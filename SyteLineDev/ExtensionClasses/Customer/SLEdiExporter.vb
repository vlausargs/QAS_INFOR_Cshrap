Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient

<IDOExtensionClass("SLEdiParms")>
Public Class SLEdiExporter
    Inherits ExtensionClassBase

    Private singleFile As String
    Private archiveFileExt As String
    'Private userName As String

    Private processId As String
    'Private siteName As String
    Private ReadOnly ediFile As String
    Private ReadOnly hdrEdiFile As String
    Private ReadOnly dtlEdiFile As String
    Private ReadOnly archiveFile As String
    Private ReadOnly hdrArchiveFile As String
    Private ReadOnly dtlArchiveFile As String
    Private ReadOnly logFile As String
    Private ReadOnly sqlCommand As String
    Private ReadOnly spStatus As Boolean
    Private bExportSup As Boolean
    Private bExportDem As Boolean
    ' supply side parameters
    Private supTpCode As String
    Private supObDataDir As String
    Private supObArchiveDir As String
    Private supEdiLogDir As String
    Private supEdiLogFile As String

    ' demand side parameters
    Private demTpCode As String
    Private obDataDir As String
    Private obArchiveDir As String
    Private ediLogDir As String
    Private ediLogFile As String
    Private serverOper As SLServerOperations = New SLServerOperations()
    Private fileOps As SLFileOperations = New SLFileOperations(serverOper)


    Public ReadOnly Property EdiServerOps As SLServerOperations
        Get
            Return serverOper
        End Get
    End Property

    Public ReadOnly Property EdiFileOps As SLFileOperations
        Get
            Return fileOps
        End Get
    End Property

    Private Sub SLEdiExporter(ByRef pID As String)
        Dim sqlCommand As String
        Dim results As DataTable
        sqlCommand = "SELECT sup.tp_code, sup.ob_data_dir, sup.ob_archive_dir, sup.edi_log_dir, dem.tp_code dm_tp_code, dem.ob_data_dir dm_ob_data_dir, dem.ob_archive_dir dm_ob_archive_dir, dem.edi_log_dir dm_edi_log_dir, dem.single_flatfile, dbo.EdiJulStmp(getdate()) JulStmp From sup_edi_parms sup full outer join edi_parms dem on sup.parm_key = dem.parm_key where dem.parm_key = 0"
        results = serverOper.SelectData(sqlCommand, pID)
        supTpCode = serverOper.GetSQLDMOColumnValue(results, 0, 0)
        supObDataDir = serverOper.GetSQLDMOColumnValue(results, 0, 1)
        supObArchiveDir = serverOper.GetSQLDMOColumnValue(results, 0, 2)
        supEdiLogDir = serverOper.GetSQLDMOColumnValue(results, 0, 3)
        demTpCode = serverOper.GetSQLDMOColumnValue(results, 0, 4)
        obDataDir = serverOper.GetSQLDMOColumnValue(results, 0, 5)
        obArchiveDir = serverOper.GetSQLDMOColumnValue(results, 0, 6)
        ediLogDir = serverOper.GetSQLDMOColumnValue(results, 0, 7)
        singleFile = serverOper.GetSQLDMOColumnValue(results, 0, 8)
        archiveFileExt = serverOper.GetSQLDMOColumnValue(results, 0, 9)
    End Sub

    Public Sub ExportEDI(ByRef pID As String, ByRef userName As String, ByRef siteName As String)
        If Not serverOper.InitSession(processId, userName, siteName) Then
            fileOps.LogError(ediLogDir, logFile, "Could not initial session context for site (" & siteName & ") using user name (" & userName & ").")
            ExitEDI()
        End If
        SLEdiExporter(pID)
        processId = pID
        If demTpCode = "" And obDataDir = "" And obArchiveDir = "" And ediLogDir = "" Then
            bExportDem = False
        Else
            bExportDem = True
        End If
        If supTpCode = "" And supObDataDir = "" And supObArchiveDir = "" And supEdiLogDir = "" Then
            bExportSup = False
        Else
            bExportSup = True
        End If

        If bExportDem Then
            ediLogFile = "editrans" & DateTime.Now.ToString("yyyyMMdd_hhmmssmm") & ".log"

            ' log the begining of the export process
            ' EDI DOWNLOAD STARTED
            serverOper.logError("EdiProcessLogSp", processId, "51", "", 0, 1)

            'log: Demand Side Messages
            serverOper.logError("EdiProcessLogSp", processId, "22", "", 0, 1)


            ' **************************
            ' ** 855 ACKNOWLEDGEMENTS **
            ' **************************
            serverOper.logError("EdiProcessLogSp", processId, "52", "ACK-P", 0, 1)

            ExportProcess("855", processId)

            ' *******************************
            ' ** 856 ADVANCED SHIP NOTICES **
            ' *******************************
            serverOper.logError("EdiProcessLogSp", processId, "52", "ASN-P", 0, 1)

            ExportProcess("856", processId)

            ' ******************
            ' ** 810 INVOICES **
            ' ******************
            serverOper.logError("EdiProcessLogSp", processId, "52", "INV-P", 0, 1)
            ExportProcess("810", processId)

        End If  ' Export Demand EDI Data

        If bExportSup Then
            supEdiLogFile = "editrans" & DateTime.Now.ToString("yyyyMMdd_hhmmssmm") & ".log"

            'log: Supply Side Messages
            serverOper.logError("EdiProcessLogSp", processId, "26", "", 0, 1)


            ' *******************************
            ' **  PLANNED PURCHASE ORDERS  **
            ' *******************************
            serverOper.logError("EdiProcessLogSp", processId, "52", "PLNPO-P", 0, 1)
            ExportProcess("830", processId)


            ' ***********************
            ' **  PURCHASE ORDERS  **
            ' ***********************
            serverOper.logError("EdiProcessLogSp", processId, "52", "PO-P", 0, 1)
            ExportProcess("850", processId)


            ' **************************
            ' **  SHIPPING SCHEDULES  **
            ' **************************
            serverOper.logError("EdiProcessLogSp", processId, "52", "SHSCH-P", 0, 1)
            ExportProcess("862", processId)


        End If  ' Export Supply EDI Data

        ' log the end of the export process
        ' EDI DOWNLOAD ENDED
        serverOper.logError("EdiProcessLogSp", processId, "53", "", 0, 1)


        ' create log file
        fileOps.CreateLogFile(ediLogDir, ediLogFile, processId)

        If ediLogDir <> supEdiLogDir Then
            fileOps.CreateLogFile(supEdiLogDir, supEdiLogFile, processId)
        End If
    End Sub


    Private Function ExportProcess(ByVal FileType As String, ByVal pID As String) As Boolean
        Dim recCount As Integer
        Dim exportLines As DataTable = New DataTable()
        Dim spToExecute As String = ""
        Dim RecType As String = ""
        Dim ediFile As String = ""
        Dim archiveFile As String = ""
        Dim ediFile2 As String = ""
        Dim archiveFile2 As String = ""
        Dim lockFile As String = ""
        Dim ediLogicalFolder As String = ""
        Dim archiveLogicalFolder As String = ""
        Dim errMsg As String = ""
        Dim existingFileLines As String = ""
        SLEdiExporter(pID)
        ExportProcess = True
        ediFile2 = ""
        archiveFile2 = ""
        lockFile = ""
        fileOps.ProcessID = pID

        Try
            Select Case FileType
                'Demand Transactions
                Case "810"
                    spToExecute = "EdiOutInvPSp"
                    ediFile = "IINV_HDR." & demTpCode
                    archiveFile = "INVH" & archiveFileExt

                    ediLogicalFolder = obDataDir
                    archiveLogicalFolder = obArchiveDir

                    If singleFile = "0" Then
                        ediFile2 = "IINV_DTL." & demTpCode
                        archiveFile2 = "INVD" & archiveFileExt
                    End If
                    lockFile = "INV_LOCK"
                Case "855"
                    spToExecute = "EdiOutAckPSp"
                    ediFile = "855_IMP." & demTpCode
                    archiveFile = "ACK" & archiveFileExt
                    lockFile = "ACK_LOCK"

                    ediLogicalFolder = obDataDir
                    archiveLogicalFolder = obArchiveDir
                Case "856"
                    spToExecute = "EdiOutAsnPSp"
                    ediFile = "SSEQ_HDR." & demTpCode
                    archiveFile = "SEQH" & archiveFileExt

                    ediLogicalFolder = obDataDir
                    archiveLogicalFolder = obArchiveDir
                    If singleFile = "0" Then
                        ediFile2 = "SSEQ_DTL." & demTpCode
                        archiveFile2 = "SEQD" & archiveFileExt
                    End If
                    lockFile = "ASN_LOCK"
                    'Supply Transactions
                Case "830"
                    spToExecute = "EdiOutPlnpoPSp"
                    ediFile = "830_WRK." & supTpCode
                    archiveFile = "830" & archiveFileExt
                    lockFile = "830_LOCK"
                    ediLogicalFolder = supObDataDir
                    archiveLogicalFolder = obArchiveDir
                Case "850"
                    spToExecute = "EdiOutPoPSp"
                    ediFile = "850_WRK." & supTpCode
                    archiveFile = "850" & archiveFileExt
                    lockFile = "850_LOCK"
                    ediLogicalFolder = supObDataDir
                    archiveLogicalFolder = supObArchiveDir
                Case "862"
                    spToExecute = "EdiOutShschPSp"
                    ediFile = "862_WRK." & supTpCode
                    archiveFile = "862" & archiveFileExt
                    lockFile = "862_LOCK"
                    ediLogicalFolder = supObDataDir
                    archiveLogicalFolder = supObArchiveDir
            End Select

            ' Create Lockfile
            lockFile += ".txt"
            If Not fileOps.CreateLockFile(ediLogicalFolder, lockFile) And Not String.IsNullOrEmpty(lockFile) Then
                serverOper.logError("EdiProcessLogSp", pID, "55", lockFile, 0, 1)
            End If

            ' Run the SP to create tmp_edi_output  records
            If Not serverOper.ExecuteEDISP(spToExecute, pID) And Not String.IsNullOrEmpty(spToExecute) Then
                AbnormalExit(ediLogicalFolder, lockFile)
                Exit Function
            End If

            ' Set RecType to 'HDR' if using multiple flat files for this transaction
            If singleFile = "0" And ediFile2 <> "" Then
                RecType = "H"
            Else
                RecType = "%"
            End If

            ' Load tmp_edi_output file into collection
            exportLines = serverOper.LoadCollectionFromTmp(pID, FileType, RecType)
            If exportLines Is Nothing Or exportLines.Rows.Count <= 0 Then
                recCount = 0
                EndTran(pID, FileType, lockFile, ediLogicalFolder)
                Exit Function
            End If

            ' check for an existing EDI file
            If fileOps.CheckForFile(ediFile, ediLogicalFolder, errMsg) Then
                serverOper.logError("EdiProcessLogSp", pID, "10", "Existing EdiFile " & ediFile & " Found", 0, 1)
                ' If found, load existing flat file information into existingFileLines string
                existingFileLines = fileOps.LoadExistingFile(ediFile, ediLogicalFolder, FileType, "100", errMsg)
            End If

            ' Output collection to flat file
            If Not fileOps.ExportFile(ediLogicalFolder, ediFile, exportLines, existingFileLines) And Not String.IsNullOrEmpty(ediFile) Then
                AbnormalExit(ediLogicalFolder, lockFile)
                Exit Function
            End If

            ' Copy Data File to the Archive
            If Not fileOps.archiveFile(ediFile, archiveFile, ediLogicalFolder, archiveLogicalFolder, "", False) And Not String.IsNullOrEmpty(archiveFile) Then
                serverOper.logError("EdiProcessLogSp", pID, "25", "", 0, 1)
            End If

            ' Process Detail if not using a single flat file for this transaction
            If singleFile = "0" And ediFile2 <> "" Then
                RecType = "D"
                exportLines = serverOper.LoadCollectionFromTmp(pID, FileType, RecType)

                If exportLines Is Nothing Or exportLines.Rows.Count <= 0 Then
                    recCount = 0
                    EndTran(pID, FileType, lockFile, ediLogicalFolder)
                    Exit Function
                End If

                ' check for an existing EDI file
                If fileOps.CheckForFile(ediFile2, ediLogicalFolder, errMsg) Then
                    serverOper.logError("EdiProcessLogSp", pID, "10", "Existing EdiFile " & ediFile2 & " Found", 0, 1)
                    ' If found, load existing flat file information into existingFileLines string
                    existingFileLines = fileOps.LoadExistingFile(ediFile2, ediLogicalFolder, FileType, "100", errMsg)
                End If

                ' Output collection to flat file
                If Not fileOps.ExportFile(ediLogicalFolder, ediFile2, exportLines, existingFileLines) Then
                    AbnormalExit(ediLogicalFolder, lockFile)
                    Exit Function
                End If

                ' Copy Data File to the Archive
                If Not fileOps.archiveFile(ediFile2, archiveFile2, ediLogicalFolder, archiveLogicalFolder, "", False) Then
                    serverOper.logError("EdiProcessLogSp", pID, "25", ediFile2, 0, 1)
                End If
            End If
        Catch ex As Exception
            ExitEDI()
        End Try
        EndTran(pID, FileType, lockFile, ediLogicalFolder)
    End Function
    Private Function ExitEDI() As Boolean
        serverOper.CloseSession(processId)
        Return False
    End Function

    Private Sub AbnormalExit(ByVal logicalFolderName As String, ByRef lockFile As String)
        fileOps.DeleteLockfile(logicalFolderName, lockFile)
    End Sub

    Private Sub EndTran(ByRef pID As String, ByRef FileType As String, ByRef lockFile As String, ByVal logicalFolderName As String)
        If Not serverOper.ClearTempTable(pID, FileType) Then
            ExitEDI()
        End If
        If Not fileOps.DeleteLockfile(logicalFolderName, lockFile) Then
            ExitEDI()
        End If
    End Sub
End Class

