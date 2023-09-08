Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.DataAccess

Public Class SLEdiImporter
    Private CmdParser As SLCmdLineParser
    Private ServerOps As SLServerOperations
    Private fileOps As SLFileOperations
    Private definitions As SLDefinition850


    Public ReadOnly Property EdiServerOps As SLServerOperations
        Get
            Return ServerOps
        End Get
    End Property

    Public ReadOnly Property EdiFileOps As SLFileOperations
        Get
            Return fileOps
        End Get
    End Property


    Public Sub New()
        CmdParser = New SLCmdLineParser()
        ServerOps = New SLServerOperations()
        fileOps = New SLFileOperations(ServerOps)
        definitions = New SLDefinition850()
    End Sub

    Public Sub Dispose()
        CmdParser = Nothing
        fileOps.Dispose()

        ServerOps.Dispose()
        definitions = Nothing
    End Sub


    Public Sub ImportEDI(ByRef pID As String, ByRef userName As String, ByRef siteName As String)
        'Dim insertStmts As Collection
        On Error GoTo ErrorEDI

        Dim processId As String
        Dim ediFile As String
        Dim hdrEdiFile As String
        Dim dtlEdiFile As String
        Dim archiveFile As String
        Dim hdrArchiveFile As String
        Dim dtlArchiveFile As String
        Dim logFile As String
        Dim FileType As String
        Dim sqlCommand As String
        Dim spStatus As Boolean
        Dim lockFile As String

        ' supply side parameters
        Dim supTpCode As String
        Dim supIbDataDir As String
        Dim supIbArchiveDir As String
        Dim supEdiLogDir As String
        Dim supEdiLogFile As String

        ' demand side parameters
        Dim tpCode As String
        Dim ibDataDir As String
        Dim ibArchiveDir As String
        Dim ediLogDir As String
        Dim ediLogFile As String
        Dim singleFile As String
        Dim archiveFileExt As String

        processId = pID

        ' set process id for file operations
        fileOps.ProcessID = processId

        fileOps.ServerOps = ServerOps

        If Not ServerOps.InitSession(processId, userName, siteName) Then
            GoTo ExitEDI
        End If

        ' set some SQL system options
        Dim results As DataTable

        ' query edi parameters
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Selecting EDI Parameters Information", 0, 1)
        sqlCommand = "SELECT sep.tp_code as suptp_code, sep.ib_data_dir as sepib_data_dir, sep.ib_archive_dir as sepib_archive_dir, sep.edi_log_dir as sepedi_log_dir"
        sqlCommand += ", ep.tp_code  as eptp_code, ep.ib_data_dir as epib_data_dir, ep.ib_archive_dir as epib_archive_dir, ep.edi_log_dir as epedi_log_dir, ep.single_flatfile as epsingle_flatfile, dbo.EdiJulStmp(getdate()) as EdiDateStmp"
        sqlCommand += " From sup_edi_parms sep FULL outer join edi_parms ep on sep.parm_key = ep.parm_key where ep.parm_key = 0"
        results = ServerOps.SelectData(sqlCommand, processId)
        If results Is Nothing Then
            ServerOps.LogError("EdiProcessLogSp", processId, "PARMS", "", 0, 0)
            GoTo ExitEDI
        End If

        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading Supply Parameter Variables", 0, 1)
        supTpCode = ServerOps.GetSQLDMOColumnValue(results, 0, 0)
        supIbDataDir = ServerOps.GetSQLDMOColumnValue(results, 0, 1)
        supIbArchiveDir = ServerOps.GetSQLDMOColumnValue(results, 0, 2)
        supEdiLogDir = ServerOps.GetSQLDMOColumnValue(results, 0, 3)

        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading Demand Parameter Variables", 0, 1)
        tpCode = ServerOps.GetSQLDMOColumnValue(results, 0, 4)
        ibDataDir = ServerOps.GetSQLDMOColumnValue(results, 0, 5)
        ibArchiveDir = ServerOps.GetSQLDMOColumnValue(results, 0, 6)
        ediLogDir = ServerOps.GetSQLDMOColumnValue(results, 0, 7)
        singleFile = ServerOps.GetSQLDMOColumnValue(results, 0, 8)
        archiveFileExt = ServerOps.GetSQLDMOColumnValue(results, 0, 9)

        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading EDI LogFile Variables", 0, 1)
        supEdiLogFile = "editrans" & DateTime.Now.ToString("yyyyMMdd_hhmmssmm") & ".log"
        ediLogFile = "editrans" & DateTime.Now.ToString("yyyyMMdd_hhmmssmm") & ".log"

        ' log the begining of the import process
        ' EDI UPLOAD STARTED
        ServerOps.LogError("EdiProcessLogSp", processId, "1", "", 0, 1)


        'log: Demand Side Messages
        ServerOps.LogError("EdiProcessLogSp", processId, "22", "", 0, 1)

        'log: Loading Transaction Type RPO
        ServerOps.LogError("EdiProcessLogSp", processId, "5", "RPO", 0, 1)

        ' Load Purchase Orders (850/860)
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading Purchase Orders (850/860) Variables", 0, 1)
        FileType = "850"  'edi-in/order-in.p (Load EDI Customer Orders)
        ediFile = "850_EXP." & tpCode
        archiveFile = "PO" & archiveFileExt
        lockFile = "ORD_LOCK"
        ImportProcess(FileType, processId, ediFile, ibDataDir, archiveFile, ibArchiveDir, lockFile, ibDataDir, userName, False)

        'log: Loading Transaction Type BPO
        ServerOps.LogError("EdiProcessLogSp", processId, 5, "BPO", 0, 1)

        'Load Customer Requirements (830/862)
        If singleFile = "1" Then
            ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading EDI Planning Order/Shipping Schedule-(830/862) Variables (Single File - RSEQ_HDR)", 0, 1)
            ' if SingleFile option is set there is only one file to load
            FileType = "830"  'edi-in/req-in.p (Load EDI Customer Requirements)
            ediFile = "RSEQ_HDR." & tpCode
            archiveFile = "RH" & archiveFileExt
            lockFile = "REQ_LOCK"
            ImportProcess(FileType, processId, ediFile, ibDataDir, archiveFile, ibArchiveDir, lockFile, ibDataDir, userName, False)
        Else
            'two files to load, header and detail
            ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading EDI Planning Order/Shipping Schedule-(830/862) Variables (Multiple Files) RSEQ_HDR", 0, 1)
            FileType = "830_HDR"  'edi-in/req-in.p (Load EDI Customer Requirements)
            hdrEdiFile = "RSEQ_HDR." & tpCode
            hdrArchiveFile = "RH" & archiveFileExt
            lockFile = "REQ_LOCK"
            If ImportProcess(FileType, processId, hdrEdiFile, ibDataDir, hdrArchiveFile, ibArchiveDir, lockFile, ibDataDir, userName, False) Then
                FileType = "830_DTL"  'edi-in/req-in.p (Load EDI Customer Requirements)
                dtlEdiFile = "RSEQ_DTL." & tpCode
                dtlArchiveFile = "RD" & archiveFileExt
                ImportProcess(FileType, processId, dtlEdiFile, ibDataDir, dtlArchiveFile, ibArchiveDir, lockFile, ibDataDir, userName, True)


                ' now archive the header file
                ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Archiving EDI Planning Order/Shipping Schedule-(830/862) RSEQ_HDR", 0, 1)
                If Not fileOps.archiveFile(hdrEdiFile, hdrArchiveFile, ibDataDir, ibArchiveDir, "", True) Then
                    ServerOps.LogError("EdiProcessLogSp", processId, "25", ediFile, 0, 1)
                End If

            End If
        End If


        'log: Loading Transaction Type SHIP
        ServerOps.LogError("EdiProcessLogSp", processId, "5", "SHIP", 0, 1)

        'Load CARaS EDI ship transactions
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading CARaS EDI Ship Transactions Variables SHIP_HDR", 0, 1)
        FileType = "SHIP_HDR" 'api/ship-in.p (Load EDI Shipments)
        hdrEdiFile = "SINT_HDR." & tpCode
        hdrArchiveFile = "SH" & archiveFileExt
        lockFile = "SHP_LOCK"
        If ImportProcess(FileType, processId, hdrEdiFile, ibDataDir, hdrArchiveFile, ibArchiveDir, lockFile, ibDataDir, userName, False) Then
            ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading CARaS EDI Ship Transactions Variables SHIP_DTL", 0, 1)
            FileType = "SHIP_DTL" 'api/ship-in.p (Load EDI Shipments)
            dtlEdiFile = "SINT_DTL." & tpCode
            dtlArchiveFile = "SD" & archiveFileExt
            ImportProcess(FileType, processId, dtlEdiFile, ibDataDir, dtlArchiveFile, ibArchiveDir, lockFile, ibDataDir, userName, True)

            ' now archive the header file
            ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Archiving CARaS EDI Ship Transactions SHIP_HDR", 0, 1)
            If Not fileOps.archiveFile(hdrEdiFile, hdrArchiveFile, ibDataDir, ibArchiveDir, "", True) Then
                ServerOps.LogError("EdiProcessLogSp", processId, "25", ediFile, 0, 1)
            End If
        End If

        ' auto-post ship transactions
        ServerOps.DoTransactionBlock("BEGIN")
        spStatus = ServerOps.ExecuteEDISP("EdiInAutoPostDccoSp", processId, userName)
        If spStatus Then
            ServerOps.DoTransactionBlock("COMMIT")
        Else
            ServerOps.DoTransactionBlock("ROLLBACK")
        End If

        ' auto-post edi_co
        ServerOps.DoTransactionBlock("BEGIN")
        spStatus = ServerOps.ExecuteEDISP("EdiInAutoPostEdiCoSp", processId, userName)
        If spStatus Then
            ServerOps.DoTransactionBlock("COMMIT")
        Else
            ServerOps.DoTransactionBlock("ROLLBACK")
        End If

        'log: Supply Side Messages
        ServerOps.LogError("EdiProcessLogSp", processId, "26", "", 0, 1)

        'log: Loading Transaction Type PO-ACK
        ServerOps.LogError("EdiProcessLogSp", processId, 5, "PO-ACK", 0, 1)

        ' Load PO Acknowledgments
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading PO Acknowledgments Variables 855_DTL", 0, 1)
        FileType = "855"  'edi-in/poack-in.p (Load EDI Vendor PO Acknowledgments)
        ediFile = "855_DTL." & supTpCode
        archiveFile = "ACK" & archiveFileExt
        lockFile = "855_LOCK"
        ImportProcess(FileType, processId, ediFile, supIbDataDir, archiveFile, supIbArchiveDir, lockFile, ibDataDir, userName, False)
        'auto-post PO Acknowledgements
        ServerOps.DoTransactionBlock("BEGIN")
        spStatus = ServerOps.ExecuteEDISP("EdiInAutoPostPoackSp", processId, userName)
        If spStatus Then
            ServerOps.DoTransactionBlock("COMMIT")
        Else
            ServerOps.DoTransactionBlock("ROLLBACK")
        End If

        'log: Loading Transaction Type PO-VSN
        ServerOps.LogError("EdiProcessLogSp", processId, 5, "PO-VSN", 0, 1)

        'Load Vendor Ship Notices
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading Vendor Ship Notices Variables 856_DTL", 0, 1)
        FileType = "856"  'edi-in/povsn-in.p (Load Vendor Shipment Notices)
        ediFile = "856_DTL." & supTpCode
        archiveFile = "VSN" & archiveFileExt
        lockFile = "856_LOCK"
        ImportProcess(FileType, processId, ediFile, supIbDataDir, archiveFile, supIbArchiveDir, lockFile, ibDataDir, userName, False)
        'log: Loading Transaction Type PO-INV
        ServerOps.LogError("EdiProcessLogSp", processId, 5, "PO-INV", 0, 1)

        'Load Vendor Invoices
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-Loading Vendor Invoice Variables 810_DTL", 0, 1)
        FileType = "810"  'edi-in/poinv-in.p (Load Vendor EDI Invoices)
        ediFile = "810_DTL." & supTpCode
        archiveFile = "INV" & archiveFileExt
        lockFile = "810_LOCK"
        ImportProcess(FileType, processId, ediFile, supIbDataDir, archiveFile, supIbArchiveDir, lockFile, ibDataDir, userName, False)

        ' log the end of the import process
        ' EDI UPLOAD ENDED
        ServerOps.LogError("EdiProcessLogSp", processId, "2", "", 0, 1)

        ' create log file
        fileOps.CreateLogFile(ediLogDir, ediLogFile, processId)

        If ediLogDir <> supEdiLogDir Then
            fileOps.CreateLogFile(supEdiLogDir, supEdiLogFile, processId)
        End If

ExitEDI:
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-SLEdiImporter.ImportEDI-ExitEDI", 0, 1)
        ' CloseSession
        ServerOps.CloseSession(processId)

        results = Nothing
        Exit Sub

ErrorEDI:

        ServerOps.LogError("EdiProcessLogSp", processId, "24", ediFile, 0, 1)
        ' CloseSession
        ServerOps.CloseSession(processId)

        'fileOps.DeleteFile(lockFile)
        results = Nothing

    End Sub

    Public Function WriteBgTaskLog(ByVal pId As String, ByRef infobarText As String, ByRef messageSeverity As Integer) As Boolean
        Return ServerOps.WriteBgTaskLog(pId, infobarText, messageSeverity)
    End Function

    Public Function ImportProcess(ByVal FileType As String, ByVal processId As String,
                                  ByVal ediFile As String, ByVal ediLogicalFolder As String,
                                  ByVal archiveFile As String, ByVal archiveLogicalFolder As String,
                                  ByVal lockFile As String, ByVal lockFileLogicalFolder As String,
                                  ByVal userName As String, ByVal SkipBeginTran As Boolean) As Boolean
        On Error GoTo ErrorEDI

        Dim insertStmts As Collection
        Dim spToExecute As String
        Dim commitInsert As Boolean
        Dim newTransaction As Boolean
        Dim commitTransaction As Boolean
        Dim bStartedTransaction As Boolean

		ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Starting (FileType:" + FileType + ") (FileName:" + ediFile + ")***", 0, 1)
        ImportProcess = True


        Select Case FileType
            Case "850"                  'edi-in/order-in.p (Load EDI Customer Orders)
                spToExecute = "EdiInOrderInSp"
            Case "830_HDR"              'edi-in/req-in.p (Load EDI Customer Requirements)
                spToExecute = vbNullString
            Case "830", "830_DTL"       'edi-in/req-in.p (Load EDI Customer Requirements)
                spToExecute = "EdiInReqInSp"
            Case "SHIP_HDR"             'api/ship-in.p (Load EDI Shipments)
                spToExecute = vbNullString
            Case "SHIP_DTL"             'api/ship-in.p (Load EDI Shipments)
                spToExecute = "EdiInShipInSp"
            Case "810"                  'edi-in/poinv-in.p (Load Vendor EDI Invoices)
                spToExecute = "EdiInPoinvInSp"
            Case "855"                  'edi-in/poack-in.p (Load EDI Vendor PO Acknowledgments)
                spToExecute = "EdiInPoackInSp"
            Case "856"                  'edi-in/povsn-in.p (Load Vendor Shipment Notices) ????
                spToExecute = "EdiInPovsnInSp"
            Case Else
                spToExecute = vbNullString
        End Select

        Dim errMsg As String = ""

        ' check for existance of the EDI file to import
        ' if file does not exist it is now safe to log the error into the database
		ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Checking For Existence Of EDI File To Import(FileType:" + FileType + ") (FileName:" + ediFile + ") (EDILogicalFolder:" + ediLogicalFolder + ")", 0, 1)
        If Not fileOps.CheckForFile(ediFile, ediLogicalFolder, errMsg) Then
            GoTo ExitEDI
        End If

        ' Create the Lock -- if it already exists, don't load the file
		ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Create The Lock File(" + lockFile + "). If It Already Exists, Don't Load The EDI File", 0, 1)
        If Not fileOps.CreateLockFile(ediLogicalFolder, lockFile) Then
            GoTo ExitEDI
        End If

        ' load the file into the collection of lines
		ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Load The EDI File Into The Collection Of Lines(FileType:" + FileType + ") (FileName:" + ediFile + ")", 0, 1)
        If Not fileOps.LoadFile(ediFile, ediLogicalFolder, FileType, "100", errMsg) Then
            GoTo ExitEDI
        End If

        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Getting Insert Statements", 0, 1)
        insertStmts = definitions.GetInsertStatements(FileType, processId, fileOps.ediLines)

        ' insert into staging tables and call to processing sp should be within the same transaction
        ' processing sp deletes the staging tables
        ' however if there is error in the sp, it will not get to the part where it deletes staging records
        ' and the insert should be rolled back
        ' if there is no sp to run we want to commit insert transaction
        If spToExecute = vbNullString Then
            commitInsert = True
            newTransaction = True
            commitTransaction = True
        Else
            commitInsert = False
            newTransaction = False
            commitTransaction = True
        End If

        ' process insert statements and commit them to database
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Running Insert Statements", 0, 1)
        If SkipBeginTran = False Then
            ServerOps.DoTransactionBlock("BEGIN")
        End If
        bStartedTransaction = True
        If Not ServerOps.RunInsertStatements(insertStmts, processId, commitInsert) Then
            bStartedTransaction = False
            GoTo ExitEDI
        End If

        ' for 830_HDR and SHIP_HDR file types we don't execute an sp
        ' also the files will be archived after the detail transaction executes
        ' that is why we can end at this point
        If spToExecute = vbNullString Then
            fileOps.DeleteLockfile(ediLogicalFolder, lockFile)
            GoTo EndProcess
        End If

        ' execute processing sp
        ServerOps.LogError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Executing Processing SP", 0, 1)
        If Not String.IsNullOrEmpty(spToExecute) Then
            If Not ServerOps.ExecuteEDISP(spToExecute, processId, userName) Then
                bStartedTransaction = False
                GoTo ExitEDI
            End If
        End If
        ServerOps.DoTransactionBlock("COMMIT")
        bStartedTransaction = False

        ' now archive the file
        ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - Archiving EDI File(FileType:" + FileType + ") (FileName:" + ediFile + ")", 0, 1)
        If Not fileOps.archiveFile(ediFile, archiveFile, ediLogicalFolder, archiveLogicalFolder, errMsg, True) Then
            ServerOps.LogError("EdiProcessLogSp", processId, "25", ediFile, 0, 1)
        End If

EndProcess:

        ' Remove the Lockfile
        If Not fileOps.DeleteLockfile(ediLogicalFolder, lockFile) Then
            GoTo ExitEDI
        End If

        insertStmts = Nothing
        Exit Function

ErrorEDI:
        If bStartedTransaction Then
            ServerOps.DoTransactionBlock("ROLLBACK")
        End If
        ServerOps.LogError("EdiProcessLogSp", processId, "24", ediFile, 0, 1)

ExitEDI:
        If bStartedTransaction Then
            ServerOps.DoTransactionBlock("ROLLBACK")
        End If
		ServerOps.logError("EdiProcessLogSp", processId, "10", "-EDI Import Process - ExitEDI(FileType:" + FileType + ") (FileName:" + ediFile + ")", 0, 1)
        fileOps.DeleteLockfile(ediLogicalFolder, lockFile)
        insertStmts = Nothing
        ImportProcess = False
    End Function

End Class
