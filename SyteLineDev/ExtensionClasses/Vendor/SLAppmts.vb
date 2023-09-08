Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports Mongoose.IDO.DataAccess
Imports CSI.Logistics.Vendor
Imports CSI.MG
Imports CSI.Data.SQL.UDDT
Imports SL
Imports CSI.Finance.AP
Imports System.Runtime.InteropServices
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports CSI.MG.MGCore
Imports CSI.Data.Functions

<IDOExtensionClass("SLAppmts")>
Public Class SLAppmts
    Inherits CSIExtensionClassBase

    'Sub New()
    '    Me.ParmsTable = "apparms"
    'End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Ap01RIDoPostVB(
        ByVal PSessionID As String,
        ByVal PUserID As Decimal,
        ByVal PStartingVendNum As String,
        ByVal PEndingVendNum As String,
        ByVal PStartingVendName As String,
        ByVal PEndingVendName As String,
        ByVal PSortNameNum As String,
        ByVal PPayType As String,
        ByVal PRegNeeded As String,
        ByRef Infobar As String,
        ByVal PPayDateStarting As String,
        ByVal PPayDateEnding As String) As Integer

        Dim invokeResponse As InvokeResponseData

        Dim str_filter As String
        If InStr("NameNumber", PSortNameNum) = 0 Then
            PSortNameNum = "Number"
        End If

        'Build the filter
        str_filter = "dbo.InValidAppmtStagingRecords('" & PSessionID _
                                                    & "',RowPointer" _
                                                    & ",'" & Replace(PStartingVendNum, "'", "''") _
                                                    & "','" & Replace(PEndingVendNum, "'", "''") _
                                                    & "','" & Replace(PStartingVendName, "'", "''") _
                                                    & "','" & Replace(PEndingVendName, "'", "''") _
                                                    & "','" & PSortNameNum _
                                                    & "','" & PPayDateStarting _
                                                    & "','" & PPayDateEnding _
                                                    & "') = 1"

        If PSortNameNum = "Number" Then
            str_filter = str_filter & " ORDER BY BankCode, CheckNum"
        Else
            str_filter = str_filter & " ORDER BY VadName, BankCode, CheckNum"
        End If

        invokeResponse = Me.Invoke("LockAPDistJournalAndCheckPrinting", PUserID, Infobar)
        If invokeResponse.IsReturnValueStdError Then
            Infobar = invokeResponse.Parameters(1).Value
            UnlockAPDistJournalAndCheckPrinting(PUserID)
            Return 16
        End If

        Try 'make sure we unlock APDistJournalAndCheckPrinting if an exception is thrown 
            Dim loadResponse As LoadCollectionResponseData
            loadResponse = Me.LoadCollection("RowPointer", str_filter, "", 0)
            '/* Check for appmts within the range */
            If loadResponse.Items.Count = 0 And PRegNeeded <> "1" Then
                Infobar = Me.GetMessageProvider().GetMessage("W=NoneSelected", "@!" & PPayType)
                Throw New MGException(Infobar)
            End If

            Dim int_numBad As Integer = 0
            Dim int_numGood As Integer = 0

            For i As Integer = 0 To loadResponse.Items.Count - 1
                invokeResponse = Me.Invoke("ApPmtpOneSp", PSessionID, loadResponse(i, "RowPointer").Value, PPayType, Infobar)
                If invokeResponse.IsReturnValueStdError Then
                    Infobar = invokeResponse.Parameters(3).Value
                    int_numBad = int_numBad + 1

                    invokeResponse = Me.Invoke("MessageToAppmtToPrintPostSp", PSessionID, loadResponse(i, "RowPointer").Value, Infobar, Infobar)
                    If invokeResponse.IsReturnValueStdError Then
                        Infobar = invokeResponse.Parameters(3).Value
                        Throw New MGException(Infobar)
                    End If

                    invokeResponse = Me.Invoke("ApPmtpVoidOneSp", PSessionID, loadResponse(i, "RowPointer").Value, PPayType, Infobar)
                    If invokeResponse.ReturnValue <> "0" Then
                        Infobar = invokeResponse.Parameters(3).Value
                        Throw New MGException(Infobar)
                    End If
                Else
                    int_numGood = int_numGood + 1
                End If
            Next

            If int_numBad > 0 Then
                If int_numGood > 0 Then
                    Infobar = Me.GetMessageProvider().GetMessage("W=PartDist", "@aptrx")
                Else
                    Infobar = Me.GetMessageProvider().GetMessage("E=CmdFailed", "@%post")
                End If
                Infobar = Me.GetMessageProvider().AppendMessage(Infobar, "I=#Invalid", CStr(int_numBad), "@appmt")
            Else
                Infobar = Me.GetMessageProvider().GetMessage("I=CmdSucceeded", "@appmt")
            End If
            Infobar = Me.GetMessageProvider().AppendMessage(Infobar, "I=#Post", int_numGood, "@appmt")
        Catch ex As Exception
            Infobar = ex.Message
            UnlockAPDistJournalAndCheckPrinting(PUserID)
            Return 16
        End Try

        UnlockAPDistJournalAndCheckPrinting(PUserID)

        Return 0

    End Function

    Function UnlockAPDistJournalAndCheckPrinting(ByVal PUserID As Decimal) As Integer
        Dim invokeResponse As InvokeResponseData
        '/* UNLOCK JOURNAL and Check Printing */
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "JourlockSp", "AP Dist", PUserID, 0, "")
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "LasttranSp", 12, PUserID, 0, 0, "")
    End Function

    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")>
    Public Function LockAPDistJournalAndCheckPrinting(ByVal PUserID As Decimal, ByRef Infobar As String) As Integer
        Dim invokeResponse As InvokeResponseData
        Dim int_success As Integer


        '/* LOCK JOURNAL and LASTTRAN */
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "JourlockSp", "AP Dist", PUserID, 1, Infobar)

        If invokeResponse.ReturnValue <> "0" Then
            Infobar = invokeResponse.Parameters(3).Value
            Return 16
        End If

        'Lock Check Printing
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "LasttranSp", 12, PUserID, 1, int_success, Infobar)
        If invokeResponse.ReturnValue <> "0" Or invokeResponse.Parameters(3).Value <> "1" Then
            Infobar = invokeResponse.Parameters(4).Value
            Return 16
        End If

        Return 0
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AP01RIPrelimRegSP(
<[Optional]> ByVal PSessionID As Guid?,
<[Optional], DefaultParameterValue("1")> ByVal PUserID As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PAddToExisting As Byte?,
<[Optional]> ByVal PStartingVendNum As String,
<[Optional]> ByVal PEndingVendNum As String,
<[Optional]> ByVal PStartingVendName As String,
<[Optional]> ByVal PEndingVendName As String, ByVal PPayCode As String,
<[Optional]> ByVal PBankCode As String,
<[Optional], DefaultParameterValue("Number")> ByVal PSortBy As String, ByRef Infobar As String,
<[Optional]> ByVal PPayDateStarting As DateTime?,
<[Optional]> ByVal PPayDateEnding As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAP01RIPrelimRegExt As IAP01RIPrelimReg = New AP01RIPrelimRegFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAP01RIPrelimRegExt.AP01RIPrelimRegSP(PSessionID, PUserID, PAddToExisting, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, PPayCode, PBankCode, PSortBy, Infobar, PPayDateStarting, PPayDateEnding)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AP01RIVoidChecksRangeSP(ByVal PPayCode As String, ByVal PBankCode As String, ByVal PStartingVendNum As String, ByVal PEndingVendNum As String, ByVal PStartingVendName As String, ByVal PEndingVendName As String,
<[Optional]> ByRef RStartCheckNum As Integer?,
<[Optional]> ByRef REndCheckNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAP01RIVoidChecksRangeExt As IAP01RIVoidChecksRange = New AP01RIVoidChecksRangeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, RStartCheckNum As Integer?, REndCheckNum As Integer?, Infobar As String) = iAP01RIVoidChecksRangeExt.AP01RIVoidChecksRangeSP(PPayCode, PBankCode, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, RStartCheckNum, REndCheckNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RStartCheckNum = result.RStartCheckNum
            REndCheckNum = result.REndCheckNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AP01RIVoidChecksSP(ByVal PSessionID As Guid?, ByVal PUserID As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PCreateNew As Byte?, ByVal PPayCode As String, ByVal PBankCode As String, ByVal PStartingVendNum As String, ByVal PEndingVendNum As String, ByVal PStartingVendName As String, ByVal PEndingVendName As String, ByVal PStartingCheckNum As Integer?, ByVal PEndingCheckNum As Integer?, ByRef RUnpostedVoid As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAP01RIVoidChecksExt As IAP01RIVoidChecks = New AP01RIVoidChecksFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, RUnpostedVoid As Byte?, Infobar As String) = iAP01RIVoidChecksExt.AP01RIVoidChecksSP(PSessionID, PUserID, PCreateNew, PPayCode, PBankCode, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, PStartingCheckNum, PEndingCheckNum, RUnpostedVoid, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RUnpostedVoid = result.RUnpostedVoid
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APCheckPrintPreDisplaySp(ByVal PayType As String, ByRef BankCode As String, ByRef NextCheckNumber As Integer?, ByRef PEFTBankcode As String, ByRef PEFTFormat As String, ByRef PEFTUserName As String, ByRef PEFTUserNumber As String, ByRef PPrintManualRemitAdvice As Byte?, ByRef PPrintEFTRemitAdvice As Byte?, ByRef PPrintWireRemitAdvice As Byte?, ByRef PPrintDraftRemitAdvice As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAPCheckPrintPreDisplay = New APCheckPrintPreDisplayFactory().Create(appDb)
            Dim oBankCode As BankCodeType = BankCode
            Dim oNextCheckNumber As GlCheckNumType = NextCheckNumber
            Dim oPEFTBankcode As BankCodeType = PEFTBankcode
            Dim oPEFTFormat As EFTFormatType = PEFTFormat
            Dim oPEFTUserName As EFTUserNameType = PEFTUserName
            Dim oPEFTUserNumber As EFTUserNumberType = PEFTUserNumber
            Dim oPPrintManualRemitAdvice As ListYesNoType = PPrintManualRemitAdvice
            Dim oPPrintEFTRemitAdvice As ListYesNoType = PPrintEFTRemitAdvice
            Dim oPPrintWireRemitAdvice As ListYesNoType = PPrintWireRemitAdvice
            Dim oPPrintDraftRemitAdvice As ListYesNoType = PPrintDraftRemitAdvice
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.APCheckPrintPreDisplaySp(PayType, oBankCode, oNextCheckNumber, oPEFTBankcode, oPEFTFormat, oPEFTUserName, oPEFTUserNumber, oPPrintManualRemitAdvice, oPPrintEFTRemitAdvice, oPPrintWireRemitAdvice, oPPrintDraftRemitAdvice, oInfobar)
            BankCode = oBankCode
            NextCheckNumber = oNextCheckNumber
            PEFTBankcode = oPEFTBankcode
            PEFTFormat = oPEFTFormat
            PEFTUserName = oPEFTUserName
            PEFTUserNumber = oPEFTUserNumber
            PPrintManualRemitAdvice = oPPrintManualRemitAdvice
            PPrintEFTRemitAdvice = oPPrintEFTRemitAdvice
            PPrintWireRemitAdvice = oPPrintWireRemitAdvice
            PPrintDraftRemitAdvice = oPPrintDraftRemitAdvice
            Infobar = oInfobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtClearSnapshotsSp(
<[Optional]> ByVal PSessionID As Guid?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal bRemitAdvicePrint As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAppmtClearSnapshotsExt As IAppmtClearSnapshots = New AppmtClearSnapshotsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAppmtClearSnapshotsExt.AppmtClearSnapshotsSp(PSessionID, bRemitAdvicePrint, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtExchRateLeaveSp(ByVal PaymentType As String, ByVal PDomCurrCode As String, ByRef PDomCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckSeq As Short?, ByVal PBankCode As String, ByVal PVendNum As String, ByVal PExchRate As Decimal?, ByRef PForCheckAmt As Decimal?, ByRef PDomApplied As Decimal?, ByRef PForApplied As Decimal?, ByRef PDomRemaining As Decimal?, ByRef PForRemaining As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtExchRateLeave = New AppmtExchRateLeaveFactory().Create(appDb)
            Dim oPDomCheckAmt As AmountType = PDomCheckAmt
            Dim oPForCheckAmt As AmountType = PForCheckAmt
            Dim oPDomApplied As AmountType = PDomApplied
            Dim oPForApplied As AmountType = PForApplied
            Dim oPDomRemaining As AmountType = PDomRemaining
            Dim oPForRemaining As AmountType = PForRemaining
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtExchRateLeaveSp(CType(PaymentType, AppmtPayTypeType), CType(PDomCurrCode, CurrCodeType), oPDomCheckAmt, CType(PRecptDate, DateType), CType(PCheckSeq, ApCheckSeqType), CType(PBankCode, BankCodeType), CType(PVendNum, VendNumType), CType(PExchRate, ExchRateType), oPForCheckAmt, oPDomApplied, oPForApplied, oPDomRemaining, oPForRemaining, oInfobar)
            PDomCheckAmt = oPDomCheckAmt.Value
            PForCheckAmt = oPForCheckAmt.Value
            PDomApplied = oPDomApplied.Value
            PForApplied = oPForApplied.Value
            PDomRemaining = oPDomRemaining.Value
            PForRemaining = oPForRemaining.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetAmtsAppliedSp(ByVal PBankCode As String, ByVal PVendNum As String, ByVal PCheckSeq As Short?, ByRef PForAmt As Decimal?, ByRef PDomAmt As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtGetAmtsAppliedExt As IAppmtGetAmtsApplied = New AppmtGetAmtsAppliedFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PForAmt As Decimal?, PDomAmt As Decimal?, Infobar As String) = iAppmtGetAmtsAppliedExt.AppmtGetAmtsAppliedSp(PBankCode, PVendNum, PCheckSeq, PForAmt, PDomAmt, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PForAmt = result.PForAmt
            PDomAmt = result.PDomAmt
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetCheckSp(ByVal PBankCode As String, ByVal PCheckNum As Integer?, ByVal PVendNum As String, ByVal PPayType As String, ByRef PForCheckAmt As Decimal?, ByRef PDomCheckAmt As Decimal?, ByRef PExchRate As Decimal?, ByRef PCheckDate As DateTime?, ByRef PRef As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtGetCheck = New AppmtGetCheckFactory().Create(appDb)
            Dim oPForCheckAmt As AmountType = PForCheckAmt
            Dim oPDomCheckAmt As AmountType = PDomCheckAmt
            Dim oPExchRate As ExchRateType = PExchRate
            Dim oPCheckDate As DateTimeType = PCheckDate
            Dim oPRef As ReferenceType = PRef
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtGetCheckSp(CType(PBankCode, BankCodeType), CType(PCheckNum, ApCheckNumType), CType(PVendNum, VendNumType), CType(PPayType, LongListType), oPForCheckAmt, oPDomCheckAmt, oPExchRate, oPCheckDate, oPRef, oInfobar)
            PForCheckAmt = oPForCheckAmt.Value
            PDomCheckAmt = oPDomCheckAmt.Value
            PExchRate = oPExchRate.Value
            PCheckDate = oPCheckDate.Value
            PRef = oPRef.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetDueDateSp(ByVal PCheckDate As DateTime?, ByVal PVendNum As String, ByRef RDueDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtGetDueDate = New AppmtGetDueDateFactory().Create(appDb)
            Dim oRDueDate As DateType = RDueDate
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtGetDueDateSp(PCheckDate, CType(PVendNum, VendNumType), oRDueDate, oInfobar)
            RDueDate = oRDueDate.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtLeaveDomAmtSp(ByVal PDomCurrCode As String, ByVal PDomCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckNum As Short?, ByVal PBankCode As String, ByVal PVendNum As String, ByRef PExchRate As Decimal?, ByRef PForCheckAmt As Decimal?, ByRef PDomApplied As Decimal?, ByRef PForApplied As Decimal?, ByRef PDomRemaining As Decimal?, ByRef PForRemaining As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtLeaveDomAmt = New AppmtLeaveDomAmtFactory().Create(appDb)
            Dim oPExchRate As ExchRateType = PExchRate
            Dim oPForCheckAmt As AmountType = PForCheckAmt
            Dim oPDomApplied As AmountType = PDomApplied
            Dim oPForApplied As AmountType = PForApplied
            Dim oPDomRemaining As AmountType = PDomRemaining
            Dim oPForRemaining As AmountType = PForRemaining
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtLeaveDomAmtSp(CType(PDomCurrCode, CurrCodeType), CType(PDomCheckAmt, AmountType), CType(PRecptDate, DateType), CType(PCheckNum, ApCheckSeqType), CType(PBankCode, BankCodeType), CType(PVendNum, VendNumType), oPExchRate, oPForCheckAmt, oPDomApplied, oPForApplied, oPDomRemaining, oPForRemaining, oInfobar)
            PExchRate = oPExchRate.Value
            PForCheckAmt = oPForCheckAmt.Value
            PDomApplied = oPDomApplied.Value
            PForApplied = oPForApplied.Value
            PDomRemaining = oPDomRemaining.Value
            PForRemaining = oPForRemaining.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtLeavePayToVendAmtSp(ByVal PFromCurrCode As String, ByVal PToCurrCode As String, ByVal PBanCurrCode As String, ByRef PToCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckSeq As Integer?, ByVal PBankCode As String, ByVal PVendNum As String, ByVal PType As String, ByVal PCreditMemoNum As String, ByRef PExchRate As Decimal?, ByVal PFromCheckAmt As Decimal?, ByRef PToApplied As Decimal?, ByRef PFromApplied As Decimal?, ByRef PToRemaining As Decimal?, ByRef PFromRemaining As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtLeavePayToVendAmtExt As IAppmtLeavePayToVendAmt = New AppmtLeavePayToVendAmtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PToCheckAmt As Decimal?, PExchRate As Decimal?, PToApplied As Decimal?, PFromApplied As Decimal?, PToRemaining As Decimal?, PFromRemaining As Decimal?, Infobar As String) = iAppmtLeavePayToVendAmtExt.AppmtLeavePayToVendAmtSp(PFromCurrCode, PToCurrCode, PBanCurrCode, PToCheckAmt, PRecptDate, PCheckSeq, PBankCode, PVendNum, PType, PCreditMemoNum, PExchRate, PFromCheckAmt, PToApplied, PFromApplied, PToRemaining, PFromRemaining, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PToCheckAmt = result.PToCheckAmt
            PExchRate = result.PExchRate
            PToApplied = result.PToApplied
            PFromApplied = result.PFromApplied
            PToRemaining = result.PToRemaining
            PFromRemaining = result.PFromRemaining
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtPostNeededSp(ByVal PSessionID As Guid, ByRef RPostNeeded As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtPostNeeded = New AppmtPostNeededFactory().Create(appDb)
            Dim oRPostNeeded As FlagNyType = RPostNeeded
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtPostNeededSp(CType(PSessionID, RowPointerType), oRPostNeeded, oInfobar)
            RPostNeeded = oRPostNeeded.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtPreDeleteSp(ByVal PRowid As Guid, ByRef Infobar As String, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtPreDelete = New AppmtPreDeleteFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As Infobar = PromptButtons
            Dim Severity As Integer = iSLAppmtsExt.AppmtPreDeleteSp(CType(PRowid, RowPointerType), oInfobar, oPromptMsg, oPromptButtons)
            Infobar = oInfobar.Value
            PromptMsg = oPromptMsg.Value
            PromptButtons = oPromptButtons.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtSetForDomAmtsSp(ByVal PVendCurr As String, ByVal PBankCurr As String, ByVal PAmt As Decimal?, ByVal PExchRate As Decimal?, ByRef PDomAmt As Decimal?, ByRef PForAmt As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtSetForDomAmts = New AppmtSetForDomAmtsFactory().Create(appDb)
            Dim oPDomAmt As AmountType = PDomAmt
            Dim oPForAmt As AmountType = PForAmt
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtSetForDomAmtsSp(CType(PVendCurr, CurrCodeType), CType(PBankCurr, CurrCodeType), CType(PAmt, AmountType), CType(PExchRate, ExchRateType), oPDomAmt, oPForAmt, oInfobar)
            PDomAmt = oPDomAmt.Value
            PForAmt = oPForAmt.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtValidateBankCheckSp(ByVal PBankCode As String, ByVal PVendNum As String, ByRef Infobar As String, ByRef pDomBank As Byte?, ByRef PBankCurrCode As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtValidateBankCheck = New AppmtValidateBankCheckFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim opDomBank As ListYesNoType = pDomBank
            Dim oPBankCurrCode As CurrCodeType = PBankCurrCode
            Dim Severity As Integer = iSLAppmtsExt.AppmtValidateBankCheckSp(CType(PBankCode, BankCodeType), CType(PVendNum, VendNumType), oInfobar, opDomBank, oPBankCurrCode)
            Infobar = oInfobar.Value
            pDomBank = opDomBank.Value
            PBankCurrCode = oPBankCurrCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtValidateCheckAPPaymentSp(ByVal PNewRecord As Byte?, ByVal PCheckNum As Integer?, ByVal PPayType As String, ByVal PReapplication As Byte?, ByVal PVendNum As String, ByRef PBankCode As String, ByRef POpenPay As Byte?, ByRef PForCheckAmt As Decimal?, ByRef PDomCheckAmt As Decimal?, ByRef PExchRate As Decimal?, ByRef PCheckDate As DateTime?, ByRef PTHPaymentNumber As String, ByRef PRef As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAppmtValidateCheckAPPayment = New AppmtValidateCheckAPPaymentFactory().Create(appDb)
            Dim oPBankCode As BankCodeType = PBankCode
            Dim oPOpenPay As FlagNyType = POpenPay
            Dim oPForCheckAmt As AmountType = PForCheckAmt
            Dim oPDomCheckAmt As AmountType = PDomCheckAmt
            Dim oPExchRate As ExchRateType = PExchRate
            Dim oPCheckDate As DateType = PCheckDate
            Dim oPTHPaymentNumber As PaymentNumberType = PTHPaymentNumber
            Dim oPRef As ReferenceType = PRef
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.AppmtValidateCheckAPPaymentSp(CType(PNewRecord, FlagNyType), CType(PCheckNum, ApCheckNumType), CType(PPayType, LongListType), CType(PReapplication, FlagNyType), CType(PVendNum, VendNumType), oPBankCode, oPOpenPay, oPForCheckAmt, oPDomCheckAmt, oPExchRate, oPCheckDate, oPTHPaymentNumber, oPRef, oInfobar)
            PBankCode = oPBankCode.Value
            POpenPay = oPOpenPay.Value
            PForCheckAmt = oPForCheckAmt.Value
            PDomCheckAmt = oPDomCheckAmt.Value
            PExchRate = oPExchRate.Value
            PCheckDate = oPCheckDate.Value
            PTHPaymentNumber = oPTHPaymentNumber.Value
            PRef = oPRef.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtValidatePaymentSp(ByVal PVendNum As String, ByVal PCheckSeq As Short?, ByVal PBankCode As String, ByVal PReapplication As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtValidatePaymentExt As IAppmtValidatePayment = New AppmtValidatePaymentFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAppmtValidatePaymentExt.AppmtValidatePaymentSp(PVendNum, PCheckSeq, PBankCode, PReapplication, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApPmtvSp(ByVal PBegVendNum As String, ByVal PEndVendNum As String, ByVal PBegName As String, ByVal PEndName As String, ByVal PPayType As String, ByVal PBankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IApPmtv = New ApPmtvFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.ApPmtvSp(CType(PBegVendNum, VendNumType), CType(PEndVendNum, VendNumType), CType(PBegName, NameType), CType(PEndName, NameType), CType(PPayType, StringType), CType(PBankCode, BankCodeType), oInfobar)
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APQPCreateOpenDistrSp(ByVal SessionId As Guid?, ByVal Selected As Byte?, ByVal AptrxpTypeDesc As String, ByVal Voucher As Integer?, ByVal SiteRef As String, ByVal VendNum As String, ByVal DueDate As DateTime?, ByVal BankCode As String, ByVal CheckSeq As Short?, ByVal ApplyVendNum As String, ByVal CheckNum As Integer?, ByVal DomAmtPaid As Decimal?, ByVal ExchRate As Decimal?, ByVal ForAmtPaid As Decimal?, ByVal AppmtRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAPQPCreateOpenDistrExt As IAPQPCreateOpenDistr = New APQPCreateOpenDistrFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iAPQPCreateOpenDistrExt.APQPCreateOpenDistrSp(SessionId, Selected, AptrxpTypeDesc, Voucher, SiteRef, VendNum, DueDate, BankCode, CheckSeq, ApplyVendNum, CheckNum, DomAmtPaid, ExchRate, ForAmtPaid, AppmtRowPointer)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APQuickPayInitialSp(ByVal pBankCode As String, ByVal pVendNum As String, ByVal pPayType As String, ByVal pCheckNum As Integer?, ByVal pCheckSeq As Short?, ByVal pCheckDate As DateTime?, ByVal pVendBankCode As String, ByVal pVendCurr As String, ByVal pParmsCurr As String, ByRef pEuroFixed As Byte?, ByRef pForApplied As Decimal?, ByRef pDomApplied As Decimal?, ByRef pBankCurr As String, ByRef pDomBank As Byte?, ByRef pDueDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSLAppmtsExt As IAPQuickPayInitial = New APQuickPayInitialFactory().Create(appDb)
            Dim opEuroFixed As ListYesNoType = pEuroFixed
            Dim opForApplied As AmountType = pForApplied
            Dim opDomApplied As AmountType = pDomApplied
            Dim opBankCurr As CurrCodeType = pBankCurr
            Dim opDomBank As ListYesNoType = pDomBank
            Dim opDueDate As DateType = pDueDate
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iSLAppmtsExt.APQuickPayInitialSp(CType(pBankCode, BankCodeType), CType(pVendNum, VendNumType), CType(pPayType, AppmtPayTypeType), CType(pCheckNum, ApCheckNumType), CType(pCheckSeq, ApCheckSeqType), CType(pCheckDate, DateType), CType(pVendBankCode, BankCodeType), CType(pVendCurr, CurrCodeType), CType(pParmsCurr, CurrCodeType), opEuroFixed, opForApplied, opDomApplied, opBankCurr, opDomBank, opDueDate, oInfobar)
            pEuroFixed = opEuroFixed.Value
            pForApplied = opForApplied.Value
            pDomApplied = opDomApplied.Value
            pBankCurr = opBankCurr.Value
            pDomBank = opDomBank.Value
            pDueDate = opDueDate.Value
            Infobar = oInfobar.Value
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APQuickVendNumChangeSp(ByVal pBankCode As String,
<[Optional]> ByVal Site As String, ByVal PVendNum As String, ByRef pBankCurr As String, ByRef PCheckSeq As Short?, ByRef Fixed As Byte?, ByRef PayHold As Byte?, ByRef BankCode As String, ByRef BankName As String, ByRef PayType As String, ByRef CurrCode As String, ByRef VendName As String, ByRef ExchRate As Decimal?, ByRef IsFixedEuro As Byte?, ByRef PCurrAmtFormat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAPQuickVendNumChangeExt As IAPQuickVendNumChange = New APQuickVendNumChangeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, pBankCurr As String, PCheckSeq As Short?, Fixed As Byte?, PayHold As Byte?, BankCode As String, BankName As String, PayType As String, CurrCode As String, VendName As String, ExchRate As Decimal?, IsFixedEuro As Byte?, PCurrAmtFormat As String, Infobar As String) = iAPQuickVendNumChangeExt.APQuickVendNumChangeSp(pBankCode, Site, PVendNum, pBankCurr, PCheckSeq, Fixed, PayHold, BankCode, BankName, PayType, CurrCode, VendName, ExchRate, IsFixedEuro, PCurrAmtFormat, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pBankCurr = result.pBankCurr
            PCheckSeq = result.PCheckSeq
            Fixed = result.Fixed
            PayHold = result.PayHold
            BankCode = result.BankCode
            BankName = result.BankName
            PayType = result.PayType
            CurrCode = result.CurrCode
            VendName = result.VendName
            ExchRate = result.ExchRate
            IsFixedEuro = result.IsFixedEuro
            PCurrAmtFormat = result.PCurrAmtFormat
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APWirePostingSp(ByVal PSessionID As Guid?, ByVal PAppmtRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAPWirePostingExt As IAPWirePosting = New APWirePostingFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iAPWirePostingExt.APWirePostingSp(PSessionID, PAppmtRowPointer, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_AppmtChecksToPrintPostSp(
<[Optional]> ByVal PSessionID As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_AppmtChecksToPrintPostExt As ICLM_AppmtChecksToPrintPost = New CLM_AppmtChecksToPrintPostFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_AppmtChecksToPrintPostExt.CLM_AppmtChecksToPrintPostSp(PSessionID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ClearAppmtChecksToPrintPostSp(
<[Optional]> ByVal PSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iClearAppmtChecksToPrintPostExt As IClearAppmtChecksToPrintPost = New ClearAppmtChecksToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iClearAppmtChecksToPrintPostExt.ClearAppmtChecksToPrintPostSp(PSessionID)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EftPostCreateTTSp(ByVal PBegVendNum As String, ByVal PEndVendNum As String, ByVal PBegName As String, ByVal PEndName As String, ByVal EFTFormat As String, ByVal PBankCode As String, ByVal PAppmtPayType As String, ByVal PPayDateStarting As DateTime?, ByVal PPayDateEnding As DateTime?, ByVal PSessionID As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iEftPostCreateTTExt As IEftPostCreateTT = New EftPostCreateTTFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iEftPostCreateTTExt.EftPostCreateTTSp(PBegVendNum, PEndVendNum, PBegName, PEndName, EFTFormat, PBankCode, PAppmtPayType, PPayDateStarting, PPayDateEnding, PSessionID)

            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EftFileCreateSp(ByVal EFTFile As String, ByVal NoteDesc As String, ByVal NoteContentFile As Byte(), ByVal Status As Short?, ByRef GUID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEftFileCreateExt As IEftFileCreate = New EftFileCreateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, GUID As Guid?, Infobar As String) = iEftFileCreateExt.EftFileCreateSp(EFTFile, NoteDesc, NoteContentFile, Status, GUID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            GUID = result.GUID
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApparmsEFTOutInfoSp(ByRef PEFTFormat As String, ByRef PEFTDestinationID As String, ByRef PEFTOriginationID As String, ByRef PEFTCompanyID As Decimal?, ByRef EFTDirectory As String, ByRef EFTFile As String, ByRef EFTDate As DateTime?, ByRef EFTUserName As String, ByRef EFTRegNumber As String, ByRef UseDefEFTAcct As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetApparmsEFTOutInfoExt As IGetApparmsEFTOutInfo = New GetApparmsEFTOutInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetApparmsEFTOutInfoExt.GetApparmsEFTOutInfoSp(PEFTFormat, PEFTDestinationID, PEFTOriginationID, PEFTCompanyID, EFTDirectory, EFTFile, EFTDate, EFTUserName, EFTRegNumber, UseDefEFTAcct)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCompanyInfoSP(ByRef ReturnCompanyName As String, ByRef MailingAddress As String, ByRef City As String, ByRef State As String, ByRef Zip As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCompanyInfoExt As IGetCompanyInfo = New GetCompanyInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetCompanyInfoExt.GetCompanyInfoSP(ReturnCompanyName, MailingAddress, City, State, Zip)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCurrencyExchRateSp(ByVal CurrCode As String, ByVal CheckDate As DateTime?, ByRef ExchRate As Decimal?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(1)> ByVal UseBuyRate As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCurrencyExchRateExt As IGetCurrencyExchRate = New GetCurrencyExchRateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iGetCurrencyExchRateExt.GetCurrencyExchRateSp(CurrCode, CheckDate, ExchRate, Infobar, UseBuyRate)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDefaultBankCodeForAPPaymentSp(ByRef BankCode As String,
<[Optional]> ByVal PayType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetDefaultBankCodeForAPPaymentExt As IGetDefaultBankCodeForAPPayment = New GetDefaultBankCodeForAPPaymentFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, BankCode As String) = iGetDefaultBankCodeForAPPaymentExt.GetDefaultBankCodeForAPPaymentSp(BankCode, PayType)
            Dim Severity As Integer = result.ReturnCode.Value
            BankCode = result.BankCode
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetSQLDateTimeSp(ByRef DateTime As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim sqlParameterProvider As CSI.Data.SQL.SQLParameterProvider = New CSI.Data.SQL.SQLParameterProvider()
            Dim getSiteDateFactory As IGetSiteDateFactory = New GetSiteDateFactory()
            Dim iGetSQLDateTimeExt As IGetSQLDateTime = New GetSQLDateTimeFactory(getSiteDateFactory).Create(appDb, mgInvoker, sqlParameterProvider, True)

            Dim result As (ReturnCode As Integer?, DateTime As Date?) = iGetSQLDateTimeExt.GetSQLDateTimeSp(DateTime)
            DateTime = result.DateTime
            Dim Severity As Integer = result.ReturnCode.Value

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function THACheckWHSp(ByVal VendNum As String, ByVal CheckNum As Integer?, ByVal CheckSeq As Short?, ByVal CheckDate As DateTime?, ByRef WithRecord As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTHACheckWHExt As ITHACheckWH = New THACheckWHFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, WithRecord As Integer?, Infobar As String) = iTHACheckWHExt.THACheckWHSp(VendNum, CheckNum, CheckSeq, CheckDate, WithRecord, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            WithRecord = result.WithRecord
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function THAGetCountwhtAttachmentSp(ByRef whtattachment As Integer?) As Integer
        Dim iTHAGetCountwhtAttachmentExt As ITHAGetCountwhtAttachment = New THAGetCountwhtAttachmentFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, whtattachment As Integer?) = iTHAGetCountwhtAttachmentExt.THAGetCountwhtAttachmentSp(whtattachment)
        Dim Severity As Integer = result.ReturnCode.Value
        whtattachment = result.whtattachment
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateApparmsSp(ByVal PEFTFile As String, ByVal PEFTFileDate As DateTime?, ByVal PFileFormat As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateApparmsExt As IUpdateApparms = New UpdateApparmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iUpdateApparmsExt.UpdateApparmsSp(PEFTFile, PEFTFileDate, PFileFormat)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateRemitAdviceFlagSp(ByVal PSessionID As Guid?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal RemitAdvicePrintedOK As Byte?, ByVal ForAPCheckOrAPEft As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateRemitAdviceFlagExt As IUpdateRemitAdviceFlag = New UpdateRemitAdviceFlagFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateRemitAdviceFlagExt.UpdateRemitAdviceFlagSp(PSessionID, RemitAdvicePrintedOK, ForAPCheckOrAPEft, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyAppmtChecksToPrintPostSp(
<[Optional]> ByRef PSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVerifyAppmtChecksToPrintPostExt As IVerifyAppmtChecksToPrintPost = New VerifyAppmtChecksToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PSessionID As Guid?) = iVerifyAppmtChecksToPrintPostExt.VerifyAppmtChecksToPrintPostSp(PSessionID)
            Dim Severity As Integer = result.ReturnCode.Value
            PSessionID = result.PSessionID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VoidAppmtChecksToPrintPostSp(ByVal PSessionID As Guid?, ByVal PUserID As Decimal?, ByVal PPayCode As String, ByVal PBankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVoidAppmtChecksToPrintPostExt As IVoidAppmtChecksToPrintPost = New VoidAppmtChecksToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iVoidAppmtChecksToPrintPostExt.VoidAppmtChecksToPrintPostSp(PSessionID, PUserID, PPayCode, PBankCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function WirePostCreateTTSp(ByVal PBegVendNum As String, ByVal PEndVendNum As String, ByVal PBegName As String, ByVal PEndName As String, ByVal PBankCode As String, ByVal PAppmtPayType As String, ByVal PPayDateStarting As DateTime?, ByVal PPayDateEnding As DateTime?, ByVal PSessionID As Guid?,
<[Optional], DefaultParameterValue("Number")> ByVal PSortNameNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWirePostCreateTTExt As IWirePostCreateTT = New WirePostCreateTTFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iWirePostCreateTTExt.WirePostCreateTTSp(PBegVendNum, PEndVendNum, PBegName, PEndName, PBankCode, PAppmtPayType, PPayDateStarting, PPayDateEnding, PSessionID, PSortNameNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WirePostValidateCloseFormSp(ByVal PSessionID As Guid?, ByVal AppmtPayType As String, ByVal bRemitAdvicePrint As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWirePostValidateCloseFormExt As IWirePostValidateCloseForm = New WirePostValidateCloseFormFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iWirePostValidateCloseFormExt.WirePostValidateCloseFormSp(PSessionID, AppmtPayType, bRemitAdvicePrint, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WirePostVerifyPrintSp(ByRef PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWirePostVerifyPrintExt As IWirePostVerifyPrint = New WirePostVerifyPrintFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PSessionID As Guid?, Infobar As String) = iWirePostVerifyPrintExt.WirePostVerifyPrintSp(PSessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PSessionID = result.PSessionID
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WirePostDeleteTTSp(ByVal PSessionID As Guid?, ByVal AppmtPayType As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal bRemitAdvicePrint As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWirePostDeleteTTExt As IWirePostDeleteTT = New WirePostDeleteTTFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iWirePostDeleteTTExt.WirePostDeleteTTSp(PSessionID, AppmtPayType, bRemitAdvicePrint)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WirePostVerifyCloseFormSp(ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWirePostVerifyCloseFormExt As IWirePostVerifyCloseForm = New WirePostVerifyCloseFormFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iWirePostVerifyCloseFormExt.WirePostVerifyCloseFormSp(PSessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AP012RSP(ByVal PSessionID As Guid?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PAddToExisting As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PManualOnly As Byte?, ByVal PPayCode As String, ByVal PBankCode As String, ByVal PStartingVendNum As String, ByVal PEndingVendNum As String, ByVal PStartingVendName As String, ByVal PEndingVendName As String,
<[Optional], DefaultParameterValue("Number")> ByVal PSortNameNum As String, ByRef RAppmtCnt As Integer?, ByRef Infobar As String, ByVal PPayDateStarting As DateTime?, ByVal PPayDateEnding As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAP012RExt As IAP012R = New AP012RFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RAppmtCnt As Integer?, Infobar As String) = iAP012RExt.AP012RSP(PSessionID, PAddToExisting, PManualOnly, PPayCode, PBankCode, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, PSortNameNum, RAppmtCnt, Infobar, PPayDateStarting, PPayDateEnding)
            Dim Severity As Integer = result.ReturnCode.Value
            RAppmtCnt = result.RAppmtCnt
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtCalcCheckAmountSp(ByVal PExchRate As Decimal?, ByVal PInCheckAmt As Decimal?, ByVal PVendCurr As String, ByVal PCheckDate As DateTime?, ByVal PToVendor As Byte?, ByRef POutCheckAmt As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtCalcCheckAmountExt As IAppmtCalcCheckAmount = New AppmtCalcCheckAmountFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, POutCheckAmt As Decimal?, Infobar As String) = iAppmtCalcCheckAmountExt.AppmtCalcCheckAmountSp(PExchRate, PInCheckAmt, PVendCurr, PCheckDate, PToVendor, POutCheckAmt, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            POutCheckAmt = result.POutCheckAmt
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtCalcCheckAmtSp(ByRef PExchRate As Decimal?, ByVal PInCheckAmt As Decimal?, ByVal PCustCurr As String, ByVal PRecptDate As DateTime?, ByVal PToCustomer As Byte?, ByRef POutCheckAmt As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtCalcCheckAmtExt As IAppmtCalcCheckAmt = New AppmtCalcCheckAmtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PExchRate As Decimal?, POutCheckAmt As Decimal?, Infobar As String) = iAppmtCalcCheckAmtExt.AppmtCalcCheckAmtSp(PExchRate, PInCheckAmt, PCustCurr, PRecptDate, PToCustomer, POutCheckAmt, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PExchRate = result.PExchRate
            POutCheckAmt = result.POutCheckAmt
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetNextCheckSp(ByVal PBankCode As String, ByVal PPayType As String, ByRef PNextCheck As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtGetNextCheckExt As IAppmtGetNextCheck = New AppmtGetNextCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PNextCheck As Integer?) = iAppmtGetNextCheckExt.AppmtGetNextCheckSp(PBankCode, PPayType, PNextCheck)
            Dim Severity As Integer = result.ReturnCode.Value
            PNextCheck = result.PNextCheck
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetNextSeqSp(ByVal PVendNum As String, ByVal PBankCode As String, ByRef PCheckSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtGetNextSeqExt As IAppmtGetNextSeq = New AppmtGetNextSeqFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PCheckSeq As Integer?, Infobar As String) = iAppmtGetNextSeqExt.AppmtGetNextSeqSp(PVendNum, PBankCode, PCheckSeq, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PCheckSeq = result.PCheckSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtGetBankCodeSp(ByVal PPayType As String, ByVal PCheckNum As Integer?, ByVal PVendNum As String, ByVal PCheckDate As DateTime?, ByVal PAmtPaid As Decimal?, ByRef PBankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtGetBankCodeExt As IAppmtGetBankCode = New AppmtGetBankCodeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PBankCode As String, Infobar As String) = iAppmtGetBankCodeExt.AppmtGetBankCodeSp(PPayType, PCheckNum, PVendNum, PCheckDate, PAmtPaid, PBankCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PBankCode = result.PBankCode
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtLeaveVendAmtSp(
<[Optional]> ByVal PVendCurrCode As String, ByVal PDomCurrCode As String, ByRef PDomCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckSeq As Short?, ByVal PBankCode As String, ByVal PVendNum As String, ByRef PExchRate As Decimal?, ByVal PForCheckAmt As Decimal?, ByRef PDomApplied As Decimal?, ByRef PForApplied As Decimal?,
<[Optional], DefaultParameterValue(0)> ByVal PPayApplied As Decimal?, ByRef PDomRemaining As Decimal?, ByRef PForRemaining As Decimal?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PPayLeave As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtLeaveVendAmtExt As IAppmtLeaveVendAmt = New AppmtLeaveVendAmtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PDomCheckAmt As Decimal?, PExchRate As Decimal?, PDomApplied As Decimal?, PForApplied As Decimal?, PDomRemaining As Decimal?, PForRemaining As Decimal?, Infobar As String) = iAppmtLeaveVendAmtExt.AppmtLeaveVendAmtSp(PVendCurrCode, PDomCurrCode, PDomCheckAmt, PRecptDate, PCheckSeq, PBankCode, PVendNum, PExchRate, PForCheckAmt, PDomApplied, PForApplied, PPayApplied, PDomRemaining, PForRemaining, Infobar, PPayLeave)
            Dim Severity As Integer = result.ReturnCode.Value
            PDomCheckAmt = result.PDomCheckAmt
            PExchRate = result.PExchRate
            PDomApplied = result.PDomApplied
            PForApplied = result.PForApplied
            PDomRemaining = result.PDomRemaining
            PForRemaining = result.PForRemaining
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtLeaveVendToPayAmtSp(ByVal PFromCurrCode As String, ByVal PToCurrCode As String, ByVal PBanCurrCode As String,
<[Optional]> ByVal PDomCurrCode As String, ByRef PToCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckSeq As Integer?, ByVal PBankCode As String, ByVal PVendNum As String, ByVal PType As String, ByVal PCreditMemoNum As String, ByRef PExchRate As Decimal?, ByVal PFromCheckAmt As Decimal?,
<[Optional], DefaultParameterValue(0)> ByVal PDomCheckAmt As Decimal?, ByRef PToApplied As Decimal?, ByRef PFromApplied As Decimal?,
<[Optional], DefaultParameterValue(0)> ByVal PDomApplied As Decimal?, ByRef PToRemaining As Decimal?, ByRef PFromRemaining As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtLeaveVendToPayAmtExt As IAppmtLeaveVendToPayAmt = New AppmtLeaveVendToPayAmtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PToCheckAmt As Decimal?, PExchRate As Decimal?, PToApplied As Decimal?, PFromApplied As Decimal?, PToRemaining As Decimal?, PFromRemaining As Decimal?, Infobar As String) = iAppmtLeaveVendToPayAmtExt.AppmtLeaveVendToPayAmtSp(PFromCurrCode, PToCurrCode, PBanCurrCode, PDomCurrCode, PToCheckAmt, PRecptDate, PCheckSeq, PBankCode, PVendNum, PType, PCreditMemoNum, PExchRate, PFromCheckAmt, PDomCheckAmt, PToApplied, PFromApplied, PDomApplied, PToRemaining, PFromRemaining, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PToCheckAmt = result.PToCheckAmt
            PExchRate = result.PExchRate
            PToApplied = result.PToApplied
            PFromApplied = result.PFromApplied
            PToRemaining = result.PToRemaining
            PFromRemaining = result.PFromRemaining
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApPmtpOneSp(ByVal PSessionID As Guid?, ByVal PAppmtRowPointer As Guid?,
    <[Optional]> ByVal PPayType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApPmtpOneExt As IApPmtpOne = New ApPmtpOneFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iApPmtpOneExt.ApPmtpOneSp(PSessionID, PAppmtRowPointer, PPayType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApPmtpVoidOneSp(ByVal PSessionID As Guid?, ByVal PAppmtRowPointer As Guid?,
    <[Optional]> ByVal PPayType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApPmtpVoidOneExt As IApPmtpVoidOne = New ApPmtpVoidOneFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iApPmtpVoidOneExt.ApPmtpVoidOneSp(PSessionID, PAppmtRowPointer, PPayType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtValidateCheckSp(ByVal PNewRecord As Byte?, ByVal PBankCode As String, ByVal PCheckNum As Integer?, ByVal PPayType As String, ByVal PReapplication As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtValidateCheckExt As IAppmtValidateCheck = New AppmtValidateCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAppmtValidateCheckExt.AppmtValidateCheckSp(PNewRecord, PBankCode, PCheckNum, PPayType, PReapplication, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtValidateOpenPaymentSp(ByVal PVendNum As String, ByVal PCheckNum As Integer?, ByRef POpenPay As Integer?, ByRef PForCheckAmt As Decimal?, ByRef PDomCheckAmt As Decimal?, ByRef PExchRate As Decimal?, ByRef PCheckDate As DateTime?, ByRef PRef As String, ByRef Infobar As String, ByVal PBankCode As String, ByVal PPayType As String,
<[Optional]> ByRef PForCurr As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAppmtValidateOpenPaymentExt As IAppmtValidateOpenPayment = New AppmtValidateOpenPaymentFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, POpenPay As Integer?, PForCheckAmt As Decimal?, PDomCheckAmt As Decimal?, PExchRate As Decimal?, PCheckDate As DateTime?, PRef As String, Infobar As String, PForCurr As String) = iAppmtValidateOpenPaymentExt.AppmtValidateOpenPaymentSp(PVendNum, PCheckNum, POpenPay, PForCheckAmt, PDomCheckAmt, PExchRate, PCheckDate, PRef, Infobar, PBankCode, PPayType, PForCurr)
            Dim Severity As Integer = result.ReturnCode.Value
            POpenPay = result.POpenPay
            PForCheckAmt = result.PForCheckAmt
            PDomCheckAmt = result.PDomCheckAmt
            PExchRate = result.PExchRate
            PCheckDate = result.PCheckDate
            PRef = result.PRef
            Infobar = result.Infobar
            PForCurr = result.PForCurr
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BAppmtdSp(ByVal PRecid As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iBAppmtdExt As IBAppmtd = New BAppmtdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iBAppmtdExt.BAppmtdSp(PRecid, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_AppmtChecksToVoidSp(ByVal PPayCode As String, ByVal PBankCode As String, ByVal PStartingVendNum As String, ByVal PEndingVendNum As String, ByVal PStartingVendName As String, ByVal PEndingVendName As String, ByVal PStartingCheckNum As Integer?, ByVal PEndingCheckNum As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_AppmtChecksToVoidExt As ICLM_AppmtChecksToVoid = New CLM_AppmtChecksToVoidFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_AppmtChecksToVoidExt.CLM_AppmtChecksToVoidSp(PPayCode, PBankCode, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, PStartingCheckNum, PEndingCheckNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportAppmtdSp(ByVal VendNum As String, ByVal InvNum As String, ByVal Voucher As Integer?, ByVal Site As String, ByVal BankCode As String, ByVal DetailAmount As Decimal?, ByVal EffectiveDate As DateTime?, ByVal CheckSeq As Short?, ByRef RefRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEFTImportAppmtdExt As IEFTImportAppmtd = New EFTImportAppmtdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RefRowPointer As Guid?, Infobar As String) = iEFTImportAppmtdExt.EFTImportAppmtdSp(VendNum, InvNum, Voucher, Site, BankCode, DetailAmount, EffectiveDate, CheckSeq, RefRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RefRowPointer = result.RefRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EFTImportAppmtSp(ByVal VendNum As String, ByVal CheckNum As Integer?, ByVal CheckDate As DateTime?, ByVal DomCheckAmt As Decimal?, ByVal Ref As String, ByVal txt As String, ByVal InvNum As String, ByVal BankCode As String, ByVal PayType As String, ByVal CheckSeq As Short?, ByVal ExchRate As Decimal?, ByVal ForCheckAmt As Decimal?, ByVal DueDate As DateTime?, ByVal Factor As Byte?, ByVal OffSet As Byte?, ByRef RefRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEFTImportAppmtExt As IEFTImportAppmt = New EFTImportAppmtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RefRowPointer As Guid?, Infobar As String) = iEFTImportAppmtExt.EFTImportAppmtSp(VendNum, CheckNum, CheckDate, DomCheckAmt, Ref, txt, InvNum, BankCode, PayType, CheckSeq, ExchRate, ForCheckAmt, DueDate, Factor, OffSet, RefRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RefRowPointer = result.RefRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApparmsEFTInfoSp(ByRef PEFTFormat As String, ByRef PEFTDestinationID As String, ByRef PEFTOriginationID As String, ByRef PEFTCompanyID As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetApparmsEFTInfoExt As IGetApparmsEFTInfo = New GetApparmsEFTInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PEFTFormat As String, PEFTDestinationID As String, PEFTOriginationID As String, PEFTCompanyID As Decimal?) = iGetApparmsEFTInfoExt.GetApparmsEFTInfoSp(PEFTFormat, PEFTDestinationID, PEFTOriginationID, PEFTCompanyID)
            Dim Severity As Integer = result.ReturnCode.Value
            PEFTFormat = result.PEFTFormat
            PEFTDestinationID = result.PEFTDestinationID
            PEFTOriginationID = result.PEFTOriginationID
            PEFTCompanyID = result.PEFTCompanyID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApparmsSp(ByRef PEFTBankCode As String, ByRef PEFTFormat As String, ByRef PEFTUserName As String, ByRef PEFTUserNumber As String, ByRef PPrintManualRemitAdvice As Integer?, ByRef PPrintEFTRemitAdvice As Integer?, ByRef PPrintWireRemitAdvice As Integer?, ByRef PPrintDraftRemitAdvice As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetApparmsExt As IGetApparms = New GetApparmsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PEFTBankCode As String, PEFTFormat As String, PEFTUserName As String, PEFTUserNumber As String, PPrintManualRemitAdvice As Integer?, PPrintEFTRemitAdvice As Integer?, PPrintWireRemitAdvice As Integer?, PPrintDraftRemitAdvice As Integer?) = iGetApparmsExt.GetApparmsSp(PEFTBankCode, PEFTFormat, PEFTUserName, PEFTUserNumber, PPrintManualRemitAdvice, PPrintEFTRemitAdvice, PPrintWireRemitAdvice, PPrintDraftRemitAdvice)
            Dim Severity As Integer = result.ReturnCode.Value
            PEFTBankCode = result.PEFTBankCode
            PEFTFormat = result.PEFTFormat
            PEFTUserName = result.PEFTUserName
            PEFTUserNumber = result.PEFTUserNumber
            PPrintManualRemitAdvice = result.PPrintManualRemitAdvice
            PPrintEFTRemitAdvice = result.PPrintEFTRemitAdvice
            PPrintWireRemitAdvice = result.PPrintWireRemitAdvice
            PPrintDraftRemitAdvice = result.PPrintDraftRemitAdvice
            Return Severity
        End Using
    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsFixedSp(ByVal CurrCode As String, ByRef Fixed As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsFixedExt As IIsFixed = New IsFixedFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Fixed As Integer?, Infobar As String) = iIsFixedExt.IsFixedSp(CurrCode, Fixed, Infobar, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            Fixed = result.Fixed
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JourlockSp(ByVal Id As String, ByVal LockUserid As Decimal?, ByVal LockJournal As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJourlockExt As IJourlock = New JourlockFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJourlockExt.JourlockSp(Id, LockUserid, LockJournal, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MessageToAppmtToPrintPostSp(ByVal PSessionID As Guid?, ByVal AppmtRowPointer As Guid?, ByVal Message As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMessageToAppmtToPrintPostExt As IMessageToAppmtToPrintPost = New MessageToAppmtToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMessageToAppmtToPrintPostExt.MessageToAppmtToPrintPostSp(PSessionID, AppmtRowPointer, Message, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateAPVendNumSp(ByVal PVendNum As String, ByRef PayHold As Integer?, ByRef BankCode As String, ByRef BankName As String, ByRef PayType As String, ByRef CurrCode As String, ByRef VendName As String, ByRef ExchRate As Decimal?, ByRef IsFixedEuro As Integer?, ByRef PCurrAmtFormat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateAPVendNumExt As IValidateAPVendNum = New ValidateAPVendNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PayHold As Integer?, BankCode As String, BankName As String, PayType As String, CurrCode As String, VendName As String, ExchRate As Decimal?, IsFixedEuro As Integer?, PCurrAmtFormat As String, Infobar As String) = iValidateAPVendNumExt.ValidateAPVendNumSp(PVendNum, PayHold, BankCode, BankName, PayType, CurrCode, VendName, ExchRate, IsFixedEuro, PCurrAmtFormat, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PayHold = result.PayHold
            BankCode = result.BankCode
            BankName = result.BankName
            PayType = result.PayType
            CurrCode = result.CurrCode
            VendName = result.VendName
            ExchRate = result.ExchRate
            IsFixedEuro = result.IsFixedEuro
            PCurrAmtFormat = result.PCurrAmtFormat
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Ap01FRISp(ByVal PSessionID As Guid?, ByVal PUserID As Decimal?,
    <[Optional]> ByVal PStartingVendNum As String,
    <[Optional]> ByVal PEndingVendNum As String,
    <[Optional]> ByVal PStartingVendName As String,
    <[Optional]> ByVal PEndingVendName As String,
    <[Optional], DefaultParameterValue("Number")> ByVal PSortNameNum As String, ByVal PPayType As String, ByVal PDistDetail As Byte?, ByVal PCurrCheckNum As Integer?, ByVal PCurBankCode As String, ByVal PPayTypeCodeSt As String, ByRef Infobar As String,
    <[Optional]> ByVal PPayDateStarting As DateTime?,
    <[Optional]> ByVal PPayDateEnding As DateTime?, ByVal PFormType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAp01FRIExt As IAp01FRI = New Ap01FRIFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAp01FRIExt.Ap01FRISp(PSessionID, PUserID, PStartingVendNum, PEndingVendNum, PStartingVendName, PEndingVendName, PSortNameNum, PPayType, PDistDetail, PCurrCheckNum, PCurBankCode, PPayTypeCodeSt, Infobar, PPayDateStarting, PPayDateEnding, PFormType)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEftOutfileInfoSp(ByRef EFTDirectory As String, ByRef EFTFile As String, ByRef EFTDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetEftOutfileInfoExt As IGetEftOutfileInfo = New GetEftOutfileInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EFTDirectory As String, EFTFile As String, EFTDate As DateTime?) = iGetEftOutfileInfoExt.GetEftOutfileInfoSp(EFTDirectory, EFTFile, EFTDate)
            Dim Severity As Integer = result.ReturnCode.Value
            EFTDirectory = result.EFTDirectory
            EFTFile = result.EFTFile
            EFTDate = result.EFTDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEFTOutInfoSp(ByVal PEFTFormat As String, ByVal PEFTBankCode As String, ByRef PEFTDestinationID As String, ByRef PEFTOriginationID As String, ByRef PEFTCompanyID As Decimal?, ByRef EFTDirectory As String, ByRef EFTFile As String, ByRef EFTDate As DateTime?, ByRef EFTUserName As String, ByRef EFTRegNumber As String, ByRef UseDefEFTAcct As Integer?, ByRef EFTUserNumber As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetEFTOutInfoExt As IGetEFTOutInfo = New GetEFTOutInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PEFTDestinationID As String, PEFTOriginationID As String, PEFTCompanyID As Decimal?, EFTDirectory As String, EFTFile As String, EFTDate As DateTime?, EFTUserName As String, EFTRegNumber As String, UseDefEFTAcct As Integer?, EFTUserNumber As String) = iGetEFTOutInfoExt.GetEFTOutInfoSp(PEFTFormat, PEFTBankCode, PEFTDestinationID, PEFTOriginationID, PEFTCompanyID, EFTDirectory, EFTFile, EFTDate, EFTUserName, EFTRegNumber, UseDefEFTAcct, EFTUserNumber)
            Dim Severity As Integer = result.ReturnCode.Value
            PEFTDestinationID = result.PEFTDestinationID
            PEFTOriginationID = result.PEFTOriginationID
            PEFTCompanyID = result.PEFTCompanyID
            EFTDirectory = result.EFTDirectory
            EFTFile = result.EFTFile
            EFTDate = result.EFTDate
            EFTUserName = result.EFTUserName
            EFTRegNumber = result.EFTRegNumber
            UseDefEFTAcct = result.UseDefEFTAcct
            EFTUserNumber = result.EFTUserNumber
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AppmtLeavePayExchRateAmtSp(ByVal PFromCurrCode As String, ByVal PToCurrCode As String, ByVal PBanCurrCode As String, ByRef PToCheckAmt As Decimal?, ByVal PRecptDate As DateTime?, ByVal PCheckSeq As Integer?, ByVal PBankCode As String, ByVal PVendtNum As String, ByVal PType As String, ByVal PCreditMemoNum As String, ByRef PExchRate As Decimal?, ByVal PFromCheckAmt As Decimal?, ByRef PToApplied As Decimal?, ByRef PFromApplied As Decimal?, ByRef PToRemaining As Decimal?, ByRef PFromRemaining As Decimal?, ByRef Infobar As String) As Integer
        Dim iAppmtLeavePayExchRateAmtExt As IAppmtLeavePayExchRateAmt = New AppmtLeavePayExchRateAmtFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, PToCheckAmt As Decimal?, PExchRate As Decimal?, PToApplied As Decimal?, PFromApplied As Decimal?, PToRemaining As Decimal?, PFromRemaining As Decimal?, Infobar As String) = iAppmtLeavePayExchRateAmtExt.AppmtLeavePayExchRateAmtSp(PFromCurrCode, PToCurrCode, PBanCurrCode, PToCheckAmt, PRecptDate, PCheckSeq, PBankCode, PVendtNum, PType, PCreditMemoNum, PExchRate, PFromCheckAmt, PToApplied, PFromApplied, PToRemaining, PFromRemaining, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        PToCheckAmt = result.PToCheckAmt
        PExchRate = result.PExchRate
        PToApplied = result.PToApplied
        PFromApplied = result.PFromApplied
        PToRemaining = result.PToRemaining
        PFromRemaining = result.PFromRemaining
        Infobar = result.Infobar
        Return Severity
    End Function
End Class
