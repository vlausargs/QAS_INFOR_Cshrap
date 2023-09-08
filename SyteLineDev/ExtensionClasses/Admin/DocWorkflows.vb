Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Infor.DocumentManagement.ICP
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO
Imports Mongoose.Core.Common
Imports System.IO
Imports System.Data
Imports System.Collections
Imports System.Text.RegularExpressions

<IDOExtensionClass("DocWorkflows")>
Public Class DocWorkflows
    Inherits ExtensionClassBase

    Private Function CheckFeatureActive(featureID As String) As Boolean
        CheckFeatureActive = False

        Dim IDOrequest As New LoadCollectionRequestData()
        Dim IDOresponse As LoadCollectionResponseData = Nothing

        IDOrequest.IDOName = "AppFeatures"
        IDOrequest.Filter = String.Format("ProductName='CSI' AND FeatureId ='{0}' AND Active=1", featureID)

        IDOrequest.RecordCap = 1
        IDOresponse = Me.Context.Commands.LoadCollection(IDOrequest)

        If IDOresponse.Items.Count = 1 Then
            CheckFeatureActive = True
        End If
    End Function

    'CSIB-23162: Check external app parameters for IDM is missing or not
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsIDMExternalParametersMissing() As Boolean
        IsIDMExternalParametersMissing = True

        Dim IDOrequest As New LoadCollectionRequestData()
        Dim IDOresponse As LoadCollectionResponseData = Nothing

        IDOrequest.IDOName = "ExternalAppParameters"
        IDOrequest.Filter = "AppName='IDM'"

        IDOrequest.RecordCap = 1
        IDOresponse = Me.Context.Commands.LoadCollection(IDOrequest)

        If IDOresponse.Items.Count = 1 Then
            IsIDMExternalParametersMissing = False
        End If
    End Function

    Public Overrides Sub SetContext(context As IIDOExtensionClassContext)
        MyBase.SetContext(context)
    End Sub
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AddContentToIDMFromEventReceivePID(EntityName As String, EntityType As String, AccountingEntity As String, Filename As String, Description As String, TenantID As String,
        IFSUserGuid As String, EventStateId As String, IdoCollection As String, IdoPropertyList As String, IdoFilter As String, ByRef ObjectName As String,
        ByRef RefRowPointer As String, ByRef pid As String, ByRef id As String, ByRef version As System.Nullable(Of Integer), ByRef errMsg As String, ByRef rc As Integer, TaskNumber As Decimal) As Integer
        errMsg = String.Empty
        pid = String.Empty
        id = String.Empty
        version = 0
        ObjectName = String.Empty
        RefRowPointer = String.Empty

        'Remove LIT~
        IdoFilter = ReplaceLITKeywords(IdoFilter)
        Description = ReplaceLITKeywords(Description)

        rc = 16
        Dim DocName As String = Filename.Substring(Filename.LastIndexOf("\") + 1)
        If Description Is Nothing Then
            Description = EntityType
        End If


        'Create fixed attribute list
        Dim AdditionalAttributes As New List(Of String)(New String() {"Description", "EntityType", "AccountingEntity"})

        Try
            'Lookup IdoCollection's BaseTable for ObjectName
            Dim IDOrequest As New LoadCollectionRequestData("IdoTables", "CollectionName, TableName", (Convert.ToString("CollectionName='") & IdoCollection) + "' AND TableType=3 AND JoinType=0", "", 1)
            Dim IDOresponse As LoadCollectionResponseData = Nothing
            IDOresponse = Me.Context.Commands.LoadCollection(IDOrequest)

            For Each ii As IDOItem In IDOresponse.Items
                'TableName
                ObjectName = ii.PropertyValues(1).Value.ToString()
            Next


            Dim strIdoSubColNames As New List(Of String)(New String() {})

            Dim dtSubCollecitons As New DataTable()
            dtSubCollecitons.Columns.Add("SubColName", GetType(String))
            dtSubCollecitons.Columns.Add("SubColProp", GetType(String))

            If CheckFeatureActive("RS8485") Then 'RS8485 feature enabled then do multi-value update
                'Check IdoPropertyList contains Subcollcetion or not
                AdditionalAttributes = New List(Of String)(New String() {"Description", "EntityType", "AccountingEntity", "TaskNumber"})

                If IdoPropertyList.Contains(".") Then
                    Dim strIdoProperties() As String

                    strIdoProperties = IdoPropertyList.Split(","c)

                    For Each strIdoProperty As String In strIdoProperties
                        Dim strIdoSubColProp As String
                        Dim strSubCollectionName As String

                        If strIdoProperty.Contains(".") Then 'Has Subcollection
                            strSubCollectionName = strIdoProperty.Substring(0, strIdoProperty.IndexOf(".")).Trim()
                            strIdoSubColProp = strIdoProperty.Substring(strIdoProperty.IndexOf(".") + 1).Trim()

                            If strIdoSubColNames.Contains(strSubCollectionName) = False Then
                                strIdoSubColNames.Add(strSubCollectionName)
                            End If

                            Dim drIdoSub As DataRow = dtSubCollecitons.NewRow()
                            drIdoSub(0) = strSubCollectionName
                            drIdoSub(1) = strIdoSubColProp
                            dtSubCollecitons.Rows.Add(drIdoSub)
                            dtSubCollecitons.AcceptChanges()

                            IdoPropertyList = IdoPropertyList.Remove(IdoPropertyList.IndexOf(strIdoProperty) - 1, strIdoProperty.Length + 1)

                        End If
                    Next

                End If

            End If


            'Get Name/Value pairs for IdoPropertyList
            Dim dt As New DataTable()
            Dim reader As New DataTableReader(CLM_GetIDONameValueData(IdoCollection, IdoPropertyList, IdoFilter))
            dt.Load(reader)

            'add rows for attribute values from input parms
            For Each attr As String In AdditionalAttributes
                Dim rw As DataRow = dt.NewRow()
                rw("Name") = attr.ToString()
                rw("Datatype") = "String"
                Select Case attr.ToString()
                    Case "EntityType"
                        rw("Value") = EntityType
                        Exit Select
                    Case "Description"
                        rw("Value") = Description
                        Exit Select
                    Case "AccountingEntity"
                        rw("Value") = AccountingEntity
                        Exit Select
                    Case "TaskNumber" 'RS8485
                        rw("Value") = TaskNumber
                        Exit Select
                End Select

                dt.Rows.Add(rw)
            Next

            'Get File from Event Attachment
            Dim DocRequest As New LoadCollectionRequestData("DocumentObjectAndRefViews", "DocumentObjectRowPointer, DocumentObject", "TableName = 'EventState' AND TableRowPointer = " + SqlLiteral.Format(EventStateId.ToString(), SqlLiteralFormatFlags.UseQuotes), String.Empty, 1)
            Dim DocResponse As New LoadCollectionResponseData()
            DocResponse = Me.Context.Commands.LoadCollection(DocRequest)

            If DocResponse.Items.Count = 0 Then
                errMsg = "Unable to retrieve document from event - check IDO permission or licensing for DocumentObjectAndRefViews IDO or Row Authorizations for user or document type group"
                rc = 16
                Return 0
            End If

            'serialize attachment to byte array
            Dim byteArr As Byte() = DocResponse.Items(0).PropertyValues(1).GetValue(Of [Byte]())()

            'assign byte array as resource
            Dim res As New CMResource(DocName, byteArr)

            'define ACL = EntityType
            Dim ACLList As New CMAccessControlList(EntityType)

            'create search string
            Dim SearchString As String = IdoFilter.Replace("'", """")

            'create IDM item and assign static properties
            Dim item As New CMItem With {
                .EntityName = EntityName,
                .Filename = Filename,
                .AccessControlList = ACLList
            }


            'Set attributes from name/value pair
            For Each row As DataRow In dt.Rows
                Select Case row("Name").ToString()
                    Case "RowPointer"
                        RefRowPointer = row("Value").ToString()
                        'assign RefRowPointer
                        Exit Select
                    Case Else
                        item.SetAttributeValue(row("Name").ToString(), row("Value").ToString())

                        Exit Select
                End Select
                SearchString = SearchString.Replace(row("Name").ToString(), "@" & row("Name").ToString())
            Next

            If CheckFeatureActive("RS8485") Then 'RS8485 feature enabled then do multi-value update
                'All properties in subcollections will map to MVA, the following code is update MVA value
                If dtSubCollecitons.Rows.Count > 0 Then
                    Dim dtSub As New DataTable()

                    For Each strSubColName As String In strIdoSubColNames
                        Dim strCurSubColPropList As String = ""

                        For Each dr As DataRow In dtSubCollecitons.Select("SubColName='" & strSubColName & "'")
                            strCurSubColPropList = strCurSubColPropList & dr("SubColProp").ToString() & ","
                        Next

                        strCurSubColPropList = strCurSubColPropList.TrimEnd(","c)

                        Dim subreader As New DataTableReader(CLM_GetSubIDONameValueData(strSubColName, strCurSubColPropList, IdoFilter))
                        dtSub.Load(subreader)


                        'update MVA
                        Dim strAttrMVAs As String() = strCurSubColPropList.Split(","c)
                        For Each strAttrMVA As String In strAttrMVAs
                            Dim cmcMVAs As New CMCollections With {
                                .Name = strAttrMVA
                            }

                            For Each drAttr As DataRow In dtSub.Select("Name='" & strAttrMVA & "'")
                                Dim cmcMVA As New CMCollection With {
                                    .EntityName = strAttrMVA
                                }
                                cmcMVA.SetAttributeValue(strAttrMVA, drAttr("Value").ToString())
                                cmcMVAs.Add(cmcMVA)
                            Next
                            'MVA update
                            item.AddCollections(cmcMVAs)
                        Next

                    Next


                End If
                'New added attribute TaskNumber, if its value is not null, the document generated by CSI
                SearchString = SearchString & " AND @TaskNumber IS NOT NULL"
            End If

            SearchString = "[@EntityType=""" & EntityType & """ AND " & SearchString & "]"
            SearchString = (Convert.ToString("/") & EntityName) & SearchString

            item.Resources.Add(res)

            'connect to IDM
            Dim testAP As AuthParms = GetConnectionParms("IDM")
            Dim conn As New Connection(testAP.BaseURL, testAP.Username, testAP.Password, testAP.AuthMethod) With {
                .Tenant = TenantID,
                .Username = IFSUserGuid
            }
            conn.Connect(False)


            'search IDM for existing document - update it if present, otherwise insert new one
            Dim items As CMItems = CMItems.Search(conn, SearchString, CMItems.SearchRetrieveFirstIndex, 1)
            If items.Count > 0 Then
                item.Pid = items(0).Pid
                item.Update(conn, True, True, False)
            Else
                item.Add(conn)
            End If

            'retrieve IDM identifiers
            pid = item.Pid
            'get IDM PID example CS_SalesInvoice_27_2_LATEST
            id = item.Id
            'get IDM ID example 27
            version = item.Version

            conn.DisconnectSilent()
            rc = 0
            Return 0
        Catch exp As Exception
            errMsg = exp.Message.Replace("<td><img id='logo' src='/grid/ui/?img=/img/image_grid_icon64.png' /></td>", "")

            If GetInnerExceptionMessage(exp) IsNot Nothing Then
                errMsg = (errMsg & Convert.ToString(" Details: ")) + GetInnerExceptionMessage(exp)
            End If

            rc = 16
            Return 0
        End Try

    End Function

    Private Function GetInnerExceptionMessage(ByVal exp As Exception) As String
        Try
            If exp.InnerException.Message.ToString() IsNot Nothing Then
                Return exp.InnerException.Message.ToString()
            End If

            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CLM_GetIDONameValueData(IDOName As String, PropList As [String], Filter As String) As DataTable
        'add RowPointer to property list
        PropList += ",RowPointer"

        'Remove LIT~
        Filter = ReplaceLITKeywords(Filter)

        'convert property list to array
        Dim aryPropList As String() = PropList.Split(","c)
        For i As Integer = 0 To aryPropList.Length - 1
            aryPropList(i) = aryPropList(i).Trim()
        Next

        'create datatable to store name,value,datatype data
        Dim dt As New DataTable()
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Columns.Add("Datatype", GetType(String))

        Try
            'retrieve collection 
            Dim IDOrequest As New LoadCollectionRequestData()
            Dim IDOresponse As LoadCollectionResponseData = Nothing

            Dim propInfo As New GetPropertyInfoResponseData()

            propInfo = Me.Context.Commands.GetPropertyInfo(IDOName)

            IDOrequest.IDOName = IDOName
            IDOrequest.PropertyList.SetProperties(aryPropList)
            IDOrequest.Filter = Filter
            IDOrequest.RecordCap = 1
            IDOresponse = Me.Context.Commands.LoadCollection(IDOrequest)

            'loop through properties & assign values to datatable rows
            For Each ii As IDOItem In IDOresponse.Items
                For i As Integer = 0 To aryPropList.Length - 1
                    Dim row As DataRow = dt.NewRow()
                    row("Name") = aryPropList(i).ToString()

                    For Each idoprop As PropertyInfo In propInfo.Properties
                        If idoprop.Name = aryPropList(i).ToString() Then
                            Select Case idoprop.DataType
                                Case "NumSortedString"
                                    row("Datatype") = "String"
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                                Case "Date"
                                    row("Datatype") = idoprop.DataType
                                    row("Value") = ii.PropertyValues(i).GetValue(Of DateTime)().ToString("yyyy-MM-ddTHH:mm:ssK")
                                    Exit Select
                                Case "GUID"
                                    row("Datatype") = "String"
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                                Case Else
                                    row("Datatype") = idoprop.DataType
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                            End Select

                        End If
                    Next
                    dt.Rows.Add(row)
                Next
            Next

        Catch ex As Exception

        Finally
        End Try
        Return dt
    End Function

    Public Function CLM_GetSubIDONameValueData(IDOName As String, PropList As [String], Filter As String) As DataTable
        'add RowPointer to property list
        PropList += ",RowPointer"

        'Remove LIT~
        Filter = ReplaceLITKeywords(Filter)

        'convert property list to array
        Dim aryPropList As String() = PropList.Split(","c)
        For i As Integer = 0 To aryPropList.Length - 1
            aryPropList(i) = aryPropList(i).Trim()
        Next

        'create datatable to store name,value,datatype data
        Dim dt As New DataTable()
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Columns.Add("Datatype", GetType(String))

        Try
            'retrieve collection 
            Dim IDOrequest As New LoadCollectionRequestData()
            Dim IDOresponse As LoadCollectionResponseData = Nothing

            Dim propInfo As New GetPropertyInfoResponseData()

            propInfo = Me.Context.Commands.GetPropertyInfo(IDOName)

            IDOrequest.IDOName = IDOName
            IDOrequest.PropertyList.SetProperties(aryPropList)
            IDOrequest.Filter = Filter
            IDOrequest.RecordCap = 0
            IDOresponse = Me.Context.Commands.LoadCollection(IDOrequest)

            'loop through properties & assign values to datatable rows
            For Each ii As IDOItem In IDOresponse.Items
                For i As Integer = 0 To aryPropList.Length - 1
                    Dim row As DataRow = dt.NewRow()
                    row("Name") = aryPropList(i).ToString()

                    For Each idoprop As PropertyInfo In propInfo.Properties
                        If idoprop.Name = aryPropList(i).ToString() Then
                            Select Case idoprop.DataType
                                Case "NumSortedString"
                                    row("Datatype") = "String"
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                                Case "Date"
                                    row("Datatype") = idoprop.DataType
                                    row("Value") = ii.PropertyValues(i).GetValue(Of DateTime)().ToString("yyyy-MM-ddTHH:mm:ssK")
                                    Exit Select
                                Case "GUID"
                                    row("Datatype") = "String"
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                                Case Else
                                    row("Datatype") = idoprop.DataType
                                    row("Value") = ii.PropertyValues(i).GetValue("").ToString()
                                    Exit Select
                            End Select

                        End If
                    Next
                    dt.Rows.Add(row)
                Next
            Next

        Catch ex As Exception

        Finally
        End Try
        Return dt
    End Function

    Private Function GetConnectionParms(AppName As String) As AuthParms
        Try
            Dim ap As New AuthParms()
            'get IDM connection info
            Dim Request As New LoadCollectionRequestData("ExternalAppParameters", "AppName, BaseURL, UserName, UserPassword, AuthMethod, IsActive", "IsActive=1 AND AppName = " + SqlLiteral.Format(AppName.ToString(), SqlLiteralFormatFlags.UseQuotes), String.Empty, 1)
            Dim Response As New LoadCollectionResponseData()
            Response = Me.Context.Commands.LoadCollection(Request)
            For Each ii As IDOItem In Response.Items
                ap.BaseURL = ii.PropertyValues(1).GetValue(String.Empty)
                ap.Username = ii.PropertyValues(2).GetValue(String.Empty)
                ap.Password = Crypto.DecryptLogonString_AES(ii.PropertyValues(3).GetValue(String.Empty))
                ap.AuthMethod = DirectCast([Enum].Parse(GetType(AuthenticationMode), ii.PropertyValues(4).GetValue(String.Empty)), AuthenticationMode)
            Next
            Return ap
        Catch exp As Exception
            Return Nothing
        End Try
    End Function

    ' Returning a parameter string, replacing ~LIT~ keywords, if needed.
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ReplaceLITKeywordsInParms(ByRef taskParms As String) As Integer

        Dim parmRegex As New Regex("~LIT~\((?<LiteralValue>(?>\((?<DEPTH>)|\)(?<-DEPTH>)|.?)*(?(DEPTH)(?!)))\)", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        Dim parmValue As String = String.Empty

        For Each reportParm As Match In parmRegex.Matches(taskParms)
            parmValue = reportParm.Groups("LiteralValue").Value
            taskParms = taskParms.Replace(reportParm.Value, parmValue)
        Next
        Return 0
    End Function
    Private Function ReplaceLITKeywords(ByRef taskParms As String) As String

        Dim parmRegex As New Regex("~LIT~\((?<LiteralValue>(?>\((?<DEPTH>)|\)(?<-DEPTH>)|.?)*(?(DEPTH)(?!)))\)", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        Dim parmValue As String = String.Empty

        For Each reportParm As Match In parmRegex.Matches(taskParms)
            parmValue = reportParm.Groups("LiteralValue").Value
            taskParms = taskParms.Replace(reportParm.Value, parmValue)
        Next
        Return taskParms
    End Function

    Public Class AuthParms
        Private pBaseURL As String
        Private pUsername As String
        Private pPsWord As String
        Private pAuthMethod As AuthenticationMode

        Public Property BaseURL() As String
            Get
                Return pBaseURL
            End Get
            Set(value As String)
                pBaseURL = value
            End Set
        End Property
        Public Property Username() As String
            Get
                Return pUsername
            End Get
            Set(value As String)
                pUsername = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return pPsWord
            End Get
            Set(value As String)
                pPsWord = value
            End Set
        End Property
        Public Property AuthMethod() As AuthenticationMode
            Get
                Return pAuthMethod
            End Get
            Set(value As AuthenticationMode)
                pAuthMethod = value
            End Set
        End Property
    End Class
End Class