Option Explicit On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports Mongoose.Core.Configuration
Imports Mongoose.Scripting
Imports System.Data.SqlClient
Imports Mongoose.IDO.DataAccess
Imports System.Management
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Admin
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports OfficeIntegration = CSI.ExternalContracts.OfficeIntegration.Outlook
Imports CSI.ExternalContracts.OfficeIntegration.Outlook

<IDOExtensionClass("MonitoredResources")>
Public Class MonitoredResource

    Inherits ExtensionClassBase
    Implements OfficeIntegration.IMonitoredResources

    Public Enum Status
        Yes = 1
        No = 0
        StatError = -1
    End Enum


    Private ReadOnly PassPhrase = "sLI)hrase"
    Private ReadOnly InitVector = "@H81B2c3D4e5F6g7"

    ReadOnly a() As String = {"a", "a"}



    ReadOnly ServiceActionStatus() As String = {
        "Success",
        "Not Supported",
        "Access Denied",
        "Dependent Services Running",
        "Invalid Service Control",
        "Service Cannot Accept Control",
        "Service Not Active",
        "Service Request timeout",
        "Unknown Failure",
        "Path Not Found",
        "Service Already Running",
        "Service Database Locked",
        "Service Dependency Deleted",
        "Service Dependency Failure",
        "Service Disabled",
        "Service Logon Failed",
        "Service Marked For Deletion",
        "Service No Thread",
        "Status Circular Dependency",
        "Status Duplicate Name",
        "Status - Invalid Name",
        "Status - Invalid Parameter",
        "Status - Invalid Service Account",
        "Status - Service Exists",
        "Service Already Paused"}

    Public Function CheckServiceStatus(
                  ByVal ServiceName As String _
                , ByVal SystemName As String _
                , ByVal UserName As String _
                , ByVal Userpassword As String _
                , ByVal DomainName As String _
                , ByRef ServiceStatus As Integer _
                , ByRef InfoBar As String) As Integer


        ServiceStatus = _IsServiceRunning(
             ServiceName _
           , SystemName _
           , UserName _
           , Userpassword _
           , DomainName _
           , InfoBar)

        CheckServiceStatus = ServiceStatus

    End Function

    Public Function KillProcess(
                 ByVal ProcessID As Integer _
               , ByVal ResourceName As String _
               , ByRef ServiceStatus As Integer _
               , ByRef InfoBar As String) As Integer



        Dim SystemName As String = ""
        Dim UserName As String = ""
        Dim Userpassword As String = ""
        Dim DomainName As String = ""
        Dim Filter = String.Format("ResourceName = {0}", SqlLiteral.Format(ResourceName))
        Dim loadResponse As New LoadCollectionResponseData

        loadResponse = Me.LoadCollection("MachineName,Username,Password, DomainName", Filter, "", -1)

        If loadResponse.Items.Count <= 0 Then
            InfoBar = "Define a KillTask in Monitored Resource form!"
            ServiceStatus = 1
            Return 0
        End If



        SystemName = loadResponse(0, "MachineName").Value
        UserName = loadResponse(0, "Username").Value
        Userpassword = loadResponse(0, "Password").Value
        DomainName = loadResponse(0, "DomainName").Value

        If String.IsNullOrEmpty(SystemName) Then
            InfoBar = "Machine Name is empty!"
            ServiceStatus = 1
            Return 0
        End If


        ServiceStatus = _KillProcess(
             ProcessID _
           , SystemName _
           , UserName _
           , Userpassword _
           , DomainName _
           , InfoBar)



        KillProcess = ServiceStatus
        Return 0
    End Function



    Public Function EventMonitorResources() As Integer

        Dim ResourceType As String = ""
        Dim ResourceName As String = ""
        Dim SystemName As String = ""
        Dim UserName As String = ""
        Dim Userpassword As String = ""
        Dim DomainName As String = ""
        Dim PublicationName As String = ""
        Dim ServiceStatus As Integer
        Dim AlertSent As Integer = 0
        Dim RowPointer As String
        Dim RecordDate As Date
        Dim Infobar As String = ""
        Dim FreeSpace As Decimal
        Dim WarningThreshold As Decimal

        Dim Filter = " Active = 1 AND ResourceType <> 'Process'"

        Dim loadResponse As LoadCollectionResponseData

        loadResponse = Me.LoadCollection("MachineName, ResourceName, Username,Password, DomainName, " &
                                         "AlertSent, RowPointer, RecordDate, PublicationName, " &
                                         "ResourceType, WarningThreshold", Filter, "", -1)

        If loadResponse.Items.Count <= 0 Then
            Infobar = "No resource to monitor!"
            Return Status.No
        End If

        For Ctr = 0 To loadResponse.Items.Count - 1

            ResourceType = loadResponse(Ctr, "ResourceType").Value
            ResourceName = loadResponse(Ctr, "ResourceName").Value
            SystemName = loadResponse(Ctr, "MachineName").Value
            UserName = loadResponse(Ctr, "Username").Value
            Userpassword = loadResponse(Ctr, "Password").Value
            DomainName = loadResponse(Ctr, "DomainName").Value
            AlertSent = CType(loadResponse(Ctr, "AlertSent").Value, Integer)
            RecordDate = loadResponse(Ctr, "RecordDate").GetValue(Of Date)(RecordDate)
            RowPointer = loadResponse(Ctr, "RowPointer").Value
            PublicationName = loadResponse(Ctr, "PublicationName").Value
            WarningThreshold = loadResponse(Ctr, "WarningThreshold").GetValue(Of Decimal)(WarningThreshold)



            If String.IsNullOrEmpty(SystemName) Then
                Infobar = "Machine Name is empty!"
                Return Status.No
            End If


            If ResourceType = "Service" Then
                ServiceStatus = _IsServiceRunning(
                               ResourceName _
                             , SystemName _
                             , UserName _
                             , Userpassword _
                             , DomainName _
                             , Infobar)
            End If

            If ResourceType = "DiskSpace" Then
                ServiceStatus = GetFreeDiskSpace(
                                ResourceName _
                             , SystemName _
                             , UserName _
                             , Userpassword _
                             , DomainName _
                             , FreeSpace _
                             , Infobar)


                If FreeSpace <= WarningThreshold Then
                    ServiceStatus = Status.No
                End If
            End If

            Me.Context.Commands.Invoke("MonitoredResources",
                                       "MonitoredResource_NotifySubscribersSp",
                                       PublicationName,
                                       RowPointer,
                                       ServiceStatus,
                                       Infobar)

        Next
        Return 0
    End Function



    Private Function _IsServiceRunning(
              ByVal ServiceName As String _
            , ByVal SystemName As String _
            , ByVal UserName As String _
            , ByVal userpassword As String _
            , ByVal authority As String _
            , ByRef InfoBar As String) As Integer

        Dim ResourceExists As Boolean
        Try

            Dim Sql As String = "SELECT * FROM Win32_Service Where Name = '" & ServiceName & "'"
            Dim searcher As ManagementObjectSearcher
            searcher = Get_Object(
                      Sql _
                    , SystemName _
                    , UserName _
                    , userpassword _
                    , authority _
                    , InfoBar)


            If searcher Is Nothing Then
                Return Status.StatError
            End If


            For Each queryObj As ManagementObject In searcher.Get()
                ResourceExists = True
                InfoBar = InfoBar & " Status: " & queryObj("State").ToString
                If queryObj("State").ToString = "Stopped" Then
                    Return Status.No
                End If
            Next

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return Status.StatError
        End Try

        If ResourceExists Then
            Return Status.Yes
        Else
            InfoBar = InfoBar & Space(1) & ServiceName & " is not found!"
            Return Status.StatError
        End If

    End Function


    Public Function ServiceAction(
              ByVal ServiceName As String _
            , ByVal SystemName As String _
            , ByVal UserName As String _
            , ByVal userpassword As String _
            , ByVal authority As String _
            , ByVal Action As String _
            , ByVal ServiceStatus As Integer _
            , ByRef InfoBar As String) As Integer

        Dim ResourceExist As Boolean

        Try


            Dim Sql As String = "SELECT * FROM Win32_Service Where Name = '" & ServiceName & "'"
            Dim searcher As ManagementObjectSearcher


            searcher = Get_Object(
                      Sql _
                    , SystemName _
                    , UserName _
                    , userpassword _
                    , authority _
                    , InfoBar)

            If searcher Is Nothing Then
                Return Status.StatError
            End If

            InfoBar = "Time: " & InfoBar

            For Each queryObj As ManagementObject In searcher.Get()
                Dim arg As Object() = Nothing
                Dim obj As Object

                ResourceExist = True
                Try


                    If Action = "STOP" Or Action = "START" Then
                        Action = Action + "Service"
                        obj = queryObj.InvokeMethod(Action, arg)
                        If Not obj Is Nothing Then
                            InfoBar = InfoBar & Space(1) & ServiceActionStatus(CType(obj, Integer))
                        End If

                    End If

                    If Action = "RESTART" Then
                        obj = queryObj.InvokeMethod("StopService", arg)
                        System.Threading.Thread.Sleep(2000)
                        obj = queryObj.InvokeMethod("StartService", arg)

                        If Not obj Is Nothing Then
                            InfoBar = InfoBar & Space(1) & ServiceActionStatus(CType(obj, Integer))
                        End If

                    End If

                    Return 1

                Catch ex As Exception
                    InfoBar = "Cannot Terminate the Service: " & ex.Message
                    Return -1
                End Try
            Next

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return -1
        End Try

        If Not ResourceExist Then
            InfoBar = ServiceName & " is not found!"
            Return -1
        Else
            Return 1
        End If
    End Function



    Private Function _KillProcess(
                  ByVal ProcessID As Integer _
                , ByVal SystemName As String _
                , ByVal UserName As String _
                , ByVal Userpassword As String _
                , ByVal DomainName As String _
                , ByRef InfoBar As String) As Integer

        Dim ResourceExist As Boolean


        Try
            Dim Sql As String = "SELECT * FROM Win32_Process Where ProcessID = " & ProcessID
            Dim searcher As ManagementObjectSearcher


            searcher = Get_Object(
                      Sql _
                    , SystemName _
                    , UserName _
                    , Userpassword _
                    , DomainName _
                    , InfoBar)



            If searcher Is Nothing Then
                InfoBar = "No Process is found!"
                Return Status.StatError
            End If

            For Each queryObj As ManagementObject In searcher.Get()

                ResourceExist = True

                Dim arg As Object() = Nothing
                Try
                    Dim obj As Object = queryObj.InvokeMethod("Terminate", arg)
                    InfoBar = "Killed"
                Catch ex As Exception
                    InfoBar = "Cannot Terminate the Service: " & ex.Message
                    Return Status.StatError
                End Try
            Next


        Catch ex As Exception
            InfoBar = ex.Message
            Return Status.StatError
        End Try

        If ResourceExist Then
            Return Status.Yes
        Else
            InfoBar = InfoBar & Space(1) & ProcessID & " is not found!"
            Return Status.StatError
        End If
    End Function


    Public Function GetFreeDiskSpace(
                  ByVal DiskDrive As String _
                , ByVal SystemName As String _
                , ByVal UserName As String _
                , ByVal userpassword As String _
                , ByVal authority As String _
                , ByRef FreeSpace As Decimal _
                , ByRef InfoBar As String) As Integer

        Dim ResourceExist As Boolean
        Dim searcher As ManagementObjectSearcher

        DiskDrive = Left(DiskDrive, 1) & ":"
        Dim Sql As String =
        "SELECT * FROM Win32_LogicalDisk Where DeviceID = '" & DiskDrive & "'"

        searcher = Get_Object(
                       Sql _
                     , SystemName _
                     , UserName _
                     , userpassword _
                     , authority _
                     , InfoBar)

        If searcher Is Nothing Then
            Return Status.StatError
        End If

        For Each queryObj As ManagementObject In searcher.Get()
            ResourceExist = True
            Try
                Dim FreeSpaceInpercent As Double = CDec((CLng(queryObj("FreeSpace")) / CLng(queryObj("Size"))) * 100)
                FreeSpace = CDec(Math.Round(FreeSpaceInpercent, 2))

                InfoBar = InfoBar & String.Format(" Free : {0} ({1}%)", CLng(queryObj("FreeSpace")), FreeSpace)
                InfoBar = InfoBar & " Total Size : " & CLng(queryObj("Size")).ToString


            Catch ex As Exception
                InfoBar = ex.Message
                Return Status.StatError
            End Try
        Next

        If ResourceExist Then
            Return Status.Yes
        Else
            InfoBar = InfoBar & Space(1) & DiskDrive & " is not found!"
            Return Status.StatError
        End If
    End Function




    Private Function Get_Object(
                  ByVal Sql As String _
                , ByVal SystemName As String _
                , ByVal UserName As String _
                , ByVal userpassword As String _
                , ByVal authority As String _
                , ByRef InfoBar As String) As ManagementObjectSearcher

        Dim Sys As String = "\\" & SystemName & "\root\CIMV2"
        Dim Connection As New System.Management.ConnectionOptions

        InfoBar = Now.ToString()

        Dim pwd As Tuple(Of String, String) = DecryptPassword(userpassword)

        Connection.Username = UserName
        Connection.Password = pwd.Item1
        Connection.Authority = "ntlmdomain:" & authority

        Dim Stat As Integer = IsLocalSystem(SystemName, authority, InfoBar)
        If Stat = Status.Yes Then
            Connection = New System.Management.ConnectionOptions()
        End If

        Try
            Dim scope As New ManagementScope(Sys, Connection)
            scope.Connect()
            If Not scope.IsConnected Then
                InfoBar = InfoBar & Space(1) & "Connection to the Namespace on " & SystemName & " can not be established!"
                Return Nothing
            End If
            '' if the password was encrypted with old algorithm
            '' then we need to encrypt with new one
            If (pwd.Item2 = "SHA1") Then
                EncryptPassword(userpassword)
            End If


            Dim query As New ObjectQuery(Sql)
            Dim searcher As New ManagementObjectSearcher(scope, query)
            Return searcher

        Catch ex As System.Runtime.InteropServices.COMException
            InfoBar = "Cannot connect to the Server " & ex.Message
        Catch ex As Exception
            InfoBar = "Error message : " & ex.Message
            Return Nothing
        End Try
        Return Nothing
    End Function



    Shared Function IsLocalSystem(
                  ByVal SystemName As String _
                , ByVal authority As String _
                , ByRef InfoBar As String) As Integer

        If String.IsNullOrEmpty(SystemName) Then
            Return Status.StatError
        End If

        Try
            Dim sname As String = SystemName.Split(".".Chars(0))(0).ToString().ToUpper()
            Dim dname As String = authority.Split(".".Chars(0))(0).ToString().ToUpper()

            If sname = System.Windows.Forms.SystemInformation.ComputerName.ToUpper() Then
                'If dname = System.Environment.UserDomainName.ToUpper Then
                '    Return Status.Yes
                'End If
                Return Status.Yes
            End If
            Return Status.No
        Catch ex As Exception
            InfoBar = ex.Message
            Return Status.StatError
        End Try
        Return Status.No
    End Function

    Public Function EncryptPassword(ByRef pPassword As String) As String
        pPassword = Encrypt(pPassword,
                            PassPhrase,
                            "(sytl!n<-)",
                            "SHA256",
                                2,
                             InitVector,
                                       256)

        Return pPassword
    End Function
    Private Function DecryptPassword(ByVal pPassword As String) As Tuple(Of String, String)
        Dim hashAlgorithm As String = "SHA256"

        Try
            pPassword = Decrypt(pPassword,
                            PassPhrase,
                            "(sytl!n<-)",
                            hashAlgorithm,
                            2,
                            InitVector,
                            256)
        Catch ex As Exception

            '' When the SHA256 fails
            '' use SHA1.
            '' This is for backward compatability

            hashAlgorithm = "SHA1"
            pPassword = Decrypt(pPassword,
                            PassPhrase,
                            "(sytl!n<-)",
                            hashAlgorithm,
                            2,
                             InitVector,
                            256)
        End Try

        Return New Tuple(Of String, String)(pPassword, hashAlgorithm)

    End Function
    Private Function Encrypt(ByVal plainText As String,
                                      ByVal passPhrase As String,
                                      ByVal saltValue As String,
                                      ByVal hashAlgorithm As String,
                                      ByVal passwordIterations As Integer,
                                      ByVal initVector As String,
                                      ByVal keySize As Integer) _
                              As String


        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte()
        plainTextBytes = Encoding.UTF32.GetBytes(plainText)


        Dim password As PasswordDeriveBytes
        password = New PasswordDeriveBytes(passPhrase,
                                           saltValueBytes,
                                           hashAlgorithm,
                                           passwordIterations)

        Dim keyBytes As Byte()
        keyBytes = password.GetBytes(CInt(keySize / 8))


        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged With {
            .Mode = CipherMode.CBC
        }


        Dim encryptor As ICryptoTransform
        encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)


        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream()


        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream,
                                        encryptor,
                                        CryptoStreamMode.Write)

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

        cryptoStream.FlushFinalBlock()

        Dim cipherTextBytes As Byte()
        cipherTextBytes = memoryStream.ToArray()

        symmetricKey.Dispose()
        memoryStream.Close()
        cryptoStream.Close()

        Dim cipherText As String
        cipherText = Convert.ToBase64String(cipherTextBytes)
        Encrypt = cipherText
    End Function
    Private Function Decrypt(ByVal pwdInPlainText As String,
                                   ByVal passPhrase As String,
                                   ByVal saltValue As String,
                                   ByVal hashAlgorithm As String,
                                   ByVal passwordIterations As Integer,
                                   ByVal initVector As String,
                                   ByVal keySize As Integer) _
                           As String


        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(pwdInPlainText)


        Dim password As PasswordDeriveBytes
        password = New PasswordDeriveBytes(passPhrase,
                                           saltValueBytes,
                                           hashAlgorithm,
                                           passwordIterations)


        Dim keyBytes As Byte()
        keyBytes = password.GetBytes(CInt(keySize / 8))


        Dim symmetric As RijndaelManaged
        symmetric = New RijndaelManaged With {
            .Mode = CipherMode.CBC
        }

        Dim decryptor As ICryptoTransform
        decryptor = symmetric.CreateDecryptor(keyBytes, initVectorBytes)

        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream(cipherTextBytes)

        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream,
                                        decryptor,
                                        CryptoStreamMode.Read)
        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)

        Dim decryptedByteCount As Integer
        decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                               0,
                                               plainTextBytes.Length)

        symmetric.Dispose()
        memoryStream.Close()
        cryptoStream.Close()

        Dim plainText As String
        plainText = Encoding.UTF32.GetString(plainTextBytes,
                                            0,
                                            decryptedByteCount)
        Decrypt = plainText
    End Function


    Public Sub GetFormDBName(ByRef formDBName As String, ByVal configName As String)
        Dim currentConfig As Configuration = IDORuntime.LoadConfiguration(configName)
        Dim FormsConnection As ConnectionProfile = currentConfig.GetFormsConnection(ConnectionProfileType.Runtime)
        Symmetric.Decrypt(FormsConnection.DatabaseName, formDBName)
    End Sub

    Public Function GetConfigurationList(ByVal configGroup As String, ByRef configStr As String, ByRef InfoBar As String) As Integer
        configStr = String.Empty
        InfoBar = String.Empty
        Try
            Dim configurations As ConfigurationInfoList = Client.GetConfigurations("", configGroup)
            For Each config As ConfigurationInfo In configurations
                configStr = (configStr & "|" & config.Name)
            Next
        Catch exp As Exception
            InfoBar = exp.Message
            Return 0
        End Try
        Return 1
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UnlockUserSp(ByVal Username As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iUnlockUserExt = New UnlockUserFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iUnlockUserExt.UnlockUserSp(Username, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SLPreciseSearchPreferenceListsSp(ByVal emailBody As String, ByVal emailid As String, ByRef InfobarType As String, ByRef xmlResult As String, ByVal formDBName As String) As Integer Implements IMonitoredResources.SLPreciseSearchPreferenceListsSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLPreciseSearchPreferenceListsExt = New SLPreciseSearchPreferenceListsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, InfobarType As String, xmlResult As String) = iSLPreciseSearchPreferenceListsExt.SLPreciseSearchPreferenceListsSp(emailBody, emailid, InfobarType, xmlResult, formDBName)
            Dim Severity As Integer = result.ReturnCode.Value
            InfobarType = result.InfobarType
            xmlResult = result.xmlResult
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SLSp_ExecuteSqlSp(ByRef Res As String, ByVal QueryStr As String,
<[Optional]> ByRef Infobar As String) As Integer Implements IMonitoredResources.SLSp_ExecuteSqlSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLSp_ExecuteSqlExt = New SLSp_ExecuteSqlFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Res As String, Infobar As String) = iSLSp_ExecuteSqlExt.SLSp_ExecuteSqlSp(Res, QueryStr, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Res = result.Res
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MonitoredResource_NotifySubscribersSp(ByVal PublicationName As String, ByVal MRRowPointer As Guid?, ByVal ServiceStatus As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iMonitoredResource_NotifySubscribersExt = New MonitoredResource_NotifySubscribersFactory().Create(appDb)

            Dim Severity As Integer = iMonitoredResource_NotifySubscribersExt.MonitoredResource_NotifySubscribersSp(PublicationName, MRRowPointer, ServiceStatus, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MonitoredResources_SubscribeAlertSp(ByVal PublicationName As String, ByVal Username As String, ByVal Email As String, ByVal IsSubscribed As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iMonitoredResources_SubscribeAlertExt = New MonitoredResources_SubscribeAlertFactory().Create(appDb)

            Dim Severity As Integer = iMonitoredResources_SubscribeAlertExt.MonitoredResources_SubscribeAlertSp(PublicationName, Username, Email, IsSubscribed, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UnlockLockedFunctionSp(ByVal FunctionName As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUnlockLockedFunctionExt As IUnlockLockedFunction = New UnlockLockedFunctionFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUnlockLockedFunctionExt.UnlockLockedFunctionSp(FunctionName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
