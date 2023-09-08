Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports CSI.Finance.AR
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Vendor
Imports CSI.POS
Imports CSI.Codes
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLCustomer")>
Public Class SLCustomer
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.None)>
    Public Function ValidateCustSeqNotExist(ByVal CustNum As String, ByVal CustSeq As Integer) As Integer

        Dim loadResponse As LoadCollectionResponseData
        Dim filter As String
        Dim result As Integer = 0

        filter = String.Format(
           "CustNum = {0} AND CustSeq = {1}",
           SqlLiteral.Format(CustNum),
           SqlLiteral.Format(CustSeq))

        loadResponse = Me.LoadCollection("CustSeq", filter, String.Empty, 1)

        If loadResponse.Items.Count = 1 Then result = 16

        Return result

    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function GetTaxSystemInfo(
       ByRef DefTax1Code As String, ByRef DefTax2Code As String,
       ByRef Tax1CodeLabel As String, ByRef Tax2CodeLabel As String,
       ByRef Tax1IdLabel As String, ByRef Tax2IdLabel As String) As Integer

        Dim loadResponse As LoadCollectionResponseData
        Dim taxSystem As Byte

        DefTax1Code = String.Empty
        DefTax2Code = String.Empty
        Tax1CodeLabel = String.Empty
        Tax2CodeLabel = String.Empty
        Tax1IdLabel = String.Empty
        Tax2IdLabel = String.Empty

        loadResponse = Me.Context.Commands.LoadCollection(
           "SLTaxSystem",
           "TaxSystem, DefTaxCode, TaxCodeLabel, TaxIdLabel",
           String.Empty,
           String.Empty,
           -1)

        For index As Integer = 0 To loadResponse.Items.Count - 1
            taxSystem = loadResponse(index, "TaxSystem").GetValue(Of Byte)()

            If taxSystem = 1 Then
                DefTax1Code = loadResponse(index, "DefTaxCode").Value
                Tax1CodeLabel = loadResponse(index, "TaxCodeLabel").Value
                Tax1IdLabel = loadResponse(index, "TaxIdLabel").Value
            Else
                DefTax2Code = loadResponse(index, "DefTaxCode").Value
                Tax2CodeLabel = loadResponse(index, "TaxCodeLabel").Value
                Tax2IdLabel = loadResponse(index, "TaxIdLabel").Value
            End If
        Next

        Return 0

    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function GetCurrencyDefault(ByVal strCustNum As String, ByRef strCurrencyCode As String) As Integer

        Dim loadResponse As LoadCollectionResponseData
        Dim filter As String

        filter = String.Format(
           "CustNum = {0} AND CustSeq = 0",
           SqlLiteral.Format(strCustNum))

        loadResponse = Me.Context.Commands.LoadCollection(
           "SLCustAddrs",
           "CurrCode",
           filter,
           String.Empty,
           1)

        If loadResponse.Items.Count = 1 Then
            strCurrencyCode = loadResponse(0, "CurrCode").Value
        Else
            strCurrencyCode = IDONull.Value.ToString()
        End If

        Return 0

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArBalanceHistorySp(ByVal ParamBegCustNum As String, ByVal ParamEndCustNum As String, ByVal ParamThruDate As DateTime?, ByVal ParamResetPeriod As Byte?, ByRef Infobar As String, ByRef ParamRecCount As Integer?,
<[Optional]> ByVal ThruDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iArBalanceHistoryExt As CSI.Logistics.Customer.IARBalanceHistory = New CSI.Logistics.Customer.ARBalanceHistoryFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, ParamRecCount As Integer?) = iArBalanceHistoryExt.ARBalanceHistorySp(ParamBegCustNum, ParamEndCustNum, ParamThruDate, ParamResetPeriod, Infobar, ParamRecCount, ThruDateOffset)

            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            ParamRecCount = result.ParamRecCount

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArEndSp(ByVal ZeroPTDOnly As Byte?, ByVal CustSlsBoth As String, ByVal StatCycle As String, ByVal BegCustNum As String, ByVal EndCustNum As String, ByVal BegSlsMan As String, ByVal EndSlsMan As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAREndExt As IAREnd = New AREndFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAREndExt.AREndSp(ZeroPTDOnly, CustSlsBoth, StatCycle, BegCustNum, EndCustNum, BegSlsMan, EndSlsMan, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckCorpCustSp(ByVal CorpCust As String, ByVal CustNum As String, ByVal NewCurrCode As String, ByRef CorpCustName As String, ByRef Address As String, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCheckCorpCustExt As ICheckCorpCust = New CheckCorpCustFactory().Create(appDb)

            Dim result As (ReturnCode As Integer?, CorpCustName As String, Address As String, Infobar As String) = iCheckCorpCustExt.CheckCorpCustSp(CorpCust, CustNum, NewCurrCode, CorpCustName, Address, Infobar, PSite)

            Dim Severity As Integer = result.ReturnCode.Value
            CorpCustName = result.CorpCustName
            Address = result.Address
            Infobar = result.Infobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckCustExistsSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckCustExistsExt As ICheckCustExists = New CheckCustExistsFactory().Create(appDb)

            Dim Severity As Integer = iCheckCustExistsExt.CheckCustExistsSp(CustNum, CustSeq, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustGlobalSp(ByVal pCustNum As String, ByRef rGlobal As Integer?) As Integer
        Dim iCustGlobalExt As ICustGlobal = Me.GetService(Of ICustGlobal)()
        Dim result As (ReturnCode As Integer?, rGlobal As Integer?) = iCustGlobalExt.CustGlobalSp(pCustNum, rGlobal)
        rGlobal = result.rGlobal
        Dim Severity As Integer = result.ReturnCode.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Customer360_GetOverviewValuesSp(ByVal CustNum As String, ByRef AvailableLimit As Decimal?, ByRef LateOrders As Decimal?, ByRef BookingAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCustomer360_GetOverviewValuesExt As ICustomer360_GetOverviewValues = New Customer360_GetOverviewValuesFactory().Create(appDb)
            Dim Severity As Integer = iCustomer360_GetOverviewValuesExt.Customer360_GetOverviewValuesSp(CustNum, AvailableLimit, LateOrders, BookingAmount)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CustomerRebalYTDSp(ByVal StartingCustomer As String, ByVal EndingCustomer As String, ByVal YearStart As DateTime?, ByVal YearEnd As DateTime?, ByVal PeriodStart As DateTime?, ByVal PeriodEnd As DateTime?, ByVal LastYearStart As DateTime?, ByVal LastYearEnd As DateTime?, ByVal ResetSalesYTD As Byte?, ByVal ResetSalesLstYr As Byte?, ByVal ResetSalesPTD As Byte?, ByVal ResetDiscYTD As Byte?, ByVal ResetDiscLstYr As Byte?, ByVal ProcessVar As String, ByVal ExceptionsOnly As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCustomerRebalYTDExt As ICustomerRebalYTD = New CustomerRebalYTDFactory().Create(appDb, bunchedLoadCollection)
            Dim dt As DataTable = iCustomerRebalYTDExt.CustomerRebalYTDSp(StartingCustomer, EndingCustomer, YearStart, YearEnd, PeriodStart, PeriodEnd, LastYearStart, LastYearEnd, ResetSalesYTD, ResetSalesLstYr, ResetSalesPTD, ResetDiscYTD, ResetDiscLstYr, ProcessVar, ExceptionsOnly)
            Return dt
        End Using
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomersPreDeleteSp(ByVal PCustNum As String, ByVal PCustSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCustomersPreDeleteExt As ICustomersPreDelete = New CustomersPreDeleteFactory().Create(appDb)

            Dim Severity As Integer = iCustomersPreDeleteExt.CustomersPreDeleteSp(PCustNum, PCustSeq, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCurrCodeSp(ByVal CustNum As String, ByRef CurrCode As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCurrCodeExt As IGetCurrCode = New GetCurrCodeFactory().Create(appDb)

            Dim Severity As Integer = iGetCurrCodeExt.GetCurrCodeSp(CustNum, CurrCode)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetExportTypeSp(ByVal CustNum As String, ByRef ExportType As String, ByRef LangCode As String, ByRef Slsman As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetExportTypeExt As IGetExportType = New GetExportTypeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ExportType As String, LangCode As String, Slsman As String) = iGetExportTypeExt.GetExportTypeSp(CustNum, ExportType, LangCode, Slsman, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            ExportType = result.ExportType
            LangCode = result.LangCode
            Slsman = result.Slsman
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPrintPackInvDefSp(ByRef PrintPackInv As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetPrintPackInvDefExt As IGetPrintPackInvDef = New GetPrintPackInvDefFactory().Create(appDb)

            Dim Severity As Integer = iGetPrintPackInvDefExt.GetPrintPackInvDefSp(PrintPackInv)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsCustomerActiveSp(ByVal CustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsCustomerActiveExt As IIsCustomerActive = New IsCustomerActiveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iIsCustomerActiveExt.IsCustomerActiveSp(CustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MoveLocalCustPreProcessSp(ByVal POldCustNum As String, ByVal POldCustSeq As Integer?, ByVal PNewCustNum As String, ByVal PNewCustSeq As Integer?,
<[Optional]> ByRef PromptMsg As String,
<[Optional]> ByRef PromptButtons As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMoveLocalCustPreProcessExt As IMoveLocalCustPreProcess = New MoveLocalCustPreProcessFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iMoveLocalCustPreProcessExt.MoveLocalCustPreProcessSp(POldCustNum, POldCustSeq, PNewCustNum, PNewCustSeq, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MoveLocalCustSp(ByVal POldCustNum As String, ByVal POldCustSeq As Integer?, ByVal PNewCustNum As String, ByVal PNewCustSeq As Integer?,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMoveLocalCustExt As IMoveLocalCust = New MoveLocalCustFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMoveLocalCustExt.MoveLocalCustSp(POldCustNum, POldCustSeq, PNewCustNum, PNewCustSeq, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetCustDefSp(ByVal CustNum As String, ByRef TransNat As String, ByRef Delterm As String, ByRef ProcessInd As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSSSFSGetCustDefExt As ISSSFSGetCustDef = New SSSFSGetCustDefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TransNat As String, Delterm As String, ProcessInd As String, Infobar As String) = iSSSFSGetCustDefExt.SSSFSGetCustDefSp(CustNum, TransNat, Delterm, ProcessInd, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TransNat = result.TransNat
            Delterm = result.Delterm
            ProcessInd = result.ProcessInd
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidatePackSliponInvoiceSp(ByVal CustNum As String, ByVal PrintPackInv As Byte?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidatePackSliponInvoiceExt As IValidatePackSliponInvoice = New ValidatePackSliponInvoiceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidatePackSliponInvoiceExt.ValidatePackSliponInvoiceSp(CustNum, PrintPackInv, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DunningCustAgingBasisSp(
    <[Optional]> ByVal CustNum As String,
    <[Optional]> ByVal SiteRef As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_DunningCustAgingBasisExt As ICLM_DunningCustAgingBasis = New CLM_DunningCustAgingBasisFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DunningCustAgingBasisExt.CLM_DunningCustAgingBasisSp(CustNum, SiteRef)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrCnvtSp(ByVal CurrCode As String, ByVal FromDomestic As Integer?, ByVal UseBuyRate As Integer?, ByVal RoundResult As Integer?,
<[Optional]> ByVal [Date] As DateTime?,
<[Optional]> ByVal RoundPlaces As Integer?,
<[Optional], DefaultParameterValue(0)> ByVal UseCustomsAndExciseRates As Integer?,
<[Optional]> ByVal ForceRate As Integer?,
<[Optional]> ByVal FindTTFixed As Integer?,
<[Optional]> ByRef TRate As Decimal?, ByRef Infobar As String, ByVal Amount1 As Decimal?, ByRef Result1 As Decimal?,
<[Optional]> ByVal Amount2 As Decimal?,
<[Optional]> ByRef Result2 As Decimal?,
<[Optional]> ByVal Amount3 As Decimal?,
<[Optional]> ByRef Result3 As Decimal?,
<[Optional]> ByVal Amount4 As Decimal?,
<[Optional]> ByRef Result4 As Decimal?,
<[Optional]> ByVal Amount5 As Decimal?,
<[Optional]> ByRef Result5 As Decimal?,
<[Optional]> ByVal Amount6 As Decimal?,
<[Optional]> ByRef Result6 As Decimal?,
<[Optional]> ByVal Amount7 As Decimal?,
<[Optional]> ByRef Result7 As Decimal?,
<[Optional]> ByVal Amount8 As Decimal?,
<[Optional]> ByRef Result8 As Decimal?,
<[Optional]> ByVal Amount9 As Decimal?,
<[Optional]> ByRef Result9 As Decimal?,
<[Optional]> ByVal Amount10 As Decimal?,
<[Optional]> ByRef Result10 As Decimal?,
<[Optional]> ByVal Amount11 As Decimal?,
<[Optional]> ByRef Result11 As Decimal?,
<[Optional]> ByVal Amount12 As Decimal?,
<[Optional]> ByRef Result12 As Decimal?,
<[Optional]> ByVal Amount13 As Decimal?,
<[Optional]> ByRef Result13 As Decimal?,
<[Optional]> ByVal Amount14 As Decimal?,
<[Optional]> ByRef Result14 As Decimal?,
<[Optional]> ByVal Amount15 As Decimal?,
<[Optional]> ByRef Result15 As Decimal?,
<[Optional]> ByVal Site As String,
<[Optional]> ByVal DomCurrCode As String,
<[Optional]> ByRef TRateD As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCurrCnvtExt As ICurrCnvt = New CurrCnvtFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TRate As Decimal?, Infobar As String, Result1 As Decimal?, Result2 As Decimal?, Result3 As Decimal?, Result4 As Decimal?, Result5 As Decimal?, Result6 As Decimal?, Result7 As Decimal?, Result8 As Decimal?, Result9 As Decimal?, Result10 As Decimal?, Result11 As Decimal?, Result12 As Decimal?, Result13 As Decimal?, Result14 As Decimal?, Result15 As Decimal?, TRateD As Integer?) = iCurrCnvtExt.CurrCnvtSp(CurrCode, FromDomestic, UseBuyRate, RoundResult, [Date], RoundPlaces, UseCustomsAndExciseRates, ForceRate, FindTTFixed, TRate, Infobar, Amount1, Result1, Amount2, Result2, Amount3, Result3, Amount4, Result4, Amount5, Result5, Amount6, Result6, Amount7, Result7, Amount8, Result8, Amount9, Result9, Amount10, Result10, Amount11, Result11, Amount12, Result12, Amount13, Result13, Amount14, Result14, Amount15, Result15, Site, DomCurrCode, TRateD)
            Dim Severity As Integer = result.ReturnCode.Value
            TRate = result.TRate
            Infobar = result.Infobar
            Result1 = result.Result1
            Result2 = result.Result2
            Result3 = result.Result3
            Result4 = result.Result4
            Result5 = result.Result5
            Result6 = result.Result6
            Result7 = result.Result7
            Result8 = result.Result8
            Result9 = result.Result9
            Result10 = result.Result10
            Result11 = result.Result11
            Result12 = result.Result12
            Result13 = result.Result13
            Result14 = result.Result14
            Result15 = result.Result15
            TRateD = result.TRateD
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerCreditCheckSp(ByVal pSite As String, ByVal pCustNum As String, ByVal pAmount As Decimal?, ByRef pCreditLimitExceeded As Integer?, ByRef pCreditLimit As Decimal?, ByRef pCreditLimitBalance As Decimal?, ByRef pCurrencyCode As String, ByRef pOnCreditHold As Integer?, ByRef pCreditHoldReason As String, ByRef pLCRRequired As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustomerCreditCheckExt As ICustomerCreditCheck = New CustomerCreditCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, pCreditLimitExceeded As Integer?, pCreditLimit As Decimal?, pCreditLimitBalance As Decimal?, pCurrencyCode As String, pOnCreditHold As Integer?, pCreditHoldReason As String, pLCRRequired As Integer?, Infobar As String) = iCustomerCreditCheckExt.CustomerCreditCheckSp(pSite, pCustNum, pAmount, pCreditLimitExceeded, pCreditLimit, pCreditLimitBalance, pCurrencyCode, pOnCreditHold, pCreditHoldReason, pLCRRequired, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pCreditLimitExceeded = result.pCreditLimitExceeded
            pCreditLimit = result.pCreditLimit
            pCreditLimitBalance = result.pCreditLimitBalance
            pCurrencyCode = result.pCurrencyCode
            pOnCreditHold = result.pOnCreditHold
            pCreditHoldReason = result.pCreditHoldReason
            pLCRRequired = result.pLCRRequired
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FormatAddressSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iFormatAddressExt As IFormatAddress = New FormatAddressFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BillToAddress As String, ShipToAddress As String, Infobar As String) = iFormatAddressExt.FormatAddressSp(CustNum, CustSeq, BillToAddress, ShipToAddress, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BillToAddress = result.BillToAddress
            ShipToAddress = result.ShipToAddress
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustomerWhseSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef Whse As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCustomerWhseExt As IGetCustomerWhse = New GetCustomerWhseFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Whse As String) = iGetCustomerWhseExt.GetCustomerWhseSp(CustNum, CustSeq, Whse)
            Dim Severity As Integer = result.ReturnCode.Value
            Whse = result.Whse
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetCustVendNumfromAcctRoutingSp(ByVal Account As String, ByVal RoutingNumber As String, ByRef InfoBar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetCustVendNumfromAcctRoutingExt As IGetCustVendNumfromAcctRouting = New GetCustVendNumfromAcctRoutingFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iGetCustVendNumfromAcctRoutingExt.GetCustVendNumfromAcctRoutingSp(Account, RoutingNumber, InfoBar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            InfoBar = result.Infobar
            Return dt
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
    Public Function IsCustomerDeactivationValidSp(ByVal CustNum As String,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal Active As Byte?,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal FromMethod As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsCustomerDeactivationValidExt As IIsCustomerDeactivationValid = New IsCustomerDeactivationValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iIsCustomerDeactivationValidExt.IsCustomerDeactivationValidSp(CustNum, Active, FromMethod, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsCustomerStatusDeactivationValidSp(ByVal Stat As String,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal Active As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsCustomerStatusDeactivationValidExt As IIsCustomerStatusDeactivationValid = New IsCustomerStatusDeactivationValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iIsCustomerStatusDeactivationValidExt.IsCustomerStatusDeactivationValidSp(Stat, Active, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MoveProspectToCustomerSp(ByVal ProspectId As String, ByVal NewCustNum As String, ByVal BankCode As String, ByRef OutCustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMoveProspectToCustomerExt As IMoveProspectToCustomer = New MoveProspectToCustomerFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OutCustNum As String, Infobar As String) = iMoveProspectToCustomerExt.MoveProspectToCustomerSp(ProspectId, NewCustNum, BankCode, OutCustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            OutCustNum = result.OutCustNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyCustSeqDoesNotExistSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVerifyCustSeqDoesNotExistExt As IVerifyCustSeqDoesNotExist = New VerifyCustSeqDoesNotExistFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iVerifyCustSeqDoesNotExistExt.VerifyCustSeqDoesNotExistSp(CustNum, CustSeq, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckBankAddrSp(
        <[Optional]> ByVal bankcode As String,
        <[Optional]> ByVal PayType As String,
        <[Optional]> ByVal CustBank As String, ByVal PrintDraft As Integer?,
        <[Optional]> ByRef Infobar As String,
        <[Optional]> ByVal PSite As String) As Integer
        Dim iCheckBankAddrExt As ICheckBankAddr = New CheckBankAddrFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckBankAddrExt.CheckBankAddrSp(bankcode, PayType, CustBank, PrintDraft, Infobar, PSite)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function
End Class
