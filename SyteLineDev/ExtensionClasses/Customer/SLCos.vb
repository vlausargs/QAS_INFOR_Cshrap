Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports CSI.App.Logistics.Customer
Imports CSI.Data.CRUD
Imports CSI.Data.Functions
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack
Imports CSI.ExternalContracts.Portals
Imports CSI.Logistics.Customer
Imports CSI.Logistics.Vendor
Imports CSI.Material
Imports CSI.MG
Imports CSI.MG.MGCore
Imports Microsoft.Extensions.DependencyInjection
Imports Mongoose.Core.Common
Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.IDO.Protocol

<IDOExtensionClass("SLCos")>
Public Class SLCos
    Inherits CSIExtensionClassBase
    Implements ISLCos
    Implements IExtFTSLCos
    <IDOMethod(MethodFlags.None)>
    Public Function GetCoCustNum(ByVal strCoNum As String, ByRef strCoCustNum As String, ByRef bCustNumFound As Boolean) As Integer

        Dim response As LoadCollectionResponseData

        bCustNumFound = False
        strCoCustNum = IDONull.Value.ToString()

        response = Me.LoadCollection("CustNum", String.Format("CoNum = {0}", SqlLiteral.Format(strCoNum)), String.Empty, 1)

        If response.Items.Count = 1 Then
            strCoCustNum = response(0, 0).Value
            bCustNumFound = True
        End If

        Return 0

    End Function
    <IDOMethod(MethodFlags.None)>
    Public Function GetCoItem(ByVal strItem As String, ByRef strCoItem As String, ByRef bItemFound As Boolean) As Integer

        Dim response As LoadCollectionResponseData

        bItemFound = False
        strCoItem = IDONull.Value.ToString()

        response = Me.LoadCollection("CustNum", String.Format("CoNum = {0}", SqlLiteral.Format(strItem)), String.Empty, 1)
        If response.Items.Count = 1 Then
            strCoItem = response(0, 0).Value
            bItemFound = True
        End If

        Return 0
    End Function
    <IDOMethod(MethodFlags.None)>
    Public Function GetCoCompEnableFlags(ByVal CoNum As String,
                                  ByVal CustNum As String,
                                  ByVal UseExchRate As String,
                                  ByRef EdiOrder As String,
                                  ByRef LcrRequired As String,
                                  ByRef EnableOrderType As String,
                                  ByRef EnableConsolidate As String,
                                  ByRef EnableEffExpDate As String) As Integer

        Dim oInvokeResponseData As InvokeResponseData

        Try
            GetCoCompEnableFlags = 0

            If Len(CoNum) > 0 Or Len(CustNum) > 0 Then
                oInvokeResponseData = Me.Invoke("GetCoCompEnableFlagsSp", CoNum, CustNum,
                   UseExchRate, 0, 0, 1, 1, 1, IDONull.Value)

                GetCoCompEnableFlags = CInt(oInvokeResponseData.ReturnValue)
                EdiOrder = oInvokeResponseData.Parameters(3).Value
                LcrRequired = oInvokeResponseData.Parameters(4).Value
                EnableOrderType = oInvokeResponseData.Parameters(5).Value
                EnableConsolidate = oInvokeResponseData.Parameters(6).Value
                EnableEffExpDate = oInvokeResponseData.Parameters(7).Value

                oInvokeResponseData = Nothing
            End If
        Catch ex As Exception
            GetCoCompEnableFlags = 16
        End Try
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ChangeCOStatusSp(ByVal PText As String, ByVal OrderType As String, ByVal OldCoStat As String, ByVal NewCoStat As String, ByVal StartingOrder As String, ByVal EndingOrder As String, ByVal StartingDate As DateTime?, ByVal EndingDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingOrderDateOffset As Short?,
<[Optional]> ByVal EndingOrderDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iChangeCOStatusExt As IChangeCOStatus = New ChangeCOStatusFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iChangeCOStatusExt.ChangeCOStatusSp(PText, OrderType, OldCoStat, NewCoStat, StartingOrder, EndingOrder, StartingDate, EndingDate, Infobar, StartingOrderDateOffset, EndingOrderDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustExchRateValidSp(ByVal CustNum As String, ByVal CurrCode As String, ByVal ExchRate As Decimal?, ByVal InvoiceDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCustExchRateValidExt As ICustExchRateValid = New CustExchRateValidFactory().Create(appDb)
            Dim Severity As Integer = iCustExchRateValidExt.CustExchRateValidSp(CustNum, CurrCode, ExchRate, InvoiceDate, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerQuoteExistsWarningSp(ByVal CoNum As String, ByVal CustQuote As String, ByVal CustNum As String, ByVal ProspectId As String, ByRef Infobar As String) As Integer
        Dim iCustomerQuoteExistsWarningExt As ICustomerQuoteExistsWarning = Me.GetService(Of ICustomerQuoteExistsWarning)()
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCustomerQuoteExistsWarningExt.CustomerQuoteExistsWarningSp(CoNum, CustQuote, CustNum, ProspectId, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ChangeConsolidatedInvoicingSp(ByVal Process As String, ByVal StartCustomerNum As String, ByVal EndCustomerNum As String, ByVal StartOrderNum As String, ByVal EndOrderNum As String, ByVal ProcessCustomers As Byte?, ByVal ProcessOrders As Byte?, ByVal ConsolidatedInvoice As Byte?, ByVal CollectionFlag As Byte?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_ChangeConsolidatedInvoicingExt As ICLM_ChangeConsolidatedInvoicing = New CLM_ChangeConsolidatedInvoicingFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iCLM_ChangeConsolidatedInvoicingExt.CLM_ChangeConsolidatedInvoicingSp(Process, StartCustomerNum, EndCustomerNum, StartOrderNum, EndOrderNum, ProcessCustomers, ProcessOrders, ConsolidatedInvoice, CollectionFlag, Infobar)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ListEstimatedCharges(ByVal PTable As String, ByVal PSite As String, ByVal PCoNum As String, ByVal PCalcTax As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_ListEstimatedChargExt As ICLM_ListEstimatedCharg = New CLM_ListEstimatedChargFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_ListEstimatedChargExt.CLM_ListEstimatedCharges(PTable, PSite, PCoNum, PCalcTax)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoDiscAmountValidSp(ByVal PCoNum As String, ByVal PCoDiscountType As String,
<[Optional], DefaultParameterValue(0)> ByVal PCoDiscAmount As Decimal?,
<[Optional], DefaultParameterValue(0)> ByVal PCoMiscCharges As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCoDiscAmountValidExt As ICoDiscAmountValid = New CoDiscAmountValidFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoDiscAmountValidExt.CoDiscAmountValidSp(PCoNum, PCoDiscountType, PCoDiscAmount, PCoMiscCharges, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoGetOrderActivity2Sp(ByVal CoNum As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoGetOrderActivity2Ext As ICoGetOrderActivity2 = New CoGetOrderActivity2Factory().Create(appDb)

            Dim Severity As Integer = iCoGetOrderActivity2Ext.CoGetOrderActivity2Sp(CoNum, CustNum, CustSeq, PromptMsg, PromptButtons)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function COHeaderWarehouseChangeSp(ByVal StartingCONum As String, ByVal EndingCONum As String, ByVal OldWhse As String, ByVal NewWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCOHeaderWarehouseChangeExt As ICOHeaderWarehouseChange = New COHeaderWarehouseChangeFactory().Create(appDb)

            Dim Severity As Integer = iCOHeaderWarehouseChangeExt.COHeaderWarehouseChangeSp(StartingCONum, EndingCONum, OldWhse, NewWhse, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoNextKeyDelSp(ByVal CoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoNextKeyDelExt As ICoNextKeyDel = New CoNextKeyDelFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoNextKeyDelExt.CoNextKeyDelSp(CoNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function COQuickEntryPreLoadBindingSp(ByRef DuePeriod As Short?, ByVal CanAnyType1 As String, ByVal CanAnyFormName1 As String, ByRef Privilege1 As Short?, ByVal Type As String, ByVal Type1 As String, ByVal Obj As String, ByVal ParamSite As String, ByRef ApsParmApsmode As String, ByRef MrpParmReqSrc As String, ByRef CanDueNEProjected As Byte?, ByRef CanDueLTProjected As Byte?, ByRef SharedCustEnabled As Byte?, ByVal CanAnyType2 As String, ByVal CanAnyFormName2 As String, ByRef Privilege2 As Short?, ByVal CanAnyType3 As String, ByVal CanAnyFormName3 As String, ByRef Privilege3 As Short?, ByVal CanAnyType4 As String, ByVal CanAnyFormName4 As String, ByRef Privilege4 As Short?, ByRef VarTaxFreeImports As Short?, ByRef ConfigDetails As String, ByRef Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCOQuickEntryPreLoadBindingExt As ICOQuickEntryPreLoadBinding = New COQuickEntryPreLoadBindingFactory().Create(appDb)

            Dim Severity As Integer = iCOQuickEntryPreLoadBindingExt.COQuickEntryPreLoadBindingSp(DuePeriod, CanAnyType1, CanAnyFormName1, Privilege1, Type, Type1, Obj, ParamSite, ApsParmApsmode, MrpParmReqSrc, CanDueNEProjected, CanDueLTProjected, SharedCustEnabled, CanAnyType2, CanAnyFormName2, Privilege2, CanAnyType3, CanAnyFormName3, Privilege3, CanAnyType4, CanAnyFormName4, Privilege4, VarTaxFreeImports, ConfigDetails, Site)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoStatusChangeValidSp(ByVal CurrCoStatus As String, ByVal NewCoStatus As String, ByVal CoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoStatusChangeValidExt As ICoStatusChangeValid = New CoStatusChangeValidFactory().Create(appDb)

            Dim Severity As Integer = iCoStatusChangeValidExt.CoStatusChangeValidSp(CurrCoStatus, NewCoStatus, CoNum, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CpSoPreprocessSp(ByVal FromCoNum As String, ByVal ToCoNum As String, ByRef FromCurrCode As String, ByRef ToCurrCode As String, ByRef LcrWarningMsg As String, ByRef LcrWarningButtons As String, ByRef CurrCodeMatchWarningMsg As String, ByRef CurrCodeMatchWarningButtons As String, ByRef Infobar As String,
<[Optional]> ByVal ToType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCpSoPreprocessExt As ICpSoPreprocess = New CpSoPreprocessFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, FromCurrCode As String, ToCurrCode As String, LcrWarningMsg As String, LcrWarningButtons As String, CurrCodeMatchWarningMsg As String, CurrCodeMatchWarningButtons As String, Infobar As String) = iCpSoPreprocessExt.CpSoPreprocessSp(FromCoNum, ToCoNum, FromCurrCode, ToCurrCode, LcrWarningMsg, LcrWarningButtons, CurrCodeMatchWarningMsg, CurrCodeMatchWarningButtons, Infobar, ToType)
            Dim Severity As Integer = result.ReturnCode.Value
            FromCurrCode = result.FromCurrCode
            ToCurrCode = result.ToCurrCode
            LcrWarningMsg = result.LcrWarningMsg
            LcrWarningButtons = result.LcrWarningButtons
            CurrCodeMatchWarningMsg = result.CurrCodeMatchWarningMsg
            CurrCodeMatchWarningButtons = result.CurrCodeMatchWarningButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateQuickEntryPreLoadBindingSp(ByVal CanAnyType1 As String, ByVal CanAnyFormName1 As String, ByRef Privilege1 As Short?, ByVal CanAnyType2 As String, ByVal CanAnyFormName2 As String, ByRef Privilege2 As Short?, ByVal CanAnyType3 As String, ByVal CanAnyFormName3 As String, ByRef Privilege3 As Short?, ByVal CanAnyType4 As String, ByVal CanAnyFormName4 As String, ByRef Privilege4 As Short?, ByVal CanAnyType5 As String, ByVal CanAnyFormName5 As String, ByRef Privilege5 As Short?, ByRef ApsParmApsmode As String, ByRef ExpPeriod As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEstimateQuickEntryPreLoadBindingExt As IEstimateQuickEntryPreLoadBinding = New EstimateQuickEntryPreLoadBindingFactory().Create(appDb)

            Dim Severity As Integer = iEstimateQuickEntryPreLoadBindingExt.EstimateQuickEntryPreLoadBindingSp(CanAnyType1, CanAnyFormName1, Privilege1, CanAnyType2, CanAnyFormName2, Privilege2, CanAnyType3, CanAnyFormName3, Privilege3, CanAnyType4, CanAnyFormName4, Privilege4, CanAnyType5, CanAnyFormName5, Privilege5, ApsParmApsmode, ExpPeriod)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EurRvalSp(ByVal PText As String, ByVal StartingCurrencyCode As String, ByVal EndingCurrencyCode As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iEurRvalExt As IEurRval = New EurRvalFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iEurRvalExt.EurRvalSp(PText, StartingCurrencyCode, EndingCurrencyCode, Infobar)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCCPApprovedSp(ByVal CoNum As String, ByRef Approved As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCCPApprovedExt As IGetCCPApproved = New GetCCPApprovedFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Approved As Integer?, Infobar As String) = iGetCCPApprovedExt.GetCCPApprovedSp(CoNum, Approved, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Approved = result.Approved
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetMarkupFromItemSp(ByVal Item As String, ByRef Markup As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetMarkupFromItemExt As IGetMarkupFromItem = New GetMarkupFromItemFactory().Create(appDb)

            Dim Severity As Integer = iGetMarkupFromItemExt.GetMarkupFromItemSp(Item, Markup)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CalcUpdCOFreightChargeSp(ByVal CoNum As String,
<[Optional]> ByVal COShipMethod As String,
<[Optional], DefaultParameterValue(0)> ByRef COFreightChargeAmt As Decimal?,
<[Optional]> ByVal CalledByCO As String,
<[Optional]> ByRef Infobar As String) As Integer Implements ISLCos.CalcUpdCOFreightChargeSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCalcUpdCOFreightChargeExt As ICalcUpdCOFreightCharge = New CalcUpdCOFreightChargeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (ReturnCode As Integer?, COFreightChargeAmt As Decimal?, Infobar As String) = iCalcUpdCOFreightChargeExt.CalcUpdCOFreightChargeSp(CoNum, COShipMethod, COFreightChargeAmt, CalledByCO, Infobar)

            Dim Severity As Integer = result.ReturnCode.Value

            COFreightChargeAmt = result.COFreightChargeAmt
            Infobar = result.Infobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CpSoSp(ByVal CopyFromCoType As String, ByVal CopyToCoType As String, ByVal CopyFromCoNum As String, ByVal CopyToCoNum As String, ByVal pCpOrdStart As Short?, ByVal pCpOrdEnd As Short?, ByVal pCopyChoice As String, ByVal HasCfg As Byte?, ByVal CurWhse As String, ByVal pRecalcDueDate As Byte?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CalledFromEcomm As Byte?) As Integer Implements ISLCos.CpSoSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCpSoExt As ICpSo = New CpSoFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCpSoExt.CpSoSp(CopyFromCoType, CopyToCoType, CopyFromCoNum, CopyToCoNum, pCpOrdStart, pCpOrdEnd, pCopyChoice, HasCfg, CurWhse, pRecalcDueDate, Infobar, CalledFromEcomm)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateCoColSp(ByVal CoCustNum As String, ByVal CoCustSeq As Integer?, ByVal CoOrderDate As DateTime?, ByVal CoWhse As String, ByVal CoConsignment As Byte?, ByVal ColItem As String, ByVal ColUM As String, ByVal ColQtyOrdered As Decimal?,
<[Optional]> ByVal CoType As String,
<[Optional]> ByVal CoShipFromSite As String,
<[Optional]> ByVal ItemPriceConv As Decimal?,
<[Optional]> ByVal ItemPrice As Decimal?,
<[Optional]> ByVal PortalUsername As String,
<[Optional]> ByVal ColProjectedDate As DateTime?,
<[Optional]> ByVal ColDueDate As DateTime?,
<[Optional]> ByVal ColPromiseDate As DateTime?,
<[Optional]> ByRef CoRowPointer As Guid?, ByRef Infobar As String) As Integer Implements ISLCos.CreateCoColSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCreateCoColExt As ICreateCoCol = New CreateCoColFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CoRowPointer As Guid?, Infobar As String) = iCreateCoColExt.CreateCoColSp(CoCustNum, CoCustSeq, CoOrderDate, CoWhse, CoConsignment, ColItem, ColUM, ColQtyOrdered, CoType, CoShipFromSite, ItemPriceConv, ItemPrice, PortalUsername, ColProjectedDate, ColDueDate, ColPromiseDate, CoRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CoRowPointer = result.CoRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LcrExpDateWarningSp(ByVal CoNum As String, ByVal CustNum As String, ByVal LcrNum As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iLcrExpDateWarningExt As ILcrExpDateWarning = New LcrExpDateWarningFactory().Create(appDb)

            Dim Severity As Integer = iLcrExpDateWarningExt.LcrExpDateWarningSp(CoNum, CustNum, LcrNum, PromptMsg, PromptButtons, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LcrValidSp(ByVal CoNum As String, ByVal CustNum As String, ByVal LcrNum As String, ByVal CoStat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iLcrValidExt As ILcrValid = New LcrValidFactory().Create(appDb)

            Dim Severity As Integer = iLcrValidExt.LcrValidSp(CoNum, CustNum, LcrNum, CoStat, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_ValidateResourceSp(
<[Optional]> ByVal RESID As String, ByRef BOMType As String, ByRef CoProductMix As String, ByRef LaborType As String, ByRef RESIDQTY As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMO_ValidateResourceExt As IMO_ValidateResource = New MO_ValidateResourceFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, BOMType As String, CoProductMix As String, LaborType As String, RESIDQTY As Integer?) = iMO_ValidateResourceExt.MO_ValidateResourceSp(RESID, BOMType, CoProductMix, LaborType, RESIDQTY)
            Dim Severity As Integer = result.ReturnCode.Value
            BOMType = result.BOMType
            CoProductMix = result.CoProductMix
            LaborType = result.LaborType
            RESIDQTY = result.RESIDQTY
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MoveEstimatesToHistorySp(
<[Optional], DefaultParameterValue("P")> ByVal Process As String,
<[Optional]> ByVal StartingEstimate As String,
<[Optional]> ByVal EndingEstimate As String,
<[Optional]> ByVal StartingQuoteDate As DateTime?,
<[Optional]> ByVal EndingQuoteDate As DateTime?,
<[Optional]> ByVal StartingExpDate As DateTime?,
<[Optional]> ByVal EndingExpDate As DateTime?,
<[Optional]> ByVal OldStatus As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iMoveEstimatesToHistoryExt As IMoveEstimatesToHistory = New MoveEstimatesToHistoryFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iMoveEstimatesToHistoryExt.MoveEstimatesToHistorySp(Process, StartingEstimate, EndingEstimate, StartingQuoteDate, EndingQuoteDate, StartingExpDate, EndingExpDate, OldStatus, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function OrderCreditHoldSp(ByVal GroupID As String, ByVal CreditHold As Byte?, ByVal StartingCustomer As String, ByVal EndingCustomer As String, ByVal StartingOrder As String, ByVal EndingOrder As String, ByVal SubCustomer As Byte?, ByVal AgingBasis As String, ByVal AgingDate As DateTime?, ByVal Reason As String, ByRef Infobar As String, ByVal UserId As Decimal?,
<[Optional]> ByVal AgingDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iOrderCreditHoldExt As IOrderCreditHold = New OrderCreditHoldFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iOrderCreditHoldExt.OrderCreditHoldSp(GroupID, CreditHold, StartingCustomer, EndingCustomer, StartingOrder, EndingOrder, SubCustomer, AgingBasis, AgingDate, Reason, Infobar, UserId, AgingDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProfileEstimateResponseFormSp(
<[Optional]> ByVal EstimateStarting As String,
<[Optional]> ByVal EstimateEnding As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iProfileEstimateResponseFormExt As IProfileEstimateResponseForm = New ProfileEstimateResponseFormFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProfileEstimateResponseFormExt.ProfileEstimateResponseFormSp(EstimateStarting, EstimateEnding)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProfileOrderVerificationSp(
<[Optional]> ByVal CoTypeRegular As Byte?,
<[Optional]> ByVal CoTypeBlanket As Byte?,
<[Optional]> ByVal OrderStarting As String,
<[Optional]> ByVal OrderEnding As String,
<[Optional]> ByVal SalespersonStarting As String,
<[Optional]> ByVal SalespersonEnding As String,
<[Optional]> ByVal Sortby As String,
<[Optional]> ByVal CoStatus As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iProfileOrderVerificationExt As IProfileOrderVerification = New ProfileOrderVerificationFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProfileOrderVerificationExt.ProfileOrderVerificationSp(CoTypeRegular, CoTypeBlanket, OrderStarting, OrderEnding, SalespersonStarting, SalespersonEnding, Sortby, CoStatus)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ResvCoSp(ByVal CurCoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iResvCoExt As IResvCo = New ResvCoFactory().Create(appDb)

            Dim Severity As Integer = iResvCoExt.ResvCoSp(CurCoNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateRMALineOrderSp(ByVal CoNum As String, ByVal CurrCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iValidateRMALineOrderExt As IValidateRMALineOrder = New ValidateRMALineOrderFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateRMALineOrderExt.ValidateRMALineOrderSp(CoNum, CurrCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateSourceCoNumForCopySp(ByVal CoNum As String, ByVal OrderType As String, ByRef StartLineNum As Short?, ByRef EndLineNum As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iValidateSourceCoNumForCopyExt As IValidateSourceCoNumForCopy = New ValidateSourceCoNumForCopyFactory().Create(appDb)

            Dim Severity As Integer = iValidateSourceCoNumForCopyExt.ValidateSourceCoNumForCopySp(CoNum, OrderType, StartLineNum, EndLineNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateTargetCoNumForCopySp(ByVal OrderType As String, ByRef CoNum As String, ByVal FROMOrderType As String, ByVal FROMCoNum As String, ByRef StartLineNum As Short?, ByRef EndLineNum As Short?, ByRef Prompt As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iValidateTargetCoNumForCopyExt As IValidateTargetCoNumForCopy = New ValidateTargetCoNumForCopyFactory().Create(appDb)

            Dim Severity As Integer = iValidateTargetCoNumForCopyExt.ValidateTargetCoNumForCopySp(OrderType, CoNum, FROMOrderType, FROMCoNum, StartLineNum, EndLineNum, Prompt, PromptButtons, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyCoCustNumSp(ByVal CoNum As String, ByRef CustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVerifyCoCustNumExt As IVerifyCoCustNum = New VerifyCoCustNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustNum As String, Infobar As String) = iVerifyCoCustNumExt.VerifyCoCustNumSp(CoNum, CustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CustNum = result.CustNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalOrderTotalsCalculationSp(ByVal CoRowPointer As Guid?, ByVal ResellerPortalFlag As Byte?, ByVal ResellerCustNum As String, ByRef SubTotal As Decimal?, ByRef SalesTax As Decimal?, ByRef ShippingCost As Decimal?, ByRef ItemCnt As Integer?, ByRef CommissionAmountTotal As Decimal?, ByRef CoNum As String, ByRef Infobar As String) As Integer Implements ISLCos.PortalOrderTotalsCalculationSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalOrderTotalsCalculationExt As IPortalOrderTotalsCalculation = New PortalOrderTotalsCalculationFactory().Create(appDb)

            Dim Severity As Integer = iPortalOrderTotalsCalculationExt.PortalOrderTotalsCalculationSp(CoRowPointer, ResellerPortalFlag, ResellerCustNum, SubTotal, SalesTax, ShippingCost, ItemCnt, CommissionAmountTotal, CoNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SubmitOrderConfirmationSp(ByVal CoNum As String, ByVal Username As String) As Integer Implements ISLCos.SubmitOrderConfirmationSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iSubmitOrderConfirmationExt As ISubmitOrderConfirmation = New SubmitOrderConfirmationFactory().Create(appDb)

            Dim Severity As Integer = iSubmitOrderConfirmationExt.SubmitOrderConfirmationSp(CoNum, Username)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateCoShipToSp(ByVal RowPointer As Guid?, ByVal CustSeq As Integer?, ByRef Infobar As String) As Integer Implements ISLCos.UpdateCoShipToSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iUpdateCoShipToExt As IUpdateCoShipTo = New UpdateCoShipToFactory().Create(appDb)

            Dim Severity As Integer = iUpdateCoShipToExt.UpdateCoShipToSp(RowPointer, CustSeq, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateGUIDSp(ByRef GUID As Guid?) As Integer Implements IExtFTSLCos.GenerateGUIDSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGenerateGUIDExt As IGenerateGUID = New GenerateGUIDFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, GUID As System.Guid?) = iGenerateGUIDExt.GenerateGUIDSp(GUID)
            Dim Severity As Integer = result.ReturnCode.Value
            GUID = result.GUID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WfPrintPickListSp(ByVal pSite As String, ByVal pCoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWfPrintPickListExt As IWfPrintPickList = New WfPrintPickListFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iWfPrintPickListExt.WfPrintPickListSp(pSite, pCoNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CustServOrdersSp(ByVal FilterVar As String, ByVal CustNum As String, ByVal SlsmanList As String, ByVal OrdersFor As String, ByVal FilterString As String,
        <[Optional]> ByVal PSiteGroup As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_CustServOrdersExt As ICLM_CustServOrders = New CLM_CustServOrdersFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CustServOrdersExt.CLM_CustServOrdersSp(FilterVar, CustNum, SlsmanList, OrdersFor, FilterString, PSiteGroup)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetAllCosSp(ByVal CoType As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_GetAllCosExt As ICLM_GetAllCos = New CLM_GetAllCosFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetAllCosExt.CLM_GetAllCosSp(CoType)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetCoShippingMethodsSp(ByVal ShipMethod As String, ByVal CoNum As String, ByVal CoPaymentMethod As String, ByVal LangCode As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetCoShippingMethodsExt As ICLM_GetCoShippingMethods = New CLM_GetCoShippingMethodsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetCoShippingMethodsExt.CLM_GetCoShippingMethodsSp(ShipMethod, CoNum, CoPaymentMethod, LangCode)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetCOsmobiSp(ByVal CustNum As String, ByVal SiteRef As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetCOsmobiExt As ICLM_GetCOsmobi = New CLM_GetCOsmobiFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetCOsmobiExt.CLM_GetCOsmobiSp(CustNum, SiteRef, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetEstimatesmobiSp(ByVal Customer As String, ByVal SiteRef As String,
<[Optional]> ByVal Filter As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetEstimatesmobiExt As ICLM_GetEstimatesmobi = New CLM_GetEstimatesmobiFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetEstimatesmobiExt.CLM_GetEstimatesmobiSp(Customer, SiteRef, Filter)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetPortalCoShippingMethodsSp(ByVal CoNum As String, ByVal CoPaymentMethod As String, ByVal LocaleID As Integer?, ByVal Filter As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetPortalCoShippingMethodsExt As ICLM_GetPortalCoShippingMethods = New CLM_GetPortalCoShippingMethodsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetPortalCoShippingMethodsExt.CLM_GetPortalCoShippingMethodsSp(CoNum, CoPaymentMethod, LocaleID, Filter)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetProspectEstimatesmobiSp(ByVal ProspectID As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetProspectEstimatesmobiExt As ICLM_GetProspectEstimatesmobi = New CLM_GetProspectEstimatesmobiFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetProspectEstimatesmobiExt.CLM_GetProspectEstimatesmobiSp(ProspectID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_SalespersonTop5CreditHoldSp(ByVal Slsman As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_SalespersonTop5CreditHoldExt As ICLM_SalespersonTop5CreditHold = New CLM_SalespersonTop5CreditHoldFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_SalespersonTop5CreditHoldExt.CLM_SalespersonTop5CreditHoldSp(Slsman)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoChgStatSp(ByVal PCoNum As String, ByVal PNewStatus As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoChgStatExt As ICoChgStat = New CoChgStatFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoChgStatExt.CoChgStatSp(PCoNum, PNewStatus, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoCustomerValid2Sp(ByVal CoNum As String, ByVal OldCustNum As String, ByVal RowPointer As Guid?, ByVal OrderDate As DateTime?, ByRef ExchRate As Decimal?, ByRef CustNum As String, ByRef CustSeq As Integer?, ByRef ShipmentExists As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Contact As String, ByRef Phone As String, ByRef BillToContact As String, ByRef BillToPhone As String, ByRef ShipToContact As String, ByRef ShipToPhone As String, ByRef CorpCust As String, ByRef CorpCustName As String, ByRef CorpCustContact As String, ByRef CorpCustPhone As String, ByRef CorpAddress As Integer?, ByRef CurrCode As String, ByRef UseExchRate As Integer?, ByRef Whse As String, ByRef ShipCode As String, ByRef ShipCodeDesc As String, ByRef ShipPartial As Integer?, ByRef ShipEarly As Integer?, ByRef Consolidate As Integer?, ByRef Summarize As Integer?, ByRef InvFreq As String, ByRef Einvoice As Integer?, ByRef TermsCode As String, ByRef TermsCodeDesc As String, ByRef Slsman As String, ByRef PriceCode As String, ByRef PriceCodeDesc As String, ByRef EndUserType As String, ByRef EndUserTypeDesc As String, ByRef ApsPullUp As Integer?, ByVal TaxCode1Type As String, ByRef TaxCode1 As String, ByRef TaxDesc1 As String, ByVal TaxCode2Type As String, ByRef TaxCode2 As String, ByRef TaxDesc2 As String, ByVal FrtTaxCode1Type As String, ByRef FrtTaxCode1 As String, ByRef FrtTaxDesc1 As String, ByVal FrtTaxCode2Type As String, ByRef FrtTaxCode2 As String, ByRef FrtTaxDesc2 As String, ByVal MiscTaxCode1Type As String, ByRef MiscTaxCode1 As String, ByRef MiscTaxDesc1 As String, ByVal MiscTaxCode2Type As String, ByRef MiscTaxCode2 As String, ByRef MiscTaxDesc2 As String, ByRef TransNat As String, ByRef TransNat2 As String, ByRef Delterm As String, ByRef ProcessInd As String, ByRef CusLcrReqd As Integer?, ByRef CusUseExchRate As Integer?, ByRef OnCreditHold As Integer?, ByRef Infobar As String, ByRef ShipmentApprovalRequired As Integer?, ByRef ShipHold As Integer?,
<[Optional]> ByRef CurAllowOver As Integer?,
<[Optional]> ByRef CurpAllowOver As Integer?,
<[Optional]> ByRef CustIncludePrice As Integer?,
<[Optional]> ByVal Consignment As Integer?,
<[Optional]> ByRef ConsignableOrder As Integer?,
<[Optional]> ByRef shipped_over_ordered_qty_tolerance As Decimal?,
<[Optional]> ByRef shipped_under_ordered_qty_tolerance As Decimal?,
<[Optional]> ByRef days_shipped_after_due_date_tolerance As Integer?,
<[Optional]> ByRef days_shipped_before_due_date_tolerance As Integer?,
<[Optional]> ByRef EdiOrder As Integer?,
<[Optional]> ByRef LcrRequired As Integer?,
<[Optional]> ByRef EnableOrderType As Integer?,
<[Optional]> ByRef EnableConsolidate As Integer?,
<[Optional]> ByRef EnableEffExpDate As Integer?,
<[Optional]> ByVal CoOrderDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoCustomerValid2Ext As ICoCustomerValid2 = New CoCustomerValid2Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, CustNum As String, CustSeq As Integer?, ShipmentExists As Integer?, BillToAddress As String, ShipToAddress As String, Contact As String, Phone As String, BillToContact As String, BillToPhone As String, ShipToContact As String, ShipToPhone As String, CorpCust As String, CorpCustName As String, CorpCustContact As String, CorpCustPhone As String, CorpAddress As Integer?, CurrCode As String, UseExchRate As Integer?, Whse As String, ShipCode As String, ShipCodeDesc As String, ShipPartial As Integer?, ShipEarly As Integer?, Consolidate As Integer?, Summarize As Integer?, InvFreq As String, Einvoice As Integer?, TermsCode As String, TermsCodeDesc As String, Slsman As String, PriceCode As String, PriceCodeDesc As String, EndUserType As String, EndUserTypeDesc As String, ApsPullUp As Integer?, TaxCode1 As String, TaxDesc1 As String, TaxCode2 As String, TaxDesc2 As String, FrtTaxCode1 As String, FrtTaxDesc1 As String, FrtTaxCode2 As String, FrtTaxDesc2 As String, MiscTaxCode1 As String, MiscTaxDesc1 As String, MiscTaxCode2 As String, MiscTaxDesc2 As String, TransNat As String, TransNat2 As String, Delterm As String, ProcessInd As String, CusLcrReqd As Integer?, CusUseExchRate As Integer?, OnCreditHold As Integer?, Infobar As String, ShipmentApprovalRequired As Integer?, ShipHold As Integer?, CurAllowOver As Integer?, CurpAllowOver As Integer?, CustIncludePrice As Integer?, ConsignableOrder As Integer?, shipped_over_ordered_qty_tolerance As Decimal?, shipped_under_ordered_qty_tolerance As Decimal?, days_shipped_after_due_date_tolerance As Integer?, days_shipped_before_due_date_tolerance As Integer?, EdiOrder As Integer?, LcrRequired As Integer?, EnableOrderType As Integer?, EnableConsolidate As Integer?, EnableEffExpDate As Integer?) = iCoCustomerValid2Ext.CoCustomerValid2Sp(CoNum, OldCustNum, RowPointer, OrderDate, ExchRate, CustNum, CustSeq, ShipmentExists, BillToAddress, ShipToAddress, Contact, Phone, BillToContact, BillToPhone, ShipToContact, ShipToPhone, CorpCust, CorpCustName, CorpCustContact, CorpCustPhone, CorpAddress, CurrCode, UseExchRate, Whse, ShipCode, ShipCodeDesc, ShipPartial, ShipEarly, Consolidate, Summarize, InvFreq, Einvoice, TermsCode, TermsCodeDesc, Slsman, PriceCode, PriceCodeDesc, EndUserType, EndUserTypeDesc, ApsPullUp, TaxCode1Type, TaxCode1, TaxDesc1, TaxCode2Type, TaxCode2, TaxDesc2, FrtTaxCode1Type, FrtTaxCode1, FrtTaxDesc1, FrtTaxCode2Type, FrtTaxCode2, FrtTaxDesc2, MiscTaxCode1Type, MiscTaxCode1, MiscTaxDesc1, MiscTaxCode2Type, MiscTaxCode2, MiscTaxDesc2, TransNat, TransNat2, Delterm, ProcessInd, CusLcrReqd, CusUseExchRate, OnCreditHold, Infobar, ShipmentApprovalRequired, ShipHold, CurAllowOver, CurpAllowOver, CustIncludePrice, Consignment, ConsignableOrder, shipped_over_ordered_qty_tolerance, shipped_under_ordered_qty_tolerance, days_shipped_after_due_date_tolerance, days_shipped_before_due_date_tolerance, EdiOrder, LcrRequired, EnableOrderType, EnableConsolidate, EnableEffExpDate, CoOrderDate)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            CustNum = result.CustNum
            CustSeq = result.CustSeq
            ShipmentExists = result.ShipmentExists
            BillToAddress = result.BillToAddress
            ShipToAddress = result.ShipToAddress
            Contact = result.Contact
            Phone = result.Phone
            BillToContact = result.BillToContact
            BillToPhone = result.BillToPhone
            ShipToContact = result.ShipToContact
            ShipToPhone = result.ShipToPhone
            CorpCust = result.CorpCust
            CorpCustName = result.CorpCustName
            CorpCustContact = result.CorpCustContact
            CorpCustPhone = result.CorpCustPhone
            CorpAddress = result.CorpAddress
            CurrCode = result.CurrCode
            UseExchRate = result.UseExchRate
            Whse = result.Whse
            ShipCode = result.ShipCode
            ShipCodeDesc = result.ShipCodeDesc
            ShipPartial = result.ShipPartial
            ShipEarly = result.ShipEarly
            Consolidate = result.Consolidate
            Summarize = result.Summarize
            InvFreq = result.InvFreq
            Einvoice = result.Einvoice
            TermsCode = result.TermsCode
            TermsCodeDesc = result.TermsCodeDesc
            Slsman = result.Slsman
            PriceCode = result.PriceCode
            PriceCodeDesc = result.PriceCodeDesc
            EndUserType = result.EndUserType
            EndUserTypeDesc = result.EndUserTypeDesc
            ApsPullUp = result.ApsPullUp
            TaxCode1 = result.TaxCode1
            TaxDesc1 = result.TaxDesc1
            TaxCode2 = result.TaxCode2
            TaxDesc2 = result.TaxDesc2
            FrtTaxCode1 = result.FrtTaxCode1
            FrtTaxDesc1 = result.FrtTaxDesc1
            FrtTaxCode2 = result.FrtTaxCode2
            FrtTaxDesc2 = result.FrtTaxDesc2
            MiscTaxCode1 = result.MiscTaxCode1
            MiscTaxDesc1 = result.MiscTaxDesc1
            MiscTaxCode2 = result.MiscTaxCode2
            MiscTaxDesc2 = result.MiscTaxDesc2
            TransNat = result.TransNat
            TransNat2 = result.TransNat2
            Delterm = result.Delterm
            ProcessInd = result.ProcessInd
            CusLcrReqd = result.CusLcrReqd
            CusUseExchRate = result.CusUseExchRate
            OnCreditHold = result.OnCreditHold
            Infobar = result.Infobar
            ShipmentApprovalRequired = result.ShipmentApprovalRequired
            ShipHold = result.ShipHold
            CurAllowOver = result.CurAllowOver
            CurpAllowOver = result.CurpAllowOver
            CustIncludePrice = result.CustIncludePrice
            ConsignableOrder = result.ConsignableOrder
            shipped_over_ordered_qty_tolerance = result.shipped_over_ordered_qty_tolerance
            shipped_under_ordered_qty_tolerance = result.shipped_under_ordered_qty_tolerance
            days_shipped_after_due_date_tolerance = result.days_shipped_after_due_date_tolerance
            days_shipped_before_due_date_tolerance = result.days_shipped_before_due_date_tolerance
            EdiOrder = result.EdiOrder
            LcrRequired = result.LcrRequired
            EnableOrderType = result.EnableOrderType
            EnableConsolidate = result.EnableConsolidate
            EnableEffExpDate = result.EnableEffExpDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoCustomerValidSp(ByVal CoNum As String, ByVal OldCustNum As String, ByVal RowPointer As Guid?, ByRef CustNum As String, ByRef CustSeq As Integer?, ByRef ShipmentExists As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Contact As String, ByRef Phone As String, ByRef BillToContact As String, ByRef BillToPhone As String, ByRef ShipToContact As String, ByRef ShipToPhone As String, ByRef CorpCust As String, ByRef CorpCustName As String, ByRef CorpCustContact As String, ByRef CorpCustPhone As String, ByRef CorpAddress As Integer?, ByRef CurrCode As String, ByRef UseExchRate As Integer?, ByRef Whse As String, ByRef ShipCode As String, ByRef ShipCodeDesc As String, ByRef ShipPartial As Integer?, ByRef ShipEarly As Integer?, ByRef Consolidate As Integer?, ByRef Summarize As Integer?, ByRef InvFreq As String, ByRef Einvoice As Integer?, ByRef TermsCode As String, ByRef TermsCodeDesc As String, ByRef Slsman As String, ByRef PriceCode As String, ByRef PriceCodeDesc As String, ByRef EndUserType As String, ByRef EndUserTypeDesc As String, ByRef ApsPullUp As Integer?, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef TransNat As String, ByRef TransNat2 As String, ByRef Delterm As String, ByRef ProcessInd As String, ByRef Infobar As String, ByRef ShipmentApprovalRequired As Integer?, ByRef ShipHold As Integer?, ByRef ExchRate As Decimal?, ByRef CurrRateIsFixed As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoCustomerValidExt As ICoCustomerValid = New CoCustomerValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustNum As String, CustSeq As Integer?, ShipmentExists As Integer?, BillToAddress As String, ShipToAddress As String, Contact As String, Phone As String, BillToContact As String, BillToPhone As String, ShipToContact As String, ShipToPhone As String, CorpCust As String, CorpCustName As String, CorpCustContact As String, CorpCustPhone As String, CorpAddress As Integer?, CurrCode As String, UseExchRate As Integer?, Whse As String, ShipCode As String, ShipCodeDesc As String, ShipPartial As Integer?, ShipEarly As Integer?, Consolidate As Integer?, Summarize As Integer?, InvFreq As String, Einvoice As Integer?, TermsCode As String, TermsCodeDesc As String, Slsman As String, PriceCode As String, PriceCodeDesc As String, EndUserType As String, EndUserTypeDesc As String, ApsPullUp As Integer?, TaxCode1 As String, TaxCode2 As String, TransNat As String, TransNat2 As String, Delterm As String, ProcessInd As String, Infobar As String, ShipmentApprovalRequired As Integer?, ShipHold As Integer?, ExchRate As Decimal?, CurrRateIsFixed As Integer?) = iCoCustomerValidExt.CoCustomerValidSp(CoNum, OldCustNum, RowPointer, CustNum, CustSeq, ShipmentExists, BillToAddress, ShipToAddress, Contact, Phone, BillToContact, BillToPhone, ShipToContact, ShipToPhone, CorpCust, CorpCustName, CorpCustContact, CorpCustPhone, CorpAddress, CurrCode, UseExchRate, Whse, ShipCode, ShipCodeDesc, ShipPartial, ShipEarly, Consolidate, Summarize, InvFreq, Einvoice, TermsCode, TermsCodeDesc, Slsman, PriceCode, PriceCodeDesc, EndUserType, EndUserTypeDesc, ApsPullUp, TaxCode1, TaxCode2, TransNat, TransNat2, Delterm, ProcessInd, Infobar, ShipmentApprovalRequired, ShipHold, ExchRate, CurrRateIsFixed)
            Dim Severity As Integer = result.ReturnCode.Value
            CustNum = result.CustNum
            CustSeq = result.CustSeq
            ShipmentExists = result.ShipmentExists
            BillToAddress = result.BillToAddress
            ShipToAddress = result.ShipToAddress
            Contact = result.Contact
            Phone = result.Phone
            BillToContact = result.BillToContact
            BillToPhone = result.BillToPhone
            ShipToContact = result.ShipToContact
            ShipToPhone = result.ShipToPhone
            CorpCust = result.CorpCust
            CorpCustName = result.CorpCustName
            CorpCustContact = result.CorpCustContact
            CorpCustPhone = result.CorpCustPhone
            CorpAddress = result.CorpAddress
            CurrCode = result.CurrCode
            UseExchRate = result.UseExchRate
            Whse = result.Whse
            ShipCode = result.ShipCode
            ShipCodeDesc = result.ShipCodeDesc
            ShipPartial = result.ShipPartial
            ShipEarly = result.ShipEarly
            Consolidate = result.Consolidate
            Summarize = result.Summarize
            InvFreq = result.InvFreq
            Einvoice = result.Einvoice
            TermsCode = result.TermsCode
            TermsCodeDesc = result.TermsCodeDesc
            Slsman = result.Slsman
            PriceCode = result.PriceCode
            PriceCodeDesc = result.PriceCodeDesc
            EndUserType = result.EndUserType
            EndUserTypeDesc = result.EndUserTypeDesc
            ApsPullUp = result.ApsPullUp
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            TransNat = result.TransNat
            TransNat2 = result.TransNat2
            Delterm = result.Delterm
            ProcessInd = result.ProcessInd
            Infobar = result.Infobar
            ShipmentApprovalRequired = result.ShipmentApprovalRequired
            ShipHold = result.ShipHold
            ExchRate = result.ExchRate
            CurrRateIsFixed = result.CurrRateIsFixed
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoCustSeqValidSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef ShipToAddress As String, ByRef Whse As String, ByRef ShipCode As String, ByRef ShipPartial As Integer?, ByRef ShipEarly As Integer?, ByRef Slsman As String, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef ShipToContact As String, ByRef ShipToPhone As String, ByRef Infobar As String, ByRef ShipHold As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoCustSeqValidExt As ICoCustSeqValid = New CoCustSeqValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ShipToAddress As String, Whse As String, ShipCode As String, ShipPartial As Integer?, ShipEarly As Integer?, Slsman As String, TaxCode1 As String, TaxCode2 As String, ShipToContact As String, ShipToPhone As String, Infobar As String, ShipHold As Integer?) = iCoCustSeqValidExt.CoCustSeqValidSp(CustNum, CustSeq, ShipToAddress, Whse, ShipCode, ShipPartial, ShipEarly, Slsman, TaxCode1, TaxCode2, ShipToContact, ShipToPhone, Infobar, ShipHold)
            Dim Severity As Integer = result.ReturnCode.Value
            ShipToAddress = result.ShipToAddress
            Whse = result.Whse
            ShipCode = result.ShipCode
            ShipPartial = result.ShipPartial
            ShipEarly = result.ShipEarly
            Slsman = result.Slsman
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            ShipToContact = result.ShipToContact
            ShipToPhone = result.ShipToPhone
            Infobar = result.Infobar
            ShipHold = result.ShipHold
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoGetOrderActivitySp(ByVal PCoNum As String, ByVal PCustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoGetOrderActivityExt As ICoGetOrderActivity = New CoGetOrderActivityFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoGetOrderActivityExt.CoGetOrderActivitySp(PCoNum, PCustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function COPromotionCodeValidSp(
<[Optional]> ByVal Slsman As String,
<[Optional]> ByVal CustNum As String,
<[Optional]> ByVal EndUserType As String, ByVal CoOrderDate As DateTime?, ByVal CurrCode As String, ByVal CoNum As String,
<[Optional]> ByVal CustSeq As Integer?, ByVal CorpCust As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCOPromotionCodeValidExt As ICOPromotionCodeValid = New COPromotionCodeValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCOPromotionCodeValidExt.COPromotionCodeValidSp(Slsman, CustNum, EndUserType, CoOrderDate, CurrCode, CoNum, CustSeq, CorpCust, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CpSoCpSoCiSp(ByVal PFromCoType As String, ByVal PFromCoNum As String, ByVal PFromCoLine As Short?, ByVal PFromCurr As String, ByVal PToCoNum As String, ByVal PToCoLine As Short?, ByVal PToCoOrigSite As String, ByVal PToCurr As String, ByVal IsCrossSite As Byte?, ByVal PCopyShipSiteCo As Byte?, ByVal PToNew As Byte?, ByVal PHasCfg As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCpSoCpSoCiExt As ICpSoCpSoCi = New CpSoCpSoCiFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCpSoCpSoCiExt.CpSoCpSoCiSp(PFromCoType, PFromCoNum, PFromCoLine, PFromCurr, PToCoNum, PToCoLine, PToCoOrigSite, PToCurr, IsCrossSite, PCopyShipSiteCo, PToNew, PHasCfg, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CpSoCpSoSoSp(ByVal PCoNum As String, ByVal TPlaces As Byte?, ByRef POrderBal As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCpSoCpSoSoExt As ICpSoCpSoSo = New CpSoCpSoSoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, POrderBal As Decimal?, Infobar As String) = iCpSoCpSoSoExt.CpSoCpSoSoSp(PCoNum, TPlaces, POrderBal, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            POrderBal = result.POrderBal
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustPoExistsWarningSp(ByVal CoNum As String, ByVal CustPo As String, ByVal CustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustPoExistsWarningExt As ICustPoExistsWarning = New CustPoExistsWarningFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCustPoExistsWarningExt.CustPoExistsWarningSp(CoNum, CustPo, CustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustPriceIncludeTaxSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef CustIncludePrice As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCustPriceIncludeTaxExt As ICustPriceIncludeTax = New CustPriceIncludeTaxFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustIncludePrice As Integer?) = iCustPriceIncludeTaxExt.CustPriceIncludeTaxSp(CustNum, CustSeq, CustIncludePrice, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            CustIncludePrice = result.CustIncludePrice
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EInvoiceSp(ByVal pSite As String, ByVal pCoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEInvoiceExt As IEInvoice = New EInvoiceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iEInvoiceExt.EInvoiceSp(pSite, pCoNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstCustomerValidSp(ByVal CustNum As String, ByRef CustSeq As Integer?, ByRef Contact As String, ByRef Phone As String, ByRef Slsman As String, ByRef CustType As String, ByRef TermsCode As String, ByRef Pricecode As String, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef CurrCode As String, ByRef ExchRate As Decimal?, ByRef CurrRateIsFixed As Integer?, ByRef UseExchRate As Integer?, ByRef ShipEarly As Integer?, ByRef ShipPartial As Integer?, ByRef ShipCode As String, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef PCur0AmtFormat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEstCustomerValidExt As IEstCustomerValid = New EstCustomerValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustSeq As Integer?, Contact As String, Phone As String, Slsman As String, CustType As String, TermsCode As String, Pricecode As String, TaxCode1 As String, TaxCode2 As String, CurrCode As String, ExchRate As Decimal?, CurrRateIsFixed As Integer?, UseExchRate As Integer?, ShipEarly As Integer?, ShipPartial As Integer?, ShipCode As String, BillToAddress As String, ShipToAddress As String, PCur0AmtFormat As String, Infobar As String) = iEstCustomerValidExt.EstCustomerValidSp(CustNum, CustSeq, Contact, Phone, Slsman, CustType, TermsCode, Pricecode, TaxCode1, TaxCode2, CurrCode, ExchRate, CurrRateIsFixed, UseExchRate, ShipEarly, ShipPartial, ShipCode, BillToAddress, ShipToAddress, PCur0AmtFormat, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CustSeq = result.CustSeq
            Contact = result.Contact
            Phone = result.Phone
            Slsman = result.Slsman
            CustType = result.CustType
            TermsCode = result.TermsCode
            Pricecode = result.Pricecode
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            CurrCode = result.CurrCode
            ExchRate = result.ExchRate
            CurrRateIsFixed = result.CurrRateIsFixed
            UseExchRate = result.UseExchRate
            ShipEarly = result.ShipEarly
            ShipPartial = result.ShipPartial
            ShipCode = result.ShipCode
            BillToAddress = result.BillToAddress
            ShipToAddress = result.ShipToAddress
            PCur0AmtFormat = result.PCur0AmtFormat
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstProspectValidSp(ByVal ProspectId As String, ByRef Slsman As String, ByRef CurrCode As String, ByRef ExchRate As Decimal?, ByRef CurrRateIsFixed As Integer?, ByRef PCur0AmtFormat As String, ByRef Infobar As String, ByRef BillToAddress As String,
<[Optional]> ByRef TaxCode1 As String,
<[Optional]> ByRef TaxCode2 As String, ByRef Phone As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEstProspectValidExt As IEstProspectValid = New EstProspectValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Slsman As String, CurrCode As String, ExchRate As Decimal?, CurrRateIsFixed As Integer?, PCur0AmtFormat As String, Infobar As String, BillToAddress As String, TaxCode1 As String, TaxCode2 As String, Phone As String) = iEstProspectValidExt.EstProspectValidSp(ProspectId, Slsman, CurrCode, ExchRate, CurrRateIsFixed, PCur0AmtFormat, Infobar, BillToAddress, TaxCode1, TaxCode2, Phone)
            Dim Severity As Integer = result.ReturnCode.Value
            Slsman = result.Slsman
            CurrCode = result.CurrCode
            ExchRate = result.ExchRate
            CurrRateIsFixed = result.CurrRateIsFixed
            PCur0AmtFormat = result.PCur0AmtFormat
            Infobar = result.Infobar
            BillToAddress = result.BillToAddress
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            Phone = result.Phone
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstSetGloVarSp(ByVal EstSetLineStat As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEstSetGloVarExt As IEstSetGloVar = New EstSetGloVarFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iEstSetGloVarExt.EstSetGloVarSp(EstSetLineStat)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateOrderPickListSp(ByVal PSessionId As Guid?, ByVal PCoNum As String, ByVal PStartDueDate As DateTime?, ByVal PEndDueDate As DateTime?, ByVal PWhse As String, ByVal PCustNum As String, ByVal PCustSeq As Integer?, ByVal PParmsSite As String, ByVal PPostDate As DateTime?, ByVal PPostMatlIssues As Byte?, ByVal PBarLoc As Byte?, ByVal PShowExternal As Byte?, ByVal PShowInternal As Byte?, ByVal PDisplayHeader As Byte?, ByVal PPrintBc As Byte?, ByVal PPrint80 As Byte?, ByVal PDetSummBoth As String, ByVal PPrItemCi As String, ByVal PPrSerialNumbers As Byte?, ByVal PPrPlanItemMatl As Byte?, ByVal PPrStdOrderText As Byte?, ByVal PDisplayDescription As Byte?, ByVal PListByLoc As Byte?, ByVal PPickwarn As String, ByVal PSuppressErrorWhenCustomerLcrNotReqd As Byte?, ByVal PSkipOrderLineCycCnt As Byte?,
<[Optional]> ByVal PProcessBatchId As Integer?, ByVal PText As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGenerateOrderPickListExt As IGenerateOrderPickList = New GenerateOrderPickListFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iGenerateOrderPickListExt.GenerateOrderPickListSp(PSessionId, PCoNum, PStartDueDate, PEndDueDate, PWhse, PCustNum, PCustSeq, PParmsSite, PPostDate, PPostMatlIssues, PBarLoc, PShowExternal, PShowInternal, PDisplayHeader, PPrintBc, PPrint80, PDetSummBoth, PPrItemCi, PPrSerialNumbers, PPrPlanItemMatl, PPrStdOrderText, PDisplayDescription, PListByLoc, PPickwarn, PSuppressErrorWhenCustomerLcrNotReqd, PSkipOrderLineCycCnt, PProcessBatchId, PText, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCoCompEnableFlagsSp(ByVal CoNum As String, ByVal CustNum As String, ByVal UseExchRate As Integer?, ByRef EdiOrder As Integer?, ByRef LcrRequired As Integer?, ByRef EnableOrderType As Integer?, ByRef EnableConsolidate As Integer?, ByRef EnableEffExpDate As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCoCompEnableFlagsExt As IGetCoCompEnableFlags = New GetCoCompEnableFlagsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EdiOrder As Integer?, LcrRequired As Integer?, EnableOrderType As Integer?, EnableConsolidate As Integer?, EnableEffExpDate As Integer?, Infobar As String) = iGetCoCompEnableFlagsExt.GetCoCompEnableFlagsSp(CoNum, CustNum, UseExchRate, EdiOrder, LcrRequired, EnableOrderType, EnableConsolidate, EnableEffExpDate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EdiOrder = result.EdiOrder
            LcrRequired = result.LcrRequired
            EnableOrderType = result.EnableOrderType
            EnableConsolidate = result.EnableConsolidate
            EnableEffExpDate = result.EnableEffExpDate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDIFOTPolicySp(
<[Optional]> ByVal Site As String,
<[Optional]> ByVal PCoNum As String,
<[Optional]> ByVal PCoLine As Integer?,
<[Optional]> ByVal PCoRelease As Integer?,
<[Optional]> ByVal PCustNum As String,
<[Optional]> ByVal PCustSeq As Integer?, ByVal PHierarchy As Integer?, ByRef shipped_over_ordered_qty_tolerance As Decimal?, ByRef shipped_under_ordered_qty_tolerance As Decimal?, ByRef days_shipped_after_due_date_tolerance As Integer?, ByRef days_shipped_before_due_date_tolerance As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetDIFOTPolicyExt As IGetDIFOTPolicy = New GetDIFOTPolicyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, shipped_over_ordered_qty_tolerance As Decimal?, shipped_under_ordered_qty_tolerance As Decimal?, days_shipped_after_due_date_tolerance As Integer?, days_shipped_before_due_date_tolerance As Integer?) = iGetDIFOTPolicyExt.GetDIFOTPolicySp(Site, PCoNum, PCoLine, PCoRelease, PCustNum, PCustSeq, PHierarchy, shipped_over_ordered_qty_tolerance, shipped_under_ordered_qty_tolerance, days_shipped_after_due_date_tolerance, days_shipped_before_due_date_tolerance)
            Dim Severity As Integer = result.ReturnCode.Value
            shipped_over_ordered_qty_tolerance = result.shipped_over_ordered_qty_tolerance
            shipped_under_ordered_qty_tolerance = result.shipped_under_ordered_qty_tolerance
            days_shipped_after_due_date_tolerance = result.days_shipped_after_due_date_tolerance
            days_shipped_before_due_date_tolerance = result.days_shipped_before_due_date_tolerance
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
    Public Function LockCoSp(ByVal CoNum As String, ByVal Lock As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iLockCoExt As ILockCo = New LockCoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iLockCoExt.LockCoSp(CoNum, Lock)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function NewCustomerOrderValidSp(ByVal CoTableFlag As Integer?, ByVal CoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iNewCustomerOrderValidExt As INewCustomerOrderValid = New NewCustomerOrderValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iNewCustomerOrderValidExt.NewCustomerOrderValidSp(CoTableFlag, CoNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProfilePriceAdjustmentSp(ByVal CoNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProfilePriceAdjustmentExt As IProfilePriceAdjustment = New ProfilePriceAdjustmentFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProfilePriceAdjustmentExt.ProfilePriceAdjustmentSp(CoNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ReserveOrderSp(ByVal pSite As String, ByVal pCoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iReserveOrderExt As IReserveOrder = New ReserveOrderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iReserveOrderExt.ReserveOrderSp(pSite, pCoNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function RMALineItemsOrdersSp(
        <[Optional]> ByVal CoNumFilter As String,
        <[Optional]> ByVal CurrCode As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRMALineItemsOrdersExt As IRMALineItemsOrders = New RMALineItemsOrdersFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iRMALineItemsOrdersExt.RMALineItemsOrdersSp(CoNumFilter, CurrCode)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SumCoSp(ByVal PCoNum As String, ByRef Infobar As String,
    <[Optional], DefaultParameterValue(0)> ByRef NewTotalPrice As Decimal?,
    <[Optional], DefaultParameterValue(0)> ByRef PlannedDiscountOffset As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSumCoExt As ISumCo = New SumCoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, NewTotalPrice As Decimal?, PlannedDiscountOffset As Decimal?) = iSumCoExt.SumCoSp(PCoNum, Infobar, NewTotalPrice, PlannedDiscountOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            NewTotalPrice = result.NewTotalPrice
            PlannedDiscountOffset = result.PlannedDiscountOffset
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateExchRateInfoByCustSp(ByVal CustNum As String, ByRef CurAllowOver As Integer?, ByRef CurpAllowOver As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateExchRateInfoByCustExt As IUpdateExchRateInfoByCust = New UpdateExchRateInfoByCustFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CurAllowOver As Integer?, CurpAllowOver As Integer?) = iUpdateExchRateInfoByCustExt.UpdateExchRateInfoByCustSp(CustNum, CurAllowOver, CurpAllowOver)
            Dim Severity As Integer = result.ReturnCode.Value
            CurAllowOver = result.CurAllowOver
            CurpAllowOver = result.CurpAllowOver
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateOrderExchRateSp(ByVal CurrCode As String, ByVal OrderDate As DateTime?, ByRef ExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateOrderExchRateExt As IUpdateOrderExchRate = New UpdateOrderExchRateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iUpdateOrderExchRateExt.UpdateOrderExchRateSp(CurrCode, OrderDate, ExchRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdatePortalCoShippingMethodSp(ByVal CoNum As String, ByVal CoShipMethod As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdatePortalCoShippingMethodExt As IUpdatePortalCoShippingMethod = New UpdatePortalCoShippingMethodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iUpdatePortalCoShippingMethodExt.UpdatePortalCoShippingMethodSp(CoNum, CoShipMethod)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateCOConsignValuesSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal Whse As String, ByVal Consignment As Integer?, ByVal CoNum As String, ByRef ConsignableOrder As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateCOConsignValuesExt As IValidateCOConsignValues = New ValidateCOConsignValuesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ConsignableOrder As Integer?, Infobar As String) = iValidateCOConsignValuesExt.ValidateCOConsignValuesSp(CustNum, CustSeq, Whse, Consignment, CoNum, ConsignableOrder, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ConsignableOrder = result.ConsignableOrder
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CoDomesticCurrencySp(ByVal CurrCode As String,
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
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DomesticCurrencySp(ByVal CurrCode As String,
<[Optional], DefaultParameterValue(0)> ByVal UseBuyRate As Integer?,
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
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_EstDomesticCurrency(ByVal CurrCode As String,
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
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PAIDomesticCurrencySp(ByVal CurrCode As String,
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
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PAITaxAdDomesticCurrencySp(ByVal CurrCode As String,
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
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GenerateOrderPickList(ByVal PStartCoNum As String, ByVal PEndCoNum As String, ByVal PStartDueDate As DateTime?, ByVal PEndDueDate As DateTime?, ByVal PStartWhse As String, ByVal PEndWhse As String, ByVal PStartCustNum As String, ByVal PEndCustNum As String, ByVal PStartCustSeq As Integer?, ByVal PEndCustSeq As Integer?, ByVal PParmsSite As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim ExpandKyByTypeFactory As IExpandKyByTypeFactory = New ExpandKyByTypeFactory()
            Dim DayEndOfFactory As IDayEndOfFactory = New DayEndOfFactory()
            Dim HighDateFactory As IHighDateFactory = New HighDateFactory()
            Dim LowDateFactory As ILowDateFactory = New LowDateFactory()
            Dim HighIntFactory As IHighIntFactory = New HighIntFactory()
            Dim LowIntFactory As ILowIntFactory = New LowIntFactory()

            Dim iCLM_GenerateOrderPickListExt As ICLM_GenerateOrderPickList = New CLM_GenerateOrderPickListFactory(ExpandKyByTypeFactory, DayEndOfFactory, HighDateFactory,
                                                                                                                   LowDateFactory, HighIntFactory, LowIntFactory).Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True, Me)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GenerateOrderPickListExt.CLM_GenerateOrderPickListSp(PStartCoNum, PEndCoNum, PStartDueDate, PEndDueDate, PStartWhse, PEndWhse, PStartCustNum, PEndCustNum, PStartCustSeq, PEndCustSeq, PParmsSite)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    ''' <summary>
    ''' Provide an API that integrators can call to get the number of customer orders 
    ''' for various use cases to be used for display as metrics on a dashboard
    ''' </summary>
    ''' <external>yes</external>
    ''' <param name="OrderType">Specify the if Order or Estimate</param>
    ''' <param name="FilterType">Allowed values are Open,Late,New,Stopped,Complete
    ''' * Open   ( Open Quotes would be done using Order Type = Estimate and Filter Type = Open)
    ''' * Late   ( Orders that contain at least one line where the Due Date is greater then Today – Late Order Days (Default to 0))
    ''' * New    ( Order with any status and the Order Date > Today – New Order Days (Default to 7))
    ''' * Stopped( Order where the Status is Stopped and the Order Date > Today – Stopped Order Days (Default to 30))
    ''' </param>
    ''' <param name="CustNum">Customer number, every customer if omitted</param>
    ''' <param name="ShipTo">enter a shipto value as integer. 0 is used a default when omitted</param>
    ''' <param name="Days"></param>
    ''' <param name="OrderCount">return total number of records matched with the search criteria </param>
    ''' <param name="Infobar">return the error message, if any</param>
    ''' <returns>return the severity of the error, if any</returns>

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerOrderCount(ByVal OrderType As String,
                                       ByVal FilterType As String,
                                       ByVal CustNum As String,
                                       ByVal ShipTo As Integer?,
                                       ByVal Days As Integer?,
                                       ByRef OrderCount As Integer,
                                       ByRef Infobar As String) As Integer



        Dim result As (ReturnCode As Integer?,
                       OrderCount As Integer?,
                       Infobar As String) =
            Me.GetService(Of ICustomerOrderCount)().GetCustomerOrderCount(
                            OrderType,
                            FilterType,
                            CustNum,
                            ShipTo,
                            Days,
                            OrderCount,
                            Infobar)

        Infobar = result.Infobar
        OrderCount = CType(result.OrderCount, Integer)
        Return If(result.ReturnCode, 0)

    End Function

End Class
