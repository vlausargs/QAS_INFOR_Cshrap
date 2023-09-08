Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.Utilities

<IDOExtensionClass("SLAccountAuthorizations")>
Public Class SLAccountAuthorizations
    Inherits ExtensionClassBase

    'This method used to revise the list of explorer node members
    <IDOMethod(MethodFlags.None)>
    Public Function ReviseExplorerFolder(ByRef Username As String,
                            ByRef OriginalExplorerXML As String,
                            ByRef PrunedExplorerXML As String) As Integer

        ReviseExplorerFolder = StdMethodResult.Success
        Dim expRespData As LoadExplorerResponseData

        If String.IsNullOrEmpty(Username) Then
            PrunedExplorerXML = OriginalExplorerXML
        Else
            expRespData = LoadExplorerResponseData.FromXml(OriginalExplorerXML)
            'Begin user implementation
            Dim executableForms As New List(Of String)
            Try
                Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                    Dim reader As IDataReader = Nothing
                    Dim param As IDbDataParameter = Nothing
                    Using cmd As IDbCommand = appDB.CreateCommand()
                        Dim iSuperUser As Integer = 0
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "Select SuperUserFlag From UserNames Where Username = @User "
                        param = cmd.CreateParameter()
                        param.ParameterName = "@User"
                        param.Value = Username
                        Try
                            cmd.Parameters.Add(param)
                            reader = appDB.ExecuteReader(cmd)
                            If reader.Read() Then
                                iSuperUser = CInt(reader.GetValue(0))
                            End If
                            If Not reader Is Nothing AndAlso Not reader.IsClosed Then
                                reader.Close()
                            End If
                        Catch ex As Exception
                            If Not reader Is Nothing AndAlso Not reader.IsClosed Then
                                reader.Close()
                            End If
                            Throw New MGException(ex.Message)
                        End Try
                        If iSuperUser = 1 Then
                            PrunedExplorerXML = OriginalExplorerXML
                            Return ReviseExplorerFolder
                        Else
                            cmd.CommandText = ";WITH UserAuthorizations (ObjectName1, ExecutePriviledge) " &
                          "AS (SELECT aau.ObjectName1, ISNULL(aau.ExecutePrivilege, 0) " &
                              "FROM AccountAuthorizations AS aau " &
                              "INNER JOIN UserNames AS una ON una.Username = @User AND aau.Id = una.UserId " &
                              "WHERE aau.ObjectType = 0 AND aau.ObjectName2 = aau.ObjectName1 AND aau.UserFlag = 1 " &
                              ") " &
                          ", GroupAuthorizations (ObjectName1, ExecutePriviledge) " &
                          "AS (SELECT aau.ObjectName1 , ISNULL(aau.ExecutePrivilege, 0) " &
                              "FROM AccountAuthorizations AS aau " &
                              "INNER JOIN UserNames AS una ON una.Username = @User " &
                              "WHERE aau.ObjectType = 0 AND aau.ObjectName2 = aau.ObjectName1 AND aau.UserFlag = 0 " &
                              "AND aau.Id IN ( SELECT ugm.GroupId FROM UserGroupMap AS ugm WHERE ugm.UserId = una.UserId) " &
                              ") " &
                          "SELECT uau.ObjectName1, CASE WHEN SUM(ISNULL(uau.ExecutePriviledge, 0)) = 0 THEN 0 ELSE 1 END AS ExecutePriviledge " &
                          "FROM UserAuthorizations AS uau " &
                          "WHERE uau.ExecutePriviledge != 0 " &
                          "GROUP BY uau.ObjectName1 " &
                          "UNION " &
                          "SELECT gau.ObjectName1, CASE WHEN SUM(ISNULL(gau.ExecutePriviledge, 0)) = 0 THEN 0 ELSE 1 END AS ExecutePriviledge " &
                          "FROM GroupAuthorizations AS gau " &
                          "LEFT OUTER JOIN UserAuthorizations AS uau ON gau.ObjectName1 = uau.ObjectName1 " &
                          "WHERE gau.ExecutePriviledge != 0 AND uau.ObjectName1 IS NULL " &
                          "GROUP BY gau.ObjectName1 "
                            Try
                                reader = appDB.ExecuteReader(cmd)
                                While reader.Read()
                                    If CInt(reader.GetValue(1)) = 1 Then
                                        Dim formName As String = reader.GetString(0)
                                        If formName <> String.Empty Then
                                            executableForms.Add(formName)
                                        End If
                                    End If
                                End While
                                If Not reader Is Nothing AndAlso Not reader.IsClosed Then
                                    reader.Close()
                                End If
                            Catch ex As Exception
                                If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                                    reader.Close()
                                End If
                                Throw New MGException(ex.Message)
                            End Try
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ReviseExplorerFolder = 16
                MGException.Throw(MGException.ExtractMessages(ex))
            End Try
            'Prune form names from node that are't in list of executable forms
            Dim node As Mongoose.FormServer.Protocol.ExplorerNodeDef
            Dim idx As Integer = 0
            While idx < expRespData.Nodes.Count
                node = expRespData.Nodes(idx)
                Dim formRunSpec As String = node.ObjectTextData
                Dim startParenPos As Integer = formRunSpec.IndexOf("(")
                If startParenPos = -1 Then
                    startParenPos = formRunSpec.Length
                End If
                Dim stringUtil As StringUtil = New StringUtil()
                Dim formName As String = stringUtil.Left(formRunSpec, startParenPos)
                If (node.ObjectType = Mongoose.WinStudio.Enums.ExplorerObjectType.NormalForm Or
                    node.ObjectType = Mongoose.WinStudio.Enums.ExplorerObjectType.QueryForm) Then
                    If Not executableForms.Contains(formName) Then
                        expRespData.Nodes.RemoveAt(idx)
                    Else
                        idx = idx + 1
                    End If
                Else
                    idx = idx + 1
                End If
            End While
            'End user implementation
            PrunedExplorerXML = expRespData.ToXml
        End If
    End Function

End Class

