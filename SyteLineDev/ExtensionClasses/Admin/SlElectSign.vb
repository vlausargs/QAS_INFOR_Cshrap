Option Explicit On

Imports Mongoose.IDO
Imports Mongoose.Core.Common
Imports Mongoose.IDO.DataAccess
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports Mongoose.IDO.Protocol
Imports CSI.Admin
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SlElectSign")>
Public Class SlElectSign

    Inherits ExtensionClassBase
    Implements IExtFTSLEsigAuthorizations

    Public Enum Status
        StatError = 16
    End Enum

    Private Const HashKey As String = "sS@P,Q%P<*c];jk.#Vaew|R0lw$R06egE[<b7"

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EncryptString(ByVal UnEncryptedString As String _
                                  , ByRef EncryptedString As String _
                                  , ByRef InfoBar As String) As Integer Implements IExtFTSLEsigAuthorizations.EncryptString
        Dim ActualString As String
        Try

            ActualString = Decrypt(UnEncryptedString, InfoBar)

            EncryptedString = Crypto.EncryptLogonString(ActualString, 30)

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return Status.StatError
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateSignature(
                 ByVal UserName As String _
                , ByVal EncryptedUserpassword As String _
                , ByVal EsigType As String _
                , ByRef InfoBar As String) As Integer Implements IExtFTSLEsigAuthorizations.ValidateSignature

        ' Assume we are going to fail
        ValidateSignature = 16

        If EncryptedUserpassword Is Nothing Then
            EncryptedUserpassword = ""
        End If

        ValidateSignature = ValidateUser(UserName, EncryptedUserpassword, InfoBar)
        If ValidateSignature > 0 Then
            Return ValidateSignature
        End If

        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' query for user status
                Using cmd As IDbCommand = db.CreateCommand()
                    ' Check if user has permission to sign on this item 
                    cmd.CommandText = "SELECT esig_authorization.UserName " &
                     "FROM esig_authorization " &
                     "WHERE esig_authorization.UserName = @UserName AND esig_authorization.esig_type = @EsigType"
                    db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                    db.AddCommandParameterWithValue(cmd, "EsigType", EsigType)

                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                        ' if we do not get any hits, throw an error, user does not have permissions
                        If Not ResultSet.Read() Then
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventBadCredentials1", UserName))
                        End If
                    End Using
                End Using
            End Using

            ' Miracle, it worked!
            ValidateSignature = 0

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            ValidateSignature = Status.StatError
        End Try

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateUser(
                 ByVal UserName As String _
                , ByVal EncryptedUserpassword As String _
                , ByRef InfoBar As String) As Integer

        Dim Userpassword As String = ""
        Dim NumberOfRetries As Integer = 0
        Dim DbPassword As String = ""
        Dim UserStatus As Integer = 0
        Dim PasswordNeverExpires As Boolean = False
        Dim PasswordExpirationDate As Date
        Dim UnlockDate As Date
        Dim LoginFailures As Integer
        Dim iLockoutDuration As Integer

        ' Assume we are going to fail
        ValidateUser = 16

        Try
            Userpassword = Crypto.DecryptLogonString(EncryptedUserpassword)

            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' query for user status
                Using cmd As IDbCommand = db.CreateCommand()

                    cmd.CommandText = "SELECT UserNames.Status, UserNames.PasswordExpirationDate, UserNames.PasswordNeverExpires, UserNames.UserPassword, UserNames.LoginFailures, UserNames.UnlockDate " &
                  "FROM UserNames " &
                  "WHERE UserNames.UserName = @UserName"
                    db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)

                        If Not ResultSet.Read() Then
                            ValidateUser = 10
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventBadCredentials1", UserName))
                        End If

                        ' if user good
                        DbPassword = Crypto.DecryptLogonString(ResultSet.Item("UserPassword"))

                        UserStatus = ResultSet.Item("Status")
                        PasswordExpirationDate = DateValue(IIf(IsDBNull(ResultSet.Item("PasswordExpirationDate")), DateAdd("yyyy", 1, Today), ResultSet.Item("PasswordExpirationDate")))
                        UnlockDate = CDate(IIf(IsDBNull(ResultSet.Item("UnlockDate")), Today, ResultSet.Item("UnlockDate")))
                        PasswordNeverExpires = ResultSet.Item("PasswordNeverExpires")
                        LoginFailures = ResultSet.Item("LoginFailures")
                    End Using

                    ' Check User Status
                    If UserStatus = 1 Then
                        ' If user is locked, and we have not passed the unlock date
                        If DateDiff("s", UnlockDate, Now()) < 0 Then
                            ValidateUser = 15
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventUserLocked1", UserName))
                        Else
                            'Update count
                            cmd.CommandText = "UPDATE UserNames Set UserNames.Status = " & 0 & ", UserNames.LoginFailures = " & 0 & " " &
                            "WHERE UserNames.UserName = @UserName"
                            cmd.Parameters.Clear()
                            db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                            cmd.ExecuteNonQuery()
                        End If
                    ElseIf UserStatus = 2 Then
                        ValidateUser = 15
                        MGException.Throw(GetMessageProvider.GetMessage("@!EventUserDisabled1", UserName))
                    ElseIf PasswordNeverExpires = False And DateDiff("s", PasswordExpirationDate, Today) >= 0 Then
                        ' Check to see if our user has expired
                        ValidateUser = 15
                        MGException.Throw(GetMessageProvider.GetMessage("@!EventPasswordExpired", UserName))
                    End If

                    ' Check for bad password
                    If (StrComp(DbPassword, Userpassword) <> 0) Then

                        LoginFailures = LoginFailures + 1

                        ' Get number of retries
                        cmd.CommandText = "SELECT PasswordParameters.NumberOfRetries, PasswordParameters.LockoutDuration " &
                        "FROM PasswordParameters "
                        cmd.Parameters.Clear()
                        Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                            If ResultSet.Read() Then
                                NumberOfRetries = ResultSet.Item("NumberOfRetries")
                                iLockoutDuration = ResultSet.Item("LockoutDuration")
                            Else
                                ' User name not found
                                ValidateUser = 10
                                MGException.Throw(GetMessageProvider.GetMessage("@!EventBadCredentials1", UserName))
                            End If
                        End Using

                        If LoginFailures = NumberOfRetries Then
                            If UserStatus = 0 Then
                                'Update status
                                cmd.CommandText = "UPDATE UserNames Set UserNames.Status = 1, UserNames.UnlockDate = '" & DateAdd("n", iLockoutDuration, Now) &
                                        "' WHERE UserNames.UserName = @UserName"
                                cmd.Parameters.Clear()
                                db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                                cmd.ExecuteNonQuery()
                            End If
                            ValidateUser = 15
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventUserLocked1", UserName))
                        ElseIf LoginFailures < NumberOfRetries Then
                            'Update count
                            cmd.CommandText = "UPDATE UserNames Set UserNames.LoginFailures = " & LoginFailures & " " &
                                "WHERE UserNames.UserName = @UserName"
                            cmd.Parameters.Clear()
                            db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                            cmd.ExecuteNonQuery()

                            ' Bad Password
                            ValidateUser = 10
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventBadCredentials1", UserName))
                        ElseIf 0 = NumberOfRetries Then
                            ' Bad Password
                            ValidateUser = 10
                            MGException.Throw(GetMessageProvider.GetMessage("@!EventBadCredentials1", UserName))
                        End If
                    End If

                    ' Login Successful
                    ValidateUser = 0

                    If LoginFailures > 0 Then
                        'Update count
                        cmd.CommandText = "UPDATE UserNames Set UserNames.LoginFailures = " & 0 & " " &
                       "WHERE UserNames.UserName = @UserName"
                        cmd.Parameters.Clear()
                        db.AddCommandParameterWithValue(cmd, "UserName", UserName)
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ValidateUser
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateCheckSum(
                  ByVal RowPointer As Guid _
                , ByVal UserName As String _
                , ByVal EncryptedUserpassword As String _
                , ByVal EsigType As String _
                , ByRef InfoBar As String) As Integer Implements IExtFTSLEsigAuthorizations.CreateCheckSum

        Dim HashValue As String = ""

        ' Assume we are going to fail
        CreateCheckSum = 16

        CreateCheckSum = ValidateSignature(UserName, EncryptedUserpassword, EsigType, InfoBar)

        If CreateCheckSum <= 0 Then

            Try

                Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                    ' query for user status
                    Using cmd As IDbCommand = db.CreateCommand()

                        ' Make sure that there is a fresh record out there that needs to be signed
                        cmd.CommandText = "SELECT esig_type " &
                        "FROM electronic_signature " &
                        "WHERE RowPointer = @RowPointer AND esig_type = @EsigType AND esig_spec IS NULL"
                        cmd.Parameters.Clear()
                        db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointer.ToString())
                        db.AddCommandParameterWithValue(cmd, "EsigType", EsigType)
                        Using ResultSet As IDataReader = db.ExecuteReader(cmd)

                            ' if we do not get any hits, throw an error, esig record does not exist
                            If Not ResultSet.Read() Then
                                CreateCheckSum = 10
                                MGException.Throw(GetMessageProvider.GetMessage("E_FRM_RECORD_NOT_FOUND"))
                            End If
                        End Using
                        ' Get Hash Code
                        HashValue = GetHashValue(RowPointer, InfoBar)

                        ' Write has out to sig header
                        cmd.CommandText = "Update electronic_signature SET esig_spec = '" & HashValue & "' " &
                        "WHERE RowPointer = @RowPointer AND esig_spec IS NULL"
                        cmd.Parameters.Clear()
                        db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointer.ToString())
                        db.ExecuteNonQuery(cmd)
                    End Using
                End Using

                ' Miracle, it worked!
                CreateCheckSum = 0

            Catch ex As Exception
                InfoBar = InfoBar & Space(1) & ex.Message
                CreateCheckSum = Status.StatError
            End Try
        Else
            Return CreateCheckSum
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateCheckSum(
                  ByVal RowPointer As Guid _
                , ByRef CheckSumOkay As Boolean _
                , ByRef InfoBar As String) As Integer

        ' Get Hash Code
        Dim HashValue As String = GetHashValue(RowPointer, InfoBar)

        ' Assume Failer
        ValidateCheckSum = 16
        CheckSumOkay = False
        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' query for user status
                Using cmd As IDbCommand = db.CreateCommand()
                    ' Read the detail rows of the Signature records.
                    cmd.CommandText = "SELECT esig_spec " &
                    "FROM electronic_signature " &
                    "WHERE RowPointer = @RowPointer"
                    cmd.Parameters.Clear()
                    db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointer.ToString())
                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                        If Not IsDBNull(ResultSet.Item("esig_spec")) Then
                            If StrComp(ResultSet.Item("esig_spec"), HashValue) = 0 Then
                                ValidateCheckSum = True
                                CheckSumOkay = True
                            End If
                        End If
                    End Using
                End Using
            End Using
            ' Miracle, it worked!
            ValidateCheckSum = 0
        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ValidateCheckSum
        End Try

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function TamperedElectronicSignatureReport(
                  ByVal SessionId As String _
                , ByVal StartDate As Date _
                , ByVal EndDate As Date _
                , ByRef InfoBar As String) As Integer

        Dim bNotDone As Boolean = True
        Dim HashValue As String = ""
        Dim RowPointer As Guid = Nothing
        Dim BadRowsList As New ArrayList

        ' Assume we are going to fail
        TamperedElectronicSignatureReport = 16
        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()

                    ' Find All Sigs in range
                    cmd.CommandText = "Select electronic_signature.RowPointer, electronic_signature.esig_spec  " &
                    "FROM electronic_signature WHERE dbo.MidnightOf(CreateDate) >= " & SqlLiteral.Format(StartDate) & "  AND dbo.MidnightOf(CreateDate) <= " & SqlLiteral.Format(EndDate)

                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                        If ResultSet.Read() Then
                            'For Each Record in the Recordset
                            Do While bNotDone

                                RowPointer = ResultSet.Item("RowPointer")

                                ' Get Hash Code
                                HashValue = GetHashValue(RowPointer, InfoBar)
                                If IsDBNull(ResultSet.Item("esig_spec")) Then
                                    BadRowsList.Add(RowPointer.ToString)
                                Else
                                    If StrComp(ResultSet.Item("esig_spec"), HashValue) <> 0 Then
                                        BadRowsList.Add(RowPointer.ToString)
                                    End If
                                End If
                                bNotDone = ResultSet.Read()
                            Loop
                        End If
                    End Using

                    ' Loop over the ArrayList with a For loop.
                    Dim i As Integer
                    Dim RowPointerStr As String
                    For i = 0 To BadRowsList.Count - 1
                        ' Cast to a string.
                        RowPointerStr = TryCast(BadRowsList.Item(i), String)
                        If Not String.IsNullOrEmpty(RowPointerStr) Then
                            cmd.CommandText = "INSERT tmp_MessageBuffer (SessionID, sequence, MessageText) VALUES (@SessionId, @Seq, @RowPointer)"
                            cmd.Parameters.Clear()
                            db.AddCommandParameterWithValue(cmd, "SessionId", SessionId)
                            db.AddCommandParameterWithValue(cmd, "Seq", i)
                            db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointerStr)
                            db.ExecuteNonQuery(cmd)
                        End If
                    Next i
                End Using
            End Using

            ' Miracle, it worked!
            TamperedElectronicSignatureReport = 0
        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return TamperedElectronicSignatureReport
        End Try

    End Function


    Private Function GetHashValue(
                 ByVal RowPointer As Guid _
               , ByRef InfoBar As String) As String

        Dim sBuffer As String = ""

        Dim bNotDone As Boolean = True
        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()
                    ' Get ESign Header 
                    cmd.CommandText = "SELECT Username, UserDesc, reason_code, reason_description, esig_type, CreateDate " &
                 "FROM electronic_signature " &
                 "WHERE RowPointer = @RowPointer"

                    cmd.Parameters.Clear()
                    db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointer)
                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                        If Not ResultSet.Read() Then
                            MGException.Throw(GetMessageProvider.GetMessage("E_FRM_RECORD_NOT_FOUND"))
                        End If

                        For fp As Integer = 0 To ResultSet.FieldCount - 1
                            sBuffer = sBuffer & ResultSet.GetValue(fp).ToString
                        Next
                    End Using
                    ' Add unique string to hash seed

                    sBuffer = sBuffer & HashKey

                    ' Read the detail rows of the Signature records.
                    cmd.CommandText = "Select column_caption, column_value " &
                     "FROM electronic_signature_detail " &
                     "WHERE ElectronicSignatureRowPointer = @RowPointer " &
                     "ORDER BY seq"

                    cmd.Parameters.Clear()
                    db.AddCommandParameterWithValue(cmd, "RowPointer", RowPointer)
                    Using ResultSet As IDataReader = db.ExecuteReader(cmd)
                        If Not ResultSet.Read() Then
                            MGException.Throw(GetMessageProvider.GetMessage("E_FRM_RECORD_NOT_FOUND"))
                        End If
                        Do While bNotDone
                            For fp As Integer = 0 To ResultSet.FieldCount - 1
                                sBuffer = sBuffer & ResultSet.GetValue(fp).ToString
                            Next
                            bNotDone = ResultSet.Read()
                        Loop
                    End Using
                    ' Get Hash Code
                    GetHashValue = Crypto.GenerateMD5Hash(sBuffer)
                End Using
            End Using
        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return Status.StatError
        End Try

    End Function


    Public Function Encrypt(ByVal sCrypt As String, ByRef InfoBar As String) As String

        Dim tmp As String = ""
        Dim sVal As String = ""
        Dim l As Long = 0

        Try
            For l = 1 To Len(sCrypt)
                sVal = HexValue(Mid(sCrypt, l, 1), InfoBar)
                If Len(sVal) = 1 Then sVal = "0" & sVal
                tmp = tmp & sVal
            Next l
            Encrypt = tmp

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ""
        End Try
    End Function

    Public Function Decrypt(ByVal sCrypt As String, ByRef InfoBar As String) As String

        Dim tmp As String = ""
        Dim sVal As String = ""
        Dim str As String = ""

        Try
            sVal = UCase(sCrypt)
            Do Until sVal = ""
                If Len(sVal) < 2 Then
                    str = ChrValue(sVal, InfoBar)
                    If Len(str) > 4 Then
                        If Left(str, 4) = "ERR: " Then
                            tmp = str
                            Exit Do
                        End If
                    End If
                    tmp = tmp & str
                    sVal = ""
                Else
                    str = Left(sVal, 2)
                    If Left(str, 1) = "0" Then str = Right(str, 1)
                    str = ChrValue(str, InfoBar)
                    tmp = tmp & str
                    sVal = Right(sVal, Len(sVal) - 2)
                End If
            Loop
            Decrypt = tmp

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ""
        End Try
    End Function

    Private Function HexValue(ByVal sChr As String, ByRef InfoBar As String) As String

        Dim iDec As Integer = 0
        Try
            iDec = Asc(sChr)
            HexValue = Hex(iDec)

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ""
        End Try
    End Function

    Private Function ChrValue(ByVal sHex As String, ByRef InfoBar As String) As String
        Dim sChr As String = ""
        Dim dblVal As Double = 0
        Dim i As Integer = 0
        Const cIdx = 16

        Try
            For i = 1 To Len(sHex)
                sChr = Mid(sHex, i, 1)
                If sChr <> " " Then
                    If sChr <= "9" Then
                        dblVal = dblVal + CInt(sChr)
                    Else
                        dblVal = dblVal + ((Asc(sChr) - 55) Mod 32)
                    End If
                    If i < Len(sHex) Then dblVal = dblVal * cIdx
                End If
            Next i
            ChrValue = Chr(dblVal)

        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ""
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UserFormInGroupSp(ByVal GroupName As String, ByVal UserId As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iUserFormInGroupExt = New UserFormInGroupFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iUserFormInGroupExt.UserFormInGroupSp(GroupName, UserId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class