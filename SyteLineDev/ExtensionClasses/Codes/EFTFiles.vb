Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data
Imports System.Collections
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports CSI.Codes
Imports CSI.MG
Imports System.Security
Imports Mongoose.MGCore
Imports System.Text
Imports System.Runtime.InteropServices
Imports CSI.Data.SQL.UDDT
Imports CSI.Data.RecordSets

<IDOExtensionClass("EFTFiles")>
Public Class EFTFiles
    Inherits CSIExtensionClassBase

    Private _fse As FileServerExtension = New FileServerExtension()
    Private ReadOnly _fileNameSplitString As String = "|"

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImport(ByVal MapID As String, ByVal ImportPath As String, ByVal ArchiveDir As String, ByRef Infobar As String, ByVal TaskID As Integer) As Integer
        Dim ResponseData As InvokeResponseData

        EFTImport = 0

        If String.IsNullOrEmpty(Infobar) Then
            Infobar = ""
        End If

        'If no ArchiveDir directory specified do nothing
        If String.IsNullOrEmpty(ArchiveDir) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=IsCompare", "@arparms.arpmt_import_archive_path", "@!blank" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            EFTImport = 16
            Return 16
        End If

        'If no import directory specified do nothing
        If String.IsNullOrEmpty(ImportPath) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=IsCompare", "@arpmt_import_map.import_path", "@!blank" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            EFTImport = 16
            Return 16
        End If

        Dim importFileServer As String = ""
        Dim importFolderTemplate As String = ""
        Dim importAccessDepth As String = ""
        Dim importFileSpec As String = ""

        Dim archiveFileServer As String = ""
        Dim archiveFolderTemplate As String = ""
        Dim archiveAccessDepth As String = ""
        Dim archiveFileSpec As String = ""
        Dim fileNameListString As String = String.Empty
        Dim fileNameStringArray() As String
        Dim fileContent As String = ""
        Dim moved As Integer = 0
        Dim exists As Integer = 0

        Try
            GetFileServerInfoByLogicalFolderName(ImportPath, importFileServer, importFolderTemplate, importAccessDepth, Infobar)
            ThrowOnException(Infobar)
            GetFileServerInfoByLogicalFolderName(ArchiveDir, archiveFileServer, archiveFolderTemplate, archiveAccessDepth, Infobar)
            ThrowOnException(Infobar)
            importFileSpec = GetFileSpec(importFolderTemplate, "", "", importAccessDepth, True)
            archiveFileSpec = GetFileSpec(archiveFolderTemplate, "", "", archiveAccessDepth, True)

            _fse.GetFiles(importFileSpec, importFileServer, ImportPath, GetFilesAction.File.ToString(), fileNameListString, Infobar)
            ThrowOnException(Infobar)
            fileNameStringArray = Split(fileNameListString, _fileNameSplitString)

            For Each fileName As String In fileNameStringArray
                If fileName.Trim() <> String.Empty Then
                    importFileSpec = GetFileSpec(importFolderTemplate, fileName, "", importAccessDepth, True)
                    Dim fileBytes As Byte() = {0}
                    _fse.GetFileContent(importFileSpec, importFileServer, ImportPath, fileBytes, "", Infobar)
                    fileContent = ByteArrayToString(fileBytes)

                    ResponseData = Me.Context.Commands.Invoke("EFTFiles", "EFTImportSp", MapID, fileName, fileContent, TaskID, Infobar)

                    archiveFileSpec = GetFileSpec(archiveFolderTemplate,
                                                  "[" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + "]" + fileName,
                                                  "", archiveAccessDepth, True)
                    _fse.FileExists(archiveFileSpec, archiveFileServer, ArchiveDir, exists, Infobar)

                    If exists = 0 Then
                        _fse.MoveFileServerToServer(Infobar, moved, importFileServer, importFileSpec, ImportPath,
                                            archiveFileServer, archiveFileSpec, ArchiveDir, 1)
                        If moved = 0 Then
                            Return 16
                        End If
                    Else
                        Return 16
                    End If
                    ThrowOnException(Infobar)
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar + vbCrLf + ":" + " [" & Err.Description + "]"
            Return 16
        End Try
    End Function

    Sub ThrowOnException(ByVal InforBar As String)
        If Not String.IsNullOrEmpty(InforBar) Then
            MGException.Throw(InforBar)
        End If
    End Sub
    Function ByteArrayToString(ByVal byteArray As Byte()) As String
        Return Encoding.ASCII.GetString(byteArray)
    End Function

    Function StringToByteArray(ByVal stringText As String) As Byte()
        Return Encoding.ASCII.GetBytes(stringText)
    End Function

    Function TextToStringCollection(ByVal text As String) As Collection
        Dim stringCollection As Collection = New Collection()
        Dim textInLines As String() = text.Split(New String() {vbNewLine}, StringSplitOptions.RemoveEmptyEntries)
        For Each sLine As String In textInLines
            stringCollection.Add(sLine)
        Next
        Return stringCollection
    End Function

    Sub GetFileServerInfoByLogicalFolderName(ByVal logicalFolderName As String,
                                             ByRef fileServerName As String,
                                             ByRef folderTemplate As String,
                                             ByRef accessDepth As String,
                                             ByRef errMsg As String)
        Using appdb As AppDB = IDORuntime.Context.CreateAppDB()
            Using sql As IDbCommand = appdb.CreateCommand()
                Dim execResult As AppDBExecResult = Nothing
                Try
                    sql.CommandType = CommandType.StoredProcedure
                    sql.CommandText = "GetFileServerInfoByLogicalFolderNameSp"

                    appdb.AddCommandParameterWithValue(sql, "LogicalFolderName", logicalFolderName).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "ServerName", "", ParameterDirection.Output).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "FolderTemplate", "", ParameterDirection.Output).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "FolderAccessDepth", "", ParameterDirection.Output).Size = 100

                    appdb.ExecuteNonQuery(sql)
                    fileServerName = CType(sql.Parameters(1), IDbDataParameter).Value.ToString()
                    folderTemplate = CType(sql.Parameters(2), IDbDataParameter).Value.ToString()
                    accessDepth = CType(sql.Parameters(3), IDbDataParameter).Value.ToString()
                Catch ex As Exception

                End Try
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTMapCreateDataViewSp(ByVal MapId As String, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEFTMapCreateDataViewExt As IEFTMapCreateDataView = New EFTMapCreateDataViewFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iEFTMapCreateDataViewExt.EFTMapCreateDataViewSp(MapId, InfoBar)
            Dim Severity As Integer = result.ReturnCode.Value
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ConvDateWithFormatNumberSp(ByVal pDateFormatNumber As Byte?, ByVal pDate As String, ByRef rDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iConvDateWithFormatNumberExt As IConvDateWithFormatNumber = New ConvDateWithFormatNumberFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, rDate As Date?) = iConvDateWithFormatNumberExt.ConvDateWithFormatNumberSp(pDateFormatNumber, pDate, rDate)
            Dim Severity As Integer = result.ReturnCode.Value
            rDate = result.rDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportInsertSp(ByVal FileName As String, ByVal AppGroup As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEFTImportInsertExt As IEFTImportInsert = New EFTImportInsertFactory().Create(appDb)

            Dim Severity As Integer = iEFTImportInsertExt.EFTImportInsertSp(FileName, AppGroup, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportSp(ByVal MapId As String, ByVal FileName As String, ByVal FileContent As String, ByVal TaskId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEFTImportExt As IEFTImport = New EFTImportFactory().Create(appDb)

            Dim Severity As Integer = iEFTImportExt.EFTImportSp(MapId, FileName, FileContent, TaskId, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTMappedImportsDefineVarSp(ByVal EFTFileName As String, ByVal EFTMapId As String, ByVal EFTReturnFormat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEFTMappedImportsDefineVarExt As IEFTMappedImportsDefineVar = New EFTMappedImportsDefineVarFactory().Create(appDb)

            Dim Severity As Integer = iEFTMappedImportsDefineVarExt.EFTMappedImportsDefineVarSp(EFTFileName, EFTMapId, EFTReturnFormat, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEFTMappedFieldSp(ByVal FileName As String, ByVal AppFieldName As String, ByVal Sequence As Integer?, ByRef FieldValue As String, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetEFTMappedFieldExt As IGetEFTMappedField = New GetEFTMappedFieldFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, FieldValue As String, InfoBar As String) = iGetEFTMappedFieldExt.GetEFTMappedFieldSp(FileName, AppFieldName, Sequence, FieldValue, InfoBar)
            Dim Severity As Integer = result.ReturnCode.Value
            FieldValue = result.FieldValue
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetCustVendNumfromAcctRoutingSp(ByVal Account As String, ByVal RoutingNumber As String, ByRef InfoBar As String) As DataTable
        Dim iGetCustVendNumfromAcctRoutingExt As IGetCustVendNumfromAcctRouting = New GetCustVendNumfromAcctRoutingFactory().Create(Me, True)
        Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iGetCustVendNumfromAcctRoutingExt.GetCustVendNumfromAcctRoutingSp(Account, RoutingNumber, InfoBar)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        InfoBar = result.InfoBar
        Return dt
    End Function
End Class
