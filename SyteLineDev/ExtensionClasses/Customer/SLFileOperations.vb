Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.IO
Imports System.Data.SqlClient

Imports System.Security
Imports Mongoose.MGCore
Imports System.Text

Public Class SLFileOperations
    Inherits ExtensionClassBase
    Private _fileLines As Collection
    Private _pId As String
    Private _oServerOps As SLServerOperations
    Private _allFileContentDic As Dictionary(Of String, Collection) = New Dictionary(Of String, Collection)()
    Private _AllFileContentsDic As Dictionary(Of String, String) = New Dictionary(Of String, String)()
    Private _fse As FileServerExtension = New FileServerExtension()
    Private ReadOnly _fileNameSplitString As String = "|"

    Sub New(ByRef so As SLServerOperations)
        _oServerOps = so
    End Sub

    Public Property ProcessID() As String
        Get
            Return _pId
        End Get
        Set(ByVal value As String)
            _pId = value
        End Set
    End Property

    Public Property FilesContentDic() As Dictionary(Of String, Collection)
        Get
            Return _allFileContentDic
        End Get
        Set(value As Dictionary(Of String, Collection))

        End Set
    End Property

    Public Property FilesContentsDics() As Dictionary(Of String, String)
        Get
            Return _AllFileContentsDic
        End Get

        Set(value As Dictionary(Of String, String))

        End Set
    End Property

    Public Property ediLines() As Collection
        Get
            Return _fileLines
        End Get
        Set(ByVal value As Collection)
            _fileLines = value
        End Set
    End Property
    Public Property ServerOps As SLServerOperations
        Get
            Return _oServerOps
        End Get
        Set(ByVal value As SLServerOperations)
            _oServerOps = value
        End Set
    End Property



    Public Function CopyFile(ByVal oldFile As String, ByVal newFile As String) As Boolean
        Dim result As Boolean
        result = True
        Try
            If File.Exists(oldFile) Then
                File.Copy(oldFile, newFile)
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function DeleteLockfile(ByVal logicalFolderName As String, ByVal LockFileName As String) As Boolean
        Dim result As Boolean
        result = True
        Try
            DeleteFile(LockFileName, logicalFolderName, "")
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function ExportFile(ByVal logicalFolderName As String, ByVal FileName As String, ByVal extractLines As DataTable, Optional ByVal ExistingFileLines As String = "") As Boolean
        Dim result As Boolean
        result = True
        Dim i As Integer
        Dim strData As String = ""
        Dim errMsg As String = ""

        If Len(ExistingFileLines) > 0 Then
            _oServerOps.logError("EdiProcessLogSp", _pId, "10", "PreLoading Existing EdiFile Data from " + FileName, 0, 1)
            strData = ExistingFileLines
        End If

        Try
            If extractLines.Rows.Count > 0 Then
                For i = 0 To extractLines.Rows.Count - 1
                    strData += CStr(extractLines.Rows(i)(0))
                    strData += vbNewLine
                Next i
            End If

            SaveFileToFileServer(logicalFolderName, FileName, strData, errMsg)
        Catch ex As Exception
            result = False
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
                _oServerOps.logError("EdiProcessLogSp", _pId, "54", FileName, 0, 1)
            End If

        End Try

        Return result
    End Function

    ' creates log file
    Public Sub CreateLogFile(ByVal logicalFolderName As String, ByVal FileName As String, ByVal processId As String)
        Dim resut As Boolean
        resut = True
        Dim results As DataTable = New DataTable()
        Dim fileContent As String = ""

        Dim sqlCommand As String
        Dim i As Integer
        i = 0
        Try
            Dim strData As String
            sqlCommand = "SELECT CONVERT(nvarchar, CreateDate) + '  ' + InfobarText FROM ProcessErrorLog WHERE Processid = " + processId + " ORDER BY LineNum"
            If Not _oServerOps Is Nothing Then
                results = _oServerOps.SelectData(sqlCommand, processId)
            End If
            fileContent += "EDI Transaction Log" & vbCrLf & vbCrLf
            fileContent += "Logfile Name: " & FileName & vbCrLf & vbCrLf
            Do While i < results.Rows.Count
                strData = results.Rows(i)(0).ToString() & vbCrLf

                fileContent += strData
                i = i + 1
            Loop

            fileContent += vbCrLf & vbCrLf
            SaveFileToFileServer(logicalFolderName, FileName, fileContent, "")
        Catch ex As Exception
            resut = False
        End Try
    End Sub

    Public Function CreateLockFile(ByVal logicalFolderName As String, ByVal lockFileName As String) As Boolean
        Dim result As Boolean
        result = True
		
        If Not _oServerOps Is Nothing Then
            _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CreateLockFile-(LockFileName:" + lockFileName + ") (LogicalFolderName:" + logicalFolderName + ")", 0, 1)
        End If		

        If Not CheckForFile(lockFileName, logicalFolderName, "") Then
            Try
                SaveFileToFileServer(logicalFolderName, lockFileName, CStr(Now), "")
            Catch ex As Exception
                result = False
            End Try
        Else
            result = False
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "55", lockFileName, 0, 1)
            End If
        End If
		
        If Not _oServerOps Is Nothing Then
            If result = True Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CreateLockFile-(LockFileName:" + lockFileName + ") (LogicalFolderName:" + logicalFolderName + ") LockFile Created", 0, 1)
            Else
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CreateLockFile-(LockFileName:" + lockFileName + ") (LogicalFolderName:" + logicalFolderName + ") LockFile Not Created", 0, 1)
            End If
        End If		
        Return result
    End Function

    Public Sub LogError(ByVal logicalFolderName As String, ByVal fileName As String, ByVal message As String)
        SaveFileToFileServer(logicalFolderName, fileName, message, "")
    End Sub

    Public Function archiveFile(ByVal oldFileName As String, ByVal newFileName As String,
                                ByVal oldFileLogicalFolder As String, ByVal newFileLogicalFolder As String,
                                ByRef ErrMsg As String, ByVal deleteOldFile As Boolean) As Boolean
        archiveFile = False
        Dim oldFileServerName As String = ""
        Dim oldFolderTemplate As String = ""
        Dim oldAccessDepth As String = ""
        Dim oldFileSpec As String = ""

        Dim newFileServerName As String = ""
        Dim newFolderTemplate As String = ""
        Dim newAccessDepth As String = ""
        Dim newFileSpec As String = ""
        Dim moved As Integer
        Dim fileDeleted As Boolean = False
        Dim exists As Integer = 0

        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(oldFileLogicalFolder, oldFileServerName, oldFolderTemplate, oldAccessDepth, ErrMsg)
                oldFileSpec = GetFileSpec(oldFolderTemplate, oldFileName, "", oldAccessDepth, True)

                _oServerOps.GetFileServerInfoByLogicalFolderName(newFileLogicalFolder, newFileServerName, newFolderTemplate, newAccessDepth, ErrMsg)
                newFileSpec = GetFileSpec(newFolderTemplate, newFileName, "", newAccessDepth, True)

                _fse.FileExists(newFileSpec, newFileServerName, newFileLogicalFolder, exists, ErrMsg)

                If exists = 0 Then
                    _fse.MoveFileServerToServer(ErrMsg, moved, oldFileServerName, oldFileSpec, oldFileLogicalFolder,
                                                      newFileServerName, newFileSpec, newFileLogicalFolder, 1)
                    If deleteOldFile = True Then
                        fileDeleted = DeleteFile(oldFileName, oldFileLogicalFolder, "")
                    End If
                End If

                If moved = 1 Then
                    archiveFile = True
                End If
            End If
        Catch ex As Exception
            _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
        End Try

        Return archiveFile
    End Function

    Public Function ArchiveAllFile(ByVal oldFileLogicalFolder As String, ByVal newFileLogicalFolder As String, ByRef ErrMsg As String) As Boolean
        ArchiveAllFile = True
        Dim oldFileServerName As String = String.Empty
        Dim oldFolderTemplate As String = String.Empty
        Dim oldAccessDepth As String = String.Empty
        Dim oldFileSpec As String = String.Empty

        Dim newFileServerName As String = String.Empty
        Dim newFolderTemplate As String = String.Empty
        Dim newAccessDepth As String = String.Empty
        Dim newFileSpec As String = String.Empty
        Dim oldFileName As String = String.Empty
        Dim newFileName As String = String.Empty
        Dim fileList As String()
        Dim fileName As String
        Dim fileListString As String = String.Empty
        Dim exists As Integer = 0

        Dim moved As Integer
        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(oldFileLogicalFolder, oldFileServerName, oldFolderTemplate, oldAccessDepth, ErrMsg)
                _oServerOps.GetFileServerInfoByLogicalFolderName(newFileLogicalFolder, newFileServerName, newFolderTemplate, newAccessDepth, ErrMsg)

                oldFileSpec = GetFileSpec(oldFolderTemplate, String.Empty, String.Empty, oldAccessDepth, True)
                If Not String.IsNullOrEmpty(ErrMsg) Then
                    Return False
                End If
                _fse.GetFiles(oldFileSpec, oldFileServerName, oldFileLogicalFolder, GetFilesAction.File.ToString(), fileListString, ErrMsg)
                fileList = Split(fileListString, _fileNameSplitString)
                If Not String.IsNullOrEmpty(ErrMsg) Then
                    Return False
                End If
                For Each fileName In fileList
                    If fileName.Trim() <> String.Empty Then
                        oldFileSpec = GetFileSpec(oldFolderTemplate, fileName, "", oldAccessDepth, True)
                        newFileSpec = GetFileSpec(newFolderTemplate, fileName, "", newAccessDepth, True)

                        _fse.FileExists(newFileSpec, newFileServerName, newFileLogicalFolder, exists, ErrMsg)

                        If exists = 0 Then
                            _fse.MoveFileServerToServer(ErrMsg, moved, oldFileServerName, oldFileSpec, oldFileLogicalFolder,
                                                         newFileServerName, newFileSpec, newFileLogicalFolder)
                            If moved = 0 Then
                                ArchiveAllFile = False
                            End If
                        Else
                            ArchiveAllFile = False
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ArchiveAllFile = False
        End Try
        Return ArchiveAllFile
    End Function

    ' delete a file
    Public Function DeleteFile(ByVal oldFile As String) As Boolean
        Try
            File.Delete(oldFile)
            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try

    End Function

    Public Function DeleteFile(ByVal FileName As String, ByVal LogicalFolderName As String, ByRef ErrMsg As String) As Boolean
        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""
        Dim deleted As Integer
        Dim success As Boolean = False

        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
                fileSpec = GetFileSpec(folderTemplate, FileName, "", accessDepth, True)
                _fse.DeleteFromFileServer(fileServerName, fileSpec, LogicalFolderName, deleted, ErrMsg)

                If deleted = 1 Then
                    success = True
                End If
            End If
        Catch ex As Exception
            success = False
        End Try

        Return success
    End Function

    Public Function CheckForFile(ByVal FileName As String, ByVal LogicalFolderName As String, ByRef ErrMsg As String) As Boolean
        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileExisted As Integer
		
        If Not _oServerOps Is Nothing Then
            _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-(FileName:" + FileName + ") (LogicalFolderName:" + LogicalFolderName + ")", 0, 1)
        End If
		
        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-GetFileServerInfoByLogicalFolderName(LogicalFolderName:" + LogicalFolderName + ")", 0, 1)			
                _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
				
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-GetFileSpec(FolderTemplate:" + folderTemplate + ") (FileName:" + FileName + ") (AccessDepth:" + accessDepth + ")", 0, 1)
                fileSpec = GetFileSpec(folderTemplate, FileName, "", accessDepth, True)
				
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-FileExists(FileSpec:" + fileSpec + ") (FileServerName:" + fileServerName + ") (LogicalFolderName:" + LogicalFolderName + ")", 0, 1)
                _fse.FileExists(fileSpec, fileServerName, LogicalFolderName, fileExisted, ErrMsg)
            End If
        Catch ex As Exception
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
                _oServerOps.logError("EdiProcessLogSp", _pId, "6", FileName, 0, 1)
            End If
        End Try
		
        If Not _oServerOps Is Nothing Then
            If fileExisted = 1 Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-(FileName:" + FileName + ") (LogicalFolderName:" + LogicalFolderName + ") File Found", 0, 1)
                Return True
            Else
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "CheckForFile-(FileName:" + FileName + ") (LogicalFolderName:" + LogicalFolderName + ") File Not Found", 0, 1)
                Return False
            End If
        End If
    End Function

    Public Function LoadFile(ByVal FileName As String, ByVal LogicalFolderName As String,
                             ByVal FileType As String, ByVal Level As String, ByRef ErrMsg As String) As Boolean
        _fileLines = New Collection
        LoadFile = True

        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContentBytes As Byte() = New Byte() {}
        Dim parsedFileSpec As String = ""
		
        If Not _oServerOps Is Nothing Then
            _oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-(FileType:" + FileType + ") (FileName:" + FileName + ")" + "(LogicalFolderName:" + LogicalFolderName + ")", 0, 1)
        End If		

        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-GetFileServerInfoByLogicalFolderName(FileServerName:" + fileServerName + ") (FolderTemplate:" + folderTemplate + ") (AccessDepth:" + accessDepth + ") (ErrMsg:" + ErrMsg + ")", 0, 1)
                _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
				
				_oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-GetFileSpec(FolderTemplate:" + folderTemplate + ") (FileName:" + FileName + ") (AccessDepth:" + accessDepth + ")", 0, 1)
                fileSpec = GetFileSpec(folderTemplate, FileName, "", accessDepth, True)
				
				_oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-GetFileContent(FileSpec:" + fileSpec + ") (FileServerName:" + fileServerName + ") (LogicalFolderName:" + LogicalFolderName + ")", 0, 1)
                _fse.GetFileContent(fileSpec, fileServerName, LogicalFolderName, fileContentBytes, parsedFileSpec, ErrMsg)
				
				_oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-TextToStringCollection", 0, 1)
                _fileLines = TextToStringCollection(ByteArrayToString(fileContentBytes), FileType, Level)
            End If
        Catch ex As Exception
            LoadFile = False
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
                _oServerOps.logError("EdiProcessLogSp", _pId, "6", FileName, 0, 1)
            End If
        End Try
		
        If Not _oServerOps Is Nothing Then
            If LoadFile = True Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-(FileType:" + FileType + ") (FileName:" + FileName + ") (LogicalFolderName:" + LogicalFolderName + ") File Loaded", 0, 1)
            Else
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-(FileType:" + FileType + ") (FileName:" + FileName + ") (LogicalFolderName:" + LogicalFolderName + ") File NOT Loaded", 0, 1)
                If Len(Trim(ErrMsg)) > 0 Then
                    _oServerOps.logError("EdiProcessLogSp", _pId, "10", "LoadFile-Error Message:" + ErrMsg, 0, 1)
                End If
            End If
        End If
		
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
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
                fileSpec = GetFileSpec(folderTemplate, FileName, FileType, accessDepth, True)
                _fse.GetFileContentAsBase64String(fileSpec, fileServerName, LogicalFolderName, fileContent, parsedFileSpec, ErrMsg)

                LoadFileContent = Base64StringToString(fileContent)
            End If
        Catch ex As Exception
            LoadFileContent = ""
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
                _oServerOps.logError("EdiProcessLogSp", _pId, "6", FileName, 0, 1)
            End If
        End Try
    End Function

    Public Function LoadAllFile(ByVal LogicalFolderName As String, ByRef errMsg As String) As Boolean
        LoadAllFile(LogicalFolderName, String.Empty, errMsg)
    End Function

    Public Function LoadAllFile(ByVal LogicalFolderName As String, ByVal FileNameExtension As String, ByRef errMsg As String) As Boolean
        Dim fileServerName As String = String.Empty
        Dim folderTemplate As String = String.Empty
        Dim accessDepth As String = String.Empty
        Dim fileList As String()
        Dim fileListString As String = String.Empty
        Dim fileName As String
        Dim fileSpec As String

        If Not _oServerOps Is Nothing Then
            _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, errMsg)
            fileSpec = GetFileSpec(folderTemplate, String.Empty, FileNameExtension, accessDepth, True)
            If Not String.IsNullOrEmpty(errMsg) Then
                Return False
            End If
            _fse.GetFiles(fileSpec, fileServerName, LogicalFolderName, GetFilesAction.File.ToString(), fileListString, errMsg)
            fileList = Split(fileListString, _fileNameSplitString)
            If Not String.IsNullOrEmpty(errMsg) Then
                Return False
            End If
            For Each fileName In fileList
                If fileName.Trim() <> String.Empty Then
                    If Not _allFileContentDic.ContainsKey(fileName) And Not String.IsNullOrEmpty(fileName) Then
                        LoadFile(fileName, LogicalFolderName, "", accessDepth, errMsg)
                        If String.IsNullOrEmpty(errMsg) Then
                            _allFileContentDic.Add(fileName, _fileLines)
                        End If
                    End If
                End If
            Next
        End If
    End Function

    Public Function LoadAllFileContent(ByVal LogicalFolderName As String, ByVal FileNameExtension As String, ByRef errMsg As String) As Boolean
        Dim fileServerName As String = String.Empty
        Dim folderTemplate As String = String.Empty
        Dim accessDepth As String = String.Empty
        Dim fileList As String()
        Dim fileListString As String = String.Empty
        Dim fileName As String, fileSpec As String, fileContent As String

        If Not _oServerOps Is Nothing Then
            _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, errMsg)
            fileSpec = GetFileSpec(folderTemplate, String.Empty, FileNameExtension, accessDepth, True)

            If Not String.IsNullOrEmpty(errMsg) Then
                Return False
            End If
            _fse.GetFiles(fileSpec, fileServerName, LogicalFolderName, GetFilesAction.File.ToString(), fileListString, errMsg)
            fileList = Split(fileListString, _fileNameSplitString)
            If Not String.IsNullOrEmpty(errMsg) Then
                Return False
            End If
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
        End If
    End Function

    Public Function SaveFileToFileServer(ByVal logicalFolderName As String, ByVal fileName As String,
                                         ByVal fileContent As String, ByRef errMsg As String) As Boolean
        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContentBytes As Byte() = New Byte() {}
        Dim parsedFileSpec As String = ""
        Dim saved As Integer = 0
        Dim success As Boolean = False

        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(logicalFolderName, fileServerName, folderTemplate, accessDepth, errMsg)
                fileSpec = GetFileSpec(folderTemplate, fileName, "", accessDepth, True)
                fileContentBytes = Encoding.UTF8.GetBytes(fileContent)
                _fse.SaveFileContent(errMsg, saved, fileContentBytes, fileSpec, fileServerName, logicalFolderName)
                If saved = 1 Then
                    success = True
                End If
            End If
        Catch ex As Exception
            success = False
            errMsg = ex.Message
        End Try

        Return success
    End Function

    Function ByteArrayToString(ByVal byteArray As Byte()) As String
        Return Encoding.ASCII.GetString(byteArray)
    End Function

    Function StringToByteArray(ByVal stringText As String) As Byte()
        Return Encoding.ASCII.GetBytes(stringText)
    End Function

    Function TextToStringCollection(ByVal text As String, ByVal fileType As String, ByVal level As String) As Collection
        Dim stringCollection As Collection = New Collection()
        Dim textInLines As String() = text.Split(New String() {vbNewLine, vbCr, vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim addLevel As String = ""

        If (fileType = "830_HDR" OrElse fileType = "830_DTL" OrElse fileType = "SHIP_HDR" OrElse fileType = "SHIP_DTL") Then
            addLevel = level
        End If
        For Each sLine As String In textInLines
            stringCollection.Add(addLevel + sLine)
        Next
        Return stringCollection
    End Function



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
            retStr = Encoding.Default.GetString(bytes)
        End If
        Return retStr
    End Function

    Public Function LoadExistingFile(ByVal FileName As String, ByVal LogicalFolderName As String,
                             ByVal FileType As String, ByVal Level As String, ByRef ErrMsg As String) As String
        Dim FileLinesString As String = ""

        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContentBytes As Byte() = New Byte() {}
        Dim parsedFileSpec As String = ""
        Dim ReturnedString As String = ""

        Try
            If Not _oServerOps Is Nothing Then
                _oServerOps.GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
                fileSpec = GetFileSpec(folderTemplate, FileName, "", accessDepth, True)
                _fse.GetFileContent(fileSpec, fileServerName, LogicalFolderName, fileContentBytes, parsedFileSpec, ErrMsg)
                FileLinesString = TextToFormattedString(ByteArrayToString(fileContentBytes), FileType, Level)
            End If
        Catch ex As Exception
            FileLinesString = ""
            If Not _oServerOps Is Nothing Then
                _oServerOps.logError("EdiProcessLogSp", _pId, "10", ex.Message, 0, 1)
                _oServerOps.logError("EdiProcessLogSp", _pId, "6", FileName, 0, 1)
            End If
        End Try

        Return FileLinesString

    End Function

    Function TextToFormattedString(ByVal text As String, ByVal fileType As String, ByVal level As String) As String
        Dim strData As String = ""
        Dim textInLines As String() = text.Split(New String() {vbNewLine, vbCr, vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim addLevel As String = ""

        If (fileType = "830_HDR" OrElse fileType = "830_DTL" OrElse fileType = "SHIP_HDR" OrElse fileType = "SHIP_DTL") Then
            addLevel = level
        End If

        For Each sLine As String In textInLines
            strData += (addLevel + sLine)
            strData += vbNewLine
        Next

        Return strData
    End Function

End Class
