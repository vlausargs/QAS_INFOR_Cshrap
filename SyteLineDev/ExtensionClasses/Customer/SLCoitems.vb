Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common

Imports Mongoose.IDO.DataAccess
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports System.Runtime.InteropServices
Imports CSI.Material
Imports CSI.Production
Imports CSI.MOIndPack
Imports CSI.Logistics.Vendor
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.ExternalContracts.Portals
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLCoitems")>
Public Class SLCoitems
    Inherits CSIExtensionClassBase
    Implements ISLCoitems
    Implements IExtFTSLCoitems

    ' Custom method to flush the APS gateway
    Public Function ApsFlushGateway(ByVal PSite As Object, ByRef PInfobar As Object) As Integer
        Dim response As InvokeResponseData

        ' Pass control to flush gateway method in SLCtps IDO
        response = Me.Context.Commands.Invoke("SLCtps", "FlushGateway", PSite, PInfobar)
        PInfobar = response.Parameters(1)
        Return TextUtil.ParseNormalizedString(response.ReturnValue, 0)
    End Function

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub

    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim bIsNotEstimate As Boolean
        Dim request As UpdateCollectionRequestData

        request = CType(args.RequestPayload, UpdateCollectionRequestData)
        bIsNotEstimate = Not request.CustomInsert Like "*Estimate*"

        If bIsNotEstimate Then
            Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", IDONull.Value, "SLCoitems.PreUpdateCollection()")
            Me.Invoke("DefineVariableSp", "BufferCoitem", "1", IDONull.Value)
        End If
    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim bIsNotEstimate As Boolean
        Dim request As UpdateCollectionRequestData
        Dim PInfobar As String = IDONull.Value.ToString
        Dim resp As InvokeResponseData

        request = CType(args.RequestPayload, UpdateCollectionRequestData)
        bIsNotEstimate = Not request.CustomInsert Like "*Estimate*"

        If bIsNotEstimate Then
            resp = Me.Invoke("CoitemPostSaveSp", PInfobar)
            If resp.ReturnValue <> "0" Then
                MGException.Throw(resp.Parameters(0).GetValue(Of String)())
            End If
            Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", IDONull.Value, 0, "SLCoitems.PostUpdateCollection()")
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BlanketReleaseLineValidSp(ByVal CoNum As String, ByVal CoLine As Short?, ByRef CblItem As String, ByRef CblBlanketQtyConv As Decimal?, ByRef CblContPriceConv As Decimal?, ByRef CblUM As String, ByRef CblEffDate As DateTime?, ByRef CblExpDate As DateTime?, ByRef CoEdiOrder As Integer?, ByRef ItemPlanFlag As Integer?, ByRef CoWhse As String, ByRef CoSite As String, ByRef ICDuePeriod As Integer?, ByRef ItemDuePeriod As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iBlanketReleaseLineValidExt As IBlanketReleaseLineValid = New BlanketReleaseLineValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?,
           CblItem As String,
           CblBlanketQtyConv As Decimal?,
           CblContPriceConv As Decimal?,
           CblUM As String,
           CblEffDate As DateTime?,
           CblExpDate As DateTime?,
           CoEdiOrder As Integer?,
           ItemPlanFlag As Integer?,
           CoWhse As String,
           CoSite As String,
           ICDuePeriod As Integer?,
           ItemDuePeriod As Integer?,
           Infobar As String) = iBlanketReleaseLineValidExt.BlanketReleaseLineValidSp(CoNum, CoLine, CblItem, CblBlanketQtyConv, CblContPriceConv, CblUM, CblEffDate, CblExpDate, CoEdiOrder, ItemPlanFlag, CoWhse, CoSite, ICDuePeriod, ItemDuePeriod, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CblItem = result.CblItem
            CblBlanketQtyConv = result.CblBlanketQtyConv
            CblContPriceConv = result.CblContPriceConv
            CblUM = result.CblUM
            CblEffDate = result.CblEffDate
            CblExpDate = result.CblExpDate
            CoEdiOrder = result.CoEdiOrder
            ItemPlanFlag = result.ItemPlanFlag
            CoWhse = result.CoWhse
            CoSite = result.CoSite
            ICDuePeriod = result.ICDuePeriod
            ItemDuePeriod = result.ItemDuePeriod
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ChangeCOLineReleaseSp(ByVal StartOrderNum As String, ByVal EndOrderNum As String, ByVal StartLine As Short?, ByVal StartRelease As Short?, ByVal EndLine As Short?, ByVal EndRelease As Short?, ByVal StartCustomer As String, ByVal EndCustomer As String, ByVal StartOrderDate As DateTime?, ByVal EndOrderDate As DateTime?, ByVal StartDueDate As DateTime?, ByVal EndDueDate As DateTime?, ByVal StartReleaseDate As DateTime?, ByVal EndReleaseDate As DateTime?, ByVal OrderType As String, ByVal Status As String, ByVal PProcess As String, ByRef Infobar As String,
<[Optional]> ByVal StartOrderDateOffset As Short?,
<[Optional]> ByVal EndOrderDateOffset As Short?,
<[Optional]> ByVal StartDueDateOffset As Short?,
<[Optional]> ByVal EndDueDateOffset As Short?,
<[Optional]> ByVal StartReleaseDateOffset As Short?,
<[Optional]> ByVal EndReleaseDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iChangeCOLineReleaseExt As IChangeCOLineRelease = New ChangeCOLineReleaseFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iChangeCOLineReleaseExt.ChangeCOLineReleaseSp(StartOrderNum, EndOrderNum, StartLine, StartRelease, EndLine, EndRelease, StartCustomer, EndCustomer, StartOrderDate, EndOrderDate, StartDueDate, EndDueDate, StartReleaseDate, EndReleaseDate, OrderType, Status, PProcess, Infobar, StartOrderDateOffset, EndOrderDateOffset, StartDueDateOffset, EndDueDateOffset, StartReleaseDateOffset, EndReleaseDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemDropShipChangedSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal Item As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal CoTaxCode1 As String, ByVal CoTaxCode2 As String, ByVal TaxCode1 As String, ByVal TaxCode2 As String, ByRef ShipToAddress As String, ByRef ECCode As String, ByRef OutTaxCode1 As String, ByRef OutTaxCode2 As String, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoitemDropShipChangedExt As ICoitemDropShipChanged = New CoitemDropShipChangedFactory().Create(appDb)

            Dim oShipToAddress As LongAddress = ShipToAddress
            Dim oECCode As LongListType = ECCode
            Dim oOutTaxCode1 As TaxCodeType = OutTaxCode1
            Dim oOutTaxCode2 As TaxCodeType = OutTaxCode2
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons

            Dim Severity As Integer = iCoitemDropShipChangedExt.CoitemDropShipChangedSp(CoNum, CoLine, Item, CustNum, CustSeq, CoTaxCode1, CoTaxCode2, TaxCode1, TaxCode2, oShipToAddress, oECCode, oOutTaxCode1, oOutTaxCode2, oPromptMsg, oPromptButtons)

            ShipToAddress = oShipToAddress
            ECCode = oECCode
            OutTaxCode1 = oOutTaxCode1
            OutTaxCode2 = oOutTaxCode2
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoLineRelWarehouseChangeSp(ByVal OldWhse As String, ByVal NewWhse As String, ByVal StartingCoNum As String, ByVal EndingCoNum As String, ByVal StartingCoLine As Short?, ByVal EndingCoLine As Short?, ByVal StartingCoRelease As Short?, ByVal EndingCoRelease As Short?, ByVal StartingCustNum As String, ByVal EndingCustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoLineRelWarehouseChangeExt As ICoLineRelWarehouseChange = New CoLineRelWarehouseChangeFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iCoLineRelWarehouseChangeExt.CoLineRelWarehouseChangeSp(OldWhse, NewWhse, StartingCoNum, EndingCoNum, StartingCoLine, EndingCoLine, StartingCoRelease, EndingCoRelease, StartingCustNum, EndingCustNum, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteCOLineItemLogEntriesSp(ByVal SActivityDate As DateTime?, ByVal EActivityDate As DateTime?, ByVal SCoNum As String, ByVal ECoNum As String, ByVal SCoLine As Short?, ByVal ECoLine As Short?, ByVal SCoRelease As Short?, ByVal ECoRelease As Short?, ByVal CreateInitial As Short?, ByRef Infobar As String,
<[Optional]> ByVal StartingActivityDateOffset As Short?,
<[Optional]> ByVal EndingActivityDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDeleteCOLineItemLogEntriesExt As IDeleteCOLineItemLogEntries = New DeleteCOLineItemLogEntriesFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDeleteCOLineItemLogEntriesExt.DeleteCOLineItemLogEntriesSP(SActivityDate, EActivityDate, SCoNum, ECoNum, SCoLine, ECoLine, SCoRelease, ECoRelease, CreateInitial, Infobar, StartingActivityDateOffset, EndingActivityDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesCheckForRecalcSp(ByVal PNewUM As String, ByVal PItem As String, ByRef Infobar As String, ByRef Infobtn As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEstimateLinesCheckForRecalcExt As IEstimateLinesCheckForRecalc = New EstimateLinesCheckForRecalcFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar
            Dim oInfobtn As Infobar = Infobtn

            Dim Severity As Integer = iEstimateLinesCheckForRecalcExt.EstimateLinesCheckForRecalcSp(PNewUM, PItem, oInfobar, oInfobtn)

            Infobar = oInfobar
            Infobtn = oInfobtn

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesValidateUMSp(ByVal PUM As String, ByVal PItem As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesValidateUMExt As IEstimateLinesValidateUM = New EstimateLinesValidateUMFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iEstimateLinesValidateUMExt.EstimateLinesValidateUMSp(PUM, PItem, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesValidCustItemSp(ByVal PCustItem As String, ByVal PCustNum As String, ByVal PItem As String, ByRef PNewItem As String, ByRef PNewUM As String, ByRef PQuestion As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEstimateLinesValidCustItemExt As IEstimateLinesValidCustItem = New EstimateLinesValidCustItemFactory().Create(appDb)

            Dim oPNewItem As ItemType = PNewItem
            Dim oPNewUM As UMType = PNewUM
            Dim oPQuestion As Infobar = PQuestion
            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iEstimateLinesValidCustItemExt.EstimateLinesValidCustItemSp(PCustItem, PCustNum, PItem, oPNewItem, oPNewUM, oPQuestion, oInfobar)

            PNewItem = oPNewItem
            PNewUM = oPNewUM
            PQuestion = oPQuestion
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateRefNumSp(ByVal RefType As String, ByRef RefNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGenerateRefNumExt As IGenerateRefNum = New GenerateRefNumFactory().Create(appDb)

            Dim oRefNum As JobPoProjReqTrnNumType = RefNum
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iGenerateRefNumExt.GenerateRefNumSp(RefType, oRefNum, oInfobar)

            RefNum = oRefNum
            Infobar = oInfobar

            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ReserveSp(ByVal RsvdType As String, ByVal InFile As String, ByVal StartCoNum As String, ByVal EndCoNum As String, ByVal StartCoLine As Short?, ByVal EndCoLine As Short?, ByVal StartCoRelease As Short?, ByVal EndCoRelease As Short?, ByVal StartOrderDate As DateTime?, ByVal EndOrderDate As DateTime?, ByVal StartDueDate As DateTime?, ByVal EndDueDate As DateTime?, ByVal StartCustNum As String, ByVal EndCustNum As String, ByVal StartItem As String, ByVal EndItem As String, ByRef Infobar As String,
    <[Optional]> ByVal StartOrderDateOffset As Short?,
    <[Optional]> ByVal EndOrderDateOffset As Short?,
    <[Optional]> ByVal StartDueDateOffset As Short?,
    <[Optional]> ByVal EndDueDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iReserveExt As IReserve = New ReserveFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iReserveExt.ReserveSp(RsvdType, InFile, StartCoNum, EndCoNum, StartCoLine, EndCoLine, StartCoRelease, EndCoRelease, StartOrderDate, EndOrderDate, StartDueDate, EndDueDate, StartCustNum, EndCustNum, StartItem, EndItem, Infobar, StartOrderDateOffset, EndOrderDateOffset, StartDueDateOffset, EndDueDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgRemoveConfigurationHoldSp(ByVal SourceRefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal ConfigHold As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCfgRemoveConfigurationHoldExt As ICfgRemoveConfigurationHold = New CfgRemoveConfigurationHoldFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCfgRemoveConfigurationHoldExt.CfgRemoveConfigurationHoldSp(SourceRefType, RefNum, RefLineSuf, ConfigHold)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AU_CheckCoLineAndBlanketSp(ByVal CoNum As String, ByVal CoLine As Short?, ByRef Item As String, ByRef UM As String, ByRef Description As String, ByRef CustItem As String, ByRef CustUM As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iAU_CheckCoLineAndBlanketExt As IAU_CheckCoLineAndBlanket = New AU_CheckCoLineAndBlanketFactory().Create(appDb)

            Dim oItem As ItemType = Item
            Dim oUM As UMType = UM
            Dim oDescription As DescriptionType = Description
            Dim oCustItem As CustItemType = CustItem
            Dim oCustUM As UMType = CustUM
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iAU_CheckCoLineAndBlanketExt.AU_CheckCoLineAndBlanketSp(CoNum, CoLine, oItem, oUM, oDescription, oCustItem, oCustUM, oInfobar)

            Item = oItem
            UM = oUM
            Description = oDescription
            CustItem = oCustItem
            CustUM = oCustUM
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AU_CheckPriceAdjustInvoiceCountSp(ByVal SessionID As Guid?, ByRef InvoiceCount As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iAU_CheckPriceAdjustInvoiceCountExt As IAU_CheckPriceAdjustInvoiceCount = New AU_CheckPriceAdjustInvoiceCountFactory().Create(appDb)

            Dim oInvoiceCount As IntType = InvoiceCount

            Dim Severity As Integer = iAU_CheckPriceAdjustInvoiceCountExt.AU_CheckPriceAdjustInvoiceCountSp(SessionID, oInvoiceCount)

            InvoiceCount = oInvoiceCount

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AU_GetCustomerParmSp(ByVal CustNum As String, ByRef CustPriceBy As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iAU_GetCustomerParmExt As IAU_GetCustomerParm = New AU_GetCustomerParmFactory().Create(appDb)

            Dim oCustPriceBy As ListOrderDueType = CustPriceBy

            Dim Severity As Integer = iAU_GetCustomerParmExt.AU_GetCustomerParmSp(CustNum, oCustPriceBy)

            CustPriceBy = oCustPriceBy

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BlanketReleasesGetParmsSp(ByVal Type As String, ByVal Type1 As String, ByRef CanDueNEProjected As Byte?, ByRef CanDueLTProjected As Byte?, ByRef ParmDuePeriod As Short?, ByRef ApsParmApsmode As String, ByRef ParmEcReporting As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iBlanketReleasesGetParmsExt As IBlanketReleasesGetParms = New BlanketReleasesGetParmsFactory().Create(appDb)

            Dim oCanDueNEProjected As ListYesNoType = CanDueNEProjected
            Dim oCanDueLTProjected As ListYesNoType = CanDueLTProjected
            Dim oParmDuePeriod As DuePeriodType = ParmDuePeriod
            Dim oApsParmApsmode As ApsModeType = ApsParmApsmode
            Dim oParmEcReporting As ListYesNoType = ParmEcReporting

            Dim Severity As Integer = iBlanketReleasesGetParmsExt.BlanketReleasesGetParmsSp(Type, Type1, oCanDueNEProjected, oCanDueLTProjected, oParmDuePeriod, oApsParmApsmode, oParmEcReporting)

            CanDueNEProjected = oCanDueNEProjected
            CanDueLTProjected = oCanDueLTProjected
            ParmDuePeriod = oParmDuePeriod
            ApsParmApsmode = oApsParmApsmode
            ParmEcReporting = oParmEcReporting

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckCoStatusSp(ByVal CoType As String, ByVal CoNumListToCheck As String, ByRef CoNumAndStatList As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckCoStatusExt As ICheckCoStatus = New CheckCoStatusFactory().Create(appDb)

            Dim oCoNumAndStatList As LongListType = CoNumAndStatList
            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iCheckCoStatusExt.CheckCoStatusSp(CoType, CoNumListToCheck, oCoNumAndStatList, oInfobar)

            CoNumAndStatList = oCoNumAndStatList
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ChkXrefWarningSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal NewRefType As String, ByVal NewRefNum As String, ByVal NewRefLineSuf As Short?, ByVal NewRefRel As Short?, ByRef WarningMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iChkXrefWarningExt As IChkXrefWarning = New ChkXrefWarningFactory().Create(appDb)

            Dim oWarningMsg As Infobar = WarningMsg

            Dim Severity As Integer = iChkXrefWarningExt.ChkXrefWarningSp(CoNum, CoLine, CoRelease, NewRefType, NewRefNum, NewRefLineSuf, NewRefRel, oWarningMsg)

            WarningMsg = oWarningMsg

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CitemXSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal Item As String, ByVal UM As String, ByVal QtyOrdered As Decimal?, ByVal DueDate As DateTime?, ByVal Whse As String, ByRef CurSuffix As Short?, ByRef TXrefDestination As String, ByRef CreateFlag As Byte?, ByRef CreateFlag2 As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCitemXExt As ICitemX = New CitemXFactory().Create(appDb)

            Dim oCurSuffix As SuffixPoReqLineType = CurSuffix
            Dim oTXrefDestination As InfobarType = TXrefDestination
            Dim oCreateFlag As FlagNyType = CreateFlag
            Dim oCreateFlag2 As FlagNyType = CreateFlag2
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCitemXExt.CitemXSp(CoNum, CoLine, CoRelease, RefType, RefNum, RefLineSuf, RefRelease, Item, UM, QtyOrdered, DueDate, Whse, oCurSuffix, oTXrefDestination, oCreateFlag, oCreateFlag2, oPromptMsg, oPromptButtons, oInfobar)

            CurSuffix = oCurSuffix
            TXrefDestination = oTXrefDestination
            CreateFlag = oCreateFlag
            CreateFlag2 = oCreateFlag2
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar

            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CoItemsBacklogSp(
            <[Optional]> ByVal Cust_Num As String,
            <[Optional]> ByVal StartDate As DateTime?,
            <[Optional]> ByVal EndDate As DateTime?,
            <[Optional], DefaultParameterValue(CByte(0))> ByVal Detail As Byte?,
            <[Optional]> ByVal SiteRef As String,
            <[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_CoItemsBacklogExt As ICLM_CoItemsBacklog = New CLM_CoItemsBacklogFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CoItemsBacklogExt.CLM_CoItemsBacklogSp(Cust_Num, StartDate, EndDate, Detail, SiteRef, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CoItemsBookingsSp(
<[Optional]> ByVal Cust_Num As String,
<[Optional]> ByVal StartDate As DateTime?,
<[Optional]> ByVal EndDate As DateTime?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Detail As Byte?,
<[Optional]> ByVal SiteRef As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_CoItemsBookingsExt As ICLM_CoItemsBookings = New CLM_CoItemsBookingsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CoItemsBookingsExt.CLM_CoItemsBookingsSp(Cust_Num, StartDate, EndDate, Detail, SiteRef, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CoItemsShippingSp(
<[Optional]> ByVal Cust_Num As String,
<[Optional]> ByVal StartDate As DateTime?,
<[Optional]> ByVal EndDate As DateTime?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Detail As Byte?,
<[Optional]> ByVal SiteRef As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_CoItemsShippingExt As ICLM_CoItemsShipping = New CLM_CoItemsShippingFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CoItemsShippingExt.CLM_CoItemsShippingSp(Cust_Num, StartDate, EndDate, Detail, SiteRef, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function




    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CustomerOrderKitBuilderSp(
<[Optional]> ByVal StartingItem As String,
<[Optional]> ByVal EndingItem As String,
<[Optional]> ByVal PlannerCode As String,
<[Optional]> ByVal StartingDueDate As DateTime?,
<[Optional]> ByVal EndingDueDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_CustomerOrderKitBuilderExt As ICLM_CustomerOrderKitBuilder = New CLM_CustomerOrderKitBuilderFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CustomerOrderKitBuilderExt.CLM_CustomerOrderKitBuilderSp(StartingItem, EndingItem, PlannerCode, StartingDueDate, EndingDueDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CustomerTop5SalesSp() As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_CustomerTop5SalesExt As ICLM_CustomerTop5Sales = New CLM_CustomerTop5SalesFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CustomerTop5SalesExt.CLM_CustomerTop5SalesSp()
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()

            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoItemPriceBreakMarkupSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal VendorPriceBreaks As Byte?, ByVal ItemQty As Decimal?, ByVal ProdCycles As Decimal?, ByVal QtyPerCycle As Decimal?, ByVal Item As String, ByVal DueDate As DateTime?, ByVal Whse As String, ByVal BOMType As String, ByVal Resource As String, ByVal CoProductMix As String, ByVal AlternateID As String, ByVal PriceBasis As String, ByVal PriceBasisValue As Decimal?, ByVal CoDisc As Decimal?, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoItemPriceBreakMarkupExt As ICoItemPriceBreakMarkup = New CoItemPriceBreakMarkupFactory().Create(Me, True)

            Dim oInfoBar As InfobarType = InfoBar

            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoItemPriceBreakMarkupExt.CoItemPriceBreakMarkupSp(CoNum, CoLine, VendorPriceBreaks, ItemQty, ProdCycles, QtyPerCycle, Item, DueDate, Whse, BOMType, Resource, CoProductMix, AlternateID, PriceBasis, PriceBasisValue, CoDisc, oInfoBar)

            Dim Severity As Integer = result.ReturnCode.Value

            InfoBar = result.Infobar

            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoItemPriceBreakSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal ItemQty As Decimal?, ByVal VendorPriceBreaks As Byte?, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCoItemPriceBreakExt As ICoItemPriceBreak = New CoItemPriceBreakFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoItemPriceBreakExt.CoItemPriceBreakSp(CoNum, CoLine, ItemQty, VendorPriceBreaks, InfoBar)
            Dim Severity As Integer = result.ReturnCode.Value
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemValidatePriceSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoItem As String, ByVal Price As Decimal?, ByVal CurrCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoitemValidatePriceExt As ICoitemValidatePrice = New CoitemValidatePriceFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCoitemValidatePriceExt.CoitemValidatePriceSp(CoNum, CoLine, CoItem, Price, CurrCode, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemXrefSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal Item As String, ByVal ItemDescription As String, ByVal UM As String, ByVal CoStat As String, ByVal QtyOrdered As Decimal?, ByVal DueDate As DateTime?, ByVal Whse As String, ByVal FromWhse As String, ByVal FromSite As String, ByVal ToSite As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PoChangeOrd As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal MpwxrefDelete As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateProj As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateProjtask As Byte?, ByRef CurRefNum As String, ByRef CurRefLineSuf As Short?, ByRef CurRefRelease As Short?, ByVal TrnLoc As String, ByVal FOBSite As String, ByRef ItemLocQuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String, ByVal ExportType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCoitemXrefExt As ICoitemXref = New CoitemXrefFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CurRefNum As String, CurRefLineSuf As Short?, CurRefRelease As Short?, ItemLocQuestionAsked As Byte?, PromptMsg As String, PromptButtons As String, Infobar As String) = iCoitemXrefExt.CoitemXrefSp(CoNum, CoLine, CoRelease, RefType, RefNum, RefLineSuf, RefRelease, Item, ItemDescription, UM, CoStat, QtyOrdered, DueDate, Whse, FromWhse, FromSite, ToSite, PoChangeOrd, MpwxrefDelete, CreateProj, CreateProjtask, CurRefNum, CurRefLineSuf, CurRefRelease, TrnLoc, FOBSite, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar, ExportType)
            Dim Severity As Integer = result.ReturnCode.Value
            CurRefNum = result.CurRefNum
            CurRefLineSuf = result.CurRefLineSuf
            CurRefRelease = result.CurRefRelease
            ItemLocQuestionAsked = result.ItemLocQuestionAsked
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoPackingSlipQtyConvSp(ByVal QuantityToPackConv As Decimal?, ByVal Item As String, ByVal UM As String, ByVal CustNum As String, ByRef QuantityToPack As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoPackingSlipQtyConvExt As ICoPackingSlipQtyConv = New CoPackingSlipQtyConvFactory().Create(appDb)

            Dim oQuantityToPack As QtyUnitType = QuantityToPack
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCoPackingSlipQtyConvExt.CoPackingSlipQtyConvSp(QuantityToPackConv, Item, UM, CustNum, oQuantityToPack, oInfobar)

            QuantityToPack = oQuantityToPack
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoPackSlipQtyValidSp(ByVal QtyRequired As Decimal?, ByVal QtyToPack As Decimal?, ByVal TPckCall As String, ByRef Warning As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoPackSlipQtyValidExt As ICoPackSlipQtyValid = New CoPackSlipQtyValidFactory().Create(appDb)

            Dim oWarning As InfobarType = Warning
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCoPackSlipQtyValidExt.CoPackSlipQtyValidSp(QtyRequired, QtyToPack, TPckCall, oWarning, oInfobar)

            Warning = oWarning
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoReleaseValidQtyOrderedSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal Item As String, ByVal UM As String, ByVal CoCustNum As String, ByVal CurrCode As String, ByVal ItemPriceCode As String, ByVal QtyOrderedConv As Decimal?, ByVal CustItem As String, ByVal ShipSite As String, ByVal CoOrderDate As DateTime?, ByVal Whse As String, ByVal RefType As String, ByRef Price As Decimal?, ByRef QtyReady As Decimal?, ByRef QtyReadyConv As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCoReleaseValidQtyOrderedExt As ICoReleaseValidQtyOrdered = New CoReleaseValidQtyOrderedFactory().Create(appDb)

            Dim oPrice As AmountType = Price
            Dim oQtyReady As QtyUnitNoNegType = QtyReady
            Dim oQtyReadyConv As QtyUnitNoNegType = QtyReadyConv
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCoReleaseValidQtyOrderedExt.CoReleaseValidQtyOrderedSp(CoNum, CoLine, CoRelease, Item, UM, CoCustNum, CurrCode, ItemPriceCode, QtyOrderedConv, CustItem, ShipSite, CoOrderDate, Whse, RefType, oPrice, oQtyReady, oQtyReadyConv, oInfobar)

            Price = oPrice
            QtyReady = oQtyReady
            QtyReadyConv = oQtyReadyConv
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerServiceAlertsSp(ByRef PastDueCOLines As Integer?, ByRef PastDueCOReleases As Integer?, ByRef EstimatesToExpire As Integer?, ByRef NumberOfUserTasks As Integer?, ByRef NumberOfEventMessages As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCustomerServiceAlertsExt As ICustomerServiceAlerts = New CustomerServiceAlertsFactory().Create(appDb)

            Dim oPastDueCOLines As NumberOfLinesType = PastDueCOLines
            Dim oPastDueCOReleases As NumberOfLinesType = PastDueCOReleases
            Dim oEstimatesToExpire As NumberOfLinesType = EstimatesToExpire
            Dim oNumberOfUserTasks As NumberOfLinesType = NumberOfUserTasks
            Dim oNumberOfEventMessages As NumberOfLinesType = NumberOfEventMessages

            Dim Severity As Integer = iCustomerServiceAlertsExt.CustomerServiceAlertsSp(oPastDueCOLines, oPastDueCOReleases, oEstimatesToExpire, oNumberOfUserTasks, oNumberOfEventMessages)

            PastDueCOLines = oPastDueCOLines
            PastDueCOReleases = oPastDueCOReleases
            EstimatesToExpire = oEstimatesToExpire
            NumberOfUserTasks = oNumberOfUserTasks
            NumberOfEventMessages = oNumberOfEventMessages

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EitemXSp(ByVal EstNum As String, ByVal EstLine As Short?, ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal Item As String, ByVal UM As String, ByVal QtyOrdered As Decimal?, ByVal DueDate As DateTime?, ByVal Whse As String, ByRef CurSuffix As Short?, ByRef TXrefDestination As String, ByRef CreateFlag As Byte?, ByRef CreateFlag2 As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEitemXExt As IEitemX = New EitemXFactory().Create(appDb)

            Dim oCurSuffix As SuffixPoReqLineType = CurSuffix
            Dim oTXrefDestination As InfobarType = TXrefDestination
            Dim oCreateFlag As FlagNyType = CreateFlag
            Dim oCreateFlag2 As FlagNyType = CreateFlag2
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iEitemXExt.EitemXSp(EstNum, EstLine, RefType, RefNum, RefLineSuf, RefRelease, Item, UM, QtyOrdered, DueDate, Whse, oCurSuffix, oTXrefDestination, oCreateFlag, oCreateFlag2, oPromptMsg, oPromptButtons, oInfobar)

            CurSuffix = oCurSuffix
            TXrefDestination = oTXrefDestination
            CreateFlag = oCreateFlag
            CreateFlag2 = oCreateFlag2
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateItemChangeCustItemSp(ByVal PCustNum As String, ByVal PItem As String, ByRef PCustItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEstimateItemChangeCustItemExt As IEstimateItemChangeCustItem = New EstimateItemChangeCustItemFactory().Create(appDb)

            Dim oPCustItem As ItemType = PCustItem

            Dim Severity As Integer = iEstimateItemChangeCustItemExt.EstimateItemChangeCustItemSp(PCustNum, PItem, oPCustItem)

            PCustItem = oPCustItem

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesItemForCustItemSp(ByRef PItem As String, ByVal PCoNum As String, ByVal PCoLine As Short?, ByVal PCoRelease As Short?, ByVal PCustNum As String, ByVal PQtyOrdered As Decimal?, ByRef PUM As String, ByRef PDisc As Decimal?, ByRef PCustItem As String, ByRef PItemDesc As String, ByRef PRefType As String, ByRef PRefNum As String, ByRef PRefLineSuf As Short?, ByRef PRefRelease As Short?, ByRef PRepriceChecked As Byte?, ByRef PTaxCode1 As String, ByRef PTaxCode2 As String, ByRef ItemFeatStr As String, ByRef PCostConv As Decimal?, ByRef PStocked As Byte?, ByRef PNoChange As Byte?, ByRef PProdCfg As Byte?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef PTotCost As Decimal?, ByRef ItemFeatTempl As String, ByRef PItemSerialTracked As Byte?, ByRef PItemExists As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal WarnIfSlowMoving As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ErrorIfSlowMoving As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal WarnIfObsolete As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal ErrorIfObsolete As Byte?, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String,
<[Optional]> ByVal Site As String, ByVal PReprice As Byte?, ByVal PCurrCode As String, ByRef PUnitPriceConv As Decimal?, ByRef PUnitCostConv As Decimal?, ByRef PMatlCostConv As Decimal?, ByRef PLbrCostConv As Decimal?, ByRef PFovhdCostConv As Decimal?, ByRef PVovhdCostConv As Decimal?, ByRef POutCostConv As Decimal?, ByVal PRate As Decimal?, ByVal POrderDate As DateTime?, ByVal PPriceCode As String, ByRef PDuePeriod As Integer?, ByRef OplConfigureItem As Byte?, ByRef OplConfigureDone As Byte?,
<[Optional], DefaultParameterValue(0)> ByRef LineDisc As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iEstimateLinesItemForCustItemExt As IEstimateLinesItemForCustItem = New EstimateLinesItemForCustItemFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PItem As String, PUM As String, PDisc As Decimal?, PCustItem As String, PItemDesc As String, PRefType As String, PRefNum As String, PRefLineSuf As Short?, PRefRelease As Short?, PRepriceChecked As Byte?, PTaxCode1 As String, PTaxCode2 As String, ItemFeatStr As String, PCostConv As Decimal?, PStocked As Byte?, PNoChange As Byte?, PProdCfg As Byte?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, PTotCost As Decimal?, ItemFeatTempl As String, PItemSerialTracked As Byte?, PItemExists As Byte?, Infobar As String, Prompt As String, PromptButtons As String, PUnitPriceConv As Decimal?, PUnitCostConv As Decimal?, PMatlCostConv As Decimal?, PLbrCostConv As Decimal?, PFovhdCostConv As Decimal?, PVovhdCostConv As Decimal?, POutCostConv As Decimal?, PDuePeriod As Integer?, OplConfigureItem As Byte?, OplConfigureDone As Byte?, LineDisc As Decimal?) = iEstimateLinesItemForCustItemExt.EstimateLinesItemForCustItemSp(PItem, PCoNum, PCoLine, PCoRelease, PCustNum, PQtyOrdered, PUM, PDisc, PCustItem, PItemDesc, PRefType, PRefNum, PRefLineSuf, PRefRelease, PRepriceChecked, PTaxCode1, PTaxCode2, ItemFeatStr, PCostConv, PStocked, PNoChange, PProdCfg, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, ItemFeatTempl, PItemSerialTracked, PItemExists, WarnIfSlowMoving, ErrorIfSlowMoving, WarnIfObsolete, ErrorIfObsolete, Infobar, Prompt, PromptButtons, Site, PReprice, PCurrCode, PUnitPriceConv, PUnitCostConv, PMatlCostConv, PLbrCostConv, PFovhdCostConv, PVovhdCostConv, POutCostConv, PRate, POrderDate, PPriceCode, PDuePeriod, OplConfigureItem, OplConfigureDone, LineDisc)
            Dim Severity As Integer = result.ReturnCode.Value
            PItem = result.PItem
            PUM = result.PUM
            PDisc = result.PDisc
            PCustItem = result.PCustItem
            PItemDesc = result.PItemDesc
            PRefType = result.PRefType
            PRefNum = result.PRefNum
            PRefLineSuf = result.PRefLineSuf
            PRefRelease = result.PRefRelease
            PRepriceChecked = result.PRepriceChecked
            PTaxCode1 = result.PTaxCode1
            PTaxCode2 = result.PTaxCode2
            ItemFeatStr = result.ItemFeatStr
            PCostConv = result.PCostConv
            PStocked = result.PStocked
            PNoChange = result.PNoChange
            PProdCfg = result.PProdCfg
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            PTotCost = result.PTotCost
            ItemFeatTempl = result.ItemFeatTempl
            PItemSerialTracked = result.PItemSerialTracked
            PItemExists = result.PItemExists
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            PUnitPriceConv = result.PUnitPriceConv
            PUnitCostConv = result.PUnitCostConv
            PMatlCostConv = result.PMatlCostConv
            PLbrCostConv = result.PLbrCostConv
            PFovhdCostConv = result.PFovhdCostConv
            PVovhdCostConv = result.PVovhdCostConv
            POutCostConv = result.POutCostConv
            PDuePeriod = result.PDuePeriod
            OplConfigureItem = result.OplConfigureItem
            OplConfigureDone = result.OplConfigureDone
            LineDisc = result.LineDisc
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetNonInvItemInfoSp(ByVal Item As String,
<[Optional]> ByRef Description As String,
<[Optional]> ByRef UM As String,
<[Optional]> ByRef MatlType As String,
<[Optional]> ByRef Revision As String,
<[Optional]> ByRef ProductCode As String,
<[Optional]> ByRef DrawingNum As String,
<[Optional]> ByRef FamilyCode As String,
<[Optional]> ByRef Buyer As String,
<[Optional]> ByRef CommCode As String,
<[Optional]> ByRef Origin As String,
<[Optional]> ByRef SubjectToNaftaRvc As Integer?,
<[Optional], DefaultParameterValue(0)> ByRef UnitCost As Decimal?,
<[Optional]> ByRef PrefCrit As String,
<[Optional]> ByRef Producer As Integer?,
<[Optional]> ByRef WeightUnit As String,
<[Optional], DefaultParameterValue(0)> ByRef UnitWeight As Decimal?,
<[Optional], DefaultParameterValue(0)> ByRef UnitPrice As Decimal?,
<[Optional]> ByRef AllowOnPickList As Integer?,
<[Optional]> ByRef Infobar As String,
<[Optional]> ByVal CurrCode As String,
<[Optional]> ByVal OrderType As String,
<[Optional]> ByVal OrderKey1 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetNonInvItemInfoExt As IGetNonInvItemInfo = New GetNonInvItemInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Description As String, UM As String, MatlType As String, Revision As String, ProductCode As String, DrawingNum As String, FamilyCode As String, Buyer As String, CommCode As String, Origin As String, SubjectToNaftaRvc As Integer?, UnitCost As Decimal?, PrefCrit As String, Producer As Integer?, WeightUnit As String, UnitWeight As Decimal?, UnitPrice As Decimal?, AllowOnPickList As Integer?, Infobar As String) = iGetNonInvItemInfoExt.GetNonInvItemInfoSp(Item, Description, UM, MatlType, Revision, ProductCode, DrawingNum, FamilyCode, Buyer, CommCode, Origin, SubjectToNaftaRvc, UnitCost, PrefCrit, Producer, WeightUnit, UnitWeight, UnitPrice, AllowOnPickList, Infobar, CurrCode, OrderType, OrderKey1)
            Dim Severity As Integer = result.ReturnCode.Value
            Description = result.Description
            UM = result.UM
            MatlType = result.MatlType
            Revision = result.Revision
            ProductCode = result.ProductCode
            DrawingNum = result.DrawingNum
            FamilyCode = result.FamilyCode
            Buyer = result.Buyer
            CommCode = result.CommCode
            Origin = result.Origin
            SubjectToNaftaRvc = result.SubjectToNaftaRvc
            UnitCost = result.UnitCost
            PrefCrit = result.PrefCrit
            Producer = result.Producer
            WeightUnit = result.WeightUnit
            UnitWeight = result.UnitWeight
            UnitPrice = result.UnitPrice
            AllowOnPickList = result.AllowOnPickList
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Home_GetTodaysKeyCustomerValuesSp(ByRef LateAmount As Decimal?, ByRef BookingAmount As Decimal?, ByRef ReturnAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iHome_GetTodaysKeyCustomerValuesExt As IHome_GetTodaysKeyCustomerValues = New Home_GetTodaysKeyCustomerValuesFactory().Create(appDb)

            Dim oLateAmount As AmountType = LateAmount
            Dim oBookingAmount As AmountType = BookingAmount
            Dim oReturnAmount As AmountType = ReturnAmount

            Dim Severity As Integer = iHome_GetTodaysKeyCustomerValuesExt.Home_GetTodaysKeyCustomerValuesSp(oLateAmount, oBookingAmount, oReturnAmount)

            LateAmount = oLateAmount
            BookingAmount = oBookingAmount
            ReturnAmount = oReturnAmount

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Home_MetricInventoryShipRcvSp() As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iHome_MetricInventoryShipRcvExt As IHome_MetricInventoryShipRcv = New Home_MetricInventoryShipRcvFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iHome_MetricInventoryShipRcvExt.Home_MetricInventoryShipRcvSp()

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsCoitemXreferencedSp(ByVal PRefType As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PRefRelease As Short?, ByRef PXreferenced As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsCoitemXreferencedExt As IIsCoitemXreferenced = New IsCoitemXreferencedFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PXreferenced As Integer?) = iIsCoitemXreferencedExt.IsCoitemXreferencedSp(PRefType, PRefNum, PRefLineSuf, PRefRelease, PXreferenced)
            Dim Severity As Integer = result.ReturnCode.Value
            PXreferenced = result.PXreferenced
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_GetEstimateWBLineDataSp(ByVal CoNum As String, ByVal CoLine As Short?, ByRef Job As String, ByRef Suffix As Short?, ByRef Item As String, ByRef ItemDesc As String, ByRef CustNum As String, ByRef ProspectID As String, ByRef QuoteDate As DateTime?, ByRef XRefType As String, ByRef XREFJobExists As Byte?, ByRef XREFJobIsPrintJob As Byte?, ByRef XREFQuoteExists As Byte?, ByRef QuoteMethod As String, ByRef QtyOrderedConv As Decimal?, ByRef CoLineStatus As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPP_GetEstimateWBLineDataExt As IPP_GetEstimateWBLineData = New PP_GetEstimateWBLineDataFactory().Create(appDb)

            Dim oJob As JobType = Job
            Dim oSuffix As SuffixType = Suffix
            Dim oItem As ItemType = Item
            Dim oItemDesc As DescriptionType = ItemDesc
            Dim oCustNum As CustNumType = CustNum
            Dim oProspectID As ProspectIDType = ProspectID
            Dim oQuoteDate As DateTimeType = QuoteDate
            Dim oXRefType As RefTypeIJKPRTType = XRefType
            Dim oXREFJobExists As ListYesNoType = XREFJobExists
            Dim oXREFJobIsPrintJob As ListYesNoType = XREFJobIsPrintJob
            Dim oXREFQuoteExists As ListYesNoType = XREFQuoteExists
            Dim oQuoteMethod As StringType = QuoteMethod
            Dim oQtyOrderedConv As QtyUnitNoNegType = QtyOrderedConv
            Dim oCoLineStatus As CoitemStatusType = CoLineStatus
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPP_GetEstimateWBLineDataExt.PP_GetEstimateWBLineDataSp(CoNum, CoLine, oJob, oSuffix, oItem, oItemDesc, oCustNum, oProspectID, oQuoteDate, oXRefType, oXREFJobExists, oXREFJobIsPrintJob, oXREFQuoteExists, oQuoteMethod, oQtyOrderedConv, oCoLineStatus, oInfobar)

            Job = oJob
            Suffix = oSuffix
            Item = oItem
            ItemDesc = oItemDesc
            CustNum = oCustNum
            ProspectID = oProspectID
            QuoteDate = oQuoteDate
            XRefType = oXRefType
            XREFJobExists = oXREFJobExists
            XREFJobIsPrintJob = oXREFJobIsPrintJob
            XREFQuoteExists = oXREFQuoteExists
            QuoteMethod = oQuoteMethod
            QtyOrderedConv = oQtyOrderedConv
            CoLineStatus = oCoLineStatus
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_ProcessPrintingEstimateWBPriceDrivenSp(ByVal QuoteType As String, ByVal SourceNum As String, ByVal SourceLine As Short?, ByVal TargetCoNum As String, ByVal TargetCoLine As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPP_ProcessPrintingEstimateWBPriceDrivenExt As IPP_ProcessPrintingEstimateWBPriceDriven = New PP_ProcessPrintingEstimateWBPriceDrivenFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPP_ProcessPrintingEstimateWBPriceDrivenExt.PP_ProcessPrintingEstimateWBPriceDrivenSp(QuoteType, SourceNum, SourceLine, TargetCoNum, TargetCoLine, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_ProcessPrintingEstimateWBSp(ByVal QuoteType As String, ByVal SourceNum As String, ByVal SourceLine As Short?, ByVal TargetCoNum As String, ByVal TargetCoLine As Short?, ByRef TargetJob As String, ByRef TargetSuffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPP_ProcessPrintingEstimateWBExt As IPP_ProcessPrintingEstimateWB = New PP_ProcessPrintingEstimateWBFactory().Create(appDb)

            Dim oTargetJob As JobType = TargetJob
            Dim oTargetSuffix As SuffixType = TargetSuffix
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPP_ProcessPrintingEstimateWBExt.PP_ProcessPrintingEstimateWBSp(QuoteType, SourceNum, SourceLine, TargetCoNum, TargetCoLine, oTargetJob, oTargetSuffix, oInfobar)

            TargetJob = oTargetJob
            TargetSuffix = oTargetSuffix
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PromotionCodeValidSp(ByVal CoNum As String, ByVal Whse As String, ByVal Item As String, ByVal CoOrderDate As DateTime?, ByVal PromotionCode As String, ByVal ItemUM As String, ByVal CustItem As String, ByVal ShipSite As String, ByVal InQtyConv As Decimal?, ByVal CurrCode As String, ByVal ItemPriceCode As String, ByVal PriceConv As Decimal?, ByVal CoLine As Short?, ByVal ItemWhse As String, ByRef Infobar As String,
<[Optional]> ByVal Slsman As String,
<[Optional]> ByVal CustNum As String,
<[Optional]> ByVal CustSeq As Integer?,
<[Optional]> ByVal EndUserType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPromotionCodeValidExt As IPromotionCodeValid = New PromotionCodeValidFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPromotionCodeValidExt.PromotionCodeValidSp(CoNum, Whse, Item, CoOrderDate, PromotionCode, ItemUM, CustItem, ShipSite, InQtyConv, CurrCode, ItemPriceCode, PriceConv, CoLine, ItemWhse, Infobar, Slsman, CustNum, CustSeq, EndUserType)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ReadyQtyCalcsp(ByVal RefType As String, ByVal Item As String, ByVal OldWhse As String, ByVal ShipSite As String, ByRef QtyReady As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iReadyQtyCalcExt As IReadyQtyCalc = New ReadyQtyCalcFactory().Create(appDb)

            Dim Severity As Integer = iReadyQtyCalcExt.ReadyQtyCalcsp(RefType, Item, OldWhse, ShipSite, QtyReady)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RefTypeValidateSp(ByVal Item As String, ByVal RefType As String,
<[Optional]> ByVal Site As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iRefTypeValidateExt As IRefTypeValidate = New RefTypeValidateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRefTypeValidateExt.RefTypeValidateSp(Item, RefType, Site, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetCoStatusSp(ByVal CoNumList As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSetCoStatusExt As ISetCoStatus = New SetCoStatusFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSetCoStatusExt.SetCoStatusSp(CoNumList, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function UpdateCOLineDIFOTPolicySp(ByVal StartCustNum As String, ByVal EndCustNum As String, ByVal StartCustSeq As Integer?, ByVal EndCustSeq As Integer?, ByVal StartOrder As String, ByVal EndOrder As String, ByVal StartLine As Short?, ByVal EndLine As Short?, ByVal StartRelease As Short?, ByVal EndRelease As Short?, ByVal StartShipDate As DateTime?, ByVal EndShipDate As DateTime?, ByVal StartDueDate As DateTime?, ByVal EndDueDate As DateTime?, ByVal OrderedStat As Byte?, ByVal PlannedStat As Byte?, ByVal CompleteStat As Byte?, ByVal FilledStat As Byte?, ByVal QtyOver As Decimal?, ByVal QtyUnder As Decimal?, ByVal DaysAfter As Short?, ByVal DaysBefore As Short?, ByVal PProcess As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iUpdateCOLineDIFOTPolicyExt As IUpdateCOLineDIFOTPolicy = New UpdateCOLineDIFOTPolicyFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iUpdateCOLineDIFOTPolicyExt.UpdateCOLineDIFOTPolicySp(StartCustNum, EndCustNum, StartCustSeq, EndCustSeq, StartOrder, EndOrder, StartLine, EndLine, StartRelease, EndRelease, StartShipDate, EndShipDate, StartDueDate, EndDueDate, OrderedStat, PlannedStat, CompleteStat, FilledStat, QtyOver, QtyUnder, DaysAfter, DaysBefore, PProcess, Infobar)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CpSoSp(ByVal CopyFromCoType As String, ByVal CopyToCoType As String, ByVal CopyFromCoNum As String, ByVal CopyToCoNum As String, ByVal pCpOrdStart As Short?, ByVal pCpOrdEnd As Short?, ByVal pCopyChoice As String, ByVal HasCfg As Byte?, ByVal CurWhse As String, ByVal pRecalcDueDate As Byte?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CalledFromEcomm As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCpSoExt As ICLM_CpSo = New CLM_CpSoFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCpSoExt.CpSoSp(CopyFromCoType, CopyToCoType, CopyFromCoNum, CopyToCoNum, pCpOrdStart, pCpOrdEnd, pCopyChoice, HasCfg, CurWhse, pRecalcDueDate, Infobar, CalledFromEcomm)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalQuoteTaxEstimationSp(ByVal CustNum As String, ByVal CoNum As String, ByVal CoLineList As String, ByVal CustSeqList As String, ByVal Freight As Decimal?, ByRef CoSalesTax As Decimal?, ByRef CoSalesTax2 As Decimal?,
                                               ByRef Infobar As String) As Integer Implements ISLCoitems.PortalQuoteTaxEstimationSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPortalQuoteTaxEstimationExt As IPortalQuoteTaxEstimation = New PortalQuoteTaxEstimationFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CoSalesTax As Decimal?, CoSalesTax2 As Decimal?, Infobar As String) = iPortalQuoteTaxEstimationExt.PortalQuoteTaxEstimationSp(CustNum, CoNum, CoLineList, CustSeqList, Freight, CoSalesTax, CoSalesTax2, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CoSalesTax = result.CoSalesTax
            CoSalesTax2 = result.CoSalesTax2
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateCoitemSp(ByVal CoLine As Short?,
<[Optional]> ByVal QtyOrderedConv As Decimal?,
<[Optional]> ByVal PriceConv As Decimal?,
<[Optional]> ByVal CustSeq As Integer?, ByRef Infobar As String, ByRef CoAlreadyPlaced As Byte?, ByRef EstAlreadyConverted As Byte?, ByRef CoRowPointer As Guid?,
<[Optional]> ByVal CoNum As String,
<[Optional]> ByVal CustNum As String,
<[Optional]> ByVal CoType As String,
<[Optional]> ByVal CoitemProjectedDate As DateTime?,
<[Optional]> ByVal CoitemDueDate As DateTime?,
<[Optional]> ByVal CoitemPromiseDate As DateTime?,
<[Optional]> ByVal CoitemUM As String) As Integer Implements ISLCoitems.UpdateCoitemSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iUpdateCoitemExt As IUpdateCoitem = New UpdateCoitemFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, CoAlreadyPlaced As Byte?, EstAlreadyConverted As Byte?, CoRowPointer As Guid?) = iUpdateCoitemExt.UpdateCoitemSp(CoLine, QtyOrderedConv, PriceConv, CustSeq, Infobar, CoAlreadyPlaced, EstAlreadyConverted, CoRowPointer, CoNum, CustNum, CoType, CoitemProjectedDate, CoitemDueDate, CoitemPromiseDate, CoitemUM)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            CoAlreadyPlaced = result.CoAlreadyPlaced
            EstAlreadyConverted = result.EstAlreadyConverted
            CoRowPointer = result.CoRowPointer
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateInternationalOrderSp(ByVal CoNum As String, ByVal PaymentMethod As String, ByVal ShipMethod As String, ByRef Infobar As String) As Integer Implements ISLCoitems.ValidateInternationalOrderSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iValidateInternationalOrderExt As IValidateInternationalOrder = New ValidateInternationalOrderFactory().Create(appDb)

            Dim Severity As Integer = iValidateInternationalOrderExt.ValidateInternationalOrderSp(CoNum, PaymentMethod, ShipMethod, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemInfoSp(ByRef Item As String, ByRef Description As String, ByRef UM As String, ByRef SerialTracked As Integer?, ByRef Revision As String, ByRef DrawingNbr As String, ByRef CostType As String, ByRef PMTCode As String, ByRef CurMatCost As Decimal?, ByRef CurMatCostConv As Decimal?, ByRef CurFreightCost As Decimal?, ByRef CurFreightCostConv As Decimal?, ByRef CurDutyCost As Decimal?, ByRef CurDutyCostConv As Decimal?, ByRef CurBrokerageCost As Decimal?, ByRef CurBrokerageCostConv As Decimal?, ByRef CurInsuranceCost As Decimal?, ByRef CurInsuranceCostConv As Decimal?, ByRef CurLocFrtCost As Decimal?, ByRef CurLocFrtCostConv As Decimal?, ByRef CommCode As String, ByRef Origin As String, ByRef UnitWeight As Decimal?, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef ItemExists As Integer?, ByRef SupplQtyReq As Integer?, ByRef SupplQtyConvFactor As Decimal?, ByRef PromptMsg As String, ByRef Infobar As String,
<[Optional]> ByVal Site As String, ByRef LotTracked As Integer?,
<[Optional]> ByRef PreassignLots As Integer?,
<[Optional]> ByRef PreassignSerials As Integer?, ByRef LotPrefix As String, ByRef SerialPrefix As String,
<[Optional]> ByVal Whse As String,
<[Optional], DefaultParameterValue(0)> ByRef IsOpenNonInvForm As Integer?) As Integer Implements IExtFTSLCoitems.GetItemInfoSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemInfoExt As IGetItemInfo = New GetItemInfoFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Item As String, Description As String, UM As String, SerialTracked As Integer?, Revision As String, DrawingNbr As String, CostType As String, PMTCode As String, CurMatCost As Decimal?, CurMatCostConv As Decimal?, CurFreightCost As Decimal?, CurFreightCostConv As Decimal?, CurDutyCost As Decimal?, CurDutyCostConv As Decimal?, CurBrokerageCost As Decimal?, CurBrokerageCostConv As Decimal?, CurInsuranceCost As Decimal?, CurInsuranceCostConv As Decimal?, CurLocFrtCost As Decimal?, CurLocFrtCostConv As Decimal?, CommCode As String, Origin As String, UnitWeight As Decimal?, TaxCode1 As String, TaxCode2 As String, ItemExists As Integer?, SupplQtyReq As Integer?, SupplQtyConvFactor As Decimal?, PromptMsg As String, Infobar As String, LotTracked As Integer?, PreassignLots As Integer?, PreassignSerials As Integer?, LotPrefix As String, SerialPrefix As String, IsOpenNonInvForm As Integer?) = iGetItemInfoExt.GetItemInfoSp(Item, Description, UM, SerialTracked, Revision, DrawingNbr, CostType, PMTCode, CurMatCost, CurMatCostConv, CurFreightCost, CurFreightCostConv, CurDutyCost, CurDutyCostConv, CurBrokerageCost, CurBrokerageCostConv, CurInsuranceCost, CurInsuranceCostConv, CurLocFrtCost, CurLocFrtCostConv, CommCode, Origin, UnitWeight, TaxCode1, TaxCode2, ItemExists, SupplQtyReq, SupplQtyConvFactor, PromptMsg, Infobar, Site, LotTracked, PreassignLots, PreassignSerials, LotPrefix, SerialPrefix, Whse, IsOpenNonInvForm)
            Dim Severity As Integer = result.ReturnCode.Value
            Item = result.Item
            Description = result.Description
            UM = result.UM
            SerialTracked = result.SerialTracked
            Revision = result.Revision
            DrawingNbr = result.DrawingNbr
            CostType = result.CostType
            PMTCode = result.PMTCode
            CurMatCost = result.CurMatCost
            CurMatCostConv = result.CurMatCostConv
            CurFreightCost = result.CurFreightCost
            CurFreightCostConv = result.CurFreightCostConv
            CurDutyCost = result.CurDutyCost
            CurDutyCostConv = result.CurDutyCostConv
            CurBrokerageCost = result.CurBrokerageCost
            CurBrokerageCostConv = result.CurBrokerageCostConv
            CurInsuranceCost = result.CurInsuranceCost
            CurInsuranceCostConv = result.CurInsuranceCostConv
            CurLocFrtCost = result.CurLocFrtCost
            CurLocFrtCostConv = result.CurLocFrtCostConv
            CommCode = result.CommCode
            Origin = result.Origin
            UnitWeight = result.UnitWeight
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            ItemExists = result.ItemExists
            SupplQtyReq = result.SupplQtyReq
            SupplQtyConvFactor = result.SupplQtyConvFactor
            PromptMsg = result.PromptMsg
            Infobar = result.Infobar
            LotTracked = result.LotTracked
            PreassignLots = result.PreassignLots
            PreassignSerials = result.PreassignSerials
            LotPrefix = result.LotPrefix
            SerialPrefix = result.SerialPrefix
            IsOpenNonInvForm = result.IsOpenNonInvForm
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ObsSlowSp(ByVal Item As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal WarnIfSlowMoving As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ErrorIfSlowMoving As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal WarnIfObsolete As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal ErrorIfObsolete As Byte?, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String,
<[Optional]> ByVal Site As String) As Integer
        Dim iObsSlowExt As IObsSlow = New ObsSlowFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iObsSlowExt.ObsSlowSp(Item, WarnIfSlowMoving, ErrorIfSlowMoving, WarnIfObsolete, ErrorIfObsolete, Infobar, Prompt, PromptButtons, Site)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Prompt = result.Prompt
        PromptButtons = result.PromptButtons
        Return Severity
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function AU_CLM_GetCoLineAndBlanketSp(ByVal CoNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAU_CLM_GetCoLineAndBlanketExt As IAU_CLM_GetCoLineAndBlanket = New AU_CLM_GetCoLineAndBlanketFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iAU_CLM_GetCoLineAndBlanketExt.AU_CLM_GetCoLineAndBlanketSp(CoNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AU_RepriceCoitemorBlanketLinesSp(ByVal LineorBlanketLine As Byte?, ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal NewPrice As Decimal?, ByVal RecordDate As DateTime?,
<[Optional]> ByVal SessionID As Guid?,
<[Optional]> ByVal ReasonText As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iAU_RepriceCoitemorBlanketLinesExt As IAU_RepriceCoitemorBlanketLines = New AU_RepriceCoitemorBlanketLinesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAU_RepriceCoitemorBlanketLinesExt.AU_RepriceCoitemorBlanketLinesSp(LineorBlanketLine, CoNum, CoLine, CoRelease, NewPrice, RecordDate, SessionID, ReasonText, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CanConfigureItemSp(ByVal IpcItem As String, ByRef OplConfigureItem As Integer?, ByRef OplConfigureDone As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCanConfigureItemExt As ICanConfigureItem = New CanConfigureItemFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OplConfigureItem As Integer?, OplConfigureDone As Integer?) = iCanConfigureItemExt.CanConfigureItemSp(IpcItem, OplConfigureItem, OplConfigureDone)
            Dim Severity As Integer = result.ReturnCode.Value
            OplConfigureItem = result.OplConfigureItem
            OplConfigureDone = result.OplConfigureDone
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckPrcRecordSp(ByVal item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCheckPrcRecordExt As ICheckPrcRecord = New CheckPrcRecordFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckPrcRecordExt.CheckPrcRecordSp(item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CitemXPreSp(ByVal SourceFile As String, ByVal SourceRefType As String, ByVal SourceRefNum As String, ByVal SourceRefLineSuf As Short?, ByVal SourceRefRelease As Short?, ByVal SourceItem As String, ByVal PDueDate As DateTime?, ByRef RefNum As String, ByRef FromSite As String, ByRef ParmSite As String, ByRef PoChangeOrd As Integer?, ByRef PromptMsg1 As String, ByRef PromptButtons1 As String, ByRef PromptMsg2 As String, ByRef PromptButtons2 As String, ByRef PromptMsg3 As String, ByRef PromptButtons3 As String, ByRef PromptMsg4 As String, ByRef PromptButtons4 As String, ByRef PromptMsg5 As String, ByRef PromptButtons5 As String, ByRef Infobar As String,
<[Optional]> ByRef FromWhse As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCitemXPreExt As ICitemXPre = New CitemXPreFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RefNum As String, FromSite As String, ParmSite As String, PoChangeOrd As Integer?, PromptMsg1 As String, PromptButtons1 As String, PromptMsg2 As String, PromptButtons2 As String, PromptMsg3 As String, PromptButtons3 As String, PromptMsg4 As String, PromptButtons4 As String, PromptMsg5 As String, PromptButtons5 As String, Infobar As String, FromWhse As String) = iCitemXPreExt.CitemXPreSp(SourceFile, SourceRefType, SourceRefNum, SourceRefLineSuf, SourceRefRelease, SourceItem, PDueDate, RefNum, FromSite, ParmSite, PoChangeOrd, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, PromptMsg3, PromptButtons3, PromptMsg4, PromptButtons4, PromptMsg5, PromptButtons5, Infobar, FromWhse)
            Dim Severity As Integer = result.ReturnCode.Value
            RefNum = result.RefNum
            FromSite = result.FromSite
            ParmSite = result.ParmSite
            PoChangeOrd = result.PoChangeOrd
            PromptMsg1 = result.PromptMsg1
            PromptButtons1 = result.PromptButtons1
            PromptMsg2 = result.PromptMsg2
            PromptButtons2 = result.PromptButtons2
            PromptMsg3 = result.PromptMsg3
            PromptButtons3 = result.PromptButtons3
            PromptMsg4 = result.PromptMsg4
            PromptButtons4 = result.PromptButtons4
            PromptMsg5 = result.PromptMsg5
            PromptButtons5 = result.PromptButtons5
            Infobar = result.Infobar
            FromWhse = result.FromWhse
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ContainerItemsForCompareCoLine(ByVal CoNum As String, ByVal ContainerNum As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ContainerItemsForCompareCoLineExt As ICLM_ContainerItemsForCompareCoLine = New CLM_ContainerItemsForCompareCoLineFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_ContainerItemsForCompareCoLineExt.CLM_ContainerItemsForCompareCoLineSp(CoNum, ContainerNum, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_CustomerOrderPriceHistorySp(ByVal CustNum As String, ByVal Item As String, ByVal FilterString As String,
    <[Optional]> ByVal PSiteGroup As String) As DataTable
        Dim iCLM_CustomerOrderPriceHistoryExt As ICLM_CustomerOrderPriceHistory = New CLM_CustomerOrderPriceHistoryFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_CustomerOrderPriceHistoryExt.CLM_CustomerOrderPriceHistorySp(CustNum, Item, FilterString, PSiteGroup)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetCOLinesmobiSp(ByVal CoNum As String, ByVal SiteRef As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetCOLinesmobiExt As ICLM_GetCOLinesmobi = New CLM_GetCOLinesmobiFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetCOLinesmobiExt.CLM_GetCOLinesmobiSp(CoNum, SiteRef, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_InvalidDueDateOrdersSp(ByVal OrderType As String, ByVal Status As String, ByVal StartOrderNum As String, ByVal EndOrderNum As String, ByVal StartLine As Short?, ByVal EndLine As Short?, ByVal StartRelease As Short?, ByVal EndRelease As Short?, ByVal StartCustomer As String, ByVal EndCustomer As String, ByVal StartOrderDate As DateTime?, ByVal EndOrderDate As DateTime?, ByVal StartReleaseDate As DateTime?, ByVal EndReleaseDate As DateTime?, ByVal StartDueDate As DateTime?, ByVal EndDueDate As DateTime?, ByVal IsForward As Byte?, ByVal Site As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_InvalidDueDateOrdersExt As ICLM_InvalidDueDateOrders = New CLM_InvalidDueDateOrdersFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_InvalidDueDateOrdersExt.CLM_InvalidDueDateOrdersSp(OrderType, Status, StartOrderNum, EndOrderNum, StartLine, EndLine, StartRelease, EndRelease, StartCustomer, EndCustomer, StartOrderDate, EndOrderDate, StartReleaseDate, EndReleaseDate, StartDueDate, EndDueDate, IsForward, Site)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PortalOrderSp(ByVal CoNum As String, ByVal LocaleID As Integer?, ByVal ResellerCustNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_PortalOrderExt As ICLM_PortalOrder = New CLM_PortalOrderFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_PortalOrderExt.CLM_PortalOrderSp(CoNum, LocaleID, ResellerCustNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PricePromotionsSp(
<[Optional]> ByVal PCoNum As String,
<[Optional]> ByVal PWhse As String,
<[Optional]> ByVal PItem As String,
<[Optional]> ByVal PCoOrderDate As DateTime?,
<[Optional]> ByVal PromotionCode As String, ByRef Infobar As String,
<[Optional]> ByVal CustNum As String,
<[Optional]> ByVal CustSeq As Integer?,
<[Optional]> ByVal Slsman As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal FIP As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_PricePromotionsExt As ICLM_PricePromotions = New CLM_PricePromotionsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_PricePromotionsExt.CLM_PricePromotionsSp(PCoNum, PWhse, PItem, PCoOrderDate, PromotionCode, Infobar, CustNum, CustSeq, Slsman, FIP)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoDuePerSp(ByVal PItem As String, ByVal PCustNum As String, ByRef PDuePeriod As Integer?, ByVal CustItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoDuePerExt As ICoDuePer = New CoDuePerFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PDuePeriod As Integer?) = iCoDuePerExt.CoDuePerSp(PItem, PCustNum, PDuePeriod, CustItem)
            Dim Severity As Integer = result.ReturnCode.Value
            PDuePeriod = result.PDuePeriod
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemPostSaveSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemPostSaveExt As ICoitemPostSave = New CoitemPostSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoitemPostSaveExt.CoitemPostSaveSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemSavePreProcSp(
    <[Optional], DefaultParameterValue(CByte(0))> ByVal ItemCustAdd As Byte?,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal ItemCustUpdate As Byte?,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal AllowOverCreditLimit As Byte?, ByVal CoNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemSavePreProcExt As ICoitemSavePreProc = New CoitemSavePreProcFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCoitemSavePreProcExt.CoitemSavePreProcSp(ItemCustAdd, ItemCustUpdate, AllowOverCreditLimit, CoNum)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemSetGloVarSp(
    <[Optional], DefaultParameterValue(CByte(0))> ByVal ItemCustAdd As Byte?,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal ItemCustUpdate As Byte?,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal AllowOverCreditLimit As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemSetGloVarExt As ICoitemSetGloVar = New CoitemSetGloVarFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCoitemSetGloVarExt.CoitemSetGloVarSp(ItemCustAdd, ItemCustUpdate, AllowOverCreditLimit)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemValidateItemSp(ByVal NewRecord As Integer?, ByVal CoNum As String, ByVal CoType As String, ByVal OrderDate As DateTime?, ByVal Item As String, ByVal OldItem As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal QtyOrderedConv As Decimal?, ByVal ItemPriceCode As String, ByVal CurrCode As String, ByRef ShipSite As String, ByRef ItemItem As String, ByRef ItemUM As String, ByRef ItemDesc As String, ByRef CustItem As String, ByRef Price As Decimal?, ByRef FeatStr As String, ByRef ItemPlanFlag As Integer?, ByRef ItemFeatTempl As String, ByRef ItemCommCode As String, ByRef ItemUnitWeight As Decimal?, ByRef ItemOrigin As String, ByRef DueDate As DateTime?, ByRef RefType As String, ByRef RefNum As String, ByRef RefLineSuf As Integer?, ByRef RefRelease As Integer?, ByRef TaxCode1 As String, ByRef TaxCode1Desc As String, ByRef TaxCode2 As String, ByRef TaxCode2Desc As String, ByRef DiscPct As Decimal?, ByRef Infobar As String, ByVal CoLine As Integer?, ByRef SupplQtyReq As Integer?, ByRef SupplQtyConvFactor As Decimal?, ByRef Kit As Integer?, ByRef PrintKitComponents As Integer?, ByRef ItemReservable As Integer?,
<[Optional], DefaultParameterValue(0)> ByRef ItemSerialTracked As Integer?,
<[Optional], DefaultParameterValue(0)> ByRef ItemOrderConfigurable As Integer?,
 <[Optional], DefaultParameterValue(0)> ByRef AllowOnPickList As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemValidateItemExt As ICoitemValidateItem = New CoitemValidateItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ShipSite As String, ItemItem As String, ItemUM As String, ItemDesc As String, CustItem As String, Price As Decimal?, FeatStr As String, ItemPlanFlag As Integer?, ItemFeatTempl As String, ItemCommCode As String, ItemUnitWeight As Decimal?, ItemOrigin As String, DueDate As DateTime?, RefType As String, RefNum As String, RefLineSuf As Integer?, RefRelease As Integer?, TaxCode1 As String, TaxCode1Desc As String, TaxCode2 As String, TaxCode2Desc As String, DiscPct As Decimal?, Infobar As String, SupplQtyReq As Integer?, SupplQtyConvFactor As Decimal?, Kit As Integer?, PrintKitComponents As Integer?, ItemReservable As Integer?, ItemSerialTracked As Integer?, ItemOrderConfigurable As Integer?, AllowOnPickList As Integer?) = iCoitemValidateItemExt.CoitemValidateItemSp(NewRecord, CoNum, CoType, OrderDate, Item, OldItem, CustNum, CustSeq, QtyOrderedConv, ItemPriceCode, CurrCode, ShipSite, ItemItem, ItemUM, ItemDesc, CustItem, Price, FeatStr, ItemPlanFlag, ItemFeatTempl, ItemCommCode, ItemUnitWeight, ItemOrigin, DueDate, RefType, RefNum, RefLineSuf, RefRelease, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, DiscPct, Infobar, CoLine, SupplQtyReq, SupplQtyConvFactor, Kit, PrintKitComponents, ItemReservable, ItemSerialTracked, ItemOrderConfigurable, AllowOnPickList)
            Dim Severity As Integer = result.ReturnCode.Value
            ShipSite = result.ShipSite
            ItemItem = result.ItemItem
            ItemUM = result.ItemUM
            ItemDesc = result.ItemDesc
            CustItem = result.CustItem
            Price = result.Price
            FeatStr = result.FeatStr
            ItemPlanFlag = result.ItemPlanFlag
            ItemFeatTempl = result.ItemFeatTempl
            ItemCommCode = result.ItemCommCode
            ItemUnitWeight = result.ItemUnitWeight
            ItemOrigin = result.ItemOrigin
            DueDate = result.DueDate
            RefType = result.RefType
            RefNum = result.RefNum
            RefLineSuf = result.RefLineSuf
            RefRelease = result.RefRelease
            TaxCode1 = result.TaxCode1
            TaxCode1Desc = result.TaxCode1Desc
            TaxCode2 = result.TaxCode2
            TaxCode2Desc = result.TaxCode2Desc
            DiscPct = result.DiscPct
            Infobar = result.Infobar
            SupplQtyReq = result.SupplQtyReq
            SupplQtyConvFactor = result.SupplQtyConvFactor
            Kit = result.Kit
            PrintKitComponents = result.PrintKitComponents
            ItemReservable = result.ItemReservable
            ItemSerialTracked = result.ItemSerialTracked
            ItemOrderConfigurable = result.ItemOrderConfigurable
            AllowOnPickList = result.AllowOnPickList
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemValidateQtyOrderedSp(ByVal NewRecord As Byte?, ByVal CoNum As String, ByVal CoLine As Short?, ByVal Item As String, ByVal UM As String, ByVal CoCustNum As String, ByVal CurrCode As String, ByVal ItemPriceCode As String, ByVal QtyOrderedConv As Decimal?, ByVal CustItem As String, ByVal ShipSite As String, ByVal CoOrderDate As DateTime?, ByVal Whse As String, ByVal RefType As String, ByVal Price As Decimal?, ByRef QtyReady As Decimal?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByRef DispMsg As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemValidateQtyOrderedExt As ICoitemValidateQtyOrdered = New CoitemValidateQtyOrderedFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, QtyReady As Decimal?, Infobar As String, DispMsg As Integer?) = iCoitemValidateQtyOrderedExt.CoitemValidateQtyOrderedSp(NewRecord, CoNum, CoLine, Item, UM, CoCustNum, CurrCode, ItemPriceCode, QtyOrderedConv, CustItem, ShipSite, CoOrderDate, Whse, RefType, Price, QtyReady, Infobar, DispMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            QtyReady = result.QtyReady
            Infobar = result.Infobar
            DispMsg = result.DispMsg
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemValidateStatusSp(ByVal PCoNum As String, ByVal PCoLine As Integer?, ByVal POldQtyShipped As Decimal?, ByVal POldQtyRsvd As Decimal?, ByVal POldQtyInvoiced As Decimal?, ByVal PCoStat As String, ByVal POldStatus As String, ByVal PNewStatus As String, ByRef Infobar As String,
<[Optional]> ByVal PlacesQtyUnit As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemValidateStatusExt As ICoitemValidateStatus = New CoitemValidateStatusFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoitemValidateStatusExt.CoitemValidateStatusSp(PCoNum, PCoLine, POldQtyShipped, POldQtyRsvd, POldQtyInvoiced, PCoStat, POldStatus, PNewStatus, Infobar, PlacesQtyUnit)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitmCdSp(ByVal CoNum As String, ByVal CoLine As Integer?, ByVal CoRelease As Integer?,
<[Optional]> ByVal Stat As String,
<[Optional]> ByVal QtyOrdered As Decimal?,
<[Optional]> ByVal QtyShipped As Decimal?,
<[Optional]> ByVal QtyReturned As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal ShipSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoitmCdExt As ICoitmCd = New CoitmCdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoitmCdExt.CoitmCdSp(CoNum, CoLine, CoRelease, Stat, QtyOrdered, QtyShipped, QtyReturned, Infobar, ShipSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CoPackingSlipLoadSp(ByVal TPckCall As String, ByVal CoNum As String, ByVal CustNum As String, ByVal CoitemCustNum As String, ByVal CoitemCustSeq As Integer?, ByVal Whse As String, ByVal FromCoLine As Short?, ByVal ToCoLine As Short?, ByVal FromCoRelease As Short?, ByVal ToCoRelease As Short?, ByVal FromDate As DateTime?, ByVal ToDate As DateTime?, ByVal Stat As String,
<[Optional]> ByVal BatchId As Integer?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoPackingSlipLoadExt As ICoPackingSlipLoad = New CoPackingSlipLoadFactory().Create(appDb, bunchedLoadCollection, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCoPackingSlipLoadExt.CoPackingSlipLoadSp(TPckCall, CoNum, CustNum, CoitemCustNum, CoitemCustSeq, Whse, FromCoLine, ToCoLine, FromCoRelease, ToCoRelease, FromDate, ToDate, Stat, BatchId, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateCoPckItemSp(ByVal PackNum As Integer?, ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal Item As String, ByVal UM As String, ByVal PackQty As Decimal?, ByVal ProcessId As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCreateCoPckItemExt As ICreateCoPckItem = New CreateCoPckItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCreateCoPckItemExt.CreateCoPckItemSp(PackNum, CoNum, CoLine, CoRelease, Item, UM, PackQty, ProcessId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerDefaultShipSiteSp(
<[Optional]> ByVal Co_Num As String,
<[Optional]> ByVal Co_Type As String,
<[Optional]> ByVal Co_Line As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustomerDefaultShipSiteExt As ICustomerDefaultShipSite = New CustomerDefaultShipSiteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCustomerDefaultShipSiteExt.CustomerDefaultShipSiteSp(Co_Num, Co_Type, Co_Line)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustOrderLinesFormDefaultsSp(ByVal CoNum As String, ByRef ShipSite As String, ByRef Stat As String, ByRef Item As String, ByRef UM As String, ByRef QtyOrderedConv As Decimal?, ByRef DueDate As DateTime?, ByRef Price As Decimal?, ByRef PriceConv As Decimal?, ByRef CustItem As String, ByRef TransNat As String, ByRef TrnDesc As String, ByRef TransNat2 As String, ByRef Trn2Desc As String, ByRef Delterm As String, ByRef DeltermDesc As String, ByRef ProcessInd As String, ByRef EcCode As String, ByRef Origin As String, ByRef CommCode As String, ByRef SupplQty As Decimal?, ByRef ExportValue As Decimal?, ByRef CustNum As String, ByRef CustSeq As Integer?, ByRef Whse As String, ByRef Pricecode As String, ByRef CoOrigSite As String, ByRef Reprice As Integer?, ByRef Consolidate As Integer?, ByRef Summarize As Integer?, ByRef InvFreq As String, ByRef RefType As String, ByRef Transport As String, ByRef TaxCode1 As String, ByRef TaxCode1Desc As String, ByRef TaxCode2 As String, ByRef TaxCode2Desc As String, ByRef CurrCode As String, ByRef CurrAmtFormat As String, ByRef CurrCstPrcFormat As String, ByRef SupplQtyReq As Integer?, ByRef SupplQtyConvFactor As Decimal?, ByRef CoStat As String, ByRef Infobar As String,
<[Optional]> ByRef ExpDate As DateTime?,
<[Optional]> ByRef EUCode As String,
<[Optional]> ByRef TaxCode1Type As String,
<[Optional]> ByRef TaxRegNum1 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustOrderLinesFormDefaultsExt As ICustOrderLinesFormDefaults = New CustOrderLinesFormDefaultsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ShipSite As String, Stat As String, Item As String, UM As String, QtyOrderedConv As Decimal?, DueDate As DateTime?, Price As Decimal?, PriceConv As Decimal?, CustItem As String, TransNat As String, TrnDesc As String, TransNat2 As String, Trn2Desc As String, Delterm As String, DeltermDesc As String, ProcessInd As String, EcCode As String, Origin As String, CommCode As String, SupplQty As Decimal?, ExportValue As Decimal?, CustNum As String, CustSeq As Integer?, Whse As String, Pricecode As String, CoOrigSite As String, Reprice As Integer?, Consolidate As Integer?, Summarize As Integer?, InvFreq As String, RefType As String, Transport As String, TaxCode1 As String, TaxCode1Desc As String, TaxCode2 As String, TaxCode2Desc As String, CurrCode As String, CurrAmtFormat As String, CurrCstPrcFormat As String, SupplQtyReq As Integer?, SupplQtyConvFactor As Decimal?, CoStat As String, Infobar As String, ExpDate As DateTime?, EUCode As String, TaxCode1Type As String, TaxRegNum1 As String) = iCustOrderLinesFormDefaultsExt.CustOrderLinesFormDefaultsSp(CoNum, ShipSite, Stat, Item, UM, QtyOrderedConv, DueDate, Price, PriceConv, CustItem, TransNat, TrnDesc, TransNat2, Trn2Desc, Delterm, DeltermDesc, ProcessInd, EcCode, Origin, CommCode, SupplQty, ExportValue, CustNum, CustSeq, Whse, Pricecode, CoOrigSite, Reprice, Consolidate, Summarize, InvFreq, RefType, Transport, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, CurrCode, CurrAmtFormat, CurrCstPrcFormat, SupplQtyReq, SupplQtyConvFactor, CoStat, Infobar, ExpDate, EUCode, TaxCode1Type, TaxRegNum1)
            Dim Severity As Integer = result.ReturnCode.Value
            ShipSite = result.ShipSite
            Stat = result.Stat
            Item = result.Item
            UM = result.UM
            QtyOrderedConv = result.QtyOrderedConv
            DueDate = result.DueDate
            Price = result.Price
            PriceConv = result.PriceConv
            CustItem = result.CustItem
            TransNat = result.TransNat
            TrnDesc = result.TrnDesc
            TransNat2 = result.TransNat2
            Trn2Desc = result.Trn2Desc
            Delterm = result.Delterm
            DeltermDesc = result.DeltermDesc
            ProcessInd = result.ProcessInd
            EcCode = result.EcCode
            Origin = result.Origin
            CommCode = result.CommCode
            SupplQty = result.SupplQty
            ExportValue = result.ExportValue
            CustNum = result.CustNum
            CustSeq = result.CustSeq
            Whse = result.Whse
            Pricecode = result.Pricecode
            CoOrigSite = result.CoOrigSite
            Reprice = result.Reprice
            Consolidate = result.Consolidate
            Summarize = result.Summarize
            InvFreq = result.InvFreq
            RefType = result.RefType
            Transport = result.Transport
            TaxCode1 = result.TaxCode1
            TaxCode1Desc = result.TaxCode1Desc
            TaxCode2 = result.TaxCode2
            TaxCode2Desc = result.TaxCode2Desc
            CurrCode = result.CurrCode
            CurrAmtFormat = result.CurrAmtFormat
            CurrCstPrcFormat = result.CurrCstPrcFormat
            SupplQtyReq = result.SupplQtyReq
            SupplQtyConvFactor = result.SupplQtyConvFactor
            CoStat = result.CoStat
            Infobar = result.Infobar
            ExpDate = result.ExpDate
            EUCode = result.EUCode
            TaxCode1Type = result.TaxCode1Type
            TaxRegNum1 = result.TaxRegNum1
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DefaultDiscSp(ByVal Item As String, ByVal CustNum As String, ByVal CustType As String, ByRef Disc As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDefaultDiscExt As IDefaultDisc = New DefaultDiscFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Disc As Decimal?) = iDefaultDiscExt.DefaultDiscSp(Item, CustNum, CustType, Disc)
            Dim Severity As Integer = result.ReturnCode.Value
            Disc = result.Disc
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesCanEnableUMSp(ByVal PItem As String, ByRef PEnableUM As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesCanEnableUMExt As IEstimateLinesCanEnableUM = New EstimateLinesCanEnableUMFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PEnableUM As Integer?) = iEstimateLinesCanEnableUMExt.EstimateLinesCanEnableUMSp(PItem, PEnableUM)
            Dim Severity As Integer = result.ReturnCode.Value
            PEnableUM = result.PEnableUM
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesEstDuePeriodSp(ByVal PItem As String, ByVal PCustNum As String, ByRef PDuePeriod As Integer?, ByVal CustItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesEstDuePeriodExt As IEstimateLinesEstDuePeriod = New EstimateLinesEstDuePeriodFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PDuePeriod As Integer?) = iEstimateLinesEstDuePeriodExt.EstimateLinesEstDuePeriodSp(PItem, PCustNum, PDuePeriod, CustItem)
            Dim Severity As Integer = result.ReturnCode.Value
            PDuePeriod = result.PDuePeriod
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesGetExtAmtsSp(ByVal PEstNum As String, ByVal PQtyOrdered As Decimal?, ByVal PPriceConv As Decimal?, ByVal PDisc As Decimal?, ByVal PCostConv As Decimal?, ByRef TcAmtExtPrice As Decimal?, ByRef TcAmtNetPrice As Decimal?, ByRef TcAmtTotCost As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesGetExtAmtsExt As IEstimateLinesGetExtAmts = New EstimateLinesGetExtAmtsFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TcAmtExtPrice As Decimal?, TcAmtNetPrice As Decimal?, TcAmtTotCost As Decimal?, Infobar As String) = iEstimateLinesGetExtAmtsExt.EstimateLinesGetExtAmtsSp(PEstNum, PQtyOrdered, PPriceConv, PDisc, PCostConv, TcAmtExtPrice, TcAmtNetPrice, TcAmtTotCost, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TcAmtExtPrice = result.TcAmtExtPrice
            TcAmtNetPrice = result.TcAmtNetPrice
            TcAmtTotCost = result.TcAmtTotCost
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesValidateAllItemSp(ByRef PItem As String, ByVal PCoNum As String, ByVal PCoLine As Integer?, ByVal PCoRelease As Integer?, ByVal PCustNum As String, ByVal PQtyOrdered As Decimal?, ByRef PUM As String, ByRef PDisc As Decimal?, ByRef PCustItem As String, ByRef PItemDesc As String, ByRef PRefType As String, ByRef PRefNum As String, ByRef PRefLineSuf As Integer?, ByRef PRefRelease As Integer?, ByRef PRepriceChecked As Integer?, ByRef PTaxCode1 As String, ByRef PTaxCode2 As String, ByRef ItemFeatStr As String, ByRef PCostConv As Decimal?, ByRef PStocked As Integer?, ByRef PNoChange As Integer?, ByRef PProdCfg As Integer?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef PTotCost As Decimal?, ByRef ItemFeatTempl As String, ByRef PItemSerialTracked As Integer?, ByRef PItemExists As Integer?,
        <[Optional], DefaultParameterValue(1)> ByVal WarnIfSlowMoving As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal ErrorIfSlowMoving As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal WarnIfObsolete As Integer?,
        <[Optional], DefaultParameterValue(1)> ByVal ErrorIfObsolete As Integer?, ByRef Infobar As String,
        <[Optional]> ByRef Prompt As String,
        <[Optional]> ByRef PromptButtons As String,
        <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesValidateAllItemExt As IEstimateLinesValidateAllItem = New EstimateLinesValidateAllItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PItem As String, PUM As String, PDisc As Decimal?, PCustItem As String, PItemDesc As String, PRefType As String, PRefNum As String, PRefLineSuf As Integer?, PRefRelease As Integer?, PRepriceChecked As Integer?, PTaxCode1 As String, PTaxCode2 As String, ItemFeatStr As String, PCostConv As Decimal?, PStocked As Integer?, PNoChange As Integer?, PProdCfg As Integer?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, PTotCost As Decimal?, ItemFeatTempl As String, PItemSerialTracked As Integer?, PItemExists As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iEstimateLinesValidateAllItemExt.EstimateLinesValidateAllItemSp(PItem, PCoNum, PCoLine, PCoRelease, PCustNum, PQtyOrdered, PUM, PDisc, PCustItem, PItemDesc, PRefType, PRefNum, PRefLineSuf, PRefRelease, PRepriceChecked, PTaxCode1, PTaxCode2, ItemFeatStr, PCostConv, PStocked, PNoChange, PProdCfg, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, ItemFeatTempl, PItemSerialTracked, PItemExists, WarnIfSlowMoving, ErrorIfSlowMoving, WarnIfObsolete, ErrorIfObsolete, Infobar, Prompt, PromptButtons, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            PItem = result.PItem
            PUM = result.PUM
            PDisc = result.PDisc
            PCustItem = result.PCustItem
            PItemDesc = result.PItemDesc
            PRefType = result.PRefType
            PRefNum = result.PRefNum
            PRefLineSuf = result.PRefLineSuf
            PRefRelease = result.PRefRelease
            PRepriceChecked = result.PRepriceChecked
            PTaxCode1 = result.PTaxCode1
            PTaxCode2 = result.PTaxCode2
            ItemFeatStr = result.ItemFeatStr
            PCostConv = result.PCostConv
            PStocked = result.PStocked
            PNoChange = result.PNoChange
            PProdCfg = result.PProdCfg
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            PTotCost = result.PTotCost
            ItemFeatTempl = result.ItemFeatTempl
            PItemSerialTracked = result.PItemSerialTracked
            PItemExists = result.PItemExists
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesValidateItemSp(ByRef PItem As String, ByVal PCoNum As String, ByVal PCoLine As Integer?, ByVal PCoRelease As Integer?, ByVal PCustNum As String, ByVal PQtyOrdered As Decimal?, ByRef PUM As String, ByRef PDisc As Decimal?, ByRef PCustItem As String, ByRef PItemDesc As String, ByRef PRefType As String, ByRef PRefNum As String, ByRef PRefLineSuf As Integer?, ByRef PRefRelease As Integer?, ByRef PRepriceChecked As Integer?, ByRef PTaxCode1 As String, ByRef PTaxCode2 As String, ByRef ItemFeatStr As String, ByRef PCostConv As Decimal?, ByRef PStocked As Integer?, ByRef PNoChange As Integer?, ByRef PProdCfg As Integer?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef PTotCost As Decimal?, ByRef ItemFeatTempl As String, ByRef PItemSerialTracked As Integer?, ByRef PItemExists As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstimateLinesValidateItemExt As IEstimateLinesValidateItem = New EstimateLinesValidateItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PItem As String, PUM As String, PDisc As Decimal?, PCustItem As String, PItemDesc As String, PRefType As String, PRefNum As String, PRefLineSuf As Integer?, PRefRelease As Integer?, PRepriceChecked As Integer?, PTaxCode1 As String, PTaxCode2 As String, ItemFeatStr As String, PCostConv As Decimal?, PStocked As Integer?, PNoChange As Integer?, PProdCfg As Integer?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, PTotCost As Decimal?, ItemFeatTempl As String, PItemSerialTracked As Integer?, PItemExists As Integer?, Infobar As String) = iEstimateLinesValidateItemExt.EstimateLinesValidateItemSp(PItem, PCoNum, PCoLine, PCoRelease, PCustNum, PQtyOrdered, PUM, PDisc, PCustItem, PItemDesc, PRefType, PRefNum, PRefLineSuf, PRefRelease, PRepriceChecked, PTaxCode1, PTaxCode2, ItemFeatStr, PCostConv, PStocked, PNoChange, PProdCfg, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, ItemFeatTempl, PItemSerialTracked, PItemExists, Infobar)

            Dim Severity As Integer = result.ReturnCode.Value
            PItem = result.PItem
            PUM = result.PUM
            PDisc = result.PDisc
            PCustItem = result.PCustItem
            PItemDesc = result.PItemDesc
            PRefType = result.PRefType
            PRefNum = result.PRefNum
            PRefLineSuf = result.PRefLineSuf
            PRefRelease = result.PRefRelease
            PRepriceChecked = result.PRepriceChecked
            PTaxCode1 = result.PTaxCode1
            PTaxCode2 = result.PTaxCode2
            ItemFeatStr = result.ItemFeatStr
            PCostConv = result.PCostConv
            PStocked = result.PStocked
            PNoChange = result.PNoChange
            PProdCfg = result.PProdCfg
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            PTotCost = result.PTotCost
            ItemFeatTempl = result.ItemFeatTempl
            PItemSerialTracked = result.PItemSerialTracked
            PItemExists = result.PItemExists
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstItemXrefSp(ByVal EstNum As String, ByVal EstLine As Integer?, ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Integer?, ByVal RefRelease As Integer?, ByVal Item As String, ByVal QtyOrdered As Decimal?, ByVal DueDate As DateTime?, ByVal Whse As String,
        <[Optional], DefaultParameterValue(0)> ByVal MpwxrefDelete As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal CreateProj As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal CreateProjtask As Integer?, ByRef CurRefNum As String, ByRef CurRefLineSuf As Integer?, ByRef CurRefRelease As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iEstItemXrefExt As IEstItemXref = New EstItemXrefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CurRefNum As String, CurRefLineSuf As Integer?, CurRefRelease As Integer?, Infobar As String) = iEstItemXrefExt.EstItemXrefSp(EstNum, EstLine, RefType, RefNum, RefLineSuf, RefRelease, Item, QtyOrdered, DueDate, Whse, MpwxrefDelete, CreateProj, CreateProjtask, CurRefNum, CurRefLineSuf, CurRefRelease, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CurRefNum = result.CurRefNum
            CurRefLineSuf = result.CurRefLineSuf
            CurRefRelease = result.CurRefRelease
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCoItemDetailForBlanketSp(ByVal CoNum As String, ByVal CoLine As Integer?, ByRef CoCustNum As String, ByRef CoCustName As String, ByRef CoOrderDate As DateTime?, ByRef CoItem As String, ByRef CoItemDesc As String, ByRef CoCustItem As String, ByRef CoCblBlanketQtyConv As Decimal?, ByRef CoCblUM As String, ByRef CoCblContPriceConv As Decimal?, ByRef CoCblEffDate As DateTime?, ByRef CoCblExpDate As DateTime?, ByRef CoAdrCreditHold As Integer?, ByRef CoRelease As Integer?, ByRef CoWhse As String, ByRef TaxCode1 As String, ByRef TaxCode1Desc As String, ByRef TaxCode2 As String, ByRef TaxCode2Desc As String, ByRef CoCurrCode As String, ByRef CoiTransNat As String, ByRef CoiTransNat2 As String, ByRef CoiDelterm As String, ByRef CoiProcessInd As String, ByRef CoiEcCode As String, ByRef CoiOrigin As String, ByRef CoiCommCode As String, ByRef CoiUnitWeight As Decimal?, ByRef CoiPrice As Decimal?, ByRef CurrAmtFormat As String, ByRef CurrCstPrcFormat As String, ByRef ShipSite As String, ByRef RefType As String, ByRef SupplQtyReq As Integer?, ByRef SupplQtyConvFactor As Decimal?, ByRef Infobar As String, ByRef CostConv As Decimal?, ByRef NonInventoryItem As Integer?, ByRef CoblnNonInvAcct As String, ByRef CoblnNonInvAcctUnit1 As String, ByRef CoblnNonInvAcctUnit2 As String, ByRef CoblnNonInvAcctUnit3 As String, ByRef CoblnNonInvAcctUnit4 As String, ByRef ManufacturerId As String, ByRef ManufacturerItem As String, ByRef ManufacturerItemDescription As String, ByRef ManufacturerName As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetCoItemDetailForBlanketExt As IGetCoItemDetailForBlanket = New GetCoItemDetailForBlanketFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CoCustNum As String, CoCustName As String, CoOrderDate As DateTime?, CoItem As String, CoItemDesc As String, CoCustItem As String, CoCblBlanketQtyConv As Decimal?, CoCblUM As String, CoCblContPriceConv As Decimal?, CoCblEffDate As DateTime?, CoCblExpDate As DateTime?, CoAdrCreditHold As Integer?, CoRelease As Integer?, CoWhse As String, TaxCode1 As String, TaxCode1Desc As String, TaxCode2 As String, TaxCode2Desc As String, CoCurrCode As String, CoiTransNat As String, CoiTransNat2 As String, CoiDelterm As String, CoiProcessInd As String, CoiEcCode As String, CoiOrigin As String, CoiCommCode As String, CoiUnitWeight As Decimal?, CoiPrice As Decimal?, CurrAmtFormat As String, CurrCstPrcFormat As String, ShipSite As String, RefType As String, SupplQtyReq As Integer?, SupplQtyConvFactor As Decimal?, Infobar As String, CostConv As Decimal?, NonInventoryItem As Integer?, CoblnNonInvAcct As String, CoblnNonInvAcctUnit1 As String, CoblnNonInvAcctUnit2 As String, CoblnNonInvAcctUnit3 As String, CoblnNonInvAcctUnit4 As String, ManufacturerId As String, ManufacturerItem As String, ManufacturerItemDescription As String, ManufacturerName As String) = iGetCoItemDetailForBlanketExt.GetCoItemDetailForBlanketSp(CoNum, CoLine, CoCustNum, CoCustName, CoOrderDate, CoItem, CoItemDesc, CoCustItem, CoCblBlanketQtyConv, CoCblUM, CoCblContPriceConv, CoCblEffDate, CoCblExpDate, CoAdrCreditHold, CoRelease, CoWhse, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, CoCurrCode, CoiTransNat, CoiTransNat2, CoiDelterm, CoiProcessInd, CoiEcCode, CoiOrigin, CoiCommCode, CoiUnitWeight, CoiPrice, CurrAmtFormat, CurrCstPrcFormat, ShipSite, RefType, SupplQtyReq, SupplQtyConvFactor, Infobar, CostConv, NonInventoryItem, CoblnNonInvAcct, CoblnNonInvAcctUnit1, CoblnNonInvAcctUnit2, CoblnNonInvAcctUnit3, CoblnNonInvAcctUnit4, ManufacturerId, ManufacturerItem, ManufacturerItemDescription, ManufacturerName)
            Dim Severity As Integer = result.ReturnCode.Value
            CoCustNum = result.CoCustNum
            CoCustName = result.CoCustName
            CoOrderDate = result.CoOrderDate
            CoItem = result.CoItem
            CoItemDesc = result.CoItemDesc
            CoCustItem = result.CoCustItem
            CoCblBlanketQtyConv = result.CoCblBlanketQtyConv
            CoCblUM = result.CoCblUM
            CoCblContPriceConv = result.CoCblContPriceConv
            CoCblEffDate = result.CoCblEffDate
            CoCblExpDate = result.CoCblExpDate
            CoAdrCreditHold = result.CoAdrCreditHold
            CoRelease = result.CoRelease
            CoWhse = result.CoWhse
            TaxCode1 = result.TaxCode1
            TaxCode1Desc = result.TaxCode1Desc
            TaxCode2 = result.TaxCode2
            TaxCode2Desc = result.TaxCode2Desc
            CoCurrCode = result.CoCurrCode
            CoiTransNat = result.CoiTransNat
            CoiTransNat2 = result.CoiTransNat2
            CoiDelterm = result.CoiDelterm
            CoiProcessInd = result.CoiProcessInd
            CoiEcCode = result.CoiEcCode
            CoiOrigin = result.CoiOrigin
            CoiCommCode = result.CoiCommCode
            CoiUnitWeight = result.CoiUnitWeight
            CoiPrice = result.CoiPrice
            CurrAmtFormat = result.CurrAmtFormat
            CurrCstPrcFormat = result.CurrCstPrcFormat
            ShipSite = result.ShipSite
            RefType = result.RefType
            SupplQtyReq = result.SupplQtyReq
            SupplQtyConvFactor = result.SupplQtyConvFactor
            Infobar = result.Infobar
            CostConv = result.CostConv
            NonInventoryItem = result.NonInventoryItem
            CoblnNonInvAcct = result.CoblnNonInvAcct
            CoblnNonInvAcctUnit1 = result.CoblnNonInvAcctUnit1
            CoblnNonInvAcctUnit2 = result.CoblnNonInvAcctUnit2
            CoblnNonInvAcctUnit3 = result.CoblnNonInvAcctUnit3
            CoblnNonInvAcctUnit4 = result.CoblnNonInvAcctUnit4
            ManufacturerId = result.ManufacturerId
            ManufacturerItem = result.ManufacturerItem
            ManufacturerItemDescription = result.ManufacturerItemDescription
            ManufacturerName = result.ManufacturerName
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCoitemSumOrderedQtySp(ByVal CoNum As String, ByVal CoLine As Integer?, ByRef TotalOrdered As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetCoitemSumOrderedQtyExt As IGetCoitemSumOrderedQty = New GetCoitemSumOrderedQtyFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TotalOrdered As Decimal?) = iGetCoitemSumOrderedQtyExt.GetCoitemSumOrderedQtySp(CoNum, CoLine, TotalOrdered)
            Dim Severity As Integer = result.ReturnCode.Value
            TotalOrdered = result.TotalOrdered
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCOLineParmsSp(ByVal Type As String, ByVal Type1 As String, ByVal Object1 As String, ByVal ParamSite As String, ByRef ApsParmApsmode As String, ByRef MrpParmReqSrc As String, ByRef CanDueNEProjected As Integer?, ByRef CanDueLTProjected As Integer?, ByRef SharedCustEnabled As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCOLineParmsExt As IGetCOLineParms = New GetCOLineParmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ApsParmApsmode As String, MrpParmReqSrc As String, CanDueNEProjected As Integer?, CanDueLTProjected As Integer?, SharedCustEnabled As Integer?) = iGetCOLineParmsExt.GetCOLineParmsSp(Type, Type1, Object1, ParamSite, ApsParmApsmode, MrpParmReqSrc, CanDueNEProjected, CanDueLTProjected, SharedCustEnabled)
            Dim Severity As Integer = result.ReturnCode.Value
            ApsParmApsmode = result.ApsParmApsmode
            MrpParmReqSrc = result.MrpParmReqSrc
            CanDueNEProjected = result.CanDueNEProjected
            CanDueLTProjected = result.CanDueLTProjected
            SharedCustEnabled = result.SharedCustEnabled
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCoNonInvAcctSp(ByVal CoNum As String, ByVal CustNum As String, ByVal Item As String, ByVal Whse As String, ByRef NonInvAcct As String, ByRef NonInvAcctUnit1 As String, ByRef NonInvAcctUnit2 As String, ByRef NonInvAcctUnit3 As String, ByRef NonInvAcctUnit4 As String, ByRef AccessUnit1 As String, ByRef AccessUnit2 As String, ByRef AccessUnit3 As String, ByRef AccessUnit4 As String, ByRef PostJour As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal Site As String, ByRef IsControl As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCoNonInvAcctExt As IGetCoNonInvAcct = New GetCoNonInvAcctFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, NonInvAcct As String, NonInvAcctUnit1 As String, NonInvAcctUnit2 As String, NonInvAcctUnit3 As String, NonInvAcctUnit4 As String, AccessUnit1 As String, AccessUnit2 As String, AccessUnit3 As String, AccessUnit4 As String, PostJour As Integer?, Infobar As String, IsControl As Integer?) = iGetCoNonInvAcctExt.GetCoNonInvAcctSp(CoNum, CustNum, Item, Whse, NonInvAcct, NonInvAcctUnit1, NonInvAcctUnit2, NonInvAcctUnit3, NonInvAcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, PostJour, Infobar, Site, IsControl)
            Dim Severity As Integer = result.ReturnCode.Value
            NonInvAcct = result.NonInvAcct
            NonInvAcctUnit1 = result.NonInvAcctUnit1
            NonInvAcctUnit2 = result.NonInvAcctUnit2
            NonInvAcctUnit3 = result.NonInvAcctUnit3
            NonInvAcctUnit4 = result.NonInvAcctUnit4
            AccessUnit1 = result.AccessUnit1
            AccessUnit2 = result.AccessUnit2
            AccessUnit3 = result.AccessUnit3
            AccessUnit4 = result.AccessUnit4
            PostJour = result.PostJour
            Infobar = result.Infobar
            IsControl = result.IsControl
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustDefaultShipSiteSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal CoLcrNum As String, ByRef ShipSite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCustDefaultShipSiteExt As IGetCustDefaultShipSite = New GetCustDefaultShipSiteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ShipSite As String, Infobar As String) = iGetCustDefaultShipSiteExt.GetCustDefaultShipSiteSp(CustNum, CustSeq, CoLcrNum, ShipSite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ShipSite = result.ShipSite
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerOrderLinesStdFormPredisplaySp(ByRef PostJour As Byte?, ByVal Type As String, ByVal Type1 As String, ByVal obj As String, ByVal ParamSite As String, ByRef ApsParmApsmode As String, ByRef MrpParmReqSrc As String, ByRef CanDueNEProjected As Byte?, ByRef CanDueLTProjected As Byte?, ByRef SharedCustEnabled As Byte?, ByRef PUseAltPriceCalc As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCoLinePlanAndPriceParmsExt As IGetCoLinePlanAndPriceParms = New GetCoLinePlanAndPriceParmsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PostJour As Byte?, ApsParmApsmode As String, MrpParmReqSrc As String, CanDueNEProjected As Byte?, CanDueLTProjected As Byte?, SharedCustEnabled As Byte?, PUseAltPriceCalc As Byte?) = iGetCoLinePlanAndPriceParmsExt.GetCoLinePlanAndPriceParmsSp(PostJour, Type, Type1, obj, ParamSite, ApsParmApsmode, MrpParmReqSrc, CanDueNEProjected, CanDueLTProjected, SharedCustEnabled, PUseAltPriceCalc)
            Dim Severity As Integer = result.ReturnCode.Value
            PostJour = result.PostJour
            ApsParmApsmode = result.ApsParmApsmode
            MrpParmReqSrc = result.MrpParmReqSrc
            CanDueNEProjected = result.CanDueNEProjected
            CanDueLTProjected = result.CanDueLTProjected
            SharedCustEnabled = result.SharedCustEnabled
            PUseAltPriceCalc = result.PUseAltPriceCalc
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
    Public Function GetEcvtItemSp(ByVal Item As String, ByRef CommCode As String, ByRef UnitWeight As Decimal?, ByRef Origin As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetEcvtItemExt As IGetEcvtItem = New GetEcvtItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CommCode As String, UnitWeight As Decimal?, Origin As String) = iGetEcvtItemExt.GetEcvtItemSp(Item, CommCode, UnitWeight, Origin)
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemCustDuePeriodSp(ByVal CustNum As String, ByVal Item As String, ByRef IcDuePeriod As Integer?, ByVal CustItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemCustDuePeriodExt As IGetItemCustDuePeriod = New GetItemCustDuePeriodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, IcDuePeriod As Integer?) = iGetItemCustDuePeriodExt.GetItemCustDuePeriodSp(CustNum, Item, IcDuePeriod, CustItem)
            Dim Severity As Integer = result.ReturnCode.Value
            IcDuePeriod = result.IcDuePeriod
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemPriceAndCostSp(ByVal PItem As String, ByVal PCustNum As String, ByVal PUM As String, ByVal PCurrCode As String, ByVal PRate As Decimal?, ByVal PReprice As Byte?, ByVal PQtyOrdered As Decimal?, ByVal POrderDate As DateTime?, ByVal PPriceCode As String, ByVal PFeatStr As String, ByRef PUnitPrice As Decimal?, ByRef PUnitCost As Decimal?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef Infobar As String, ByVal PCoNum As String, ByVal PCoLine As Short?, ByVal PCustItem As String,
<[Optional], DefaultParameterValue(0)> ByRef LineDisc As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemPriceAndCostExt As IGetItemPriceAndCost = New GetItemPriceAndCostFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PUnitPrice As Decimal?, PUnitCost As Decimal?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, Infobar As String, LineDisc As Decimal?) = iGetItemPriceAndCostExt.GetItemPriceAndCostSp(PItem, PCustNum, PUM, PCurrCode, PRate, PReprice, PQtyOrdered, POrderDate, PPriceCode, PFeatStr, PUnitPrice, PUnitCost, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, Infobar, PCoNum, PCoLine, PCustItem, LineDisc)
            Dim Severity As Integer = result.ReturnCode.Value
            PUnitPrice = result.PUnitPrice
            PUnitCost = result.PUnitCost
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            Infobar = result.Infobar
            LineDisc = result.LineDisc
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemRefSp(ByVal Item As String, ByVal CalledFrom As String, ByRef RefType As String, ByRef Infobar As String,
        <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemRefExt As IGetItemRef = New GetItemRefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RefType As String, Infobar As String) = iGetItemRefExt.GetItemRefSp(Item, CalledFrom, RefType, Infobar, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            RefType = result.RefType
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetNextValidDueDateSp(ByVal RefType As String, ByVal IsForward As Byte?, ByVal Site As String, ByRef DueDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetNextValidDueDateExt As IGetNextValidDueDate = New GetNextValidDueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DueDate As DateTime?, Infobar As String) = iGetNextValidDueDateExt.GetNextValidDueDateSp(RefType, IsForward, Site, DueDate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DueDate = result.DueDate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetSiteGroupSp(ByRef SiteGroup As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetSiteGroupExt As IGetSiteGroup = New GetSiteGroupFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, SiteGroup As String) = iGetSiteGroupExt.GetSiteGroupSp(SiteGroup)
            Dim Severity As Integer = result.ReturnCode.Value
            SiteGroup = result.SiteGroup
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetTaxFreeDaysSp(ByVal ProdCode As String, ByRef TaxFreeDays As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetTaxFreeDaysExt As IGetTaxFreeDays = New GetTaxFreeDaysFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, TaxFreeDays As Integer?) = iGetTaxFreeDaysExt.GetTaxFreeDaysSp(ProdCode, TaxFreeDays, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            TaxFreeDays = result.TaxFreeDays
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetUnitPricingSp(ByVal CustNum As String, ByVal Item As String, ByRef UnitPrice As Decimal?, ByRef DiscPercent As Decimal?, ByRef DiscUnitPrice As Decimal?, ByRef Infobar As String,
        <[Optional]> ByRef ErrorMessage As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetUnitPricingExt As IGetUnitPricing = New GetUnitPricingFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, UnitPrice As Decimal?, DiscPercent As Decimal?, DiscUnitPrice As Decimal?, Inforbar As String, ErrorMessage As String) = iGetUnitPricingExt.GetUnitPricingSp(CustNum, Item, UnitPrice, DiscPercent, DiscUnitPrice, Infobar, ErrorMessage)
            Dim Severity As Integer = result.ReturnCode.Value
            UnitPrice = result.UnitPrice
            DiscPercent = result.DiscPercent
            DiscUnitPrice = result.DiscUnitPrice
            Infobar = result.Inforbar
            ErrorMessage = result.ErrorMessage
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InsertProgBillByItemPercentSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal InvoiceFlag As String, ByVal BillDate As DateTime?, ByVal Description As String, ByVal Percent As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInsertProgBillByItemPercentExt As IInsertProgBillByItemPercent = New InsertProgBillByItemPercentFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iInsertProgBillByItemPercentExt.InsertProgBillByItemPercentSp(CoNum, CoLine, InvoiceFlag, BillDate, Description, Percent, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ITaxSp(ByVal PTaxSystem As Integer?, ByVal PTaxCode As String, ByVal PItem As String, ByRef PDefaultTaxCode As String,
<[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iITaxExt As IITax = New ITaxFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PDefaultTaxCode As String) = iITaxExt.ITaxSp(PTaxSystem, PTaxCode, PItem, PDefaultTaxCode, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            PDefaultTaxCode = result.PDefaultTaxCode
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemUnitWeightSp(ByVal PItem As String, ByRef PUnitWeight As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemUnitWeightExt As IItemUnitWeight = New ItemUnitWeightFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PunitWeight As Decimal?, Infobar As String) = iItemUnitWeightExt.ItemUnitWeightSp(PItem, PUnitWeight, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PUnitWeight = result.PUnitWeight
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JmatlTpSp(ByVal CallFrom As String, ByVal DeleteTmpSer As Byte?, ByVal Backflush As Byte?, ByVal Workkey As String, ByVal ByProduct As Byte?, ByVal TransClass As String, ByVal JobJob As String, ByVal JobSuffix As Short?, ByVal JobmatlOperNum As Integer?, ByVal JobmatlSequence As Decimal?, ByVal ChildItem As String, ByVal Wc As String, ByVal EmpNum As String, ByVal Whse As String, ByVal Loc As String, ByVal Lot As String, ByVal TransDate As DateTime?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal Cost As Decimal?, ByVal Qty As Decimal?, ByVal Acct As String, ByVal AcctUnit1 As String, ByVal AcctUnit2 As String, ByVal AcctUnit3 As String, ByVal AcctUnit4 As String,
<[Optional]> ByVal ImportDocId As String, ByRef Infobar As String,
<[Optional]> ByVal JobLot As String,
<[Optional]> ByVal JobSerial As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJmatlTpExt As IJmatlTp = New JmatlTpFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJmatlTpExt.JmatlTpSp(CallFrom, DeleteTmpSer, Backflush, Workkey, ByProduct, TransClass, JobJob, JobSuffix, JobmatlOperNum, JobmatlSequence, ChildItem, Wc, EmpNum, Whse, Loc, Lot, TransDate, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Cost, Qty, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, ImportDocId, Infobar, JobLot, JobSerial, ContainerNum, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
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

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MO_CLM_EstimateJobSp(ByVal CoNum As String, ByVal RESID As String, ByVal BOMType As String, ByVal CoProductMix As String, ByVal ProductCycle As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_CLM_EstimateJobExt As IMO_CLM_EstimateJob = New MO_CLM_EstimateJobFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iMO_CLM_EstimateJobExt.MO_CLM_EstimateJobSp(CoNum, RESID, BOMType, CoProductMix, ProductCycle)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MO_CLM_ResourceJobSp(ByVal BOMType As String, ByVal CoJob As String, ByVal ProdMix As String, ByVal RESID As String, ByVal DeleteFlag As Integer?,
        <[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMO_CLM_ResourceJobExt As IMO_CLM_ResourceJob = New MO_CLM_ResourceJobFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, returncode As Integer?) = iMO_CLM_ResourceJobExt.MO_CLM_ResourceJobSp(BOMType, CoJob, ProdMix, RESID, DeleteFlag, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_GenEstJobSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal Item As String, ByVal QtyOrdered As Decimal?, ByVal ProductCycle As Integer?, ByVal QtyPerCycle As Decimal?, ByVal DueDate As DateTime?, ByVal Whse As String, ByVal BOMType As String, ByVal CoProductMix As String, ByVal AlternateID As String, ByVal Resource As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMO_GenEstJobExt As IMO_GenEstJob = New MO_GenEstJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMO_GenEstJobExt.MO_GenEstJobSp(CoNum, CoLine, Item, QtyOrdered, ProductCycle, QtyPerCycle, DueDate, Whse, BOMType, CoProductMix, AlternateID, Resource, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_UpdateEstJobCostSp(ByVal Job As String, ByVal JobSuffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_UpdateEstJobCostExt As IMO_UpdateEstJobCost = New MO_UpdateEstJobCostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMO_UpdateEstJobCostExt.MO_UpdateEstJobCostSp(Job, JobSuffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_ValEstimateWBSourceSp(ByVal QuoteMethod As String, ByVal QuoteType As String, ByVal Source As String, ByVal SourceLine As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_ValEstimateWBSourceExt As IPP_ValEstimateWBSource = New PP_ValEstimateWBSourceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPP_ValEstimateWBSourceExt.PP_ValEstimateWBSourceSp(QuoteMethod, QuoteType, Source, SourceLine, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ResvCoitemSp(ByVal CurCoNum As String, ByVal CurCoLine As Short?, ByVal CurCoRel As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iResvCoitemExt As IResvCoitem = New ResvCoitemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iResvCoitemExt.ResvCoitemSp(CurCoNum, CurCoLine, CurCoRel, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
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
    Public Function UpdateEstJobSp(ByVal EstNum As String, ByVal EstLine As Short?, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal ProductCycle As Integer?, ByVal QtyCycle As Decimal?, ByVal Item As String, ByVal BOMType As String, ByVal CoProductMix As String, ByVal AlternateID As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateEstJobExt As IUpdateEstJob = New UpdateEstJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateEstJobExt.UpdateEstJobSp(EstNum, EstLine, RefNum, RefLineSuf, ProductCycle, QtyCycle, Item, BOMType, CoProductMix, AlternateID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateShipItemSp(ByVal CoNum As String, ByVal CoLine As Integer?, ByVal CoRelease As Integer?, ByVal Active As Integer?, ByRef Infobar As String, ByVal BatchId As Integer?, ByVal DoLine As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateShipItemExt As IUpdateShipItem = New UpdateShipItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateShipItemExt.UpdateShipItemSp(CoNum, CoLine, CoRelease, Active, Infobar, BatchId, DoLine)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateDueDateSp(ByVal RefType As String, ByVal DueDate As DateTime?, ByVal Site As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iValidateDueDateExt As IValidateDueDate = New ValidateDueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateDueDateExt.ValidateDueDateSp(RefType, DueDate, Site, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidatorRefPickListSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidatorRefPickListExt As IValidatorRefPickList = New ValidatorRefPickListFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidatorRefPickListExt.ValidatorRefPickListSp(CoNum, CoLine, CoRelease, Infobar)
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

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PRBDomesticCurrencySp(ByVal CurrCode As String,
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ChangeCOInvalidDueDateSp(ByVal Selected As Byte?, ByVal OrderNum As String, ByVal Line As Short?, ByVal Release As Short?, ByVal Status As String, ByVal OldDueDate As DateTime?, ByVal NewDueDate As DateTime?, ByVal ShipSite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iChangeCOInvalidDueDateExt As IChangeCOInvalidDueDate = New ChangeCOInvalidDueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iChangeCOInvalidDueDateExt.ChangeCOInvalidDueDateSp(Selected, OrderNum, Line, Release, Status, OldDueDate, NewDueDate, ShipSite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Homepage_OrdersFulfilledSp(ByVal StartDate As DateTime?, ByVal EndDate As DateTime?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iHomepage_OrdersFulfilledExt As IHomepage_OrdersFulfilled = New Homepage_OrdersFulfilledFactory().Create(appDb, bunchedLoadCollection, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iHomepage_OrdersFulfilledExt.Homepage_OrdersFulfilledSp(StartDate, EndDate)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AddResvSp(ByVal Item As String, ByVal Whse As String, ByVal RefNum As String, ByVal RefLine As Integer?, ByVal RefRelease As Integer?, ByVal Loc As String, ByVal Lot As String, ByVal Qty As Decimal?, ByVal ConvFactor As Decimal?, ByVal UM As String, ByVal AutoRsvd As Integer?, ByVal ProgramName As String, ByRef RsvdNum As Decimal?, ByRef Infobar As String,
        <[Optional]> ByVal SessionID As Guid?, ByVal ImportDocId As String,
        <[Optional]> ByVal ParmsSite As String) As Integer
        Dim iAddResvExt As IAddResv = New AddResvFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, RsvdNum As Decimal?, Infobar As String) = iAddResvExt.AddResvSp(Item, Whse, RefNum, RefLine, RefRelease, Loc, Lot, Qty, ConvFactor, UM, AutoRsvd, ProgramName, RsvdNum, Infobar, SessionID, ImportDocId, ParmsSite)
        Dim Severity As Integer = result.ReturnCode.Value
        RsvdNum = result.RsvdNum
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstimateLinesSetItemCustSp(ByVal PSetItemCust As Integer?, ByVal PItem As String, ByVal PCustNum As String, ByVal PCustItem As String, ByVal PCostConv As Decimal?, ByVal PCoNum As String, ByVal PUM As String) As Integer
        Dim iEstimateLinesSetItemCustExt As IEstimateLinesSetItemCust = New EstimateLinesSetItemCustFactory().Create(Me, True)
        Dim result As Integer? = iEstimateLinesSetItemCustExt.EstimateLinesSetItemCustSp(PSetItemCust, PItem, PCustNum, PCustItem, PCostConv, PCoNum, PUM)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdObalSp(ByVal CustNum As String, ByVal Adjust As Decimal?) As Integer
        Dim iUpdObalExt As IUpdObal = New UpdObalFactory().Create(Me, True)
        Dim result As Integer? = iUpdObalExt.UpdObalSp(CustNum, Adjust)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEcvtSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal Shipcode As String, ByRef EcCode As String, ByRef Transport As String,
        <[Optional], DefaultParameterValue(0)> ByRef SupplQtyReq As Integer?,
        <[Optional], DefaultParameterValue(1)> ByRef SupplQtyConvFactor As Decimal?,
        <[Optional]> ByVal CoLcrNum As String,
        <[Optional]> ByRef ShipSite As String) As Integer
        Dim iGetEcvtExt As IGetEcvt = New GetEcvtFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, EcCode As String, Transport As String, SupplQtyReq As Integer?, SupplQtyConvFactor As Decimal?, ShipSite As String) = iGetEcvtExt.GetEcvtSp(CustNum, CustSeq, Shipcode, EcCode, Transport, SupplQtyReq, SupplQtyConvFactor, CoLcrNum, ShipSite)
        Dim Severity As Integer = result.ReturnCode.Value
        EcCode = result.EcCode
        Transport = result.Transport
        SupplQtyReq = result.SupplQtyReq
        SupplQtyConvFactor = result.SupplQtyConvFactor
        ShipSite = result.ShipSite
        Return Severity
    End Function

End Class