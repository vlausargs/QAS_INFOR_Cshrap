
Option Explicit On

Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Configuration
Imports Mongoose.Core.Common
Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO

<IDOExtensionClass("SLMobileDeviceDatas")>
Public Class SLMobileDeviceDatas
    Inherits ExtensionClassBase
    'We serialize new parameters as sync options because Mongoose doesn't handle optional parms on IDO Extension Methods
    Public Class SyncOptions
        Public IncludeLogo As Boolean
        Public IncludeImages As Boolean = True
        Public IncludeAttachments As Boolean = True
        Public AllowImages As Boolean = True
        Public AllowAttachments As Boolean = True
        Public AppVersion As String = ""
    End Class


    <IDOMethod(MethodFlags.None, "sInfobar")>
    Public Function MobileServiceGetDataSp(ByVal CustomerFilter As Integer,'0=All,1=AssignedToWork,2=AssignedToPartner,3=PartnersArea
                                           ByVal ItemFilter As Integer,'0=All,1=PartnerWhse
                                           ByVal UnitFilter As Integer,'0=All,1=AssignedToWork,2=OwnedByCustomer,3=AssignedToPartner
                                           ByVal IncludeSlowMoving As Boolean,
                                           ByVal IncludeObsolete As Boolean,
                                           ByVal PastHistoryDays As Integer,
                                           ByVal DeviceId As String,
                                           ByVal Username As String,
                                           ByVal DeviceName As String,
                                           ByRef ClearOld As Boolean,
                                           ByRef LastQueryTime As String,  'DateStamp in SQLTime Format  YYYY-MM-DD
                                           ByRef LastTableSequence As Integer,
                                           ByRef LastSyncSeq As Integer,
                                           ByRef JSONData As String,
                                           ByRef sInfobar As String) As Integer
        Try
            Dim CompanyImage As String = Nothing
            Dim syncStart As DateTime = Now()
            Dim bRS8416Active As Boolean = False
            Dim DoFullSync As Boolean = True
            Dim oTables As New Generic.Dictionary(Of String, clsTableData)(StringComparer.CurrentCultureIgnoreCase)
            Dim settings As JsonSerializerSettings = New JsonSerializerSettings()
            Dim Is915OrLater As Boolean = False
            Dim mOptions As New SyncOptions()
            Dim mLastTableSequence As Integer = LastTableSequence
            Dim mAppVersion As String
            Dim mMongooseVersion As String
            Dim bHasMoreRecords As Boolean = False
            Dim SyncDate As DateTime
            Dim FormServer As String = vbNullString
            Dim FormDatabase As String = vbNullString
            Dim FormatProvider As IFormatProvider = New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name, True)
            Dim oParms As List(Of SqlParameter)
            Dim SettingsChanged As Boolean
            settings.NullValueHandling = NullValueHandling.Ignore

            bHasMoreRecords = False

            MobileServiceGetDataSp = 0

            oTables = New Generic.Dictionary(Of String, clsTableData)(StringComparer.CurrentCultureIgnoreCase)
            'save input parms

            If (Not String.IsNullOrEmpty(JSONData)) Then
                JSONData = JSONData.Replace("#COMMA#", ",")
                mOptions = JsonConvert.DeserializeObject(Of SyncOptions)(JSONData)
                JSONData = ""
            End If

            If mOptions IsNot Nothing AndAlso mOptions.AppVersion <> "" Then
                'format will be Major.Minor.Release.Build
                Dim segments As String() = mOptions.AppVersion.Split(".")
                If segments.Length = 4 AndAlso (GetInteger(segments(0)) > 9 OrElse GetInteger(segments(1)) > 1 OrElse GetInteger(segments(2)) > 4) Then
                    Is915OrLater = True
                End If
            End If

            Using SyncSettings As New ClsSyncSettings("MobileService", DeviceId, DeviceName, Username, LastSyncSeq,
                                                    mOptions.IncludeImages, mOptions.IncludeAttachments, Is915OrLater,
                                                    CustomerFilter, ItemFilter, UnitFilter, IncludeObsolete, IncludeSlowMoving,
                                                    GetDate(LastQueryTime, FormatProvider), mOptions.AllowImages, mOptions.AllowAttachments) With {
                .LogContext = String.Format("{0}:{1}", "MobileService", Username),
                .ResponseSize = 2  'initialize to 2 to account for Json
                }
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Include Images: {0}", SQLBoolean(SyncSettings.IncludeImages)))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Include Attachments: {0}", SQLBoolean(SyncSettings.IncludeAttachments)))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("IS 915 or Later: {0}", SQLBoolean(SyncSettings.Is915OrLater)))
                Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()


                    'if we are on the initial assume a clear local and process full.
                    If SyncSettings.ParmSyncSeq > 0 Then
                        CheckForUnProcessedSentRecord(appDB, DoFullSync, SyncSettings)

                        'if we didn't find one already sent with the last sequence 
                        If DoFullSync Then
                            CheckForUnsentPartialDownload(appDB, DoFullSync, SyncSettings)
                        End If
                    End If
                    'nothing else to check we are now doing a full sync
                    If DoFullSync Then
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Doing full sync for user: {0}", Username))
                        'if we are doing a full sync clear any orphan tmp records from failed prior syncs in case not cleaned up above.
                        oParms = New List(Of SqlParameter) From {
                            New SqlParameter("@DeviceID", DeviceId),
                            New SqlParameter("@Username", Username)
                        }
                        ExecuteSQLStatement("DELETE FROM mobile_device_data_sync WHERE device_id= @DeviceID AND username = @Username", appDB, oParms, SyncSettings)

                        Using formDB As Mongoose.Core.DataAccess.FrameworkDB = IDORuntime.Context.CreateFormsDB()

                            Dim FormsConnection As ConnectionProfile = formDB.Profile
                            Dim FormsName As String = FormsConnection.DatabaseName
                            Dim DecodedFormsName As String = vbNullString
                            Dim oEncrytion As New Symmetric

                            Try
                                Symmetric.Decrypt(FormsName, DecodedFormsName)
                                FormDatabase = DecodedFormsName
                            Catch ex As Exception
                                Return Nothing
                            End Try

                            ' Decrypt Form Db Connection Information     
                            oEncrytion.Decrypt(vbNullString, FormsConnection.DataSource, FormServer)

                            If Not String.IsNullOrEmpty(FormServer) AndAlso FormServer.ToLower <> "localhost" Then
                                oParms = New List(Of SqlParameter) From {
                                    New SqlParameter("@Server", FormServer)
                                }
                                If Lookup("SELECT 1 FROM sys.servers WHERE name = @Server", appDB, oParms, SyncSettings) = "" Then
                                    'if the form server is not in sys.servers then fall back to localhost
                                    'this handles the cloud scenario where the configuration is pointing to a listener.
                                    FormServer = "localhost"
                                End If
                            End If
                        End Using

                        If (mOptions IsNot Nothing AndAlso mOptions.IncludeLogo) Then
                            If (Not String.IsNullOrEmpty(FormServer) And Not String.IsNullOrEmpty(FormDatabase)) Then
                                If FormServer.ToLower = "localhost" Then
                                    oParms = New List(Of SqlParameter) From {
                                        New SqlParameter("@UserName", SyncSettings.Username)
                                    }
                                    CompanyImage = ImageLookup("SELECT  blob FROM [" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 3 AND ScopeName = @UserName", appDB, oParms, SyncSettings)
                                    If (CompanyImage Is Nothing) Then
                                        oParms = New List(Of SqlParameter) From {
                                            New SqlParameter("@UserName", SyncSettings.Username)
                                        }
                                        Dim sb As New Text.StringBuilder
                                        sb.AppendFormat(" Select blob FROM [{0}].dbo.images i ", FormDatabase)
                                        sb.AppendLine("INNER Join GroupNames g ON i.ScopeName = g.GroupName")
                                        sb.AppendLine("INNER Join UserGroupMap ugm ON ugm.groupid = g.groupid")
                                        sb.AppendLine("INNER Join UserNames u ON ugm.userid = u.userid")
                                        sb.AppendLine("WHERE FileName = 'company-logo.jpg' AND ugm.FormGroupFlag = 1 AND i.ScopeType = 2 AND username = @UserName")

                                        CompanyImage = ImageLookup(sb.ToString(), appDB, oParms, SyncSettings)
                                    End If

                                    If (CompanyImage Is Nothing) Then
                                        CompanyImage = ImageLookup("SELECT  blob FROM [" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 1", appDB, Nothing, SyncSettings)
                                        If (CompanyImage Is Nothing) Then
                                            CompanyImage = ImageLookup("SELECT  blob FROM [" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 0", appDB, Nothing, SyncSettings)
                                        End If
                                    End If
                                Else
                                    oParms = New List(Of SqlParameter) From {
                                        New SqlParameter("@UserName", SyncSettings.Username)
                                    }
                                    CompanyImage = ImageLookup("SELECT blob FROM [" + FormServer + "].[" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 3 AND ScopeName = @UserName", appDB, oParms, SyncSettings)
                                    If (CompanyImage Is Nothing) Then
                                        oParms = New List(Of SqlParameter) From {
                                            New SqlParameter("@UserName", SyncSettings.Username)
                                        }
                                        Dim sb As New Text.StringBuilder
                                        sb.AppendFormat(" Select  blob FROM [{0}].[{1}].dbo.images i ", FormServer, FormDatabase)
                                        sb.AppendLine("INNER Join GroupNames g ON i.ScopeName = g.GroupName")
                                        sb.AppendLine("INNER Join UserGroupMap ugm ON ugm.groupid = g.groupid")
                                        sb.AppendLine("INNER Join UserNames u ON ugm.userid = u.userid")
                                        sb.AppendLine("WHERE FileName = 'company-logo.jpg' AND ugm.FormGroupFlag = 1 AND i.ScopeType = 2 AND username = @UserName")

                                        CompanyImage = ImageLookup(sb.ToString(), appDB, oParms, SyncSettings)
                                    End If
                                    If (CompanyImage Is Nothing) Then
                                        CompanyImage = ImageLookup("SELECT blob FROM [" + FormServer + "].[" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 1", appDB, Nothing, SyncSettings)
                                        If (CompanyImage Is Nothing) Then
                                            CompanyImage = ImageLookup("SELECT blob FROM [" + FormServer + "].[" + FormDatabase + "].dbo.images WHERE FileName = 'company-logo.jpg' AND ScopeType = 0", appDB, Nothing, SyncSettings)
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        'Get Version Info    
                        mMongooseVersion = MGInfo.Version
                        mAppVersion = Lookup("SELECT ProductVersion FROM ProductVersion", appDB, Nothing, SyncSettings)

                        'Account for size of values
                        If Not String.IsNullOrEmpty(mMongooseVersion) Then
                            SyncSettings.ResponseSize = SyncSettings.ResponseSize + mMongooseVersion.Length + 13
                            SyncSettings.JSONOut = SyncSettings.JSONOut + ",""MGVersion"":""" + mMongooseVersion + """"
                        End If
                        If Not String.IsNullOrEmpty(mAppVersion) Then
                            SyncSettings.ResponseSize = SyncSettings.ResponseSize + mAppVersion.Length + 13
                            SyncSettings.JSONOut = SyncSettings.JSONOut + ",""AppVersion"":""" + mAppVersion + """"
                        End If
                        If Not String.IsNullOrEmpty(CompanyImage) Then
                            SyncSettings.ResponseSize = SyncSettings.ResponseSize + CompanyImage.Length + 13
                            SyncSettings.JSONOut = SyncSettings.JSONOut + ",""CompanyImage"":""" + CompanyImage + """"
                        End If

                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Processing for user: {0}", SyncSettings.Username))
                        'set new sync date This is not the value passed in
                        SyncDate = Lookup("SELECT dbo.GetSiteNow()", appDB, Nothing, SyncSettings)
                        SyncSettings.CurrentDate = SyncDate
                        bRS8416Active = GetBoolean(Lookup("SELECT dbo.IsFeatureActive('CSI','RS8416')", appDB, Nothing, SyncSettings))

                        If String.IsNullOrEmpty(DeviceId) Then
                            sInfobar = GetMessageProvider.GetMessage("E=NoCompare", "@fs_tmp.id", "@!blank")
                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                            Return 16
                        End If


                        SyncSettings.PastHistory = PastHistoryDays
                        oParms = New List(Of SqlParameter) From {
                            New SqlParameter("@PastHistory", PastHistoryDays)
                        }
                        SyncSettings.HistoryCutoff = Lookup("SELECT DATEADD(dd,-1*@PastHistory,dbo.GetSiteNow())", appDB, oParms, SyncSettings)

                        oParms = New List(Of SqlParameter) From {
                            New SqlParameter("@Username", Username)
                        }
                        Using dt As DataTable = GetDatatable("SELECT
                                              partner_id
                                            , whse
                                            FROM fs_partner
                                            WHERE username = @Username
                                            AND  active = 1", appDB, oParms, SyncSettings, sInfobar)
                            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                                sInfobar = GetMessageProvider.GetMessage("I=NoExist1", "@fs_partner", "@!UserName", Username)
                                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                                Return 16
                            Else
                                SyncSettings.PartnerId = dt.Rows(0)("partner_id")
                                SyncSettings.PartnerWhse = GetString(dt.Rows(0)("whse"))
                                dt.Clear()
                                dt.Columns.Clear()
                            End If

                        End Using
                        If SyncSettings.ItemFilter = 1 AndAlso SyncSettings.PartnerWhse = "" Then
                            SyncSettings.ItemFilter = 0
                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Partner warehouse is blank, overriding Item Filter to return all items.")
                        End If

                        If bRS8416Active Then

                            'Check for admin override
                            Using dt As DataTable = GetDatatable("SELECT allow_device_settings, days_history, customer_filter, item_filter, unit_filter,include_slow_moving, include_obsolete,include_attachments,include_images FROM mobile_parms",
                                                                 appDB, Nothing, SyncSettings, "")

                                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                                    'we don't allow devices to set there values so override
                                    If Not GetBoolean(dt.Rows(0)("allow_device_settings")) Then
                                        SettingsChanged = True
                                        SyncSettings.AllowDeviceSettings = False
                                        SyncSettings.CustomerFilter = GetInteger(dt.Rows(0)("customer_filter"))
                                        SyncSettings.UnitFilter = GetInteger(dt.Rows(0)("unit_filter"))
                                        SyncSettings.ItemFilter = GetInteger(dt.Rows(0)("item_filter"))
                                        SyncSettings.IncludeObsolete = GetBoolean(dt.Rows(0)("include_obsolete"))
                                        SyncSettings.IncludeSlowMoving = GetBoolean(dt.Rows(0)("include_slow_moving"))
                                        SyncSettings.PastHistory = GetInteger(dt.Rows(0)("days_history"))

                                        oParms = New List(Of SqlParameter) From {
                                            New SqlParameter("@PastHistory", SyncSettings.PastHistory)
                                        }
                                        SyncSettings.HistoryCutoff = Lookup("SELECT DATEADD(dd,-1*@PastHistory,dbo.GetSiteNow())", appDB, oParms, SyncSettings)
                                        Dim bOldAllowImages As Boolean = SyncSettings.AllowImages
                                        Dim bOldAllowAttachments As Boolean = SyncSettings.AllowAttachments

                                        SyncSettings.AllowAttachments = GetBoolean(dt.Rows(0)("include_attachments"))
                                        SyncSettings.AllowImages = GetBoolean(dt.Rows(0)("include_images"))
                                        'if the admin doesn't allow it don't let the user override but if the admin does allow then let the user turn off the following settings
                                        If Not SyncSettings.AllowAttachments And SyncSettings.IncludeAttachments Then
                                            SyncSettings.IncludeAttachments = False
                                        End If
                                        'if the allow Attachments changed since last sync 
                                        If SyncSettings.AllowAttachments <> bOldAllowAttachments Then
                                            If SyncSettings.AllowAttachments Then
                                                SyncSettings.IncludeAttachments = True
                                            Else
                                                SyncSettings.IncludeAttachments = False
                                            End If
                                        End If
                                        'if the allow images changed since last sync 
                                        If SyncSettings.AllowImages <> bOldAllowImages Then
                                            'if this isn't the first sync have the sync clear old and re-download
                                            If SyncSettings.ParmSyncSeq > 0 Then
                                                SyncSettings.ParmSyncSeq = 0
                                            End If

                                            If SyncSettings.AllowImages Then
                                                SyncSettings.IncludeImages = True
                                            Else
                                                SyncSettings.IncludeImages = False
                                            End If
                                        End If
                                    Else
                                        SyncSettings.AllowDeviceSettings = True
                                    End If
                                End If
                            End Using



                            Dim mListForceShowTables As List(Of String) = New List(Of String)()
                            Dim UserStringsTable As String = ""
                            oParms = New List(Of SqlParameter) From {
                                New SqlParameter("@Username", SyncSettings.Username)
                            }
                            Dim sb As New StringBuilder
                            sb.AppendLine("SELECT ido_name FROM MobileUserIDOView WHERE app_name = 'MobileService' AND is_system = 1 AND show_on_menu = 1 AND shown_in_base = 0 AND UserName = @Username")
                            sb.AppendLine("UNION")
                            sb.AppendLine("SELECT mdc.ido_name FROM MobileUserIDOView mui INNER JOIN mobile_device_child_ido mdc ON mui.app_name = mdc.app_name AND mui.ido_name = mdc.ido_name")
                            sb.AppendLine("WHERE mui.app_name = 'MobileService' AND mui.is_system = 1 AND mui.shown_in_base = 0 AND UserName = @Username")
                            Using dt As DataTable = GetDatatable(sb.ToString(), appDB, oParms, SyncSettings)

                                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                                    For Each orow As DataRow In dt.Rows
                                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Adding system IDO {0} to custom list.", GetString(orow("ido_name"))))
                                        mListForceShowTables.Add(GetString(orow("ido_name")))
                                    Next
                                End If
                            End Using
                            'get user strings table
                            If (Not String.IsNullOrEmpty(FormServer) And Not String.IsNullOrEmpty(FormDatabase)) Then
                                If FormServer.ToLower = "localhost" Then
                                    oParms = New List(Of SqlParameter) From {
                                        New SqlParameter("@Username", SyncSettings.Username)
                                    }
                                    sb.Length = 0
                                    sb.AppendLine("SELECT Top 1 lang.StringTableName")
                                    sb.AppendLine("FROM LanguageIDs lang")
                                    sb.AppendLine("INNER JOIN UserNames u ON lang.LanguageCode = u.LanguageCode ")
                                    sb.AppendLine("WHERE u.username = @Username")
                                    sb.AppendFormat("AND EXISTS(SELECT 1 FROM {0}.INFORMATION_SCHEMA.Tables ", SQLQuoted(FormDatabase))
                                    sb.AppendLine()
                                    sb.AppendLine("WHERE TABLE_TYPE = N'BASE TABLE' ")
                                    sb.AppendLine("AND TABLE_NAME = lang.StringTableName)")
                                    sb.AppendLine("ORDER BY lang.LanguageID ASC")
                                    UserStringsTable = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                                Else
                                    oParms = New List(Of SqlParameter) From {
                                        New SqlParameter("@Username", SyncSettings.Username)
                                    }
                                    sb.Length = 0
                                    sb.AppendLine("SELECT Top 1 lang.StringTableName")
                                    sb.AppendLine("FROM LanguageIDs lang")
                                    sb.AppendLine("INNER JOIN UserNames u ON lang.LanguageCode = u.LanguageCode ")
                                    sb.AppendLine("WHERE u.username = @Username")
                                    sb.AppendFormat("AND EXISTS(SELECT 1 FROM {0}.{1}.INFORMATION_SCHEMA.Tables ", SQLQuoted(FormServer), SQLQuoted(FormDatabase))
                                    sb.AppendLine()
                                    sb.AppendLine("WHERE TABLE_TYPE = N'BASE TABLE' ")
                                    sb.AppendLine("AND TABLE_NAME = lang.StringTableName)")
                                    sb.AppendLine("ORDER BY lang.LanguageID ASC")
                                    UserStringsTable = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                                End If
                            End If

                            If String.IsNullOrEmpty(UserStringsTable) Then
                                UserStringsTable = "Strings"
                            End If

                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Strings table for user {0} is {1}.", SyncSettings.Username, UserStringsTable))
                            SyncSettings.UserStringsTable = UserStringsTable
                            SyncSettings.FormDatabase = FormDatabase
                            SyncSettings.FormServer = FormServer
                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Setting up temp tables.")
                            If Not SetupTempTablesRS8416(appDB, settings, sInfobar, SyncSettings, FormatProvider, mListForceShowTables, False) Then Return 16

                            'return sync parms
                            If SettingsChanged Then
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""SettingsChanged"":""" + SettingsChanged.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""CustomerFilter"":""" + SyncSettings.CustomerFilter.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""UnitFilter"":""" + SyncSettings.UnitFilter.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""ItemFilter"":""" + SyncSettings.ItemFilter.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""IncludeObsolete"":""" + SyncSettings.IncludeObsolete.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""IncludeSlowMoving"":""" + SyncSettings.IncludeSlowMoving.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""IncludeAttachments"":""" + SyncSettings.IncludeAttachments.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""IncludeImages"":""" + SyncSettings.IncludeImages.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""AllowAttachments"":""" + SyncSettings.AllowAttachments.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""AllowImages"":""" + SyncSettings.AllowImages.ToString() + """"
                                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""PastHistory"":""" + SyncSettings.PastHistory.ToString() + """"
                            End If
                        Else
                            SyncSettings.AllowDeviceSettings = True
                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Setting up temp tables.")
                            If Not SetupTempTables(appDB, settings, sInfobar, SyncSettings, FormatProvider) Then Return 16
                        End If
                        SyncSettings.JSONOut = SyncSettings.JSONOut + ",""AllowDeviceSettings"":""" + SyncSettings.AllowDeviceSettings.ToString() + """"
                        LastQueryTime = SQLDateTime(SyncDate, FormatProvider) ' only set this if we did a full sync

                    End If

                    oParms = New List(Of SqlParameter) From {
                        New SqlParameter("@DeviceID", DeviceId),
                        New SqlParameter("@Username", SyncSettings.Username)
                    }
                    If Lookup("SELECT 1 FROM mobile_device_data_sync WHERE device_id= @DeviceID AND username = @Username AND is_sent = 0", appDB, oParms, SyncSettings) = "1" Then
                        bHasMoreRecords = True
                        LastTableSequence = 99  'we are still setting the old parameter for backwards compatibility
                    Else
                        LastTableSequence = 0
                    End If
                    LastSyncSeq = SyncSettings.DeviceSyncSeq
                    ClearOld = SyncSettings.ClearOld
                    SyncSettings.JSONOut = SyncSettings.JSONOut + ",""RecordCount"":""" + SyncSettings.RecordCount.ToString() + """"
                    JSONData = "{" + SyncSettings.JSONOut.TrimStart(","c) + "}"

                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Actual Response Size: {0} MB / Max: {1} MB.", SyncSettings.JSONOut.Length / 1000000, SyncSettings.MaxResponseSize / 1000000))
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Has more records: {0} ", SQLBoolean(bHasMoreRecords)))
                    SyncSettings.JSONOut = ""
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Synchronization Complete. Duration: {0}", (Now - syncStart).ToString()))
                End Using
            End Using
            Return 0
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage(String.Format("{0}:{1}", "MobileService", Username), LogMessageTypes.Error, sInfobar)

            Return 16
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "sInfobar")>
    Public Function MobileServiceValidateDataSp(ByVal ProcessID As String,
                                                ByVal CustomerFilter As Integer,'0=All,1=AssignedToWork,2=AssignedToPartner,3=PartnersArea
                                                ByVal ItemFilter As Integer,'0=All,1=PartnerWhse
                                                ByVal UnitFilter As Integer,'0=All,1=AssignedToWork,2=OwnedByCustomer,3=AssignedToPartner
                                                ByVal IncludeSlowMoving As Boolean,
                                                ByVal IncludeObsolete As Boolean,
                                                ByVal PastHistoryDays As Integer,
                                                ByVal IncludeImages As Boolean,
                                                ByVal IncludeAttachments As Boolean,
                                                ByVal Username As String,
                                                ByRef sInfobar As String) As Integer
        Try
            Dim CompanyImage As String = Nothing
            Dim syncStart As DateTime = Now()
            Dim DoFullSync As Boolean = True
            Dim oTables As New Generic.Dictionary(Of String, clsTableData)(StringComparer.CurrentCultureIgnoreCase)
            Dim settings As JsonSerializerSettings = New JsonSerializerSettings()
            Dim Is915OrLater As Boolean = True
            Dim bHasMoreRecords As Boolean = False
            Dim SyncDate As DateTime
            Dim FormServer As String = vbNullString
            Dim FormDatabase As String = vbNullString
            Dim FormatProvider As IFormatProvider = New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name, True)
            Dim oParms As List(Of SqlParameter)

            settings.NullValueHandling = NullValueHandling.Ignore

            MobileServiceValidateDataSp = 0

            oTables = New Generic.Dictionary(Of String, clsTableData)(StringComparer.CurrentCultureIgnoreCase)
            'save input parms


            Using SyncSettings As New ClsSyncSettings("MobileService", ProcessID, "VALDATE", Username, 0,
                                                    IncludeImages, IncludeAttachments, Is915OrLater,
                                                    CustomerFilter, ItemFilter, UnitFilter, IncludeObsolete, IncludeSlowMoving,
                                                    Nothing, IncludeImages, IncludeAttachments) With {
                .LogContext = "MobileService:Validate",
                .ResponseSize = 2  'initialize to 2 to account for Json
                }
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Include Images: {0}", SQLBoolean(SyncSettings.IncludeImages)))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Include Attachments: {0}", SQLBoolean(SyncSettings.IncludeAttachments)))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("IS 915 or Later: {0}", SQLBoolean(SyncSettings.Is915OrLater)))
                Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                    Using formDB As Mongoose.Core.DataAccess.FrameworkDB = IDORuntime.Context.CreateFormsDB()

                        Dim FormsConnection As ConnectionProfile = formDB.Profile
                        Dim FormsName As String = FormsConnection.DatabaseName
                        Dim DecodedFormsName As String = vbNullString
                        Dim oEncrytion As New Symmetric

                        Try
                            Symmetric.Decrypt(FormsName, DecodedFormsName)
                            FormDatabase = DecodedFormsName
                        Catch ex As Exception
                            Return Nothing
                        End Try

                        ' Decrypt Form Db Connection Information     
                        oEncrytion.Decrypt(vbNullString, FormsConnection.DataSource, FormServer)

                        If Not String.IsNullOrEmpty(FormServer) AndAlso FormServer.ToLower <> "localhost" Then
                            oParms = New List(Of SqlParameter) From {
                                New SqlParameter("@Server", FormServer)
                            }
                            If Lookup("SELECT 1 FROM sys.servers WHERE name = @Server", appDB, oParms, SyncSettings) = "" Then
                                'if the form server is not in sys.servers then fall back to localhost
                                'this handles the cloud scenario where the configuration is pointing to a listener.
                                FormServer = "localhost"
                            End If
                        End If
                    End Using

                    If Not ClearValidationRecord(appDB, SyncSettings, sInfobar) Then Return 16


                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Processing for user: {0}", SyncSettings.Username))
                    'set new sync date This is not the value passed in
                    SyncDate = Lookup("SELECT dbo.GetSiteNow()", appDB, Nothing, SyncSettings)
                    SyncSettings.CurrentDate = SyncDate

                    If String.IsNullOrEmpty(ProcessID) Then
                        sInfobar = GetMessageProvider.GetMessage("E=NoCompare", "@fs_tmp.id", "@!blank")
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                        Return 16
                    End If

                    If (PastHistoryDays > 0) Then
                        SyncSettings.PastHistory = PastHistoryDays
                        oParms = New List(Of SqlParameter) From {
                            New SqlParameter("@PastHistory", PastHistoryDays)
                        }
                        SyncSettings.HistoryCutoff = Lookup("SELECT DATEADD(dd,-1*@PastHistory,dbo.GetSiteNow())", appDB, oParms, SyncSettings)
                    End If

                    oParms = New List(Of SqlParameter) From {
                        New SqlParameter("@Username", Username)
                    }
                    Using dt As DataTable = GetDatatable("SELECT
                                              partner_id
                                            , whse
                                            FROM fs_partner
                                            WHERE username = @Username
                                            AND  active = 1", appDB, oParms, SyncSettings, sInfobar)
                        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                            sInfobar = GetMessageProvider.GetMessage("I=NoExist1", "@fs_partner", "@!UserName", Username)
                            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                            Return 16
                        Else
                            SyncSettings.PartnerId = dt.Rows(0)("partner_id")
                            SyncSettings.PartnerWhse = GetString(dt.Rows(0)("whse"))
                            dt.Clear()
                            dt.Columns.Clear()
                        End If

                    End Using
                    If SyncSettings.ItemFilter = 1 AndAlso SyncSettings.PartnerWhse = "" Then
                        SyncSettings.ItemFilter = 0
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Partner warehouse is blank, overriding Item Filter to return all items.")
                    End If


                    Dim mListForceShowTables As List(Of String) = New List(Of String)()
                    Dim UserStringsTable As String = ""
                    oParms = New List(Of SqlParameter) From {
                        New SqlParameter("@Username", SyncSettings.Username)
                    }
                    Dim sb As New StringBuilder
                    sb.AppendLine("SELECT ido_name FROM MobileUserIDOView WHERE app_name = 'MobileService' AND is_system = 1 AND show_on_menu = 1 AND shown_in_base = 0 AND UserName = @Username")
                    sb.AppendLine("UNION")
                    sb.AppendLine("SELECT mdc.ido_name FROM MobileUserIDOView mui INNER JOIN mobile_device_child_ido mdc ON mui.app_name = mdc.app_name AND mui.ido_name = mdc.ido_name")
                    sb.AppendLine("WHERE mui.app_name = 'MobileService' AND mui.is_system = 1 AND mui.shown_in_base = 0 AND UserName = @Username")
                    Using dt As DataTable = GetDatatable(sb.ToString(), appDB, oParms, SyncSettings)

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            For Each orow As DataRow In dt.Rows
                                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Adding system IDO {0} to custom list.", GetString(orow("ido_name"))))
                                mListForceShowTables.Add(GetString(orow("ido_name")))
                            Next
                        End If
                    End Using
                    'get user strings table
                    If (Not String.IsNullOrEmpty(FormServer) And Not String.IsNullOrEmpty(FormDatabase)) Then
                        If FormServer.ToLower = "localhost" Then
                            oParms = New List(Of SqlParameter) From {
                                New SqlParameter("@Username", SyncSettings.Username)
                            }
                            sb.Length = 0
                            sb.AppendLine("SELECT Top 1 lang.StringTableName")
                            sb.AppendLine("FROM LanguageIDs lang")
                            sb.AppendLine("INNER JOIN UserNames u ON lang.LanguageCode = u.LanguageCode ")
                            sb.AppendLine("WHERE u.username = @Username")
                            sb.AppendFormat("AND EXISTS(SELECT 1 FROM {0}.INFORMATION_SCHEMA.Tables ", SQLQuoted(FormDatabase))
                            sb.AppendLine()
                            sb.AppendLine("WHERE TABLE_TYPE = N'BASE TABLE' ")
                            sb.AppendLine("AND TABLE_NAME = lang.StringTableName)")
                            sb.AppendLine("ORDER BY lang.LanguageID ASC")
                            UserStringsTable = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                        Else
                            oParms = New List(Of SqlParameter) From {
                                New SqlParameter("@Username", SyncSettings.Username)
                            }
                            sb.Length = 0
                            sb.AppendLine("SELECT Top 1 lang.StringTableName")
                            sb.AppendLine("FROM LanguageIDs lang")
                            sb.AppendLine("INNER JOIN UserNames u ON lang.LanguageCode = u.LanguageCode ")
                            sb.AppendLine("WHERE u.username = @Username")
                            sb.AppendFormat("AND EXISTS(SELECT 1 FROM {0}.{1}.INFORMATION_SCHEMA.Tables ", SQLQuoted(FormServer), SQLQuoted(FormDatabase))
                            sb.AppendLine()
                            sb.AppendLine("WHERE TABLE_TYPE = N'BASE TABLE' ")
                            sb.AppendLine("AND TABLE_NAME = lang.StringTableName)")
                            sb.AppendLine("ORDER BY lang.LanguageID ASC")
                            UserStringsTable = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                        End If
                    End If

                    If String.IsNullOrEmpty(UserStringsTable) Then
                        UserStringsTable = "Strings"
                    End If

                    If String.IsNullOrEmpty(UserStringsTable) Then
                        UserStringsTable = "Strings"
                    End If
                    SyncSettings.UserStringsTable = UserStringsTable
                    SyncSettings.FormDatabase = FormDatabase
                    SyncSettings.FormServer = FormServer
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Setting up temp tables.")
                    If Not SetupTempTablesRS8416(appDB, settings, sInfobar, SyncSettings, FormatProvider, mListForceShowTables, True) Then Return 16

                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Actual Response Size: {0} MB / Max: {1} MB.", SyncSettings.JSONOut.Length / 1000000, SyncSettings.MaxResponseSize / 1000000))
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Has more records: {0} ", SQLBoolean(bHasMoreRecords)))
                    SyncSettings.JSONOut = ""
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Synchronization Complete. Duration: {0}", (Now - syncStart).ToString()))
                End Using
            End Using
            Return 0
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage("MobileService:Validate", LogMessageTypes.Error, sInfobar)

            Return 16
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "sInfobar")>
    Public Function MobileServiceValidateCleanupSp(ByVal ProcessID As String, ByRef sInfobar As String) As Integer
        Try
            MobileServiceValidateCleanupSp = 0

            Using SyncSettings As New ClsSyncSettings("MobileService", ProcessID, "CLEANUP", "", 0,
                                                    False, False, True,
                                                    0, 0, 0, False, False,
                                                    Nothing, False, False) With {
                .LogContext = "MobileService:Cleanup",
                .ResponseSize = 0
                }
                Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                    If Not ClearValidationRecord(appDB, SyncSettings, sInfobar) Then Return 16
                End Using
            End Using
            Return 0
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage("MobileService:Cleanup", LogMessageTypes.Error, sInfobar)
            Return 16
        End Try
    End Function

    Sub CheckForUnProcessedSentRecord(ByRef appDB As ApplicationDB, ByRef DoFullSync As Boolean,
                                      ByRef SyncSettings As ClsSyncSettings)
        Dim oParms As List(Of SqlParameter)
        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Checking for incomplete sync record.")
        oParms = New List(Of SqlParameter) From {
            New SqlParameter("@AppName", SyncSettings.AppId),
            New SqlParameter("@DeviceID", SyncSettings.DeviceID),
            New SqlParameter("@Username", SyncSettings.Username),
            New SqlParameter("@SyncSequence", SyncSettings.ParmSyncSeq + 1)
        }
        If Lookup("SELECT 1 FROM mobile_device_data_sync WHERE app_name = @AppName AND device_id= @DeviceID AND username = @Username AND sync_sequence = @SyncSequence AND is_sent = 1", appDB, oParms, SyncSettings) = "1" Then

            'this means we sent a result set but the device never received it so resend
            oParms = New List(Of SqlParameter) From {
                New SqlParameter("@AppName", SyncSettings.AppId),
                New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                New SqlParameter("@Username", SyncSettings.Username),
                New SqlParameter("@SyncSequence", SyncSettings.ParmSyncSeq + 1)
            }
            Dim dr As DataRow = GetFirstRowFromSelect("SELECT device_data,record_count FROM mobile_device_data_sync WHERE app_name = @AppName AND device_id= @DeviceID AND username = @Username AND sync_sequence = @SyncSequence AND is_sent = 1", appDB, oParms, SyncSettings)
            If dr IsNot Nothing Then
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Found Incomplete sync re-send last.")
                SyncSettings.JSONOut = GetString(dr("device_data"))
                SyncSettings.RecordCount = GetInteger(dr("record_count"))
                SyncSettings.DeviceSyncSeq = SyncSettings.ParmSyncSeq + 1
                DoFullSync = False
            End If
            dr = Nothing
        End If
    End Sub
    Sub CheckForUnsentPartialDownload(ByRef appDB As ApplicationDB, ByRef DoFullSync As Boolean,
                                      ByRef SyncSettings As ClsSyncSettings)
        Dim oParms As List(Of SqlParameter)

        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Checking for partial sync record for sync sequence: {0}.", SyncSettings.ParmSyncSeq.ToString()))

        oParms = New List(Of SqlParameter) From {
            New SqlParameter("@AppName", SyncSettings.AppId),
            New SqlParameter("@DeviceID", SyncSettings.DeviceID),
            New SqlParameter("@Username", SyncSettings.Username),
            New SqlParameter("@SyncSequence", SyncSettings.ParmSyncSeq)
        }
        If Lookup("SELECT 1 FROM mobile_device_data_sync WHERE app_name = @AppName AND device_id= @DeviceID AND username = @Username", appDB, oParms, SyncSettings) = "1" Then
            ' this means we we found a result set that the device successfully processed clear it and look for another
            oParms = New List(Of SqlParameter) From {
                New SqlParameter("@AppName", SyncSettings.AppId),
                New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                New SqlParameter("@Username", SyncSettings.Username)
            }
            'oParms.Add(New SqlParameter("@SyncSequence", SyncSettings.ParmSyncSeq))
            ExecuteSQLStatement("DELETE FROM mobile_device_data_sync WHERE app_name = @AppName AND device_id= @DeviceID AND username = @Username AND is_sent = 1", appDB, oParms, SyncSettings)

            'now get the next
            oParms = New List(Of SqlParameter) From {
                New SqlParameter("@AppName", SyncSettings.AppId),
                New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                New SqlParameter("@Username", SyncSettings.Username)
            }


            If GetNextRecord(appDB, SyncSettings.ParmSyncSeq + 1, SyncSettings) Then
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, "Found partial sync record, sending next segment.")
                SyncSettings.DeviceSyncSeq = SyncSettings.ParmSyncSeq + 1
                DoFullSync = False
            Else
                'we are done processing partials update the device data to current sequence and continue
                UpdateDeviceDataSequence(appDB, SyncSettings)
            End If
        End If
    End Sub

    Sub UpdateDeviceDataSequence(ByRef appDB As ApplicationDB,
                                 ByRef SyncSettings As ClsSyncSettings)
        Dim oParms As List(Of SqlParameter)
        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                           New SqlParameter("@SyncSequence", SyncSettings.ParmSyncSeq),
                                                           New SqlParameter("@ApplicationId", SyncSettings.AppId),
                                                           New SqlParameter("@Username", SyncSettings.Username)
                                                      }
        Dim sb As New StringBuilder
        sb.AppendLine("IF (SELECT COUNT(1) FROM (SELECT DISTINCT sync_sequence FROM mobile_device_data WHERE device_id = @DeviceID AND app_name = @ApplicationId AND username = @Username) AS dd) = 1")
        sb.AppendLine("UPDATE mobile_device_data set sync_sequence = @SyncSequence WHERE device_id = @DeviceID AND app_name = @ApplicationId AND username = @Username")
        ExecuteSQLStatement(sb.ToString(), appDB, oParms, SyncSettings)
    End Sub

    Function GetNextRecord(ByRef AppDB As ApplicationDB, ByVal SyncSeq As Integer, ByRef SyncSettings As ClsSyncSettings) As Boolean
        Dim oParms As List(Of SqlParameter)
        oParms = New List(Of SqlParameter) From {
             New SqlParameter("@AppName", SyncSettings.AppId),
                New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                New SqlParameter("@Username", SyncSettings.Username)
            }
        Dim dr As DataRow = GetFirstRowFromSelect("SELECT TOP 1 device_data,RowPointer,record_count FROM mobile_device_data_sync WHERE app_name = @AppName AND device_id= @DeviceID AND username = @Username AND is_sent = 0 ORDER BY sequence ASC", AppDB, oParms, SyncSettings)
        If dr IsNot Nothing Then
            SyncSettings.JSONOut = GetString(dr("device_data"))
            SyncSettings.RecordCount = GetInteger(dr("record_count"))
            'update to flag as sent
            oParms = New List(Of SqlParameter) From {
                    New SqlParameter("@RowPointer", GetString(dr("RowPointer"))),
                    New SqlParameter("@SyncSequence", SyncSeq)
                }
            ExecuteSQLStatement("update mobile_device_data_sync set is_sent = 1,sync_sequence = @SyncSequence WHERE RowPointer = @RowPointer", AppDB, oParms, SyncSettings)
            dr = Nothing
            Return True
        Else
            Return False
        End If
    End Function

    Sub UpdateTmpRecordCount(ByRef AppDB As ApplicationDB, ByRef SyncSettings As ClsSyncSettings)
        Dim oParms As List(Of SqlParameter)
        oParms = New List(Of SqlParameter) From {
            New SqlParameter("@AppName", SyncSettings.AppId),
                New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                New SqlParameter("@Username", SyncSettings.Username),
                New SqlParameter("@Count", SyncSettings.RecordCount)
            }
        ExecuteSQLStatement("update mobile_device_data_sync set record_count = @Count WHERE app_name =@AppName AND device_id= @DeviceID AND username = @Username", AppDB, oParms, SyncSettings)

    End Sub
    'can be useful for debugging but it is not supported in partial trust.
    'Public Sub WriteApplicationEvent(ByVal sServiceName As String, sMessage As String, Optional sEventLogEntryType As String = "error")

    '    Dim lType As System.Diagnostics.EventLogEntryType = EventLogEntryType.Error
    '    If sEventLogEntryType.ToLower() = "error" Then

    '        lType = EventLogEntryType.Error

    '    ElseIf sEventLogEntryType.ToLower() = "information" Then

    '        lType = EventLogEntryType.Information
    '    End If
    '    If Not EventLog.SourceExists(sServiceName) Then

    '        EventLog.CreateEventSource(sServiceName, "Application")

    '        Dim elog As EventLog = New EventLog()
    '        elog.Source = sServiceName
    '        elog.WriteEntry(sMessage, lType)
    '    End If
    'End Sub





#Region "RS8416"
    Private Function SetupTempTablesRS8416(ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                           ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider, ByRef mListForceShowTables As List(Of String), ByVal bValidateOnly As Boolean) As Boolean
        SetupTempTablesRS8416 = False

        Try
            Dim sSQL As New System.Text.StringBuilder
            Dim sAdditionalFilter As String = ""
            Dim sLinkBy As String = ""
            Dim Parms As List(Of SqlParameter)
            Dim sFilter As String
            Dim mNewCustomFields As List(Of String) = New List(Of String)
            Dim oFields As Dictionary(Of String, Dictionary(Of String, clsFieldDataRS8416)) = New Dictionary(Of String, Dictionary(Of String, clsFieldDataRS8416))
            Dim oJoins As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
            Dim oObjectNotesCache As DataTable = Nothing
            Dim oObjectDocumentsCache As DataTable = Nothing
            Dim mDuplicateCustomFields As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))

            Parms = New List(Of SqlParameter) From {
                  New SqlParameter("@Username", SyncSettings.Username)
              }
            Using table = New clsTableDataRS8416("mobile_device_field", "SLMobileDeviceFields", "muf", False, False, "appname=N'MobileService' AND UserName = @Username", Parms)
                table.fields.Add("IDO", New clsFieldDataRS8416("IDO", "IDO"))
                table.fields.Add("Property", New clsFieldDataRS8416("Property", "Property"))
                table.fields.Add("TableName", New clsFieldDataRS8416("TableName", "TableName"))
                table.fields.Add("ColumnName", New clsFieldDataRS8416("ColumnName", "ColumnName"))
                table.fields.Add("Caption", New clsFieldDataRS8416("Caption", "Caption", Translate:=True))
                table.fields.Add("DataType", New clsFieldDataRS8416("DataType", "DataType"))
                table.fields.Add("MaxLength", New clsFieldDataRS8416("MaxLength", "MaxLength"))
                table.fields.Add("Precision", New clsFieldDataRS8416("Precision", "Precision"))
                table.fields.Add("InlineList", New clsFieldDataRS8416("InlineList", "InlineList", Translate:=True))
                table.fields.Add("DownloadOnly", New clsFieldDataRS8416("DownloadOnly", "DownloadOnly"))
                table.fields.Add("Sequence", New clsFieldDataRS8416("Sequence", "Sequence"))
                table.fields.Add("ShowOnList", New clsFieldDataRS8416("ShowOnList", "ShowOnList"))
                table.fields.Add("DeviceInteraction", New clsFieldDataRS8416("DeviceInteraction", "DeviceInteraction"))
                table.fields.Add("FieldStyle", New clsFieldDataRS8416("FieldStyle", "FieldStyle"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, True, bValidateOnly) Then Return False
            End Using

            Parms = New List(Of SqlParameter) From {
             New SqlParameter("@Username", SyncSettings.Username)}
            Using table = New clsTableDataRS8416("mobileuseridoview", "SLMobileDeviceIDOs", "mdc", False, False, "app_name =N'MobileService' AND Mobileitv.TableType = 3 AND Mobileitv.DevelopmentFlag = 0 AND UserName = @Username", Parms)
                table.fields.Add("IdoName", New clsFieldDataRS8416("ido_name", "IdoName"))
                table.fields.Add("ListCaption", New clsFieldDataRS8416("list_caption", "ListCaption", Translate:=True))
                table.fields.Add("DetailCaption", New clsFieldDataRS8416("detail_caption", "DetailCaption", Translate:=True))
                table.fields.Add("ShowOnMenu", New clsFieldDataRS8416("show_on_menu", "ShowOnMenu"))
                table.fields.Add("IsSystem", New clsFieldDataRS8416("is_system", "IsSystem"))
                table.fields.Add("ShownInBase", New clsFieldDataRS8416("shown_in_base", "ShownInBase"))
                table.fields.Add("AllowNotes", New clsFieldDataRS8416("allow_notes", "AllowNotes"))
                table.fields.Add("AllowDocuments", New clsFieldDataRS8416("allow_documents", "AllowDocuments"))
                table.fields.Add("AllowAdd", New clsFieldDataRS8416("allow_add", "AllowAdd"))
                table.fields.Add("AllowDelete", New clsFieldDataRS8416("allow_delete", "AllowDelete"))
                table.fields.Add("AllowCamera", New clsFieldDataRS8416("allow_camera", "AllowCamera"))

                table.fields.Add("Picture", New clsFieldDataRS8416("picture", "Picture")) 'this is included regardless of include images option

                table.fields.Add("TableName", New clsFieldDataRS8416("TableName", "TableName", "Mobileitv.TableName"))
                table.Joins.Add("Mobileitv", "INNER JOIN ido.tables Mobileitv ON mdc.ido_name = Mobileitv.CollectionName")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then


                End If


            End Using
            Parms = New List(Of SqlParameter) From {
                New SqlParameter("@Username", SyncSettings.Username)}
            Using table = New clsTableDataRS8416("mobile_device_child_ido", "SLMobileDeviceChildIDOs", "mdcc", False, False, "mdcc.app_name =N'MobileService' AND MobileCol.Username = @Username", Parms)
                table.fields.Add("IdoName", New clsFieldDataRS8416("ido_name", "IdoName", "mdcc.ido_name"))
                table.fields.Add("ParentIdoName", New clsFieldDataRS8416("parent_ido_name", "ParentIdoName"))
                table.fields.Add("ListCaption", New clsFieldDataRS8416("list_caption", "ListCaption", "MobileCol.list_caption", Translate:=True))
                table.Joins.Add("MobileCol", "INNER JOIN MobileUserIDOView MobileCol ON mdcc.app_name = MobileCol.app_name AND mdcc.ido_name = MobileCol.ido_name")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = New List(Of SqlParameter) From {
                    New SqlParameter("@Username", SyncSettings.Username)}
            Using table = New clsTableDataRS8416("mobile_device_ido_link", "SLMobileDeviceIDOLinks", "mdcl", False, False, "mdcl.app_name =N'MobileService' AND MobileCol.Username = @Username", Parms)
                table.fields.Add("IdoName", New clsFieldDataRS8416("ido_name", "IdoName", "mdcl.ido_name"))
                table.fields.Add("ParentIdoName", New clsFieldDataRS8416("parent_ido_name", "ParentIdoName"))
                table.fields.Add("PropertyName", New clsFieldDataRS8416("property_name", "PropertyName"))
                table.fields.Add("ParentPropertyName", New clsFieldDataRS8416("parent_property_name", "ParentPropertyName"))
                table.Joins.Add("MobileCol", "INNER JOIN MobileUserIDOView MobileCol ON mdcl.app_name = MobileCol.app_name AND mdcl.ido_name = MobileCol.ido_name")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_parms", "FSParms", "prm", False, False, Nothing)
                table.fields.Add("MatlTransType", New clsFieldDataRS8416("matl_trans_type", "MatlTransType"))
                table.fields.Add("DefaultLaborRate", New clsFieldDataRS8416("default_labor_rate", "DefaultLaborRate"))
                table.fields.Add("DefaultLaborCost", New clsFieldDataRS8416("default_labor_cost", "DefaultLaborCost"))
                table.fields.Add("BillType", New clsFieldDataRS8416("bill_type", "BillType"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse"))
                table.fields.Add("StatCode", New clsFieldDataRS8416("stat_code", "StatCode"))
                table.fields.Add("PriorCode", New clsFieldDataRS8416("prior_code", "PriorCode"))
                table.fields.Add("OpStat", New clsFieldDataRS8416("op_stat", "OpStat"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("u_m", "SLUMs", "um", False, False, Nothing)
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("reason", "SLReasons", "rea", False, False, "reason_class = N'CO RETURN'")
                table.fields.Add("ReasonClass", New clsFieldDataRS8416("reason_class", "ReasonClass"))
                table.fields.Add("ReasonCode", New clsFieldDataRS8416("reason_code", "ReasonCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("site", "SLSites", "sit", False, False, Nothing)
                table.fields.Add("Site", New clsFieldDataRS8416("site", "Site", "sit.site"))
                table.fields.Add("SiteName", New clsFieldDataRS8416("site_name", "SiteName", "sit.site_name"))
                table.fields.Add("TimeZone", New clsFieldDataRS8416("time_zone", "TimeZone", "sit.time_zone"))
                table.fields.Add("SystemType", New clsFieldDataRS8416("system_type", "SystemType", "sit.system_type"))
                table.Joins.Add("mobprm", "INNER JOIN parms mobprm ON mobprm.site = sit.site")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_unit_stat_code", "FSUnitStatCodes", "usc", False, False, Nothing)
                table.fields.Add("UnitStatCode", New clsFieldDataRS8416("unit_stat_code", "UnitStatCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                table.fields.Add("Down", New clsFieldDataRS8416("Down", "Down"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_stat_code", "FSStatCodes", "sta", False, False, Nothing)
                table.fields.Add("StatCode", New clsFieldDataRS8416("stat_code", "StatCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                table.fields.Add("Closed", New clsFieldDataRS8416("Closed", "Closed"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_prior_code", "FSPriorCodes", "pri", False, False, Nothing)
                table.fields.Add("PriorCode", New clsFieldDataRS8416("prior_code", "PriorCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_pay_type", "FSPayTypes", "pay", False, False, Nothing)
                table.fields.Add("FsPayType", New clsFieldDataRS8416("fs_pay_type", "FsPayType"))
                table.fields.Add("PayDesc", New clsFieldDataRS8416("pay_desc", "PayDesc"))
                table.fields.Add("ReimbPartner", New clsFieldDataRS8416("reimb_partner", "ReimbPartner"))
                table.fields.Add("VendNum", New clsFieldDataRS8416("vend_num", "VendNum"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_misc_code", "FSMiscCodes", "MiscCode", False, False, Nothing)
                table.fields.Add("MiscCode", New clsFieldDataRS8416("misc_code", "MiscCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                table.fields.Add("Price", New clsFieldDataRS8416("price", "Price"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_work_code", "FSWorkCodes", "WorkCode", False, False, Nothing)
                table.fields.Add("WorkCode", New clsFieldDataRS8416("work_code", "WorkCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                table.fields.Add("Cost", New clsFieldDataRS8416("Cost", "Cost"))
                table.fields.Add("CostCode", New clsFieldDataRS8416("cost_code", "CostCode"))
                table.fields.Add("Rate", New clsFieldDataRS8416("Rate", "Rate"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_oper_code", "FSOperCodes", "opcd", False, False, Nothing)
                table.fields.Add("OperCode", New clsFieldDataRS8416("oper_code", "OperCode"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_res_spec", "FSResolutionSpecs", "reas", False, False, Nothing)
                table.fields.Add("ResCodeGen", New clsFieldDataRS8416("res_code_gen", "ResCodeGen"))
                table.fields.Add("ResCodeSpec", New clsFieldDataRS8416("res_code_spec", "ResCodeSpec"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_res_gen", "FSResolutions", "reas", False, False, Nothing)
                table.fields.Add("ResCodeGen", New clsFieldDataRS8416("res_code_gen", "ResCodeGen"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_reas_spec", "FSReasonSpecs", "reas", False, False, Nothing)
                table.fields.Add("ReasonGen", New clsFieldDataRS8416("reason_gen", "ReasonGen"))
                table.fields.Add("ReasonSpec", New clsFieldDataRS8416("reason_spec", "ReasonSpec"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                table.fields.Add("Duration", New clsFieldDataRS8416("duration", "Duration"))
                table.fields.Add("DurationUnits", New clsFieldDataRS8416("duration_units", "DurationUnits"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_reas_gen", "FSReasons", "reas", False, False, Nothing)
                table.fields.Add("ReasonGen", New clsFieldDataRS8416("reason_gen", "ReasonGen"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_meas_type_resp", "FSMeasTypeResps", "meastyprsp", False, False, Nothing)
                table.fields.Add("MeasType", New clsFieldDataRS8416("meas_type", "MeasType"))
                table.fields.Add("Response", New clsFieldDataRS8416("Response", "Response"))
                table.fields.Add("Failure", New clsFieldDataRS8416("Failure", "Failure"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("DocumentType", "DocumentTypes", "doc", False, False, "StorageMethod = 'D'")
                table.fields.Add("DocumentType", New clsFieldDataRS8416("DocumentType", "DocumentType"))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description"))
                table.fields.Add("DocumentExtension", New clsFieldDataRS8416("DocumentExtension", "DocumentExtension"))
                table.fields.Add("StorageMethod", New clsFieldDataRS8416("StorageMethod", "StorageMethod"))
                table.fields.Add("MediaType", New clsFieldDataRS8416("MediaType", "MediaType"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("cci_system", "CCISystems", "cci", False, False, "active=1")
                table.fields.Add("CardSystemId", New clsFieldDataRS8416("card_system_id", "CardSystemId"))
                table.fields.Add("CardSystem", New clsFieldDataRS8416("card_system", "CardSystem"))
                table.fields.Add("PaymentServer", New clsFieldDataRS8416("payment_server", "PaymentServer"))
                table.fields.Add("GatewayUserId", New clsFieldDataRS8416("gateway_user_id", "GatewayUserId"))
                table.fields.Add("GatewayPassword", New clsFieldDataRS8416("gateway_password", "GatewayPassword"))
                table.fields.Add("GatewayVendId", New clsFieldDataRS8416("gateway_vend_id", "GatewayVendId"))
                table.fields.Add("BankCode", New clsFieldDataRS8416("bank_code", "BankCode"))
                table.fields.Add("CurrCode", New clsFieldDataRS8416("curr_code", "CurrCode"))
                table.fields.Add("Active", New clsFieldDataRS8416("Active", "Active"))
                table.fields.Add("DefaultForCurrCode", New clsFieldDataRS8416("default_for_curr_code", "DefaultForCurrCode"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("cci_parms", "CCIParms", "cci", False, False, Nothing)
                table.fields.Add("ParmKey", New clsFieldDataRS8416("parm_key", "ParmKey"))
                table.fields.Add("AuthType", New clsFieldDataRS8416("auth_type", "AuthType"))
                table.fields.Add("AuthAmount", New clsFieldDataRS8416("auth_amount", "AuthAmount"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("invparms", "SLInvparms", "inv", False, False, Nothing)
                table.fields.Add("ParmKey", New clsFieldDataRS8416("parm_key", "ParmKey"))
                table.fields.Add("SerialLength", New clsFieldDataRS8416("serial_length", "SerialLength"))
                table.fields.Add("NumPad", New clsFieldDataRS8416("NumPad", "NumPad", "dbo.GetNumSortCharNumericPad() AS NumPad"))
                table.fields.Add("LeftPad", New clsFieldDataRS8416("LeftPad", "LeftPad", "dbo.GetNumSortCharLeftPad() AS LeftPad "))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_inspect_type", "FSInspectTypes", "intype", False, False, Nothing)
                table.fields.Add("InspectType", New clsFieldDataRS8416("inspect_type", "InspectType"))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_appt_stat", "FSApptStats", "appt", False, False, Nothing)
                table.fields.Add("ApptStat", New clsFieldDataRS8416("appt_stat", "ApptStat"))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description"))
                table.fields.Add("Closed", New clsFieldDataRS8416("Closed", "Closed"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableDataRS8416("customer", "SLCustomers", "cus", False, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("CustNum", New clsFieldDataRS8416("cust_num", "CustNum", "cus.cust_num", "NVARCHAR(7)", bKeyField:=True))
                table.fields.Add("CustSeq", New clsFieldDataRS8416("cust_seq", "CustSeq", "cus.cust_seq", "INT", bKeyField:=True))
                If SyncSettings.IncludeImages Then
                    table.fields.Add("Picture", New clsFieldDataRS8416("picture", "Picture", "cus.picture", "VARBINARY(MAX)"))
                End If
                table.fields.Add("Name", New clsFieldDataRS8416("name", "Name", "adr.name", "NVARCHAR(60)"))
                table.fields.Add("Addr_1", New clsFieldDataRS8416("addr##1", "Addr_1", "adr.addr##1", "NVARCHAR(50)"))
                table.fields.Add("Addr_2", New clsFieldDataRS8416("addr##2", "Addr_2", "adr.addr##2", "NVARCHAR(50)"))
                table.fields.Add("Addr_3", New clsFieldDataRS8416("addr##3", "Addr_3", "adr.addr##3", "NVARCHAR(50)"))
                table.fields.Add("Addr_4", New clsFieldDataRS8416("addr##4", "Addr_4", "adr.addr##4", "NVARCHAR(50)"))
                table.fields.Add("City", New clsFieldDataRS8416("city", "City", "adr.city", "NVARCHAR(30)"))
                table.fields.Add("State", New clsFieldDataRS8416("state", "State", "adr.state", "NVARCHAR(5)"))
                table.fields.Add("Zip", New clsFieldDataRS8416("zip", "Zip", "adr.zip", "NVARCHAR(10)"))
                table.fields.Add("Contact_1", New clsFieldDataRS8416("Contact_1", "Contact_1", "CASE WHEN cus.cust_seq = 0 THEN cus.contact##1 ELSE cc1.contact##1 END AS Contact_1", "NVARCHAR(30)"))
                table.fields.Add("Phone_1", New clsFieldDataRS8416("Phone_1", "Phone_1", "CASE WHEN cus.cust_seq = 0 THEN cus.phone##1 ELSE cc1.phone##1 END AS Phone_1", "NVARCHAR(25)"))
                table.fields.Add("FaxNum", New clsFieldDataRS8416("fax_num", "FaxNum", "adr.fax_num", "NVARCHAR(25)"))
                table.fields.Add("ExternalEmailAddr", New clsFieldDataRS8416("ExternalEmailAddr", "ExternalEmailAddr", "CASE WHEN cus.cust_seq = 0 THEN adr.external_email_addr ELSE mobbilltoaddr.external_email_addr END AS ExternalEmailAddr", "NVARCHAR(60)"))
                table.fields.Add("Contact_2", New clsFieldDataRS8416("contact##2", "Contact_2", "cus.contact##2", "NVARCHAR(30)"))
                table.fields.Add("Phone_2", New clsFieldDataRS8416("phone##2", "Phone_2", "cus.phone##2", "NVARCHAR(25)"))
                table.fields.Add("ShipToEmail", New clsFieldDataRS8416("ship_to_email", "ShipToEmail", "adr.ship_to_email", "NVARCHAR(60)"))
                table.fields.Add("Contact_3", New clsFieldDataRS8416("Contact_3", "Contact_3", "CASE WHEN cus.cust_seq = 0 THEN cus.contact##3 ELSE cc1.contact##3 END AS Contact_3", "NVARCHAR(30)"))
                table.fields.Add("Phone_3", New clsFieldDataRS8416("Phone_3", "Phone_3", "CASE WHEN cus.cust_seq = 0 THEN cus.phone##3 ELSE cc1.phone##3 END AS Phone_3", "NVARCHAR(25)"))
                table.fields.Add("BillToEmail", New clsFieldDataRS8416("bill_to_email", "BillToEmail", "adr.bill_to_email", "NVARCHAR(60)"))
                table.fields.Add("Country", New clsFieldDataRS8416("country", "Country", "adr.country", "NVARCHAR(30)"))
                table.fields.Add("County", New clsFieldDataRS8416("county", "County", "adr.county", "NVARCHAR(30)"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "mobfscust.partner_id", "NVARCHAR(10)"))
                table.fields.Add("Region", New clsFieldDataRS8416("region", "Region", "mobfscust.region", "NVARCHAR(10)"))
                table.fields.Add("CurrCode", New clsFieldDataRS8416("curr_code", "CurrCode", "adr.curr_code", "NVARCHAR(3)"))
                table.fields.Add("AddrRecordDate", New clsFieldDataRS8416("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,adr.RecordDate,121) AS AddrRecordDate", "DateTime", True))
                table.fields.Add("FSRecordDate", New clsFieldDataRS8416("FSRecordDate", "FSRecordDate", "CONVERT(NVARCHAR,mobfscust.RecordDate,121) AS FSRecordDate", "DateTime", True))
                table.fields.Add("BillToRecordDate", New clsFieldDataRS8416("BillToRecordDate", "BillToRecordDate", "CONVERT(NVARCHAR,cc1.RecordDate,121) AS BillToRecordDate", "DateTime", True))
                table.Joins.Add("adr", "INNER JOIN custaddr adr ON cus.cust_num = adr.cust_num AND cus.cust_seq = adr.cust_seq")
                table.Joins.Add("mobfscust", "INNER JOIN fs_customer mobfscust ON cus.cust_num = mobfscust.cust_num AND cus.cust_seq = mobfscust.cust_seq")
                table.Joins.Add("cc1", "INNER JOIN customer cc1 ON cus.cust_num = cc1.cust_num AND cc1.cust_seq = 0")
                table.Joins.Add("mobbilltoaddr", "INNER JOIN custaddr mobbilltoaddr ON cus.cust_num = mobbilltoaddr.cust_num AND mobbilltoaddr.cust_seq = 0")

                'Assigned to Work
                If SyncSettings.CustomerFilter = 1 Then
                    table.AddlJoins.Add("INNER JOIN 
                             (
	                           SELECT 
                                 inc.cust_num AS CustNum
	                           , inc.cust_seq AS CustSeq
                               FROM fs_incident inc 
                               INNER JOIN fs_schedule sched ON sched.ref_type = 'N' AND sched.ref_num = inc.inc_num
                               WHERE sched.complete = 0
                               AND sched.partner_id = @PartnerId 
                               UNION
                               SELECT
                                 sro.cust_num AS CustNum
                               , sro.cust_seq AS CustSeq
                               FROM fs_sro sro 
                               INNER JOIN fs_schedule sched ON sched.ref_type = 'S' AND sched.ref_num = sro.sro_num
                               WHERE sched.complete = 0
                               AND sched.partner_id = @PartnerId
                               UNION
                               SELECT
                                 sro.cust_num AS CustNum
                               , sro.cust_seq AS CustSeq
                               FROM fs_sro sro 
                               WHERE sro.partner_id = @PartnerId
                               AND sro_stat IN ('O','E')
                               UNION
                               SELECT
                                 inc.cust_num AS CustNum
                               , inc.cust_seq AS CustSeq
                               FROM fs_incident inc 
                               INNER JOIN fs_stat_code stat ON inc.stat_code = stat.stat_code
                               WHERE inc.[owner] = @PartnerId
                               AND stat.closed = 0
                              ) work_queue ON work_queue.CustNum = cus.cust_num AND work_queue.CustSeq = cus.cust_seq")
                ElseIf SyncSettings.CustomerFilter = 2 Then 'Assigned to Partner
                    table.sFilter = "mobfscust.partner_id = @PartnerId"
                ElseIf SyncSettings.CustomerFilter = 3 Then 'Partner Area
                    table.AddlJoins.Add("INNER JOIN fs_partner_area area ON (area.region = mobfscust.region OR area.region IS NULL)
                              AND (area.city = adr.city OR area.city IS NULL)
                              AND (area.[state] = adr.[state] OR area.[state] IS NULL)
                              AND (area.county = adr.county OR area.county IS NULL)
                              AND (area.country = adr.country OR area.country IS NULL)
                              AND (area.zip = adr.zip OR area.zip IS NULL)")

                    table.sFilter = "area.partner_id = @PartnerId"
                End If
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("customer", CopyDictionary(table.fields))
                oJoins.Add("customer", CopyDictionary(table.Joins))
            End Using
            Parms = New List(Of SqlParameter) From {
                      New SqlParameter("@PartnerWhse", SyncSettings.PartnerWhse),
                      New SqlParameter("@IncludeSlowMoving", SQLBoolean(SyncSettings.IncludeSlowMoving)),
                      New SqlParameter("@IncludeObsolete", SQLBoolean(SyncSettings.IncludeObsolete))
            }
            sFilter = "(itm.stat = 'A' OR (itm.stat = 'S' AND @IncludeSlowMoving = 1) OR (itm.stat = 'O' AND @IncludeObsolete = 1))"
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, sFilter, Parms, TempTable:="#MobileItems", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "itm.item", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description", "itm.description", "NVARCHAR(40)"))
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM", "itm.u_m", "NVARCHAR(3)"))
                table.fields.Add("LotTracked", New clsFieldDataRS8416("lot_tracked", "LotTracked", "itm.lot_tracked", "tinyint"))
                table.fields.Add("SerialTracked", New clsFieldDataRS8416("serial_tracked", "SerialTracked", "itm.serial_tracked", "tinyint"))
                table.fields.Add("Stat", New clsFieldDataRS8416("stat", "Stat", "itm.stat", "NCHAR(1)"))
                table.fields.Add("DerQtyOnHand", New clsFieldDataRS8416("QtyOnHand", "DerQtyOnHand", "iwqv.QtyOnHand", "decimal(20,8)"))
                table.fields.Add("DerQtyTrans", New clsFieldDataRS8416("QtyTrans", "DerQtyTrans", "iwqv.QtyTrans", "decimal(20,8)"))
                table.fields.Add("DerQtyAllocCo", New clsFieldDataRS8416("QtyAllocCo", "DerQtyAllocCo", "iwqv.QtyAllocCo", "decimal(20,8)"))
                table.fields.Add("DerQtyAllowTrn", New clsFieldDataRS8416("QtyAllocTrn", "DerQtyAllowTrn", "iwqv.QtyAllocTrn", "decimal(20,8)"))
                table.fields.Add("QtyAllocJob", New clsFieldDataRS8416("qty_AllocJob", "QtyAllocJob", "itm.qty_Allocjob", "decimal(20,8)"))
                table.fields.Add("DerQtyAvail", New clsFieldDataRS8416("DerQtyAvail", "DerQtyAvail", "((iwqv.QtyOnHand - iwqv.QtyTrans) - (iwqv.QtyAllocCo + iwqv.QtyAllocTrn + itm.qty_allocjob)) AS DerQtyAvail", "decimal(20,8)"))
                table.AddlJoins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON itm.item = iwqv.item")

                If SyncSettings.ItemFilter = 1 Then 'Partner Whse
                    table.AddlJoins.Add("INNER JOIN itemwhse iw ON itm.item = iw.item")
                    table.sFilter = "iw.whse = @PartnerWhse
                             AND   (itm.stat = 'A'
                                    OR (itm.stat = 'S' AND @IncludeSlowMoving = 1)
                                    OR (itm.stat = 'O' AND @IncludeObsolete = 1))"
                End If
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("item", CopyDictionary(table.fields))

            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                        New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableDataRS8416("fs_unit", "FSUnits", "unt", True, True, Nothing, Parms, TempTable:="#MobileUnits", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("SerNum", New clsFieldDataRS8416("ser_num", "SerNum", "unt.ser_num", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "unt.item", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "unt.description", "NVARCHAR(40)"))
                table.fields.Add("CustNum", New clsFieldDataRS8416("cust_num", "CustNum", "unt.cust_num", "NVARCHAR(7)"))
                table.fields.Add("CustSeq", New clsFieldDataRS8416("cust_seq", "CustSeq", "unt.cust_seq", "int"))
                table.fields.Add("BillToName", New clsFieldDataRS8416("BillToName", "BillToName", "bilcad.name AS BillToName", "NVARCHAR(60)"))
                table.fields.Add("ShipToName", New clsFieldDataRS8416("ShipToName", "ShipToName", "CA.name AS ShipToName", "NVARCHAR(60)"))
                table.fields.Add("UnitStatCode", New clsFieldDataRS8416("unit_stat_code", "UnitStatCode", "", "NVARCHAR(10)"))
                table.fields.Add("SrvDealer", New clsFieldDataRS8416("srv_dealer", "SrvDealer", "", "NVARCHAR(10)"))
                table.fields.Add("CompId", New clsFieldDataRS8416("comp_id", "CompId", "", "int"))
                table.fields.Add("LastMeterAmt", New clsFieldDataRS8416("last_meter_amt", "LastMeterAmt", "", "int"))
                table.fields.Add("LastMeterDate", New clsFieldDataRS8416("last_meter_date", "LastMeterDate", "", "datetime"))
                table.fields.Add("InstallDate", New clsFieldDataRS8416("install_date", "InstallDate", "", "datetime"))
                table.fields.Add("LastInsDate", New clsFieldDataRS8416("last_ins_date", "LastInsDate", "", "datetime"))
                table.fields.Add("NextInsDate", New clsFieldDataRS8416("next_ins_date", "NextInsDate", "", "datetime"))
                table.fields.Add("LastCalibDate", New clsFieldDataRS8416("last_calib_date", "LastCalibDate", "", "datetime"))
                table.fields.Add("NextCalibDate", New clsFieldDataRS8416("next_calib_date", "NextCalibDate", "", "datetime"))
                table.fields.Add("LastPmDate", New clsFieldDataRS8416("last_pm_date", "LastPmDate", "", "datetime"))
                table.fields.Add("NextPmDate", New clsFieldDataRS8416("next_pm_date", "NextPmDate", "", "datetime"))
                If SyncSettings.IncludeImages Then
                    table.fields.Add("DerPrimaryPicture", New clsFieldDataRS8416("DerPrimaryPicture", "DerPrimaryPicture", "item.picture AS DerPrimaryPicture", "varbinary(max)"))
                End If
                table.fields.Add("ItemRecordDate", New clsFieldDataRS8416("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,item.RecordDate,121) AS ItemRecordDate", "datetime", True))
                table.fields.Add("SAddrRecordDate", New clsFieldDataRS8416("SAddrRecordDate", "SAddrRecordDate", "CONVERT(NVARCHAR,CA.RecordDate,121) AS SAddrRecordDate", "datetime", True))
                table.fields.Add("BAddrRecordDate", New clsFieldDataRS8416("BAddrRecordDate", "BAddrRecordDate", "CONVERT(NVARCHAR,bilcad.RecordDate,121) AS BAddrRecordDate", "datetime", True))
                table.Joins.Add("item", "LEFT OUTER JOIN item ON item.item = unt.item")
                table.Joins.Add("bilcad", "LEFT OUTER JOIN custaddr bilcad ON unt.cust_num = bilcad.cust_num AND bilcad.cust_seq = 0")
                table.Joins.Add("CA", "LEFT OUTER JOIN custaddr CA ON unt.cust_num = CA.cust_num AND unt.cust_seq = CA.cust_seq")
                If SyncSettings.UnitFilter = 1 Then 'Assigned to Work
                    table.AddlJoins.Add("INNER JOIN (
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN fs_schedule sched ON sched.ref_type = 'S' AND sched.ref_num = line.sro_num
                             WHERE sched.complete = 0 AND sched.partner_id = @PartnerId
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc 
                             INNER JOIN fs_schedule sched ON sched.ref_type = 'N' AND sched.ref_num = inc.inc_num
                             WHERE sched.complete = 0 AND sched.partner_id = @PartnerId 
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc
                             INNER JOIN fs_stat_code stat ON inc.stat_code = stat.stat_code
                             WHERE stat.closed = 0 AND inc.owner = @PartnerId 
                             UNION
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN fs_sro sro ON sro.sro_num = line.sro_num
                             WHERE sro.sro_stat IN ('O','E') AND sro.partner_id = @PartnerId 
                             ) queue ON unt.ser_num = queue.ser_num AND unt.item = queue.item")
                ElseIf SyncSettings.UnitFilter = 2 Then 'Assigned to Customer
                    table.AddlJoins.Add("INNER JOIN #mobilecustomers cust ON unt.cust_num = cust.cust_num")
                ElseIf SyncSettings.UnitFilter = 3 Then 'Assigned to Partner
                    table.sFilter = "unt.srv_dealer = @PartnerId"
                End If

                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("fs_unit", CopyDictionary(table.fields))
                oJoins.Add("fs_unit", CopyDictionary(table.Joins))
            End Using
            Using table = New clsTableDataRS8416("fs_partner", "FSPartners", "part", True, False, "part.active=1")
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "part.partner_id"))
                table.fields.Add("Name", New clsFieldDataRS8416("name", "Name", "part.name"))
                table.fields.Add("Email", New clsFieldDataRS8416("email", "Email", "part.email"))
                table.fields.Add("DerPhone", New clsFieldDataRS8416("DerPhone", "DerPhone", "COALESCE(emp.Phone,cust.Phone##1,ven.Phone) AS DerPhone"))
                If SyncSettings.IncludeImages Then
                    table.fields.Add("DerPrimaryPicture", New clsFieldDataRS8416("DerPrimaryPicture", "DerPrimaryPicture", "COALESCE(emp.Picture,cust.picture,ven.picture) AS DerPrimaryPicture"))
                End If
                table.fields.Add("UserName", New clsFieldDataRS8416("username", "UserName", "part.username"))
                table.fields.Add("Rate", New clsFieldDataRS8416("rate", "Rate", "part.rate"))
                table.fields.Add("Cost", New clsFieldDataRS8416("cost", "Cost", "part.cost"))
                table.fields.Add("Dept", New clsFieldDataRS8416("dept", "Dept", "part.dept"))
                table.fields.Add("MiscCode", New clsFieldDataRS8416("misc_code", "MiscCode", "part.misc_code"))
                table.fields.Add("WorkCode", New clsFieldDataRS8416("work_code", "WorkCode", "part.work_code"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "part.whse"))
                table.fields.Add("FsPayType", New clsFieldDataRS8416("fs_pay_type", "FsPayType", "part.fs_pay_type"))
                table.fields.Add("GpsLastTimestamp", New clsFieldDataRS8416("gps_last_timestamp", "GpsLastTimestamp", "part.gps_last_timestamp"))
                table.fields.Add("GpsLastLongitude", New clsFieldDataRS8416("gps_last_longitude", "GpsLastLongitude", "part.gps_last_longitude"))
                table.fields.Add("GpsLastLatitude", New clsFieldDataRS8416("gps_last_latitude", "GpsLastLatitude", "part.gps_last_latitude"))
                table.fields.Add("GPSPollingInterval", New clsFieldDataRS8416("gps_polling_interval", "GPSPollingInterval", "part.gps_polling_interval"))
                table.fields.Add("Active", New clsFieldDataRS8416("Active", "Active", "part.Active"))
                table.fields.Add("ReimbMatl", New clsFieldDataRS8416("reimb_matl", "ReimbMatl", "part.reimb_matl"))
                Dim PartnerLangSB As New StringBuilder
                PartnerLangSB.AppendLine("(Select Top 1 lang.LanguageID FROM LanguageIDs lang ")
                PartnerLangSB.AppendLine("WHERE lang.LanguageCode = MobUser.LanguageCode  ")
                PartnerLangSB.AppendLine("ORDER BY lang.LanguageID ASC) AS DerLanguageID")
                table.fields.Add("DerLanguageID", New clsFieldDataRS8416("DerLanguageID", "DerLanguageID", PartnerLangSB.ToString))
                table.fields.Add("UserRecordDate", New clsFieldDataRS8416("UserRecordDate", "UserRecordDate", "CONVERT(NVARCHAR,MobUser.RecordDate,121) AS UserRecordDate", "datetime", True))
                table.Joins.Add("cust", "Left OUTER JOIN customer cust ON cust.[cust_num] = part.[ref_num] AND cust.[cust_seq] = part.[ref_seq] AND part.[ref_type] = 'C'")
                table.Joins.Add("ven", "Left OUTER JOIN vendor ven ON ven.[vend_num] = part.[ref_num] AND part.[ref_type]='V'")
                table.Joins.Add("emp", "Left OUTER JOIN Employee emp ON emp.[emp_num] = part.[ref_num] AND part.[ref_type] = 'E'")
                table.Joins.Add("MobUser", "Left OUTER JOIN usernames MobUser ON MobUser.[username] = part.[username] ")

                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                                New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableDataRS8416("fs_partner_area", "FSPartnerAreas", "FS", False, False, "fs.partner_Id=@PartnerId", Parms)
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "fs.partner_id"))
                table.fields.Add("Region", New clsFieldDataRS8416("region", "Region", "fs.region"))
                table.fields.Add("City", New clsFieldDataRS8416("city", "City", "fs.city"))
                table.fields.Add("State", New clsFieldDataRS8416("state", "State", "fs.state"))
                table.fields.Add("Country", New clsFieldDataRS8416("country", "Country", "fs.country"))
                table.fields.Add("County", New clsFieldDataRS8416("county", "County", "fs.county"))
                table.fields.Add("Zip", New clsFieldDataRS8416("zip", "Zip", "fs.zip"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                                    New SqlParameter("@PartnerId", SyncSettings.PartnerId),
                                                                                                                                    New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " CHARINDEX(schdview.RefTypeKey, N'SCN') > 0 AND schdview.PartnerId = @PartnerId  AND schdview.Complete = 0"
            Using table = New clsTableDataRS8416("fs_schedule", "FSSchedules", "sched", False, False, sFilter, Parms, TempTable:="#MobileSchedules", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("SchedDate", New clsFieldDataRS8416("ApptStartDate", "SchedDate", "schdview.ApptStartDate", "datetime"))
                table.fields.Add("Hrs", New clsFieldDataRS8416("ApptLength", "Hrs", "schdview.ApptLength", "decimal(19,8)"))
                table.fields.Add("ApptStat", New clsFieldDataRS8416("ApptStat", "ApptStat", "schdview.ApptStat", "NVARCHAR(15)"))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description", "schdview.Description", "NVARCHAR(40)"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("PartnerId", "PartnerId", "schdview.PartnerId", "NVARCHAR(10)"))
                table.fields.Add("RefType", New clsFieldDataRS8416("RefTypeKey", "RefType", "schdview.RefTypeKey", "NCHAR(1)", bKeyField:=True))
                table.fields.Add("RefNum", New clsFieldDataRS8416("RefNumKey", "RefNum", "schdview.RefNumKey", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add("RefLineSuf", New clsFieldDataRS8416("RefLineKey", "RefLineSuf", "schdview.RefLineKey", "int"))
                table.fields.Add("RefRelease", New clsFieldDataRS8416("RefReleaseKey", "RefRelease", "schdview.RefReleaseKey", "int"))
                table.fields.Add("DerRefShpToName", New clsFieldDataRS8416("CustName", "DerRefShpToName", "schdview.CustName", "NVARCHAR(60)"))
                table.fields.Add("DerRefCustNum", New clsFieldDataRS8416("CustNum", "DerRefCustNum", "schdview.CustNum", "NVARCHAR(7)"))
                table.fields.Add("DerRefCustSeq", New clsFieldDataRS8416("CustSeq", "DerRefCustSeq", "schdview.CustSeq", "int"))
                table.fields.Add("DerLocAddr1", New clsFieldDataRS8416("ShpToAddr##1", "DerLocAddr1", "schdview.ShpToAddr##1", "NVARCHAR(50)"))
                table.fields.Add("DerLocCity", New clsFieldDataRS8416("ShpToCity", "DerLocCity", "schdview.ShpToCity", "NVARCHAR(30)"))
                table.fields.Add("DerLocState", New clsFieldDataRS8416("ShpToState", "DerLocState", "schdview.ShpToState", "NVARCHAR(5)"))
                table.fields.Add("DerLocZip", New clsFieldDataRS8416("ShpToZip", "DerLocZip", "schdview.ShpToZip", "NVARCHAR(10)"))
                table.fields.Add("DerPhone", New clsFieldDataRS8416("DerPhone", "DerPhone", "COALESCE(sro.Phone,inc.Phone) AS DerPhone", "NVARCHAR(25)"))
                table.fields.Add("NotesSubject", New clsFieldDataRS8416("NotesSubject", "NotesSubject", "schdview.NotesSubject", "NVARCHAR(255)"))
                table.fields.Add("Notes", New clsFieldDataRS8416("Notes", "Notes", "schdview.Notes", "NVARCHAR(MAX)"))
                table.fields.Add("Complete", New clsFieldDataRS8416("Complete", "Complete", "schdview.Complete", "tinyint"))
                table.Joins.Add("schdview", "INNER JOIN SSSSchedView schdview ON schdview.RowPointer=sched.RowPointer")
                table.Joins.Add("inc", "LEFT OUTER JOIN fs_incident inc ON schdview.RefNum = inc.inc_num AND schdview.RefTypeKey = 'N'")
                table.Joins.Add("sro", "LEFT OUTER JOIN fs_sro sro ON schdview.RefNum = sro.sro_num AND schdview.RefTypeKey = 'S'")

                If SyncSettings.PastHistory > 0 Then
                    table.sFilter = " CHARINDEX(schdview.RefTypeKey, N'SCN') > 0 
                              AND schdview.PartnerId = @PartnerId  
                              AND (schdview.Complete = 0 
                                   OR (schdview.ApptStartDate >= @HistoryCutoff))"
                End If
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("fs_schedule", CopyDictionary(table.fields))
            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                                        New SqlParameter("@PartnerId", SyncSettings.PartnerId),
                                                                                                                                        New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " inc.owner = @PartnerId  AND stat.closed = 0"
            Using table = New clsTableDataRS8416("fs_incident", "FSIncidents", "inc", True, True, sFilter, Parms, TempTable:="#MobileIncidents", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("RefType", New clsFieldDataRS8416("ref_type", "RefType", "inc.ref_type", "NCHAR(1)"))
                table.fields.Add("RefNum", New clsFieldDataRS8416("ref_num", "RefNum", "inc.ref_num", "NVARCHAR(10)"))
                table.fields.Add("IncNum", New clsFieldDataRS8416("inc_num", "IncNum", "inc.inc_num", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "inc.description", "NVARCHAR(40)"))
                table.fields.Add("StatCode", New clsFieldDataRS8416("stat_code", "StatCode", "inc.stat_code", "NVARCHAR(10)"))
                table.fields.Add("PriorCode", New clsFieldDataRS8416("prior_code", "PriorCode", "inc.prior_code", "NVARCHAR(10)"))
                table.fields.Add("SerNum", New clsFieldDataRS8416("ser_num", "SerNum", "inc.ser_num", "NVARCHAR(30)"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "inc.item", "NVARCHAR(30)"))
                table.fields.Add("Contact", New clsFieldDataRS8416("contact", "Contact", "inc.contact", "NVARCHAR(30)"))
                table.fields.Add("Email", New clsFieldDataRS8416("email", "Email", "inc.email", "NVARCHAR(60)"))
                table.fields.Add("Phone", New clsFieldDataRS8416("phone", "Phone", "inc.phone", "NVARCHAR(25)"))
                table.fields.Add("SSR", New clsFieldDataRS8416("ssr", "SSR", "inc.ssr", "NVARCHAR(10)"))
                table.fields.Add("Site", New clsFieldDataRS8416("site", "Site", "inc.site", "NVARCHAR(8)"))
                table.fields.Add("Owner", New clsFieldDataRS8416("owner", "Owner", "inc.owner", "NVARCHAR(10)"))
                table.fields.Add("WorkSite", New clsFieldDataRS8416("work_site", "WorkSite", "inc.work_site", "NVARCHAR(8)"))
                table.fields.Add("CustNum", New clsFieldDataRS8416("cust_num", "CustNum", "inc.cust_num", "NVARCHAR(7)"))
                table.fields.Add("CustSeq", New clsFieldDataRS8416("cust_seq", "CustSeq", "inc.cust_seq", "int"))
                table.fields.Add("IncDate", New clsFieldDataRS8416("inc_date", "IncDate", "inc.inc_date", "datetime"))
                table.fields.Add("CloseDate", New clsFieldDataRS8416("close_date", "CloseDate", "inc.close_date", "datetime"))
                table.fields.Add("Duration", New clsFieldDataRS8416("duration", "Duration", "inc.duration", "decimal(8,2)"))
                table.fields.Add("DurationUnits", New clsFieldDataRS8416("duration_units", "DurationUnits", "inc.duration_units", "NCHAR(1)"))
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM", "inc.u_m", "NVARCHAR(3)"))
                table.fields.Add("DerClosed", New clsFieldDataRS8416("closed", "DerClosed", "stat.closed", "tinyint"))
                table.fields.Add("MatlQtyConv", New clsFieldDataRS8416("matl_qty_conv", "MatlQtyConv", "inc.matl_qty_conv", "decimal(19,8)"))
                table.fields.Add("ShpToName", New clsFieldDataRS8416("ShpToName", "ShpToName", "cadship.Name AS ShpToName", "NVARCHAR(60)"))
                table.fields.Add("ShpToAddr1", New clsFieldDataRS8416("ShpToAddr1", "ShpToAddr1", "cadship.addr##1 AS ShpToAddr1", "NVARCHAR(50)"))
                table.fields.Add("ShpToCity", New clsFieldDataRS8416("ShpToCity", "ShpToCity", "cadship.city AS ShpToCity", "NVARCHAR(30)"))
                table.fields.Add("ShpToState", New clsFieldDataRS8416("ShpToState", "ShpToState", "cadship.state AS ShpToState", "NVARCHAR(5)"))
                table.fields.Add("ShpToZip", New clsFieldDataRS8416("ShpToZip", "ShpToZip", "cadship.zip AS ShpToZip", "NVARCHAR(10)"))
                table.fields.Add("ItemDesc", New clsFieldDataRS8416("ItemDesc", "ItemDesc", "COALESCE(unit.description,item.description,null) AS ItemDesc", "NVARCHAR(40)"))
                table.fields.Add("AddrRecordDate", New clsFieldDataRS8416("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,cadship.RecordDate,121) AS AddrRecordDate", "datetime", True))
                table.fields.Add("ItemRecordDate", New clsFieldDataRS8416("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,item.RecordDate,121) AS ItemRecordDate", "datetime", True))
                table.fields.Add("UnitRecordDate", New clsFieldDataRS8416("UnitRecordDate", "UnitRecordDate", "CONVERT(NVARCHAR,unit.RecordDate,121) AS UnitRecordDate", "datetime", True))
                table.Joins.Add("stat", "LEFT OUTER JOIN fs_stat_code stat On inc.stat_code = stat.stat_code")
                table.Joins.Add("unit", "Left OUTER JOIN fs_unit unit On inc.ser_num = unit.ser_num And inc.item = unit.item")
                table.Joins.Add("cadship", "Left OUTER JOIN custaddr cadship On inc.cust_num = cadship.cust_num And inc.cust_seq = cadship.cust_seq")
                table.Joins.Add("item", "Left OUTER JOIN item On inc.item = item.item")

                table.SecondaryJoins.Add("INNER JOIN #MobileSchedules sched ON sched.RefTypeKey = 'N' AND sched.RefNumKey = inc.inc_num", "")

                If SyncSettings.PastHistory > 0 Then
                    table.sFilter = " inc.owner = @PartnerId  AND (stat.closed = 0 Or (inc.inc_date >= @HistoryCutoff))"
                    table.SecondaryJoins.Add("INNER JOIN #MobileCustomers mobcust ON mobcust.cust_num = inc.cust_num AND mobcust.cust_seq = inc.cust_seq", "inc.inc_date >= @HistoryCutoff")
                    table.SecondaryJoins.Add("INNER JOIN #MobileUnits mobunit ON mobunit.ser_num = inc.ser_num AND mobunit.item = inc.item", "inc.inc_date >= @HistoryCutoff")
                End If

                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("fs_incident", CopyDictionary(table.fields))
            End Using
            Parms = New List(Of SqlParameter) From {
                                                                                                                                            New SqlParameter("@PartnerId", SyncSettings.PartnerId),
                                                                                                                                            New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " sro.partner_id = @PartnerId  AND sro.sro_stat IN ('O','E')"

            Using table = New clsTableDataRS8416("fs_sro", "FSSROs", "sro", True, True, sFilter, Parms, TempTable:="#MobileSROs", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "sro.sro_num", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "sro.description", "NVARCHAR(40)"))
                table.fields.Add("StatCode", New clsFieldDataRS8416("stat_code", "StatCode", "sro.stat_code", "NVARCHAR(10)"))
                table.fields.Add("PriorCode", New clsFieldDataRS8416("prior_code", "PriorCode", "sro.prior_code", "NVARCHAR(10)"))
                table.fields.Add("Contact", New clsFieldDataRS8416("contact", "Contact", "sro.contact", "NVARCHAR(60)"))
                table.fields.Add("Email", New clsFieldDataRS8416("email", "Email", "sro.email", "NVARCHAR(60)"))
                table.fields.Add("Phone", New clsFieldDataRS8416("phone", "Phone", "sro.phone", "NVARCHAR(25)"))
                table.fields.Add("CustNum", New clsFieldDataRS8416("cust_num", "CustNum", "sro.cust_num", "NVARCHAR(7)"))
                table.fields.Add("CustSeq", New clsFieldDataRS8416("cust_seq", "CustSeq", "sro.cust_seq", "int"))
                table.fields.Add("OpenDate", New clsFieldDataRS8416("open_date", "OpenDate", "sro.open_date", "datetime"))
                table.fields.Add("CloseDate", New clsFieldDataRS8416("close_date", "CloseDate", "sro.close_date", "datetime"))
                table.fields.Add("BillType", New clsFieldDataRS8416("bill_type", "BillType", "sro.bill_type", "NCHAR(1)"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "sro.bill_code", "NCHAR(1)"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "sro.partner_id", "NVARCHAR(10)"))
                table.fields.Add("ProductCode", New clsFieldDataRS8416("product_code", "ProductCode", "sro.product_code", "NVARCHAR(10)"))
                table.fields.Add("SroStat", New clsFieldDataRS8416("sro_stat", "SroStat", "sro.sro_stat", "NCHAR(1)"))
                table.fields.Add("ShpToName", New clsFieldDataRS8416("ShpToName", "ShpToName", "billcst.Name AS ShpToName", "NVARCHAR(60)"))
                table.fields.Add("ShpToAddr1", New clsFieldDataRS8416("ShpToAddr1", "ShpToAddr1", "billcst.addr##1 AS ShpToAddr1", "NVARCHAR(50)"))
                table.fields.Add("ShpToCity", New clsFieldDataRS8416("ShpToCity", "ShpToCity", "billcst.city AS ShpToCity", "NVARCHAR(30)"))
                table.fields.Add("ShpToState", New clsFieldDataRS8416("ShpToState", "ShpToState", "billcst.state AS ShpToState", "NVARCHAR(5)"))
                table.fields.Add("ShpToZip", New clsFieldDataRS8416("ShpToZip", "ShpToZip", "billcst.zip AS ShpToZip", "NVARCHAR(10)"))
                table.fields.Add("AddrRecordDate", New clsFieldDataRS8416("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,billcst.RecordDate,121) AS AddrRecordDate", "datetime", True))
                table.Joins.Add("billcst", "Left OUTER JOIN custaddr billcst On sro.cust_num = billcst.cust_num And sro.cust_seq = billcst.cust_seq")

                table.SecondaryJoins.Add("INNER JOIN #MobileSchedules mobsched ON mobsched.RefTypeKey = 'S' AND mobsched.RefNumKey = sro.sro_num", "")

                If SyncSettings.PastHistory > 0 Then

                    table.sFilter = " (sro.partner_id = @PartnerId  AND sro.sro_stat IN ('O','E'))  OR (sro.open_date >= @HistoryCutoff AND sro.sro_stat IN ('O','C','E'))"

                    table.SecondaryJoins.Add("INNER JOIN #MobileCustomers mobcust ON mobcust.cust_num = sro.cust_num AND sro.cust_seq = mobcust.cust_seq", "sro.open_date >= @HistoryCutoff")
                    table.SecondaryJoins.Add("INNER JOIN fs_sro_line line ON sro.sro_num = line.sro_num INNER JOIN #MobileUnits mobunit ON mobunit.ser_num = line.ser_num AND mobunit.item = line.item", "sro.open_date >= @HistoryCutoff")
                End If
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                oFields.Add("fs_sro", CopyDictionary(table.fields))
            End Using
            If SyncSettings.CustomerFilter <> 0 Then
                Parms = New List(Of SqlParameter) From {
                New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
                Using table = New clsTableDataRS8416("customer", "SLCustomers", "cus", False, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=False, DeferProcess:=True)
                    table.fields = CopyDictionary(oFields("customer"))
                    table.Joins = CopyDictionary(oJoins("customer"))
                    table.AddlJoins.Add("LEFT OUTER JOIN #MobileSROs mobsro ON mobsro.cust_num = cus.cust_num AND mobsro.cust_seq = cus.cust_seq")
                    table.AddlJoins.Add("LEFT OUTER JOIN #MobileIncidents mobinc ON mobinc.cust_num = cus.cust_num AND mobinc.cust_seq = cus.cust_seq")
                    table.sFilter = "(mobsro.rowpointer IS NOT NULL OR mobinc.RowPointer IS NOT NULL)"
                    'do not add user filters here
                    If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                End Using
            End If
            Parms = New List(Of SqlParameter) From {
                      New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            sFilter = " stm.active = 1 And trn.success = 1"
            Using table = New clsTableDataRS8416("cci_card", "CCICards", "cci", False, False, sFilter, Parms)
                table.fields.Add("CardSystemId", New clsFieldDataRS8416("card_system_id", "CardSystemId", "cci.card_system_id "))
                table.fields.Add("CardSystem", New clsFieldDataRS8416("card_system", "CardSystem", "cci.card_system "))
                table.fields.Add("CustNum", New clsFieldDataRS8416("cust_num", "CustNum", "cci.cust_num"))
                table.fields.Add("CustSeq", New clsFieldDataRS8416("cust_seq", "CustSeq", "cci.cust_seq"))
                table.fields.Add("CardNum", New clsFieldDataRS8416("card_num", "CardNum", "cci.card_num"))
                table.fields.Add("ExpDate", New clsFieldDataRS8416("exp_date", "ExpDate", "cci.exp_date"))
                table.fields.Add("LastStoredGatewayTransNum", New clsFieldDataRS8416("last_stored_gateway_trans_num", "LastStoredGatewayTransNum", "cci.last_stored_gateway_trans_num"))
                table.fields.Add("GatewayStoredToken", New clsFieldDataRS8416("gateway_stored_token", "GatewayStoredToken", "trn.gateway_stored_token"))
                table.fields.Add("CardType", New clsFieldDataRS8416("card_type", "CardType", "cci.card_type"))
                table.fields.Add("StmRecordDate", New clsFieldDataRS8416("StmRecordDate", "StmRecordDate", "CONVERT(NVARCHAR,stm.RecordDate,121) As StmRecordDate", bDate:=True))
                table.AddlJoins.Add("INNER JOIN cci_trans trn On cci.last_stored_gateway_trans_num = trn.gateway_trans_num And cci.card_system_id = trn.card_system_id")
                table.AddlJoins.Add("INNER JOIN cci_system stm On stm.card_system_id = cci.card_system_id")
                table.AddlJoins.Add(" INNER JOIN #MobileCustomers mobcust On cci.cust_num = mobcust.cust_num And cci.cust_seq = mobcust.cust_seq")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_inc_reason", "FSIncReasons", "increas", False, False, sFilter, Parms)
                table.fields.Add("Reason", New clsFieldDataRS8416("reason_gen", "Reason", "increas.reason_gen"))
                table.fields.Add("ReasonSpec", New clsFieldDataRS8416("reason_spec", "ReasonSpec", "increas.reason_spec"))
                table.fields.Add("ReasonNotes", New clsFieldDataRS8416("reason_notes", "ReasonNotes", "increas.reason_notes "))
                table.fields.Add("Resolution", New clsFieldDataRS8416("res_code_gen", "Resolution", "increas.res_code_gen"))
                table.fields.Add("ResolutionSpec", New clsFieldDataRS8416("res_code_spec", "ResolutionSpec", "increas.res_code_spec"))
                table.fields.Add("ResolutionNotes", New clsFieldDataRS8416("resolution_notes", "ResolutionNotes", "increas.resolution_notes"))
                table.fields.Add("Duration", New clsFieldDataRS8416("duration", "Duration", "frs.duration"))
                table.fields.Add("DurationUnits", New clsFieldDataRS8416("duration_units", "DurationUnits", "frs.duration_units"))
                table.fields.Add("IncNum", New clsFieldDataRS8416("inc_num", "IncNum", "increas.inc_num"))
                table.fields.Add("Seq", New clsFieldDataRS8416("seq", "Seq", "increas.seq"))
                table.fields.Add("SpecRecordDate", New clsFieldDataRS8416("SpecRecordDate", "SpecRecordDate", "CONVERT(NVARCHAR,frs.RecordDate,121) As SpecRecordDate", bDate:=True))
                table.Joins.Add("frs", "LEFT OUTER JOIN fs_reas_spec frs ON increas.reason_spec = frs.reason_spec AND increas.reason_gen = frs.reason_gen")
                table.AddlJoins.Add("INNER JOIN #MobileIncidents mobinc On mobinc.inc_num = increas.inc_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_line", "FSSROLines", "ln", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "ln.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "ln.sro_line"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "ln.partner_id"))
                table.fields.Add("Stat", New clsFieldDataRS8416("stat", "Stat", "ln.stat"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "ln.description"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "ln.bill_code"))
                table.fields.Add("BillType", New clsFieldDataRS8416("bill_type", "BillType", "ln.bill_type"))
                table.fields.Add("QtyConv", New clsFieldDataRS8416("qty_conv", "QtyConv", "ln.qty_conv"))
                table.fields.Add("SerNum", New clsFieldDataRS8416("ser_num", "SerNum", "ln.ser_num"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "ln.item"))
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM", "ln.u_m"))
                table.fields.Add("InspectType", New clsFieldDataRS8416("inspect_type", "InspectType", "ln.inspect_type"))
                table.fields.Add("ProductCode", New clsFieldDataRS8416("product_code", "ProductCode", "ln.product_code"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = ln.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_oper", "FSSROOpers", "op", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "op.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "op.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "op.sro_oper"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "op.partner_id"))
                table.fields.Add("Stat", New clsFieldDataRS8416("stat", "Stat", "op.stat"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "op.description"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "op.bill_code"))
                table.fields.Add("BillType", New clsFieldDataRS8416("bill_type", "BillType", "op.bill_type"))
                table.fields.Add("OperCode", New clsFieldDataRS8416("oper_code", "OperCode", "op.oper_code"))
                table.fields.Add("StartDate", New clsFieldDataRS8416("start_date", "StartDate", "op.start_date"))
                table.fields.Add("EndDate", New clsFieldDataRS8416("end_date", "EndDate", "op.end_date"))
                table.fields.Add("TotalPrice", New clsFieldDataRS8416("total_price", "TotalPrice", "op.total_price"))
                table.fields.Add("ProductCode", New clsFieldDataRS8416("product_code", "ProductCode", "op.product_code"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = op.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_reason", "FSSROReasons", "sroreas", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "sroreas.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "sroreas.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "sroreas.sro_oper"))
                table.fields.Add("Reason", New clsFieldDataRS8416("reason_gen", "Reason"))
                table.fields.Add("ReasonSpec", New clsFieldDataRS8416("reason_spec", "ReasonSpec"))
                table.fields.Add("ReasonNotes", New clsFieldDataRS8416("reason_notes", "ReasonNotes"))
                table.fields.Add("Resolution", New clsFieldDataRS8416("res_code_gen", "Resolution"))
                table.fields.Add("ResolutionSpec", New clsFieldDataRS8416("res_code_spec", "ResolutionSpec"))
                table.fields.Add("ResolutionNotes", New clsFieldDataRS8416("resolution_notes", "ResolutionNotes"))
                table.fields.Add("Seq", New clsFieldDataRS8416("seq", "Seq"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = sroreas.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_inspect", "FSSROInspects", "sroinsp", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "sroinsp.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "sroinsp.sro_line"))
                table.fields.Add("InspectType", New clsFieldDataRS8416("inspect_type", "InspectType", "sroinsp.inspect_type"))
                table.fields.Add("SectionCode", New clsFieldDataRS8416("section_code", "SectionCode", "sroinsp.section_code"))
                table.fields.Add("InspectTask", New clsFieldDataRS8416("inspect_task", "InspectTask", "sroinsp.inspect_task"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "sroinsp.description"))
                table.fields.Add("ParentId", New clsFieldDataRS8416("parent_id", "ParentId", "sroinsp.parent_id"))
                table.fields.Add("CompId", New clsFieldDataRS8416("comp_id", "CompId", "sroinsp.comp_id"))
                table.fields.Add("Sequence", New clsFieldDataRS8416("sequence", "Sequence", "sroinsp.sequence"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "sroinsp.item"))
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM", "sroinsp.u_m"))
                table.fields.Add("LowValue", New clsFieldDataRS8416("low_value", "LowValue", "sroinsp.low_value"))
                table.fields.Add("HighValue", New clsFieldDataRS8416("high_value", "HighValue", "sroinsp.high_value"))
                table.fields.Add("FormatString", New clsFieldDataRS8416("format_string", "FormatString", "sroinsp.format_string"))
                table.fields.Add("ExpectedValue", New clsFieldDataRS8416("expected_value", "ExpectedValue", "sroinsp.expected_value"))
                table.fields.Add("MeasValue", New clsFieldDataRS8416("meas_value", "MeasValue", "sroinsp.meas_value"))
                table.fields.Add("AdjValue", New clsFieldDataRS8416("adj_value", "AdjValue", "sroinsp.adj_value"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "sroinsp.partner_id"))
                table.fields.Add("InspReq", New clsFieldDataRS8416("insp_req", "InspReq", "sroinsp.insp_req"))
                table.fields.Add("MeasType", New clsFieldDataRS8416("meas_type", "MeasType", "sroinsp.meas_type"))
                table.fields.Add("MeasTypeMeasRespType", New clsFieldDataRS8416("meas_resp_type", "MeasTypeMeasRespType", "meastype.meas_resp_type"))
                table.fields.Add("MeasTypeRecordDate", New clsFieldDataRS8416("MeasTypeRecordDate", "MeasTypeRecordDate", "CONVERT(NVARCHAR,meastype.RecordDate,121) AS MeasTypeRecordDate", bDate:=True))
                table.Joins.Add("meastype", "LEFT OUTER JOIN fs_meas_type meastype ON meastype.meas_type = sroinsp.meas_type")
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = sroinsp.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_matl", "FSSROMatls", "SROMatl", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "SROMatl.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "SROMatl.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "SROMatl.sro_oper"))
                table.fields.Add("TransNum", New clsFieldDataRS8416("trans_num", "TransNum", "SROMatl.trans_num"))
                table.fields.Add("TransDate", New clsFieldDataRS8416("trans_date", "TransDate", "SROMatl.trans_date"))
                table.fields.Add("Type", New clsFieldDataRS8416("type", "Type", "SROMatl.type"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "SROMatl.partner_id"))
                table.fields.Add("Posted", New clsFieldDataRS8416("posted", "Posted", "SROMatl.posted"))
                table.fields.Add("TransType", New clsFieldDataRS8416("trans_type", "TransType", "SROMatl.trans_type"))
                table.fields.Add("PostDate", New clsFieldDataRS8416("post_date", "PostDate", "SROMatl.post_date"))
                table.fields.Add("MatlQtyConv", New clsFieldDataRS8416("matl_qty_conv", "MatlQtyConv", "SROMatl.matl_qty_conv"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "SROMatl.item"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "SROMatl.description"))
                table.fields.Add("UM", New clsFieldDataRS8416("u_m", "UM", "SROMatl.u_m"))
                table.fields.Add("Dept", New clsFieldDataRS8416("dept", "Dept", "SROMatl.dept"))
                table.fields.Add("Disc", New clsFieldDataRS8416("disc", "Disc", "SROMatl.disc"))
                table.fields.Add("Loc", New clsFieldDataRS8416("loc", "Loc", "SROMatl.loc"))
                table.fields.Add("Lot", New clsFieldDataRS8416("lot", "Lot", "SROMatl.lot"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "SROMatl.whse"))
                table.fields.Add("CostConv", New clsFieldDataRS8416("cost_conv", "CostConv", "SROMatl.cost_conv"))
                table.fields.Add("PriceConv", New clsFieldDataRS8416("price_conv", "PriceConv", "SROMatl.price_conv"))
                table.fields.Add("ReasonCode", New clsFieldDataRS8416("reason_code", "ReasonCode", "SROMatl.reason_code"))
                table.fields.Add("ExtCost", New clsFieldDataRS8416("extcost", "ExtCost", "SROMatl.extcost"))
                table.fields.Add("ExtPrice", New clsFieldDataRS8416("extprice", "ExtPrice", "SROMatl.extprice"))
                table.fields.Add("PriceCode", New clsFieldDataRS8416("pricecode", "PriceCode", "SROMatl.pricecode"))
                table.fields.Add("RefType", New clsFieldDataRS8416("ref_type", "RefType", "SROMatl.ref_type"))
                table.fields.Add("TaxCode1", New clsFieldDataRS8416("tax_code1", "TaxCode1", "SROMatl.tax_code1"))
                table.fields.Add("TaxCode2", New clsFieldDataRS8416("tax_code2", "TaxCode2", "SROMatl.tax_code2"))
                table.fields.Add("CustItem", New clsFieldDataRS8416("cust_item", "CustItem", "SROMatl.cust_item"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "SROMatl.bill_code"))
                table.fields.Add("ReimbPartner", New clsFieldDataRS8416("reimb_partner", "ReimbPartner", "SROMatl.reimb_partner"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = SROMatl.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_labor", "FSSROLabors", "SROLabor", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "SROLabor.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "SROLabor.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "SROLabor.sro_oper"))
                table.fields.Add("TransNum", New clsFieldDataRS8416("trans_num", "TransNum", "SROLabor.trans_num"))
                table.fields.Add("TransDate", New clsFieldDataRS8416("trans_date", "TransDate", "SROLabor.trans_date"))
                table.fields.Add("Type", New clsFieldDataRS8416("type", "Type", "SROLabor.type"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "SROLabor.partner_id"))
                table.fields.Add("Posted", New clsFieldDataRS8416("posted", "Posted", "SROLabor.posted"))
                table.fields.Add("PostDate", New clsFieldDataRS8416("post_date", "PostDate", "SROLabor.post_date"))
                table.fields.Add("WorkCode", New clsFieldDataRS8416("work_code", "WorkCode", "SROLabor.work_code"))
                table.fields.Add("WorkCodeDescription", New clsFieldDataRS8416("WorkCodeDescription", "WorkCodeDescription", "workcode.description AS WorkCodeDescription"))
                table.fields.Add("HrsWorked", New clsFieldDataRS8416("hrs_worked", "HrsWorked", "SROLabor.hrs_worked"))
                table.fields.Add("HrsToBill", New clsFieldDataRS8416("hrs_to_bill", "HrsToBill", "SROLabor.hrs_to_bill"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "SROLabor.whse"))
                table.fields.Add("Dept", New clsFieldDataRS8416("dept", "Dept", "SROLabor.dept"))
                table.fields.Add("Disc", New clsFieldDataRS8416("disc", "Disc", "SROLabor.disc"))
                table.fields.Add("Cost", New clsFieldDataRS8416("cost", "Cost", "SROLabor.cost"))
                table.fields.Add("Rate", New clsFieldDataRS8416("rate", "Rate", "SROLabor.rate"))
                table.fields.Add("ExtCost", New clsFieldDataRS8416("extcost", "ExtCost", "SROLabor.extcost"))
                table.fields.Add("ExtPrice", New clsFieldDataRS8416("extprice", "ExtPrice", "SROLabor.extprice"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "SROLabor.bill_code"))
                table.fields.Add("WorkCodeRecordDate", New clsFieldDataRS8416("WorkCodeRecordDate", "WorkCodeRecordDate", "CONVERT(NVARCHAR,workcode.RecordDate,121) AS WorkCodeRecordDate", bDate:=True))
                table.Joins.Add("WorkCode", "LEFT OUTER JOIN fs_work_code WorkCode ON WorkCode.work_code = SROLabor.work_code")
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = SROLabor.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_misc", "FSSROMiscs", "SROMisc", True, True, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "SROMisc.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "SROMisc.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "SROMisc.sro_oper"))
                table.fields.Add("TransNum", New clsFieldDataRS8416("trans_num", "TransNum", "SROMisc.trans_num"))
                table.fields.Add("TransDate", New clsFieldDataRS8416("trans_date", "TransDate", "SROMisc.trans_date"))
                table.fields.Add("Type", New clsFieldDataRS8416("type", "Type", "SROMisc.type"))
                table.fields.Add("PartnerId", New clsFieldDataRS8416("partner_id", "PartnerId", "SROMisc.partner_id"))
                table.fields.Add("Posted", New clsFieldDataRS8416("posted", "Posted", "SROMisc.posted"))
                table.fields.Add("PostDate", New clsFieldDataRS8416("post_date", "PostDate", "SROMisc.post_date"))
                table.fields.Add("Qty", New clsFieldDataRS8416("qty", "Qty", "SROMisc.qty"))
                table.fields.Add("MiscCode", New clsFieldDataRS8416("misc_code", "MiscCode", "SROMisc.misc_code"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "SROMisc.description"))
                table.fields.Add("MatlCost", New clsFieldDataRS8416("matl_cost", "MatlCost", "SROMisc.matl_cost"))
                table.fields.Add("LbrCost", New clsFieldDataRS8416("lbr_cost", "LbrCost", "SROMisc.lbr_cost"))
                table.fields.Add("FovhdCost", New clsFieldDataRS8416("fovhd_cost", "FovhdCost", "SROMisc.fovhd_cost"))
                table.fields.Add("VovhdCost", New clsFieldDataRS8416("vovhd_cost", "VovhdCost", "SROMisc.vovhd_cost"))
                table.fields.Add("OutCost", New clsFieldDataRS8416("out_cost", "OutCost", "SROMisc.out_cost"))
                table.fields.Add("Cost", New clsFieldDataRS8416("cost", "Cost", "SROMisc.cost"))
                table.fields.Add("Price", New clsFieldDataRS8416("price", "Price", "SROMisc.price"))
                table.fields.Add("ExtCost", New clsFieldDataRS8416("extcost", "ExtCost", "SROMisc.extcost"))
                table.fields.Add("ExtPrice", New clsFieldDataRS8416("extprice", "ExtPrice", "SROMisc.extprice"))
                table.fields.Add("Disc", New clsFieldDataRS8416("disc", "Disc", "SROMisc.disc"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "SROMisc.whse"))
                table.fields.Add("FsPayType", New clsFieldDataRS8416("fs_pay_type", "FsPayType", "SROMisc.fs_pay_type"))
                table.fields.Add("BillCode", New clsFieldDataRS8416("bill_code", "BillCode", "SROMisc.bill_code"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = SROMisc.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableDataRS8416("fs_sro_serial", "FSSROSerials", "SROSerial", False, False, sFilter, Parms)
                table.fields.Add("SroNum", New clsFieldDataRS8416("sro_num", "SroNum", "SROSerial.sro_num"))
                table.fields.Add("SroLine", New clsFieldDataRS8416("sro_line", "SroLine", "SROSerial.sro_line"))
                table.fields.Add("SroOper", New clsFieldDataRS8416("sro_oper", "SroOper", "SROSerial.sro_oper"))
                table.fields.Add("TransNum", New clsFieldDataRS8416("trans_num", "TransNum", "SROSerial.trans_num"))
                table.fields.Add("Type", New clsFieldDataRS8416("type", "Type", "SROSerial.type"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "SROSerial.item"))
                table.fields.Add("SerNum", New clsFieldDataRS8416("ser_num", "SerNum", "SROSerial.ser_num"))
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro On mobsro.sro_num = SROSerial.sro_num")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = "controlled_by_external_wms = 0"
            Using table = New clsTableDataRS8416("whse", "SLWhses", "whs", False, False, sFilter, Parms)
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse"))
                table.fields.Add("Name", New clsFieldDataRS8416("name", "Name"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            'add units included later
            If SyncSettings.UnitFilter = 1 Or SyncSettings.UnitFilter = 2 Then 'Assigned to Work
                Parms = Nothing
                sFilter = "unt.RowPointer Not In(SELECT RowPointer From #MobileUnits)"
                Using table = New clsTableDataRS8416("fs_unit", "FSUnits", "unt", True, True, sFilter, Parms, TempTable:="#MobileUnits", CreateTempTable:=False, DeferProcess:=True)
                    table.fields = CopyDictionary(oFields("fs_unit"))
                    table.Joins = CopyDictionary(oJoins("fs_unit"))

                    If SyncSettings.UnitFilter = 1 Then
                        table.AddlJoins.Add("INNER JOIN (
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN #MobileSchedules mobsched ON mobsched.RefTypeKey = 'S' AND mobsched.RefNumKey = line.sro_num      
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc 
                             INNER JOIN #MobileSchedules mobsched ON mobsched.RefTypeKey = 'N' AND mobsched.RefNumKey = inc.inc_num
                             UNION
                             SELECT mobinc.ser_num , mobinc.item FROM 
                             #MobileIncidents mobinc
                             UNION
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN #MobileSROs mobsro ON mobsro.sro_num = line.sro_num
                             ) queue ON unt.ser_num = queue.ser_num AND unt.item = queue.item")
                    ElseIf SyncSettings.UnitFilter = 2 Then 'owned by customer
                        table.AddlJoins.Add("INNER JOIN #MobileCustomers mobcust ON unt.cust_num = mobcust.cust_num AND unt.cust_seq = mobcust.cust_seq")
                    End If
                    If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                End Using
            End If


            Parms = Nothing
            sFilter = "itm.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = CopyDictionary(oFields("item"))
                table.AddlJoins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON itm.item = iwqv.item")
                table.AddlJoins.Add("INNER JOIN fs_sro_matl matl ON itm.item = matl.item")
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro ON mobsro.sro_num = matl.sro_num")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = "itm.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = CopyDictionary(oFields("item"))
                table.AddlJoins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON itm.item = iwqv.item")
                table.AddlJoins.Add("INNER JOIN fs_sro_line line ON itm.item = line.item")
                table.AddlJoins.Add("INNER JOIN #MobileSROs mobsro ON mobsro.sro_num = line.sro_num")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = "itm.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = CopyDictionary(oFields("item"))
                table.AddlJoins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON itm.item = iwqv.item")
                table.AddlJoins.Add("INNER JOIN #MobileIncidents mobinc ON mobinc.item = itm.item")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using
            Parms = Nothing
            sFilter = "itm.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = CopyDictionary(oFields("item"))
                table.AddlJoins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON itm.item = iwqv.item")
                table.AddlJoins.Add("INNER JOIN #MobileUnits mobunt ON mobunt.item = itm.item")
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("item"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("customer", "SLCustomers", "cus", True, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("customer"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_unit", "FSUnits", "unt", True, True, Nothing, Parms, TempTable:="#MobileUnits", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("fs_unit"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Parms = Nothing
            sFilter = "whs.controlled_by_external_wms = 0"
            Using table = New clsTableDataRS8416("itemwhse", "SLItemWhses", "itwh", False, False, sFilter, Parms)
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "itwh.item"))
                table.fields.Add("Description", New clsFieldDataRS8416("Description", "Description", "mobitem.description"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "itwh.whse"))
                table.fields.Add("Name", New clsFieldDataRS8416("name", "Name", "whs.name"))
                table.fields.Add("QtyOnHand", New clsFieldDataRS8416("qty_on_hand", "QtyOnHand", "(itwh.qty_on_hand - ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = itwh.item 
                              AND iloc.whse = itwh.whse
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)) AS qty_on_hand"))
                table.fields.Add("QtyAllocCo", New clsFieldDataRS8416("qty_alloc_co", "QtyAllocCo", "itwh.qty_alloc_co"))
                table.fields.Add("AllocTrn", New clsFieldDataRS8416("alloc_trn", "AllocTrn", "itwh.alloc_trn"))
                table.fields.Add("QtyTrans", New clsFieldDataRS8416("qty_trans", "QtyTrans", "itwh.qty_trans"))
                table.fields.Add("DerQtyAvail", New clsFieldDataRS8416("DerQtyAvail", "DerQtyAvail", "(itwh.qty_on_hand - ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = itwh.item 
                              AND iloc.whse = itwh.whse
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)) - (itwh.qty_alloc_co + itwh.alloc_trn + (CASE when exists (select 1 from invparms as prm where prm.def_whse = itwh.whse) THEN  mobitem.qty_allocjob ELSE  0 END))  AS DerQtyAvail"))
                table.fields.Add("WhseRecordDate", New clsFieldDataRS8416("WhseRecordDate", "WhseRecordDate", "CONVERT(NVARCHAR,whs.RecordDate,121) AS WhseRecordDate", bDate:=True))
                table.fields.Add("ItemRecordDate", New clsFieldDataRS8416("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,mobitem.RecordDate,121) AS ItemRecordDate", bDate:=True))

                table.Joins.Add("whs", "INNER JOIN whse whs ON whs.whse = itwh.whse")
                table.AddlJoins.Add("INNER JOIN #MobileItems mobitem ON mobitem.item = itwh.item")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False

            End Using

            Parms = Nothing
            sFilter = "whs.controlled_by_external_wms = 0"
            Using table = New clsTableDataRS8416("itemloc", "SLItemLocs", "iloc", False, False, sFilter, Parms)
                table.fields.Add("Loc", New clsFieldDataRS8416("loc", "Loc", "iloc.loc"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "iloc.item"))
                table.fields.Add("LocType", New clsFieldDataRS8416("loc_type", "LocType", "iloc.loc_type"))
                table.fields.Add("Rank", New clsFieldDataRS8416("rank", "Rank", "iloc.rank"))
                table.fields.Add("MrbFlag", New clsFieldDataRS8416("mrb_flag", "MrbFlag", "iloc.mrb_flag"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "iloc.whse"))
                table.fields.Add("QtyOnHand", New clsFieldDataRS8416("qty_on_hand", "QtyOnHand", "iloc.qty_on_hand"))

                table.Joins.Add("whs", "INNER JOIN whse whs ON whs.whse = iloc.whse")
                table.AddlJoins.Add("INNER JOIN #MobileItems mobitem ON mobitem.item = iloc.item")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using

            Parms = Nothing
            sFilter = "whs.controlled_by_external_wms = 0"
            Using table = New clsTableDataRS8416("lot_loc", "SLLotLocs", "ltlc", False, False, sFilter, Parms)
                table.fields.Add("Loc", New clsFieldDataRS8416("loc", "Loc", "ltlc.loc"))
                table.fields.Add("LocationDescription", New clsFieldDataRS8416("description", "LocationDescription", "loc.description"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "ltlc.item"))
                table.fields.Add("Lot", New clsFieldDataRS8416("lot", "Lot", "ltlc.lot"))
                table.fields.Add("Whse", New clsFieldDataRS8416("whse", "Whse", "ltlc.whse"))
                table.fields.Add("WhseName", New clsFieldDataRS8416("name", "WhseName", "whs.name"))
                table.fields.Add("QtyOnHand", New clsFieldDataRS8416("qty_on_hand", "QtyOnHand", "ltlc.qty_on_hand"))
                table.fields.Add("WhseRecordDate", New clsFieldDataRS8416("WhseRecordDate", "WhseRecordDate", "CONVERT(NVARCHAR,whs.RecordDate,121) AS WhseRecordDate", bDate:=True))
                table.fields.Add("LocRecordDate", New clsFieldDataRS8416("LocRecordDate", "LocRecordDate", "CONVERT(NVARCHAR,loc.RecordDate,121) AS LocRecordDate", bDate:=True))
                table.Joins.Add("whs", "INNER JOIN whse whs ON whs.whse = ltlc.whse")
                table.AddlJoins.Add("INNER JOIN #MobileItems mobitem ON mobitem.item = ltlc.item")
                table.AddlJoins.Add("INNER JOIN location loc ON loc.loc = ltlc.loc")
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False


            End Using
            Parms = Nothing
            sFilter = "config.comp_id IN (SELECT comp_id FROM #MobileUnits)"
            Using table = New clsTableDataRS8416("fs_config", "FSConfigs", "Config", False, False, sFilter, Parms, IsHierarchical:=True)
                table.fields.Add("CompId", New clsFieldDataRS8416("comp_id", "CompId", "config.comp_id", HierarchicalChild:=True))
                table.fields.Add("SerNum", New clsFieldDataRS8416("ser_num", "SerNum", "config.ser_num"))
                table.fields.Add("Item", New clsFieldDataRS8416("item", "Item", "config.item"))
                table.fields.Add("Description", New clsFieldDataRS8416("description", "Description", "config.description"))
                table.fields.Add("ParentId", New clsFieldDataRS8416("parent_id", "ParentId", "config.parent_id", HierarchicalParent:=True))
                table.fields.Add("InstallDate", New clsFieldDataRS8416("install_date", "InstallDate", "config.install_date"))
                table.fields.Add("RemoveDate", New clsFieldDataRS8416("remove_date", "RemoveDate", "config.remove_date"))
                table.fields.Add("Qty", New clsFieldDataRS8416("qty", "Qty", "config.qty"))
                GetCustomFields(table.sIDO, table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            'PROCESS SRO,Incident,Appt data last so all items/customers/codes are already down on the device

            Using table = New clsTableDataRS8416("fs_schedule", "FSSchedules", "sched", False, False, Nothing, Parms, TempTable:="#MobileSchedules", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("fs_schedule"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_incident", "FSIncidents", "inc", True, True, Nothing, Parms, TempTable:="#MobileIncidents", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("fs_incident"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using
            Using table = New clsTableDataRS8416("fs_sro", "FSSROs", "sro", True, True, Nothing, Parms, TempTable:="#MobileSROs", CreateTempTable:=False, DeferProcess:=False)
                table.fields = CopyDictionary(oFields("fs_sro"))
                If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
            End Using

            'add in records that aren't system records
            Using CustomDT As DataTable = GetDatatable("SELECT mitv.CollectionName, TableName, TableAlias,mdc.show_on_menu ,mipv.ColumnName,mipv.ColumnTableAlias,mdc.allow_notes,mdc.allow_documents  FROM ido.tables mitv " _
                                                   & " INNER JOIN mobile_device_ido mdc ON mitv.CollectionName = mdc.ido_name " _
                                                   & " LEFT OUTER JOIN ido.properties mipv ON mipv.CollectionName = mdc.ido_name AND mipv.PropertyName = mdc.days_hist_filter_property_name AND mipv.DevelopmentFlag =0 " _
                                                   & " WHERE mdc.App_Name = 'MobileService' AND TableType = 3 AND mdc.is_system = 0 and mitv.DevelopmentFlag=0", appDB, Nothing, SyncSettings)

                If CustomDT IsNot Nothing Then
                    For Each dr As DataRow In CustomDT.Rows
                        'apply days history filter if specified
                        If (GetString(dr("ColumnName")) <> "" AndAlso GetString(dr("ColumnTableAlias")) <> "") Then
                            Parms = New List(Of SqlParameter) From {
                                New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
                            sFilter = String.Concat(dr("ColumnTableAlias"), ".", dr("ColumnName"), ">= @HistoryCutoff")
                        Else
                            Parms = Nothing
                            sFilter = ""
                        End If
                        'if not set to show on menu, filter also by parent records if no parents then show none as there is no way to view them
                        If Not GetBoolean(dr("show_on_menu")) Then

                            Dim ParmList = New List(Of SqlParameter)() From {New SqlParameter("@IdoName", dr("CollectionName"))}
                            Dim ParentDT As DataTable = GetDatatable("SELECT child.ido_name,child.parent_ido_name,link.property_name, link.parent_property_name from mobile_device_child_ido child" _
                                                                           & " INNER join mobile_Device_ido_link link ON child.ido_name = link.ido_name AND child.parent_ido_name = link.parent_ido_name AND child.app_name = link.app_name" _
                                                                           & " WHERE child.app_name = 'MobileService' AND child.ido_name = @IdoName", appDB, ParmList, SyncSettings)

                            If ParentDT IsNot Nothing Then
                                'store off the link to the parent

                            End If
                        End If
                        Using table = New clsTableDataRS8416(dr("TableName"), dr("CollectionName"), dr("TableAlias"), GetBoolean(dr("allow_notes")), GetBoolean(dr("allow_documents")), sFilter, Parms, IsCustom:=True)
                            GetCustomFields(dr("CollectionName"), table, appDB, sInfobar, SyncSettings, mListForceShowTables, mDuplicateCustomFields)
                            If Not AddUserFilter(table.sIDO, table, appDB, sInfobar, SyncSettings, FormatProvider, bValidateOnly) Then Return False
                            If Not ReturnRecordsRS8416(table, appDB, settings, sInfobar, SyncSettings, mListForceShowTables, mNewCustomFields, FormatProvider, oObjectNotesCache, oObjectDocumentsCache, False, bValidateOnly) Then Return False
                        End Using
                    Next
                End If
            End Using

            If Not FinalizeSyncRS8416(appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, SyncSettings, FormatProvider, mNewCustomFields, mListForceShowTables, bValidateOnly) Then Return False
            If bValidateOnly Then
                If Not WriteValidationTotalRecord(appDB, SyncSettings, sInfobar) Then Return False
            End If
                oFields.Clear()
            oJoins.Clear()
            SetupTempTablesRS8416 = True
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            SetupTempTablesRS8416 = False
        End Try

    End Function
    Private Function CopyDictionary(ByRef source As Dictionary(Of String, String)) As Dictionary(Of String, String)
        If source Is Nothing Then Return Nothing
        CopyDictionary = New Dictionary(Of String, String)
        For Each pair As KeyValuePair(Of String, String) In source
            CopyDictionary.Add(pair.Key, pair.Value)
        Next
    End Function
    Private Function CopyDictionary(ByRef source As Dictionary(Of String, clsFieldDataRS8416)) As Dictionary(Of String, clsFieldDataRS8416)
        If source Is Nothing Then Return Nothing
        CopyDictionary = New Dictionary(Of String, clsFieldDataRS8416)
        For Each pair As KeyValuePair(Of String, clsFieldDataRS8416) In source
            CopyDictionary.Add(pair.Key, pair.Value)
        Next
    End Function
    Private Function GetMobileDeviceDataFilterSQL() As String
        Try
            Dim sql As New StringBuilder
            sql.AppendLine("Select IDO ,Property,TableName, JoinType, JoinText,TableAlias,ColumnName,FilterOperator,FilterValue,UserName,DataType,PropertyValue,RowPointer,CONVERT(NVARCHAR,RecordDate,121) AS RecordDate,AppName")
            sql.AppendLine("FROM")
            sql.AppendLine("(")
            sql.AppendLine("Select ")
            sql.AppendLine(" prop.CollectionName AS 'IDO'")
            sql.AppendLine(",prop.PropertyName as 'Property'")
            sql.AppendLine(",tbl.tablename as 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(",prop.ColumnName as 'ColumnName'")
            sql.AppendLine(",mdif.filter_operator AS 'FilterOperator'")
            sql.AppendLine(",mdif.filter_value AS 'FilterValue'")
            sql.AppendLine(",mdif.username AS 'UserName'")
            sql.AppendLine(",mdif.data_type AS 'DataType'")
            sql.AppendLine(",prop.PropertyValue AS 'PropertyValue'")
            sql.AppendLine(",mdif.RowPointer")
            sql.AppendLine(",mdif.RecordDate")
            sql.AppendLine(",mdif.app_name AS 'AppName'")
            sql.AppendLine("From ido.properties prop ")
            sql.AppendLine("Left OUTER JOIN  ido.tables tbl ON tbl.TableAlias = prop.ColumnTableAlias And tbl.CollectionName = prop.collectionname AND tbl.DevelopmentFlag = 0 ")
            sql.AppendLine("INNER Join mobile_device_ido_filter mdif ON mdif.ido_name = prop.CollectionName And mdif.property_name = prop.propertyname")
            sql.AppendLine("WHERE prop.DevelopmentFlag = 0")
            sql.AppendLine("UNION")
            sql.AppendLine("Select")
            sql.AppendLine("tbl.CollectionName")
            sql.AppendLine(",tbl.TableAlias + ufc.fld_name AS 'Property'")
            sql.AppendLine(", tbl.Tablename AS 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(", ufc.fld_name AS 'ColumnName'")
            sql.AppendLine(",mdif.filter_operator AS 'FilterOperator'")
            sql.AppendLine(",mdif.filter_value AS 'FilterValue'")
            sql.AppendLine(",mdif.username AS 'UserName'")
            sql.AppendLine(",mdif.data_type AS 'DataType'")
            sql.AppendLine(",NULL AS 'PropertyValue'")
            sql.AppendLine(",mdif.RowPointer")
            sql.AppendLine(",mdif.RecordDate")
            sql.AppendLine(",mdif.app_name AS 'AppName'")
            sql.AppendLine("From ido.tables tbl")
            sql.AppendLine("INNER Join table_class_impacted tcc ON tbl.TableName = tcc.table_name")
            sql.AppendLine("INNER Join user_class_fld_impacted ucfc ON tcc.class_name = ucfc.class_name")
            sql.AppendLine("INNER Join user_fld_impacted ufc ON ucfc.fld_name = ufc.fld_name")
            sql.AppendLine("INNER Join mobile_device_ido_filter mdif ON mdif.ido_name = tbl.CollectionName And mdif.property_name = tbl.TableAlias + ufc.fld_name")
            sql.AppendLine("WHERE tbl.TableType = 3 AND tbl.DevelopmentFlag = 0 ")
            sql.AppendLine("UNION")
            sql.AppendLine("Select")
            sql.AppendLine("tbl.CollectionName")
            sql.AppendLine(",tbl.TableAlias + ufc.fld_name AS 'Property'")
            sql.AppendLine(", tbl.Tablename AS 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(", ufc.fld_name AS 'ColumnName'")
            sql.AppendLine(",mdif.filter_operator AS 'FilterOperator'")
            sql.AppendLine(",mdif.filter_value AS 'FilterValue'")
            sql.AppendLine(",mdif.username AS 'UserName'")
            sql.AppendLine(",mdif.data_type AS 'DataType'")
            sql.AppendLine(",NULL AS 'PropertyValue'")
            sql.AppendLine(",mdif.RowPointer")
            sql.AppendLine(",mdif.RecordDate")
            sql.AppendLine(",mdif.app_name AS 'AppName'")
            sql.AppendLine("From ido.tables tbl")
            sql.AppendLine("INNER Join table_class_impacted tcc ON tbl.TableName+'_mst' = tcc.table_name")
            sql.AppendLine("INNER Join user_class_fld_impacted ucfc ON tcc.class_name = ucfc.class_name")
            sql.AppendLine("INNER Join user_fld_impacted ufc ON ucfc.fld_name = ufc.fld_name")
            sql.AppendLine("INNER Join mobile_device_ido_filter mdif ON mdif.ido_name = tbl.CollectionName And mdif.property_name = tbl.TableAlias + ufc.fld_name")
            sql.AppendLine("WHERE tbl.TableType = 3 AND tbl.DevelopmentFlag = 0")
            sql.AppendLine(") tmpView ")

            Return sql.ToString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function GetMobileDeviceFieldSQL() As String
        Try
            Dim sql As New StringBuilder
            sql.AppendLine("Select IDO ,Property,TableName, JoinType, JoinText,TableAlias,ColumnName,Caption,DataType, [MaxLength],[Precision],UserName,DownloadOnly, InlineList,PropertyValue,RowPointer,CONVERT(NVARCHAR,RecordDate,121) AS RecordDate,AppName,[Sequence],ShowOnList, DeviceInteraction, FieldStyle")
            sql.AppendLine("FROM")
            sql.AppendLine("(")
            sql.AppendLine("Select ")
            sql.AppendLine(" prop.CollectionName AS 'IDO'")
            sql.AppendLine(",prop.PropertyName as 'Property'")
            sql.AppendLine(",tbl.tablename as 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(",prop.ColumnName as 'ColumnName'")
            sql.AppendLine(",mdf.caption AS 'Caption'")
            sql.AppendLine(",dbo.EffectiveDataType(prop.PropertyClass, prop.CollectionName, prop.PropertyName, prop.DevelopmentFlag) AS 'DataType'")
            sql.AppendLine(",dbo.EffectiveDataLength(prop.PropertyClass, prop.CollectionName, prop.PropertyName, prop.DevelopmentFlag) AS 'MaxLength'")
            sql.AppendLine(",dbo.EffectiveDataDecimalPos(prop.PropertyClass, prop.CollectionName, prop.PropertyName, prop.DevelopmentFlag) AS 'Precision'")
            sql.AppendLine(",mui.username AS 'UserName'")
            sql.AppendLine(",mdf.download_only AS 'DownloadOnly'")
            sql.AppendLine(",mdf.inline_list AS 'InlineList'")
            sql.AppendLine(",prop.PropertyValue AS 'PropertyValue'")
            sql.AppendLine(",mdf.RowPointer")
            sql.AppendLine(",mdf.RecordDate")
            sql.AppendLine(",mdf.app_name AS 'AppName'")
            sql.AppendLine(",mdf.sequence AS 'Sequence'")
            sql.AppendLine(",mdf.show_on_list AS 'ShowOnList'")
            sql.AppendLine(",mdf.device_interaction AS 'DeviceInteraction'")
            sql.AppendLine(",mdf.field_style AS 'FieldStyle'")
            sql.AppendLine("From ido.properties prop ")
            sql.AppendLine("Left OUTER JOIN  ido.tables tbl ON tbl.TableAlias = prop.ColumnTableAlias And tbl.CollectionName = prop.collectionname AND tbl.DevelopmentFlag = 0 ")
            sql.AppendLine("INNER Join mobile_device_field mdf ON mdf.ido_name = prop.CollectionName And mdf.property_name = prop.propertyname")
            sql.AppendLine("INNER Join MobileUserIDOView mui ON mdf.app_name = mui.app_name And mdf.ido_name = mui.ido_name")
            sql.AppendLine("WHERE prop.DevelopmentFlag = 0")
            sql.AppendLine("UNION")
            sql.AppendLine("Select")
            sql.AppendLine("tbl.CollectionName")
            sql.AppendLine(",tbl.TableAlias + ufc.fld_name AS 'Property'")
            sql.AppendLine(", tbl.Tablename AS 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(", ufc.fld_name AS 'ColumnName'")
            sql.AppendLine(", ufc.fld_desc AS 'Caption'")
            sql.AppendLine(", ufc.fld_data_type AS 'DataType'")
            sql.AppendLine(", ufc.fld_prec AS 'MaxLength'")
            sql.AppendLine(", ufc.fld_decimals AS 'Precision'")
            sql.AppendLine(",mui.username AS 'UserName'")
            sql.AppendLine(",mdf.download_only AS 'DownloadOnly'")
            sql.AppendLine(",mdf.inline_list AS 'InlineList'")
            sql.AppendLine(",NULL AS 'PropertyValue'")
            sql.AppendLine(",mdf.RowPointer")
            sql.AppendLine(",mdf.RecordDate")
            sql.AppendLine(",mdf.app_name AS 'AppName'")
            sql.AppendLine(",mdf.sequence AS 'Sequence'")
            sql.AppendLine(",mdf.show_on_list AS 'ShowOnList'")
            sql.AppendLine(",mdf.device_interaction AS 'DeviceInteraction'")
            sql.AppendLine(",mdf.field_style AS 'FieldStyle'")
            sql.AppendLine("From ido.tables tbl")
            sql.AppendLine("INNER Join table_class_impacted tcc ON tbl.TableName = tcc.table_name")
            sql.AppendLine("INNER Join user_class_fld_impacted ucfc ON tcc.class_name = ucfc.class_name")
            sql.AppendLine("INNER Join user_fld_impacted ufc ON ucfc.fld_name = ufc.fld_name")
            sql.AppendLine("INNER Join mobile_device_field mdf ON mdf.ido_name = tbl.CollectionName And mdf.property_name = tbl.TableAlias + ufc.fld_name")
            sql.AppendLine("INNER Join MobileUserIDOView mui ON mdf.app_name = mui.app_name And mdf.ido_name = mui.ido_name")
            sql.AppendLine("WHERE tbl.TableType = 3 AND tbl.DevelopmentFlag = 0 ")
            sql.AppendLine("UNION")
            sql.AppendLine("Select")
            sql.AppendLine("tbl.CollectionName")
            sql.AppendLine(",tbl.TableAlias + ufc.fld_name AS 'Property'")
            sql.AppendLine(", tbl.Tablename AS 'TableName'")
            sql.AppendLine(",tbl.JoinType as 'JoinType'")
            sql.AppendLine(",tbl.JoinText as 'JoinText'")
            sql.AppendLine(",tbl.TableAlias AS 'TableAlias'")
            sql.AppendLine(", ufc.fld_name AS 'ColumnName'")
            sql.AppendLine(", ufc.fld_desc AS 'Caption'")
            sql.AppendLine(", ufc.fld_data_type AS 'DataType'")
            sql.AppendLine(", ufc.fld_prec AS 'MaxLength'")
            sql.AppendLine(", ufc.fld_decimals AS 'Precision'")
            sql.AppendLine(",mui.username AS 'UserName'")
            sql.AppendLine(",mdf.download_only AS 'DownloadOnly'")
            sql.AppendLine(",mdf.inline_list AS 'InlineList'")
            sql.AppendLine(",NULL AS 'PropertyValue'")
            sql.AppendLine(",mdf.RowPointer")
            sql.AppendLine(",mdf.RecordDate")
            sql.AppendLine(",mdf.app_name AS 'AppName'")
            sql.AppendLine(",mdf.sequence AS 'Sequence'")
            sql.AppendLine(",mdf.show_on_list AS 'ShowOnList'")
            sql.AppendLine(",mdf.device_interaction AS 'DeviceInteraction'")
            sql.AppendLine(",mdf.field_style AS 'FieldStyle'")
            sql.AppendLine("From ido.tables tbl")
            sql.AppendLine("INNER Join table_class_impacted tcc ON tbl.TableName+'_mst' = tcc.table_name")
            sql.AppendLine("INNER Join user_class_fld_impacted ucfc ON tcc.class_name = ucfc.class_name")
            sql.AppendLine("INNER Join user_fld_impacted ufc ON ucfc.fld_name = ufc.fld_name")
            sql.AppendLine("INNER Join mobile_device_field mdf ON mdf.ido_name = tbl.CollectionName And mdf.property_name = tbl.TableAlias + ufc.fld_name")
            sql.AppendLine("INNER Join MobileUserIDOView mui ON mdf.app_name = mui.app_name And mdf.ido_name = mui.ido_name")
            sql.AppendLine("WHERE tbl.TableType = 3 AND tbl.DevelopmentFlag = 0")
            sql.AppendLine(") tmpView ")

            Return sql.ToString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function ReturnRecordsRS8416(ByRef tbl As clsTableDataRS8416, ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                         ByRef SyncSettings As ClsSyncSettings, ByRef mListForceShowTables As List(Of String),
                                         ByRef mNewCustomFields As List(Of String), ByVal FormatProvider As IFormatProvider,
                                         ByRef oObjectNotesCache As DataTable, ByRef oObjectDocumentsCache As DataTable, ByRef bFirstTable As Boolean,
                                         ByVal bValidateOnly As Boolean) As Boolean
        ReturnRecordsRS8416 = False
        Try
            Dim sSQL As String = ""
            Dim time As DateTime
            Dim time2 As DateTime
            Dim mDeviceDataOld As Generic.Dictionary(Of String, String)
            Dim mDeviceDataNew As Generic.Dictionary(Of String, String)
            Dim mDeviceDataUpd As Generic.Dictionary(Of String, String)
            Dim mDeviceDataSame As Generic.Dictionary(Of String, String)
            mDeviceDataNew = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataSame = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataUpd = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataOld = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)

            If mListForceShowTables.Contains(tbl.sIDO) Then
                SyncSettings.ResponseMultiplier = 2
            Else
                SyncSettings.ResponseMultiplier = 1
            End If
            time = Now
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Starting.", tbl.sTableName))

            If bValidateOnly Then
                'if validating then reset on each table
                SyncSettings.ResponseSize = 1
                SyncSettings.RecordCount = 0
            Else
                If tbl.DeferProcess Then
                    PrepDeviceData(appDB, tbl.sTableName, bFirstTable, SyncSettings, mDeviceDataOld, True)
                Else
                    PrepDeviceData(appDB, tbl.sTableName, bFirstTable, SyncSettings, mDeviceDataOld)
                End If


            End If
            tbl.dt = GetTableRecordsRS8416(appDB, tbl, sInfobar, SyncSettings)

            For Each sSecondaryJoin As KeyValuePair(Of String, String) In tbl.SecondaryJoins
                If tbl.dt Is Nothing Then
                    tbl.dt = GetTableRecordsRS8416(appDB, tbl, sInfobar, SyncSettings, sSecondaryJoin)
                Else
                    tbl.dt.Merge(GetTableRecordsRS8416(appDB, tbl, sInfobar, SyncSettings, sSecondaryJoin))
                End If
            Next
            'There are no records to process
            If tbl.dt Is Nothing OrElse tbl.dt.Rows.Count = 0 Then
                time2 = Now
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Table: {0} Records: 0", tbl.sTableName))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Complete. Duration: {1}", tbl.sTableName, (time2 - time).ToString))
                If bValidateOnly And (Not tbl.DeferProcess Or SyncSettings.ValidationMessage <> "") Then
                    Return WriteValidationRecord(appDB, tbl, SyncSettings, sInfobar)
                End If
                Return True
            End If
            'Setup output table to JSON serialization
            tbl.BuildOutTable()

            'populate output table with records
            If Not BuildXMLFromDT(tbl, appDB, sInfobar, SyncSettings,
                                  FormatProvider, settings, mDeviceDataOld,
                                  mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame,
                                  mNewCustomFields, mListForceShowTables, bValidateOnly) Then
                If bValidateOnly And Not String.IsNullOrEmpty(sInfobar) Then
                    SyncSettings.ValidationMessage = sInfobar
                    Return WriteValidationRecord(appDB, tbl, SyncSettings, sInfobar)
                Else
                    Exit Function
                End If
            End If
            If tbl.doNotes Then
                CacheNotes(appDB, tbl.sTableName, tbl.dt, oObjectNotesCache, SyncSettings)
            End If

            If tbl.doDocs Then
                CacheDocuments(appDB, tbl.sTableName, tbl.dt, oObjectDocumentsCache, SyncSettings)
            End If

            If Not bValidateOnly Then
                If Not SaveDeviceData(appDB, sInfobar, tbl, SyncSettings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame) Then Exit Function
            End If

            If tbl.outTable IsNot Nothing And tbl.outTable.Rows.Count > 0 Then
                SetJSONString(tbl, SyncSettings, settings, mListForceShowTables)
            End If

            bFirstTable = False
            time2 = Now
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Complete. Duration: {1}", tbl.sTableName, (time2 - time).ToString))

            If mDeviceDataOld IsNot Nothing Then
                mDeviceDataOld.Clear()
            End If
            If mDeviceDataNew IsNot Nothing Then
                mDeviceDataNew.Clear()
            End If
            If mDeviceDataUpd IsNot Nothing Then
                mDeviceDataUpd.Clear()
            End If
            If mDeviceDataSame IsNot Nothing Then
                mDeviceDataSame.Clear()
            End If

            If bValidateOnly Then
                If Not WriteValidationRecord(appDB, tbl, SyncSettings, sInfobar) Then Return False
            End If
            ReturnRecordsRS8416 = True
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            SyncSettings.ValidationMessage = sInfobar
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            If bValidateOnly Then
                If Not WriteValidationRecord(appDB, tbl, SyncSettings, sInfobar) Then Return False
                ReturnRecordsRS8416 = True 'return true so the validation can continue
            Else
                ReturnRecordsRS8416 = False
            End If
        End Try
    End Function
    Public Sub SetJSONString(ByRef tbl As clsTableDataRS8416, ByRef SyncSettings As ClsSyncSettings, ByRef settings As JsonSerializerSettings, ByRef mListForceShowTables As List(Of String))
        If tbl.IsCustom Then
            SyncSettings.JSONOut = SyncSettings.JSONOut + ",""LocalCustomRecords"":      " + JsonConvert.SerializeObject(tbl.outTable, settings)
        Else
            SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + tbl.sIDO + """:      " + JsonConvert.SerializeObject(tbl.outTable, settings)

            'also send as custom
            If mListForceShowTables.Contains(tbl.sIDO) Then
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Sending IDO: {0} as Custom.", tbl.sIDO))
                If Not tbl.outTable.Columns.Contains("IDO") Then
                    Dim idoCol As New DataColumn("IDO", GetType(String)) With {
                        .DefaultValue = tbl.sIDO
                    }

                    tbl.outTable.Columns.Add(idoCol)
                    idoCol.SetOrdinal(0)
                End If
                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""LocalCustomRecords"":      " + JsonConvert.SerializeObject(tbl.outTable, settings)
            End If
        End If
    End Sub
    Public Function BuildXMLFromDT(ByRef tbl As clsTableDataRS8416,
                                   ByRef appDB As ApplicationDB,
                                   ByRef sInfobar As String,
                                   ByRef SyncSettings As ClsSyncSettings,
                                   ByVal FormatProvider As IFormatProvider,
                                   ByRef settings As JsonSerializerSettings,
                                   ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataSame As Generic.Dictionary(Of String, String),
                                   ByRef mNewCustomFields As List(Of String),
                                   ByRef mListForceShowTables As List(Of String),
                                   ByVal bValidateOnly As Boolean) As Boolean

        Try
            Dim oRow As DataRow
            Dim bIsNew As Boolean = False

            BuildXMLFromDT = False

            SyncSettings.DeviceSyncSeq = SyncSettings.DeviceSyncSeq + 1
            For Each oRow In tbl.dt.Rows

                If SyncSettings.ResponseSize >= SyncSettings.MaxResponseSize Then
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Split sync {0} at table {1}.", SyncSettings.TmpSequence.ToString(), tbl.sTableName))
                    If tbl.outTable IsNot Nothing And tbl.outTable.Rows.Count > 0 Then
                        SetJSONString(tbl, SyncSettings, settings, mListForceShowTables)
                    End If
                    If bValidateOnly Then
                        SyncSettings.TableSize = SyncSettings.TableSize + SyncSettings.JSONOut.Length / 1000000.0
                        SyncSettings.JSONOut = ""
                        SyncSettings.ResponseSize = 1
                    Else
                        If Not WriteTmpData(appDB, sInfobar, SyncSettings) Then Return False
                    End If
                    tbl.outTable.Clear()
                End If

                ' Create/Setup "record"
                AddRecord(tbl, oRow, bIsNew, SyncSettings, FormatProvider, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame, mNewCustomFields)

                AddDataRow(tbl, oRow, sInfobar, bIsNew, appDB, SyncSettings, mNewCustomFields, FormatProvider)
            Next

            Return True
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
            sInfobar = ex.Message
            Return False
        End Try
    End Function
    Private Function FieldList(ByVal table As clsTableDataRS8416, Optional ByVal bIsTempTable As Boolean = False, Optional ByVal bkeyonly As Boolean = False, Optional ByVal bNullParent As Boolean = False) As String
        Dim sColumns As String = ""
        For Each field As clsFieldDataRS8416 In table.fields.Values
            If field.HierarchicalParent And bNullParent Then
                sColumns = sColumns + ",NULL"
            ElseIf field.sExpression <> "" And Not bIsTempTable Then
                sColumns = sColumns + "," + field.sExpression
            ElseIf (bkeyonly And field.bKeyField) Or Not bkeyonly Then
                sColumns = sColumns + "," + field.sField
            End If
        Next
        If (String.IsNullOrEmpty(sColumns)) Then
            sColumns = "*"
        Else
            sColumns = sColumns.TrimStart(",")
        End If
        Return sColumns
    End Function
    Private Function GetJoin(ByVal table As clsTableDataRS8416) As String
        Dim sJoin As String = ""

        For Each join As String In table.Joins.Values
            sJoin = sJoin + vbNewLine + join
        Next
        For Each join As String In table.AddlJoins
            sJoin = sJoin + vbNewLine + join
        Next

        If (String.IsNullOrEmpty(sJoin)) Then
            sJoin = ""
        End If
        Return sJoin
    End Function
    Public Function GetTableRecordsRS8416(ByRef appDB As ApplicationDB,
                                    ByVal tblData As clsTableDataRS8416,
                                    ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings,
                                    Optional ByVal sJoinOverride As KeyValuePair(Of String, String) = Nothing) As DataTable
        Dim sSql As New System.Text.StringBuilder
        Try
            Dim sWhere As String

            Dim oParms As List(Of SqlParameter)

            oParms = New List(Of SqlParameter)
            sSql.Length = 0
            sWhere = ""
            Dim sParentCol As String = ""
            Dim sChildCol As String = ""

            'GetFilters(oParms, sWhere, GetTableRecords.TableName)
            If tblData.IsHierarchical Then

                For Each sfield As clsFieldDataRS8416 In tblData.fields.Values
                    If sfield.HierarchicalChild Then
                        sChildCol = sfield.sField
                    ElseIf sfield.HierarchicalParent Then
                        sParentCol = sfield.sField
                    End If
                    If sChildCol <> "" And sParentCol <> "" Then Exit For
                Next

                sSql.AppendFormat(";WITH {0}_cte (", tblData.sTableName)
                sSql.AppendLine(FieldList(tblData, bIsTempTable:=True))
                sSql.AppendLine("  )")
                sSql.AppendLine(" AS (SELECT")
                sSql.AppendLine(FieldList(tblData))
                sSql.AppendFormat("From {0} {1} (NOLOCK)", tblData.sTableName, tblData.sAlias)
                sSql.AppendLine()
                sSql.AppendFormat("WHERE {0}", tblData.sFilter)
                sSql.AppendLine()
                sSql.AppendLine("UNION ALL")
                sSql.AppendLine("  Select ")
                sSql.AppendLine(FieldList(tblData))
                sSql.AppendFormat("From {0} {1} (NOLOCK)", tblData.sTableName, tblData.sAlias)
                sSql.AppendLine()
                sSql.AppendFormat("INNER JOIN {0}_cte cte ON cte.{1} = {2}.{3}", tblData.sTableName, sChildCol, tblData.sAlias, sParentCol)
                sSql.AppendLine(")")
                sSql.AppendFormat("Select DISTINCT {0} FROM {1}_cte {2} ", FieldList(tblData), tblData.sTableName, tblData.sAlias)
                sSql.AppendLine()
            Else
                If tblData.TempTable <> "" And tblData.CreateTempTable And sJoinOverride.Key Is Nothing Then
                    'sSql.AppendFormat("Select {0} INTO {1} FROM {2} ", FieldList(tblData), SQLQuoted(tblData.TempTable), SQLQuoted(tblData.sTableName))
                    'sSql.AppendLine(GetJoin(tblData))
                    'sSql.AppendLine("WHERE 1= 2")
                    'sSql.AppendFormat("Select * FROM {0} ", SQLQuoted(tblData.TempTable))
                    'Dim dt As DataTable = GetDatatable(sSql.ToString, oConn, oTrans, Nothing)
                    'sSql.Length = 0

                    sSql.AppendFormat("CREATE TABLE {0}(", SQLQuoted(tblData.TempTable))
                    Dim bfirst As Boolean = True
                    For Each fld As clsFieldDataRS8416 In tblData.fields.Values
                        If fld.sField = "" Then Continue For
                        If bfirst Then
                            sSql.AppendFormat("{0} {1}", fld.sField, fld.sSQLType)
                            bfirst = False
                        Else
                            sSql.AppendFormat(", {0} {1}", fld.sField, fld.sSQLType)
                        End If
                        sSql.AppendLine()

                    Next
                    sSql.AppendLine(")")

                    sSql.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_RowPointer ON {0}(RowPointer)", tblData.TempTable)
                    sSql.AppendLine()
                    Dim keylist As String = FieldList(tblData, True, True)
                    If (keylist <> "*") Then
                        sSql.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_Main ON {0}({1})", tblData.TempTable, keylist)
                    End If
                    sSql.AppendLine()



                    ExecuteSQLStatement(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)
                    sSql.Length = 0
                End If
                If tblData.TempTable <> "" And tblData.DeferProcess Then
                    If (tblData.sTableView <> "") Then
                        sSql.AppendFormat("INSERT INTO {0} Select DISTINCT {1} FROM {2} {3}", SQLQuoted(tblData.TempTable), FieldList(tblData), SQLQuoted(tblData.sTableView), SQLQuoted(tblData.sAlias))
                        sSql.AppendLine()
                    Else
                        sSql.AppendFormat("INSERT INTO {0} Select DISTINCT {1} FROM {2} {3}", SQLQuoted(tblData.TempTable), FieldList(tblData), SQLQuoted(tblData.sTableName), SQLQuoted(tblData.sAlias))
                        sSql.AppendLine()
                    End If

                Else
                    If tblData.TempTable <> "" Then
                        sSql.AppendFormat("Select {0} FROM {1} {2} ", FieldList(tblData, True), SQLQuoted(tblData.TempTable), SQLQuoted(tblData.sAlias))
                        sSql.AppendLine()
                    Else
                        If (tblData.sTableView <> "") Then
                            sSql.AppendFormat("Select {0} FROM {1} {2} ", FieldList(tblData), SQLQuoted(tblData.sTableView), SQLQuoted(tblData.sAlias))
                            sSql.AppendLine()
                        ElseIf tblData.sTableName = "mobile_device_field" Then
                            sSql.Append(GetMobileDeviceFieldSQL())
                        Else
                            sSql.AppendFormat("Select {0} FROM {1} {2}", FieldList(tblData), SQLQuoted(tblData.sTableName), SQLQuoted(tblData.sAlias))
                            sSql.AppendLine()
                        End If

                    End If
                End If

                sSql.AppendLine(GetJoin(tblData))

                'normal processing of main select
                If sJoinOverride.Key Is Nothing Then
                    If tblData.sFilter <> "" Then
                        sSql.AppendFormat("WHERE {0}", tblData.sFilter)
                        sSql.AppendLine()
                    End If
                Else 'processing secondary joins to add additional data
                    sSql.AppendLine(sJoinOverride.Key)

                    If Not String.IsNullOrEmpty(sJoinOverride.Value) Then
                        sSql.AppendFormat("WHERE {0}", sJoinOverride.Value)
                        sSql.AppendLine()
                    End If
                End If

                If tblData.Parms IsNot Nothing Then
                    For Each parm As SqlParameter In tblData.Parms
                        oParms.Add(New SqlParameter(parm.ParameterName, parm.Value))
                    Next
                End If

            End If


            If tblData.DeferProcess Then

                ExecuteSQLStatement(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)

                Return Nothing 'just adding records to the temp table
            Else
                GetTableRecordsRS8416 = GetDatatable(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)
                GetTableRecordsRS8416.TableName = tblData.sTableName
                GetTableRecordsRS8416.CaseSensitive = False
            End If

            Return GetTableRecordsRS8416
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
            If sSql IsNot Nothing AndAlso sSql.Length > 0 Then
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sSql.ToString)
            End If

            Return Nothing
        End Try
    End Function
    Public Sub AddRecord(ByVal tblData As clsTableDataRS8416,
                         ByRef oRow As DataRow,
                         ByRef bIsNew As Boolean, ByRef SyncSettings As ClsSyncSettings,
                         ByVal FormatProvider As IFormatProvider,
                         ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataSame As Generic.Dictionary(Of String, String),
                         ByRef mNewCustomFields As List(Of String))
        Dim sRowPointer As String = ""
        Dim dRecordDate As Date
        Dim dTmpDate As Date
        If Not oRow Is Nothing Then
            sRowPointer = GetString(oRow("RowPointer"))

            For Each sColumn As String In tblData.DateColumns
                dTmpDate = GetDate(oRow(sColumn), FormatProvider)
                If (dTmpDate > dRecordDate) Then
                    dRecordDate = dTmpDate
                End If
            Next
        End If
        AddRecordInternal(tblData, sRowPointer, dRecordDate, bIsNew, SyncSettings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame, mNewCustomFields)

    End Sub
    Private Sub AddRecordInternal(ByVal tblData As clsTableDataRS8416,
                                  ByVal sRowPointer As String,
                                  ByVal dRecordDate As Date,
                                  ByRef bIsNew As Boolean,
                                  ByRef SyncSettings As ClsSyncSettings,
                                  ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataSame As Generic.Dictionary(Of String, String),
                                  ByRef mNewCustomFields As List(Of String))
        SyncSettings.SuspendAddThisRecord = False

        If sRowPointer.Length > 0 Then

            'If Not mTablesProcessed.Contains(tblData.sIDO) Then mTablesProcessed.Add(tblData.sIDO)
            'sXMLTableName,
            ' Dim oData As New clsDeviceData(sRowPointer, dRecordDate)

            ' Need to figure out if record actually needs to be sent.
            Dim sKey As String = sRowPointer
            If mDeviceDataOld.ContainsKey(sKey) Then
                ' we need to send an update if the record changed or a new custom field was added to the table
                If dRecordDate <= SyncSettings.LastSyncDate AndAlso Not mNewCustomFields.Contains(tblData.sIDO) Then
                    ' Suspend Sending this record!!!
                    SyncSettings.SuspendAddThisRecord = True
                    If Not mDeviceDataSame.ContainsKey(sKey) Then
                        mDeviceDataSame.Add(sKey, sRowPointer)
                    End If
                    Return
                End If
                If Not mDeviceDataUpd.ContainsKey(sKey) Then
                    mDeviceDataUpd.Add(sKey, sKey)
                Else
                    'record already sent
                    SyncSettings.SuspendAddThisRecord = True
                    Return
                End If
                bIsNew = False
            Else
                If Not mDeviceDataNew.ContainsKey(sKey) Then
                    mDeviceDataNew.Add(sKey, sKey)
                Else
                    'record already sent
                    SyncSettings.SuspendAddThisRecord = True
                    Return
                End If
                bIsNew = True
            End If

        End If

    End Sub
    Public Sub AddDataRow(ByRef tblData As clsTableDataRS8416, ByVal oRow As DataRow, ByRef sInfobar As String, ByVal bIsNew As Boolean,
                          ByRef AppDB As ApplicationDB, ByRef SyncSettings As ClsSyncSettings, ByRef mNewCustomFields As List(Of String),
                          ByVal FormatProvider As IFormatProvider)
        If SyncSettings.SuspendAddThisRecord Then Exit Sub

        SyncSettings.RecordCount = SyncSettings.RecordCount + 1
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + ((tblData.sTableName.Length + SyncSettings.RecordPadding) * SyncSettings.ResponseMultiplier)



        Dim outRow As DataRow = tblData.outTable.NewRow()
        outRow("_ItemId") = CreateItemId(tblData.sTableName, tblData.sAlias, oRow("RowPointer").ToString, oRow("RecordDate"))
        outRow("ToRemove") = "False"

        If bIsNew Then
            outRow("ToInsert") = "True"

            'track tables with new fields added
            If tblData.sIDO = "SLMobileDeviceFields" AndAlso Not mNewCustomFields.Contains(oRow("IDO")) Then
                mNewCustomFields.Add(oRow("IDO"))
            End If

        Else
            outRow("ToInsert") = "False"
        End If

        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("_ItemId".Length + GetString(outRow("_ItemId")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("ToInsert".Length + GetString(outRow("ToInsert")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("ToRemove".Length + GetString(outRow("ToRemove")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)

        If tblData.IsCustom Then
            Me.AddXMLField("IDO", tblData.sIDO, outRow, SyncSettings)
        End If

        For Each fldData As clsFieldDataRS8416 In tblData.fields.Values
            Try
                If fldData.sField = "_ItemId" Or fldData.sField = "ToRemove" Or fldData.sField = "ToInsert" Or fldData.sField = "NativeGetImage" _
                    Or fldData.sProperty = "_ItemId" Or fldData.sProperty = "ToRemove" Or fldData.sProperty = "ToInsert" Or fldData.sProperty = "NativeGetImage" Then Continue For
                If fldData.sField <> "" And fldData.sProperty <> "" Then
                    If tblData.dt.Columns(fldData.sField).DataType = GetType(String) Then
                        Me.AddXMLField(fldData.sProperty, oRow(fldData.sField), outRow, AppDB, fldData.Translate, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Int32) Then
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Boolean) Then
                        Me.AddXMLLogiField(fldData.sProperty, GetBoolean(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Byte) Then 'bytes don't allow nulls treat as integer
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Double) Then
                        Me.AddXMLField(fldData.sProperty, GetDouble(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Decimal) Then
                        Me.AddXMLField(fldData.sProperty, SQLDecimal(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Int16) Then
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Date) Then
                        Me.AddXMLDateTimeField(fldData.sProperty, GetDate(oRow(fldData.sField), FormatProvider), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(DateTime) Then
                        Me.AddXMLDateTimeField(fldData.sProperty, GetDate(oRow(fldData.sField), FormatProvider), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Guid) Then
                        Me.AddXMLField(fldData.sProperty, GetString(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Byte()) Then
                        If oRow(fldData.sField).ToString <> "" Then
                            If SyncSettings.Is915OrLater Then
                                outRow("NativeGetImage") = fldData.sProperty
                            Else
                                Me.AddXMLField(fldData.sProperty, Convert.ToBase64String(oRow(fldData.sField)), outRow, SyncSettings)
                            End If
                        End If
                    Else
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, String.Format("Processing: {0} Can't handle {1}", tblData.sTableName, fldData.sField))
                    End If
                Else
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, String.Concat("Can't handle ", fldData.sProperty))
                End If
            Catch ex As Exception
                sInfobar = MGException.ExtractMessages(ex)
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            End Try
        Next
        tblData.outTable.Rows.Add(outRow)
    End Sub
    Public Sub AddXMLField(ByVal sXMLFieldName As String, ByVal sXMLFieldValue As Object, ByRef outRow As DataRow, ByRef appDB As ApplicationDB, ByVal Translate As Boolean, ByRef SyncSettings As ClsSyncSettings)

        Try
            If SyncSettings.SuspendAddThisRecord = True Then Return

            If sXMLFieldValue Is System.DBNull.Value OrElse sXMLFieldValue Is Nothing Then Return

            If sXMLFieldValue.ToString.Contains(Chr(3)) Then
                sXMLFieldValue = sXMLFieldValue.ToString.Replace(Chr(3), Chr(32))
            End If

            If Translate AndAlso sXMLFieldValue.ToString.Length > 1 Then
                Dim Entries As String
                Dim newEntries As String = ""
                Dim reg As Regex = New Regex("ENTRIES\((?<Entries>.+)\) DISPLAY\((?<DisplayFull>(?<Display>[0-9]+)[0-9,]*)\) VALUE\((?<Value>[0-9]+)\)")
                'if the value is an inline list parse
                If reg.IsMatch(sXMLFieldValue.ToString) Then
                    Entries = reg.Match(sXMLFieldValue.ToString).Groups("Entries").Value
                    'Entries Format: C\sCall,D\sDispatch,S\sSRO
                    For Each Entry As String In Entries.Split(",")
                        'Entry Format: C\sCall
                        For Each column As String In Entry.Split("\")
                            If column IsNot Nothing AndAlso column.Length > 1 Then
                                column = GetStringValue(column, appDB, SyncSettings)
                            End If
                            newEntries = newEntries + column + "\"
                        Next
                        newEntries = newEntries.TrimEnd("\")
                        newEntries = newEntries + ","
                    Next
                    newEntries = newEntries.TrimEnd(",")
                    sXMLFieldValue = sXMLFieldValue.ToString.Replace(Entries, newEntries)
                Else
                    sXMLFieldValue = GetStringValue(sXMLFieldValue, appDB, SyncSettings)
                End If
            End If

            outRow(sXMLFieldName) = sXMLFieldValue
        Catch ex As Exception
            outRow(sXMLFieldName) = sXMLFieldValue
        End Try

        SyncSettings.ResponseSize = SyncSettings.ResponseSize + ((sXMLFieldName.Length + sXMLFieldValue.Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)
    End Sub
    Private Function GetStringValue(ByVal sValue As String, ByRef appDB As ApplicationDB, ByRef SyncSettings As ClsSyncSettings) As String
        Try
            Dim oParms As List(Of SqlParameter) = New List(Of SqlParameter)
            Dim tmpValue As String
            Dim sb As New StringBuilder
            If (Not String.IsNullOrEmpty(SyncSettings.FormServer) And Not String.IsNullOrEmpty(SyncSettings.FormDatabase)) Then
                oParms.Add(New SqlParameter("@String", sValue))
                If SyncSettings.FormServer.ToLower = "localhost" Then
                    sb.AppendFormat("SELECT string FROM {0}.dbo.{1}", SQLQuoted(SyncSettings.FormDatabase), SQLQuoted(SyncSettings.UserStringsTable))
                    sb.AppendLine()
                    sb.AppendLine("WHERE [name] = @String")
                Else
                    sb.AppendFormat("SELECT string FROM {0}.{1}.dbo.{2}", SQLQuoted(SyncSettings.FormServer), SQLQuoted(SyncSettings.FormDatabase), SQLQuoted(SyncSettings.UserStringsTable))
                    sb.AppendLine()
                    sb.AppendLine("WHERE [name] = @String")
                End If

                tmpValue = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                If tmpValue <> "" Then
                    Return tmpValue
                ElseIf SyncSettings.UserStringsTable <> "Strings" Then
                    'if the string isn't translated fall back to base strings
                    sb.Length = 0
                    oParms.Clear()
                    oParms.Add(New SqlParameter("@String", sValue))
                    If SyncSettings.FormServer.ToLower = "localhost" Then
                        sb.AppendFormat("SELECT string FROM {0}.dbo.strings", SQLQuoted(SyncSettings.FormDatabase))
                        sb.AppendLine()
                        sb.AppendLine("WHERE [name] = @String")
                    Else
                        sb.AppendFormat("SELECT string FROM {0}.{1}.dbo.strings", SQLQuoted(SyncSettings.FormServer), SQLQuoted(SyncSettings.FormDatabase))
                        sb.AppendLine()
                        sb.AppendLine("WHERE [name] = @String")
                    End If

                    tmpValue = Lookup(sb.ToString, appDB, oParms, SyncSettings)
                    If tmpValue <> "" Then
                        Return tmpValue
                    End If
                End If
            End If

            Return sValue

        Catch ex As Exception
            Return sValue
        End Try

    End Function

    Private Function AddUserFilter(sIDO As String, ByRef table As clsTableDataRS8416, ByRef appDB As ApplicationDB, ByRef sInfobar As String,
                                ByRef SyncSettings As ClsSyncSettings, ByRef FormatProvider As IFormatProvider, ByVal bValidateOnly As Boolean) As Boolean
        Try
            Dim sSQL As String
            Dim row As DataRow
            Dim oParms As New List(Of SqlParameter)
            Dim sTableAlias As String
            Dim iJoinType As Integer
            Dim sJoinType As String
            Dim sJoinText As String
            Dim sTableName As String
            Dim sPropertyValue As String
            Dim sPropertyName As String
            Dim sColumnName As String
            Dim sDataType As String
            Dim sFilterOperator As String
            Dim sFilterValue As String
            Dim offset As Double
            oParms.Add(New SqlParameter("@UserName", SyncSettings.Username))
            oParms.Add(New SqlParameter("@IdoName", sIDO))
            oParms.Add(New SqlParameter("@AppName", SyncSettings.AppId))
            sSQL = GetMobileDeviceDataFilterSQL()
            sSQL = sSQL + " WHERE IDO = @IdoName AND AppName = @AppName AND (UserName = @UserName OR UserName = '*') ORDER BY UserName DESC"
            Dim sUserFilters As New List(Of String)
            Using dt As DataTable = GetDatatable(sSQL, appDB, oParms, SyncSettings, sInfobar)
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return True

                'wrap predefined filter 
                If Not String.IsNullOrEmpty(table.sFilter) Then
                    table.sFilter = String.Format("({0})", table.sFilter)
                End If


                For Each row In dt.Rows
                    sTableAlias = GetString(row("TableAlias"))
                    sTableName = GetString(row("TableName"))
                    sJoinText = GetString(row("JoinText"))
                    iJoinType = GetInteger(row("JoinType"))
                    sPropertyValue = GetString(row("PropertyValue")) 'for derived properties if we choose to support
                    sPropertyName = GetString(row("Property"))
                    sColumnName = GetString(row("ColumnName"))
                    sFilterOperator = GetString(row("FilterOperator")).ToLower
                    sFilterValue = GetString(row("FilterValue")).ToLower
                    sDataType = GetString(row("DataType")).ToLower
                    'we need to skip adding this a second time if we already added a user specific version
                    If sUserFilters.Contains(sPropertyName) Then Continue For

                    sUserFilters.Add(sPropertyName)

                    'add in join if needed
                    If sTableAlias <> "" AndAlso sTableName <> "" AndAlso sJoinText <> "" AndAlso iJoinType <> 0 Then
                        If Not table.Joins.ContainsKey(sTableAlias) Then
                            If iJoinType = 0 Then
                                sJoinType = "INNER JOIN"
                            Else
                                sJoinType = "LEFT OUTER JOIN"
                            End If

                            table.Joins.Add(sTableAlias, String.Format("{0} {1} {2} ON {3}", sJoinType, SQLQuoted(sTableName), SQLQuoted(sTableAlias), sJoinText))
                        End If
                    End If

                    If sPropertyValue <> "" Then
                        sPropertyValue = SubstituteDerivedValues(sPropertyValue, sIDO, table, appDB, sInfobar, SyncSettings)
                    ElseIf sTableAlias <> "" Then
                        sPropertyValue = SQLQuoted(sTableAlias) + "." + SQLQuoted(sColumnName)
                    End If

                    'input validation
                    sFilterValue = sFilterValue.Replace("sys(partnerid)", SyncSettings.PartnerId)
                    sFilterValue = sFilterValue.Replace("sys(username)", SyncSettings.Username)
                    sFilterValue = sFilterValue.Replace("sys(partnerwhse)", SyncSettings.PartnerWhse)
                    sFilterValue = sFilterValue.Replace("sys(dayshistory)", SyncSettings.HistoryCutoff)
                    sFilterValue = sFilterValue.Replace(";", "")
                    sFilterValue = sFilterValue.Replace("(", "")
                    sFilterValue = sFilterValue.Replace(")", "")
                    sFilterValue = sFilterValue.Replace(" and ", "")
                    sFilterValue = sFilterValue.Replace(" or ", "")

                    If sDataType = "date" AndAlso Not String.IsNullOrEmpty(sFilterValue) Then
                        If (sFilterOperator = "in" Or sFilterOperator = "be") Then

                            Dim sb As New StringBuilder
                            For Each sValue In sFilterValue.Split(",")
                                If (Double.TryParse(sValue, offset)) Then
                                    sb.AppendFormat(",{0}", SyncSettings.CurrentDate.AddDays(offset))
                                Else
                                    sb.AppendFormat(",{0}", SQLDateTime(sValue, FormatProvider))
                                End If
                            Next
                            sFilterValue = sb.ToString.TrimStart(",")
                        Else
                            If (Double.TryParse(sFilterValue, offset)) Then
                                sFilterValue = SyncSettings.CurrentDate.AddDays(offset)
                            Else
                                sFilterValue = SQLDateTime(sFilterValue, FormatProvider)
                            End If
                        End If
                    End If


                    If sFilterOperator = "in" AndAlso Not String.IsNullOrEmpty(sFilterValue) Then
                        If String.IsNullOrEmpty(table.sFilter) Then
                            table.sFilter = String.Format("{0} IN ({1})", sPropertyValue, QuoteList(sFilterValue))
                        Else
                            table.sFilter = String.Format("{0} AND {1} IN ({2})", table.sFilter, sPropertyValue, QuoteList(sFilterValue))
                        End If
                    ElseIf sFilterOperator = "be" AndAlso Not String.IsNullOrEmpty(sFilterValue) Then
                        If sFilterValue.Split(",").Length = 2 Then
                            If String.IsNullOrEmpty(table.sFilter) Then
                                table.sFilter = String.Format("{0} BETWEEN {1} AND {2}", sPropertyValue, GetString(sFilterValue.Split(",")(0), True), GetString(sFilterValue.Split(",")(1), True))
                            Else
                                table.sFilter = String.Format("{0} AND {1} BETWEEN {2} AND {3}", table.sFilter, sPropertyValue, GetString(sFilterValue.Split(",")(0), True), GetString(sFilterValue.Split(",")(1), True))
                            End If
                        Else
                            sInfobar = GetMessageProvider.GetMessage("E=InvalidReference", "sFilter", sPropertyName, "sIDO", sIDO, sFilterValue)
                            SyncSettings.ValidationMessage = sInfobar
                            Continue For
                        End If

                    ElseIf String.IsNullOrEmpty(sFilterValue) OrElse sFilterValue = "null" Then
                        If sFilterOperator = "=" Then
                            If String.IsNullOrEmpty(table.sFilter) Then
                                table.sFilter = String.Format("{0} IS NULL", sPropertyValue)
                            Else
                                table.sFilter = String.Format("{0} AND {1} IS NULL", table.sFilter, sPropertyValue)
                            End If
                        ElseIf sFilterOperator = "<>" Then
                            If String.IsNullOrEmpty(table.sFilter) Then
                                table.sFilter = String.Format("{0} IS NOT NULL", sPropertyValue)
                            Else
                                table.sFilter = String.Format("{0} AND {1} IS NOT NULL", table.sFilter, sPropertyValue)
                            End If
                        Else
                            sInfobar = GetMessageProvider.GetMessage("E=InvalidReference", "sFilter", sPropertyName, "sIDO", sIDO, sFilterValue)
                            SyncSettings.ValidationMessage = sInfobar
                            Continue For
                        End If
                    Else
                        If String.IsNullOrEmpty(table.sFilter) Then
                            table.sFilter = String.Format("{0} {1} {2}", sPropertyValue, sFilterOperator, GetString(sFilterValue, True))
                        Else
                            table.sFilter = String.Format("{0} AND {1} {2} {3}", table.sFilter, sPropertyValue, sFilterOperator, GetString(sFilterValue, True))
                        End If
                    End If
                Next
            End Using
            Return True
        Catch ex As Exception
            sInfobar = ex.Message
            SyncSettings.ValidationMessage = sInfobar
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            If bValidateOnly Then
                Return True
            Else
                Return False
            End If

        End Try


    End Function
    Function QuoteList(ByVal list As String) As String
        Dim sb As New StringBuilder()
        For Each value In list.Split(",")
            If sb.Length = 0 Then
                sb.Append(GetString(value, True))
            Else
                sb.AppendFormat(",{0}", GetString(value, True))
            End If
        Next

        Return sb.ToString()
    End Function
    Private Sub GetCustomFields(sIDO As String, ByRef table As clsTableDataRS8416, ByRef appDB As ApplicationDB, ByRef sInfobar As String,
                                ByRef SyncSettings As ClsSyncSettings, ByRef mListForceShowTables As List(Of String), ByRef mDuplicateCustomFields As Dictionary(Of String, List(Of String)))
        Try
            Dim sSQL As String
            Dim row As DataRow
            Dim oParms As New List(Of SqlParameter)
            Dim sTableAlias As String
            Dim iJoinType As Integer
            Dim sJoinType As String
            Dim sJoinText As String
            Dim sTableName As String
            Dim sDataType As String
            Dim sPropertyValue As String
            Dim sPropertyName As String
            Dim sColumnName As String
            oParms.Add(New SqlParameter("@UserName", SyncSettings.Username))
            oParms.Add(New SqlParameter("@IdoName", sIDO))
            sSQL = GetMobileDeviceFieldSQL()
            sSQL = sSQL + " WHERE IDO = @IdoName AND UserName = @UserName"

            Using dt As DataTable = GetDatatable(sSQL, appDB, oParms, SyncSettings, sInfobar)
                If dt Is Nothing Then Return

                For Each row In dt.Rows
                    sTableAlias = GetString(row("TableAlias"))
                    sTableName = GetString(row("TableName"))
                    sJoinText = GetString(row("JoinText"))
                    iJoinType = GetInteger(row("JoinType"))
                    sPropertyValue = GetString(row("PropertyValue"))
                    sPropertyName = GetString(row("Property"))
                    sColumnName = GetString(row("ColumnName"))
                    If sColumnName = "" Then
                        sColumnName = sPropertyName
                    End If
                    'we need to skip adding this a second time and exclude from sending the value down
                    If table.fields.ContainsKey(sPropertyName) Then
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Skipping Custom Property: {0} for IDO: {1}. This property is included in standard product already.", sPropertyName, sIDO))
                        If mListForceShowTables.Contains(sIDO) Then Continue For 'don't add a second time but go ahead and allow the user field to go down so it can be shown.

                        If mDuplicateCustomFields.ContainsKey(sIDO) Then
                            If Not mDuplicateCustomFields(sIDO).Contains(sPropertyName) Then
                                mDuplicateCustomFields(sIDO).Add(sPropertyName)
                            End If
                        Else
                            mDuplicateCustomFields.Add(sIDO, New List(Of String)() From {sPropertyName})
                        End If
                        Continue For
                    End If

                    If sTableAlias <> "" AndAlso sTableName <> "" AndAlso sJoinText <> "" AndAlso iJoinType <> 0 Then
                        If Not table.Joins.ContainsKey(sTableAlias) Then
                            If iJoinType = 0 Then
                                sJoinType = "INNER JOIN"
                            Else
                                sJoinType = "LEFT OUTER JOIN"
                            End If

                            table.Joins.Add(sTableAlias, String.Format("{0} {1} {2} ON {3}", sJoinType, SQLQuoted(sTableName), SQLQuoted(sTableAlias), sJoinText))
                        End If
                    End If
                    sDataType = GetString(row("DataType"))
                    If sDataType = "" Then
                        Continue For 'invalid datatype so ignore
                    ElseIf sDataType = "GUID" Then
                        sDataType = "uniqueidentifier"
                    ElseIf sDataType = "Decimal" Then
                        sDataType = String.Format("decimal({0},{1})", GetInteger(row("MaxLength")), GetInteger(row("Precision")))
                    ElseIf sDataType = "Short Integer" Then
                        sDataType = "smallint"
                    ElseIf sDataType = "Binary" Then
                        sDataType = "varbinary(max)"
                        If Not SyncSettings.IncludeImages Then
                            Continue For 'user doesn't want to see images
                        End If
                    ElseIf sDataType = "Byte" Then
                        sDataType = "tinyint"
                    ElseIf sDataType = "Date" Then
                        sDataType = "datetime"
                    ElseIf sDataType = "String" Or sDataType = "NumSortedString" Then
                        sDataType = String.Format("nvarchar({0})", GetInteger(row("MaxLength")))
                    ElseIf sDataType = "Long Integer" Then
                        sDataType = "Int"
                    End If

                    If sPropertyValue <> "" Then
                        sPropertyValue = SubstituteDerivedValues(sPropertyValue, sIDO, table, appDB, sInfobar, SyncSettings)

                        sPropertyValue = sPropertyValue + " AS " + sPropertyName
                    ElseIf sTableAlias <> "" Then
                        sPropertyValue = SQLQuoted(sTableAlias) + "." + SQLQuoted(sColumnName) + " AS " + sPropertyName
                        sColumnName = sPropertyName  'if using multiple table set field to the property value to be unique.
                    End If

                    table.fields.Add(sPropertyName, New clsFieldDataRS8416(sColumnName, sPropertyName, sPropertyValue, sDataType))
                Next
            End Using
        Catch ex As Exception
            sInfobar = ex.Message
            SyncSettings.ValidationMessage = sInfobar
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
        End Try


    End Sub

    Private Function SubstituteDerivedValues(sPropertyValue As String, sIDO As String, ByRef table As clsTableDataRS8416, ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings) As String
        Try
            Dim sSQL As String
            Dim oParms As New List(Of SqlParameter) From {
                New SqlParameter("@IdoName", sIDO)
            }
            sSQL = "select PropertyName,ColumnName,ColumnTableAlias,TableName,PropertyValue,JoinType,JoinText from ido.properties p LEFT OUTER JOIN ido.tables t ON p.collectionname = t.collectionname AND p.columntablealias = t.tablealias AND t.DevelopmentFlag=0 where p.CollectionName = @IdoName AND p.PropertyType < 3 AND p.DevelopmentFlag=0"

            Using dt As DataTable = GetDatatable(sSQL, appDB, oParms, SyncSettings, sInfobar)
                If dt Is Nothing Then Return sPropertyValue

                Return SubstituteDerivedValuesInternal(sPropertyValue, dt, table, sInfobar, SyncSettings)
            End Using
        Catch ex As Exception
            sInfobar = ex.Message
            SyncSettings.ValidationMessage = sInfobar
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            Return sPropertyValue
        End Try


    End Function
    Private Function SubstituteDerivedValuesInternal(sPropertyValue As String, dt As DataTable, ByRef table As clsTableDataRS8416, ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings) As String
        Try
            Dim row As DataRow
            Dim oParms As New List(Of SqlParameter)
            Dim sTableAlias As String
            Dim iJoinType As Integer
            Dim sJoinType As String
            Dim sJoinText As String
            Dim sTableName As String
            Dim sColumnName As String
            Dim sPropertyName As String
            Dim sPropertySubValue As String
            Dim sPattern As String
            Dim reg As Regex
            For Each row In dt.Rows
                sTableAlias = GetString(row("ColumnTableAlias"))
                sTableName = GetString(row("TableName"))
                sJoinText = GetString(row("JoinText"))
                iJoinType = GetInteger(row("JoinType"))
                sPropertySubValue = GetString(row("PropertyValue"))
                sColumnName = GetString(row("ColumnName"))
                sPropertyName = GetString(row("PropertyName"))

                ' if the sub value is the value we are currently working on skip to avoid infinite recursion
                If sPropertyValue = sPropertySubValue Then
                    Continue For
                End If
                sPattern = "\b(?<=[^'])" + sPropertyName + "\b(?=[^'])"
                'check if property is in derivation
                'will need regex
                reg = New Regex(sPattern)
                If reg.IsMatch(sPropertyValue) Then

                    'recursive substitute
                    If sPropertySubValue <> "" Then
                        sPropertySubValue = SubstituteDerivedValuesInternal(sPropertySubValue, dt, table, sInfobar, SyncSettings)
                        sPropertyValue = reg.Replace(sPropertyValue, sPropertySubValue)
                    Else
                        sPropertyValue = reg.Replace(sPropertyValue, String.Format("[{0}].[{1}]", sTableAlias, sColumnName))
                    End If

                    If sTableAlias <> "" AndAlso sTableName <> "" AndAlso sJoinText <> "" AndAlso iJoinType <> 0 Then
                        If Not table.Joins.ContainsKey(sTableAlias) Then
                            If iJoinType = 0 Then
                                sJoinType = "INNER JOIN"
                            Else
                                sJoinType = "LEFT OUTER JOIN"
                            End If

                            table.Joins.Add(sTableAlias, String.Format("{0} {1} {2} {3}", sJoinType, SQLQuoted(sTableName), SQLQuoted(sTableAlias), sJoinText))
                        End If
                    End If
                End If

            Next
            Return sPropertyValue

        Catch ex As Exception
            sInfobar = ex.Message
            SyncSettings.ValidationMessage = sInfobar
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            Return sPropertyValue
        End Try


    End Function

    Public Function SaveDeviceData(ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef tblData As clsTableDataRS8416,
                                   ByRef SyncSettings As ClsSyncSettings,
                                   ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataSame As Generic.Dictionary(Of String, String)) As Boolean
        SaveDeviceData = False
        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Save Device Data for table: {0}", tblData.sTableName))
        ' Remove Records from both Local Cache and Client Device that should no longer be on the device
        For Each sKey As String In mDeviceDataOld.Keys
            If Not mDeviceDataSame.ContainsKey(sKey) _
                And Not mDeviceDataUpd.ContainsKey(sKey) Then

                ' Tell Client to remove the files
                Dim outRow As DataRow
                outRow = tblData.outTable.NewRow
                outRow("ToRemove") = "True"
                outRow("RowPointer") = sKey
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Removing Record {0} for Table: {1}", sKey, tblData.sTableName))
                tblData.outTable.Rows.Add(outRow)
            End If
        Next

        ' Now, serialize it and store it!
        Dim sbXML As New System.Text.StringBuilder
        Dim stringwriter As New System.IO.StringWriter(sbXML)
        Dim xmlwriter As New IMobileXMLWriter(stringwriter)
        Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces
        ns.Add("", "")

        Dim tablesequence As Integer = 1
        Dim count As Integer = 1
        xmlwriter.WriteStartElement("Data")
        ' In order to save it in the database, we want to consolidate all the table records into one collection
        ' and then store the serialized collection in the database.
        For Each oData In mDeviceDataNew.Values
            If Not mDeviceDataSame.ContainsKey(oData) Then
                If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
            End If
        Next

        For Each oData In mDeviceDataUpd.Values
            If Not mDeviceDataSame.ContainsKey(oData) Then
                If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
            End If
        Next

        For Each oData In mDeviceDataSame.Values
            If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
        Next

        'if this is just the open element <Data> there is nothing more to write.
        If sbXML.Length > 6 Then
            xmlwriter.WriteEndElement() '/Data
            If Not WriteData(appDB, tblData.sTableName, sbXML.ToString, tablesequence, sInfobar, SyncSettings) Then Return False
        End If
        Return True
    End Function
    Private Function WriteElement(ByRef xmlwriter As IMobileXMLWriter, ByRef count As Integer, ByRef tablesequence As Integer, ByRef sbXML As StringBuilder _
                             , ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef oData As String, ByRef tblData As clsTableDataRS8416, ByRef SyncSettings As ClsSyncSettings) As Boolean
        xmlwriter.WriteStartElement("I")
        xmlwriter.WriteAttributeString("P", oData)
        xmlwriter.WriteEndElement() '/I
        count = count + 1
        If count > 199 Then
            xmlwriter.WriteEndElement() '/Data
            If Not WriteData(appDB, tblData.sTableName, sbXML.ToString, tablesequence, sInfobar, SyncSettings) Then Return False
            count = 1
            tablesequence = tablesequence + 1
            sbXML.Clear()
            xmlwriter.WriteStartElement("Data")
        End If
        Return True
    End Function

#End Region

    Private Function SetupTempTables(ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                        ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider) As Boolean
        SetupTempTables = False
        Try

            Dim Parms As List(Of SqlParameter)
            Dim sFilter As String
            Dim oTables As Dictionary(Of String, clsFieldData()) = New Dictionary(Of String, clsFieldData())()
            Dim oObjectNotesCache As DataTable = Nothing
            Dim oObjectDocumentsCache As DataTable = Nothing

            Using table = New clsTableData("fs_parms", "FSParms", "prm", False, False, Nothing)
                table.fields.Add(New clsFieldData("matl_trans_type", "MatlTransType"))
                table.fields.Add(New clsFieldData("default_labor_rate", "DefaultLaborRate"))
                table.fields.Add(New clsFieldData("default_labor_cost", "DefaultLaborCost"))
                table.fields.Add(New clsFieldData("bill_type", "BillType"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode"))
                table.fields.Add(New clsFieldData("whse", "Whse"))
                table.fields.Add(New clsFieldData("stat_code", "StatCode"))
                table.fields.Add(New clsFieldData("prior_code", "PriorCode"))
                table.fields.Add(New clsFieldData("op_stat", "OpStat"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, True, SyncSettings, FormatProvider) Then Return False
            End Using

            Using table = New clsTableData("u_m", "SLUMs", "um", False, False, Nothing)
                table.fields.Add(New clsFieldData("u_m", "UM"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("reason", "SLReasons", "rea", False, False, "reason_class = N'CO RETURN'")
                table.fields.Add(New clsFieldData("reason_class", "ReasonClass"))
                table.fields.Add(New clsFieldData("reason_code", "ReasonCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("site", "SLSites", "sit", False, False, Nothing)
                table.fields.Add(New clsFieldData("site", "Site", "site.site"))
                table.fields.Add(New clsFieldData("site_name", "SiteName", "site.site_name"))
                table.fields.Add(New clsFieldData("time_zone", "TimeZone", "site.time_zone"))
                table.fields.Add(New clsFieldData("system_type", "SystemType", "site.system_type"))
                table.joins.Add("INNER JOIN parms prm ON prm.site = site.site")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_unit_stat_code", "FSUnitStatCodes", "usc", False, False, Nothing)
                table.fields.Add(New clsFieldData("unit_stat_code", "UnitStatCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                table.fields.Add(New clsFieldData("Down", "Down"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_stat_code", "FSStatCodes", "sta", False, False, Nothing)
                table.fields.Add(New clsFieldData("stat_code", "StatCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                table.fields.Add(New clsFieldData("Closed", "Closed"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_prior_code", "FSPriorCodes", "pri", False, False, Nothing)
                table.fields.Add(New clsFieldData("prior_code", "PriorCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_pay_type", "FSPayTypes", "pay", False, False, Nothing)
                table.fields.Add(New clsFieldData("fs_pay_type", "FsPayType"))
                table.fields.Add(New clsFieldData("pay_desc", "PayDesc"))
                table.fields.Add(New clsFieldData("reimb_partner", "ReimbPartner"))
                table.fields.Add(New clsFieldData("vend_num", "VendNum"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_misc_code", "FSMiscCodes", "MiscCode", False, False, Nothing)
                table.fields.Add(New clsFieldData("misc_code", "MiscCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                table.fields.Add(New clsFieldData("price", "Price"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_work_code", "FSWorkCodes", "WorkCode", False, False, Nothing)
                table.fields.Add(New clsFieldData("work_code", "WorkCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                table.fields.Add(New clsFieldData("Cost", "Cost"))
                table.fields.Add(New clsFieldData("cost_code", "CostCode"))
                table.fields.Add(New clsFieldData("Rate", "Rate"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_oper_code", "FSOperCodes", "opcd", False, False, Nothing)
                table.fields.Add(New clsFieldData("oper_code", "OperCode"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_res_spec", "FSResolutionSpecs", "reas", False, False, Nothing)
                table.fields.Add(New clsFieldData("res_code_gen", "ResCodeGen"))
                table.fields.Add(New clsFieldData("res_code_spec", "ResCodeSpec"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_res_gen", "FSResolutions", "reas", False, False, Nothing)
                table.fields.Add(New clsFieldData("res_code_gen", "ResCodeGen"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_reas_spec", "FSReasonSpecs", "reas", False, False, Nothing)
                table.fields.Add(New clsFieldData("reason_gen", "ReasonGen"))
                table.fields.Add(New clsFieldData("reason_spec", "ReasonSpec"))
                table.fields.Add(New clsFieldData("description", "Description"))
                table.fields.Add(New clsFieldData("duration", "Duration"))
                table.fields.Add(New clsFieldData("duration_units", "DurationUnits"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_reas_gen", "FSReasons", "reas", False, False, Nothing)
                table.fields.Add(New clsFieldData("reason_gen", "ReasonGen"))
                table.fields.Add(New clsFieldData("description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_meas_type_resp", "FSMeasTypeResps", "meastyprsp", False, False, Nothing)
                table.fields.Add(New clsFieldData("meas_type", "MeasType"))
                table.fields.Add(New clsFieldData("Response", "Response"))
                table.fields.Add(New clsFieldData("Failure", "Failure"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("DocumentType", "DocumentTypes", "doc", False, False, "StorageMethod = 'D'")
                table.fields.Add(New clsFieldData("DocumentType", "DocumentType"))
                table.fields.Add(New clsFieldData("Description", "Description"))
                table.fields.Add(New clsFieldData("DocumentExtension", "DocumentExtension"))
                table.fields.Add(New clsFieldData("StorageMethod", "StorageMethod"))
                table.fields.Add(New clsFieldData("MediaType", "MediaType"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("cci_system", "CCISystems", "cci", False, False, "active=1")
                table.fields.Add(New clsFieldData("card_system_id", "CardSystemId"))
                table.fields.Add(New clsFieldData("card_system", "CardSystem"))
                table.fields.Add(New clsFieldData("payment_server", "PaymentServer"))
                table.fields.Add(New clsFieldData("gateway_user_id", "GatewayUserId"))
                table.fields.Add(New clsFieldData("gateway_password", "GatewayPassword"))
                table.fields.Add(New clsFieldData("gateway_vend_id", "GatewayVendId"))
                table.fields.Add(New clsFieldData("bank_code", "BankCode"))
                table.fields.Add(New clsFieldData("curr_code", "CurrCode"))
                table.fields.Add(New clsFieldData("Active", "Active"))
                table.fields.Add(New clsFieldData("default_for_curr_code", "DefaultForCurrCode"))

                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("cci_parms", "CCIParms", "cci", False, False, Nothing)
                table.fields.Add(New clsFieldData("parm_key", "ParmKey"))
                table.fields.Add(New clsFieldData("auth_type", "AuthType"))
                table.fields.Add(New clsFieldData("auth_amount", "AuthAmount"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("invparms", "SLInvparms", "inv", False, False, Nothing)
                table.fields.Add(New clsFieldData("parm_key", "ParmKey"))
                table.fields.Add(New clsFieldData("serial_length", "SerialLength"))
                table.fields.Add(New clsFieldData("NumPad", "NumPad", "dbo.GetNumSortCharNumericPad() AS NumPad"))
                table.fields.Add(New clsFieldData("LeftPad", "LeftPad", "dbo.GetNumSortCharLeftPad() AS LeftPad "))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_inspect_type", "FSInspectTypes", "intype", False, False, Nothing)
                table.fields.Add(New clsFieldData("inspect_type", "InspectType"))
                table.fields.Add(New clsFieldData("Description", "Description"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_appt_stat", "FSApptStats", "appt", False, False, Nothing)
                table.fields.Add(New clsFieldData("appt_stat", "ApptStat"))
                table.fields.Add(New clsFieldData("Description", "Description"))
                table.fields.Add(New clsFieldData("Closed", "Closed"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableData("customer", "SLCustomers", "cus", False, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("cust_num", "CustNum", "customer.cust_num", "NVARCHAR(7)", bKeyField:=True))
                table.fields.Add(New clsFieldData("cust_seq", "CustSeq", "customer.cust_seq", "INT", bKeyField:=True))
                If SyncSettings.IncludeImages Then
                    table.fields.Add(New clsFieldData("picture", "Picture", "customer.picture", "VARBINARY(MAX)"))
                End If
                table.fields.Add(New clsFieldData("name", "Name", "addr.name", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("addr##1", "Addr_1", "addr.addr##1", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("addr##2", "Addr_2", "addr.addr##2", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("addr##3", "Addr_3", "addr.addr##3", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("addr##4", "Addr_4", "addr.addr##4", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("city", "City", "addr.city", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("state", "State", "addr.state", "NVARCHAR(5)"))
                table.fields.Add(New clsFieldData("zip", "Zip", "addr.zip", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("Contact_1", "Contact_1", "CASE WHEN customer.cust_seq = 0 THEN customer.contact##1 ELSE billto.contact##1 END AS Contact_1", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("Phone_1", "Phone_1", "CASE WHEN customer.cust_seq = 0 THEN customer.phone##1 ELSE billto.phone##1 END AS Phone_1", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("fax_num", "FaxNum", "addr.fax_num", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("ExternalEmailAddr", "ExternalEmailAddr", "CASE WHEN customer.cust_seq = 0 THEN addr.external_email_addr ELSE billtoaddr.external_email_addr END AS ExternalEmailAddr", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("contact##2", "Contact_2", "customer.contact##2", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("phone##2", "Phone_2", "customer.phone##2", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("ship_to_email", "ShipToEmail", "addr.ship_to_email", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("Contact_3", "Contact_3", "CASE WHEN customer.cust_seq = 0 THEN customer.contact##3 ELSE billto.contact##3 END AS Contact_3", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("Phone_3", "Phone_3", "CASE WHEN customer.cust_seq = 0 THEN customer.phone##3 ELSE billto.phone##3 END AS Phone_3", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("bill_to_email", "BillToEmail", "addr.bill_to_email", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("country", "Country", "addr.country", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("county", "County", "addr.county", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fscust.partner_id", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("region", "Region", "fscust.region", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("curr_code", "CurrCode", "addr.curr_code", "NVARCHAR(3)"))
                table.fields.Add(New clsFieldData("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,addr.RecordDate,121) AS AddrRecordDate", "DateTime", True))
                table.fields.Add(New clsFieldData("FSRecordDate", "FSRecordDate", "CONVERT(NVARCHAR,fscust.RecordDate,121) AS FSRecordDate", "DateTime", True))
                table.fields.Add(New clsFieldData("BillToRecordDate", "BillToRecordDate", "CONVERT(NVARCHAR,billto.RecordDate,121) AS BillToRecordDate", "DateTime", True))
                table.joins.Add("INNER JOIN custaddr addr ON customer.cust_num = addr.cust_num AND customer.cust_seq = addr.cust_seq")
                table.joins.Add("INNER JOIN fs_customer fscust ON customer.cust_num = fscust.cust_num AND customer.cust_seq = fscust.cust_seq")
                table.joins.Add("INNER JOIN customer billto ON customer.cust_num = billto.cust_num AND billto.cust_seq = 0")
                table.joins.Add("INNER JOIN custaddr billtoaddr ON customer.cust_num = billtoaddr.cust_num AND billtoaddr.cust_seq = 0")

                'Assigned to Work
                If SyncSettings.CustomerFilter = 1 Then
                    table.joins.Add("INNER JOIN 
                             (
	                           SELECT 
                                 inc.cust_num AS CustNum
	                           , inc.cust_seq AS CustSeq
                               FROM fs_incident inc 
                               INNER JOIN fs_schedule sched ON sched.ref_type = 'N' AND sched.ref_num = inc.inc_num
                               WHERE sched.complete = 0
                               AND sched.partner_id = @PartnerId 
                               UNION
                               SELECT
                                 sro.cust_num AS CustNum
                               , sro.cust_seq AS CustSeq
                               FROM fs_sro sro 
                               INNER JOIN fs_schedule sched ON sched.ref_type = 'S' AND sched.ref_num = sro.sro_num
                               WHERE sched.complete = 0
                               AND sched.partner_id = @PartnerId
                               UNION
                               SELECT
                                 sro.cust_num AS CustNum
                               , sro.cust_seq AS CustSeq
                               FROM fs_sro sro 
                               WHERE sro.partner_id = @PartnerId
                               AND sro_stat IN ('O','E')
                               UNION
                               SELECT
                                 inc.cust_num AS CustNum
                               , inc.cust_seq AS CustSeq
                               FROM fs_incident inc 
                               INNER JOIN fs_stat_code stat ON inc.stat_code = stat.stat_code
                               WHERE inc.[owner] = @PartnerId
                               AND stat.closed = 0
                              ) work_queue ON work_queue.CustNum = customer.cust_num AND work_queue.CustSeq = customer.cust_seq")
                ElseIf SyncSettings.CustomerFilter = 2 Then 'Assigned to Partner
                    table.sFilter = "fscust.partner_id = @PartnerId"
                ElseIf SyncSettings.CustomerFilter = 3 Then 'Partner Area
                    table.joins.Add("INNER JOIN fs_partner_area area ON (area.region = fscust.region OR area.region IS NULL)
                              AND (area.city = addr.city OR area.city IS NULL)
                              AND (area.[state] = addr.[state] OR area.[state] IS NULL)
                              AND (area.county = addr.county OR area.county IS NULL)
                              AND (area.country = addr.country OR area.country IS NULL)
                              AND (area.zip = addr.zip OR area.zip IS NULL)")

                    table.sFilter = "area.partner_id = @PartnerId"
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray())
            End Using
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, "Post Customer")
            Parms = New List(Of SqlParameter) From {
                New SqlParameter("@PartnerWhse", SyncSettings.PartnerWhse),
                New SqlParameter("@IncludeSlowMoving", SQLBoolean(SyncSettings.IncludeSlowMoving)),
                New SqlParameter("@IncludeObsolete", SQLBoolean(SyncSettings.IncludeObsolete))
            }
            sFilter = "(item.stat = 'A' OR (item.stat = 'S' AND @IncludeSlowMoving = 1) OR (item.stat = 'O' AND @IncludeObsolete = 1))"
            Using table = New clsTableData("item", "SLItems", "itm", False, False, sFilter, Parms, TempTable:="#MobileItems", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("item", "Item", "item.item", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add(New clsFieldData("Description", "Description", "item.description", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("u_m", "UM", "item.u_m", "NVARCHAR(3)"))
                table.fields.Add(New clsFieldData("lot_tracked", "LotTracked", "item.lot_tracked", "tinyint"))
                table.fields.Add(New clsFieldData("serial_tracked", "SerialTracked", "item.serial_tracked", "tinyint"))
                table.fields.Add(New clsFieldData("stat", "Stat", "item.stat", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("QtyOnHand", "DerQtyOnHand", "iwqv.QtyOnHand", "decimal(20,8)"))
                table.fields.Add(New clsFieldData("QtyTrans", "DerQtyTrans", "iwqv.QtyTrans", "decimal(20,8)"))
                table.fields.Add(New clsFieldData("QtyAllocCo", "DerQtyAllocCo", "iwqv.QtyAllocCo", "decimal(20,8)"))
                table.fields.Add(New clsFieldData("QtyAllocTrn", "DerQtyAllowTrn", "iwqv.QtyAllocTrn", "decimal(20,8)"))
                table.fields.Add(New clsFieldData("qty_AllocJob", "QtyAllocJob", "item.qty_Allocjob", "decimal(20,8)"))
                table.fields.Add(New clsFieldData("DerQtyAvail", "DerQtyAvail", "((iwqv.QtyOnHand - iwqv.QtyTrans) - (iwqv.QtyAllocCo + iwqv.QtyAllocTrn + item.qty_allocjob)) AS DerQtyAvail", "decimal(20,8)"))
                table.joins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON item.item = iwqv.item")

                If SyncSettings.ItemFilter = 1 Then 'Partner Whse
                    table.joins.Add("INNER JOIN itemwhse iw ON item.item = iw.item")
                    table.sFilter = "iw.whse = @PartnerWhse
                             AND   (item.stat = 'A'
                                    OR (item.stat = 'S' AND @IncludeSlowMoving = 1)
                                    OR (item.stat = 'O' AND @IncludeObsolete = 1))"
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray())
            End Using
            Parms = New List(Of SqlParameter) From {New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableData("fs_unit", "FSUnits", "unt", True, True, Nothing, Parms, TempTable:="#MobileUnits", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("ser_num", "SerNum", "fs_unit.ser_num", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add(New clsFieldData("item", "Item", "fs_unit.item", "NVARCHAR(30)", bKeyField:=True))
                table.fields.Add(New clsFieldData("description", "Description", "fs_unit.description", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("cust_num", "CustNum", "fs_unit.cust_num", "NVARCHAR(7)"))
                table.fields.Add(New clsFieldData("cust_seq", "CustSeq", "fs_unit.cust_seq", "int"))
                table.fields.Add(New clsFieldData("BillToName", "BillToName", "baddr.name AS BillToName", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("ShipToName", "ShipToName", "saddr.name AS ShipToName", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("unit_stat_code", "UnitStatCode", "", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("srv_dealer", "SrvDealer", "", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("comp_id", "CompId", "", "int"))
                table.fields.Add(New clsFieldData("last_meter_amt", "LastMeterAmt", "", "int"))
                table.fields.Add(New clsFieldData("last_meter_date", "LastMeterDate", "", "datetime"))
                table.fields.Add(New clsFieldData("install_date", "InstallDate", "", "datetime"))
                table.fields.Add(New clsFieldData("last_ins_date", "LastInsDate", "", "datetime"))
                table.fields.Add(New clsFieldData("next_ins_date", "NextInsDate", "", "datetime"))
                table.fields.Add(New clsFieldData("last_calib_date", "LastCalibDate", "", "datetime"))
                table.fields.Add(New clsFieldData("next_calib_date", "NextCalibDate", "", "datetime"))
                table.fields.Add(New clsFieldData("last_pm_date", "LastPmDate", "", "datetime"))
                table.fields.Add(New clsFieldData("next_pm_date", "NextPmDate", "", "datetime"))
                If SyncSettings.IncludeImages Then
                    table.fields.Add(New clsFieldData("DerPrimaryPicture", "DerPrimaryPicture", "itm.picture AS DerPrimaryPicture", "varbinary(max)"))
                End If
                table.fields.Add(New clsFieldData("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,itm.RecordDate,121) AS ItemRecordDate", "datetime", True))
                table.fields.Add(New clsFieldData("SAddrRecordDate", "SAddrRecordDate", "CONVERT(NVARCHAR,saddr.RecordDate,121) AS SAddrRecordDate", "datetime", True))
                table.fields.Add(New clsFieldData("BAddrRecordDate", "BAddrRecordDate", "CONVERT(NVARCHAR,baddr.RecordDate,121) AS BAddrRecordDate", "datetime", True))
                table.joins.Add("LEFT OUTER JOIN item itm ON itm.item = fs_unit.item")
                table.joins.Add("LEFT OUTER JOIN custaddr baddr ON fs_unit.cust_num = baddr.cust_num AND baddr.cust_seq = 0")
                table.joins.Add("LEFT OUTER JOIN custaddr saddr ON fs_unit.cust_num = saddr.cust_num AND fs_unit.cust_seq = saddr.cust_seq")
                If SyncSettings.UnitFilter = 1 Then 'Assigned to Work
                    table.joins.Add("INNER JOIN (
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN fs_schedule sched ON sched.ref_type = 'S' AND sched.ref_num = line.sro_num
                             WHERE sched.complete = 0 AND sched.partner_id = @PartnerId
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc 
                             INNER JOIN fs_schedule sched ON sched.ref_type = 'N' AND sched.ref_num = inc.inc_num
                             WHERE sched.complete = 0 AND sched.partner_id = @PartnerId 
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc
                             INNER JOIN fs_stat_code stat ON inc.stat_code = stat.stat_code
                             WHERE stat.closed = 0 AND inc.owner = @PartnerId 
                             UNION
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN fs_sro sro ON sro.sro_num = line.sro_num
                             WHERE sro.sro_stat IN ('O','E') AND sro.partner_id = @PartnerId 
                             ) queue ON fs_unit.ser_num = queue.ser_num AND fs_unit.item = queue.item")
                ElseIf SyncSettings.UnitFilter = 2 Then 'Assigned to Customer
                    table.joins.Add("INNER JOIN #mobilecustomers cust ON fs_unit.cust_num = cust.cust_num")
                ElseIf SyncSettings.UnitFilter = 3 Then 'Assigned to Partner
                    table.sFilter = "fs_unit.srv_dealer = @PartnerId"
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray())
            End Using
            Using table = New clsTableData("fs_partner", "FSPartners", "part", True, False, "active=1")
                table.fields.Add(New clsFieldData("partner_id", "PartnerId"))
                table.fields.Add(New clsFieldData("name", "Name", "fs_partner.name"))
                table.fields.Add(New clsFieldData("email", "Email"))
                table.fields.Add(New clsFieldData("DerPhone", "DerPhone", "COALESCE(emp.Phone,cust.Phone##1,Vend.Phone) AS DerPhone"))
                If SyncSettings.IncludeImages Then
                    table.fields.Add(New clsFieldData("DerPrimaryPicture", "DerPrimaryPicture", "COALESCE(emp.Picture,cust.picture,Vend.picture) AS DerPrimaryPicture"))
                End If
                table.fields.Add(New clsFieldData("username", "UserName", "fs_partner.username"))
                table.fields.Add(New clsFieldData("rate", "Rate"))
                table.fields.Add(New clsFieldData("cost", "Cost"))
                table.fields.Add(New clsFieldData("dept", "Dept", "fs_partner.dept"))
                table.fields.Add(New clsFieldData("misc_code", "MiscCode"))
                table.fields.Add(New clsFieldData("work_code", "WorkCode"))
                table.fields.Add(New clsFieldData("whse", "Whse", "fs_partner.whse"))
                table.fields.Add(New clsFieldData("fs_pay_type", "FsPayType", "fs_partner.fs_pay_type"))
                table.fields.Add(New clsFieldData("gps_last_timestamp", "GpsLastTimestamp"))
                table.fields.Add(New clsFieldData("gps_last_longitude", "GpsLastLongitude"))
                table.fields.Add(New clsFieldData("gps_last_latitude", "GpsLastLatitude"))
                table.fields.Add(New clsFieldData("gps_polling_interval", "GPSPollingInterval"))
                table.fields.Add(New clsFieldData("Active", "Active"))
                table.fields.Add(New clsFieldData("reimb_matl", "ReimbMatl"))
                table.joins.Add("Left OUTER JOIN customer cust ON fs_partner.ref_type = 'C' AND fs_partner.ref_num = cust.cust_num AND fs_partner.ref_seq= cust.cust_seq")
                table.joins.Add("Left OUTER JOIN vendor vend ON fs_partner.ref_type = 'V' AND fs_partner.ref_num = vend.vend_num")
                table.joins.Add("Left OUTER JOIN Employee emp ON fs_partner.ref_type = 'E' AND fs_partner.ref_num = emp.emp_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            Using table = New clsTableData("fs_partner_area", "FSPartnerAreas", "FS", False, False, "partner_Id=@PartnerId", Parms)
                table.fields.Add(New clsFieldData("partner_id", "PartnerId"))
                table.fields.Add(New clsFieldData("region", "Region"))
                table.fields.Add(New clsFieldData("city", "City"))
                table.fields.Add(New clsFieldData("state", "State"))
                table.fields.Add(New clsFieldData("country", "Country"))
                table.fields.Add(New clsFieldData("county", "County"))
                table.fields.Add(New clsFieldData("zip", "Zip"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId),
            New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " CHARINDEX(SSSSchedView.RefTypeKey, N'SCN') > 0 AND SSSSchedView.PartnerId = @PartnerId  AND SSSSchedView.Complete = 0"
            Using table = New clsTableData("fs_schedule", "FSSchedules", "sched", False, False, sFilter, Parms, TableView:="SSSSchedView", TempTable:="#MobileSchedules", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("ApptStartDate", "SchedDate", "SSSSchedView.ApptStartDate", "datetime"))
                table.fields.Add(New clsFieldData("ApptLength", "Hrs", "SSSSchedView.ApptLength", "decimal(19,8)"))
                table.fields.Add(New clsFieldData("ApptStat", "ApptStat", "SSSSchedView.ApptStat", "NVARCHAR(15)"))
                table.fields.Add(New clsFieldData("Description", "Description", "SSSSchedView.Description", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("PartnerId", "PartnerId", "SSSSchedView.PartnerId", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("RefTypeKey", "RefType", "SSSSchedView.RefTypeKey", "NCHAR(1)", bKeyField:=True))
                table.fields.Add(New clsFieldData("RefNumKey", "RefNum", "SSSSchedView.RefNumKey", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add(New clsFieldData("RefLineKey", "RefLineSuf", "SSSSchedView.RefLineKey", "int"))
                table.fields.Add(New clsFieldData("RefReleaseKey", "RefRelease", "SSSSchedView.RefReleaseKey", "int"))
                table.fields.Add(New clsFieldData("CustName", "DerRefShpToName", "SSSSchedView.CustName", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("CustNum", "DerRefCustNum", "SSSSchedView.CustNum", "NVARCHAR(7)"))
                table.fields.Add(New clsFieldData("CustSeq", "DerRefCustSeq", "SSSSchedView.CustSeq", "int"))
                table.fields.Add(New clsFieldData("ShpToAddr##1", "DerLocAddr1", "SSSSchedView.ShpToAddr##1", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("ShpToCity", "DerLocCity", "SSSSchedView.ShpToCity", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("ShpToState", "DerLocState", "SSSSchedView.ShpToState", "NVARCHAR(5)"))
                table.fields.Add(New clsFieldData("ShpToZip", "DerLocZip", "SSSSchedView.ShpToZip", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("DerPhone", "DerPhone", "COALESCE(sro.Phone,inc.Phone) AS DerPhone", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("NotesSubject", "NotesSubject", "SSSSchedView.NotesSubject", "NVARCHAR(255)"))
                table.fields.Add(New clsFieldData("Notes", "Notes", "SSSSchedView.Notes", "NVARCHAR(MAX)"))
                table.fields.Add(New clsFieldData("Complete", "Complete", "SSSSchedView.Complete", "tinyint"))
                table.joins.Add("LEFT OUTER JOIN fs_incident inc ON SSSSchedView.RefNum = inc.inc_num AND SSSSchedView.RefTypeKey = 'N'")
                table.joins.Add("LEFT OUTER JOIN fs_sro sro ON SSSSchedView.RefNum = sro.sro_num AND SSSSchedView.RefTypeKey = 'S'")

                If SyncSettings.PastHistory > 0 Then
                    table.sFilter = " CHARINDEX(SSSSchedView.RefTypeKey, N'SCN') > 0 
                              AND SSSSchedView.PartnerId = @PartnerId  
                              AND (SSSSchedView.Complete = 0 
                                   OR (SSSSchedView.ApptStartDate >= @HistoryCutoff))"
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray())
            End Using

            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId),
            New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " fs_incident.owner = @PartnerId  AND stat.closed = 0"
            Using table = New clsTableData("fs_incident", "FSIncidents", "inc", True, True, sFilter, Parms, TempTable:="#MobileIncidents", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("ref_type", "RefType", "fs_incident.ref_type", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("ref_num", "RefNum", "fs_incident.ref_num", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("inc_num", "IncNum", "fs_incident.inc_num", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add(New clsFieldData("description", "Description", "fs_incident.description", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("stat_code", "StatCode", "fs_incident.stat_code", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("prior_code", "PriorCode", "fs_incident.prior_code", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("ser_num", "SerNum", "fs_incident.ser_num", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_incident.item", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("contact", "Contact", "fs_incident.contact", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("email", "Email", "fs_incident.email", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("phone", "Phone", "fs_incident.phone", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("ssr", "SSR", "fs_incident.ssr", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("site", "Site", "fs_incident.site", "NVARCHAR(8)"))
                table.fields.Add(New clsFieldData("owner", "Owner", "fs_incident.owner", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("work_site", "WorkSite", "fs_incident.work_site", "NVARCHAR(8)"))
                table.fields.Add(New clsFieldData("cust_num", "CustNum", "fs_incident.cust_num", "NVARCHAR(7)"))
                table.fields.Add(New clsFieldData("cust_seq", "CustSeq", "fs_incident.cust_seq", "int"))
                table.fields.Add(New clsFieldData("inc_date", "IncDate", "fs_incident.inc_date", "datetime"))
                table.fields.Add(New clsFieldData("close_date", "CloseDate", "fs_incident.close_date", "datetime"))
                table.fields.Add(New clsFieldData("duration", "Duration", "fs_incident.duration", "decimal(8,2)"))
                table.fields.Add(New clsFieldData("duration_units", "DurationUnits", "fs_incident.duration_units", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("u_m", "UM", "fs_incident.u_m", "NVARCHAR(3)"))
                table.fields.Add(New clsFieldData("closed", "DerClosed", "stat.closed", "tinyint"))
                table.fields.Add(New clsFieldData("matl_qty_conv", "MatlQtyConv", "fs_incident.matl_qty_conv", "decimal(19,8)"))
                table.fields.Add(New clsFieldData("ShpToName", "ShpToName", "addr.Name AS ShpToName", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("ShpToAddr1", "ShpToAddr1", "addr.addr##1 AS ShpToAddr1", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("ShpToCity", "ShpToCity", "addr.city AS ShpToCity", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("ShpToState", "ShpToState", "addr.state AS ShpToState", "NVARCHAR(5)"))
                table.fields.Add(New clsFieldData("ShpToZip", "ShpToZip", "addr.zip AS ShpToZip", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("ItemDesc", "ItemDesc", "COALESCE(unt.description,item.description,null) AS ItemDesc", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,addr.RecordDate,121) AS AddrRecordDate", "datetime", True))
                table.fields.Add(New clsFieldData("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,item.RecordDate,121) AS ItemRecordDate", "datetime", True))
                table.fields.Add(New clsFieldData("UnitRecordDate", "UnitRecordDate", "CONVERT(NVARCHAR,unt.RecordDate,121) AS UnitRecordDate", "datetime", True))
                table.joins.Add("INNER JOIN fs_stat_code stat On fs_incident.stat_code = stat.stat_code")
                table.joins.Add("Left OUTER JOIN fs_unit unt On fs_incident.ser_num = unt.ser_num And fs_incident.item = unt.item")
                table.joins.Add("Left OUTER JOIN custaddr addr On fs_incident.cust_num = addr.cust_num And fs_incident.cust_seq = addr.cust_seq")
                table.joins.Add("Left OUTER JOIN item On fs_incident.item = item.item")

                table.SecondaryJoins.Add("INNER JOIN #MobileSchedules sched ON sched.RefTypeKey = 'N' AND sched.RefNumKey = fs_incident.inc_num", "")

                If SyncSettings.PastHistory > 0 Then
                    table.sFilter = " fs_incident.owner = @PartnerId  AND (stat.closed = 0 Or (fs_incident.inc_date >= @HistoryCutoff))"
                    table.SecondaryJoins.Add("INNER JOIN #MobileCustomers cust ON cust.cust_num = fs_incident.cust_num AND cust.cust_seq = fs_incident.cust_seq", "fs_incident.inc_date >= @HistoryCutoff")
                    table.SecondaryJoins.Add("INNER JOIN #MobileUnits unit ON unit.ser_num = fs_incident.ser_num AND unit.item = fs_incident.item", "fs_incident.inc_date >= @HistoryCutoff")
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray())
            End Using
            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId),
            New SqlParameter("@HistoryCutoff", SyncSettings.HistoryCutoff)}
            sFilter = " fs_sro.partner_id = @PartnerId  AND fs_sro.sro_stat IN ('O','E')"

            Using table = New clsTableData("fs_sro", "FSSROs", "sro", True, True, sFilter, Parms, TempTable:="#MobileSROs", CreateTempTable:=True, DeferProcess:=True)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro.sro_num", "NVARCHAR(10)", bKeyField:=True))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro.description", "NVARCHAR(40)"))
                table.fields.Add(New clsFieldData("stat_code", "StatCode", "fs_sro.stat_code", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("prior_code", "PriorCode", "fs_sro.prior_code", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("contact", "Contact", "fs_sro.contact", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("email", "Email", "fs_sro.email", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("phone", "Phone", "fs_sro.phone", "NVARCHAR(25)"))
                table.fields.Add(New clsFieldData("cust_num", "CustNum", "fs_sro.cust_num", "NVARCHAR(7)"))
                table.fields.Add(New clsFieldData("cust_seq", "CustSeq", "fs_sro.cust_seq", "int"))
                table.fields.Add(New clsFieldData("open_date", "OpenDate", "fs_sro.open_date", "datetime"))
                table.fields.Add(New clsFieldData("close_date", "CloseDate", "fs_sro.close_date", "datetime"))
                table.fields.Add(New clsFieldData("bill_type", "BillType", "fs_sro.bill_type", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro.bill_code", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro.partner_id", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("product_code", "ProductCode", "fs_sro.product_code", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("sro_stat", "SroStat", "fs_sro.sro_stat", "NCHAR(1)"))
                table.fields.Add(New clsFieldData("ShpToName", "ShpToName", "addr.Name AS ShpToName", "NVARCHAR(60)"))
                table.fields.Add(New clsFieldData("ShpToAddr1", "ShpToAddr1", "addr.addr##1 AS ShpToAddr1", "NVARCHAR(50)"))
                table.fields.Add(New clsFieldData("ShpToCity", "ShpToCity", "addr.city AS ShpToCity", "NVARCHAR(30)"))
                table.fields.Add(New clsFieldData("ShpToState", "ShpToState", "addr.state AS ShpToState", "NVARCHAR(5)"))
                table.fields.Add(New clsFieldData("ShpToZip", "ShpToZip", "addr.zip AS ShpToZip", "NVARCHAR(10)"))
                table.fields.Add(New clsFieldData("AddrRecordDate", "AddrRecordDate", "CONVERT(NVARCHAR,addr.RecordDate,121) AS AddrRecordDate", "datetime", True))
                table.joins.Add("Left OUTER JOIN custaddr addr On fs_sro.cust_num = addr.cust_num And fs_sro.cust_seq = addr.cust_seq")

                table.SecondaryJoins.Add("INNER JOIN #MobileSchedules sched ON sched.RefTypeKey = 'S' AND sched.RefNumKey = fs_sro.sro_num", "")

                If SyncSettings.PastHistory > 0 Then

                    table.sFilter = " (fs_sro.partner_id = @PartnerId  AND fs_sro.sro_stat IN ('O','E'))  OR (fs_sro.open_date >= @HistoryCutoff AND fs_sro.sro_stat IN ('O','C','E'))"

                    table.SecondaryJoins.Add("INNER JOIN #MobileCustomers cust ON cust.cust_num = fs_sro.cust_num AND fs_sro.cust_seq = cust.cust_seq", "fs_sro.open_date >= @HistoryCutoff")
                    table.SecondaryJoins.Add("INNER JOIN fs_sro_line line ON fs_sro.sro_num = line.sro_num INNER JOIN #MobileUnits unit ON unit.ser_num = line.ser_num AND unit.item = line.item", "fs_sro.open_date >= @HistoryCutoff")
                End If
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                oTables.Add(table.sTableName, table.fields.ToArray)
            End Using
            If SyncSettings.CustomerFilter <> 0 Then
                Parms = New List(Of SqlParameter) From {
                New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
                Using table = New clsTableData("customer", "SLCustomers", "cus", False, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=False, DeferProcess:=True)
                    table.fields = oTables("customer").ToList
                    table.joins.Add("INNER JOIN custaddr addr ON customer.cust_num = addr.cust_num AND customer.cust_seq = addr.cust_seq")
                    table.joins.Add("INNER JOIN fs_customer fscust ON customer.cust_num = fscust.cust_num AND customer.cust_seq = fscust.cust_seq")
                    table.joins.Add("INNER JOIN customer billto ON customer.cust_num = billto.cust_num AND billto.cust_seq = 0")
                    table.joins.Add("INNER JOIN custaddr billtoaddr ON customer.cust_num = billtoaddr.cust_num AND billtoaddr.cust_seq = 0")
                    table.joins.Add("LEFT OUTER JOIN #MobileSROs SRO ON sro.cust_num = customer.cust_num AND sro.cust_seq = customer.cust_seq")
                    table.joins.Add("LEFT OUTER JOIN #MobileIncidents Inc ON Inc.cust_num = customer.cust_num AND inc.cust_seq = customer.cust_seq")
                    table.sFilter = "(sro.rowpointer IS NOT NULL OR inc.RowPointer IS NOT NULL)"

                    If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                End Using
            End If


            Parms = New List(Of SqlParameter) From {
            New SqlParameter("@PartnerId", SyncSettings.PartnerId)}
            sFilter = " stm.active = 1 And trn.success = 1"
            Using table = New clsTableData("cci_card", "CCICards", "cci", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("card_system_id", "CardSystemId", "cci_card.card_system_id "))
                table.fields.Add(New clsFieldData("card_system", "CardSystem", "cci_card.card_system "))
                table.fields.Add(New clsFieldData("cust_num", "CustNum", "cci_card.cust_num"))
                table.fields.Add(New clsFieldData("cust_seq", "CustSeq", "cci_card.cust_seq"))
                table.fields.Add(New clsFieldData("card_num", "CardNum", "cci_card.card_num"))
                table.fields.Add(New clsFieldData("exp_date", "ExpDate", "cci_card.exp_date"))
                table.fields.Add(New clsFieldData("last_stored_gateway_trans_num", "LastStoredGatewayTransNum", "cci_card.last_stored_gateway_trans_num"))
                table.fields.Add(New clsFieldData("gateway_stored_token", "GatewayStoredToken", "trn.gateway_stored_token"))
                table.fields.Add(New clsFieldData("card_type", "CardType", "cci_card.card_type"))
                table.fields.Add(New clsFieldData("StmRecordDate", "StmRecordDate", "CONVERT(NVARCHAR,stm.RecordDate,121) As StmRecordDate", bDate:=True))
                table.joins.Add("INNER JOIN cci_trans trn On cci_card.last_stored_gateway_trans_num = trn.gateway_trans_num And cci_card.card_system_id = trn.card_system_id")
                table.joins.Add("INNER JOIN cci_system stm On stm.card_system_id = cci_card.card_system_id")
                table.joins.Add(" INNER JOIN #MobileCustomers cust On cci_card.cust_num = cust.cust_num And cci_card.cust_seq = cust.cust_seq")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_inc_reason", "FSIncReasons", "increas", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("reason_gen", "Reason", "fs_inc_reason.reason_gen"))
                table.fields.Add(New clsFieldData("reason_spec", "ReasonSpec", "fs_inc_reason.reason_spec"))
                table.fields.Add(New clsFieldData("reason_notes", "ReasonNotes", "fs_inc_reason.reason_notes "))
                table.fields.Add(New clsFieldData("res_code_gen", "Resolution", "fs_inc_reason.res_code_gen"))
                table.fields.Add(New clsFieldData("res_code_spec", "ResolutionSpec", "fs_inc_reason.res_code_spec"))
                table.fields.Add(New clsFieldData("resolution_notes", "ResolutionNotes", "fs_inc_reason.resolution_notes"))
                table.fields.Add(New clsFieldData("duration", "Duration", "spec.duration"))
                table.fields.Add(New clsFieldData("duration_units", "DurationUnits", "spec.duration_units"))
                table.fields.Add(New clsFieldData("inc_num", "IncNum", "fs_inc_reason.inc_num"))
                table.fields.Add(New clsFieldData("seq", "Seq", "fs_inc_reason.seq"))
                table.fields.Add(New clsFieldData("SpecRecordDate", "SpecRecordDate", "CONVERT(NVARCHAR,spec.RecordDate,121) As SpecRecordDate", bDate:=True))
                table.joins.Add("LEFT OUTER JOIN fs_reas_spec spec ON fs_inc_reason.reason_spec = spec.reason_spec AND fs_inc_reason.reason_gen = spec.reason_gen")
                table.joins.Add("INNER JOIN #MobileIncidents inc On inc.inc_num = fs_inc_reason.inc_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_line", "FSSROLines", "ln", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_line.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_line.sro_line"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_line.partner_id"))
                table.fields.Add(New clsFieldData("stat", "Stat", "fs_sro_line.stat"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro_line.description"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro_line.bill_code"))
                table.fields.Add(New clsFieldData("bill_type", "BillType", "fs_sro_line.bill_type"))
                table.fields.Add(New clsFieldData("qty_conv", "QtyConv", "fs_sro_line.qty_conv"))
                table.fields.Add(New clsFieldData("ser_num", "SerNum", "fs_sro_line.ser_num"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_sro_line.item"))
                table.fields.Add(New clsFieldData("u_m", "UM", "fs_sro_line.u_m"))
                table.fields.Add(New clsFieldData("inspect_type", "InspectType", "fs_sro_line.inspect_type"))
                table.fields.Add(New clsFieldData("product_code", "ProductCode", "fs_sro_line.product_code"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_line.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_oper", "FSSROOpers", "op", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_oper.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_oper.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_oper.sro_oper"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_oper.partner_id"))
                table.fields.Add(New clsFieldData("stat", "Stat", "fs_sro_oper.stat"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro_oper.description"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro_oper.bill_code"))
                table.fields.Add(New clsFieldData("bill_type", "BillType", "fs_sro_oper.bill_type"))
                table.fields.Add(New clsFieldData("oper_code", "OperCode", "fs_sro_oper.oper_code"))
                table.fields.Add(New clsFieldData("start_date", "StartDate", "fs_sro_oper.start_date"))
                table.fields.Add(New clsFieldData("end_date", "EndDate", "fs_sro_oper.end_date"))
                table.fields.Add(New clsFieldData("total_price", "TotalPrice", "fs_sro_oper.total_price"))
                table.fields.Add(New clsFieldData("product_code", "ProductCode", "fs_sro_oper.product_code"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_oper.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_reason", "FSSROReasons", "sroreas", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_reason.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_reason.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_reason.sro_oper"))
                table.fields.Add(New clsFieldData("reason_gen", "Reason"))
                table.fields.Add(New clsFieldData("reason_spec", "ReasonSpec"))
                table.fields.Add(New clsFieldData("reason_notes", "ReasonNotes"))
                table.fields.Add(New clsFieldData("res_code_gen", "Resolution"))
                table.fields.Add(New clsFieldData("res_code_spec", "ResolutionSpec"))
                table.fields.Add(New clsFieldData("resolution_notes", "ResolutionNotes"))
                table.fields.Add(New clsFieldData("seq", "Seq"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_reason.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_inspect", "FSSROInspects", "sroinsp", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_inspect.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_inspect.sro_line"))
                table.fields.Add(New clsFieldData("inspect_type", "InspectType", "fs_sro_inspect.inspect_type"))
                table.fields.Add(New clsFieldData("section_code", "SectionCode", "fs_sro_inspect.section_code"))
                table.fields.Add(New clsFieldData("inspect_task", "InspectTask", "fs_sro_inspect.inspect_task"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro_inspect.description"))
                table.fields.Add(New clsFieldData("parent_id", "ParentId", "fs_sro_inspect.parent_id"))
                table.fields.Add(New clsFieldData("comp_id", "CompId", "fs_sro_inspect.comp_id"))
                table.fields.Add(New clsFieldData("sequence", "Sequence", "fs_sro_inspect.sequence"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_sro_inspect.item"))
                table.fields.Add(New clsFieldData("u_m", "UM", "fs_sro_inspect.u_m"))
                table.fields.Add(New clsFieldData("low_value", "LowValue", "fs_sro_inspect.low_value"))
                table.fields.Add(New clsFieldData("high_value", "HighValue", "fs_sro_inspect.high_value"))
                table.fields.Add(New clsFieldData("format_string", "FormatString", "fs_sro_inspect.format_string"))
                table.fields.Add(New clsFieldData("expected_value", "ExpectedValue", "fs_sro_inspect.expected_value"))
                table.fields.Add(New clsFieldData("meas_value", "MeasValue", "fs_sro_inspect.meas_value"))
                table.fields.Add(New clsFieldData("adj_value", "AdjValue", "fs_sro_inspect.adj_value"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_inspect.partner_id"))
                table.fields.Add(New clsFieldData("insp_req", "InspReq", "fs_sro_inspect.insp_req"))
                table.fields.Add(New clsFieldData("meas_type", "MeasType", "fs_sro_inspect.meas_type"))
                table.fields.Add(New clsFieldData("meas_resp_type", "MeasTypeMeasRespType", "meastype.meas_resp_type"))
                table.fields.Add(New clsFieldData("MeasTypeRecordDate", "MeasTypeRecordDate", "CONVERT(NVARCHAR,meastype.RecordDate,121) AS MeasTypeRecordDate", bDate:=True))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_inspect.sro_num")
                table.joins.Add("LEFT OUTER JOIN fs_meas_type meastype ON meastype.meas_type = fs_sro_inspect.meas_type")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_matl", "FSSROMatls", "SROMatl", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_matl.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_matl.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_matl.sro_oper"))
                table.fields.Add(New clsFieldData("trans_num", "TransNum", "fs_sro_matl.trans_num"))
                table.fields.Add(New clsFieldData("trans_date", "TransDate", "fs_sro_matl.trans_date"))
                table.fields.Add(New clsFieldData("type", "Type", "fs_sro_matl.type"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_matl.partner_id"))
                table.fields.Add(New clsFieldData("posted", "Posted", "fs_sro_matl.posted"))
                table.fields.Add(New clsFieldData("trans_type", "TransType", "fs_sro_matl.trans_type"))
                table.fields.Add(New clsFieldData("post_date", "PostDate", "fs_sro_matl.post_date"))
                table.fields.Add(New clsFieldData("matl_qty_conv", "MatlQtyConv", "fs_sro_matl.matl_qty_conv"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_sro_matl.item"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro_matl.description"))
                table.fields.Add(New clsFieldData("u_m", "UM", "fs_sro_matl.u_m"))
                table.fields.Add(New clsFieldData("dept", "Dept", "fs_sro_matl.dept"))
                table.fields.Add(New clsFieldData("disc", "Disc", "fs_sro_matl.disc"))
                table.fields.Add(New clsFieldData("loc", "Loc", "fs_sro_matl.loc"))
                table.fields.Add(New clsFieldData("lot", "Lot", "fs_sro_matl.lot"))
                table.fields.Add(New clsFieldData("whse", "Whse", "fs_sro_matl.whse"))
                table.fields.Add(New clsFieldData("cost_conv", "CostConv", "fs_sro_matl.cost_conv"))
                table.fields.Add(New clsFieldData("price_conv", "PriceConv", "fs_sro_matl.price_conv"))
                table.fields.Add(New clsFieldData("reason_code", "ReasonCode", "fs_sro_matl.reason_code"))
                table.fields.Add(New clsFieldData("extcost", "ExtCost", "fs_sro_matl.extcost"))
                table.fields.Add(New clsFieldData("extprice", "ExtPrice", "fs_sro_matl.extprice"))
                table.fields.Add(New clsFieldData("pricecode", "PriceCode", "fs_sro_matl.pricecode"))
                table.fields.Add(New clsFieldData("ref_type", "RefType", "fs_sro_matl.ref_type"))
                table.fields.Add(New clsFieldData("tax_code1", "TaxCode1", "fs_sro_matl.tax_code1"))
                table.fields.Add(New clsFieldData("tax_code2", "TaxCode2", "fs_sro_matl.tax_code2"))
                table.fields.Add(New clsFieldData("cust_item", "CustItem", "fs_sro_matl.cust_item"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro_matl.bill_code"))
                table.fields.Add(New clsFieldData("reimb_partner", "ReimbPartner", "fs_sro_matl.reimb_partner"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_matl.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_labor", "FSSROLabors", "SROLabor", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_labor.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_labor.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_labor.sro_oper"))
                table.fields.Add(New clsFieldData("trans_num", "TransNum", "fs_sro_labor.trans_num"))
                table.fields.Add(New clsFieldData("trans_date", "TransDate", "fs_sro_labor.trans_date"))
                table.fields.Add(New clsFieldData("type", "Type", "fs_sro_labor.type"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_labor.partner_id"))
                table.fields.Add(New clsFieldData("posted", "Posted", "fs_sro_labor.posted"))
                table.fields.Add(New clsFieldData("post_date", "PostDate", "fs_sro_labor.post_date"))
                table.fields.Add(New clsFieldData("work_code", "WorkCode", "fs_sro_labor.work_code"))
                table.fields.Add(New clsFieldData("WorkCodeDescription", "WorkCodeDescription", "workcode.description AS WorkCodeDescription"))
                table.fields.Add(New clsFieldData("hrs_worked", "HrsWorked", "fs_sro_labor.hrs_worked"))
                table.fields.Add(New clsFieldData("hrs_to_bill", "HrsToBill", "fs_sro_labor.hrs_to_bill"))
                table.fields.Add(New clsFieldData("dept", "Dept", "fs_sro_labor.dept"))
                table.fields.Add(New clsFieldData("disc", "Disc", "fs_sro_labor.disc"))
                table.fields.Add(New clsFieldData("cost", "Cost", "fs_sro_labor.cost"))
                table.fields.Add(New clsFieldData("rate", "Rate", "fs_sro_labor.rate"))
                table.fields.Add(New clsFieldData("whse", "Whse", "fs_sro_labor.whse"))
                table.fields.Add(New clsFieldData("extcost", "ExtCost", "fs_sro_labor.extcost"))
                table.fields.Add(New clsFieldData("extprice", "ExtPrice", "fs_sro_labor.extprice"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro_labor.bill_code"))
                table.fields.Add(New clsFieldData("WorkCodeRecordDate", "WorkCodeRecordDate", "CONVERT(NVARCHAR,workcode.RecordDate,121) AS WorkCodeRecordDate", bDate:=True))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_labor.sro_num")
                table.joins.Add("LEFT OUTER JOIN fs_work_code WorkCode ON WorkCode.work_code = fs_sro_labor.work_code")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_misc", "FSSROMiscs", "SROMisc", True, True, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_misc.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_misc.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_misc.sro_oper"))
                table.fields.Add(New clsFieldData("trans_num", "TransNum", "fs_sro_misc.trans_num"))
                table.fields.Add(New clsFieldData("trans_date", "TransDate", "fs_sro_misc.trans_date"))
                table.fields.Add(New clsFieldData("type", "Type", "fs_sro_misc.type"))
                table.fields.Add(New clsFieldData("partner_id", "PartnerId", "fs_sro_misc.partner_id"))
                table.fields.Add(New clsFieldData("posted", "Posted", "fs_sro_misc.posted"))
                table.fields.Add(New clsFieldData("post_date", "PostDate", "fs_sro_misc.post_date"))
                table.fields.Add(New clsFieldData("qty", "Qty", "fs_sro_misc.qty"))
                table.fields.Add(New clsFieldData("misc_code", "MiscCode", "fs_sro_misc.misc_code"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_sro_misc.description"))
                table.fields.Add(New clsFieldData("matl_cost", "MatlCost", "fs_sro_misc.matl_cost"))
                table.fields.Add(New clsFieldData("lbr_cost", "LbrCost", "fs_sro_misc.lbr_cost"))
                table.fields.Add(New clsFieldData("fovhd_cost", "FovhdCost", "fs_sro_misc.fovhd_cost"))
                table.fields.Add(New clsFieldData("vovhd_cost", "VovhdCost", "fs_sro_misc.vovhd_cost"))
                table.fields.Add(New clsFieldData("out_cost", "OutCost", "fs_sro_misc.out_cost"))
                table.fields.Add(New clsFieldData("cost", "Cost", "fs_sro_misc.cost"))
                table.fields.Add(New clsFieldData("price", "Price", "fs_sro_misc.price"))
                table.fields.Add(New clsFieldData("extcost", "ExtCost", "fs_sro_misc.extcost"))
                table.fields.Add(New clsFieldData("extprice", "ExtPrice", "fs_sro_misc.extprice"))
                table.fields.Add(New clsFieldData("disc", "Disc", "fs_sro_misc.disc"))
                table.fields.Add(New clsFieldData("fs_pay_type", "FsPayType", "fs_sro_misc.fs_pay_type"))
                table.fields.Add(New clsFieldData("bill_code", "BillCode", "fs_sro_misc.bill_code"))
                table.fields.Add(New clsFieldData("whse", "Whse", "fs_sro_misc.whse"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_misc.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = Nothing
            Using table = New clsTableData("fs_sro_serial", "FSSROSerials", "serial", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("sro_num", "SroNum", "fs_sro_serial.sro_num"))
                table.fields.Add(New clsFieldData("sro_line", "SroLine", "fs_sro_serial.sro_line"))
                table.fields.Add(New clsFieldData("sro_oper", "SroOper", "fs_sro_serial.sro_oper"))
                table.fields.Add(New clsFieldData("trans_num", "TransNum", "fs_sro_serial.trans_num"))
                table.fields.Add(New clsFieldData("type", "Type", "fs_sro_serial.type"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_sro_serial.item"))
                table.fields.Add(New clsFieldData("ser_num", "SerNum", "fs_sro_serial.ser_num"))
                table.joins.Add("INNER JOIN #MobileSROs sro On sro.sro_num = fs_sro_serial.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "controlled_by_external_wms = 0"
            Using table = New clsTableData("whse", "SLWhses", "whs", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("whse", "Whse"))
                table.fields.Add(New clsFieldData("name", "Name"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            'add units included later
            If SyncSettings.UnitFilter = 1 Or SyncSettings.UnitFilter = 2 Then 'Assigned to Work
                Parms = Nothing
                sFilter = "fs_unit.RowPointer Not In(SELECT RowPointer From #MobileUnits)"
                Using table = New clsTableData("fs_unit", "FSUnits", "unt", True, True, sFilter, Parms, TempTable:="#MobileUnits", CreateTempTable:=False, DeferProcess:=True)
                    table.fields = oTables("fs_unit").ToList
                    table.joins.Add("LEFT OUTER JOIN item itm ON itm.item = fs_unit.item")
                    table.joins.Add("LEFT OUTER JOIN custaddr baddr ON fs_unit.cust_num = baddr.cust_num AND baddr.cust_seq = 0")
                    table.joins.Add("LEFT OUTER JOIN custaddr saddr ON fs_unit.cust_num = saddr.cust_num AND fs_unit.cust_seq = saddr.cust_seq")
                    If SyncSettings.UnitFilter = 1 Then
                        table.joins.Add("INNER JOIN (
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN #MobileSchedules sched ON sched.RefTypeKey = 'S' AND sched.RefNumKey = line.sro_num      
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             fs_incident inc 
                             INNER JOIN #MobileSchedules sched ON sched.RefTypeKey = 'N' AND sched.RefNumKey = inc.inc_num
                             UNION
                             SELECT inc.ser_num , inc.item FROM 
                             #MobileIncidents inc
                             UNION
                             SELECT line.ser_num , line.item FROM 
                             fs_sro_line line 
                             INNER JOIN #MobileSROs sro ON sro.sro_num = line.sro_num
                             ) queue ON fs_unit.ser_num = queue.ser_num AND fs_unit.item = queue.item")
                    ElseIf SyncSettings.UnitFilter = 2 Then 'owned by customer
                        table.joins.Add("INNER JOIN #MobileCustomers cust ON fs_unit.cust_num = cust.cust_num AND fs_unit.cust_seq = cust.cust_seq")
                    End If
                    If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
                End Using
            End If

            Parms = Nothing
            sFilter = "item.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableData("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = oTables("item").ToList
                table.joins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON item.item = iwqv.item")
                table.joins.Add("INNER JOIN fs_sro_matl matl ON item.item = matl.item")
                table.joins.Add("INNER JOIN #MobileSROs sro ON sro.sro_num = matl.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "item.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableData("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = oTables("item").ToList
                table.joins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON item.item = iwqv.item")
                table.joins.Add("INNER JOIN fs_sro_line line ON item.item = line.item")
                table.joins.Add("INNER JOIN #MobileSROs sro ON sro.sro_num = line.sro_num")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "item.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableData("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = oTables("item").ToList
                table.joins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON item.item = iwqv.item")
                table.joins.Add("INNER JOIN #MobileIncidents inc ON inc.item = item.item")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "item.RowPointer Not In(SELECT RowPointer From #MobileItems)"
            Using table = New clsTableData("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=True)
                table.fields = oTables("item").ToList
                table.joins.Add("INNER JOIN 
                          (SELECT 
                             [iw].[item]                           AS [item]
                           , SUM(ISNULL([iw].[qty_alloc_co], 0.0)) AS [QtyAllocCo]
                           , SUM(ISNULL([iw].[alloc_trn], 0.0))    AS [QtyAllocTrn]
                           , SUM(ISNULL([iw].[qty_on_hand], 0.0))  AS [QtyOnHand]
                           , ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = iw.item 
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)  AS [QtyTrans]
                           FROM [dbo].[itemwhse] [iw]
                           GROUP BY [iw].[item]
                          ) iwqv ON item.item = iwqv.item")
                table.joins.Add("INNER JOIN #MobileUnits unt ON unt.item = item.item")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("item", "SLItems", "itm", False, False, Nothing, Parms, TempTable:="#MobileItems", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("item").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("customer", "SLCustomers", "cus", True, False, Nothing, Parms, TempTable:="#MobileCustomers", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("customer").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_unit", "FSUnits", "unt", True, True, Nothing, Parms, TempTable:="#MobileUnits", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("fs_unit").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "whse.controlled_by_external_wms = 0"
            Using table = New clsTableData("itemwhse", "SLItemWhses", "itwh", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("item", "Item", "itemwhse.item"))
                table.fields.Add(New clsFieldData("Description", "Description", "item.description"))
                table.fields.Add(New clsFieldData("whse", "Whse", "itemwhse.whse"))
                table.fields.Add(New clsFieldData("name", "Name", "whse.name"))
                table.fields.Add(New clsFieldData("qty_on_hand", "QtyOnHand", "(itemwhse.qty_on_hand - ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = itemwhse.item 
                              AND iloc.whse = itemwhse.whse
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)) AS qty_on_hand"))
                table.fields.Add(New clsFieldData("qty_alloc_co", "QtyAllocCo", "itemwhse.qty_alloc_co"))
                table.fields.Add(New clsFieldData("alloc_trn", "AllocTrn", "itemwhse.alloc_trn"))
                table.fields.Add(New clsFieldData("qty_trans", "QtyTrans", "itemwhse.qty_trans"))
                table.fields.Add(New clsFieldData("DerQtyAvail", "DerQtyAvail", "(itemwhse.qty_on_hand - ISNULL((SELECT SUM(ISNULL([iloc].[qty_on_hand],0)) 
						      FROM itemloc iloc 
							  WHERE iloc.item = itemwhse.item 
                              AND iloc.whse = itemwhse.whse
							  AND iloc.mrb_flag = 0 and iloc.loc_type = 'T'),0.0)) - (itemwhse.qty_alloc_co + itemwhse.alloc_trn + (CASE when exists (select 1 from invparms as prm where prm.def_whse = itemwhse.whse) THEN  item.qty_allocjob ELSE  0 END))  AS DerQtyAvail"))
                table.fields.Add(New clsFieldData("WhseRecordDate", "WhseRecordDate", "CONVERT(NVARCHAR,whse.RecordDate,121) AS WhseRecordDate", bDate:=True))
                table.fields.Add(New clsFieldData("ItemRecordDate", "ItemRecordDate", "CONVERT(NVARCHAR,item.RecordDate,121) AS ItemRecordDate", bDate:=True))

                table.joins.Add("INNER JOIN #MobileItems item ON item.item = itemwhse.item")
                table.joins.Add("INNER JOIN whse ON whse.whse = itemwhse.whse")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "whse.controlled_by_external_wms = 0"
            Using table = New clsTableData("itemloc", "SLItemLocs", "iloc", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("loc", "Loc", "itemloc.loc"))
                table.fields.Add(New clsFieldData("item", "Item", "itemloc.item"))
                table.fields.Add(New clsFieldData("loc_type", "LocType", "itemloc.loc_type"))
                table.fields.Add(New clsFieldData("rank", "Rank", "itemloc.rank"))
                table.fields.Add(New clsFieldData("mrb_flag", "MrbFlag", "itemloc.mrb_flag"))
                table.fields.Add(New clsFieldData("whse", "Whse", "itemloc.whse"))
                table.fields.Add(New clsFieldData("qty_on_hand", "QtyOnHand", "itemloc.qty_on_hand"))

                table.joins.Add("INNER JOIN #MobileItems item ON item.item = itemloc.item")
                table.joins.Add("INNER JOIN whse ON whse.whse = itemloc.whse")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Parms = Nothing
            sFilter = "whse.controlled_by_external_wms = 0"
            Using table = New clsTableData("lot_loc", "SLLotLocs", "ltlc", False, False, sFilter, Parms)
                table.fields.Add(New clsFieldData("loc", "Loc", "lot_loc.loc"))
                table.fields.Add(New clsFieldData("description", "LocationDescription", "loc.description"))
                table.fields.Add(New clsFieldData("item", "Item", "lot_loc.item"))
                table.fields.Add(New clsFieldData("lot", "Lot", "lot_loc.lot"))
                table.fields.Add(New clsFieldData("whse", "Whse", "lot_loc.whse"))
                table.fields.Add(New clsFieldData("name", "WhseName", "whse.name"))
                table.fields.Add(New clsFieldData("qty_on_hand", "QtyOnHand", "lot_loc.qty_on_hand"))
                table.fields.Add(New clsFieldData("WhseRecordDate", "WhseRecordDate", "CONVERT(NVARCHAR,whse.RecordDate,121) AS WhseRecordDate", bDate:=True))
                table.fields.Add(New clsFieldData("LocRecordDate", "LocRecordDate", "CONVERT(NVARCHAR,loc.RecordDate,121) AS LocRecordDate", bDate:=True))
                table.joins.Add("INNER JOIN #MobileItems item ON item.item = lot_loc.item")
                table.joins.Add("INNER JOIN whse ON whse.whse = lot_loc.whse")
                table.joins.Add("INNER JOIN location loc ON loc.loc = lot_loc.loc")
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            Parms = Nothing
            sFilter = "fs_config.comp_id IN (SELECT comp_id FROM #MobileUnits)"
            Using table = New clsTableData("fs_config", "FSConfigs", "Config", False, False, sFilter, Parms, IsHierarchical:=True)
                table.fields.Add(New clsFieldData("comp_id", "CompId", "fs_config.comp_id", HierarchicalChild:=True))
                table.fields.Add(New clsFieldData("ser_num", "SerNum", "fs_config.ser_num"))
                table.fields.Add(New clsFieldData("item", "Item", "fs_config.item"))
                table.fields.Add(New clsFieldData("description", "Description", "fs_config.description"))
                table.fields.Add(New clsFieldData("parent_id", "ParentId", "fs_config.parent_id", HierarchicalParent:=True))
                table.fields.Add(New clsFieldData("install_date", "InstallDate", "fs_config.install_date"))
                table.fields.Add(New clsFieldData("remove_date", "RemoveDate", "fs_config.remove_date"))
                table.fields.Add(New clsFieldData("qty", "Qty", "fs_config.qty"))
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            'PROCESS SRO,Incident,Appt data last so all items/customers/codes are already down on the device

            Using table = New clsTableData("fs_schedule", "FSSchedules", "sched", False, False, Nothing, Parms, TempTable:="#MobileSchedules", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("fs_schedule").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_incident", "FSIncidents", "inc", True, True, Nothing, Parms, TempTable:="#MobileIncidents", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("fs_incident").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using
            Using table = New clsTableData("fs_sro", "FSSROs", "sro", True, True, Nothing, Parms, TempTable:="#MobileSROs", CreateTempTable:=False, DeferProcess:=False)
                table.fields = oTables("fs_sro").ToList
                If Not ReturnRecords(table, appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, False, SyncSettings, FormatProvider) Then Return False
            End Using

            FinalizeSync(appDB, settings, sInfobar, oObjectNotesCache, oObjectDocumentsCache, SyncSettings, FormatProvider)
            oTables.Clear()
            SetupTempTables = True
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            SetupTempTables = False
        End Try
    End Function
    Private Function ReturnRecords(ByRef tbl As clsTableData, ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                      ByRef oObjectNotesCache As DataTable, ByRef oObjectDocumentsCache As DataTable, ByRef bFirstTable As Boolean,
                                      ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider) As Boolean
        ReturnRecords = False
        Try
            Dim sSQL As String = ""
            Dim time As DateTime
            Dim time2 As DateTime
            Dim mDeviceDataOld As Generic.Dictionary(Of String, String)
            Dim mDeviceDataNew As Generic.Dictionary(Of String, String)
            Dim mDeviceDataUpd As Generic.Dictionary(Of String, String)
            Dim mDeviceDataSame As Generic.Dictionary(Of String, String)
            mDeviceDataNew = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataSame = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataUpd = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            mDeviceDataOld = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            time = Now
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Starting.", tbl.sTableName))

            If tbl.DeferProcess Then
                PrepDeviceData(appDB, tbl.sTableName, bFirstTable, SyncSettings, mDeviceDataOld, True)
            Else
                PrepDeviceData(appDB, tbl.sTableName, bFirstTable, SyncSettings, mDeviceDataOld)
            End If

            tbl.dt = GetTableRecords(appDB, tbl, sInfobar, SyncSettings)

            For Each sSecondaryJoin As KeyValuePair(Of String, String) In tbl.SecondaryJoins
                If tbl.dt Is Nothing Then
                    tbl.dt = GetTableRecords(appDB, tbl, sInfobar, SyncSettings, sSecondaryJoin)
                Else
                    tbl.dt.Merge(GetTableRecords(appDB, tbl, sInfobar, SyncSettings, sSecondaryJoin))
                End If
            Next
            'There are no records to process
            If tbl.dt Is Nothing OrElse tbl.dt.Rows.Count = 0 Then
                time2 = Now
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Table: {0} Records: 0", tbl.sTableName))
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Complete. Duration: {1}", tbl.sTableName, (time2 - time).ToString))
                Return True
            End If

            If tbl.dt IsNot Nothing Then
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Table: {0} Records: {1}", tbl.sTableName, tbl.dt.Rows.Count.ToString))
            End If
            'Setup output table to JSON serialization
            tbl.BuildOutTable()

            'populate output table with records
            If Not BuildXMLFromDT(tbl, appDB, sInfobar, SyncSettings, FormatProvider, settings,
                                  mDeviceDataOld,
                 mDeviceDataNew,
                mDeviceDataUpd,
                 mDeviceDataSame) Then Exit Function
            If tbl.doNotes Then
                CacheNotes(appDB, tbl.sTableName, tbl.dt, oObjectNotesCache, SyncSettings)
            End If

            If tbl.doDocs Then
                CacheDocuments(appDB, tbl.sTableName, tbl.dt, oObjectDocumentsCache, SyncSettings)
            End If

            If Not SaveDeviceData(appDB, sInfobar, tbl, SyncSettings,
                                  mDeviceDataOld,
                 mDeviceDataNew,
                mDeviceDataUpd,
                 mDeviceDataSame) Then Exit Function


            If tbl.outTable IsNot Nothing And tbl.outTable.Rows.Count > 0 Then
                SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + tbl.sIDO + """:      " + JsonConvert.SerializeObject(tbl.outTable, settings)
            End If

            bFirstTable = False
            time2 = Now
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0} Complete. Duration: {1}", tbl.sTableName, (time2 - time).ToString))

            If mDeviceDataOld IsNot Nothing Then
                mDeviceDataOld.Clear()
            End If
            If mDeviceDataNew IsNot Nothing Then
                mDeviceDataNew.Clear()
            End If
            If mDeviceDataUpd IsNot Nothing Then
                mDeviceDataUpd.Clear()
            End If
            If mDeviceDataSame IsNot Nothing Then
                mDeviceDataSame.Clear()
            End If
            ReturnRecords = True
        Catch ex As Exception
            sInfobar = MGException.ExtractMessages(ex)
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            ReturnRecords = False
        End Try
    End Function

    'Public Function SerializeDataTable(ByRef dt As DataTable) As String
    '    If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return ""
    '    If String.IsNullOrEmpty(dt.TableName) Then Return ""

    '    Dim datasb As StringBuilder = New StringBuilder()
    '    Using datasw As StringWriter = New StringWriter(datasb)

    '        Using dataWriter As JsonWriter = New JsonTextWriter(datasw)

    '            'dataWriter.WritePropertyName(dt.TableName)

    '            dataWriter.WriteStartArray()

    '            For Each row As DataRow In dt.Rows

    '                dataWriter.WriteStartObject()

    '                For Each col As DataColumn In dt.Columns

    '                    If row(col.ColumnName) Is DBNull.Value Then Continue For
    '                    dataWriter.WritePropertyName(col.ColumnName)
    '                    dataWriter.WriteValue(row(col.ColumnName).ToString)
    '                Next
    '                dataWriter.WriteEndObject()
    '            Next
    '            dataWriter.WriteEndArray()

    '        End Using
    '    End Using
    '    Return datasb.ToString
    'End Function
    Public Function FinalizeSync(ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                 ByRef oObjectNotesCache As DataTable, ByRef oObjectDocumentsCache As DataTable,
                                 ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider) As Boolean
        FinalizeSync = True

        Dim mDeviceDataOld As Generic.Dictionary(Of String, String)
        Dim mDeviceDataNew As Generic.Dictionary(Of String, String)
        Dim mDeviceDataUpd As Generic.Dictionary(Of String, String)
        Dim mDeviceDataSame As Generic.Dictionary(Of String, String)
        mDeviceDataNew = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataSame = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataUpd = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataOld = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)

        'Send Out Notes
        If oObjectNotesCache IsNot Nothing Then ' And Not bHasMoreRecords Then
            '  Detail = "Processing ObjectNotes"

            oObjectNotesCache.TableName = "ObjectNotes"
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0}", oObjectNotesCache.TableName))


            Using oNoteTable = New clsTableData("ObjectNotes", "SLObjectNotes", "objn", False, False, Nothing)
                PrepDeviceData(appDB, oNoteTable.sTableName, False, SyncSettings, mDeviceDataOld)
                oNoteTable.dt = oObjectNotesCache

                oNoteTable.fields.Add(New clsFieldData("ObjectName", "NhObjectName"))
                oNoteTable.fields.Add(New clsFieldData("NoteDesc", "DerDesc"))
                oNoteTable.fields.Add(New clsFieldData("NoteContent", "DerContent"))
                oNoteTable.fields.Add(New clsFieldData("DerReusable", "DerReusable"))
                oNoteTable.fields.Add(New clsFieldData("DerSystem", "DerSystem"))
                oNoteTable.fields.Add(New clsFieldData("DerType", "DerType"))
                oNoteTable.fields.Add(New clsFieldData("ObjectNoteToken", "ObjectNoteToken"))
                oNoteTable.fields.Add(New clsFieldData("NoteHeaderToken", "NoteHeaderToken"))
                oNoteTable.fields.Add(New clsFieldData("SpecificNoteToken", "SpecificNoteToken"))
                oNoteTable.fields.Add(New clsFieldData("SystemNoteToken", "SystemNoteToken"))
                oNoteTable.fields.Add(New clsFieldData("UserNoteToken", "UserNoteToken"))
                oNoteTable.fields.Add(New clsFieldData("NoteFlag", "NhNoteFlag"))
                oNoteTable.fields.Add(New clsFieldData("RefRowPointer", "RefRowPointer"))
                oNoteTable.BuildOutTable()

                If Not BuildXMLFromDT(oNoteTable, appDB, sInfobar, SyncSettings, FormatProvider, settings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame) Then Exit Function

                If Not SaveDeviceData(appDB, sInfobar, oNoteTable, SyncSettings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame) Then Exit Function
                If oNoteTable.outTable IsNot Nothing And oNoteTable.outTable.Rows.Count > 0 Then
                    SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + oNoteTable.sIDO + """:      " + JsonConvert.SerializeObject(oNoteTable.outTable, settings)
                End If

            End Using
        End If

        ClearNotesCache(oObjectNotesCache)

        ''Send out Documents
        If oObjectDocumentsCache IsNot Nothing Then

            oObjectDocumentsCache.TableName = "DocumentObjectAndRefViews"
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0}", oObjectDocumentsCache.TableName))

            Using oDocTable = New clsTableData("DocumentObjectAndRefViews", "DocumentObjectAndRefViews", "refs", False, False, Nothing)
                PrepDeviceData(appDB, oDocTable.sTableName, False, SyncSettings, mDeviceDataOld)
                oDocTable.dt = oObjectDocumentsCache

                oDocTable.fields.Add(New clsFieldData("TableName", "TableName"))
                oDocTable.fields.Add(New clsFieldData("TableRowPointer", "TableRowPointer"))
                oDocTable.fields.Add(New clsFieldData("DocumentObjectRowPointer", "DocumentObjectRowPointer"))
                oDocTable.fields.Add(New clsFieldData("DocumentName", "DocumentName"))
                oDocTable.fields.Add(New clsFieldData("Description", "Description"))
                oDocTable.fields.Add(New clsFieldData("DocumentType", "DocumentType"))
                oDocTable.fields.Add(New clsFieldData("DocumentExtension", "DocumentExtension"))
                oDocTable.fields.Add(New clsFieldData("StorageMethod", "StorageMethod"))
                oDocTable.fields.Add(New clsFieldData("MediaType", "MediaType"))
                oDocTable.fields.Add(New clsFieldData("Sequence", "Sequence"))

                oDocTable.fields.Add(New clsFieldData("DocumentObject", "DocumentObject"))

                oDocTable.BuildOutTable()

                If Not BuildXMLFromDT(oDocTable, appDB, sInfobar, SyncSettings, FormatProvider, settings,
                                  mDeviceDataOld,
                 mDeviceDataNew,
                mDeviceDataUpd,
                 mDeviceDataSame) Then Exit Function

                If Not SaveDeviceData(appDB, sInfobar, oDocTable, SyncSettings,
                                  mDeviceDataOld,
                 mDeviceDataNew,
                mDeviceDataUpd,
                 mDeviceDataSame) Then Exit Function

                If oDocTable.outTable IsNot Nothing And oDocTable.outTable.Rows.Count > 0 Then
                    SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + oDocTable.sIDO + """:      " + JsonConvert.SerializeObject(oDocTable.outTable, settings)
                End If
            End Using
        End If

        ClearDocumentsCache(oObjectDocumentsCache)

        'Write last segment to temp table
        If Not WriteTmpData(appDB, sInfobar, SyncSettings) Then Return False

        UpdateTmpRecordCount(appDB, SyncSettings)

        Return GetNextRecord(appDB, SyncSettings.DeviceSyncSeq, SyncSettings)

    End Function
    Public Function FinalizeSyncRS8416(ByRef appDB As ApplicationDB, ByRef settings As JsonSerializerSettings, ByRef sInfobar As String,
                                 ByRef oObjectNotesCache As DataTable, ByRef oObjectDocumentsCache As DataTable,
                                 ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider, ByRef mNewCustomFields As List(Of String),
                                   ByRef mListForceShowTables As List(Of String), ByVal bValidateOnly As Boolean) As Boolean
        FinalizeSyncRS8416 = True

        Dim mDeviceDataOld As Generic.Dictionary(Of String, String)
        Dim mDeviceDataNew As Generic.Dictionary(Of String, String)
        Dim mDeviceDataUpd As Generic.Dictionary(Of String, String)
        Dim mDeviceDataSame As Generic.Dictionary(Of String, String)
        mDeviceDataNew = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataSame = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataUpd = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        mDeviceDataOld = New Generic.Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)

        'Send Out Notes
        If oObjectNotesCache IsNot Nothing Then ' And Not bHasMoreRecords Then
            '  Detail = "Processing ObjectNotes"

            oObjectNotesCache.TableName = "ObjectNotes"
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0}", oObjectNotesCache.TableName))


            Using oNoteTable = New clsTableDataRS8416("ObjectNotes", "SLObjectNotes", "objn", False, False, Nothing)
                If bValidateOnly Then
                    'if validating then reset on each table
                    SyncSettings.ResponseSize = 1
                    SyncSettings.RecordCount = 0
                Else
                    PrepDeviceData(appDB, oNoteTable.sTableName, False, SyncSettings, mDeviceDataOld)
                End If

                oNoteTable.dt = oObjectNotesCache

                oNoteTable.fields.Add("ObjectName", New clsFieldDataRS8416("ObjectName", "NhObjectName"))
                oNoteTable.fields.Add("NoteDesc", New clsFieldDataRS8416("NoteDesc", "DerDesc"))
                oNoteTable.fields.Add("NoteContent", New clsFieldDataRS8416("NoteContent", "DerContent"))
                oNoteTable.fields.Add("DerReusable", New clsFieldDataRS8416("DerReusable", "DerReusable"))
                oNoteTable.fields.Add("DerSystem", New clsFieldDataRS8416("DerSystem", "DerSystem"))
                oNoteTable.fields.Add("DerType", New clsFieldDataRS8416("DerType", "DerType"))
                oNoteTable.fields.Add("ObjectNoteToken", New clsFieldDataRS8416("ObjectNoteToken", "ObjectNoteToken"))
                oNoteTable.fields.Add("NoteHeaderToken", New clsFieldDataRS8416("NoteHeaderToken", "NoteHeaderToken"))
                oNoteTable.fields.Add("SpecificNoteToken", New clsFieldDataRS8416("SpecificNoteToken", "SpecificNoteToken"))
                oNoteTable.fields.Add("SystemNoteToken", New clsFieldDataRS8416("SystemNoteToken", "SystemNoteToken"))
                oNoteTable.fields.Add("UserNoteToken", New clsFieldDataRS8416("UserNoteToken", "UserNoteToken"))
                oNoteTable.fields.Add("NoteFlag", New clsFieldDataRS8416("NoteFlag", "NhNoteFlag"))
                oNoteTable.fields.Add("RefRowPointer", New clsFieldDataRS8416("RefRowPointer", "RefRowPointer"))
                oNoteTable.BuildOutTable()

                If Not BuildXMLFromDT(oNoteTable, appDB, sInfobar, SyncSettings, FormatProvider, settings,
                                      mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame,
                                      mNewCustomFields, mListForceShowTables, bValidateOnly) Then
                    If bValidateOnly And Not String.IsNullOrEmpty(sInfobar) Then
                        SyncSettings.ValidationMessage = sInfobar
                        Return WriteValidationRecord(appDB, oNoteTable, SyncSettings, sInfobar)
                    Else
                        Exit Function
                    End If
                End If

                If Not bValidateOnly Then
                    If Not SaveDeviceData(appDB, sInfobar, oNoteTable, SyncSettings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame) Then Exit Function
                End If

                If oNoteTable.outTable IsNot Nothing And oNoteTable.outTable.Rows.Count > 0 Then
                    SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + oNoteTable.sIDO + """:      " + JsonConvert.SerializeObject(oNoteTable.outTable, settings)
                End If

                If bValidateOnly Then
                    If Not WriteValidationRecord(appDB, oNoteTable, SyncSettings, sInfobar) Then Return False
                End If
            End Using
        End If

        ClearNotesCache(oObjectNotesCache)

        ''Send out Documents
        If oObjectDocumentsCache IsNot Nothing Then

            oObjectDocumentsCache.TableName = "DocumentObjectAndRefViews"
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Processing Table: {0}", oObjectDocumentsCache.TableName))

            Using oDocTable = New clsTableDataRS8416("DocumentObjectAndRefViews", "DocumentObjectAndRefViews", "refs", False, False, Nothing)
                If bValidateOnly Then
                    'if validating then reset on each table
                    SyncSettings.ResponseSize = 1
                    SyncSettings.RecordCount = 0
                Else
                    PrepDeviceData(appDB, oDocTable.sTableName, False, SyncSettings, mDeviceDataOld)
                End If
                oDocTable.dt = oObjectDocumentsCache

                oDocTable.fields.Add("TableName", New clsFieldDataRS8416("TableName", "TableName"))
                oDocTable.fields.Add("TableRowPointer", New clsFieldDataRS8416("TableRowPointer", "TableRowPointer"))
                oDocTable.fields.Add("DocumentObjectRowPointer", New clsFieldDataRS8416("DocumentObjectRowPointer", "DocumentObjectRowPointer"))
                oDocTable.fields.Add("DocumentName", New clsFieldDataRS8416("DocumentName", "DocumentName"))
                oDocTable.fields.Add("Description", New clsFieldDataRS8416("Description", "Description"))
                oDocTable.fields.Add("DocumentType", New clsFieldDataRS8416("DocumentType", "DocumentType"))
                oDocTable.fields.Add("DocumentExtension", New clsFieldDataRS8416("DocumentExtension", "DocumentExtension"))
                oDocTable.fields.Add("StorageMethod", New clsFieldDataRS8416("StorageMethod", "StorageMethod"))
                oDocTable.fields.Add("MediaType", New clsFieldDataRS8416("MediaType", "MediaType"))
                oDocTable.fields.Add("Sequence", New clsFieldDataRS8416("Sequence", "Sequence"))
                oDocTable.fields.Add("DocumentObject", New clsFieldDataRS8416("DocumentObject", "DocumentObject"))

                oDocTable.BuildOutTable()

                If Not BuildXMLFromDT(oDocTable, appDB, sInfobar, SyncSettings, FormatProvider, settings,
                                      mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame,
                                      mNewCustomFields, mListForceShowTables, bValidateOnly) Then
                    If bValidateOnly And Not String.IsNullOrEmpty(sInfobar) Then
                        SyncSettings.ValidationMessage = sInfobar
                        Return WriteValidationRecord(appDB, oDocTable, SyncSettings, sInfobar)
                    Else
                        Exit Function
                    End If
                End If

                If Not bValidateOnly Then
                    If Not SaveDeviceData(appDB, sInfobar, oDocTable, SyncSettings,
                                  mDeviceDataOld,
                 mDeviceDataNew,
                mDeviceDataUpd,
                 mDeviceDataSame) Then Exit Function
                End If
                If oDocTable.outTable IsNot Nothing And oDocTable.outTable.Rows.Count > 0 Then
                    SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + oDocTable.sIDO + """:      " + JsonConvert.SerializeObject(oDocTable.outTable, settings)
                End If

                If bValidateOnly Then
                    If Not WriteValidationRecord(appDB, oDocTable, SyncSettings, sInfobar) Then Return False
                End If

            End Using
        End If

        ClearDocumentsCache(oObjectDocumentsCache)

        If Not bValidateOnly Then
            'Write last segment to temp table
            If Not WriteTmpData(appDB, sInfobar, SyncSettings) Then Return False

            UpdateTmpRecordCount(appDB, SyncSettings)

            Return GetNextRecord(appDB, SyncSettings.DeviceSyncSeq, SyncSettings)
        Else
            Return True
        End If

    End Function

    Public Function BuildXMLFromDT(ByRef tbl As clsTableData, ByRef appDB As ApplicationDB, ByRef sInfobar As String,
                                   ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider,
                                   ByRef settings As JsonSerializerSettings,
                                             ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
            ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
        ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
        ByRef mDeviceDataSame As Generic.Dictionary(Of String, String)) As Boolean
        Try
            Dim oRow As DataRow
            Dim bIsNew As Boolean = False

            BuildXMLFromDT = False


            SyncSettings.DeviceSyncSeq = SyncSettings.DeviceSyncSeq + 1
            For Each oRow In tbl.dt.Rows
                If SyncSettings.ResponseSize >= SyncSettings.MaxResponseSize Then
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.General, String.Format("Split sync {0} at table {1}.", SyncSettings.TmpSequence.ToString(), tbl.sTableName))
                    If tbl.outTable IsNot Nothing And tbl.outTable.Rows.Count > 0 Then

                        SyncSettings.JSONOut = SyncSettings.JSONOut + ",""" + tbl.sIDO + """:      " + JsonConvert.SerializeObject(tbl.outTable, settings)


                    End If
                    If Not WriteTmpData(appDB, sInfobar, SyncSettings) Then Return False
                    tbl.outTable.Clear()
                End If

                ' Create/Setup "record"
                AddRecord(tbl, oRow, bIsNew, SyncSettings, FormatProvider, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame)

                AddDataRow(tbl, oRow, sInfobar, bIsNew, SyncSettings, FormatProvider)
            Next

            Return True
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
            sInfobar = ex.Message
            Return False
        End Try
    End Function
    Public Function GetTableRecords(ByRef appDB As ApplicationDB,
                                    ByVal tblData As clsTableData,
                                    ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings,
                                    Optional ByVal sJoinOverride As KeyValuePair(Of String, String) = Nothing) As DataTable
        Dim sWhere As String
        Dim sSql As New System.Text.StringBuilder
        Dim oParms As List(Of SqlParameter)

        oParms = New List(Of SqlParameter)
        sSql.Length = 0
        sWhere = ""
        Dim sParentCol As String = ""
        Dim sChildCol As String = ""

        'GetFilters(oParms, sWhere, GetTableRecords.TableName)
        If tblData.IsHierarchical Then

            For Each sfield As clsFieldData In tblData.fields
                If sfield.HierarchicalChild Then
                    sChildCol = sfield.sField
                ElseIf sfield.HierarchicalParent Then
                    sParentCol = sfield.sField
                End If
                If sChildCol <> "" And sParentCol <> "" Then Exit For
            Next

            sSql.AppendFormat(";WITH {0}_cte (", tblData.sTableName)
            sSql.AppendLine(FieldList(tblData, bIsTempTable:=True))
            sSql.AppendLine("  )")
            sSql.AppendLine(" AS (SELECT")
            sSql.AppendLine(FieldList(tblData, bNullParent:=True))
            sSql.AppendFormat("From {0} (NOLOCK)", tblData.sTableName)
            sSql.AppendLine()
            sSql.AppendFormat("WHERE {0}", tblData.sFilter)
            sSql.AppendLine()
            sSql.AppendLine("UNION ALL")
            sSql.AppendLine("  Select ")
            sSql.AppendLine(FieldList(tblData))
            sSql.AppendFormat("From {0} (NOLOCK)", tblData.sTableName)
            sSql.AppendLine()
            sSql.AppendFormat("INNER JOIN {0}_cte cte ON cte.{1} = {0}.{2}", tblData.sTableName, sChildCol, sParentCol)
            sSql.AppendLine(")")
            sSql.AppendFormat("Select {0} FROM {1}_cte {1} ", FieldList(tblData), tblData.sTableName)
            sSql.AppendLine()
        Else
            If tblData.TempTable <> "" And tblData.CreateTempTable And sJoinOverride.Key Is Nothing Then

                sSql.AppendFormat("CREATE TABLE {0}(", SQLQuoted(tblData.TempTable))
                Dim bfirst As Boolean = True
                For Each fld As clsFieldData In tblData.fields
                    If fld.sField = "" Then Continue For
                    If bfirst Then
                        sSql.AppendFormat("{0} {1}", fld.sField, fld.sSQLType)
                        bfirst = False
                    Else
                        sSql.AppendFormat(", {0} {1}", fld.sField, fld.sSQLType)
                    End If
                    sSql.AppendLine()

                Next
                sSql.AppendLine(")")

                sSql.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_RowPointer ON {0}(RowPointer)", tblData.TempTable)
                sSql.AppendLine()
                Dim keylist As String = FieldList(tblData, True, True)
                If (keylist <> "*") Then
                    sSql.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_Main ON {0}({1})", tblData.TempTable, keylist)
                End If
                sSql.AppendLine()
                ExecuteSQLStatement(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)
                sSql.Length = 0
            End If
            If tblData.TempTable <> "" And tblData.DeferProcess Then
                If (tblData.sTableView <> "") Then
                    sSql.AppendFormat("INSERT INTO {0} Select DISTINCT {1} FROM {2} ", SQLQuoted(tblData.TempTable), FieldList(tblData), SQLQuoted(tblData.sTableView))
                    sSql.AppendLine()
                Else
                    sSql.AppendFormat("INSERT INTO {0} Select DISTINCT {1} FROM {2} ", SQLQuoted(tblData.TempTable), FieldList(tblData), SQLQuoted(tblData.sTableName))
                    sSql.AppendLine()
                End If

            Else
                If tblData.TempTable <> "" Then
                    sSql.AppendFormat("Select {0} FROM {1} ", FieldList(tblData, True), SQLQuoted(tblData.TempTable))
                    sSql.AppendLine()
                Else
                    If (tblData.sTableView <> "") Then
                        sSql.AppendFormat("Select {0} FROM {1} ", FieldList(tblData), SQLQuoted(tblData.sTableView))
                        sSql.AppendLine()
                    Else
                        sSql.AppendFormat("Select {0} FROM {1} ", FieldList(tblData), SQLQuoted(tblData.sTableName))
                        sSql.AppendLine()
                    End If

                End If
            End If

            sSql.AppendLine(GetJoin(tblData))

            'normal processing of main select
            If sJoinOverride.Key Is Nothing Then
                If tblData.sFilter <> "" Then
                    sSql.AppendFormat("WHERE {0}", tblData.sFilter)
                    sSql.AppendLine()
                End If
            Else 'processing secondary joins to add additional data
                sSql.AppendLine(sJoinOverride.Key)

                If Not String.IsNullOrEmpty(sJoinOverride.Value) Then
                    sSql.AppendFormat("WHERE {0}", sJoinOverride.Value)
                    sSql.AppendLine()
                End If
            End If
        End If

        If tblData.Parms IsNot Nothing Then
            For Each parm As SqlParameter In tblData.Parms
                oParms.Add(New SqlParameter(parm.ParameterName, parm.Value))
            Next
        End If

        If tblData.DeferProcess Then
            ExecuteSQLStatement(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)

            Return Nothing 'just adding records to the temp table
        Else
            GetTableRecords = GetDatatable(sSql.ToString, appDB, oParms, SyncSettings, sInfobar)
            GetTableRecords.TableName = tblData.sTableName
            GetTableRecords.CaseSensitive = False
        End If

        Return GetTableRecords
    End Function
    Public Function Lookup(ByVal sSQL As String,
                          ByRef appDB As ApplicationDB,
                           ByVal oParms As List(Of SqlParameter), ByRef SyncSettings As ClsSyncSettings) As String

        Try
            Dim sValue As String

            sValue = ""

            Using oCmd As SqlCommand = appDB.CreateCommand(CommandType.Text, sSQL)
                If oParms IsNot Nothing Then
                    oCmd.Parameters.AddRange(oParms.ToArray)
                End If

                sValue = GetString(oCmd.ExecuteScalar())

                Return sValue
            End Using
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
            Return ""
        End Try
    End Function

    Public Function ImageLookup(ByVal sSQL As String,
                          ByRef formDB As Mongoose.Core.DataAccess.FrameworkDB,
                           ByVal oParms As List(Of SqlParameter), ByRef SyncSettings As ClsSyncSettings) As String
        Try
            Dim sValue As String

            Using oCmd As SqlCommand = formDB.CreateCommand(CommandType.Text, sSQL)
                If oParms IsNot Nothing Then
                    oCmd.Parameters.AddRange(oParms.ToArray)
                End If

                sValue = oCmd.ExecuteScalar()

                Return sValue
            End Using
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function GetDatatable(ByVal sSql As String,
                                 ByRef appDB As ApplicationDB,
                                 ByRef oParms As List(Of SqlParameter),
                                 ByRef SyncSettings As ClsSyncSettings,
                                 Optional ByRef sInfobar As String = "") As DataTable

        Using oCmd As SqlCommand = appDB.CreateCommand(CommandType.Text, sSql)
            sInfobar = ""
            'add parameters
            If oParms IsNot Nothing Then
                oCmd.Parameters.AddRange(oParms.ToArray)
            End If

            oCmd.CommandTimeout = 60

            Using da As SqlDataAdapter = New SqlDataAdapter
                da.SelectCommand = oCmd

                Using dt As DataTable = New DataTable

                    Try
                        da.Fill(dt)
                    Catch ex As Exception
                        SyncSettings.ValidationMessage = MGException.ExtractMessages(ex)
                        sInfobar = String.Format("Error occured In GetDatatable:{0}", SyncSettings.ValidationMessage)

                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sSql)
                    End Try

                    Return dt
                End Using
            End Using
        End Using
    End Function

    Public Function ExecuteSQLStatement(ByVal sSQL As String,
                                        ByRef appDB As ApplicationDB,
                                        ByRef oParms As List(Of SqlParameter),
                                        ByRef SyncSettings As ClsSyncSettings,
                                        Optional ByRef sInfobar As String = "") As Boolean
        Dim lRecCount As Long
        If sSQL.Trim = "" Then Return True
        Using oCmd As SqlCommand = appDB.CreateCommand(CommandType.Text, sSQL)
            sInfobar = ""
            ExecuteSQLStatement = False

            oCmd.CommandTimeout = 60

            If oParms IsNot Nothing Then
                oCmd.Parameters.AddRange(oParms.ToArray)
            End If

            Try
                lRecCount = oCmd.ExecuteNonQuery()
            Catch ex As Exception
                SyncSettings.ValidationMessage = MGException.ExtractMessages(ex)
                sInfobar = String.Format("Execute Error:{0}", SyncSettings.ValidationMessage)

                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                Return False
            End Try
            ExecuteSQLStatement = True
        End Using
    End Function
    Public Function GetFirstRowFromSelect(ByVal sSQL As String,
                                          ByRef appDB As ApplicationDB,
                                          ByRef Parms As List(Of SqlParameter), ByRef SyncSettings As ClsSyncSettings) As DataRow


        Dim dr As DataRow = Nothing

        Using dt As DataTable = GetDatatable(sSQL, appDB, Parms, SyncSettings)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
            End If

            Return dr
        End Using
    End Function

    Private Function AddWhere(ByVal filter As String) As String

        If String.IsNullOrEmpty(filter) Then
            Return ""

        Else
            Return "WHERE " + filter
        End If
    End Function

    Private Function GetJoin(ByVal table As clsTableData) As String
        Dim sJoin As String = ""

        For Each join As String In table.joins
            sJoin = sJoin + vbNewLine + join
        Next

        If (String.IsNullOrEmpty(sJoin)) Then
            sJoin = ""
        End If
        Return sJoin
    End Function
    Private Function FieldList(ByVal table As clsTableData, Optional ByVal bIsTempTable As Boolean = False, Optional ByVal bkeyonly As Boolean = False, Optional ByVal bNullParent As Boolean = False) As String
        Dim sColumns As String = ""
        For Each field As clsFieldData In table.fields
            If field.HierarchicalParent And bNullParent Then
                sColumns = sColumns + ",NULL"
            ElseIf field.sExpression <> "" And Not bIsTempTable Then
                sColumns = sColumns + "," + field.sExpression
            ElseIf (bkeyonly And field.bKeyField) Or Not bkeyonly Then
                sColumns = sColumns + "," + field.sField
            End If
        Next
        If (String.IsNullOrEmpty(sColumns)) Then
            sColumns = "*"
        Else
            sColumns = sColumns.TrimStart(",")
        End If
        Return sColumns
    End Function


    Public Sub CacheDocuments(ByRef appDB As ApplicationDB, ByVal sTableName As String, ByVal dtSource As DataTable, ByRef oObjectDocumentsCache As DataTable, ByRef SyncSettings As ClsSyncSettings)
        Try
            Dim sSQL As String
            Dim iNoteHeaderFlagZero As Integer = 0
            Dim iNoteHeaderFlagOne As Integer = 0
            Dim iCount As Integer = 0
            Dim sTempList As String = ""
            Dim oParmsDict As Dictionary(Of String, SqlParameter)
            Dim sWhereList As String = ""
            If Not SyncSettings.IncludeAttachments Then
                If oObjectDocumentsCache Is Nothing Then
                    'initialize cache to clear existing records on parm change
                    oParmsDict = New Dictionary(Of String, SqlParameter) From {
                        {"@TableName", New SqlParameter("@TableName", sTableName)}
                    }
                    sSQL = GetDocumentObjectRefSQL("1=2", SyncSettings)
                    oObjectDocumentsCache = GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings)
                End If
                Exit Sub
            End If
                ' Build List of Rowpointers
                Dim sbRPList As New StringBuilder
            If Not dtSource.Columns.Contains("RowPointer") Then Exit Sub
            For Each oRow As DataRow In dtSource.Rows
                If sbRPList.Length > 0 Then sbRPList.Append(", ")
                sbRPList.Append(GetString(oRow("RowPointer")))
                iCount = iCount + 1
                'break down the table insert into chunks of 1000 records to avoid sql out of resources error
                If iCount >= 1000 Then
                    oParmsDict = New Dictionary(Of String, SqlParameter)
                    AddListToParameters(oParmsDict, sWhereList, sbRPList.ToString, "doc", "TableRowPointer", SqlDbType.UniqueIdentifier, 36, Nothing)
                    oParmsDict.Add("@TableName", New SqlParameter("@TableName", sTableName))
                    sSQL = GetDocumentObjectRefSQL(sWhereList, SyncSettings)
                    If oObjectDocumentsCache Is Nothing Then
                        oObjectDocumentsCache = GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings)
                    Else
                        oObjectDocumentsCache.Merge(GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings))
                    End If
                    iCount = 0
                    sbRPList.Length = 0
                    oParmsDict = Nothing
                    sWhereList = ""
                End If
            Next

            If sbRPList.Length > 0 Then
                oParmsDict = New Dictionary(Of String, SqlParameter)
                AddListToParameters(oParmsDict, sWhereList, sbRPList.ToString, "doc", "TableRowPointer", SqlDbType.UniqueIdentifier, 36, Nothing)
                oParmsDict.Add("@TableName", New SqlParameter("@TableName", sTableName))
                sSQL = GetDocumentObjectRefSQL(sWhereList, SyncSettings)
                If oObjectDocumentsCache Is Nothing Then
                    oObjectDocumentsCache = GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings)
                Else
                    oObjectDocumentsCache.Merge(GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings))
                End If
                iCount = 0
                sbRPList.Length = 0
                oParmsDict = Nothing
                sWhereList = ""
            End If
        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
        End Try
    End Sub

    Public Sub ClearDocumentsCache(ByRef oObjectDocumentsCache As DataTable)
        If oObjectDocumentsCache IsNot Nothing Then
            oObjectDocumentsCache.Clear()
            oObjectDocumentsCache.Columns.Clear()
            oObjectDocumentsCache.Dispose()
        End If

        oObjectDocumentsCache = Nothing
    End Sub

    Public Function GetSpecificNoteSQL(ByVal sWhereList As String) As String

        Dim sbSQL As New StringBuilder
        sbSQL.AppendLine("  Select ")
        sbSQL.AppendLine("  nh.ObjectName ")
        sbSQL.AppendLine(" , objn.RefRowPointer ")
        sbSQL.AppendLine(" , COALESCE(spcn.NoteDesc, sysn.NoteDesc,usrn.NoteDesc) AS NoteDesc ")
        sbSQL.AppendLine(" , COALESCE(spcn.NoteContent, sysn.NoteContent,usrn.NoteContent) AS NoteContent ")
        sbSQL.AppendLine(" , CASE WHEN objn.UserNoteToken Is Not NULL Or objn.SystemNoteToken Is Not NULL THEN 1 ELSE 0 END AS DerReusable ")
        sbSQL.AppendLine(" , CASE WHEN objn.SystemNoteToken Is Not NULL THEN 1 ELSE 0 END AS DerSystem ")
        sbSQL.AppendLine(" , CASE WHEN sysn.SystemNoteToken Is Not NULL THEN 'System' ")
        sbSQL.AppendLine("   WHEN usrn.UserNoteToken Is Not NULL THEN 'User' ")
        sbSQL.AppendLine("   Else 'Specific' ")
        sbSQL.AppendLine("   End As DerType ")
        sbSQL.AppendLine(" , objn.ObjectNoteToken ")
        sbSQL.AppendLine(" , nh.NoteHeaderToken ")
        sbSQL.AppendLine(" , objn.SpecificNoteToken ")
        sbSQL.AppendLine(" , sysn.SystemNoteToken ")
        sbSQL.AppendLine(" , usrn.UserNoteToken ")
        sbSQL.AppendLine(" , nh.NoteFlag ")
        sbSQL.AppendLine(" , objn.RowPointer ")
        sbSQL.AppendLine(" , CONVERT(NVARCHAR,COALESCE(spcn.RecordDate,usrn.RecordDate,sysn.RecordDate, objn.RecordDate),121) AS RecordDate ")
        sbSQL.AppendLine(" From ObjectNotes objn ")
        sbSQL.AppendLine(" INNER Join NoteHeaders nh ")
        sbSQL.AppendLine(" On nh.NoteHeaderToken = objn.NoteHeaderToken ")
        sbSQL.AppendLine(" Left OUTER JOIN SpecificNotes spcn ")
        sbSQL.AppendLine(" On spcn.SpecificNoteToken = objn.SpecificNoteToken ")
        sbSQL.AppendLine(" Left OUTER JOIN SystemNotes sysn ")
        sbSQL.AppendLine(" On sysn.SystemNoteToken = objn.SystemNoteToken ")
        sbSQL.AppendLine(" Left OUTER JOIN UserNotes usrn ")
        sbSQL.AppendLine(" On usrn.UserNoteToken = objn.UserNoteToken ")
        sbSQL.AppendLine(" WHERE nh.ObjectName = @TableName ")
        sbSQL.AppendFormat(" And {0}", sWhereList)

        Return sbSQL.ToString

    End Function
    Public Function GetDocumentObjectRefSQL(ByVal sWhereList As String, ByVal SyncSettings As ClsSyncSettings) As String

        Dim sbSQL As New StringBuilder
        sbSQL.AppendLine("  Select ")
        sbSQL.AppendLine("doc.TableName")
        sbSQL.AppendLine(", doc.TableRowPointer")
        sbSQL.AppendLine(", doc.DocumentObjectRowPointer")
        sbSQL.AppendLine(", doc.DocumentName")
        sbSQL.AppendLine(", doc.Description")
        sbSQL.AppendLine(", doc.DocumentType")
        sbSQL.AppendLine(", doc.DocumentExtension")
        sbSQL.AppendLine(", doc.StorageMethod")
        sbSQL.AppendLine(", doc.MediaType")
        sbSQL.AppendLine(", doc.Sequence")
        sbSQL.AppendLine(", doc.DocumentObject")
        sbSQL.AppendLine(", doc.RowPointer")
        sbSQL.AppendLine(", CONVERT(NVARCHAR,doc.RecordDate,121) AS RecordDate")
        sbSQL.AppendLine(" From DocumentObjectAndRefView doc ")
        sbSQL.AppendLine(" WHERE doc.TableName = @TableName ")
        sbSQL.AppendFormat(" And {0}", sWhereList)

        Return sbSQL.ToString

    End Function
    Public Sub CacheNotes(ByRef appDB As ApplicationDB, ByVal sTableName As String, ByVal dtSource As DataTable, ByRef oObjectNotesCache As DataTable, ByRef SyncSettings As ClsSyncSettings)
        Try
            Dim sSQL As String
            Dim oParmsDict As Dictionary(Of String, SqlParameter)

            If dtSource Is Nothing Then Return
            Dim iCount As Integer = 0
            Dim sWhereList As String = ""
            ' Build List of Rowpointers
            Dim sbRPList As New StringBuilder
            If Not dtSource.Columns.Contains("RowPointer") Then Exit Sub
            For Each oRow As DataRow In dtSource.Rows
                If sbRPList.Length > 0 Then sbRPList.Append(", ")
                sbRPList.Append(GetString(oRow("RowPointer")))
                iCount = iCount + 1
                'break down the table insert into chunks of 1000 records to avoid sql out of resources error
                If iCount >= 1000 Then
                    oParmsDict = New Dictionary(Of String, SqlParameter)
                    AddListToParameters(oParmsDict, sWhereList, sbRPList.ToString, "objn", "RefRowPointer", SqlDbType.UniqueIdentifier, 36, Nothing)
                    oParmsDict.Add("@TableName", New SqlParameter("@TableName", sTableName))
                    sSQL = GetSpecificNoteSQL(sWhereList)

                    If oObjectNotesCache Is Nothing Then
                        oObjectNotesCache = GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings)
                    Else
                        oObjectNotesCache.Merge(GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings))
                    End If

                    iCount = 0
                    sbRPList.Length = 0
                    oParmsDict = Nothing
                    sWhereList = ""
                End If
            Next

            If sbRPList.Length > 0 Then
                oParmsDict = New Dictionary(Of String, SqlParameter)
                AddListToParameters(oParmsDict, sWhereList, sbRPList.ToString, "objn", "RefRowPointer", SqlDbType.UniqueIdentifier, 36, Nothing)
                oParmsDict.Add("@TableName", New SqlParameter("@TableName", sTableName))
                sSQL = GetSpecificNoteSQL(sWhereList)

                If oObjectNotesCache Is Nothing Then
                    oObjectNotesCache = GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings)
                Else
                    oObjectNotesCache.Merge(GetDatatable(sSQL, appDB, oParmsDict.Values.ToList, SyncSettings))
                End If

                'mCurrentRecordCount = mCurrentRecordCount + dt.Rows.Count


                oParmsDict = Nothing
                sWhereList = ""
            End If

        Catch ex As Exception
            MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, ex.Message)
        End Try

    End Sub

    Public Sub AddListToParameters(ByRef oParms As Dictionary(Of String, SqlParameter), ByRef sWhere As String, ByVal sList As String _
                            , ByVal sTableName As String, ByVal sFieldName As String, ByVal dbtype As SqlDbType, ByVal size As Integer, ByVal precision As Integer _
                            , Optional ByVal sOperator As String = "=", Optional ByVal sAlternateFieldName As String = "")
        Dim sNewWhere As String
        Dim tNumEntries As Integer
        Dim sSplit As String()
        Dim sTempList As String
        Dim tIdx As Integer
        Dim sEntry As String
        Dim sNewParmName As String

        If sAlternateFieldName <> "" Then
            sNewParmName = "@" & sTableName & sAlternateFieldName
        Else
            sNewParmName = "@" & sTableName & sFieldName
        End If

        If sList.Trim.Length = 0 Then Exit Sub

        sSplit = sList.Split(","c)
        tNumEntries = sSplit.Length

        If tNumEntries = 1 Then
            sNewWhere = String.Concat(SQLQuoted(sTableName), ".", SQLQuoted(sFieldName), " ", sOperator, " ", sNewParmName)
            If Not oParms.ContainsKey(sNewParmName) Then
                oParms.Add(sNewParmName, New SqlParameter(sNewParmName, sList))
            End If
        Else
            sTempList = ""
            For tIdx = 0 To tNumEntries - 1
                sEntry = sSplit(tIdx)
                AppendList(sTempList, sNewParmName & tIdx.ToString)
                If Not oParms.ContainsKey(sNewParmName & tIdx.ToString) Then
                    oParms.Add(sNewParmName & tIdx.ToString, GetSQLParameter(sNewParmName & tIdx.ToString, sEntry, dbtype, size, precision, False))
                End If
            Next
            sNewWhere = SQLQuoted(sTableName) & "." & SQLQuoted(sFieldName) & " IN (" & sTempList & ")"
        End If
        AppendWhere(sWhere, sNewWhere)
    End Sub

    Public Sub AppendWhere(ByRef sWhere As String, ByVal sValueToAppend As String, Optional ByVal sOperator As String = "And", Optional ByVal bDoParenthesis As Boolean = False)
        If sValueToAppend.Trim.Length = 0 Then Exit Sub

        If Len(Trim(sWhere)) <> 0 Then
            sOperator = " " & Trim(sOperator) & " "
            If bDoParenthesis Then
                sWhere = "(" & sWhere & ")" & sOperator
            Else
                sWhere = sWhere & sOperator
            End If
        End If
        If bDoParenthesis Then
            'protect SQL injection double any existing () to prevent escaping
            sValueToAppend = sValueToAppend.Replace("(", "((").Replace(")", "))")
            sValueToAppend = "(" & sValueToAppend & ")"
        End If
        sWhere = sWhere & sValueToAppend
    End Sub


    Public Sub AppendList(ByRef sList As String, ByVal sValue As String, Optional ByVal sSeperator As String = ",")
        If sList Is Nothing Then sList = ""
        If sList.Length <> 0 Then
            sList = sList & sSeperator
        End If
        sList = sList & sValue
    End Sub
    Public Sub ClearNotesCache(ByRef oObjectNotesCache As DataTable)

        If oObjectNotesCache IsNot Nothing Then
            oObjectNotesCache.Clear()
            oObjectNotesCache.Columns.Clear()
            oObjectNotesCache.Dispose()
        End If

        oObjectNotesCache = Nothing
    End Sub


    Public Function GetSQLParameter(ByVal Name As String, ByVal Value As Object, ByVal dbtype As SqlDbType, ByVal size As Integer, ByVal precision As Integer,
                                ByVal isNullable As Boolean) As SqlParameter
        Dim sValue As String = GetString(Value)
        GetSQLParameter = New SqlParameter(Name, dbtype)

        If isNullable AndAlso (sValue = "" Or sValue = "NULL") Then
            Value = DBNull.Value
        End If
        If dbtype = SqlDbType.UniqueIdentifier Then
            GetSQLParameter.Value = New Guid(Value.ToString)
        Else
            GetSQLParameter.Value = Value
        End If

        If size <> Nothing Then
            GetSQLParameter.Size = size
        End If

        If precision <> Nothing Then
            GetSQLParameter.Precision = precision
        End If

        GetSQLParameter.IsNullable = isNullable
    End Function

    Public Sub AddRecord(ByRef tblData As clsTableData,
                         ByRef oRow As DataRow,
                         ByRef bIsNew As Boolean, ByRef SyncSettings As ClsSyncSettings,
                         ByVal FormatProvider As IFormatProvider,
                         ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                         ByRef mDeviceDataSame As Generic.Dictionary(Of String, String))

        Dim sRowPointer As String = ""
        Dim dRecordDate As Date

        Dim dTmpDate As Date
        If Not oRow Is Nothing Then
            sRowPointer = GetString(oRow("RowPointer"))
            For Each sColumn As String In tblData.DateColumns
                dTmpDate = GetDate(oRow(sColumn), FormatProvider)
                If (dTmpDate > dRecordDate) Then
                    dRecordDate = dTmpDate
                End If
            Next
        End If
        AddRecordInternal(tblData, sRowPointer, dRecordDate, bIsNew, SyncSettings, mDeviceDataOld, mDeviceDataNew, mDeviceDataUpd, mDeviceDataSame)
    End Sub
    Private Sub AddRecordInternal(ByRef tblData As clsTableData,
                                  ByVal sRowPointer As String,
                                  ByVal dRecordDate As Date,
                                  ByRef bIsNew As Boolean,
                                  ByRef SyncSettings As ClsSyncSettings,
                                  ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                                  ByRef mDeviceDataSame As Generic.Dictionary(Of String, String)
                                  )
        SyncSettings.SuspendAddThisRecord = False

        If sRowPointer.Length > 0 Then
            ' Need to figure out if record actually needs to be sent.
            Dim sKey As String = sRowPointer
            If mDeviceDataOld.ContainsKey(sKey) Then
                ' we need to send an update if the record changed 
                If dRecordDate <= SyncSettings.LastSyncDate Then
                    ' Suspend Sending this record!!!
                    SyncSettings.SuspendAddThisRecord = True
                    If Not mDeviceDataSame.ContainsKey(sKey) Then
                        mDeviceDataSame.Add(sKey, sRowPointer)
                    End If
                    mDeviceDataOld.Remove(sKey)
                    Return
                End If
                If Not mDeviceDataUpd.ContainsKey(sKey) Then
                    mDeviceDataUpd.Add(sKey, sKey)
                    mDeviceDataOld.Remove(sKey)
                Else
                    'record already sent
                    SyncSettings.SuspendAddThisRecord = True
                    Return
                End If
                bIsNew = False
            ElseIf mDeviceDataSame.ContainsKey(sKey) Then
                ' Suspend Sending this record!!!
                SyncSettings.SuspendAddThisRecord = True
            ElseIf mDeviceDataUpd.ContainsKey(sKey) Then
                ' Suspend Sending this record!!!
                SyncSettings.SuspendAddThisRecord = True
            Else
                'make sure we haven't already processed this record due to a bad join returning it twice
                If Not mDeviceDataNew.ContainsKey(sKey) Then
                    mDeviceDataNew.Add(sKey, sKey)
                Else
                    'record already sent
                    SyncSettings.SuspendAddThisRecord = True
                    Return
                End If

                bIsNew = True
            End If
        End If
    End Sub
    Public Function CreateItemId(ByVal table As String, ByVal tblalias As String, ByVal rowpointer As String, ByVal recorddate As String) As String
        Return "PBT=[" + table + "] " + tblalias + ".ID=[" + rowpointer + "] " + tblalias + ".DT=[" + recorddate + "]"
    End Function
    Public Sub AddDataRow(ByRef tblData As clsTableData, ByRef oRow As DataRow, ByRef sInfobar As String, ByVal bIsNew As Boolean,
                          ByRef SyncSettings As ClsSyncSettings, ByVal FormatProvider As IFormatProvider)
        If SyncSettings.SuspendAddThisRecord Then Exit Sub
        SyncSettings.RecordCount = SyncSettings.RecordCount + 1
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + ((tblData.sTableName.Length + SyncSettings.RecordPadding) * SyncSettings.ResponseMultiplier)
        Dim outRow As DataRow = tblData.outTable.NewRow()
        outRow("_ItemId") = CreateItemId(tblData.sTableName, tblData.sAlias, oRow("RowPointer").ToString, oRow("RecordDate"))
        outRow("ToRemove") = "False"

        If bIsNew Then
            outRow("ToInsert") = "True"
        Else
            outRow("ToInsert") = "False"
        End If

        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("_ItemId".Length + GetString(outRow("_ItemId")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("ToInsert".Length + GetString(outRow("ToInsert")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)
        SyncSettings.ResponseSize = SyncSettings.ResponseSize + (("ToRemove".Length + GetString(outRow("ToRemove")).Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)


        For Each fldData As clsFieldData In tblData.fields
            Try
                If fldData.sField = "_ItemId" Or fldData.sField = "ToRemove" Or fldData.sField = "ToInsert" Or fldData.sField = "NativeGetImage" _
                    Or fldData.sProperty = "_ItemId" Or fldData.sProperty = "ToRemove" Or fldData.sProperty = "ToInsert" Or fldData.sProperty = "NativeGetImage" Then Continue For
                If fldData.sField <> "" And fldData.sProperty <> "" Then
                    If tblData.dt.Columns(fldData.sField).DataType = GetType(String) Then
                        Me.AddXMLField(fldData.sProperty, oRow(fldData.sField), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Int32) Then
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Boolean) Then
                        Me.AddXMLLogiField(fldData.sProperty, GetBoolean(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Byte) Then 'bytes don't allow nulls treat as integer
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Double) Then
                        Me.AddXMLField(fldData.sProperty, GetDouble(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Decimal) Then
                        Me.AddXMLField(fldData.sProperty, SQLDecimal(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Int16) Then
                        Me.AddXMLField(fldData.sProperty, SQLInteger(oRow(fldData.sField), True), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Date) Then
                        Me.AddXMLDateTimeField(fldData.sProperty, GetDate(oRow(fldData.sField), FormatProvider), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(DateTime) Then
                        Me.AddXMLDateTimeField(fldData.sProperty, GetDate(oRow(fldData.sField), FormatProvider), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Guid) Then
                        Me.AddXMLField(fldData.sProperty, GetString(oRow(fldData.sField)), outRow, SyncSettings)
                    ElseIf tblData.dt.Columns(fldData.sField).DataType = GetType(Byte()) Then
                        If oRow(fldData.sField).ToString <> "" Then
                            If SyncSettings.Is915OrLater Then
                                outRow("NativeGetImage") = fldData.sProperty
                            Else
                                Me.AddXMLField(fldData.sProperty, Convert.ToBase64String(oRow(fldData.sField)), outRow, SyncSettings)
                            End If
                        End If
                    Else
                        sInfobar = String.Format("Processing: {0} Can't handle {1}", tblData.sTableName, fldData.sField)
                        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                    End If
                Else
                    sInfobar = String.Concat("Can't handle ", fldData.sProperty)
                    MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
                End If
            Catch ex As Exception
                sInfobar = MGException.ExtractMessages(ex)
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Error, sInfobar)
            End Try
        Next
        tblData.outTable.Rows.Add(outRow)
    End Sub
    Public Sub AddXMLField(ByVal sXMLFieldName As String, ByVal sXMLFieldValue As Object, ByRef outRow As DataRow, ByRef SyncSettings As ClsSyncSettings)

        If SyncSettings.SuspendAddThisRecord = True Then Return


        If sXMLFieldValue Is System.DBNull.Value OrElse sXMLFieldValue Is Nothing Then Return

        If sXMLFieldValue.ToString.Contains(Chr(3)) Then

            sXMLFieldValue = sXMLFieldValue.ToString.Replace(Chr(3), Chr(32))
        End If

        outRow(sXMLFieldName) = sXMLFieldValue

        SyncSettings.ResponseSize = SyncSettings.ResponseSize + ((sXMLFieldName.Length + sXMLFieldValue.Length + SyncSettings.FieldPadding) * SyncSettings.ResponseMultiplier)

    End Sub

    Public Sub AddXMLLogiField(ByVal sXMLFieldName As String, ByVal sXMLFieldValue As Object,
             ByRef outRow As DataRow, ByRef SyncSettings As ClsSyncSettings)

        Dim bValue As Boolean
        Dim sValue As String

        If sXMLFieldValue Is System.DBNull.Value Then Return

        sValue = ""
        Try
            bValue = CType(sXMLFieldValue, Boolean)

            If bValue Then
                sValue = "TRUE"
            Else
                sValue = "FALSE"
            End If
        Catch ex As Exception

        End Try

        If sValue = "" Then Return

        AddXMLField(sXMLFieldName, sValue, outRow, SyncSettings)

    End Sub

    Public Sub AddXMLDateField(ByVal sXMLFieldName As String, ByVal sXMLFieldValue As Object,
                 ByRef outRow As DataRow, ByRef SyncSettings As ClsSyncSettings)

        Dim sValue As String

        If sXMLFieldValue Is System.DBNull.Value Then Return
        If sXMLFieldValue = GetNullDate() Then Return

        sValue = Format(sXMLFieldValue, "yyyy-MM-dd")

        AddXMLField(sXMLFieldName, sValue, outRow, SyncSettings)

    End Sub
    Public Sub AddXMLDateTimeField(ByVal sXMLFieldName As String, ByVal sXMLFieldValue As Object,
                ByRef outRow As DataRow, ByRef SyncSettings As ClsSyncSettings)

        Dim sValue As String

        If sXMLFieldValue Is System.DBNull.Value Then Return
        If sXMLFieldValue = GetNullDate() Then Return

        sValue = Format(sXMLFieldValue, "yyyy-MM-dd HH:mm:ss.fff")

        AddXMLField(sXMLFieldName, sValue, outRow, SyncSettings)

    End Sub

#Region "ConversionRoutines"
    Public Function GetNullDate() As Date
        Dim dDate As Date
        GetNullDate = dDate
    End Function
    Public Function GetDouble(ByVal strValue As Object) As Double
        Dim dValue As Double

        GetDouble = 0

        Try
            If strValue Is Nothing Then Return 0
            If strValue Is System.DBNull.Value Then Return 0
            dValue = CDbl(strValue)
        Catch ex As Exception
            dValue = 0
        End Try
        GetDouble = dValue
    End Function

    Public Function GetDouble(ByVal sFieldName As String, ByRef dr As DataRow) As Double
        Dim dValue As Double

        GetDouble = 0

        Try
            If dr(sFieldName) Is Nothing Then Return 0
            If dr(sFieldName) Is System.DBNull.Value Then Return 0
            dValue = CDbl(dr(sFieldName))
        Catch ex As Exception
            dValue = 0
        End Try
        GetDouble = dValue
    End Function
    Public Function GetBoolean(ByVal strValue As Object) As Boolean
        Dim bValue As Boolean

        Try
            If strValue Is Nothing Then Return False
            If strValue Is System.DBNull.Value Then Return False
            bValue = CBool(strValue)
        Catch ex As Exception
            bValue = False
        End Try

        GetBoolean = bValue
    End Function
    Public Function SQLDecimal(ByVal Value As Object, ByVal bAllowNull As Boolean) As String

        SQLDecimal = Nothing

        If bAllowNull AndAlso (Value Is System.DBNull.Value Or Value Is Nothing) Then Exit Function

        SQLDecimal = GetDecimal(Value)

        Exit Function

    End Function
    Public Function GetDecimal(ByVal oValue As Object) As Decimal
        Dim dValue As Decimal

        GetDecimal = 0

        Try
            If oValue Is Nothing Then Return 0
            If oValue Is System.DBNull.Value Then Return 0
            dValue = CDec(oValue)
        Catch ex As Exception
            dValue = 0
        End Try
        GetDecimal = dValue
    End Function

    Public Function GetDecimal(ByVal sFieldName As String, ByRef dr As DataRow) As Decimal
        Dim dValue As Decimal

        GetDecimal = 0

        Try
            If dr(sFieldName) Is Nothing Then Return 0
            If dr(sFieldName) Is System.DBNull.Value Then Return 0
            dValue = CDec(dr(sFieldName))
        Catch ex As Exception
            dValue = 0
        End Try
        GetDecimal = dValue
    End Function
    Public Function GetInteger(ByVal strValue As Object) As Integer
        Dim iValue As Integer

        GetInteger = 0

        Try
            If strValue Is Nothing Then Return 0
            If strValue Is System.DBNull.Value Then Return 0
            iValue = strValue
        Catch ex As Exception
            iValue = 0
        End Try

        GetInteger = iValue

    End Function
    Public Function GetInteger(ByVal sXMLBoolValue As String, ByVal bDefault As Boolean) As Integer
        Dim iValue As Integer

        GetInteger = 0

        If sXMLBoolValue.ToUpper = "TRUE" Then
            iValue = 1
        ElseIf sXMLBoolValue.ToUpper = "FALSE" Then
            iValue = 0
        ElseIf bDefault Then
            iValue = 1
        Else
            iValue = 0
        End If

        GetInteger = iValue
    End Function
    Public Function GetInteger(ByVal sFieldName As String, ByRef dr As DataRow) As Integer
        Dim iValue As Integer

        GetInteger = 0

        Try
            If dr(sFieldName) Is Nothing Then Return 0
            If dr(sFieldName) Is System.DBNull.Value Then Return 0
            iValue = dr(sFieldName)
        Catch ex As Exception
            iValue = 0
        End Try

        GetInteger = iValue

    End Function


    Public Function SQLInteger(ByVal Value As Object, ByVal bAllowNull As Boolean) As String

        SQLInteger = Nothing

        If bAllowNull AndAlso (Value Is System.DBNull.Value Or Value Is Nothing) Then Exit Function

        SQLInteger = GetInteger(Value)

        Exit Function

    End Function
    Public Function SQLDateTime(ByVal vDateTime As Object, ByVal FormatProvider As IFormatProvider) As String

        Dim dDate As Date
        Dim dUnsetDate As Date

        SQLDateTime = Nothing

        If vDateTime Is System.DBNull.Value Or vDateTime = dUnsetDate Then Exit Function

        On Error Resume Next
        dDate = DateTime.Parse(vDateTime, FormatProvider, Globalization.DateTimeStyles.AllowWhiteSpaces)
        If Err.Number <> 0 Then
            Err.Clear()
            Exit Function
        End If

        If dDate = dUnsetDate Then Exit Function

        SQLDateTime = SQLDate(dDate, FormatProvider, True) & "T" & Format$(dDate, "HH:mm:ss.fff")

        Exit Function

    End Function

    Public Function SQLBoolean(ByVal bValue As Boolean) As String
        Dim sVal As String

        If bValue Then
            sVal = "1"
        Else
            sVal = "0"
        End If

        SQLBoolean = sVal

    End Function


    Public Function SQLDate(ByVal vDate As Object, FormatProvider As IFormatProvider, Optional ByVal bSkipAppend As Boolean = False) As String

        Dim dDate As Date
        Dim dUnsetDate As Date

        SQLDate = Nothing

        If vDate Is System.DBNull.Value Or vDate = dUnsetDate Then Exit Function

        If Len(Trim$(vDate)) = 0 Then Exit Function

        On Error Resume Next
        dDate = DateTime.Parse(vDate, FormatProvider, Globalization.DateTimeStyles.AllowWhiteSpaces)
        If Err.Number <> 0 Then
            Err.Clear()
            Exit Function
        End If

        ' Skip out if date not set 
        If dDate = dUnsetDate Then Exit Function

        ' Format Date
        SQLDate = Format$(dDate, "yyyy-MM-dd")

        If Not bSkipAppend Then
            SQLDate = SQLDate & "T00:00:00.000"
        End If

    End Function




    Public Function SQLQuoted(ByVal sString As String) As String
        Dim sReturn As String = sString
        If (sString.ToUpper.StartsWith("INFORMATION_SCHEMA.") Or sString.ToUpper.StartsWith("SYS.")) AndAlso sString.Split("."c, " "c).Length = 2 Then Return sReturn

        sReturn = "[" & Replace(Replace(sString, "]", "]]"), "[", "[[") & "]"

        Return sReturn
    End Function

    Public Function GetDate(ByVal strDate As Object, ByVal FormatProvider As IFormatProvider) As Date
        Dim dDate As Date
        Try
            If Not (strDate Is DBNull.Value) Then
                dDate = DateTime.Parse(strDate, FormatProvider, Globalization.DateTimeStyles.AllowWhiteSpaces)
            Else
                dDate = Nothing
            End If
        Catch ex As Exception

        End Try
        GetDate = dDate
    End Function
    Public Function GetString(ByRef strValue As Object, Optional bQuote As Boolean = False) As String
        Dim sValue As String

        sValue = ""
        Try
            If strValue Is Nothing Then Return ""
            If strValue Is System.DBNull.Value Then Return ""
            sValue = strValue.ToString
            If bQuote Then
                sValue = sValue.Trim("'") 'remove outer quotes
                sValue = "'" & Replace(sValue, "'", "''") & "'"
            End If
        Catch ex As Exception
        End Try
        GetString = sValue
    End Function

#End Region

#Region "DeviceData"
    Public Sub PrepDeviceData(ByRef appDB As ApplicationDB, ByVal sTableName As String, ByVal bFirstTable As Boolean,
                              ByRef SyncSettings As ClsSyncSettings,
                              ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                              Optional ByVal bClearOnly As Boolean = False)

        SyncSettings.DeviceSyncSeq = SyncSettings.ParmSyncSeq
        Me.GetDeviceCache(appDB, sTableName, bClearOnly, bFirstTable, SyncSettings, mDeviceDataOld)
    End Sub

    Public Sub GetDeviceCache(ByRef appDB As ApplicationDB, ByVal sTableName As String, ByVal bClearOnly As Boolean, ByVal bFirstTable As Boolean,
                              ByRef SyncSettings As ClsSyncSettings,
                              ByRef mDeviceDataOld As Generic.Dictionary(Of String, String))

        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Get Device Data for table: {0}", sTableName))
        Dim sbSQL As New StringBuilder
        'Dim oData As clsDeviceData
        Dim oParms As List(Of SqlParameter)

        If sTableName = "" Then Exit Sub

        If SyncSettings.DeviceSyncSeq = 0 And bFirstTable Then
            ' Clear out all data for this device/message 
            sbSQL.Length = 0
            sbSQL.AppendLine("DELETE mobile_device_data WHERE device_id = @DeviceId AND app_name = @ApplicationId")

            oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceId", SyncSettings.DeviceID),
                                                     New SqlParameter("@ApplicationId", SyncSettings.AppId)}
        Else
            ' Clear out any other older/newer SyncSequences
            sbSQL.Length = 0
            sbSQL.AppendLine("DELETE mobile_device_data WHERE device_id = @DeviceId AND app_name = @ApplicationId AND sync_sequence <> @Sequence AND table_name = @TableName")

            oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                     New SqlParameter("@Sequence", SyncSettings.DeviceSyncSeq),
                                                     New SqlParameter("@TableName", sTableName),
                                                     New SqlParameter("@ApplicationId", SyncSettings.AppId)}
        End If
        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, "") Then Exit Sub

        If Not bClearOnly Then
            ' Get Current sync_sequence Data for the current table
            sbSQL.Length = 0
            sbSQL.AppendLine("SELECT * FROM mobile_device_Data")
            sbSQL.AppendLine(" WHERE device_id = @DeviceID")
            sbSQL.AppendLine(" AND app_name = @ApplicationId")
            sbSQL.AppendLine(" AND sync_sequence = @Sequence AND table_name = @TableName")

            oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                     New SqlParameter("@Sequence", SyncSettings.DeviceSyncSeq),
                                                     New SqlParameter("@TableName", sTableName),
                                                     New SqlParameter("@ApplicationId", SyncSettings.AppId)}

            Using dt As DataTable = GetDatatable(sbSQL.ToString, appDB, oParms, SyncSettings)

                oParms = Nothing
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    sbSQL.Length = 0
                    sbSQL.AppendLine("SELECT table_name FROM mobile_device_data WHERE device_id = @DeviceID AND app_name = @ApplicationId AND sync_sequence = @Sequence")

                    oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                                       New SqlParameter("@Sequence", SyncSettings.DeviceSyncSeq),
                                                                       New SqlParameter("@ApplicationId", SyncSettings.AppId)}

                    'see if any tables exist for this sync sequence
                    If Lookup(sbSQL.ToString, appDB, oParms, SyncSettings) = "" Then
                        ' If no Current sync_sequence Data, send ClearAll to device
                        SyncSettings.ClearOld = True
                    End If
                Else
                    ' Deserialize Data
                    Dim stringreader As System.IO.StringReader
                    Dim xReader As System.Xml.XmlTextReader
                    Dim sKey As String
                    For Each oRow As DataRow In dt.Rows
                        stringreader = New System.IO.StringReader(GetString(oRow("device_data")))
                        xReader = New System.Xml.XmlTextReader(stringreader)
                        'oRow = Nothing

                        xReader.Read() '<Data>

                        While Not xReader.EOF
                            If xReader.Name = "I" Then
                                ' Found "Item" row

                                sKey = GetString(xReader.GetAttribute("P"))
                                'Dim sDate As String = xReader.GetAttribute("D")
                                'oData.D = GetDate(sDate)
                                If Not mDeviceDataOld.ContainsKey(sKey) Then
                                    mDeviceDataOld.Add(sKey, sKey)
                                End If
                                xReader.Read()
                            Else
                                xReader.Read()
                            End If
                        End While
                    Next
                End If
            End Using
        End If
    End Sub
    Public Function SaveDeviceData(ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef tblData As clsTableData,
                                   ByRef SyncSettings As ClsSyncSettings,
                                   ByRef mDeviceDataOld As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataNew As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataUpd As Generic.Dictionary(Of String, String),
                                   ByRef mDeviceDataSame As Generic.Dictionary(Of String, String)) As Boolean
        SaveDeviceData = False
        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Save Device Data for table: {0}", tblData.sTableName))
        ' Remove Records from both Local Cache and Client Device that should no longer be on the device
        For Each sKey As String In mDeviceDataOld.Keys
            If Not mDeviceDataSame.ContainsKey(sKey) _
                And Not mDeviceDataUpd.ContainsKey(sKey) Then

                ' Tell Client to remove the files
                Dim outRow As DataRow
                outRow = tblData.outTable.NewRow
                outRow("ToRemove") = "True"
                outRow("RowPointer") = sKey
                MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Performance, String.Format("Removing Record {0} for Table: {1}", sKey, tblData.sTableName))
                tblData.outTable.Rows.Add(outRow)
            End If
        Next

        ' Now, serialize it and store it!
        Dim sbXML As New System.Text.StringBuilder
        Dim stringwriter As New System.IO.StringWriter(sbXML)
        Dim xmlwriter As New IMobileXMLWriter(stringwriter)
        Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces
        ns.Add("", "")

        Dim tablesequence As Integer = 1
        Dim count As Integer = 1
        xmlwriter.WriteStartElement("Data")
        ' In order to save it in the database, we want to consolidate all the table records into one collection
        ' and then store the serialized collection in the database.
        For Each oData In mDeviceDataNew.Values
            If Not mDeviceDataSame.ContainsKey(oData) Then
                If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
            End If
        Next

        For Each oData In mDeviceDataUpd.Values
            If Not mDeviceDataSame.ContainsKey(oData) Then
                If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
            End If
        Next

        For Each oData In mDeviceDataSame.Values
            If Not WriteElement(xmlwriter, count, tablesequence, sbXML, appDB, sInfobar, oData, tblData, SyncSettings) Then Return False
        Next

        'if this is just the open element <Data> there is nothing more to write.
        If sbXML.Length > 6 Then
            xmlwriter.WriteEndElement() '/Data
            If Not WriteData(appDB, tblData.sTableName, sbXML.ToString, tablesequence, sInfobar, SyncSettings) Then Return False
        End If
        Return True
    End Function

    Private Function WriteElement(ByRef xmlwriter As IMobileXMLWriter, ByRef count As Integer, ByRef tablesequence As Integer, ByRef sbXML As StringBuilder _
                             , ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef oData As String, ByRef tblData As clsTableData, ByRef SyncSettings As ClsSyncSettings) As Boolean
        xmlwriter.WriteStartElement("I")
        xmlwriter.WriteAttributeString("P", oData)
        xmlwriter.WriteEndElement() '/I
        count = count + 1
        If count > 199 Then
            xmlwriter.WriteEndElement() '/Data
            If Not WriteData(appDB, tblData.sTableName, sbXML.ToString, tablesequence, sInfobar, SyncSettings) Then Return False
            count = 1
            tablesequence = tablesequence + 1
            sbXML.Clear()
            xmlwriter.WriteStartElement("Data")
        End If
        Return True
    End Function

    Public Function WriteData(ByRef appDB As ApplicationDB, ByVal sTableName As String, ByVal sXML As String, ByVal tablesequence As Integer, ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings) As Boolean

        MGLog.LogMessage(SyncSettings.LogContext, LogMessageTypes.Trace, String.Format("Write Device Data for table: {0} sequence: {1}", sTableName, tablesequence.ToString()))
        Dim oParms As List(Of SqlParameter)
        Dim sbSQL As New StringBuilder
        sbSQL.AppendLine("INSERT INTO mobile_device_data(Device_ID, Sync_Sequence, device_data, table_name,app_name,username,device_name,table_sequence)")
        sbSQL.AppendLine("VALUES (@DeviceID, @SyncSequence, @XMLData, @TableName,@ApplicationId,@Username,@DeviceName,@TableSequence)")

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                           New SqlParameter("@SyncSequence", SyncSettings.DeviceSyncSeq),
                                                           New SqlParameter("@XMLData", sXML),
                                                           New SqlParameter("@TableName", sTableName),
                                                           New SqlParameter("@ApplicationId", SyncSettings.AppId),
                                                           New SqlParameter("@Username", SyncSettings.Username),
                                                           New SqlParameter("@TableSequence", tablesequence)
                                                      }

        If String.IsNullOrEmpty(SyncSettings.DeviceName) Then
            oParms.Add(New SqlParameter("@DeviceName", DBNull.Value))
        Else
            oParms.Add(New SqlParameter("@DeviceName", SyncSettings.DeviceName))
        End If

        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, sInfobar) Then Return False
        oParms = Nothing
        sXML = Nothing
        sbSQL = Nothing

        Return True
    End Function

    Public Function WriteTmpData(ByRef appDB As ApplicationDB, ByRef sInfobar As String, ByRef SyncSettings As ClsSyncSettings) As Boolean
        SyncSettings.TmpSequence = SyncSettings.TmpSequence + 1
        Dim oParms As List(Of SqlParameter)
        Dim sbSQL As New StringBuilder
        sbSQL.AppendLine("INSERT INTO mobile_device_data_sync(device_id,sequence, device_data,app_name,username)")
        sbSQL.AppendLine("VALUES (@DeviceID,@Sequence, @JSONData,@ApplicationId,@Username)")

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                           New SqlParameter("@Sequence", SyncSettings.TmpSequence),
                                                           New SqlParameter("@JSONData", SyncSettings.JSONOut),
                                                           New SqlParameter("@ApplicationId", SyncSettings.AppId),
                                                           New SqlParameter("@Username", SyncSettings.Username)
                                                      }

        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, sInfobar) Then Return False

        'reset json out and response size
        SyncSettings.JSONOut = ""
        SyncSettings.ResponseSize = 1
        oParms = Nothing
        sbSQL = Nothing
        Return True
    End Function

    Public Function ClearValidationRecord(ByRef appDB As ApplicationDB, ByRef SyncSettings As ClsSyncSettings, ByRef sInfobar As String) As Boolean
        Dim oParms As List(Of SqlParameter)
        Dim sbSQL As New StringBuilder

        sbSQL.AppendLine("DELETE FROM mobile_tmp_device_ido_validate")
        sbSQL.AppendLine("WHERE process_id = @DeviceID")

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID)}

        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, sInfobar) Then Return False

        'reset json out and response size
        SyncSettings.JSONOut = ""
        SyncSettings.ResponseSize = 1
        oParms = Nothing
        sbSQL = Nothing
        Return True
    End Function

    Public Function WriteValidationTotalRecord(ByRef appDB As ApplicationDB, ByRef SyncSettings As ClsSyncSettings, ByRef sInfobar As String) As Boolean
        Dim oParms As List(Of SqlParameter)
        Dim sbSQL As New StringBuilder
        Dim RecordCount As Integer
        Dim ResponseSize As Decimal

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID)}
        RecordCount = GetInteger(Lookup("SELECT SUM(record_count) AS RecordCount FROM mobile_tmp_device_ido_validate WHERE process_id = @DeviceID", appDB, oParms, SyncSettings))

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID)}
        ResponseSize = GetDecimal(Lookup("SELECT SUM(response_size) AS ResponseSize FROM mobile_tmp_device_ido_validate WHERE process_id = @DeviceID", appDB, oParms, SyncSettings))

        sbSQL.AppendLine("INSERT INTO mobile_tmp_device_ido_validate(process_id,ido_name,record_count,response_size,message)")
        sbSQL.AppendLine("VALUES (@DeviceID,@IDO,@RecordCount,@ResponseSize,@Message)")

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                 New SqlParameter("@IDO", GetStringValue("sTotal", appDB, SyncSettings)),
                                                 New SqlParameter("@RecordCount", RecordCount),
                                                 New SqlParameter("@ResponseSize", ResponseSize),
                                                 New SqlParameter("@Message", SyncSettings.ValidationMessage)
                                                }

        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, sInfobar) Then Return False

        'reset json out and response size
        SyncSettings.JSONOut = ""
        SyncSettings.ResponseSize = 0
        SyncSettings.TableSize = 0
        oParms = Nothing
        sbSQL = Nothing
        Return True
    End Function


    Public Function WriteValidationRecord(ByRef appDB As ApplicationDB, ByRef tbl As clsTableDataRS8416, ByRef SyncSettings As ClsSyncSettings, ByRef sInfobar As String) As Boolean
        Dim oParms As List(Of SqlParameter)
        Dim sbSQL As New StringBuilder

        If SyncSettings.ValidationMessage <> "" Then
            SyncSettings.ValidationMessage = String.Format("{0} {1}: {2}", SyncSettings.ValidationMessage, GetStringValue("sFilter", appDB, SyncSettings), tbl.sFilter)
        End If

        SyncSettings.TableSize = SyncSettings.TableSize + SyncSettings.JSONOut.Length / 1000000.0
        sbSQL.AppendLine("IF NOT EXISTS(SELECT 1 FROM mobile_tmp_device_ido_validate WHERE process_id = @DeviceID AND ido_name = @IDO)")
        sbSQL.AppendLine("INSERT INTO mobile_tmp_device_ido_validate(process_id,ido_name,record_count,response_size,message)")
        sbSQL.AppendLine("VALUES (@DeviceID,@IDO,@RecordCount,@ResponseSize,@Message)")

        oParms = New List(Of SqlParameter) From {New SqlParameter("@DeviceID", SyncSettings.DeviceID),
                                                 New SqlParameter("@IDO", tbl.sIDO),
                                                 New SqlParameter("@RecordCount", SyncSettings.RecordCount),
                                                 New SqlParameter("@ResponseSize", SyncSettings.TableSize),
                                                 New SqlParameter("@Message", SyncSettings.ValidationMessage)
                                                }

        If Not ExecuteSQLStatement(sbSQL.ToString, appDB, oParms, SyncSettings, sInfobar) Then Return False

        'reset json out and response size
        SyncSettings.JSONOut = ""
        SyncSettings.ResponseSize = 0
        SyncSettings.TableSize = 0
        SyncSettings.ValidationMessage = ""
        oParms = Nothing
        sbSQL = Nothing
        Return True
    End Function
#End Region

End Class

Public Class ClsSyncSettings
    Implements IDisposable
    Public ReadOnly AppId As String
    Public ReadOnly DeviceID As String
    Public ReadOnly DeviceName As String
    Public ReadOnly Username As String
    Public ParmSyncSeq As Integer
    Public IncludeImages As Boolean
    Public IncludeAttachments As Boolean
    Public AllowImages As Boolean = True
    Public AllowAttachments As Boolean = True
    Public ReadOnly Is915OrLater As Boolean
    Public CustomerFilter As Integer
    Public ItemFilter As Integer
    Public UnitFilter As Integer
    Public IncludeObsolete As Boolean
    Public IncludeSlowMoving As Boolean
    Public ReadOnly LastSyncDate As Date
    Public ClearOld As Boolean
    Public SuspendAddThisRecord As Boolean
    Public AllowDeviceSettings As Boolean = True
    Public DeviceSyncSeq As Integer
    Public TmpSequence As Integer
    Public PastHistory As Integer
    Public RecordCount As Integer
    Public PartnerId As String = ""
    Public PartnerWhse As String = ""
    Public FormServer As String = ""
    Public FormDatabase As String = ""
    Public UserStringsTable As String = ""
    Public HistoryCutoff As Date = New Date(1900, 1, 1)
    Public LogContext As String
    Public JSONOut As String
    Public TableSize As Decimal
    Public ValidationMessage As String = ""
    Public ResponseMultiplier As Integer = 1
    Public ResponseSize As Integer = 0
    Public MaxResponseSize As Integer = 2000000  'aprox 2 mb
    Public RecordPadding As Integer = 17 'json padding
    Public FieldPadding As Integer = 6 'json padding
    Public ResponseHeaderSize As Integer = 0
    Public CurrentDate As Date
    Sub New(ByVal appId As String,
    ByVal deviceID As String,
             ByVal deviceName As String,
        ByVal username As String,
        ByVal parmSyncSeq As Integer,
        ByVal includeImages As Boolean,
        ByVal includeDocuments As Boolean,
        ByVal is915OrLater As Boolean,
            ByVal customerFilter As Integer,
    ByVal itemFilter As Integer,
        ByVal unitFilter As Integer,
        ByVal includeObsolete As Boolean,
        ByVal includeSlowMoving As Boolean,
        ByVal lastSyncDate As Date,
            ByVal allowImages As Boolean,
            ByVal allowAttachments As Boolean)

        Me.AppId = appId
        Me.DeviceID = deviceID
        Me.DeviceName = deviceName
        Me.Username = username
        Me.ParmSyncSeq = parmSyncSeq
        Me.IncludeAttachments = includeDocuments
        Me.IncludeImages = includeImages
        Me.Is915OrLater = is915OrLater
        Me.CustomerFilter = customerFilter
        Me.ItemFilter = itemFilter
        Me.UnitFilter = unitFilter
        Me.IncludeSlowMoving = includeSlowMoving
        Me.IncludeObsolete = includeObsolete
        Me.LastSyncDate = lastSyncDate
        Me.AllowImages = allowImages
        Me.AllowAttachments = allowAttachments
        Me.DeviceSyncSeq = parmSyncSeq
        Me.TmpSequence = 0
        Me.JSONOut = ""
        ClearOld = False
        LogContext = appId
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        JSONOut = Nothing
    End Sub
End Class


Public Class clsTableData
    Implements IDisposable
    Public sTableName As String
    Public sTableView As String
    Public sIDO As String
    Public sAlias As String
    Public doNotes As Boolean
    Public doDocs As Boolean
    Public DeferProcess As Boolean
    Public IsHierarchical As Boolean
    Public CreateTempTable As Boolean
    Public TempTable As String
    Public sFilter As String
    Public dt As DataTable
    Public outTable As DataTable
    Public fields As List(Of clsFieldData)
    Public joins As List(Of String)
    Public SecondaryJoins As Dictionary(Of String, String)
    Public DateColumns As List(Of String)
    Public Parms As List(Of SqlParameter)

    Sub New()
    End Sub

    Sub New(ByVal sTableName As String,
            ByVal sIDO As String,
            ByVal sAlias As String,
            ByVal doNotes As Boolean,
            ByVal doDocs As Boolean,
            ByVal sFilter As String,
            Optional ByVal Parms As List(Of SqlParameter) = Nothing,
            Optional ByVal TableView As String = "",
            Optional ByVal TempTable As String = "",
            Optional ByVal DeferProcess As Boolean = False,
            Optional ByVal CreateTempTable As Boolean = False,
            Optional ByVal IsHierarchical As Boolean = False)

        Me.sTableName = sTableName
        Me.sIDO = sIDO
        Me.sAlias = sAlias
        Me.doDocs = doDocs
        Me.doNotes = doNotes
        Me.sFilter = sFilter
        Me.Parms = Parms
        Me.TempTable = TempTable
        Me.DeferProcess = DeferProcess
        Me.IsHierarchical = IsHierarchical
        Me.CreateTempTable = CreateTempTable
        sTableView = TableView
        Me.fields = New List(Of clsFieldData)()
        fields.Add(New clsFieldData("", "_ItemId"))
        fields.Add(New clsFieldData("", "ToRemove"))
        fields.Add(New clsFieldData("", "ToInsert"))
        fields.Add(New clsFieldData("", "NativeGetImage"))
        If sTableView = "" Then
            fields.Add(New clsFieldData("RowPointer", "RowPointer", sTableName + ".RowPointer", "uniqueidentifier"))
            fields.Add(New clsFieldData("RecordDate", "RecordDate", "CONVERT(NVARCHAR," + sTableName + ".RecordDate,121) AS RecordDate", "NVARCHAR(25)", True))
        Else
            fields.Add(New clsFieldData("RowPointer", "RowPointer", sTableView + ".RowPointer", "uniqueidentifier"))
            fields.Add(New clsFieldData("RecordDate", "RecordDate", "CONVERT(NVARCHAR," + sTableView + ".RecordDate,121) AS RecordDate", "NVARCHAR(25)", True))
        End If
        joins = New List(Of String)
        SecondaryJoins = New Dictionary(Of String, String)
        DateColumns = New List(Of String)

    End Sub

    Sub BuildOutTable()
        outTable = New DataTable With {
            .TableName = sIDO
        }
        Dim scolumns As String = ""
        For Each fieldData As clsFieldData In fields
            'If fieldData.sField <> "" And fieldData.sProperty <> "" Then
            '    outTable.Columns.Add(fieldData.sProperty, dt.Columns(fieldData.sField).DataType)
            'Else
            If fieldData.sProperty <> "" Then
                outTable.Columns.Add(fieldData.sProperty, GetType(String))  'treat all columns as strings for output to allow nulls
            End If

            If fieldData.bDate Then
                DateColumns.Add(fieldData.sField)
            End If
        Next
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose

        If dt IsNot Nothing Then
            dt.Clear()
            dt.Columns.Clear()
            dt.Dispose()
        End If
        If outTable IsNot Nothing Then
            outTable.Clear()
            outTable.Columns.Clear()
            outTable.Dispose()
        End If

        If fields IsNot Nothing Then
            fields.Clear()
        End If

        If joins IsNot Nothing Then
            joins.Clear()
        End If
        If SecondaryJoins IsNot Nothing Then
            SecondaryJoins.Clear()
        End If
        If DateColumns IsNot Nothing Then
            DateColumns.Clear()
        End If

    End Sub
End Class


Public Class clsFieldData
    Public sField As String
    Public sProperty As String
    Public sExpression As String
    Public bDate As Boolean
    Public bKeyField As Boolean
    Public sSQLType As String
    Public HierarchicalParent As Boolean
    Public HierarchicalChild As Boolean
    Sub New(ByVal sField As String,
            ByVal sProperty As String,
            Optional ByVal sExpression As String = "",
            Optional ByVal sSQLType As String = "",
            Optional ByVal bDate As Boolean = False,
            Optional ByVal bKeyField As Boolean = False,
            Optional ByVal HierarchicalParent As Boolean = False,
            Optional ByVal HierarchicalChild As Boolean = False
            )

        Me.sField = sField
        Me.sProperty = sProperty
        Me.sExpression = sExpression
        Me.sSQLType = sSQLType
        Me.bDate = bDate
        Me.HierarchicalParent = HierarchicalParent
        Me.HierarchicalChild = HierarchicalChild
        Me.bKeyField = bKeyField
    End Sub

    Public Function GetKey() As String
        Return Me.sField
    End Function

End Class

Public Class clsTableDataRS8416
    Implements IDisposable
    Public sTableName As String
    Public sTableView As String
    Public sIDO As String
    Public sAlias As String
    Public doNotes As Boolean
    Public doDocs As Boolean
    Public DeferProcess As Boolean
    Public IsHierarchical As Boolean
    Public CreateTempTable As Boolean
    Public TempTable As String
    Public sFilter As String
    Public dt As DataTable
    Public outTable As DataTable
    Public fields As Dictionary(Of String, clsFieldDataRS8416)
    Public AddlJoins As List(Of String)
    Public Joins As Dictionary(Of String, String)
    Public SecondaryJoins As Dictionary(Of String, String)
    Public DateColumns As List(Of String)
    Public Parms As List(Of SqlParameter)
    Public IsCustom As Boolean
    Public ParentLinks
    Sub New()
    End Sub

    Sub New(ByVal sTableName As String,
            ByVal sIDO As String,
            ByVal sAlias As String,
            ByVal doNotes As Boolean,
            ByVal doDocs As Boolean,
            ByVal sFilter As String,
            Optional ByVal Parms As List(Of SqlParameter) = Nothing,
            Optional ByVal TableView As String = "",
            Optional ByVal TempTable As String = "",
            Optional ByVal DeferProcess As Boolean = False,
            Optional ByVal CreateTempTable As Boolean = False,
            Optional ByVal IsHierarchical As Boolean = False,
            Optional ByVal IsCustom As Boolean = False)

        Me.sTableName = sTableName
        Me.sIDO = sIDO
        Me.sAlias = sAlias
        Me.doDocs = doDocs
        Me.doNotes = doNotes
        Me.sFilter = sFilter
        Me.Parms = Parms
        Me.TempTable = TempTable
        Me.DeferProcess = DeferProcess
        Me.IsHierarchical = IsHierarchical
        Me.CreateTempTable = CreateTempTable
        Me.IsCustom = IsCustom
        sTableView = TableView
        Me.fields = New Dictionary(Of String, clsFieldDataRS8416)()
        fields.Add("_ItemId", New clsFieldDataRS8416("", "_ItemId"))
        fields.Add("ToRemove", New clsFieldDataRS8416("", "ToRemove"))
        fields.Add("ToInsert", New clsFieldDataRS8416("", "ToInsert"))
        fields.Add("NativeGetImage", New clsFieldDataRS8416("", "NativeGetImage"))
        If sTableView = "" Then
            fields.Add("RowPointer", New clsFieldDataRS8416("RowPointer", "RowPointer", sAlias + ".RowPointer", "uniqueidentifier"))
            fields.Add("RecordDate", New clsFieldDataRS8416("RecordDate", "RecordDate", "CONVERT(NVARCHAR," + sAlias + ".RecordDate,121) AS RecordDate", "NVARCHAR(25)", True))
        Else
            fields.Add("RowPointer", New clsFieldDataRS8416("RowPointer", "RowPointer", sAlias + ".RowPointer", "uniqueidentifier"))
            fields.Add("RecordDate", New clsFieldDataRS8416("RecordDate", "RecordDate", "CONVERT(NVARCHAR," + sAlias + ".RecordDate,121) AS RecordDate", "NVARCHAR(25)", True))
        End If
        Joins = New Dictionary(Of String, String)
        AddlJoins = New List(Of String)
        SecondaryJoins = New Dictionary(Of String, String)
        DateColumns = New List(Of String)

    End Sub

    Sub BuildOutTable()
        outTable = New DataTable With {
            .TableName = sIDO
        }
        Dim scolumns As String = ""

        If IsCustom AndAlso Not fields.ContainsKey("IDO") Then
            outTable.Columns.Add("IDO", GetType(String))
        End If

        For Each fieldData As clsFieldDataRS8416 In fields.Values
            'If fieldData.sField <> "" And fieldData.sProperty <> "" Then
            '    outTable.Columns.Add(fieldData.sProperty, dt.Columns(fieldData.sField).DataType)
            'Else
            If fieldData.sProperty <> "" Then
                outTable.Columns.Add(fieldData.sProperty, GetType(String))  'treat all columns as strings for output to allow nulls
            End If

            If fieldData.bDate Then
                DateColumns.Add(fieldData.sField)
            End If
        Next
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose

        If dt IsNot Nothing Then
            dt.Clear()
            dt.Columns.Clear()
            dt.Dispose()
        End If
        If outTable IsNot Nothing Then
            outTable.Clear()
            outTable.Columns.Clear()
            outTable.Dispose()
        End If

        If fields IsNot Nothing Then
            fields.Clear()
        End If

        If Joins IsNot Nothing Then
            Joins.Clear()
        End If
        If SecondaryJoins IsNot Nothing Then
            SecondaryJoins.Clear()
        End If
        If DateColumns IsNot Nothing Then
            DateColumns.Clear()
        End If

    End Sub
End Class

Public Class clsFieldDataRS8416
    Public sField As String
    Public sProperty As String
    Public sExpression As String
    Public bDate As Boolean
    Public bKeyField As Boolean
    Public sSQLType As String
    Public HierarchicalParent As Boolean
    Public HierarchicalChild As Boolean
    Public Translate As Boolean
    Sub New(ByVal sField As String,
            ByVal sProperty As String,
            Optional ByVal sExpression As String = "",
            Optional ByVal sSQLType As String = "",
            Optional ByVal bDate As Boolean = False,
            Optional ByVal bKeyField As Boolean = False,
                     Optional ByVal HierarchicalParent As Boolean = False,
                     Optional ByVal HierarchicalChild As Boolean = False,
            Optional ByVal Translate As Boolean = False
            )

        Me.sField = sField
        Me.sProperty = sProperty
        Me.sExpression = sExpression
        Me.sSQLType = sSQLType
        Me.bDate = bDate
        Me.HierarchicalParent = HierarchicalParent
        Me.HierarchicalChild = HierarchicalChild
        Me.bKeyField = bKeyField
        Me.Translate = Translate
    End Sub

    Public Function GetKey() As String
        Return Me.sField
    End Function

End Class

Public Class IMobileXMLWriter

    ' The entire purpose of this routine is to prevent the "Header" from being written into the XML
    ' We don't need it and want to cut down on space!
    Inherits System.Xml.XmlTextWriter

    Public Sub New(ByVal w As System.IO.TextWriter)
        MyBase.New(w)
    End Sub

    Public Overrides Sub WriteStartDocument()
        ' DO NOTHING!
    End Sub

End Class


