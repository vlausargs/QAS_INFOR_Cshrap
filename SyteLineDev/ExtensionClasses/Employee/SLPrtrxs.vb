Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Employee
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets

<IDOExtensionClass("SLPrtrxs")> _
Public Class SLPrtrxs
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Private Function CallJourlockSp(ByVal Id As String, ByVal LockUser As Decimal, ByVal LockJournal As Integer, ByRef message As String) As Integer
        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Context.Commands.Invoke("SLParms", "JourlockSp", Id, LockUser, LockJournal, message)
            If invokeResponse.IsReturnValueStdError() Then
                message = invokeResponse.Parameters(3).Value
                CallJourlockSp = 16
            Else
                CallJourlockSp = 0
            End If
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
            CallJourlockSp = 16
        End Try
    End Function


    Private Function CallLasttranSp(ByVal Key As Integer, ByVal LockUser As Decimal, ByVal TransLocked As Integer, ByRef success As Integer, ByRef message As String) As Integer

        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Context.Commands.Invoke("SLParms", "LasttranSp", Key, LockUser, TransLocked, success, message)
            success = CInt(invokeResponse.Parameters(3).Value)
            If invokeResponse.IsReturnValueStdError() Then
                message = invokeResponse.Parameters(4).Value
                CallLasttranSp = 16
            Else
                CallLasttranSp = 0
            End If
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
            CallLasttranSp = 16
        End Try
    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxpPostChecksVB(ByVal PSessionID As Guid,
                            ByVal PUserID As Decimal,
                            ByVal PStartDept As String,
                            ByVal PEndDept As String,
                            ByVal PStartEmpNum As String,
                            ByVal pEndEmpNum As String,
                            ByVal PPrintZeroChecks As Byte,
                            ByVal PEmpType As String,
                            ByVal PRegNeeded As Byte,
                            ByRef Infobar As String,
                            ByRef PStartEmpCate As String,
                            ByRef PEndEmpCate As String) As Integer

        '-- Converted from pr/prtrxp.p
        '-- Post Payroll Checks


        Dim str_filter As String
        Dim int_returnCode As Integer
        Dim int_success As Integer
        Dim int_numGood As Integer
        Dim int_numBad As Integer

        Dim invokeResponse As New InvokeResponseData
        Dim loadresponse As LoadCollectionResponseData
        Dim messageProvider As Mongoose.IDO.IMessageProvider
        Try
            PRtrxpPostChecksVB = 0
            messageProvider = Me.GetMessageProvider()

            PRtrxpPostChecksVB = CallJourlockSp("PR Dist", PUserID, 1, Infobar)

            If PRtrxpPostChecksVB <> 0 Then
                ' roll back will be done in calljourlocksp
                PRtrxpPostChecksVB = 16
                GoTo Exit_PRtrxpPostChecksVB
            End If


            PRtrxpPostChecksVB = CallLasttranSp(12, PUserID, 1, int_success, Infobar)

            If PRtrxpPostChecksVB <> 0 Or int_success <> 1 Then
                PRtrxpPostChecksVB = 16
                GoTo Exit_PRtrxpPostChecksVB
            End If

            'Build the filter
            str_filter = "dbo.InValidPrtrxStagingRecords('" & PSessionID.ToString _
                                                        & "',RowPointer" _
                                                        & ",'" & PStartDept _
                                                        & "','" & PEndDept _
                                                        & "','" & PStartEmpNum _
                                                        & "','" & pEndEmpNum _
                                                        & "'," & PPrintZeroChecks _
                                                        & ",'" & PEmpType _
                                                        & "','" & PStartEmpCate _
                                                        & "','" & PEndEmpCate _
                                                        & "') = 1"

            loadresponse = Me.LoadCollection("RowPointer", str_filter, String.Empty, 0)

            ' Check for prtrxs within the range
            ' Still need to print Voided Checks and Unposted Transactions (don't set error code)
            If loadresponse.Items.Count = 0 And PRegNeeded <> 1 Then
                Infobar = messageProvider.GetMessage("I=#Post", int_numGood, "@prtrx")
                PRtrxpPostChecksVB = 16
                GoTo Exit_PRtrxpPostChecksVB
            End If

            For index As Integer = 0 To loadresponse.Items.Count - 1

                '/* POST */
                Try
                    invokeResponse = Me.Invoke("PRtrxp1pPostChecksSp", PSessionID, loadresponse(index, "RowPointer").GetValue(Of Guid), Infobar)
                    Infobar = invokeResponse.Parameters(2).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                End Try
                If invokeResponse.IsReturnValueStdError Or CInt(invokeResponse.ReturnValue) > 0 Then
                    int_numBad = int_numBad + 1
                    Try
                        invokeResponse = Me.Invoke("MessageToPrtrxToPrintPostSp", PSessionID, loadresponse(index, "RowPointer").GetValue(Of Guid), Infobar, Infobar)
                    Catch ex As Exception
                        Infobar = MGException.ExtractMessages(ex)
                    End Try
                    If invokeResponse.IsReturnValueStdError Then
                        PRtrxpPostChecksVB = 16
                        GoTo Exit_PRtrxpPostChecksVB
                    End If
                    '/* VOID CHECK */
                    Try
                        invokeResponse = Me.Invoke("PrtrxVoidOneCheckSp", PSessionID, loadresponse(index, "RowPointer").GetValue(Of Guid), Infobar)
                    Catch ex As Exception
                        Infobar = MGException.ExtractMessages(ex)
                    End Try
                    If invokeResponse.IsReturnValueStdError Then
                        PRtrxpPostChecksVB = 16
                        GoTo Exit_PRtrxpPostChecksVB
                    End If
                Else
                    int_numGood = int_numGood + 1
                End If
            Next

            Infobar = ""

            If int_numBad > 0 Then
                If int_numGood > 0 Then
                    Infobar = messageProvider.GetMessage("W=PartDist", "@prtrx")
                Else
                    Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                End If
                Infobar = messageProvider.AppendMessage(Infobar, "I=#Invalid", CStr(int_numBad), "@prtrx")
            Else
                Infobar = messageProvider.GetMessage("I=CmdSucceeded", "@prtrx")
            End If

            Infobar = messageProvider.AppendMessage(Infobar, "I=#Post", CStr(int_numGood), "@prtrx")

            GoTo Exit_PRtrxpPostChecksVB


Exit_PRtrxpPostChecksVB:
            '/* UNLOCK JOURNAL and LASTTRAN */
            Try
                int_returnCode = CallJourlockSp("PR Dist", PUserID, 0, Infobar)
            Catch ex As Exception
                Infobar = MGException.ExtractMessages(ex)
                PRtrxpPostChecksVB = 16
            End Try
            Try
                int_returnCode = CallLasttranSp(12, PUserID, 0, int_success, Infobar)
            Catch ex As Exception
                Infobar = MGException.ExtractMessages(ex)
                PRtrxpPostChecksVB = 16
            End Try
            If int_numBad = 0 Then
                Try
                    invokeResponse = Me.Invoke("PRtrxpSetPrparmsEndPostSp", Infobar)
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    PRtrxpPostChecksVB = 16
                End Try
            End If
        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            PRtrxpPostChecksVB = 16
        End Try
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PrtrxChecksToPrintPostSp(
<[Optional]> ByVal pSessionID As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_PrtrxChecksToPrintPostExt As ICLM_PrtrxChecksToPrintPost = New CLM_PrtrxChecksToPrintPostFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_PrtrxChecksToPrintPostExt.CLM_PrtrxChecksToPrintPostSp(pSessionID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetMaxPrtrxSeqSp(ByVal pEmpNum As String,
                                     ByRef rSequence As Short?,
                                     ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetMaxPrtrxSeqExt As IGetMaxPrtrxSeq = New GetMaxPrtrxSeqFactory().Create(appDb)

            Dim orSequence As PrtrxSeqType = rSequence
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iGetMaxPrtrxSeqExt.GetMaxPrtrxSeqSp(pEmpNum, orSequence, oInfobar)

            rSequence = orSequence
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPrparmsCurFlagInfoSp(
<[Optional], DefaultParameterValue(CByte(0))> ByRef PrparmsCurFlag1 As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByRef PrparmsCurFlag2 As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByRef PrparmsCurFlag3 As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByRef PrparmsCurFlag4 As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetPrparmsCurFlagInfoExt As IGetPrparmsCurFlagInfo = New GetPrparmsCurFlagInfoFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PrparmsCurFlag1 As Byte?, PrparmsCurFlag2 As Byte?, PrparmsCurFlag3 As Byte?, PrparmsCurFlag4 As Byte?) = iGetPrparmsCurFlagInfoExt.GetPrparmsCurFlagInfoSp(PrparmsCurFlag1, PrparmsCurFlag2, PrparmsCurFlag3, PrparmsCurFlag4)
            Dim Severity As Integer = result.ReturnCode.Value
            PrparmsCurFlag1 = result.PrparmsCurFlag1
            PrparmsCurFlag2 = result.PrparmsCurFlag2
            PrparmsCurFlag3 = result.PrparmsCurFlag3
            PrparmsCurFlag4 = result.PrparmsCurFlag4
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPrparmsCurInfoSp(
<[Optional]> ByRef PrparmsCurStart As DateTime?,
<[Optional]> ByRef PrparmsCurEnd As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetPrparmsCurInfoExt As IGetPrparmsCurInfo = New GetPrparmsCurInfoFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PrparmsCurStart As DateTime?, PrparmsCurEnd As DateTime?) = iGetPrparmsCurInfoExt.GetPrparmsCurInfoSp(PrparmsCurStart, PrparmsCurEnd)
            Dim Severity As Integer = result.ReturnCode.Value
            PrparmsCurStart = result.PrparmsCurStart
            PrparmsCurEnd = result.PrparmsCurEnd
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetWorkUnitDescriptionForEmpSp(ByVal CurEmpNum As String, ByRef TUnits As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetWorkUnitDescriptionForEmpExt As IGetWorkUnitDescriptionForEmp = New GetWorkUnitDescriptionForEmpFactory().Create(appDb)

            Dim oTUnits As DeWorkUnitDescType = TUnits

            Dim Severity As Integer = iGetWorkUnitDescriptionForEmpExt.GetWorkUnitDescriptionForEmpSp(CurEmpNum, oTUnits)

            TUnits = oTUnits

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PayoutGenericMessagesSp(ByVal StartingDept As String, ByVal EndingDept As String, ByVal StartingEmpNum As String, ByVal EndingEmpNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPayoutGenericMessagesExt As IPayoutGenericMessages = New PayoutGenericMessagesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, InforBar As String) = iPayoutGenericMessagesExt.PayoutGenericMessagesSp(StartingDept, EndingDept, StartingEmpNum, EndingEmpNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.InforBar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function PayoutSp(
<[Optional], DefaultParameterValue("W")> ByVal InterfaceVersion As String,
<[Optional], DefaultParameterValue("D")> ByVal SummaryOrDetail As String, ByVal StartingDept As String, ByVal EndingDept As String, ByVal StartingEmpNum As String, ByVal EndingEmpNum As String, ByVal FilterString As String,
<[Optional]> ByVal UserId As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iPayoutExt = New PayoutFactory().Create(appDb, bunchedLoadCollection)
            Dim result = iPayoutExt.PayoutSp(InterfaceVersion, SummaryOrDetail, StartingDept, EndingDept, StartingEmpNum, EndingEmpNum, FilterString, UserId)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PayoutWinMessagesSp(ByVal StartingDept As String,
                                        ByVal EndingDept As String,
                                        ByVal StartingEmpNum As String,
                                        ByVal EndingEmpNum As String,
                                        ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPayoutWinMessagesExt As IPayoutWinMessages = New PayoutWinMessagesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPayoutWinMessagesExt.PayoutWinMessagesSp(StartingDept, EndingDept, StartingEmpNum, EndingEmpNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PR01crpDoChecksSp(
<[Optional]> ByVal pSessionID As Guid?, ByVal pCheckNum As Integer?, ByVal pStartDept As String, ByVal pEndDept As String, ByVal pStartEmpNum As String, ByVal pEndEmpNum As String, ByVal pCheckDate As DateTime?, ByVal pBankCode As String, ByVal pPrintZeroChecks As Byte?, ByVal pEmpType As String, ByRef rTPostNeeded As Byte?, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPR01crpDoChecksExt As IPR01crpDoChecks = New PR01crpDoChecksFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, rTPostNeeded As Byte?, Infobar As String) = iPR01crpDoChecksExt.PR01crpDoChecksSp(pSessionID, pCheckNum, pStartDept, pEndDept, pStartEmpNum, pEndEmpNum, pCheckDate, pBankCode, pPrintZeroChecks, pEmpType, rTPostNeeded, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            rTPostNeeded = result.rTPostNeeded
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PR01VRPVoidChecksSp(ByVal pSessionId As Guid?, ByVal pUserID As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal pCreateNew As Byte?, ByVal pCheckNum As Integer?, ByVal pEndCheckNum As Integer?, ByVal pBankCode As String, ByVal pStartDept As String, ByVal pEndDept As String, ByVal pStartEmpNum As String, ByVal pEndEmpNum As String, ByVal pPrintZeroChecks As Byte?, ByVal pEmpType As String, ByRef rUnpostedVoid As Integer?, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPR01VRPVoidChecksExt As IPR01VRPVoidChecks = New PR01VRPVoidChecksFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, rUnpostedVoid As Integer?, Infobar As String) = iPR01VRPVoidChecksExt.PR01VRPVoidChecksSp(pSessionId, pUserID, pCreateNew, pCheckNum, pEndCheckNum, pBankCode, pStartDept, pEndDept, pStartEmpNum, pEndEmpNum, pPrintZeroChecks, pEmpType, rUnpostedVoid, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            rUnpostedVoid = result.rUnpostedVoid
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrDeCodeCheckSp(ByVal pEmpNum As String, ByVal pEmpSeq As Short?, ByVal pPrDeCode As String, ByVal pPrDeAmt As Decimal?, ByVal pDeCodeSeq As Integer?, ByVal PEmpType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPrDeCodeCheckExt As IPrDeCodeCheck = New PrDeCodeCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrDeCodeCheckExt.PrDeCodeCheckSp(pEmpNum, pEmpSeq, pPrDeCode, pPrDeAmt, pDeCodeSeq, PEmpType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxClearSnapshotsSp(
<[Optional]> ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPrtrxClearSnapshotsExt As IPrtrxClearSnapshots = New PrtrxClearSnapshotsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrtrxClearSnapshotsExt.PrtrxClearSnapshotsSp(PSessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxcPreSp(ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPrtrxcPreExt As IPrtrxcPre = New PrtrxcPreFactory().Create(appDb)

            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As Infobar = PromptButtons
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPrtrxcPreExt.PrtrxcPreSp(oPromptMsg, oPromptButtons, oInfobar)

            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxgcSp(ByVal SEmployee As String, ByVal EEmployee As String, ByVal PIncPayFreq As String, ByVal PEmplType As String, ByRef RestartFlag As Integer?, ByRef RestartRow As Guid?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPrtrxgcExt As IPrtrxgc = New PrtrxgcFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, RestartFlag As Integer?, RestartRow As Guid?, PromptMsg As String, PromptButtons As String, Infobar As String) = iPrtrxgcExt.PrtrxgcSp(SEmployee, EEmployee, PIncPayFreq, PEmplType, RestartFlag, RestartRow, PromptMsg, PromptButtons, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            RestartFlag = result.RestartFlag
            RestartRow = result.RestartRow
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxgPreCheckSp(ByRef PStartDate As DateTime?, ByRef PEndDate As DateTime?, ByRef PIncPayFreq As String, ByRef PJobTrx As Byte?, ByRef PTimeAttend As Byte?, ByRef PPrComm As Byte?, ByRef PCheckDate As DateTime?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPrtrxgPreCheckExt As IPrtrxgPreCheck = New PrtrxgPreCheckFactory().Create(appDb)

            Dim oPStartDate As DateType = PStartDate
            Dim oPEndDate As DateType = PEndDate
            Dim oPIncPayFreq As LongListType = PIncPayFreq
            Dim oPJobTrx As ListYesNoType = PJobTrx
            Dim oPTimeAttend As ListYesNoType = PTimeAttend
            Dim oPPrComm As ListYesNoType = PPrComm
            Dim oPCheckDate As DateType = PCheckDate
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As Infobar = PromptButtons
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPrtrxgPreCheckExt.PrtrxgPreCheckSp(oPStartDate, oPEndDate, oPIncPayFreq, oPJobTrx, oPTimeAttend, oPPrComm, oPCheckDate, oPromptMsg, oPromptButtons, oInfobar)

            PStartDate = oPStartDate
            PEndDate = oPEndDate
            PIncPayFreq = oPIncPayFreq
            PJobTrx = oPJobTrx
            PTimeAttend = oPTimeAttend
            PPrComm = oPPrComm
            PCheckDate = oPCheckDate
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxgSp(ByVal SDepartment As String, ByVal EDepartment As String, ByVal SEmployee As String, ByVal EEmployee As String, ByVal PStartDate As DateTime?, ByVal PEndDate As DateTime?, ByVal PIncPayFreq As String, ByVal PJobTrx As Byte?, ByVal PProjTrx As Byte?, ByVal PTimeAttend As Byte?, ByVal PSumAttend As Byte?, ByVal PEmplType As String, ByVal PPrHrs As Byte?, ByVal PPrComm As Byte?, ByVal PPrServiceHours As Byte?, ByVal PCheckDate As DateTime?, ByVal PPrDelWhich As String, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPrtrxgExt As IPrtrxg = New PrtrxgFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrtrxgExt.PrtrxgSp(SDepartment, EDepartment, SEmployee, EEmployee, PStartDate, PEndDate, PIncPayFreq, PJobTrx, PProjTrx, PTimeAttend, PSumAttend, PEmplType, PPrHrs, PPrComm, PPrServiceHours, PCheckDate, PPrDelWhich, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxPostNeededSp(ByVal PSessionID As Guid?, ByRef RPostNeeded As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPrtrxPostNeededExt As IPrtrxPostNeeded = New PrtrxPostNeededFactory().Create(appDb)

            Dim oRPostNeeded As FlagNyType = RPostNeeded
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPrtrxPostNeededExt.PrtrxPostNeededSp(PSessionID, oRPostNeeded, oInfobar)

            RPostNeeded = oRPostNeeded
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxpValPostChecksSp(ByVal pSessionID As Guid?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal pAddToExisting As Byte?, ByVal pStartDept As String, ByVal pEndDept As String, ByVal pStartEmpNum As String, ByVal pEndEmpNum As String, ByVal pBankCode As String, ByVal pEmpType As String, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPRtrxpValPostChecksExt As IPRtrxpValPostChecks = New PRtrxpValPostChecksFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPRtrxpValPostChecksExt.PRtrxpValPostChecksSp(pSessionID, pAddToExisting, pStartDept, pEndDept, pStartEmpNum, pEndEmpNum, pBankCode, pEmpType, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxvpCurPayrollTxsSp(ByVal pSessionId As Guid?, ByVal pCheckDate As DateTime?, ByVal pBankCode As String, ByVal pStartDept As String, ByVal pEndDept As String, ByVal pStartEmpNum As String, ByVal pEndEmpNum As String, ByVal pEmpType As String, ByRef Infobar As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPRtrxvpCurPayrollTxsExt As IPRtrxvpCurPayrollTxs = New PRtrxvpCurPayrollTxsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPRtrxvpCurPayrollTxsExt.PRtrxvpCurPayrollTxsSP(pSessionId, pCheckDate, pBankCode, pStartDept, pEndDept, pStartEmpNum, pEndEmpNum, pEmpType, Infobar, PStartEmpCate, PEndEmpCate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxvpValPeriodSp(ByVal pCheckDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPRtrxvpValPeriodExt As IPRtrxvpValPeriod = New PRtrxvpValPeriodFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPRtrxvpValPeriodExt.PRtrxvpValPeriodSp(pCheckDate, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyPrtrxChecksToPrintPostSp(
<[Optional]> ByRef PSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iVerifyPrtrxChecksToPrintPostExt As IVerifyPrtrxChecksToPrintPost = New VerifyPrtrxChecksToPrintPostFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PSessionID As Guid?) = iVerifyPrtrxChecksToPrintPostExt.VerifyPrtrxChecksToPrintPostSp(PSessionID)
            Dim Severity As Integer = result.ReturnCode.Value
            PSessionID = result.PSessionID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VoidPrtrxChecksToPrintPostSp(ByVal PSessionID As Guid?, ByVal PUserID As Decimal?, ByVal PBankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iVoidPrtrxChecksToPrintPostExt As IVoidPrtrxChecksToPrintPost = New VoidPrtrxChecksToPrintPostFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iVoidPrtrxChecksToPrintPostExt.VoidPrtrxChecksToPrintPostSp(PSessionID, PUserID, PBankCode, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ClearPrtrxChecksToPrintPostSp(
    <[Optional]> ByVal pSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iClearPrtrxChecksToPrintPostExt As IClearPrtrxChecksToPrintPost = New ClearPrtrxChecksToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iClearPrtrxChecksToPrintPostExt.ClearPrtrxChecksToPrintPostSp(pSessionID)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PR01VRPVoidChecksRangeSp(ByVal pBankCode As String, ByVal pStartDept As String, ByVal pEndDept As String, ByVal pStartEmpNum As String, ByVal pEndEmpNum As String, ByVal pPrintZeroChecks As Integer?, ByVal pEmpType As String,
<[Optional]> ByVal PStartEmpCate As String,
<[Optional]> ByVal PEndEmpCate As String) As DataTable
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_PR01VRPVoidChecksRangeExt As ICLM_PR01VRPVoidChecksRange = New CLM_PR01VRPVoidChecksRangeFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_PR01VRPVoidChecksRangeExt.CLM_PR01VRPVoidChecksRangeSp(pBankCode, pStartDept, pEndDept, pStartEmpNum, pEndEmpNum, pPrintZeroChecks, pEmpType, PStartEmpCate, PEndEmpCate)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MessageToPrtrxToPrintPostSp(ByVal pSessionID As Guid?, ByVal pPrtrxRowPointer As Guid?, ByVal pMessage As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMessageToPrtrxToPrintPostExt As IMessageToPrtrxToPrintPost = New MessageToPrtrxToPrintPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMessageToPrtrxToPrintPostExt.MessageToPrtrxToPrintPostSp(pSessionID, pPrtrxRowPointer, pMessage, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrDeCodeAmtCheckSp(ByVal pEmpNum As String, ByVal pEmpSeq As Short?, ByVal pPrDeCode As String, ByVal pPrDeAmt As Decimal?, ByVal pDeCodeSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPrDeCodeAmtCheckExt As IPrDeCodeAmtCheck = New PrDeCodeAmtCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrDeCodeAmtCheckExt.PrDeCodeAmtCheckSp(pEmpNum, pEmpSeq, pPrDeCode, pPrDeAmt, pDeCodeSeq, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxcSp(ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPrtrxcExt As IPrtrxc = New PrtrxcFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrtrxcExt.PrtrxcSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxp1pPostChecksSp(ByVal pSessionID As Guid?, ByVal pPrtrxRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPRtrxp1pPostChecksExt As IPRtrxp1pPostChecks = New PRtrxp1pPostChecksFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPRtrxp1pPostChecksExt.PRtrxp1pPostChecksSp(pSessionID, pPrtrxRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PRtrxpSetPrparmsEndPostSp(ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPRtrxpSetPrparmsEndPostExt As IPRtrxpSetPrparmsEndPost = New PRtrxpSetPrparmsEndPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPRtrxpSetPrparmsEndPostExt.PRtrxpSetPrparmsEndPostSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxSetRegularHrsSp(ByVal EmpNum As String, ByVal EmpSeq As Short?, ByVal PaySalaryStatus As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPrtrxSetRegularHrsExt As IPrtrxSetRegularHrs = New PrtrxSetRegularHrsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrtrxSetRegularHrsExt.PrtrxSetRegularHrsSp(EmpNum, EmpSeq, PaySalaryStatus, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PrtrxVoidOneCheckSp(ByVal pSessionID As Guid?, ByVal pPrtrxRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPrtrxVoidOneCheckExt As IPrtrxVoidOneCheck = New PrtrxVoidOneCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPrtrxVoidOneCheckExt.PrtrxVoidOneCheckSp(pSessionID, pPrtrxRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CalculateDirectDepositSp(ByVal EmpPrbankEmpNum As String, ByVal PrtrxDepDtlSeq As Short?, ByVal EmployeeDirDep As Byte?, ByVal PrtrxType As String, ByVal PrtrxCheckNum As Integer?, ByVal Void As Byte?, ByVal CreateDepDtl As Byte?, ByVal CheckDate As DateTime?, ByVal BankCode As String, ByVal CalledFromForm As String, ByRef PrtrxNetPay As Decimal?, ByRef PrtrxDepAmt As Decimal?, ByRef SchedDirDepExceedNetPay As Byte?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPrtrxdepIExt As IPrtrxdepI = New PrtrxdepIFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PrtrxNetPay As Decimal?, PrtrxDepAmt As Decimal?, SchedDirDepExceedNetPay As Byte?) = iPrtrxdepIExt.PrtrxdepISp(EmpPrbankEmpNum, PrtrxDepDtlSeq, EmployeeDirDep, PrtrxType, PrtrxCheckNum, Void, CreateDepDtl, CheckDate, BankCode, CalledFromForm, PrtrxNetPay, PrtrxDepAmt, SchedDirDepExceedNetPay)
            Dim Severity As Integer = result.ReturnCode.Value
            PrtrxNetPay = result.PrtrxNetPay
            PrtrxDepAmt = result.PrtrxDepAmt
            SchedDirDepExceedNetPay = result.SchedDirDepExceedNetPay
            Return Severity
        End Using
    End Function
End Class
