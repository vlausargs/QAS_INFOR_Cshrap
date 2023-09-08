Option Explicit On


Imports System
Imports System.Data
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Codes
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.SQL.UDDT
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLUserLocals")>
Public Class SLUserLocals
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.None)>
    Public Function GetCurVars(ByVal vUserName As String,
            ByRef vCurWhse As String,
            ByRef vCurUserCode As String,
            ByRef vUserID As String) As Integer



        Dim ResultSet As IDataReader
        Dim iResult As Integer

        Try
            iResult = 0

            Using db As AppDB = IDORuntime.Context.CreateAppDB()
                ' first query from invparms with user local

                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT inv.def_whse, usl.whse, usl.user_code " &
                      "FROM invparms AS inv, user_local AS usl " &
                      "INNER JOIN UserNames ON usl.UserId = UserNames.UserId " &
                      "WHERE UserNames.UserName = @UserName"
                    db.AddCommandParameterWithValue(cmd, "UserName", vUserName)
                    ResultSet = db.ExecuteReader(cmd)
                    ' if we do not get any hits, then try just inv parms
                    If ResultSet IsNot Nothing AndAlso Not ResultSet.Read() Then
                        If Not ResultSet.IsClosed Then
                            ResultSet.Close()
                            ResultSet = Nothing
                        End If

                        cmd.CommandText = "SELECT whse = def_whse, def_whse FROM invparms"
                        cmd.Parameters.Clear()
                        ResultSet = db.ExecuteReader(cmd)

                        If ResultSet IsNot Nothing AndAlso Not ResultSet.Read() Then
                            If Not ResultSet.IsClosed Then
                                ResultSet.Close()
                            End If
                            MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist0", "@invparms"))
                        End If
                    End If

                    If iResult = 0 Then
                        If IsDBNull(ResultSet.Item("whse")) Then
                            vCurWhse = TextUtil.FormatNormalizedString(ResultSet.Item("def_whse"))
                        Else
                            vCurWhse = TextUtil.FormatNormalizedString(ResultSet.Item("whse"))
                        End If
                        If IsDBNull(ResultSet.Item("user_code")) Then
                            vCurUserCode = ""
                        Else
                            vCurUserCode = TextUtil.FormatNormalizedString(ResultSet.Item("user_code"))
                        End If
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                    ' now get the userid
                    If iResult = 0 Then
                        cmd.CommandText = "select UserId from UserNames where Username = @UserName"
                        db.AddCommandParameterWithValue(cmd, "UserName", vUserName)
                        ResultSet = db.ExecuteReader(cmd)
                        If Not ResultSet.Read AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                            MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@UserNames.UserName", "@UserNames.UserName", vUserName))
                        Else
                            vUserID = TextUtil.FormatNormalizedString(ResultSet.Item("UserId"))
                        End If
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using
            Return iResult

        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BuyerValidSp(ByVal Buyer As String, ByRef Infobar As String) As Integer
        Dim iBuyerValidExt = Me.GetService(Of IBuyerValid)()
        Dim result As (ReturnCode As Integer?, Infobar As String) = iBuyerValidExt.BuyerValidSp(Buyer, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar

        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateUserNameSp(ByVal UserName As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim iValidateUserNameExt = New ValidateUserNameFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateUserNameExt.ValidateUserNameSp(UserName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
