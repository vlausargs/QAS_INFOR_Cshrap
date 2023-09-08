Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Customer
Imports CSI.Reporting
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLItems")>
Public Class SLItems
    Inherits CSIExtensionClassBase
    Implements IExtFTSLItems

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemCopyCustomLoad(ByVal PropertyNames As Object, ByRef ResultSet As Object, ByRef Flags As Object,
        ByVal Process As String, ByVal FromItem As String, ByVal ToItem As String, ByVal FromItemLabel As String,
        ByVal ToItemLabel As String, ByVal CopyUDF As Integer, ByVal CopyLoc As Integer,
        ByVal CopyBom As Integer, ByVal EffectDate As Date, ByRef Infobar As String) As Integer

        Dim oSLItems As InvokeResponseData

        oSLItems = Me.Invoke("ItemCopySp", PropertyNames, ResultSet, Flags,
                            Process, FromItem, ToItem, FromItemLabel,
                            ToItemLabel, CopyUDF, CopyLoc, CopyBom, EffectDate, Infobar)

        oSLItems = Nothing
        If Process = "P" Then
            ItemCopyCustomLoad = 16
        Else
            ItemCopyCustomLoad = 0
        End If
    End Function

    Public Overrides Sub SetContext(ByVal context As _
    Mongoose.IDO.IIDOExtensionClassContext)

        MyBase.SetContext(context)
        ' Add event handlers
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf _
        Me.PostUpdateCollection

    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim UpdateAcct As String
        Dim Item As String
        Dim ProductCode As String
        Dim PInfobar As String = IDONull.Value.ToString
        Dim updateRequest As UpdateCollectionRequestData

        updateRequest = CType(args.RequestPayload, UpdateCollectionRequestData)

        For Each updateItem As IDOUpdateItem In updateRequest.Items
            UpdateAcct = "0"
            If updateItem.Properties.IndexOf("UbUpdateAcctAndUC") >= 0 Then
                If Not updateItem.Properties("UbUpdateAcctAndUC").IsNull Then
                    UpdateAcct = updateItem.Properties("UbUpdateAcctAndUC").GetValue(Of String)()
                End If
            End If

            If UpdateAcct = "1" Then
                Item = updateItem.Properties("Item").GetValue(Of String)()
                ProductCode = updateItem.Properties("ProductCode").GetValue(Of String)()
                Me.Invoke("UpdateItemLocAcctSp", Item, ProductCode, PInfobar)
            End If
        Next

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AttributesQueryTabSearchSp(ByVal AttrGroupClass As String, ByVal SearchStr As String, ByVal CriteriaSepa As String, ByRef RowPointerStr As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAttributesQueryTabSearchExt As IAttributesQueryTabSearch = New AttributesQueryTabSearchFactory().Create(appDb)

            Dim oRowPointerStr As StringType = RowPointerStr
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iAttributesQueryTabSearchExt.AttributesQueryTabSearchSp(AttrGroupClass, SearchStr, CriteriaSepa, oRowPointerStr, oInfobar)
            RowPointerStr = oRowPointerStr
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateItemSp(ByVal Item As String,
                                 ByVal Description As String,
                                 ByVal Revision As String,
                                 ByVal UM As String,
                                 ByVal ProductCode As String,
                                 ByRef Job As String,
                                 ByRef Suffix As Short?,
                                 ByRef JobType As String,
                                 ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCreateItemExt As ICreateItem = New CreateItemFactory().Create(appDb)

            Dim oJob As JobType = Job
            Dim oSuffix As SuffixType = Suffix
            Dim oJobType As JobTypeType = JobType
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCreateItemExt.CreateItemSp(Item, Description, Revision, UM, ProductCode, oJob, oSuffix, oJobType, oInfobar)

            Job = oJob
            Suffix = oSuffix
            JobType = oJobType
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function FbomVSp(ByVal FromItem As String,
                            ByVal ToItem As String,
                            ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iFbomVExt As IFbomV = New FbomVFactory().Create(appDb, bunchedLoadCollection)

            Dim oInfobar As InfobarType = Infobar
            Dim dt As DataTable = iFbomVExt.FbomVSp(FromItem, ToItem, oInfobar)
            Infobar = oInfobar

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEnggWBParmsSp(ByRef PAnyCanAdd As Byte?,
                                     ByRef PAnyCanDelete As Byte?,
                                     ByRef PAnyCanUpdate As Byte?,
                                     ByRef DefWhse As String,
                                     ByRef EcnEst As String,
                                     ByRef EcnJob As String,
                                     ByRef EcnStd As String,
                                     ByRef NegFlag As Byte?,
                                     ByRef LocalDefWhse As String,
                                     ByRef LocalBFlushLoc As String,
                                     ByRef Parm_RunBasis As String,
                                     ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetEnggWBParmsExt As IGetEnggWBParms = New GetEnggWBParmsFactory().Create(appDb)

            Dim oPAnyCanAdd As ListYesNoType = PAnyCanAdd
            Dim oPAnyCanDelete As ListYesNoType = PAnyCanDelete
            Dim oPAnyCanUpdate As ListYesNoType = PAnyCanUpdate
            Dim oDefWhse As WhseType = DefWhse
            Dim oEcnEst As EcnModeType = EcnEst
            Dim oEcnJob As EcnModeType = EcnJob
            Dim oEcnStd As EcnModeType = EcnStd
            Dim oNegFlag As ListYesNoType = NegFlag
            Dim oLocalDefWhse As WhseType = LocalDefWhse
            Dim oLocalBFlushLoc As LocType = LocalBFlushLoc
            Dim oParm_RunBasis As RunBasisType = Parm_RunBasis
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iGetEnggWBParmsExt.GetEnggWBParmsSp(oPAnyCanAdd, oPAnyCanDelete, oPAnyCanUpdate, oDefWhse, oEcnEst, oEcnJob, oEcnStd, oNegFlag, oLocalDefWhse, oLocalBFlushLoc, oParm_RunBasis, oInfobar)

            PAnyCanAdd = oPAnyCanAdd
            PAnyCanDelete = oPAnyCanDelete
            PAnyCanUpdate = oPAnyCanUpdate
            DefWhse = oDefWhse
            EcnEst = oEcnEst
            EcnJob = oEcnJob
            EcnStd = oEcnStd
            NegFlag = oNegFlag
            LocalDefWhse = oLocalDefWhse
            LocalBFlushLoc = oLocalBFlushLoc
            Parm_RunBasis = oParm_RunBasis
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemMatlTrackQtySp(ByVal PItem As String, ByVal PUM As String, ByVal PRefType As String,
<[Optional]> ByVal PRefNum As String,
<[Optional]> ByVal PRefLineSuf As Short?,
<[Optional]> ByVal PRefRelease As Short?,
<[Optional]> ByVal PWhse As String,
<[Optional]> ByVal PLoc As String,
<[Optional]> ByVal PLot As String, ByRef PQty As Decimal?, ByRef PQtyConv As Decimal?, ByRef Infobar As String, ByRef PQtyWithOutLotConv As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemMatlTrackQtyExt As IGetItemMatlTrackQty = New GetItemMatlTrackQtyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PQty As Decimal?, PQtyConv As Decimal?, Infobar As String, PQtyWithOutLotConv As Decimal?) = iGetItemMatlTrackQtyExt.GetItemMatlTrackQtySp(PItem, PUM, PRefType, PRefNum, PRefLineSuf, PRefRelease, PWhse, PLoc, PLot, PQty, PQtyConv, Infobar, PQtyWithOutLotConv)
            Dim Severity As Integer = result.ReturnCode.Value
            PQty = result.PQty
            PQtyConv = result.PQtyConv
            Infobar = result.Infobar
            PQtyWithOutLotConv = result.PQtyWithOutLotConv
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetMaxLotNumSiteSp(ByVal LotPrefix As String,
<[Optional]> ByVal Site As String, ByRef KeyVal As String, ByVal Item As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetMaxLotNumSiteExt As IGetMaxLotNumSite = New GetMaxLotNumSiteFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, KeyVal As String) = iGetMaxLotNumSiteExt.GetMaxLotNumSiteSp(LotPrefix, Site, KeyVal, Item)
            Dim Severity As Integer = result.ReturnCode.Value
            KeyVal = result.KeyVal
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InventoryControlAlertsSp(ByRef ItemsBelowSafetyStock As Integer?,
                                             ByRef ItemsQuarantined As Integer?,
                                             ByRef NumberOfUserTasks As Integer?,
                                             ByRef NumberOfEventMessages As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iInventoryControlAlertsExt As IInventoryControlAlerts = New InventoryControlAlertsFactory().Create(appDb)

            Dim oItemsBelowSafetyStock As NumberOfLinesType = ItemsBelowSafetyStock
            Dim oItemsQuarantined As NumberOfLinesType = ItemsQuarantined
            Dim oNumberOfUserTasks As NumberOfLinesType = NumberOfUserTasks
            Dim oNumberOfEventMessages As NumberOfLinesType = NumberOfEventMessages

            Dim Severity As Integer = iInventoryControlAlertsExt.InventoryControlAlertsSp(oItemsBelowSafetyStock, oItemsQuarantined, oNumberOfUserTasks, oNumberOfEventMessages)

            ItemsBelowSafetyStock = oItemsBelowSafetyStock
            ItemsQuarantined = oItemsQuarantined
            NumberOfUserTasks = oNumberOfUserTasks
            NumberOfEventMessages = oNumberOfEventMessages

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsItemInNonInventoryItemSp(ByVal Item As String,
                                               ByRef ExistsInNonInventoryItem As Byte?,
                                               ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iIsItemInNonInventoryItemExt As IIsItemInNonInventoryItem = New IsItemInNonInventoryItemFactory().Create(appDb)

            Dim oExistsInNonInventoryItem As ListYesNoType = ExistsInNonInventoryItem
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iIsItemInNonInventoryItemExt.IsItemInNonInventoryItemSp(Item, oExistsInNonInventoryItem, oInfobar)

            ExistsInNonInventoryItem = oExistsInNonInventoryItem
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Item360_GetMonthToDateValuesSp(ByVal Item As String,
                                                   ByRef BookingAmount As Decimal?,
                                                   ByRef POFundAmount As Decimal?,
                                                   ByRef ToCompleteAmount As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItem360_GetMonthToDateValuesExt As IItem360_GetMonthToDateValues = New Item360_GetMonthToDateValuesFactory().Create(appDb)

            Dim oBookingAmount As AmountType = BookingAmount
            Dim oPOFundAmount As AmountType = POFundAmount
            Dim oToCompleteAmount As AmountType = ToCompleteAmount

            Dim Severity As Integer = iItem360_GetMonthToDateValuesExt.Item360_GetMonthToDateValuesSp(Item, oBookingAmount, oPOFundAmount, oToCompleteAmount)

            BookingAmount = oBookingAmount
            POFundAmount = oPOFundAmount
            ToCompleteAmount = oToCompleteAmount

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemBFlushLocSp(ByVal Item As String, ByVal Loc As String, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemBFlushLocExt As IItemBFlushLoc = New ItemBFlushLocFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemBFlushLocExt.ItemBFlushLocSp(Item, Loc, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemCheckShipSiteSp(ByVal Item As String,
                                        ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemCheckShipSiteExt As IItemCheckShipSite = New ItemCheckShipSiteFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iItemCheckShipSiteExt.ItemCheckShipSiteSp(Item, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemCopySp(ByVal Process As String, ByVal FromItem As String, ByVal ToItem As String, ByVal FromItemLabel As String, ByVal ToItemLabel As String, ByVal CopyUDF As Byte?, ByVal CopyLoc As Byte?, ByVal CopyBOM As Byte?, ByVal EffectDate As DateTime?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyUetValues As Byte?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemCopyExt As IItemCopy = New ItemCopyFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemCopyExt.ItemCopySp(Process, FromItem, ToItem, FromItemLabel, ToItemLabel, CopyUDF, CopyLoc, CopyBOM, EffectDate, Infobar, CopyUetValues, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemCostMethodCostTypeValidSp(ByVal CostMethod As String,
                                                  ByVal CostType As String,
                                                  ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemCostMethodCostTypeValidExt As IItemCostMethodCostTypeValid = New ItemCostMethodCostTypeValidFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iItemCostMethodCostTypeValidExt.ItemCostMethodCostTypeValidSp(CostMethod, CostType, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemJobCheckSp(ByVal Item As String, ByVal LotTracked As Byte?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemJobCheckExt As IItemJobCheck = New ItemJobCheckFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemJobCheckExt.ItemJobCheckSp(Item, LotTracked, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemLeadTimeSp(ByVal FromItem As String, ByVal ToItem As String, ByVal UseWcCal As Byte?, ByVal UseOffsetHrs As Byte?, ByVal ListOpts As Byte?, ByRef Infobar As String,
<[Optional]> ByVal ShopCal As String,
<[Optional]> ByVal ApplyOffsetHrsStart As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemLeadTimeExt As IItemLeadTime = New ItemLeadTimeFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemLeadTimeExt.ItemLeadTimeSp(FromItem, ToItem, UseWcCal, UseOffsetHrs, ListOpts, Infobar, ShopCal, ApplyOffsetHrsStart)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemLotExistsSp(ByVal Item As String,
                                    ByRef Infobar As String,
                                    ByRef PromptMsg As String,
                                    ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemLotExistsExt As IItemLotExists = New ItemLotExistsFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As Infobar = PromptButtons

            Dim Severity As Integer = iItemLotExistsExt.ItemLotExistsSp(Item, oInfobar, oPromptMsg, oPromptButtons)

            Infobar = oInfobar
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemLowSp(
<[Optional], DefaultParameterValue("N")> ByVal ListDuring As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ListRecursiveOnly As Byte?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemLowExt As IItemLow = New ItemLowFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemLowExt.ItemLowSp(ListDuring, ListRecursiveOnly, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemNewSp(ByVal Item As String, ByRef ItemDescription As String, ByRef ItemUM As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iItemNewExt As IItemNew = New ItemNewFactory().Create(appDb)

            Dim oItemDescription As DescriptionType = ItemDescription
            Dim oItemUM As UMType = ItemUM

            Dim Severity As Integer = iItemNewExt.ItemNewSp(Item, oItemDescription, oItemUM)

            ItemDescription = oItemDescription
            ItemUM = oItemUM

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemPreDisplayEntrySp(ByRef CanUpdateRevTrack As Short?, ByRef ApsParmApsmode As String, ByRef TrackTaxFreeimports As Byte?, ByRef RUserCode As String, ByRef POToleranceOver As Decimal?, ByRef POToleranceUnder As Decimal?, ByRef Vchrauthorize As Byte?, ByRef VchrOverPoCostTolerance As Decimal?, ByRef VchrUnderPoCostTolerance As Decimal?, ByRef use_wholesale_price As Byte?, ByRef use_backflush As Byte?, ByRef ConfigServerId As String, ByRef ConfigHeaderNameSpace As String, ByRef Configurator As String, ByRef ConfiguratorURL As String, ByRef ConfigDeploymentPath As String, ByRef AvailCfg As Byte?, ByRef AllowFcstBomSupplyItems As Byte?, ByRef CostItemAtWhse As Byte?, ByRef LinearDimensionUM As String, ByRef DensityUM As String, ByRef AreaUM As String, ByRef BulkMassUM As String, ByRef ReamMassUM As String, ByRef LotPrefix As String, ByRef LotTracked As Byte?, ByRef IssueBy As String, ByRef SerialTracked As Byte?, ByRef SerialPrefix As String, ByRef CostType As String, ByRef PreassignLots As Byte?, ByRef PreassignSerials As Byte?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemPreDisplayEntryExt As IItemPreDisplayEntry = New ItemPreDisplayEntryFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CanUpdateRevTrack As Short?, ApsParmApsmode As String, TrackTaxFreeimports As Byte?, RUserCode As String, POToleranceOver As Decimal?, POToleranceUnder As Decimal?, Vchrauthorize As Byte?, VchrOverPoCostTolerance As Decimal?, VchrUnderPoCostTolerance As Decimal?, use_wholesale_price As Byte?, use_backflush As Byte?, ConfigServerId As String, ConfigHeaderNameSpace As String, Configurator As String, ConfiguratorURL As String, ConfigDeploymentPath As String, AvailCfg As Byte?, AllowFcstBomSupplyItems As Byte?, CostItemAtWhse As Byte?, LinearDimensionUM As String, DensityUM As String, AreaUM As String, BulkMassUM As String, ReamMassUM As String, LotPrefix As String, LotTracked As Byte?, IssueBy As String, SerialTracked As Byte?, SerialPrefix As String, CostType As String, PreassignLots As Byte?, PreassignSerials As Byte?, Infobar As String) = iItemPreDisplayEntryExt.ItemPreDisplayEntrySp(CanUpdateRevTrack, ApsParmApsmode, TrackTaxFreeimports, RUserCode, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, use_wholesale_price, use_backflush, ConfigServerId, ConfigHeaderNameSpace, Configurator, ConfiguratorURL, ConfigDeploymentPath, AvailCfg, AllowFcstBomSupplyItems, CostItemAtWhse, LinearDimensionUM, DensityUM, AreaUM, BulkMassUM, ReamMassUM, LotPrefix, LotTracked, IssueBy, SerialTracked, SerialPrefix, CostType, PreassignLots, PreassignSerials, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            CanUpdateRevTrack = result.CanUpdateRevTrack
            ApsParmApsmode = result.ApsParmApsmode
            TrackTaxFreeimports = result.TrackTaxFreeimports
            RUserCode = result.RUserCode
            POToleranceOver = result.POToleranceOver
            POToleranceUnder = result.POToleranceUnder
            Vchrauthorize = result.Vchrauthorize
            VchrOverPoCostTolerance = result.VchrOverPoCostTolerance
            VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance
            use_wholesale_price = result.use_wholesale_price
            use_backflush = result.use_backflush
            ConfigServerId = result.ConfigServerId
            ConfigHeaderNameSpace = result.ConfigHeaderNameSpace
            Configurator = result.Configurator
            ConfiguratorURL = result.ConfiguratorURL
            ConfigDeploymentPath = result.ConfigDeploymentPath
            AvailCfg = result.AvailCfg
            AllowFcstBomSupplyItems = result.AllowFcstBomSupplyItems
            CostItemAtWhse = result.CostItemAtWhse
            LinearDimensionUM = result.LinearDimensionUM
            DensityUM = result.DensityUM
            AreaUM = result.AreaUM
            BulkMassUM = result.BulkMassUM
            ReamMassUM = result.ReamMassUM
            LotPrefix = result.LotPrefix
            LotTracked = result.LotTracked
            IssueBy = result.IssueBy
            SerialTracked = result.SerialTracked
            SerialPrefix = result.SerialPrefix
            CostType = result.CostType
            PreassignLots = result.PreassignLots
            PreassignSerials = result.PreassignSerials
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemrollSp(ByVal ListOpts As Byte?, ByVal EffectDate As DateTime?, ByVal ResetByProdCost As Byte?, ByVal UseStdCost As Byte?, ByRef Infobar As String,
<[Optional]> ByVal EffectDateOffset As Short?, ByVal ProcessObsoleteItems As Byte?, ByVal ProcessSlowMovingItems As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemrollExt As IItemroll = New ItemrollFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemrollExt.ItemrollSp(ListOpts, EffectDate, ResetByProdCost, UseStdCost, Infobar, EffectDateOffset, ProcessObsoleteItems, ProcessSlowMovingItems)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemSglrollSp(ByVal Item As String, ByVal EffectDate As DateTime?, ByVal ResetByProdCost As Byte?, ByRef Infobar As String,
<[Optional]> ByVal EffectDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemSglrollExt As IItemSglroll = New ItemSglrollFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemSglrollExt.ItemSglrollSP(Item, EffectDate, ResetByProdCost, Infobar, EffectDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemStatusChangeSp(ByVal Process As String,
                                       ByVal FromItem As String,
                                       ByVal ToItem As String,
                                       ByVal FromProductCode As String,
                                       ByVal ToProductCode As String,
                                       ByVal FromBuyer As String,
                                       ByVal ToBuyer As String,
                                       ByVal OldStat As String,
                                       ByVal NewStat As String,
                                       ByVal ReasonCode As String,
                                       ByVal UserID As Decimal?,
                                       ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iItemStatusChangeExt As IItemStatusChange = New ItemStatusChangeFactory().Create(appDb, bunchedLoadCollection)

            Dim oInfobar As InfobarType = Infobar

            Dim dt As DataTable = iItemStatusChangeExt.ItemStatusChangeSp(Process, FromItem, ToItem, FromProductCode, ToProductCode, FromBuyer, ToBuyer, OldStat, NewStat, ReasonCode, UserID, oInfobar)

            Infobar = oInfobar

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemUMCheckSp(ByVal Item As String,
                                  ByVal UM As String,
                                  ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemUMCheckExt As IItemUMCheck = New ItemUMCheckFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iItemUMCheckExt.ItemUMCheckSp(Item, UM, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MultiSiteBOMCopySp(
<[Optional]> ByVal SourceSite As String,
<[Optional]> ByVal TargetSite As String,
<[Optional]> ByVal Item As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateNonInventoryItems As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal IncludeDrawingNbr As Byte?,
<[Optional]> ByVal StartOperNum As Integer?,
<[Optional]> ByVal EndOperNum As Integer?,
<[Optional], DefaultParameterValue("D")> ByVal CopyOption As String,
<[Optional]> ByVal NewOperNum As Integer?,
<[Optional]> ByVal NewRevision As String, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMultiSiteBOMCopyExt As IMultiSiteBOMCopy = New MultiSiteBOMCopyFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMultiSiteBOMCopyExt.MultiSiteBOMCopySp(SourceSite, TargetSite, Item, CreateNonInventoryItems, IncludeDrawingNbr, StartOperNum, EndOperNum, CopyOption, NewOperNum, NewRevision, InfoBar)
            Dim Severity As Integer = result.ReturnCode.Value
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessTaxFreeImportUtilitySp(ByVal StartingItem As String, ByVal EndingItem As String, ByVal StartingProductCode As String, ByVal EndingProductCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iProcessTaxFreeImportUtilityExt As IProcessTaxFreeImportUtility = New ProcessTaxFreeImportUtilityFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iProcessTaxFreeImportUtilityExt.ProcessTaxFreeImportUtilitySp(StartingItem, EndingItem, StartingProductCode, EndingProductCode, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RebalIrSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iRebalIrExt As IRebalIr = New RebalIrFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iRebalIrExt.RebalIrSp(oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RebalAssignedToBePickedSp(ByRef Infobar As String) As Integer
        Dim iRebalAssignedToBePickedExt As IRebalAssignedToBePicked = New RebalAssignedToBePickedFactory().Create(Me, True)

        Dim result As (ReturnCode As Integer?, Infobar As String) = iRebalAssignedToBePickedExt.RebalAssignedToBePickedSp(Infobar)

        Infobar = result.Infobar
        Return If(result.ReturnCode, 0)
    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RebalItemQtyOnHandSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iRebalItemQtyOnHandExt As IRebalItemQtyOnHand = New RebalItemQtyOnHandFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iRebalItemQtyOnHandExt.RebalItemQtyOnHandSp(oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RebalItemQtyTrnSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iRebalItemQtyTrnExt As IRebalItemQtyTrn = New RebalItemQtyTrnFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iRebalItemQtyTrnExt.RebalItemQtyTrnSp(oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function SupDemItemwhseSp(ByVal Whse As String,
                                     ByVal Filter As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iSupDemItemwhseExt As ISupDemItemwhse = New SupDemItemwhseFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iSupDemItemwhseExt.SupDemItemwhseSp(Whse, Filter)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function TH_StockBalanceCons_InitDataSP(ByVal OverwriteExistingData As Integer?,
                                                   ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iTH_StockBalanceCons_InitDataExt As ITH_StockBalanceCons_InitData = New TH_StockBalanceCons_InitDataFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iTH_StockBalanceCons_InitDataExt.TH_StockBalanceCons_InitDataSP(OverwriteExistingData, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateProdCodeSp(ByRef ProductCode As String, ByVal Whse As String, ByRef TaxFreeDays As Short?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iValidateProdCodeExt As IValidateProdCode = New ValidateProdCodeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ProductCode As String, TaxFreeDays As Short?, Infobar As String) = iValidateProdCodeExt.ValidateProdCodeSp(ProductCode, Whse, TaxFreeDays, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            ProductCode = result.ProductCode
            TaxFreeDays = result.TaxFreeDays
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FetchNextLotSp(ByVal Item As String, ByVal Prefix As String, ByRef Infobar As String, ByRef Key As String,
<[Optional]> ByVal Site As String) As Integer Implements IExtFTSLItems.FetchNextLotSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iFetchNextLotExt As IFetchNextLot = New FetchNextLotFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, Key As String) = iFetchNextLotExt.FetchNextLotSp(Item, Prefix, Infobar, Key, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Key = result.Key
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
    Public Function IsItemNotInInventorySp(ByVal Item As String, ByRef ItemNotInInventory As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIsItemNotInInventoryExt As IIsItemNotInInventory = New IsItemNotInInventoryFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ItemNotInInventory As Integer?) = iIsItemNotInInventoryExt.IsItemNotInInventorySp(Item, ItemNotInInventory)
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MisReceiptItemWhseGetCostValuesSp(ByVal CurWhse As String, ByVal Item As String, ByRef MatlCost As Decimal?, ByRef LbrCost As Decimal?, ByRef FovhdCost As Decimal?, ByRef VovhdCost As Decimal?, ByRef OutCost As Decimal?, ByRef UnitCost As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal UM As String,
<[Optional]> ByRef MatlCostConv As Decimal?,
<[Optional]> ByRef LbrCostConv As Decimal?,
<[Optional]> ByRef FovhdCostConv As Decimal?,
<[Optional]> ByRef VovhdCostConv As Decimal?,
<[Optional]> ByRef OutCostConv As Decimal?,
<[Optional]> ByRef UnitCostConv As Decimal?) As Integer Implements IExtFTSLItems.MisReceiptItemWhseGetCostValuesSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMisReceiptItemWhseGetCostValuesExt As IMisReceiptItemWhseGetCostValues = New MisReceiptItemWhseGetCostValuesFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, UnitCost As Decimal?, Infobar As String, MatlCostConv As Decimal?, LbrCostConv As Decimal?, FovhdCostConv As Decimal?, VovhdCostConv As Decimal?, OutCostConv As Decimal?, UnitCostConv As Decimal?) = iMisReceiptItemWhseGetCostValuesExt.MisReceiptItemWhseGetCostValuesSp(CurWhse, Item, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitCost, Infobar, UM, MatlCostConv, LbrCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, UnitCostConv)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            UnitCost = result.UnitCost
            Infobar = result.Infobar
            MatlCostConv = result.MatlCostConv
            LbrCostConv = result.LbrCostConv
            FovhdCostConv = result.FovhdCostConv
            VovhdCostConv = result.VovhdCostConv
            OutCostConv = result.OutCostConv
            UnitCostConv = result.UnitCostConv
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
<[Optional]> ByVal Site As String) As Integer Implements IExtFTSLItems.ObsSlowSp
        Dim iObsSlowExt As IObsSlow = New ObsSlowFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iObsSlowExt.ObsSlowSp(Item, WarnIfSlowMoving, ErrorIfSlowMoving, WarnIfObsolete, ErrorIfObsolete, Infobar, Prompt, PromptButtons, Site)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Prompt = result.Prompt
        PromptButtons = result.PromptButtons
        Return Severity
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemABCAnalysisSp(ByVal Process As String, ByVal Background As Byte?, ByVal TaskId As Integer?, ByVal AnalysisMethod As String, ByVal ByValOrUnits As String, ByVal PMTCode As String, ByVal ABC1 As Integer?, ByVal ABC2 As Integer?, ByVal ABC3 As Integer?, ByRef Infobar As String,
<[Optional]> ByVal pSite As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItemABCAnalysisExt As IItemABCAnalysis = New ItemABCAnalysisFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iItemABCAnalysisExt.ItemABCAnalysisSP(Process, Background, TaskId, AnalysisMethod, ByValOrUnits, PMTCode, ABC1, ABC2, ABC3, Infobar, pSite)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CanUpdateCostsSp(ByVal PItem As String, ByVal PCostType As String, ByVal PCostMethod As String, ByVal PPMTCode As String,
<[Optional], DefaultParameterValue("")> ByVal PJob As String, ByVal PSuffix As Integer?, ByRef PCanUpdateCosts As Integer?, ByRef PCanPromptCost1 As Integer?, ByRef PCanPromptCost2 As Integer?, ByRef PDisplayUnitCosts As Integer?, ByRef CanUpdateCur As Integer?,
<[Optional]> ByVal Whse As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCanUpdateCostsExt As ICanUpdateCosts = New CanUpdateCostsFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (ReturnCode As Integer?, PCanUpdateCosts As Integer?, PCanPromptCost1 As Integer?, PCanPromptCost2 As Integer?, PDisplayUnitCosts As Integer?, CanUpdateCur As Integer?) = iCanUpdateCostsExt.CanUpdateCostsSp(PItem, PCostType, PCostMethod, PPMTCode, PJob, PSuffix, PCanUpdateCosts, PCanPromptCost1, PCanPromptCost2, PDisplayUnitCosts, CanUpdateCur, Whse)
            Dim Severity As Integer = result.ReturnCode.Value
            PCanUpdateCosts = result.PCanUpdateCosts
            PCanPromptCost1 = result.PCanPromptCost1
            PCanPromptCost2 = result.PCanPromptCost2
            PDisplayUnitCosts = result.PDisplayUnitCosts
            CanUpdateCur = result.CanUpdateCur
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckTaxFreeMatlItemSp(
<[Optional]> ByVal Item As String, ByVal CallFrom As String, ByRef DisableEnable As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCheckTaxFreeMatlItemExt As ICheckTaxFreeMatlItem = New CheckTaxFreeMatlItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DisableEnable As Integer?) = iCheckTaxFreeMatlItemExt.CheckTaxFreeMatlItemSp(Item, CallFrom, DisableEnable, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            DisableEnable = result.DisableEnable
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_PurchasedItemsSp(
<[Optional]> ByVal ItemFilter As String) As DataTable
        Dim iCLM_PurchasedItemsExt As ICLM_PurchasedItems = New CLM_PurchasedItemsFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_PurchasedItemsExt.CLM_PurchasedItemsSp(ItemFilter)
        If result.Data Is Nothing Then
            Return New DataTable()
        Else
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End If
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CoitemSp(ByVal PMode As String, ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal FromParmsSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCoitemExt As ICoitem = New CoitemFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCoitemExt.CoitemSp(PMode, CoNum, CoLine, CoRelease, FromParmsSite)
            Dim Severity As Integer = result.Value

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DistAcctExistsSp(ByVal Whse As String, ByVal ProductCode As String, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDistAcctExistsExt As IDistAcctExists = New DistAcctExistsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDistAcctExistsExt.DistAcctExistsSp(Whse, ProductCode, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
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
    Public Function GetItemParSp(ByRef ApsParmApsmode As String, ByRef TrackTaxFreeimports As Integer?, ByRef RUserCode As String, ByRef POToleranceOver As Decimal?, ByRef POToleranceUnder As Decimal?, ByRef Vchrauthorize As Integer?, ByRef VchrOverPoCostTolerance As Decimal?, ByRef VchrUnderPoCostTolerance As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemParExt As IGetItemPar = New GetItemParFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ApsParmApsmode As String, TrackTaxFreeimports As Integer?, RUserCode As String, POToleranceOver As Decimal?, POToleranceUnder As Decimal?, Vchrauthorize As Integer?, VchrOverPoCostTolerance As Decimal?, VchrUnderPoCostTolerance As Decimal?, Infobar As String) = iGetItemParExt.GetItemParSp(ApsParmApsmode, TrackTaxFreeimports, RUserCode, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            ApsParmApsmode = result.ApsParmApsmode
            TrackTaxFreeimports = result.TrackTaxFreeimports
            RUserCode = result.RUserCode
            POToleranceOver = result.POToleranceOver
            POToleranceUnder = result.POToleranceUnder
            Vchrauthorize = result.Vchrauthorize
            VchrOverPoCostTolerance = result.VchrOverPoCostTolerance
            VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetItemsPriceForCustItemSp(
        <[Optional]> ByVal CustItem As String,
        <[Optional]> ByVal CustNum As String,
        <[Optional]> ByVal Item As String,
        <[Optional]> ByVal SiteRef As String, ByVal Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetItemsPriceForCustItemExt As IGetItemsPriceForCustItem = New GetItemsPriceForCustItemFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iGetItemsPriceForCustItemExt.GetItemsPriceForCustItemSp(CustItem, CustNum, Item, SiteRef, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPurchasingParmsSp(ByRef POToleranceOver As Decimal?, ByRef POToleranceUnder As Decimal?, ByRef Vchrauthorize As Integer?, ByRef VchrOverPoCostTolerance As Decimal?, ByRef VchrUnderPoCostTolerance As Decimal?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetPurchasingParmsExt As IGetPurchasingParms = New GetPurchasingParmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, POToleranceOver As Decimal?, POToleranceUnder As Decimal?, Vchrauthorize As Integer?, VchrOverPoCostTolerance As Decimal?, VchrUnderPoCostTolerance As Decimal?) = iGetPurchasingParmsExt.GetPurchasingParmsSp(POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            POToleranceOver = result.POToleranceOver
            POToleranceUnder = result.POToleranceUnder
            Vchrauthorize = result.Vchrauthorize
            VchrOverPoCostTolerance = result.VchrOverPoCostTolerance
            VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Item_ItemRevSp(ByVal sTreeFilter As String, ByVal sStartingRevision As String, ByVal sEndingRevision As String,
        <[Optional]> ByVal sAlternateFilter As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iItem_ItemRevExt As IItem_ItemRev = New Item_ItemRevFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iItem_ItemRevExt.Item_ItemRevSp(sTreeFilter, sStartingRevision, sEndingRevision, sAlternateFilter)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemAvailabilitySp(ByVal pSite As String, ByVal pItem As String, ByRef pQtyOnHandPhysical As Decimal?, ByRef pQtyOnHandAvailable As Decimal?, ByRef pQtyAllocCo As Decimal?, ByRef pQtyAllocMfg As Decimal?, ByRef pQtyOnOrder As Decimal?, ByRef pQtyWip As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemAvailabilityExt As IItemAvailability = New ItemAvailabilityFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, pQtyOnHandPhysical As Decimal?, pQtyOnHandAvailable As Decimal?, pQtyAllocCo As Decimal?,
                pQtyAllocMfg As Decimal?, pQtyOnOrder As Decimal?, pQtyWip As Decimal?, Infobar As String) = iItemAvailabilityExt.ItemAvailabilitySp(pSite, pItem, pQtyOnHandPhysical, pQtyOnHandAvailable, pQtyAllocCo, pQtyAllocMfg, pQtyOnOrder, pQtyWip, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pQtyOnHandPhysical = result.pQtyOnHandPhysical
            pQtyOnHandAvailable = result.pQtyOnHandAvailable
            pQtyAllocCo = result.pQtyAllocCo
            pQtyAllocMfg = result.pQtyAllocMfg
            pQtyOnOrder = result.pQtyOnOrder
            pQtyWip = result.pQtyWip
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemCopyDataSp(ByVal FromItem As String, ByVal NewItem As String, ByVal CopyUDF As Byte?, ByVal CopyLoc As Byte?, ByVal CopyBOM As Byte?, ByVal CopyBOMType As String, ByVal EffectDate As DateTime?, ByVal PlanFlag As Byte?, ByVal FeatStr As String,
<[Optional], DefaultParameterValue("C")> ByVal Process As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyUetValues As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemCopyDataExt As IItemCopyData = New ItemCopyDataFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemCopyDataExt.ItemCopyDataSp(FromItem, NewItem, CopyUDF, CopyLoc, CopyBOM, CopyBOMType, EffectDate, PlanFlag, FeatStr, Process, Infobar, CopyUetValues)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemEnableFormSp(ByRef use_wholesale_price As Integer?, ByRef use_backflush As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemEnableFormExt As IItemEnableForm = New ItemEnableFormFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, use_wholesale_price As Integer?, use_backflush As Integer?) = iItemEnableFormExt.ItemEnableFormSp(use_wholesale_price, use_backflush, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            use_wholesale_price = result.use_wholesale_price
            use_backflush = result.use_backflush
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemExtraInitSp(ByRef LotPrefix As String, ByRef LotTracked As Integer?, ByRef IssueBy As String, ByRef SerialTracked As Integer?, ByRef SerialPrefix As String, ByRef CostType As String, ByVal PSite As String, ByRef PreassignLots As Integer?, ByRef PreassignSerials As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemExtraInitExt As IItemExtraInit = New ItemExtraInitFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, LotPrefix As String, LotTracked As Integer?, IssueBy As String, SerialTracked As Integer?, SerialPrefix As String, CostType As String, PreassignLots As Integer?, PreassignSerials As Integer?) = iItemExtraInitExt.ItemExtraInitSp(LotPrefix, LotTracked, IssueBy, SerialTracked, SerialPrefix, CostType, PSite, PreassignLots, PreassignSerials)
            Dim Severity As Integer = result.ReturnCode.Value
            LotPrefix = result.LotPrefix
            LotTracked = result.LotTracked
            IssueBy = result.IssueBy
            SerialTracked = result.SerialTracked
            SerialPrefix = result.SerialPrefix
            CostType = result.CostType
            PreassignLots = result.PreassignLots
            PreassignSerials = result.PreassignSerials
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ItemOrCustItemLov(ByVal CIFlag As Integer?, ByVal CustNum As String, ByVal Item As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemOrCustItemLovExt As IItemOrCustItemLov = New ItemOrCustItemLovFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iItemOrCustItemLovExt.ItemOrCustItemLovSp(CIFlag, CustNum, Item)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemPreDisplaySp(ByRef CanUpdateRevTrack As Integer?, ByRef ApsParmApsmode As String, ByRef TrackTaxFreeimports As Integer?, ByRef RUserCode As String, ByRef POToleranceOver As Decimal?, ByRef POToleranceUnder As Decimal?, ByRef Vchrauthorize As Integer?, ByRef VchrOverPoCostTolerance As Decimal?, ByRef VchrUnderPoCostTolerance As Decimal?, ByRef use_wholesale_price As Integer?, ByRef use_backflush As Integer?, ByRef ConfigServerId As String, ByRef ConfigHeaderNameSpace As String, ByRef Configurator As String, ByRef ConfiguratorURL As String, ByRef ConfigDeploymentPath As String, ByRef AvailCfg As Integer?, ByRef AllowFcstBomSupplyItems As Integer?, ByRef Infobar As String,
<[Optional]> ByVal PSite As String,
<[Optional]> ByRef CostItemAtWhse As Integer?,
<[Optional]> ByRef LinearDimensionUM As String,
<[Optional]> ByRef DensityUM As String,
<[Optional]> ByRef AreaUM As String,
<[Optional]> ByRef BulkMassUM As String,
<[Optional]> ByRef ReamMassUM As String,
<[Optional]> ByRef LotPrefix As String,
<[Optional]> ByRef LotTracked As Integer?,
<[Optional]> ByRef IssueBy As String,
<[Optional]> ByRef SerialTracked As Integer?,
<[Optional]> ByRef SerialPrefix As String,
<[Optional]> ByRef CostType As String,
<[Optional]> ByRef PreassignLots As Integer?,
<[Optional]> ByRef PreassignSerials As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iItemPreDisplayExt As IItemPreDisplay = New ItemPreDisplayFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CanUpdateRevTrack As Integer?, ApsParmApsmode As String, TrackTaxFreeimports As Integer?, RUserCode As String, POToleranceOver As Decimal?, POToleranceUnder As Decimal?, Vchrauthorize As Integer?, VchrOverPoCostTolerance As Decimal?, VchrUnderPoCostTolerance As Decimal?, use_wholesale_price As Integer?, use_backflush As Integer?, ConfigServerId As String, ConfigHeaderNameSpace As String, Configurator As String, ConfiguratorURL As String, ConfigDeploymentPath As String, AvailCfg As Integer?, AllowFcstBomSupplyItems As Integer?, Infobar As String, CostItemAtWhse As Integer?, LinearDimensionUM As String, DensityUM As String, AreaUM As String, BulkMassUM As String, ReamMassUM As String, LotPrefix As String, LotTracked As Integer?, IssueBy As String, SerialTracked As Integer?, SerialPrefix As String, CostType As String, PreassignLots As Integer?, PreassignSerials As Integer?) = iItemPreDisplayExt.ItemPreDisplaySp(CanUpdateRevTrack, ApsParmApsmode, TrackTaxFreeimports, RUserCode, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, use_wholesale_price, use_backflush, ConfigServerId, ConfigHeaderNameSpace, Configurator, ConfiguratorURL, ConfigDeploymentPath, AvailCfg, AllowFcstBomSupplyItems, Infobar, PSite, CostItemAtWhse, LinearDimensionUM, DensityUM, AreaUM, BulkMassUM, ReamMassUM, LotPrefix, LotTracked, IssueBy, SerialTracked, SerialPrefix, CostType, PreassignLots, PreassignSerials)
            Dim Severity As Integer = result.ReturnCode.Value
            CanUpdateRevTrack = result.CanUpdateRevTrack
            ApsParmApsmode = result.ApsParmApsmode
            TrackTaxFreeimports = result.TrackTaxFreeimports
            RUserCode = result.RUserCode
            POToleranceOver = result.POToleranceOver
            POToleranceUnder = result.POToleranceUnder
            Vchrauthorize = result.Vchrauthorize
            VchrOverPoCostTolerance = result.VchrOverPoCostTolerance
            VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance
            use_wholesale_price = result.use_wholesale_price
            use_backflush = result.use_backflush
            ConfigServerId = result.ConfigServerId
            ConfigHeaderNameSpace = result.ConfigHeaderNameSpace
            Configurator = result.Configurator
            ConfiguratorURL = result.ConfiguratorURL
            ConfigDeploymentPath = result.ConfigDeploymentPath
            AvailCfg = result.AvailCfg
            AllowFcstBomSupplyItems = result.AllowFcstBomSupplyItems
            Infobar = result.Infobar
            CostItemAtWhse = result.CostItemAtWhse
            LinearDimensionUM = result.LinearDimensionUM
            DensityUM = result.DensityUM
            AreaUM = result.AreaUM
            BulkMassUM = result.BulkMassUM
            ReamMassUM = result.ReamMassUM
            LotPrefix = result.LotPrefix
            LotTracked = result.LotTracked
            IssueBy = result.IssueBy
            SerialTracked = result.SerialTracked
            SerialPrefix = result.SerialPrefix
            CostType = result.CostType
            PreassignLots = result.PreassignLots
            PreassignSerials = result.PreassignSerials
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemUMValidSp(ByVal PItem As String, ByRef PUM As String, ByRef UomConvFactor As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iItemUMValidExt As IItemUMValid = New ItemUMValidFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PUM As String, UomConvFactor As Decimal?, Inforbar As String) = iItemUMValidExt.ItemUMValidSp(PItem, PUM, UomConvFactor, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PUM = result.PUM
            UomConvFactor = result.UomConvFactor
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemPlanFlagSp(ByVal Item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemPlanFlagExt As IItemPlanFlag = New ItemPlanFlagFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemPlanFlagExt.ItemPlanFlagSp(Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LockJobItemsSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal QtyMoved As Decimal?,
    <[Optional], DefaultParameterValue(CByte(1))> ByVal Lock As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iLockJobItemsExt As ILockJobItems = New LockJobItemsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iLockJobItemsExt.LockJobItemsSp(Job, Suffix, OperNum, QtyMoved, Lock)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_UpdateAlternateDescSp(ByVal Job As String, ByVal JobSuffix As Integer?,
<[Optional]> ByVal AlternateDescription As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_UpdateAlternateDescExt As IMO_UpdateAlternateDesc = New MO_UpdateAlternateDescFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iMO_UpdateAlternateDescExt.MO_UpdateAlternateDescSp(Job, JobSuffix, AlternateDescription)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_ItemUMConvertSp(ByVal Length As Decimal?, ByVal Width As Decimal?, ByVal Density As Decimal?, ByVal BaseUM As String, ByVal LengthUM As String, ByVal DensityUM As String, ByVal PaperMassBasis As String, ByVal Item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_ItemUMConvertExt As IPP_ItemUMConvert = New PP_ItemUMConvertFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Inforbar As String) = iPP_ItemUMConvertExt.PP_ItemUMConvertSp(Length, Width, Density, BaseUM, LengthUM, DensityUM, PaperMassBasis, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PriceCalculationSp(ByVal pSite As String, ByVal pItem As String, ByVal pCustNum As String, ByVal pOrderDate As DateTime?, ByVal pQuantityOrdered As Decimal?, ByVal pUOM As String, ByRef pPrice As Decimal?, ByRef pCurrencyCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPriceCalculationExt As IPriceCalculation = New PriceCalculationFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, pPrice As Decimal?, pCurrencyCode As String, Infobar As String) = iPriceCalculationExt.PriceCalculationSp(pSite, pItem, pCustNum, pOrderDate, pQuantityOrdered, pUOM, pPrice, pCurrencyCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pPrice = result.pPrice
            pCurrencyCode = result.pCurrencyCode
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RebalItemQtyJobSp(ByRef Infobar As String,
        <[Optional]> ByVal StartingItem As String,
        <[Optional]> ByVal EndingItem As String,
        <[Optional]> ByVal StartingWhse As String,
        <[Optional]> ByVal EndingWhse As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRebalItemQtyJobExt As IRebalItemQtyJob = New RebalItemQtyJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Inforbar As String) = iRebalItemQtyJobExt.RebalItemQtyJobSp(Infobar, StartingItem, EndingItem, StartingWhse, EndingWhse)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateItemLocAcctSp(ByVal PItem As String, ByVal PItemProductCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateItemLocAcctExt As IUpdateItemLocAcct = New UpdateItemLocAcctFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Inforbar As String) = iUpdateItemLocAcctExt.UpdateItemLocAcctSp(PItem, PItemProductCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateProductCodeSp(ByRef ProductCode As String, ByVal Whse As String, ByRef Infobar As String,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateProductCodeExt As IValidateProductCode = New ValidateProductCodeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ProductCode As String, Infobar As String) = iValidateProductCodeExt.ValidateProductCodeSp(ProductCode, Whse, Infobar, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            ProductCode = result.ProductCode
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AccountingPeriodToSalesPeriodSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iAccountingPeriodToSalesPeriodExt As IAccountingPeriodToSalesPeriod = New AccountingPeriodToSalesPeriodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAccountingPeriodToSalesPeriodExt.AccountingPeriodToSalesPeriodSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetIndentedCurrentJobStructureSp(ByVal JobType As String, ByVal Job As String, ByVal Suffix As Integer?, ByRef Infobar As String) As DataTable
        Dim iGetIndentedCurrentJobStructureExt As IGetIndentedCurrentJobStructure = New GetIndentedCurrentJobStructureFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iGetIndentedCurrentJobStructureExt.GetIndentedCurrentJobStructureSp(JobType, Job, Suffix, Infobar)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Infobar = result.Infobar
        Return dt
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetTaxFreeDaysSp(ByVal ProdCode As String, ByRef TaxFreeDays As Integer?,
        <[Optional]> ByVal PSite As String) As Integer
        Dim iGetTaxFreeDaysExt As IGetTaxFreeDays = New GetTaxFreeDaysFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, TaxFreeDays As Integer?) = iGetTaxFreeDaysExt.GetTaxFreeDaysSp(ProdCode, TaxFreeDays, PSite)
        Dim Severity As Integer = result.ReturnCode.Value
        TaxFreeDays = result.TaxFreeDays
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetUnitPricingSp(ByVal CustNum As String, ByVal Item As String, ByRef UnitPrice As Decimal?, ByRef DiscPercent As Decimal?, ByRef DiscUnitPrice As Decimal?, ByRef Infobar As String,
        <[Optional]> ByRef ErrorMessage As String) As Integer
        Dim iGetUnitPricingExt As IGetUnitPricing = New GetUnitPricingFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, UnitPrice As Decimal?, DiscPercent As Decimal?, DiscUnitPrice As Decimal?, Infobar As String, ErrorMessage As String) = iGetUnitPricingExt.GetUnitPricingSp(CustNum, Item, UnitPrice, DiscPercent, DiscUnitPrice, Infobar, ErrorMessage)
        Dim Severity As Integer = result.ReturnCode.Value
        UnitPrice = result.UnitPrice
        DiscPercent = result.DiscPercent
        DiscUnitPrice = result.DiscUnitPrice
        Infobar = result.Infobar
        ErrorMessage = result.ErrorMessage
        Return Severity
    End Function
End Class
