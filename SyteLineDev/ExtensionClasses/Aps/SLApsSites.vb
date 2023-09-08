Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Aps.ServerService
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports CSI.Data.SQL.UDDT
Imports CSI.MG
Imports CSI.Production.APS
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLApsSites")> _
Public Class SLApsSites
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApsServerStatus(
        ByVal HostName As String,
        ByVal PortNo As String,
        ByRef IsRunning As String,
        ByRef Infobar As String) As Integer

        Infobar = String.Empty
        IsRunning = "0"

        Dim oAps As New Aps.MasterService
        Dim uApsServerStatus As New Aps.MasterService.GetAPSServerServiceStatus_s

        Try
            uApsServerStatus.server_service_host = HostName
            uApsServerStatus.server_service_port = Convert.ToInt32(PortNo)
            oAps.cGetAPSServerServiceStatus(uApsServerStatus)
            If uApsServerStatus.return_code <> Aps.MasterService.APS_ERR_OK Then
                Infobar = uApsServerStatus.return_message
                GetApsServerStatus = 16
                Exit Function
            End If
            IsRunning = Convert.ToString(uApsServerStatus.is_running)
        Catch ex As Exception
            Infobar = ex.Message
            GetApsServerStatus = 16
            Exit Function
        End Try

        GetApsServerStatus = 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function StartApsServer(
        ByVal ServerHostName As String,
        ByVal PortNo As String,
        ByVal SQLHostName As String,
        ByVal SQLDbName As String,
        ByVal SQLUser As String,
        ByVal SQLPassword As String,
        ByVal AlwaysOn As String,
        ByVal Site As String,
        ByVal AltNo As String,
        ByRef ReturnCode As String,
        ByRef Infobar As String) As Integer

        Infobar = String.Empty

        Dim oAps As New Aps.MasterService
        Dim uApsStartApsServer As New Aps.MasterService.StartAPSServerService_s

        Try
            uApsStartApsServer.server_service_host = ServerHostName
            uApsStartApsServer.server_service_port = Convert.ToInt32(PortNo)
            uApsStartApsServer.sql_host = SQLHostName
            uApsStartApsServer.sql_database = SQLDbName
            uApsStartApsServer.sql_user = SQLUser
            uApsStartApsServer.sql_pfield = SQLPassword
            uApsStartApsServer.sql_pfield_encrypted = 1
            uApsStartApsServer.sql_alwayson = Convert.ToInt32(AlwaysOn)
            uApsStartApsServer.syteline_site = Site
            uApsStartApsServer.alternative = Convert.ToInt32(AltNo)
            oAps.cStartAPSServerService(uApsStartApsServer)
            ReturnCode = Convert.ToString(uApsStartApsServer.return_code)
            If uApsStartApsServer.return_code <> Aps.MasterService.APS_ERR_OK Then
                Infobar = uApsStartApsServer.return_message
                StartApsServer = 16
                Exit Function
            End If
        Catch ex As Exception
            Infobar = ex.Message
            StartApsServer = 16
            Exit Function
        End Try

        StartApsServer = 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function StopApsServer(
        ByVal ServerHostName As String, _
        ByVal PortNo As String, _
        ByRef ReturnCode As String, _
        ByRef Infobar As String) As Integer

        Infobar = String.Empty

        Dim oAps As New Aps.MasterService
        Dim uApsStopApsServer As New Aps.MasterService.StopAPSServerService_s

        Try
            uApsStopApsServer.server_service_host = ServerHostName
            uApsStopApsServer.server_service_port = Convert.ToInt32(PortNo)
            oAps.cStopAPSServerService(uApsStopApsServer)
            ReturnCode = Convert.ToString(uApsStopApsServer.return_code)
            If uApsStopApsServer.return_code <> Aps.MasterService.APS_ERR_OK
                Infobar = uApsStopApsServer.return_message
                StopApsServer = 16
                Exit Function
            End If
        Catch ex As Exception
            Infobar = ex.Message
            StopApsServer = 16
            Exit Function
        End Try

        StopApsServer = 0

    End Function

    ReadOnly ByteStream1() As Byte = {&HFF, &HEE, &HDD, &HCC, &HBB, &HAA, &H99, &H88, &H77, &H66, &H55, &H44, &H33, &H22, &H11, &H0}
    ReadOnly ByteStream2() As Byte = {&HF, &H1E, &H2D, &H3C, &H4B, &H5A, &H69, &H78, &H87, &H96, &HA5, &HB4, &HC3, &HD2, &HE1, &HF0}


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EncryptString(ByVal PlainText As String, ByRef EncryptedText As String, ByRef Infobar As String) As Integer
        Infobar = String.Empty
        EncryptedText = ""

        Try
            EncryptedText = Encrypt(PlainText, ByteStream1, ByteStream2)
        Catch ex As Exception
            Infobar = ex.Message
            EncryptString = 16
            Exit Function
        End Try

        EncryptString = 0
    End Function

    Private Function Encrypt(ByVal plainText As String,
                             ByVal passPhrase As Byte(),
                             ByVal initVector As Byte()) As String

        Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim cipherText As String

        Using aesAlg As New AesCryptoServiceProvider
            aesAlg.Mode = CipherMode.CBC
            aesAlg.Key = passPhrase
            aesAlg.IV = initVector
            aesAlg.Padding = PaddingMode.PKCS7
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, aesAlg.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(plainBytes, 0, plainBytes.Length)
                    cs.Close()
                End Using
                cipherText = "=01" + Convert.ToBase64String(ms.ToArray())
            End Using
        End Using

        Return cipherText
    End Function

    Private Function Decrypt(ByVal cipherText As String,
                             ByVal passPhrase As Byte(),
                             ByVal initVector As Byte()) As String

        Dim version As Integer

        If Left(cipherText, 1) = "=" Then
            version = CInt(cipherText.Substring(1, 2))
            cipherText = cipherText.Substring(3)
        Else
            version = 0
        End If

        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim plainText As String

        Using aesAlg As New AesCryptoServiceProvider
            aesAlg.Mode = CipherMode.CBC
            aesAlg.Key = passPhrase
            aesAlg.IV = initVector
            If version = 0 Then
                aesAlg.Padding = PaddingMode.Zeros
            ElseIf version = 1 Then
                aesAlg.Padding = PaddingMode.PKCS7
            End If
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, aesAlg.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                plainText = Encoding.UTF8.GetString(ms.ToArray()).TrimEnd({Chr(0)})
            End Using
        End Using
        Return plainText
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateEncryption(ByRef Infobar As String) As Integer

        Dim oDataReader As IDataReader = Nothing
        Dim sEncryptedPassword As String
        Dim sPlainText As String

        Infobar = String.Empty

        UpdateEncryption = 0

        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                Using cmd As IDbCommand = appDB.CreateCommand()

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT sql_server_password FROM aps_parm WHERE aps_parm_key = 0"

                    oDataReader = appDB.ExecuteReader(cmd)

                    If oDataReader.Read Then
                        sEncryptedPassword = oDataReader.Item("sql_server_password").ToString
                    Else
                        sEncryptedPassword = ""
                    End If

                    oDataReader.Close()

                End Using

                If sEncryptedPassword = "" Then
                    Exit Function
                End If

                If Left(sEncryptedPassword, 1) = "=" Then
                    Exit Function
                End If

                sPlainText = Decrypt(sEncryptedPassword, ByteStream1, ByteStream2)

                sEncryptedPassword = Encrypt(sPlainText, ByteStream1, ByteStream2)

                Using cmd As IDbCommand = appDB.CreateCommand()

                    cmd.CommandText = "UPDATE aps_parm SET sql_server_password = @Pass WHERE aps_parm_key = 0"
                    cmd.Parameters.Clear()
                    appDB.AddCommandParameterWithValue(cmd, "Pass", sEncryptedPassword)
                    cmd.ExecuteNonQuery()

                End Using

            End Using
        Catch ex As Exception
            UpdateEncryption = 16
            Infobar = ex.Message
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsGetLocalSiteSp(ByRef LocalSite As String) As Integer
        Dim iApsGetLocalSiteExt As IApsGetLocalSite = New ApsGetLocalSiteFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iApsGetLocalSiteExt.ApsGetLocalSiteSp(LocalSite)
        LocalSite = result.Infobar
        Return result.ReturnCode.Value

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsGlobalPlanningEnvSp(ByVal AltNo As Short?, ByRef GlobalPlanning As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsGlobalPlanningEnvExt As IApsGlobalPlanningEnv = New ApsGlobalPlanningEnvFactory().Create(appDb)
            Dim oGlobalPlanning As Flag = GlobalPlanning
            Dim Severity As Integer = iApsGlobalPlanningEnvExt.ApsGlobalPlanningEnvSp(AltNo, oGlobalPlanning)
            GlobalPlanning = oGlobalPlanning
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetLocalServerServiceSp(ByVal AltNo As Short?, ByRef pServerName As String, ByRef pPortNo As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetLocalServerServiceExt As IGetLocalServerService = New GetLocalServerServiceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, pServerName As String, pPortNo As Integer?) = iGetLocalServerServiceExt.GetLocalServerServiceSp(AltNo, pServerName, pPortNo)
            Dim Severity As Integer = result.ReturnCode.Value
            pServerName = result.pServerName
            pPortNo = result.pPortNo
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsClearPlannerStatusSp(ByVal AltNo As Integer?) As Integer
        Dim iApsClearPlannerStatExt As IApsClearPlannerStatus = Me.GetService(Of IApsClearPlannerStatus)()
        Dim result As Integer? = iApsClearPlannerStatExt.ApsClearPlannerStatusSp(AltNo)
        Return result.Value
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsClearSchedulerStatusSp(ByVal AltNo As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsClearSchedulerStatExt As IApsClearSchedulerStatus = New ApsClearSchedulerStatusFactory().Create(Me, True)
            Dim result As Integer? = iApsClearSchedulerStatExt.ApsClearSchedulerStatusSp(AltNo)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsSiteInfoSp(ByRef PSQLServerName As String, ByRef PSQLDbName As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsSiteInExt As iApsSiteIn = New ApsSiteInFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PSQLServerName As String, PSQLDbName As String) = iApsSiteInExt.ApsSiteInfo(PSQLServerName, PSQLDbName)
            Dim Severity As Integer = result.ReturnCode.Value
            PSQLServerName = result.PSQLServerName
            PSQLDbName = result.PSQLDbName
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PlanningModeSp(ByVal apsmode As String, ByVal infcap As Decimal?) As Integer
        Dim iPlanningModeExt As IPlanningMode = New PlanningModeFactory().Create(Me, True)
        Dim result As Integer? = iPlanningModeExt.PlanningModeSp(apsmode, infcap)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsUpdateActiveBGTasks() As Integer
        Dim iApsUpdateActiveBGTasksExt As IApsUpdateActiveBGTasks = Me.GetService(Of IApsUpdateActiveBGTasks)()
        Dim result As Integer? = iApsUpdateActiveBGTasksExt.UpdateActiveBGTasks()
        Return result.Value
    End Function

End Class
