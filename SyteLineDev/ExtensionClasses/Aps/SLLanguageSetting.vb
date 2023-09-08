Option Explicit On
Option Strict On
Imports System.Xml

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.SQL.UDDT
Imports CSI.MG
Imports CSI.Production.APS
Imports IMessageProvider = Mongoose.IDO.IMessageProvider
Imports CSI.ExternalContracts.RhythmIntegration

<IDOExtensionClass("SLLanguageSetting")>
Public Class SLLanguageSetting
    Inherits CSIExtensionClassBase

    Private Const DEFAULT_LANGUAGE_ID As String = "en-US"

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetUserLanguageId(ByRef LanguageId As String,
        ByVal UserName As String,
        ByVal SiteId As String,
        ByRef Infobar As String) As Integer

        Infobar = String.Empty
        GetUserLanguageId = 0

        Dim statement As String = String.Format("SELECT OverrideLanguageID
                                                FROM UserPreferences
                                                INNER JOIN usernames ON usernames.Username = UserPreferences.UserName
                                                WHERE UserId = {0}",
                                                UserName)

        GetUserLanguageId = GetColumnValue(statement, "OverrideLanguageID", LanguageId, Infobar)

        If Not String.IsNullOrEmpty(LanguageId) Then
            Return GetUserLanguageId
        End If

        statement = String.Format("SELECT TOP 1 LanguageID
                                            FROM usernames
                                            INNER JOIN LanguageIDs ON usernames.LanguageCode = LanguageIDs.LanguageCode
                                            WHERE UserId = {0}",
                                                UserName)
        GetUserLanguageId = GetColumnValue(statement, "LanguageID", LanguageId, Infobar)

        If Not String.IsNullOrEmpty(LanguageId) Then
            Return GetUserLanguageId
        End If

        statement = String.Format("SELECT TOP 1 LanguageID
                                                FROM site
                                                INNER JOIN LanguageIDs ON site.lang_code = LanguageIDs.LanguageCode
                                                WHERE site = '{0}'",
                                                SiteId)
        GetUserLanguageId = GetColumnValue(statement, "LanguageID", LanguageId, Infobar)

        If Not String.IsNullOrEmpty(LanguageId) Then
            Return GetUserLanguageId
        End If

        LanguageId = DEFAULT_LANGUAGE_ID

    End Function

    Private Function GetColumnValue(ByVal CommandText As String,
            ByVal Column As String,
            ByRef OutputValue As String,
            ByRef Infobar As String) As Integer

        Dim oDataReader As IDataReader = Nothing

        Infobar = String.Empty

        Try
            Using MGAppDB As AppDB = CreateAppDB()
                Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Context, GetMessageProvider())
                Using cmd As IDbCommand = appDb.CreateCommand()

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = CommandText

                    oDataReader = appDb.ExecuteReader(cmd)

                    If oDataReader.Read Then
                        OutputValue = oDataReader.Item(Column).ToString
                    Else
                        OutputValue = String.Empty
                    End If

                    oDataReader.Close()

                End Using
            End Using


        Catch ex As Exception
            GetColumnValue = 16
            Infobar = ex.Message
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

    End Function

End Class
