
Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common

Imports SL

Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Logistics.Vendor
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports Mongoose.IDO.DataAccess
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets

<IDOExtensionClass("SLTTVouchers")>
Public Class SLTTVouchers
    Inherits CSIExtensionClassBase

    Public Sub CLM_EmptyTaxesQuerySp()
        ' do not do anything
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ClearTTVouchersSp() As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iClearTTVouchersExt As IClearTTVouchers = New ClearTTVouchersFactory().Create(appDb)

            Dim Severity As Integer = iClearTTVouchersExt.ClearTTVouchersSp()

            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GenerateAPTransactionsSp(ByVal PVendNum As String,
        <[Optional], DefaultParameterValue("V")> ByVal PGenerateVoucher As String,
        <[Optional], DefaultParameterValue(CByte(1))> ByVal PCanEdi As Byte?,
        <[Optional], DefaultParameterValue(CByte(0))> ByVal PShowEdi As Byte?, ByVal CurrCode As String,
        <[Optional]> ByVal FilterString As String) As DataTable
        Dim iCLM_GenerateAPTransactionsExt As ICLM_GenerateAPTransactions = New CLM_GenerateAPTransactionsFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GenerateAPTransactionsExt.CLM_GenerateAPTransactionsSp(PVendNum, PGenerateVoucher, PCanEdi, PShowEdi, CurrCode, FilterString)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenAPTransactionsPostRefreshSp(ByVal PVendNum As String, ByVal PVendInvNum As String, ByVal PPoNum As String, ByVal PEdiFlag As Byte?, ByRef PFixedRate As Byte?, ByRef PExchRate As Decimal?, ByRef PTermsCode As String, ByRef PTermsCodeDescription As String, ByRef PAuthorizer As String, ByRef PSeqNum As Short?, ByRef PFreight As Decimal?, ByRef PMiscCharges As Decimal?, ByRef PSalesTax As Decimal?, ByRef PInvDate As DateTime?, ByRef PInvNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGenAPTransactionsPostRefreshExt As IGenAPTransactionsPostRefresh = New GenAPTransactionsPostRefreshFactory().Create(appDb)

            Dim Severity As Integer = iGenAPTransactionsPostRefreshExt.GenAPTransactionsPostRefreshSp(PVendNum, PVendInvNum, PPoNum, PEdiFlag, PFixedRate, PExchRate, PTermsCode, PTermsCodeDescription, PAuthorizer, PSeqNum, PFreight, PMiscCharges, PSalesTax, PInvDate, PInvNum)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenApValInvNumSp(ByVal PoInvNum As String, ByVal PoVendNum As String, ByVal Voucher As String,
<[Optional]> ByVal SiteRef As String,
<[Optional]> ByVal ProcessID As Guid?,
<[Optional]> ByVal CalledFrom As String, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGenApValInvNumExt As IGenApValInvNum = New GenApValInvNumFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String) = iGenApValInvNumExt.GenApValInvNumSp(PoInvNum, PoVendNum, Voucher, SiteRef, ProcessID, CalledFrom, PromptMsg, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateAptrxGenAPTransSp(ByVal PMatlCost As Decimal?, ByVal PVendCurrCode As String, ByVal PVchAdj As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateAptrxGenAPTransExt As IValidateAptrxGenAPTrans = New ValidateAptrxGenAPTransFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iValidateAptrxGenAPTransExt.ValidateAptrxGenAPTransSp(PMatlCost, PVendCurrCode, PVchAdj, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ClearSTypeTTVouchersSp() As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iClearSTypeTTVouchersExt As IClearSTypeTTVouchers = New ClearSTypeTTVouchersFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iClearSTypeTTVouchersExt.ClearSTypeTTVouchersSp()
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GenerateAPTrxnListPoNumSp(ByVal PVendNum As String,
    <[Optional], DefaultParameterValue("V")> ByVal PGenerateVoucher As String, ByVal CurrCode As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GenerateAPTrxnListPoNumExt As ICLM_GenerateAPTrxnListPoNum = New CLM_GenerateAPTrxnListPoNumFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GenerateAPTrxnListPoNumExt.CLM_GenerateAPTrxnListPoNumSp(PVendNum, PGenerateVoucher, CurrCode)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GenerateTaxDistributionSp(ByVal PVendNum As String, ByVal PInvDate As DateTime?, ByVal PFreight As Decimal?, ByVal PMisc As Decimal?, ByVal IncludeTaxInCost As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GenerateTaxDistributionExt As ICLM_GenerateTaxDistribution = New CLM_GenerateTaxDistributionFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GenerateTaxDistributionExt.CLM_GenerateTaxDistributionSp(PVendNum, PInvDate, PFreight, PMisc, IncludeTaxInCost)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_VchPrTaxDistributionSp(ByVal PPreRegister As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_VchPrTaxDistributionExt As ICLM_VchPrTaxDistribution = New CLM_VchPrTaxDistributionFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iCLM_VchPrTaxDistributionExt.CLM_VchPrTaxDistributionSp(PPreRegister)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MaterialDistributionCustUpdSp(ByVal ConnectionId As Guid?, ByVal VchType As String, ByVal PoNum As String, ByVal PoLine As Short?, ByVal PoRelease As Short?, ByVal GrnNum As String, ByVal GrnLine As Short?, ByVal Item As String, ByVal ItemDescription As String, ByVal TransNat As String, ByVal TransNat2 As String, ByVal UM As String, ByVal TermsCode As String, ByVal QtuQtyReceived As Decimal?, ByVal QtuQtyVoucher As Decimal?, ByVal CprItemCost As Decimal?, ByVal CprItemCostConv As Decimal?, ByVal CprPlanCostConv As Decimal?, ByVal PoRecordDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMaterialDistributionCustUpdExt As IMaterialDistributionCustUpd = New MaterialDistributionCustUpdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iMaterialDistributionCustUpdExt.MaterialDistributionCustUpdSp(ConnectionId, VchType, PoNum, PoLine, PoRelease, GrnNum, GrnLine, Item, ItemDescription, TransNat, TransNat2, UM, TermsCode, QtuQtyReceived, QtuQtyVoucher, CprItemCost, CprItemCostConv, CprPlanCostConv, PoRecordDate)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function TaxDistributionCustUpdSp(ByVal VchType As String, ByVal PoNum As String, ByVal TaxSystem As Byte?, ByVal TaxCode As String, ByVal TaxCodeE As String, ByVal AmtTaxBasis As Decimal?, ByVal AmtTaxAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTaxDistributionCustUpdExt As ITaxDistributionCustUpd = New TaxDistributionCustUpdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iTaxDistributionCustUpdExt.TaxDistributionCustUpdSp(VchType, PoNum, TaxSystem, TaxCode, TaxCodeE, AmtTaxBasis, AmtTaxAmount)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function
End Class