Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Logistics.Vendor
Imports CSI.Data.SQL.UDDT
Imports System.Runtime.InteropServices
Imports CSI.Finance.AP
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.Logistics.Customer
Imports CSI.Material

<IDOExtensionClass("SLVendors")>
Public Class SLVendors
    Inherits CSIExtensionClassBase

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)

        'AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim updateArgs As IDOUpdateEventArgs = CType(args, IDOUpdateEventArgs)
        Dim updateResponse As UpdateCollectionResponseData = CType(updateArgs.ResponsePayload, UpdateCollectionResponseData)

        ' Handle delete case where there is no udpate response.
        If updateResponse.Items.Count = 0 Then
            Exit Sub
        End If
        If Not (updateResponse.Items.Count = 1 And updateResponse.Items(0).Properties.IndexOf("SynchronizedToBus") <> -1) Then
            'Sync vendor changes to the Bus (but skip the case where the only change was to SynchronizedToBus to avoid an infinite loop)

            Dim colParms As LoadCollectionResponseData = Me.Context.Commands.LoadCollection("SLParms", "Site", String.Empty, String.Empty, 0)
            Dim site As String = colParms(0, "Site").GetValue(Of String)()

            Dim oRuleExistsResp As InvokeResponseData
            Dim ruleExists As Integer = 1
            Dim recordsfound As Boolean = False
            oRuleExistsResp = Me.Invoke("RepRuleForObjectExistsSp", site, "Bus-Vendor", "Sync.SupplierPartyMaster", 3, ruleExists)
            ruleExists = oRuleExistsResp.Parameters(4).GetValue(Of Integer)()

            'If replication rules exist to handle them, queue up documents for the bus
            If ruleExists = 1 Then
                For Each item As IDOUpdateItem In updateResponse.Items
                    'make sure we have the VendNum and ActiveForDataIntegration properties available
                    Dim vendNum As String
                    Dim rowPointer As Guid = UpdateItemID.ParseRowID(item.ItemID, "ven")
                    Dim refRowPointer As String = TextUtil.FormatNormalizedString(rowPointer)
                    Dim activeForDataIntegration As Integer

                    If item.Properties.IndexOf("ActiveForDataIntegration") = -1 Or item.Properties.IndexOf("VendNum") = -1 Then
                        Dim filter As String = String.Format("RowPointer = {0}", SqlLiteral.Format(rowPointer))
                        Dim colVendor As LoadCollectionResponseData =
                            Me.LoadCollection("VendNum,ActiveForDataIntegration",
                                String.Format("RowPointer = {0}", SqlLiteral.Format(rowPointer)), String.Empty, 0)
                        activeForDataIntegration = colVendor(0, "ActiveForDataIntegration").GetValue(Of Integer)()
                        vendNum = colVendor(0, "VendNum").GetValue(Of String)()
                    Else
                        activeForDataIntegration = item.Properties("ActiveForDataIntegration").GetValue(Of Integer)()
                        vendNum = item.Properties("VendNum").GetValue(Of String)()
                    End If

                    'send each vendor that was added or updated
                    If CBool((updateArgs.ActionMask And item.Action And (UpdateAction.Insert Or UpdateAction.Update))) _
                        And activeForDataIntegration = 1 _
                    Then
                        Dim newItem As New IDOUpdateItem With {
                            .Action = UpdateAction.Insert
                        }
                        newItem.Properties.Add("TableName", "vendor")
                        newItem.Properties.Add("RefRowPointer", refRowPointer)
                        newItem.Properties.Add("Name1", "vend_num")
                        newItem.Properties.Add("Value1", vendNum)

                        Dim addExportDoc As New UpdateCollectionRequestData()
                        addExportDoc.Items.Add(newItem)
                        addExportDoc.IDOName = "SLTmpExportBusDocuments"
                        Me.Context.Commands.UpdateCollection(addExportDoc)
                        recordsfound = True
                    End If
                Next

                If recordsfound Then
                    'put a task on the BGTask queue
                    Dim resp As InvokeResponseData
                    Dim infobar As String = IDONull.Value.ToString
                    resp = Me.Invoke("CheckForActiveBGTaskSp", "BusExportDocument", infobar)
                    If resp.ReturnValue <> "0" Then
                        MGException.Throw(resp.Parameters(1).GetValue(Of String)())
                    End If
                End If
            End If
        End If
    End Sub


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function AP1099MagMediaSp(
<[Optional]> ByVal PSiteGroup As String,
<[Optional]> ByVal PVendorNumStarting As String,
<[Optional]> ByVal PVendorNumEnding As String,
<[Optional]> ByVal PMinPayments As Decimal?,
<[Optional]> ByVal PUseLstYrPayRec As Byte?,
<[Optional]> ByVal PPaperTapeDisk As String,
<[Optional]> ByVal PCombineState As Byte?,
<[Optional]> ByVal PForeignTrans As Byte?,
<[Optional]> ByVal PCountry As String,
<[Optional]> ByVal PForeignPayer As Byte?,
<[Optional]> ByVal PTransTIN As String,
<[Optional]> ByVal PCompany As String,
<[Optional]> ByVal PCompany2 As String,
<[Optional]> ByVal PAddress As String,
<[Optional]> ByVal PCity As String,
<[Optional]> ByVal PState As String,
<[Optional]> ByVal PZip As String,
<[Optional]> ByVal PContact As String,
<[Optional]> ByVal PPhone As String,
<[Optional]> ByVal PSoftVendor As String,
<[Optional]> ByVal PSetPriorYearIndicator As Byte?,
<[Optional]> ByVal PContactEmail As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iAP1099MagMediaExt As IAP1099MagMedia = New AP1099MagMediaFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iAP1099MagMediaExt.AP1099MagMediaSp(PSiteGroup, PVendorNumStarting, PVendorNumEnding, PMinPayments, PUseLstYrPayRec, PPaperTapeDisk, PCombineState, PForeignTrans, PCountry, PForeignPayer, PTransTIN, PCompany, PCompany2, PAddress, PCity, PState, PZip, PContact, PPhone, PSoftVendor, PSetPriorYearIndicator, PContactEmail)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APEndSP(
<[Optional]> ByVal PStartingVendNum As String,
<[Optional]> ByVal PEndingVendNum As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PResetPurchasesYTD As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PResetDiscountsYTD As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PResetPaymentsYTD As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PResetPaymentsFiscalYTD As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAPEndExt As IAPEnd = New APEndFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAPEndExt.APEndSP(PStartingVendNum, PEndingVendNum, PResetPurchasesYTD, PResetDiscountsYTD, PResetPaymentsYTD, PResetPaymentsFiscalYTD, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ApSummVendorSp(ByVal RowCount As Integer?, ByVal Filter As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PSiteQuery As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iApSummVendorExt As CSI.Logistics.Vendor.IApSummVendor = New CSI.Logistics.Vendor.ApSummVendorFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iApSummVendorExt.ApSummVendorSp(RowCount, Filter, Infobar, PSiteQuery)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckVendorForConsgnWhseSp(ByVal ConsignmentType As String, ByVal Whse As String, ByVal VendNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckVendorForConsgnWhseExt As ICheckVendorForConsgnWhse = New CheckVendorForConsgnWhseFactory().Create(appDb)

            Dim Severity As Integer = iCheckVendorForConsgnWhseExt.CheckVendorForConsgnWhseSp(ConsignmentType, Whse, VendNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckVendorExistsSp(ByVal VendNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckVendorExistsExt As ICheckVendorExists = New CheckVendorExistsFactory().Create(appDb)

            Dim Severity As Integer = iCheckVendorExistsExt.CheckVendorExistsSp(VendNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EurVendSp(ByRef Infobar As String, ByVal pStartVendNum1 As String, ByVal pStartVendNum2 As String, ByVal pStartVendNum3 As String, ByVal pStartVendNum4 As String, ByVal pStartVendNum5 As String, ByVal pStartVendNum6 As String, ByVal pStartVendNum7 As String, ByVal pStartVendNum8 As String, ByVal pStartVendNum9 As String, ByVal pStartVendNum10 As String, ByVal pEndVendNum1 As String, ByVal pEndVendNum2 As String, ByVal pEndVendNum3 As String, ByVal pEndVendNum4 As String, ByVal pEndVendNum5 As String, ByVal pEndVendNum6 As String, ByVal pEndVendNum7 As String, ByVal pEndVendNum8 As String, ByVal pEndVendNum9 As String, ByVal pEndVendNum10 As String, ByVal pCurrCode As String, ByVal pCommit As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iEurVendExt As IEurVend = New EurVendFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iEurVendExt.EurVendSp(Infobar, pStartVendNum1, pStartVendNum2, pStartVendNum3, pStartVendNum4, pStartVendNum5, pStartVendNum6, pStartVendNum7, pStartVendNum8, pStartVendNum9, pStartVendNum10, pEndVendNum1, pEndVendNum2, pEndVendNum3, pEndVendNum4, pEndVendNum5, pEndVendNum6, pEndVendNum7, pEndVendNum8, pEndVendNum9, pEndVendNum10, pCurrCode, pCommit)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetVendAddrInfoSp(ByVal VendNum As String, ByRef Addr1 As String, ByRef Addr2 As String, ByRef Addr3 As String, ByRef Addr4 As String, ByRef Country As String, ByRef County As String, ByRef Name As String, ByRef Zip As String, ByRef City As String, ByRef State As String, ByRef FaxNum As String, ByRef TelexNum As String, ByRef PayHold As Byte?, ByRef PayHoldUser As String, ByRef PayHoldDate As DateTime?, ByRef PayHoldReason As String, ByRef InternetURL As String, ByRef IntEmailAddr As String, ByRef ExtEmailAddr As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetVendAddrInfoExt As IGetVendAddrInfo = New GetVendAddrInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetVendAddrInfoExt.GetVendAddrInfoSp(VendNum, Addr1, Addr2, Addr3, Addr4, Country, County, Name, Zip, City, State, FaxNum, TelexNum, PayHold, PayHoldUser, PayHoldDate, PayHoldReason, InternetURL, IntEmailAddr, ExtEmailAddr, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Home_GetTodaysKeyVendorValuesSp(ByRef LateAmount As Decimal?, ByRef FundsCommittedAmount As Decimal?, ByRef OpenPayablesAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iHome_GetTodaysKeyVendorValuesExt As IHome_GetTodaysKeyVendorValues = New Home_GetTodaysKeyVendorValuesFactory().Create(appDb)

            Dim Severity As Integer = iHome_GetTodaysKeyVendorValuesExt.Home_GetTodaysKeyVendorValuesSp(LateAmount, FundsCommittedAmount, OpenPayablesAmount)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsVendorActiveSp(ByVal VendNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iIsVendorActiveExt As IIsVendorActive = New IsVendorActiveFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iIsVendorActiveExt.IsVendorActiveSp(VendNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MoveLocalVendSp(ByVal POldVendNum As String, ByVal PNewVendNum As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMoveLocalVendExt As IMoveLocalVend = New MoveLocalVendFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMoveLocalVendExt.MoveLocalVendSp(POldVendNum, PNewVendNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PurgeEDIVendorShipNoticesSp(
<[Optional]> ByVal VendorStarting As String,
<[Optional]> ByVal VendorEnding As String,
<[Optional]> ByVal GRNStarting As String,
<[Optional]> ByVal GRNEnding As String,
<[Optional]> ByVal CDateStarting As DateTime?,
<[Optional]> ByVal CDateEnding As DateTime?,
<[Optional]> ByVal CDateStartingOffset As Short?,
<[Optional]> ByVal CDateEndingOffset As Short?,
<[Optional]> ByRef Message As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iPurgeEDIVendorShipNoticesExt As IPurgeEDIVendorShipNotices = New PurgeEDIVendorShipNoticesFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Message As String) = iPurgeEDIVendorShipNoticesExt.PurgeEDIVendorShipNoticesSp(VendorStarting, VendorEnding, GRNStarting, GRNEnding, CDateStarting, CDateEnding, CDateStartingOffset, CDateEndingOffset, Message)
            Dim Severity As Integer = result.ReturnCode.Value
            Message = result.Message
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Update1099PaymentForVendorAfterPostedSp(ByVal VendNum As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Curr1099Reportable As Byte?, ByVal AmtPaid As Decimal?, ByVal DistDate As DateTime?, ByRef Inforbar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdate1099PaymentForVendorAfterPostedExt As IUpdate1099PaymentForVendorAfterPosted = New Update1099PaymentForVendorAfterPostedFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Inforbar As String) = iUpdate1099PaymentForVendorAfterPostedExt.Update1099PaymentForVendorAfterPostedSp(VendNum, Curr1099Reportable, AmtPaid, DistDate, Inforbar)
            Dim Severity As Integer = result.ReturnCode.Value
            Inforbar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidatePayTypeSp(ByVal EntityPayType As String, ByVal EntityCurrCode As String, ByVal EntityBankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iValidatePayTypeExt As IValidatePayType = New ValidatePayTypeFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidatePayTypeExt.ValidatePayTypeSp(EntityPayType, EntityCurrCode, EntityBankCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Vendor360_GetOverviewValuesSp(ByVal VendorID As String, ByRef LateOrders As Decimal?, ByRef POFundsCommittedAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iVendor360_GetOverviewValuesExt As IVendor360_GetOverviewValues = New Vendor360_GetOverviewValuesFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, LateOrders As Decimal?, POFundsCommittedAmount As Decimal?) = iVendor360_GetOverviewValuesExt.Vendor360_GetOverviewValuesSp(VendorID, LateOrders, POFundsCommittedAmount)
            Dim Severity As Integer = result.ReturnCode.Value
            LateOrders = result.LateOrders
            POFundsCommittedAmount = result.POFundsCommittedAmount
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VendorCustomerValidationSp(ByVal CustNum As String, ByVal VendNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iVendorCustomerValidationExt As IVendorCustomerValidation = New VendorCustomerValidationFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iVendorCustomerValidationExt.VendorCustomerValidationSp(CustNum, VendNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function VendorRebalYTDSp(ByVal StartingVendor As String, ByVal EndingVendor As String, ByVal YearStart As DateTime?, ByVal YearEnd As DateTime?, ByVal LastYearStart As DateTime?, ByVal LastYearEnd As DateTime?, ByVal ResetPurchYTD As Byte?, ByVal ResetPurchLstYr As Byte?, ByVal ResetPayYTD As Byte?, ByVal ResetPayLstYr As Byte?, ByVal ResetDiscYTD As Byte?, ByVal ResetDiscLstYr As Byte?, ByVal FiscalYearStart As DateTime?, ByVal FiscalYearEnd As DateTime?, ByVal LastFiscalYearStart As DateTime?, ByVal LastFiscalYearEnd As DateTime?, ByVal ResetPayFiscalYTD As Byte?, ByVal ResetPayFiscalLstYr As Byte?, ByVal Reset1099PayYTD As Byte?, ByVal Reset1099PayLstYr As Byte?, ByVal ProcessVar As String, ByVal ExceptionsOnly As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iVendorRebalYTDExt As IVendorRebalYTD = New VendorRebalYTDFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iVendorRebalYTDExt.VendorRebalYTDSp(StartingVendor, EndingVendor, YearStart, YearEnd, LastYearStart, LastYearEnd, ResetPurchYTD, ResetPurchLstYr, ResetPayYTD, ResetPayLstYr, ResetDiscYTD, ResetDiscLstYr, FiscalYearStart, FiscalYearEnd, LastFiscalYearStart, LastFiscalYearEnd, ResetPayFiscalYTD, ResetPayFiscalLstYr, Reset1099PayYTD, Reset1099PayLstYr, ProcessVar, ExceptionsOnly)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetAPAgingInfoSp(ByVal PVendNum As String, ByVal PCurrCode As String, ByVal PTransDom As Byte?, ByVal PSiteQuery As Byte?, ByRef PAgeDesc1 As String, ByRef PAgeDesc2 As String, ByRef PAgeDesc3 As String, ByRef PAgeDesc4 As String, ByRef PAgeDesc5 As String, ByRef PAgeBal1 As Decimal?, ByRef PAgeBal2 As Decimal?, ByRef PAgeBal3 As Decimal?, ByRef PAgeBal4 As Decimal?, ByRef PAgeBal5 As Decimal?, ByRef PAgeBal6 As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetAPAgingInfoExt As IGetAPAgingInfo = New GetAPAgingInfoFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PAgeDesc1 As String, PAgeDesc2 As String, PAgeDesc3 As String, PAgeDesc4 As String, PAgeDesc5 As String, PAgeBal1 As Decimal?, PAgeBal2 As Decimal?, PAgeBal3 As Decimal?, PAgeBal4 As Decimal?, PAgeBal5 As Decimal?, PAgeBal6 As Decimal?, Infobar As String) = iGetAPAgingInfoExt.GetAPAgingInfoSp(PVendNum, PCurrCode, PTransDom, PSiteQuery, PAgeDesc1, PAgeDesc2, PAgeDesc3, PAgeDesc4, PAgeDesc5, PAgeBal1, PAgeBal2, PAgeBal3, PAgeBal4, PAgeBal5, PAgeBal6, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PAgeDesc1 = result.PAgeDesc1
            PAgeDesc2 = result.PAgeDesc2
            PAgeDesc3 = result.PAgeDesc3
            PAgeDesc4 = result.PAgeDesc4
            PAgeDesc5 = result.PAgeDesc5
            PAgeBal1 = result.PAgeBal1
            PAgeBal2 = result.PAgeBal2
            PAgeBal3 = result.PAgeBal3
            PAgeBal4 = result.PAgeBal4
            PAgeBal5 = result.PAgeBal5
            PAgeBal6 = result.PAgeBal6
            Infobar = result.Infobar
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
    Public Function GetAverageVendOnTimeDelPercentSp(ByVal pVendNum As String, ByVal pNumberOfMonths As Integer?, ByRef pAverageOnTimeDelPercent As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetAverageVendOnTimeDelPercentExt As IGetAverageVendOnTimeDelPercent = New GetAverageVendOnTimeDelPercentFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, pAverageOnTimeDelPercent As Decimal?) = iGetAverageVendOnTimeDelPercentExt.GetAverageVendOnTimeDelPercentSp(pVendNum, pNumberOfMonths, pAverageOnTimeDelPercent)
            Dim Severity As Integer = result.ReturnCode.Value
            pAverageOnTimeDelPercent = result.pAverageOnTimeDelPercent
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetParmsSp(ByRef POToleranceOver As Decimal?, ByRef POToleranceUnder As Decimal?, ByRef Vchrauthorize As Integer?, ByRef VchrOverPoCostTolerance As Decimal?, ByRef VchrUnderPoCostTolerance As Decimal?, ByRef PEFTBankCode As String, ByRef PEFTFormat As String, ByRef PEFTUserName As String, ByRef PEFTUserNumber As String, ByRef PPrintManualRemitAdvice As Integer?, ByRef PPrintEFTRemitAdvice As Integer?, ByRef PPrintWireRemitAdvice As Integer?, ByRef PPrintDraftRemitAdvice As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetParmsExt As IGetParms = New GetParmsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, POToleranceOver As Decimal?, POToleranceUnder As Decimal?, Vchrauthorize As Integer?, VchrOverPoCostTolerance As Decimal?, VchrUnderPoCostTolerance As Decimal?, PEFTBankCode As String, PEFTFormat As String, PEFTUserName As String, PEFTUserNumber As String, PPrintManualRemitAdvice As Integer?, PPrintEFTRemitAdvice As Integer?, PPrintWireRemitAdvice As Integer?, PPrintDraftRemitAdvice As Integer?) = iGetParmsExt.GetParmsSp(POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, PEFTBankCode, PEFTFormat, PEFTUserName, PEFTUserNumber, PPrintManualRemitAdvice, PPrintEFTRemitAdvice, PPrintWireRemitAdvice, PPrintDraftRemitAdvice)
            Dim Severity As Integer = result.ReturnCode.Value
            POToleranceOver = result.POToleranceOver
            POToleranceUnder = result.POToleranceUnder
            Vchrauthorize = result.Vchrauthorize
            VchrOverPoCostTolerance = result.VchrOverPoCostTolerance
            VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance
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
    Public Function IsVendorDeactivationValidSp(ByVal VendNum As String,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal Active As Byte?,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal FromMethod As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iIsVendorDeactivationValidExt As IIsVendorDeactivationValid = New IsVendorDeactivationValidFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iIsVendorDeactivationValidExt.IsVendorDeactivationValidSp(VendNum, Active, FromMethod, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RepRuleForObjectExistsSp(ByVal SourceSite As String, ByVal RepCategory As String, ByVal RepCatObject As String, ByVal RepCatObjectType As Byte?, ByRef RepRuleForObjectExists As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iRepRuleForObjectExistsExt As IRepRuleForObjectExists = New RepRuleForObjectExistsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, RepRuleForObjectExists As Integer?) = iRepRuleForObjectExistsExt.RepRuleForObjectExistsSp(SourceSite, RepCategory, RepCatObject, RepCatObjectType, RepRuleForObjectExists)
            Dim Severity As Integer = result.ReturnCode.Value
            RepRuleForObjectExists = result.RepRuleForObjectExists
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function VendorandCustomerSp(ByVal InputVendCustNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVendorandCustomerExt As IVendorandCustomer = New VendorandCustomerFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iVendorandCustomerExt.VendorandCustomerSp(InputVendCustNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DomesticCurrencySp(ByVal CurrCode As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal UseBuyRate As Byte?,
<[Optional]> ByVal TRate As Decimal?,
<[Optional]> ByVal PossibleDate As DateTime?,
<[Optional]> ByVal Amount1 As Decimal?,
<[Optional]> ByVal Amount2 As Decimal?,
<[Optional]> ByVal Amount3 As Decimal?,
<[Optional]> ByVal Amount4 As Decimal?,
<[Optional]> ByVal Amount5 As Decimal?,
<[Optional]> ByVal Amount6 As Decimal?,
<[Optional]> ByVal Amount7 As Decimal?,
<[Optional]> ByVal Amount8 As Decimal?,
<[Optional]> ByVal Amount9 As Decimal?,
<[Optional]> ByVal Amount10 As Decimal?,
<[Optional]> ByVal Amount11 As Decimal?,
<[Optional]> ByVal Amount12 As Decimal?,
<[Optional]> ByVal Amount13 As Decimal?,
<[Optional]> ByVal Amount14 As Decimal?,
<[Optional]> ByVal Amount15 As Decimal?,
<[Optional]> ByVal Amount16 As Decimal?,
<[Optional]> ByVal Amount17 As Decimal?,
<[Optional]> ByVal Amount18 As Decimal?,
<[Optional]> ByVal Amount19 As Decimal?,
<[Optional]> ByVal Amount20 As Decimal?,
<[Optional]> ByVal Amount21 As Decimal?,
<[Optional]> ByVal Amount22 As Decimal?,
<[Optional]> ByVal Amount23 As Decimal?,
<[Optional]> ByVal Amount24 As Decimal?,
<[Optional]> ByVal Amount25 As Decimal?,
<[Optional]> ByVal Amount26 As Decimal?,
<[Optional]> ByVal Amount27 As Decimal?,
<[Optional]> ByVal Amount28 As Decimal?,
<[Optional]> ByVal Amount29 As Decimal?,
<[Optional]> ByVal Amount30 As Decimal?,
<[Optional]> ByVal Amount31 As Decimal?,
<[Optional]> ByVal Amount32 As Decimal?,
<[Optional]> ByVal Amount33 As Decimal?,
<[Optional]> ByVal Amount34 As Decimal?,
<[Optional]> ByVal Amount35 As Decimal?,
<[Optional]> ByVal Amount36 As Decimal?,
<[Optional]> ByVal Amount37 As Decimal?,
<[Optional]> ByVal Amount38 As Decimal?,
<[Optional]> ByVal Amount39 As Decimal?,
<[Optional]> ByVal Amount40 As Decimal?) As DataTable
        Dim iCLM_DomesticCurrencyExt As ICLM_DomesticCurrency = New CLM_DomesticCurrencyFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsVendorStatusDeactivationValidSp(ByVal Stat As String,
        <[Optional], DefaultParameterValue(1)> ByVal Active As Integer?, ByRef Infobar As String) As Integer
        Dim iIsVendorStatusDeactivationValidExt As IIsVendorStatusDeactivationValid = New IsVendorStatusDeactivationValidFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iIsVendorStatusDeactivationValidExt.IsVendorStatusDeactivationValidSp(Stat, Active, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckForActiveBGTaskSp(ByVal TaskName As String, ByRef Infobar As String) As Integer
        Dim iCheckForActiveBGTaskExt As ICheckForActiveBGTask = New CheckForActiveBGTaskFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckForActiveBGTaskExt.CheckForActiveBGTaskSp(TaskName, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ChkPaySp(ByVal VendorVendNum As String, ByRef TPayhold As String, ByRef Infobar As String) As Integer
        Dim iChkPayExt As IChkPay = New ChkPayFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, TPayhold As String, Infobar As String) = iChkPayExt.ChkPaySp(VendorVendNum, TPayhold, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        TPayhold = result.TPayhold
        Infobar = result.Infobar
        Return Severity
    End Function
End Class