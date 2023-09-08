Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports CSI.Finance.AR
Imports Mongoose.MGCore
Imports System.Text

<IDOExtensionClass("SLARPaymentImports")>
Public Class SLARPaymentImports
    Inherits Mongoose.IDO.ExtensionClassBase

    Private _fse As FileServerExtension = New FileServerExtension()
    Private ReadOnly _fileNameSplitString As String = "|"
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ARPaymentImport_ProcessFiles(ByVal MapID As String, ByVal ImportPath As String, ByRef Infobar As String, ByVal TaskID As Integer) As Integer
        Dim sArchiveDir As String
        Dim loadResponse As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData

        ARPaymentImport_ProcessFiles = 0
        sArchiveDir = String.Empty

        If String.IsNullOrEmpty(Infobar) Then
            Infobar = ""
        End If

        'Get the Import and Archive Directories from BOM Bulk Import Parameters
        loadResponse = Me.Context.Commands.LoadCollection("SLArparms", "ArchivePath", "ArparmsKey = 0", "", 0)
        For index As Integer = 0 To loadResponse.Items.Count - 1
            Try
                sArchiveDir = loadResponse(index, "ArchivePath").GetValue(Of String)()
            Catch ex As NullReferenceException
                sArchiveDir = ""
            End Try
        Next

        'If no import directory specified in parms, nothing to do
        If String.IsNullOrEmpty(sArchiveDir) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=IsCompare", "@arparms.arpmt_import_archive_path", "@!blank" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            ARPaymentImport_ProcessFiles = 16
            Return 16
        End If

        'If no import directory specified in parms, nothing to do
        If String.IsNullOrEmpty(ImportPath) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=IsCompare", "@arpmt_import_map.import_path", "@!blank" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            ARPaymentImport_ProcessFiles = 16
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
        Dim deleted As Integer = 0
        Try
            GetFileServerInfoByLogicalFolderName(ImportPath, importFileServer, importFolderTemplate, importAccessDepth, Infobar)
            ThrowOnException(Infobar)
            GetFileServerInfoByLogicalFolderName(sArchiveDir, archiveFileServer, archiveFolderTemplate, archiveAccessDepth, Infobar)
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
                    'Call the processing method/SP, passing the sFileFullname
                    Try
                        ResponseData = Me.Invoke("ARPaymentImportSp", MapID, fileName, fileContent, TaskID, Infobar)



                        If ResponseData.IsReturnValueStdError() Then
                            Infobar = "Call to ARPaymentImportSp failed"
                            ARPaymentImport_ProcessFiles = 16
                            Exit For
                        End If
                    Catch
                        Infobar = Err.Description
                        ARPaymentImport_ProcessFiles = 16
                        Exit For
                    End Try

                    archiveFileSpec = GetFileSpec(archiveFolderTemplate,
                                                  "[" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + "]" + fileName,
                                                  "", archiveAccessDepth, True)
                    _fse.FileExists(archiveFileSpec, archiveFileServer, sArchiveDir, exists, Infobar)

                    If exists = 0 Then
                        _fse.MoveFileServerToServer(Infobar, moved, importFileServer, importFileSpec, ImportPath,
                                            archiveFileServer, archiveFileSpec, sArchiveDir, 1)
                        If moved = 0 Then
                            Return 16
                        End If
                    Else
                        Return 16
                    End If

                    _fse.FileExists(importFileSpec, importFileServer, ImportPath, exists, Infobar)

                    If exists = 1 Then
                        _fse.DeleteFromFileServer(importFileServer, importFileSpec, ImportPath, deleted, Infobar)

                        If deleted = 0 Then
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
    Public Function AREFTImportValidateSp(ByVal SourceSite As String, ByVal BatchId As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAREFTImportValidateExt As IAREFTImportValidate = New AREFTImportValidateFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iAREFTImportValidateExt.AREFTImportValidateSp(SourceSite, BatchId, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ARPaymentImportProcessSp(ByVal BatchID As Decimal?, ByVal HeaderNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iARPaymentImportProcessExt As IARPaymentImportProcess = New ARPaymentImportProcessFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iARPaymentImportProcessExt.ARPaymentImportProcessSp(BatchID, HeaderNum, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CanImportPmtDeletedSp(ByVal BatchID As Decimal?, ByRef DeleteEnabled As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCanImportPmtDeletedExt As ICanImportPmtDeleted = New CanImportPmtDeletedFactory().Create(appDb)

            Dim oDeleteEnabled As FlagNyType = DeleteEnabled

            Dim Severity As Integer = iCanImportPmtDeletedExt.CanImportPmtDeletedSp(BatchID, oDeleteEnabled)

            DeleteEnabled = oDeleteEnabled

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ARPaymentImportSp(ByVal MapId As String, ByVal Filename As String, ByVal FileContent As String, ByVal TaskId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iARPaymentImportExt As IARPaymentImport = New ARPaymentImportFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iARPaymentImportExt.ARPaymentImportSp(MapId, Filename, FileContent, TaskId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportEFTArpmntdSp(ByVal BatchId As Decimal?, ByVal HeaderNumber As Integer?, ByVal InvNum As String, ByVal DetailAmount As Decimal?, ByVal EffectiveDate As DateTime?, ByRef AppToCustomer As String, ByRef ArpmtdForAmtApplied As Decimal?, ByRef ArpmtdForDiscAmt As Decimal?, ByRef ArpmtdDomAmtApplied As Decimal?, ByRef ArpmtdDomDiscAmt As Decimal?, ByRef ArpmtdExchRate As Decimal?, ByRef LineNumber As Integer?, ByRef Site As String, ByRef RefRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEFTImportEFTArpmntdExt As IEFTImportEFTArpmntd = New EFTImportEFTArpmntdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AppToCustomer As String, ArpmtdForAmtApplied As Decimal?, ArpmtdForDiscAmt As Decimal?, ArpmtdDomAmtApplied As Decimal?, ArpmtdDomDiscAmt As Decimal?, ArpmtdExchRate As Decimal?, LineNumber As Integer?, Site As String, RefRowPointer As Guid?, Infobar As String) = iEFTImportEFTArpmntdExt.EFTImportEFTArpmntdSp(BatchId, HeaderNumber, InvNum, DetailAmount, EffectiveDate, AppToCustomer, ArpmtdForAmtApplied, ArpmtdForDiscAmt, ArpmtdDomAmtApplied, ArpmtdDomDiscAmt, ArpmtdExchRate, LineNumber, Site, RefRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AppToCustomer = result.AppToCustomer
            ArpmtdForAmtApplied = result.ArpmtdForAmtApplied
            ArpmtdForDiscAmt = result.ArpmtdForDiscAmt
            ArpmtdDomAmtApplied = result.ArpmtdDomAmtApplied
            ArpmtdDomDiscAmt = result.ArpmtdDomDiscAmt
            ArpmtdExchRate = result.ArpmtdExchRate
            LineNumber = result.LineNumber
            Site = result.Site
            RefRowPointer = result.RefRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportEFTArpmntSp(ByVal MapId As String, ByVal Filename As String, ByVal CustNum As String, ByVal CustName As String, ByVal CheckNum As String, ByVal DepositDate As DateTime?, ByVal CheckAmt As Decimal?, ByVal RoutingNum As String, ByVal AccountNum As String, ByVal PaymentType As String, ByVal Stat As String, ByRef BatchId As Decimal?, ByRef HeaderNum As Integer?, ByRef RefRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEFTImportEFTArpmntExt As IEFTImportEFTArpmnt = New EFTImportEFTArpmntFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BatchId As Decimal?, HeaderNum As Integer?, RefRowPointer As Guid?, Infobar As String) = iEFTImportEFTArpmntExt.EFTImportEFTArpmntSp(MapId, Filename, CustNum, CustName, CheckNum, DepositDate, CheckAmt, RoutingNum, AccountNum, PaymentType, Stat, BatchId, HeaderNum, RefRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BatchId = result.BatchId
            HeaderNum = result.HeaderNum
            RefRowPointer = result.RefRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
