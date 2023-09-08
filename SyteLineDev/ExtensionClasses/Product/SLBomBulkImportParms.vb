Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
'Imports System.Xml
Imports System.IO
Imports System.Collections

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports Mongoose.MGCore
Imports System.Data.SqlClient
Imports Customer
Imports System.Text
Imports CSI.MG
Imports CSI.Production

<IDOExtensionClass("SLBOMBulkImportParms")> _
Public Class SLBomBulkImportParms
    Inherits ExtensionClassBase
    'Private fileOper As SLFileOperations = New SLFileOperations()
    Private _AllFileContentsDic As Dictionary(Of String, String) = New Dictionary(Of String, String)()
    Private ReadOnly _allFileContentDic As Dictionary(Of String, Collection) = New Dictionary(Of String, Collection)()
    Private _fse As FileServerExtension = New FileServerExtension()

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BOMBulkImport_ProcessXMLFiles(ByRef Infobar As String, ImportFolderName As String, ArchiveFolderName As String) As Integer

        Dim ResponseData As InvokeResponseData

        Dim xmlFileContent As String = ""
        Dim ImportFolderTemplate As String = "", ImportAccessDepth As String = ""
        Dim filesContentKP As KeyValuePair(Of String, String)

        BOMBulkImport_ProcessXMLFiles = 0

        LoadAllFileContent(ImportFolderName, ".xml", Infobar)

        For Each filesContentKP In _AllFileContentsDic

            xmlFileContent = filesContentKP.Value.TrimStart("?"c)

            'Call the processing method/SP, passing the sFileFullname
            Try
                ResponseData = Me.Invoke("BOMBulkImport_ProcessSp", filesContentKP.Key, xmlFileContent)
                If ResponseData.IsReturnValueStdError() Then
                    Infobar = "Call to BOMBulkImport_ProcessSp failed"
                    BOMBulkImport_ProcessXMLFiles = 16
                    Exit For
                End If
            Catch
                Infobar = Err.Description
                BOMBulkImport_ProcessXMLFiles = 16
                Exit For
            End Try

            'Move the file to the Archive directory
            If ArchiveFolderName <> "" Then
                Try
                    If Not archiveFile(filesContentKP.Key, GetArchiveFileName(filesContentKP.Key), ImportFolderName, ArchiveFolderName, Infobar) Then
                        ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
                            , "E=CmdFailed", "@:JobtranType:M", "" _
                            , "", "", "", "", "", "", "", "", "", "", "", "", "")
                        Infobar = ResponseData.Parameters(0).GetValue(Of String)() & Infobar
                        BOMBulkImport_ProcessXMLFiles = 16
                        Exit For
                    End If
                Catch
                    'malformed path
                    ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
                        , "E=CmdFailed", "@:JobtranType:M", "" _
                        , "", "", "", "", "", "", "", "", "", "", "", "", "")
                    Infobar = ResponseData.Parameters(0).GetValue(Of String)()
                    Infobar = Infobar & Err.Description
                    BOMBulkImport_ProcessXMLFiles = 16
                    Exit For
                End Try
            End If
        Next        'Filename

    End Function

    Public Function archiveFile(ByVal oldFileName As String, ByVal newFileName As String,
                                ByVal oldFileLogicalFolder As String, ByVal newFileLogicalFolder As String,
                                ByRef ErrMsg As String) As Boolean
        archiveFile = False
        Dim oldFileServerName As String = ""
        Dim oldFolderTemplate As String = ""
        Dim oldAccessDepth As String = ""
        Dim oldFileSpec As String = ""

        Dim newFileServerName As String = ""
        Dim newFolderTemplate As String = ""
        Dim newAccessDepth As String = ""
        Dim newFileSpec As String = ""
        Dim moved As Integer = 0
        Dim exists As Integer = 0

        Try
            GetFileServerInfoByLogicalFolderName(oldFileLogicalFolder, oldFileServerName, oldFolderTemplate, oldAccessDepth, ErrMsg)
            oldFileSpec = GetFileSpec(oldFolderTemplate, oldFileName, "", oldAccessDepth, True)

            GetFileServerInfoByLogicalFolderName(newFileLogicalFolder, newFileServerName, newFolderTemplate, newAccessDepth, ErrMsg)
            newFileSpec = GetFileSpec(newFolderTemplate, newFileName, "", newAccessDepth, True)

            _fse.FileExists(newFileSpec, newFileServerName, newFileLogicalFolder, exists, ErrMsg)

            If exists = 0 Then
                _fse.MoveFileServerToServer(ErrMsg, moved, oldFileServerName, oldFileSpec, oldFileLogicalFolder,
                                                  newFileServerName, newFileSpec, newFileLogicalFolder, 1, 1)
                If moved = 1 Then
                    archiveFile = True
                End If
            End If
        Catch ex As Exception

        End Try

        Return archiveFile
    End Function

    Private Function GetArchiveFileName(ByVal filename As String) As String
        Dim d As DateTime = DateTime.Now

        Dim index As Integer = filename.LastIndexOf(".")
        Dim extensionName As String = ""

        If (index > 0) Then
            extensionName = filename.Substring(filename.LastIndexOf("."))
            filename = filename.Substring(0, filename.LastIndexOf("."))
        End If

        Return filename & "_" & d.ToString("yyyyMMdd") & "T" & d.ToString("hhmmssmm") & extensionName
    End Function

    Public Function LoadAllFileContent(ByVal LogicalFolderName As String, ByVal FileNameExtension As String, ByRef errMsg As String) As Boolean
        Dim fileServerName As String = String.Empty
        Dim folderTemplate As String = String.Empty
        Dim accessDepth As String = String.Empty
        Dim fileList As String()
        Dim fileListString As String = String.Empty
        Dim fileName As String, fileSpec As String, fileContent As String

        GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, errMsg)
        fileSpec = GetFileSpec(folderTemplate, String.Empty, FileNameExtension, accessDepth, True)

        If Not String.IsNullOrEmpty(errMsg) Then
            Return False
        End If
        _fse.GetFiles(fileSpec, fileServerName, LogicalFolderName, GetFilesAction.File.ToString(), fileListString, errMsg)

        If Not String.IsNullOrEmpty(errMsg) Then
            Return False
        End If

        fileList = Split(fileListString, "|")

        For Each fileName In fileList
            If fileName.Trim() <> String.Empty Then
                If Not _AllFileContentsDic.ContainsKey(fileName) And Not String.IsNullOrEmpty(fileName) Then
                    fileContent = LoadFileContent(fileName, LogicalFolderName, FileNameExtension, accessDepth, errMsg)

                    If String.IsNullOrEmpty(errMsg) Then
                        _AllFileContentsDic.Add(fileName, fileContent)
                    End If
                End If
            End If
        Next
    End Function

    Public Function LoadFileContent(ByVal FileName As String, ByVal LogicalFolderName As String,
                             ByVal FileType As String, ByVal Level As String, ByRef ErrMsg As String) As String
        LoadFileContent = ""

        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContent As String = ""
        Dim parsedFileSpec As String = ""

        Try
            GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
            fileSpec = GetFileSpec(folderTemplate, FileName, FileType, accessDepth, True)
            _fse.GetFileContentAsBase64String(fileSpec, fileServerName, LogicalFolderName, fileContent, parsedFileSpec, ErrMsg)

            LoadFileContent = Base64StringToString(fileContent)
        Catch ex As Exception
            LoadFileContent = ""
            '_oServerOps.logError("EdiProcessLogSp", _pId, "6", FileName, 0, 1)
        End Try
    End Function

    Sub GetFileServerInfoByLogicalFolderName(ByVal logicalFolderName As String,
                                             ByRef fileServerName As String,
                                             ByRef folderTemplate As String,
                                             ByRef accessDepth As String,
                                             ByRef errMsg As String)
        Using appdb As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using sql As IDbCommand = appdb.CreateCommand()
                sql.CommandType = CommandType.StoredProcedure
                sql.CommandText = "GetFileServerInfoByLogicalFolderNameSp"

                appdb.AddCommandParameterWithValue(sql, "LogicalFolderName", logicalFolderName)
                appdb.AddCommandParameterWithValue(sql, "ServerName", fileServerName, ParameterDirection.InputOutput).Size = 100
                appdb.AddCommandParameterWithValue(sql, "FolderTemplate", folderTemplate, ParameterDirection.InputOutput).Size = 100
                appdb.AddCommandParameterWithValue(sql, "FolderAccessDepth", accessDepth, ParameterDirection.InputOutput).Size = 100

                appdb.ExecuteNonQuery(sql)

                fileServerName = CType(sql.Parameters(1), IDbDataParameter).Value.ToString()
                folderTemplate = CType(sql.Parameters(2), IDbDataParameter).Value.ToString()
                accessDepth = CType(sql.Parameters(3), IDbDataParameter).Value.ToString()
            End Using
        End Using
    End Sub

    Function GetFileSpec(ByVal folderTemplate As String, ByVal fileName As String,
                             ByVal fileExtension As String, ByVal accessDepth As String,
                             ByVal useServerCheck As Boolean) As String
        Dim useServerCheckStr As String
        Dim fileSpec As String = String.Empty

        If useServerCheck Then
            useServerCheckStr = "1"
        Else
            useServerCheckStr = "0"
        End If

        If fileName.LastIndexOf("\") >= 0 Then
            fileName = fileName.Substring(fileName.LastIndexOf("\")).TrimStart("\"c)
        End If

        fileSpec = folderTemplate.TrimEnd("/"c) + "\" + fileName + "|" + fileExtension + "|" + accessDepth + "|" + useServerCheckStr

        Return fileSpec
    End Function

    Public Function Base64StringToString(ByVal Base64Str As String) As String
        Dim retStr As String = ""
        Dim bytes As Byte()
        Dim charBuffer As Char()

        If Base64Str <> "" Then
            charBuffer = Base64Str.ToCharArray()
            bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length)
            retStr = Encoding.UTF8.GetString(bytes)
        End If

        Return retStr

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BOMBulkImport_ProcessSp(ByVal xmlFileName As String, ByVal xmlData As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iBOMBulkImport_ProcessExt As IBOMBulkImport_Process = New BOMBulkImport_ProcessFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iBOMBulkImport_ProcessExt.BOMBulkImport_ProcessSp(xmlFileName, xmlData)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function
End Class
