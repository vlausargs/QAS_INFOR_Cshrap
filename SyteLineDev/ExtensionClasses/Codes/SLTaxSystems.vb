Option Explicit On
Option Strict On

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

<IDOExtensionClass("SLTaxSystems")>
Public Class SLTaxSystems
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None)>
    Public Function GetTaxSystemEnabledInfo(ByVal strEnabledForColumn As Object,
                                          ByRef bEnabledSystem1 As Object,
                                          ByRef bEnabledSystem2 As Object,
                                          ByRef strMessage As Object) As Integer


        Dim ResultSet As IDataReader = Nothing
        Dim sEnabledForColumn As String

        Dim strParmNameWithQuote As String

        Try
            sEnabledForColumn = strEnabledForColumn.ToString()
            strParmNameWithQuote = sEnabledForColumn.Replace("]", "]]")
            strParmNameWithQuote = "[" + strParmNameWithQuote + "]"

            bEnabledSystem1 = "0"
            bEnabledSystem2 = "0"

            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()

                    cmd.CommandText = "SELECT  " & strParmNameWithQuote &
                                      " FROM tax_system WHERE tax_system = 1"

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read Then
                        If ((ResultSet.Item(sEnabledForColumn)).ToString() = "1") Then
                            bEnabledSystem1 = "1"
                        End If

                    End If

                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then ResultSet.Close()

                    ResultSet = Nothing

                    cmd.CommandText = "SELECT  " & sEnabledForColumn &
                                      " FROM tax_system WHERE tax_system = 2"

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read Then
                        If ((ResultSet.Item(sEnabledForColumn)).ToString() = "1") Then
                            bEnabledSystem2 = "1"
                        End If
                    End If

                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using

            End Using
            Return 0

        Catch ex As Exception
            MGException.Throw(Err.Description)
        End Try
    End Function
End Class

