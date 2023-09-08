Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient

<IDOExtensionClass("SLEdiParms")> _
Public Class SLServerOperations
    Inherits ExtensionClassBase
    Implements IDisposable

    Private appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

    Public Property AppDBConnection() As ApplicationDB
        Get
            Return appDB
        End Get
        Set(value As ApplicationDB)
            appDB = value
        End Set
    End Property

    Public Function SelectData(ByVal sqlCommand As String, ByRef processID As String) As DataTable
        Dim oDataReader As IDataReader = Nothing
        Dim results As DataTable = New DataTable()
        Dim ds As DataSet = New DataSet

        Try
            Using cmd As IDbCommand = appDB.CreateCommand()
                cmd.CommandText = sqlCommand
                Dim dr As IDataReader = appDB.ExecuteReader(cmd)
                results = ConvertDataReaderToDataTable(dr)
            End Using
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

        Return results
    End Function

    Public Function ConvertDataReaderToDataTable(ByVal reader As IDataReader) As DataTable
        Dim objDataTable As New DataTable
        Dim intFieldCount As Integer = reader.FieldCount
        Dim intCounter As Integer
        For intCounter = 0 To intFieldCount - 1
            objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter))
        Next intCounter

        objDataTable.BeginLoadData()
        Dim objValues(intFieldCount - 1) As Object
        While reader.Read()
            reader.GetValues(objValues)
            objDataTable.LoadDataRow(objValues, True)
        End While
        reader.Close()
        objDataTable.EndLoadData()

        Return objDataTable

    End Function

    Private Function ExecuteSp(ByVal sqlComand As IDbCommand) As Boolean
        Dim results As Boolean
        results = True
        Try
            appDB.ExecuteNonQuery(sqlComand)
        Catch ex As Exception
            results = False
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
        Return results
    End Function

    Public Function LogError(ByVal spName As String, ByVal pId As String, ByVal pElement As String, ByVal PMsgStack As String, ByVal PStdMsg As Integer, ByVal PDemandSide As Integer) As Boolean


        Dim processID As Decimal
        Dim result As Boolean = True

        Try
            Using sql As IDbCommand = appDB.CreateCommand()
                processID = CInt(pId)
                sql.CommandType = CommandType.StoredProcedure
                sql.CommandText = spName
                appDB.AddCommandParameterWithValue(sql, "ProcessId", processID).Size = 100
                appDB.AddCommandParameterWithValue(sql, "PElement", pElement).Size = 100
                appDB.AddCommandParameterWithValue(sql, "PMsgStack", PMsgStack).Size = 5600
                appDB.AddCommandParameterWithValue(sql, "PStdMsg", PStdMsg).Size = 1000
                appDB.AddCommandParameterWithValue(sql, "PDemandSide", PDemandSide).Size = 100
                result = ExecuteSp(sql)
            End Using
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function ExecuteEDISP(ByVal spName As String, ByVal pId As String) As Boolean
        Using sql As IDbCommand = appDB.CreateCommand()
            Dim processID As Decimal
            processID = CInt(pId)
            sql.CommandType = CommandType.StoredProcedure
            sql.CommandText = spName
            appDB.AddCommandParameterWithValue(sql, "ProcessId", processID).Size = 100
            Try
                Return ExecuteSp(sql)
            Catch ex As Exception
                appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION")
                LogError("EdiProcessLogSp", pId, "23", spName & ": " & Replace(Err.Description, "'", "''"), 0, 1)
                Return False
            End Try
        End Using
    End Function


    Public Function ExecuteEDISP(ByVal spName As String, ByVal pId As String, ByRef userName As String) As Boolean
        Using sql As IDbCommand = appDB.CreateCommand()
            Dim processID As Decimal
            processID = CInt(pId)
            sql.CommandType = CommandType.StoredProcedure
            sql.CommandText = spName
            appDB.AddCommandParameterWithValue(sql, "ProcessId", processID).Size = 100
            appDB.AddCommandParameterWithValue(sql, "Username", userName).Size = 100
            Try
                Return ExecuteSp(sql)
            Catch ex As Exception
                appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION")
                LogError("EdiProcessLogSp", pId, "23", spName & ": " & Replace(Err.Description, "'", "''"), 0, 1)
                Return False
            End Try
        End Using
    End Function

    Public Function WriteBgTaskLog(ByVal pId As String, ByRef infobarText As String, ByRef messageSeverity As Integer) As Boolean
        Using sql As IDbCommand = appDB.CreateCommand()
            Dim processID As Decimal
            processID = CInt(pId)
            sql.CommandType = CommandType.StoredProcedure
            sql.CommandText = "AddProcessErrorLogSp"
            appDB.AddCommandParameterWithValue(sql, "ProcessId", processID).Size = 100
            appDB.AddCommandParameterWithValue(sql, "InfobarText", infobarText).Size = 5600
            appDB.AddCommandParameterWithValue(sql, "MessageSeverity", messageSeverity).Size = 100
            Try
                Return ExecuteSp(sql)
            Catch ex As Exception
                appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION")
                LogError("EdiProcessLogSp", pId, "23", sql.CommandText & ": " & Replace(Err.Description, "'", "''"), 0, 1)
                Return False
            End Try
        End Using
    End Function

    Public Function LoadCollectionFromTmp _
     (ByVal processId As String, ByVal tranType As String, ByVal strLike As String) As DataTable
        Dim sqlCmd As String
        Dim queryResults As DataTable
        sqlCmd = "SELECT Data FROM tmp_edi_output WHERE ProcessId = " & processId _
                 & " AND TranType = '" & tranType & "'" _
                 & " AND RecType LIKE '" & strLike & "' ORDER BY Sequence"
        queryResults = SelectData(sqlCmd, processId)
        Return queryResults
    End Function

    Public Function GetSQLDMOColumnValue(ByRef DataSet As DataTable, ByVal RowPos As Integer, ByVal ColPos As Integer) As String
        Dim Value As String = vbNullString
        If DataSet.Rows(RowPos)(ColPos).ToString() <> vbNullString Then
            Value = DataSet.Rows(RowPos)(ColPos).ToString()
        End If
        Return Value
    End Function

    Public Function ClearTempTable(ByVal processId As String, ByVal tranType As String) As Boolean
        Dim sqlCommandString As String
        Dim results As Boolean
        Using sqlCommand As IDbCommand = appDB.CreateCommand()
            results = True
            Try
                sqlCommandString = "DELETE FROM tmp_edi_output WHERE ProcessId = @ProcessId" _
                   & " AND TranType = @TranType"
                sqlCommand.CommandText = sqlCommandString
                sqlCommand.CommandType = CommandType.Text
                appDB.AddCommandParameterWithValue(sqlCommand, "ProcessId", processId).Size = 100
                appDB.AddCommandParameterWithValue(sqlCommand, "TranType", tranType).Size = 100
                results = ExecuteSp(sqlCommand)
            Catch ex As Exception
                results = False
                LogError("EdiProcessLogSp", processId, "23", sqlCommand.CommandText & ": " & Replace(Err.Description, "'", "''"), 0, 1)
            End Try
        End Using
        Return results
    End Function
    Public Function CloseSession(ByVal pID As String) As Boolean
        Dim ProcedureName As String = "CloseSessionContextSp"
        Dim result As Boolean = True
        Using sql As IDbCommand = appDB.CreateCommand()
            Dim sessionID As String = "8E8EFA7A-4244-4261-A23C-A0BBA992BBEA"
            Try
                sql.CommandType = CommandType.StoredProcedure
                sql.CommandText = ProcedureName

                appDB.AddCommandParameterWithValue(sql, "SessionId", sessionID).Size = 100
                result = ExecuteSp(sql)
            Catch ex As Exception
                result = False
                LogError("EdiProcessLogSp", pID, "23", ProcedureName & ": " & Replace(Err.Description, "'", "''"), 0, 1)
            End Try
        End Using
        Return result
    End Function

    Public Function InitSession(ByVal pId As String, ByVal userName As String, ByVal siteName As String) As Boolean
        Dim ProcedureName As String
        Dim result As Boolean = True
        Using sql As IDbCommand = appDB.CreateCommand()
            ProcedureName = "InitSessionContextWithUserSp"

            Dim sessionID As String = "8E8EFA7A-4244-4261-A23C-A0BBA992BBEA"

            sql.CommandText = ProcedureName
            sql.CommandType = CommandType.StoredProcedure

            Try
                appDB.AddCommandParameterWithValue(sql, "ContextName", "EdiImport").Size = 100
                appDB.AddCommandParameterWithValue(sql, "UserName", Replace(userName, "'", "")).Size = 100
                appDB.AddCommandParameterWithValue(sql, "SessionId", sessionID).Size = 100
                appDB.AddCommandParameterWithValue(sql, "Site", siteName).Size = 100

                result = ExecuteSp(sql)
            Catch ex As Exception
                result = False
                LogError("EdiProcessLogSp", pId, "23", ProcedureName & ": " & Replace(Err.Description, "'", "''"), 0, 1)
            End Try
        End Using
        Return result
    End Function

    Public Function RunInsertStatements(ByVal insertStmts As Collection, ByVal processId As String, ByVal commitTransaction As Boolean) As Boolean

        Try

            Dim i As Long
            For i = 1 To insertStmts.Count
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandText = insertStmts(i).ToString()
                    appDB.ExecuteNonQuery(cmd)
                End Using
            Next i
            RunInsertStatements = True
            Exit Function
        Catch ex As Exception
            appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION")
            RunInsertStatements = False
            LogError("EdiProcessLogSp", processId.ToString(), "23", Substitute(Err.Description, "'", "''"), 0, 1)
        End Try
    End Function

    Public Function Substitute(ByVal Str As String, ByVal PatternStr As String, ByVal ReplaceStr As String) As String
        Dim strLeft As String
        Dim strRight As String
        Dim strTemp As String
        Dim intPos As Integer

        strTemp = Str
        intPos = InStr(strTemp, PatternStr)

        Do Until intPos = 0
            strLeft = Left(strTemp, intPos - 1)
            strRight = Right(strTemp, Len(strTemp) - intPos - Len(PatternStr) + 1)
            strTemp = strLeft & ReplaceStr & strRight
            intPos = InStr(intPos + Len(ReplaceStr), strTemp, PatternStr)
        Loop

        Substitute = strTemp
    End Function

    Sub GetFileServerInfoByLogicalFolderName(ByVal logicalFolderName As String,
                                             ByRef fileServerName As String,
                                             ByRef folderTemplate As String,
                                             ByRef accessDepth As String,
                                             ByRef errMsg As String)
        Using sql As IDbCommand = appDB.CreateCommand()
            Dim execResult As AppDBExecResult = Nothing

            Try
                sql.CommandType = CommandType.StoredProcedure
                sql.CommandText = "GetFileServerInfoByLogicalFolderNameSp"

                appDB.AddCommandParameterWithValue(sql, "LogicalFolderName", logicalFolderName).Size = 100
                appDB.AddCommandParameterWithValue(sql, "ServerName", "", ParameterDirection.Output).Size = 100
                appDB.AddCommandParameterWithValue(sql, "FolderTemplate", "", ParameterDirection.Output).Size = 100
                appDB.AddCommandParameterWithValue(sql, "FolderAccessDepth", "", ParameterDirection.Output).Size = 100

                appDB.ExecuteNonQuery(sql)
                fileServerName = CType(sql.Parameters(1), IDbDataParameter).Value.ToString()
                folderTemplate = CType(sql.Parameters(2), IDbDataParameter).Value.ToString()
                accessDepth = CType(sql.Parameters(3), IDbDataParameter).Value.ToString()
            Catch ex As Exception
                errMsg = Err.Description
            End Try
        End Using
    End Sub

    Public Sub DoTransactionBlock(ByVal TrxType As String)
        If TrxType = "BEGIN" Then
            appDB.ExecuteNonQuery("BEGIN TRANSACTION")
        ElseIf TrxType = "COMMIT" Then
            appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 COMMIT TRANSACTION")
        ElseIf TrxType = "ROLLBACK" Then
            appDB.ExecuteNonQuery("IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION")
        End If
    End Sub
End Class
