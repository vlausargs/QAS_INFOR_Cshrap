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
Imports CSI.DataCollection
Imports CSI.Production
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLItemLocs")>
Public Class SLItemLocs
    Inherits CSIExtensionClassBase
    Implements IExtFTSLItemLocs

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs

        ' cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        ' NOTE:  IDOUpdateEventArgs has an additional property named 
        ' ActionMask.  This property will be set with one or more 
        ' of the following bit flags:
        '
        '   UpdateAction.Delete
        '   UpdateAction.Insert
        '   UpdateAction.Update
        '
        ' These flags indicate which items in the update request the framework 
        ' is processing on this call.  Typically, all the flags will be set 
        ' (UpdateAction.All), however, there are times when the framework will 
        ' do deletes, inserts and updates in separate calls 
        ' (for example, when processing nested updates). create a new 
        ' instance of the AppDB class for accessing the application database
        ' Create an array containing procedures to be called.

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Dim sMethodArray As Array
            Dim sMethodName As String
            sMethodArray = Split(appDB.GetSessionVariable("PostHandlerMethodVar"), "|")

            ' Cycle through that array calling each procedure.
            For Each sMethodName In sMethodArray
                Call DoProcessMethod(sMethodName)
            Next

            'Finally unset the PostHandlerMethodVar variable
            appDB.DeleteSessionVariable("PostHandlerMethodVar")
        End Using
    End Sub
    Private Function DoProcessMethod(ByVal sMethodName As String) As Integer
        Dim oResponse As InvokeResponseData
        DoProcessMethod = 0
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Select Case sMethodName.Trim
                    Case "SLItemLocs.istkrPostSaveSp"
                        Dim sInfobar As String
                        Dim sPWhseList As String
                        Dim sPItemList As String
                        Dim sPromptMsg As String

                        sPWhseList = appDB.GetSessionVariable("istkrPostSaveSp.PWhseList")
                        sPItemList = appDB.GetSessionVariable("istkrPostSaveSp.PItemList")
                        sInfobar = appDB.GetSessionVariable("istkrPostSaveSp.Infobar")
                        sPromptMsg = appDB.GetSessionVariable("istkrPostSaveSp.PromptMsg")

                        oResponse = Me.Invoke("istkrPostSaveSp", sPWhseList, sPItemList, sInfobar, sPromptMsg)
                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(2).Value)
                        Else
                            appDB.SetSessionVariable("istkrPostSaveSp.PromptMsg", oResponse.Parameters(3).Value)
                        End If
                End Select
            End Using
            DoProcessMethod = 0
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function
    Public Overrides Sub SetContext(ByVal context As _
    IIDOExtensionClassContext)

        MyBase.SetContext(context)
        ' Add event handlers
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf _
        Me.PostUpdateCollection

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ContainerMvPostSp(ByVal ContainNum As String,
                                      ByVal PType As String,
                                      ByVal PDate As DateTime?,
                                      ByVal FromWhse As String,
                                      ByVal ToWhse As String,
                                      ByVal ToLoc As String,
                                      ByVal PZeroCost As Byte?,
                                      ByVal PStat As String,
                                      ByRef Infobar As String) As Integer Implements IExtFTSLItemLocs.ContainerMvPostSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iContainerMvPostExt As IContainerMvPost = New ContainerMvPostFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iContainerMvPostExt.ContainerMvPostSp(ContainNum, PType, PDate, FromWhse, ToWhse, ToLoc, PZeroCost, PStat, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CycleGenerationSp(ByVal Whse As String,
                                      ByVal CycleType As String,
                                      ByVal MatlType As String,
                                      ByVal ABCCode As String,
                                      ByVal OverwriteRecords As Byte?,
                                      ByVal SortBy As String,
                                      ByVal PageBetween As Byte?,
                                      ByVal PrintCutoffQty As Byte?,
                                      ByVal FromItem As String,
                                      ByVal ToItem As String,
                                      ByVal FromLoc As String,
                                      ByVal ToLoc As String,
                                      ByVal FromProductCode As String,
                                      ByVal ToProductCode As String,
                                      ByVal FromPlanCode As String,
                                      ByVal ToPlanCode As String,
                                      ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCycleGenerationExt As ICycleGeneration = New CycleGenerationFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCycleGenerationExt.CycleGenerationSp(Whse, CycleType, MatlType, ABCCode, OverwriteRecords, SortBy, PageBetween, PrintCutoffQty, FromItem, ToItem, FromLoc, ToLoc, FromProductCode, ToProductCode, FromPlanCode, ToPlanCode, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetQtyOnHandSp(ByVal item As String,
                                   ByVal whse As String,
                                   ByRef QtyOnHand As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetQtyOnHandExt As IGetQtyOnHand = New GetQtyOnHandFactory().Create(appDb)

            Dim oQtyOnHand As QtyTotlType = QtyOnHand

            Dim Severity As Integer = iGetQtyOnHandExt.GetQtyOnHandSp(item, whse, oQtyOnHand)

            QtyOnHand = oQtyOnHand

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IaPostSetVarsSp(ByVal [SET] As String, ByVal TrxType As String, ByVal TransDate As DateTime?,
<[Optional]> ByVal Acct As String,
<[Optional]> ByVal AcctUnit1 As String,
<[Optional]> ByVal AcctUnit2 As String,
<[Optional]> ByVal AcctUnit3 As String,
<[Optional]> ByVal AcctUnit4 As String, ByVal TransQty As Decimal?, ByVal Whse As String, ByVal Item As String, ByVal Loc As String,
<[Optional]> ByVal Lot As String,
<[Optional]> ByVal FromSite As String,
<[Optional]> ByVal ToSite As String,
<[Optional]> ByVal ReasonCode As String,
<[Optional]> ByVal TrnNum As String,
<[Optional]> ByVal TrnLine As Short?,
<[Optional]> ByVal TransNum As Decimal?,
<[Optional]> ByVal RsvdNum As Decimal?,
<[Optional], DefaultParameterValue("I")> ByVal SerialStat As String,
<[Optional]> ByVal Workkey As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Override As Byte?,
<[Optional]> ByRef MatlCost As Decimal?,
<[Optional]> ByRef LbrCost As Decimal?,
<[Optional]> ByRef FovhdCost As Decimal?,
<[Optional]> ByRef VovhdCost As Decimal?,
<[Optional]> ByRef OutCost As Decimal?,
<[Optional]> ByRef TotalCost As Decimal?,
<[Optional]> ByRef ProfitMarkup As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal ToWhse As String,
<[Optional]> ByVal ToLoc As String,
<[Optional]> ByVal ToLot As String,
<[Optional]> ByVal TransferTrxType As String,
<[Optional]> ByVal TmpSerId As Guid?,
<[Optional]> ByVal UseExistingSerials As Byte?,
<[Optional]> ByVal SerialPrefix As String,
<[Optional]> ByVal RemoteSiteLot As String,
<[Optional]> ByVal DocumentNum As String,
<[Optional]> ByVal ImportDocId As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal MoveZeroCostItem As Byte?,
<[Optional]> ByVal EmpNum As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal SkipItemlocDelete As Byte?,
<[Optional]> ByVal FromSiteRecordDate As DateTime?,
<[Optional]> ByVal ToSiteRecordDate As DateTime?) As Integer Implements IExtFTSLItemLocs.IaPostSetVarsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iIaPostSetVarsExt As IIaPostSetVars = New IaPostSetVarsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, TotalCost As Decimal?, ProfitMarkup As Decimal?, Infobar As String) = iIaPostSetVarsExt.IaPostSetVarsSp([SET], TrxType, TransDate, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, TransQty, Whse, Item, Loc, Lot, FromSite, ToSite, ReasonCode, TrnNum, TrnLine, TransNum, RsvdNum, SerialStat, Workkey, Override, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, TotalCost, ProfitMarkup, Infobar, ToWhse, ToLoc, ToLot, TransferTrxType, TmpSerId, UseExistingSerials, SerialPrefix, RemoteSiteLot, DocumentNum, ImportDocId, MoveZeroCostItem, EmpNum, SkipItemlocDelete, FromSiteRecordDate, ToSiteRecordDate)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            TotalCost = result.TotalCost
            ProfitMarkup = result.ProfitMarkup
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemLocAddRemoteSp(ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal UcFlag As Byte?, ByVal UnitCost As Decimal?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal SetPermFlag As Byte?,
<[Optional]> ByVal Site As String, ByRef RowPointer As Guid?, ByRef Infobar As String) As Integer Implements IExtFTSLItemLocs.ItemLocAddRemoteSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iItemLocAddRemoteExt As IItemLocAddRemote = New ItemLocAddRemoteFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RowPointer As Guid?, Infobar As String) = iItemLocAddRemoteExt.ItemLocAddRemoteSp(Whse, Item, Loc, UcFlag, UnitCost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, SetPermFlag, Site, RowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RowPointer = result.RowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemlocDeleteMassSp(ByVal FromWhse As String, ByVal ToWhse As String, ByVal FromItem As String, ByVal ToItem As String, ByVal FromLoc As String, ByVal ToLoc As String, ByVal Quantity As Decimal?, ByVal DelPermLocs As Byte?, ByVal ReasonCode As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintDiagnostics As Byte?,
<[Optional], DefaultParameterValue(10000)> ByVal DeleteBlockSize As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemlocDeleteMassExt As IItemlocDeleteMass = New ItemlocDeleteMassFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemlocDeleteMassExt.ItemlocDeleteMassSp(FromWhse, ToWhse, FromItem, ToItem, FromLoc, ToLoc, Quantity, DelPermLocs, ReasonCode, Infobar, PrintDiagnostics, DeleteBlockSize)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MvPostSetVarsSp(ByVal [SET] As String, ByVal PType As String, ByVal PDate As DateTime?, ByVal PQty As Decimal?, ByVal PItem As String, ByVal FromWhse As String, ByVal FromLoc As String, ByVal FromLot As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal PZeroCost As Byte?, ByVal PTrnNum As String, ByVal PTrnLine As Short?, ByVal PTransNum As Decimal?, ByVal PRsvdNum As Decimal?, ByVal PStat As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PRefRelease As Short?,
<[Optional]> ByVal RefStr As String, ByRef PUnitCost As Decimal?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef PTotCost As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String,
<[Optional]> ByVal FromImportDocId As String,
<[Optional]> ByVal ToImportDocId As String,
<[Optional]> ByVal ReasonCode As String,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal FromSiteRecordDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMvPostSetVarsExt As IMvPostSetVars = New MvPostSetVarsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PUnitCost As Decimal?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, PTotCost As Decimal?, Infobar As String) = iMvPostSetVarsExt.MvPostSetVarsSp([SET], PType, PDate, PQty, PItem, FromWhse, FromLoc, FromLot, ToWhse, ToLoc, ToLot, PZeroCost, PTrnNum, PTrnLine, PTransNum, PRsvdNum, PStat, PRefNum, PRefLineSuf, PRefRelease, RefStr, PUnitCost, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, Infobar, DocumentNum, FromImportDocId, ToImportDocId, ReasonCode, EmpNum, FromSiteRecordDate)
            Dim Severity As Integer = result.ReturnCode.Value
            PUnitCost = result.PUnitCost
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            PTotCost = result.PTotCost
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostAdjTransWrapperSp(ByVal TrxType As String, ByVal TransDate As DateTime?,
<[Optional]> ByVal Acct As String,
<[Optional]> ByVal AcctUnit1 As String,
<[Optional]> ByVal AcctUnit2 As String,
<[Optional]> ByVal AcctUnit3 As String,
<[Optional]> ByVal AcctUnit4 As String, ByVal TransQty As Decimal?, ByVal Whse As String, ByVal Item As String, ByVal Loc As String,
<[Optional]> ByVal Lot As String,
<[Optional]> ByVal FromSite As String,
<[Optional]> ByVal ToSite As String,
<[Optional]> ByVal ReasonCode As String,
<[Optional]> ByVal TrnNum As String,
<[Optional]> ByVal TrnLine As Short?,
<[Optional]> ByVal TransNum As Decimal?,
<[Optional]> ByVal RsvdNum As Decimal?,
<[Optional], DefaultParameterValue("I")> ByVal SerialStat As String,
<[Optional]> ByVal Workkey As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Override As Byte?,
<[Optional]> ByRef MatlCost As Decimal?,
<[Optional]> ByRef LbrCost As Decimal?,
<[Optional]> ByRef FovhdCost As Decimal?,
<[Optional]> ByRef VovhdCost As Decimal?,
<[Optional]> ByRef OutCost As Decimal?,
<[Optional]> ByRef TotalCost As Decimal?,
<[Optional]> ByRef ProfitMarkup As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal ToWhse As String,
<[Optional]> ByVal ToLoc As String,
<[Optional]> ByVal ToLot As String,
<[Optional]> ByVal TransferTrxType As String,
<[Optional]> ByVal TmpSerId As Guid?,
<[Optional]> ByVal UseExistingSerials As Byte?,
<[Optional]> ByVal SerialPrefix As String,
<[Optional]> ByVal RemoteSiteLot As String,
<[Optional]> ByVal DocumentNum As String,
<[Optional]> ByVal ImportDocId As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal MoveZeroCostItem As Byte?,
<[Optional], DefaultParameterValue(0)> ByVal DropDeferred As Integer?,
<[Optional]> ByRef PromptMsg As String,
<[Optional]> ByRef PromptButtons As String) As Integer Implements IExtFTSLItemLocs.PostAdjTransWrapperSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPostAdjTransWrapperExt As IPostAdjTransWrapper = New PostAdjTransWrapperFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, TotalCost As Decimal?, ProfitMarkup As Decimal?, Infobar As String, PromptMsg As String, PromptButtons As String) = iPostAdjTransWrapperExt.PostAdjTransWrapperSp(TrxType, TransDate, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, TransQty, Whse, Item, Loc, Lot, FromSite, ToSite, ReasonCode, TrnNum, TrnLine, TransNum, RsvdNum, SerialStat, Workkey, Override, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, TotalCost, ProfitMarkup, Infobar, ToWhse, ToLoc, ToLot, TransferTrxType, TmpSerId, UseExistingSerials, SerialPrefix, RemoteSiteLot, DocumentNum, ImportDocId, MoveZeroCostItem, DropDeferred, PromptMsg, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            TotalCost = result.TotalCost
            ProfitMarkup = result.ProfitMarkup
            Infobar = result.Infobar
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateNonNettableItemLoc(ByVal Item As String,
                                               ByVal Whse As String,
                                               ByVal Loc As String,
                                               ByVal TcQtuToReceive As Decimal?,
                                               ByVal TtRcvDrReturn As Byte?,
                                               ByRef PromptMsg As String,
                                               ByRef PromptButtons As String,
                                               ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateNonNettableItemLocExt As IValidateNonNettableItemLoc = New ValidateNonNettableItemLocFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iValidateNonNettableItemLocExt.ValidateNonNettableItemLocSp(Item, Whse, Loc, TcQtuToReceive, TtRcvDrReturn, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemMiscReceiptSetVarsSp(ByVal [SET] As String, ByVal P_Item As String, ByVal P_Whse As String, ByVal P_Qty As Decimal?, ByVal P_UM As String, ByVal P_MatlCost As Decimal?, ByVal P_LbrCost As Decimal?, ByVal P_FovhdCost As Decimal?, ByVal P_VovhdCost As Decimal?, ByVal P_OutCost As Decimal?, ByVal P_UnitCost As Decimal?, ByVal P_Loc As String, ByVal P_Lot As String, ByVal P_Reason As String, ByVal P_Acct As String, ByVal P_AcctUnit1 As String, ByVal P_AcctUnit2 As String, ByVal P_AcctUnit3 As String, ByVal P_AcctUnit4 As String, ByVal P_TransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String, ByVal P_ImportDocId As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal UMVendNum As String,
<[Optional]> ByVal UMArea As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemMiscReceiptSetVarsExt As IItemMiscReceiptSetVars = New ItemMiscReceiptSetVarsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemMiscReceiptSetVarsExt.ItemMiscReceiptSetVarsSp([SET], P_Item, P_Whse, P_Qty, P_UM, P_MatlCost, P_LbrCost, P_FovhdCost, P_VovhdCost, P_OutCost, P_UnitCost, P_Loc, P_Lot, P_Reason, P_Acct, P_AcctUnit1, P_AcctUnit2, P_AcctUnit3, P_AcctUnit4, P_TransDate, Infobar, DocumentNum, P_ImportDocId, ContainerNum, UMVendNum, UMArea)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetMethodSp(ByVal MethodValInput As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSetMethodExt As ISetMethod = New SetMethodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSetMethodExt.SetMethodSp(MethodValInput)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SlocValidSp(ByVal Item As String, ByVal Whse As String, ByVal Loc As String, ByRef Lot As String, ByRef Infobar As String, ByRef ImportDocId As String) As Integer Implements IExtFTSLItemLocs.SlocValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSlocValidExt As ISlocValid = New SlocValidFactory().Create(appDb)
            Dim Severity As Integer = iSlocValidExt.SlocValidSp(Item, Whse, Loc, Lot, Infobar, ImportDocId)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemLocAddSp(ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal UcFlag As Byte?, ByVal UnitCost As Decimal?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal SetPermFlag As Byte?, ByRef RowPointer As Guid?, ByRef Infobar As String,
<[Optional]> ByVal PermFlagValue As Byte?,
<[Optional]> ByVal MrbFlagValue As Byte?,
<[Optional]> ByVal locMrbFlag As Byte?,
<[Optional]> ByVal locLocType As String,
<[Optional]> ByVal locWC As String) As Integer Implements IExtFTSLItemLocs.ItemLocAddSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iItemLocAddExt As IItemLocAdd = New ItemLocAddFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RowPointer As Guid?, Infobar As String) = iItemLocAddExt.ItemLocAddSp(Whse, Item, Loc, UcFlag, UnitCost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, SetPermFlag, RowPointer, Infobar, PermFlagValue, MrbFlagValue, locMrbFlag, locLocType, locWC)
            Dim Severity As Integer = result.ReturnCode.Value
            RowPointer = result.RowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemlocValidateSp(ByVal Item As String, ByVal Whse As String, ByVal Loc As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal VerifyAccounts As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CheckUserAccount As Byte?,
<[Optional]> ByVal UserAcct As String, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal Outgoing As Byte?,
<[Optional]> ByRef ItemQtyOnHand As Decimal?,
<[Optional]> ByVal OldLoc As String,
<[Optional]> ByVal CoNum As String,
<[Optional]> ByVal CoLine As Short?,
<[Optional]> ByVal CoRelease As Short?,
<[Optional]> ByVal Lot As String) As Integer Implements IExtFTSLItemLocs.ItemlocValidateSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemlocValidateExt As IItemlocValidate = New ItemlocValidateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String, ItemQtyOnHand As Decimal?) = iItemlocValidateExt.ItemlocValidateSp(Item, Whse, Loc, VerifyAccounts, CheckUserAccount, UserAcct, Infobar, Prompt, PromptButtons, Outgoing, ItemQtyOnHand, OldLoc, CoNum, CoLine, CoRelease, Lot)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            ItemQtyOnHand = result.ItemQtyOnHand
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_EmptyStockroomLocsSp(
<[Optional]> ByVal FilterString As String,
<[Optional]> ByVal PSiteGroup As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_EmptyStockroomLocsExt As ICLM_EmptyStockroomLocs = New CLM_EmptyStockroomLocsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_EmptyStockroomLocsExt.CLM_EmptyStockroomLocsSp(FilterString, PSiteGroup)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetValLoc(
<[Optional]> ByVal Whse As String,
<[Optional]> ByVal Item As String,
<[Optional]> ByVal LocType As String,
<[Optional]> ByVal Loc As String,
<[Optional]> ByRef EnableNonNet As Byte?, ByRef InvAcct As String, ByRef InvAcctUnit1 As String, ByRef InvAcctUnit2 As String, ByRef InvAcctUnit3 As String, ByRef InvAcctUnit4 As String, ByRef InvAcctAccessUnit1 As String, ByRef InvAcctAccessUnit2 As String, ByRef InvAcctAccessUnit3 As String, ByRef InvAcctAccessUnit4 As String, ByRef InvAcctDesc As String, ByRef LbrAcct As String, ByRef LbrAcctUnit1 As String, ByRef LbrAcctUnit2 As String, ByRef lbrAcctUnit3 As String, ByRef LbrAcctUnit4 As String, ByRef LbrAcctAccessUnit1 As String, ByRef LbrAcctAccessUnit2 As String, ByRef LbrAcctAccessUnit3 As String, ByRef LbrAcctAccessUnit4 As String, ByRef LbrAcctDesc As String, ByRef FovhdAcct As String, ByRef FovhdAcctUnit1 As String, ByRef FovhdAcctUnit2 As String, ByRef FovhdAcctUnit3 As String, ByRef FovhdAcctUnit4 As String, ByRef FovhdAcctAccessUnit1 As String, ByRef FovhdAcctAccessUnit2 As String, ByRef FovhdAcctAccessUnit3 As String, ByRef FovhdAcctAccessUnit4 As String, ByRef FovhdAcctDesc As String, ByRef VovhdAcct As String, ByRef VovhdAcctUnit1 As String, ByRef VovhdAcctUnit2 As String, ByRef VovhdAcctUnit3 As String, ByRef VovhdAcctUnit4 As String, ByRef VovhdAcctAccessUnit1 As String, ByRef VovhdAcctAccessUnit2 As String, ByRef VovhdAcctAccessUnit3 As String, ByRef VovhdAcctAccessUnit4 As String, ByRef VovhdAcctDesc As String, ByRef OutAcct As String, ByRef OutAcctUnit1 As String, ByRef OutAcctUnit2 As String, ByRef OutAcctUnit3 As String, ByRef OutAcctUnit4 As String, ByRef OutAcctAccessUnit1 As String, ByRef OutAcctAccessUnit2 As String, ByRef OutAcctAccessUnit3 As String, ByRef OutAcctAccessUnit4 As String, ByRef OutAcctDesc As String, ByVal Action As String,
<[Optional]> ByRef Infobar As String, ByRef IPInvAcct As String, ByRef IPInvAcctUnit1 As String, ByRef IPInvAcctUnit2 As String, ByRef IPInvAcctUnit3 As String, ByRef IPInvAcctUnit4 As String, ByRef IPInvAcctAccessUnit1 As String, ByRef IPInvAcctAccessUnit2 As String, ByRef IPInvAcctAccessUnit3 As String, ByRef IPInvAcctAccessUnit4 As String, ByRef IPInvAcctDesc As String, ByRef IPLbrAcct As String, ByRef IPLbrAcctUnit1 As String, ByRef IPLbrAcctUnit2 As String, ByRef IPLbrAcctUnit3 As String, ByRef IPLbrAcctUnit4 As String, ByRef IPLbrAcctAccessUnit1 As String, ByRef IPLbrAcctAccessUnit2 As String, ByRef IPLbrAcctAccessUnit3 As String, ByRef IPLbrAcctAccessUnit4 As String, ByRef IPLbrAcctDesc As String, ByRef IPFovhdAcct As String, ByRef IPFovhdAcctUnit1 As String, ByRef IPFovhdAcctUnit2 As String, ByRef IPFovhdAcctUnit3 As String, ByRef IPFovhdAcctUnit4 As String, ByRef IPFovhdAcctAccessUnit1 As String, ByRef IPFovhdAcctAccessUnit2 As String, ByRef IPFovhdAcctAccessUnit3 As String, ByRef IPFovhdAcctAccessUnit4 As String, ByRef IPFovhdAcctDesc As String, ByRef IPVovhdAcct As String, ByRef IPVovhdAcctUnit1 As String, ByRef IPVovhdAcctUnit2 As String, ByRef IPVovhdAcctUnit3 As String, ByRef IPVovhdAcctUnit4 As String, ByRef IPVovhdAcctAccessUnit1 As String, ByRef IPVovhdAcctAccessUnit2 As String, ByRef IPVovhdAcctAccessUnit3 As String, ByRef IPVovhdAcctAccessUnit4 As String, ByRef IPVovhdAcctDesc As String, ByRef IPOutAcct As String, ByRef IPOutAcctUnit1 As String, ByRef IPOutAcctUnit2 As String, ByRef IPOutAcctUnit3 As String, ByRef IPOutAcctUnit4 As String, ByRef IPOutAcctAccessUnit1 As String, ByRef IPOutAcctAccessUnit2 As String, ByRef IPOutAcctAccessUnit3 As String, ByRef IPOutAcctAccessUnit4 As String, ByRef IPOutAcctDesc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrGetValLocExt As IistkrGetValLoc = New istkrGetValLocFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, EnableNonNet As Byte?, InvAcct As String, InvAcctUnit1 As String, InvAcctUnit2 As String, InvAcctUnit3 As String, InvAcctUnit4 As String, InvAcctAccessUnit1 As String, InvAcctAccessUnit2 As String, InvAcctAccessUnit3 As String, InvAcctAccessUnit4 As String, InvAcctDesc As String, LbrAcct As String, LbrAcctUnit1 As String, LbrAcctUnit2 As String, lbrAcctUnit3 As String, LbrAcctUnit4 As String, LbrAcctAccessUnit1 As String, LbrAcctAccessUnit2 As String, LbrAcctAccessUnit3 As String, LbrAcctAccessUnit4 As String, LbrAcctDesc As String, FovhdAcct As String, FovhdAcctUnit1 As String, FovhdAcctUnit2 As String, FovhdAcctUnit3 As String, FovhdAcctUnit4 As String, FovhdAcctAccessUnit1 As String, FovhdAcctAccessUnit2 As String, FovhdAcctAccessUnit3 As String, FovhdAcctAccessUnit4 As String, FovhdAcctDesc As String, VovhdAcct As String, VovhdAcctUnit1 As String, VovhdAcctUnit2 As String, VovhdAcctUnit3 As String, VovhdAcctUnit4 As String, VovhdAcctAccessUnit1 As String, VovhdAcctAccessUnit2 As String, VovhdAcctAccessUnit3 As String, VovhdAcctAccessUnit4 As String, VovhdAcctDesc As String, OutAcct As String, OutAcctUnit1 As String, OutAcctUnit2 As String, OutAcctUnit3 As String, OutAcctUnit4 As String, OutAcctAccessUnit1 As String, OutAcctAccessUnit2 As String, OutAcctAccessUnit3 As String, OutAcctAccessUnit4 As String, OutAcctDesc As String, Infobar As String, IPInvAcct As String, IPInvAcctUnit1 As String, IPInvAcctUnit2 As String, IPInvAcctUnit3 As String, IPInvAcctUnit4 As String, IPInvAcctAccessUnit1 As String, IPInvAcctAccessUnit2 As String, IPInvAcctAccessUnit3 As String, IPInvAcctAccessUnit4 As String, IPInvAcctDesc As String, IPLbrAcct As String, IPLbrAcctUnit1 As String, IPLbrAcctUnit2 As String, IPLbrAcctUnit3 As String, IPLbrAcctUnit4 As String, IPLbrAcctAccessUnit1 As String, IPLbrAcctAccessUnit2 As String, IPLbrAcctAccessUnit3 As String, IPLbrAcctAccessUnit4 As String, IPLbrAcctDesc As String, IPFovhdAcct As String, IPFovhdAcctUnit1 As String, IPFovhdAcctUnit2 As String, IPFovhdAcctUnit3 As String, IPFovhdAcctUnit4 As String, IPFovhdAcctAccessUnit1 As String, IPFovhdAcctAccessUnit2 As String, IPFovhdAcctAccessUnit3 As String, IPFovhdAcctAccessUnit4 As String, IPFovhdAcctDesc As String, IPVovhdAcct As String, IPVovhdAcctUnit1 As String, IPVovhdAcctUnit2 As String, IPVovhdAcctUnit3 As String, IPVovhdAcctUnit4 As String, IPVovhdAcctAccessUnit1 As String, IPVovhdAcctAccessUnit2 As String, IPVovhdAcctAccessUnit3 As String, IPVovhdAcctAccessUnit4 As String, IPVovhdAcctDesc As String, IPOutAcct As String, IPOutAcctUnit1 As String, IPOutAcctUnit2 As String, IPOutAcctUnit3 As String, IPOutAcctUnit4 As String, IPOutAcctAccessUnit1 As String, IPOutAcctAccessUnit2 As String, IPOutAcctAccessUnit3 As String, IPOutAcctAccessUnit4 As String, IPOutAcctDesc As String) = iistkrGetValLocExt.istkrGetValLocSp(Whse, Item, LocType, Loc, EnableNonNet, InvAcct, InvAcctUnit1, InvAcctUnit2, InvAcctUnit3, InvAcctUnit4, InvAcctAccessUnit1, InvAcctAccessUnit2, InvAcctAccessUnit3, InvAcctAccessUnit4, InvAcctDesc, LbrAcct, LbrAcctUnit1, LbrAcctUnit2, lbrAcctUnit3, LbrAcctUnit4, LbrAcctAccessUnit1, LbrAcctAccessUnit2, LbrAcctAccessUnit3, LbrAcctAccessUnit4, LbrAcctDesc, FovhdAcct, FovhdAcctUnit1, FovhdAcctUnit2, FovhdAcctUnit3, FovhdAcctUnit4, FovhdAcctAccessUnit1, FovhdAcctAccessUnit2, FovhdAcctAccessUnit3, FovhdAcctAccessUnit4, FovhdAcctDesc, VovhdAcct, VovhdAcctUnit1, VovhdAcctUnit2, VovhdAcctUnit3, VovhdAcctUnit4, VovhdAcctAccessUnit1, VovhdAcctAccessUnit2, VovhdAcctAccessUnit3, VovhdAcctAccessUnit4, VovhdAcctDesc, OutAcct, OutAcctUnit1, OutAcctUnit2, OutAcctUnit3, OutAcctUnit4, OutAcctAccessUnit1, OutAcctAccessUnit2, OutAcctAccessUnit3, OutAcctAccessUnit4, OutAcctDesc, Action, Infobar, IPInvAcct, IPInvAcctUnit1, IPInvAcctUnit2, IPInvAcctUnit3, IPInvAcctUnit4, IPInvAcctAccessUnit1, IPInvAcctAccessUnit2, IPInvAcctAccessUnit3, IPInvAcctAccessUnit4, IPInvAcctDesc, IPLbrAcct, IPLbrAcctUnit1, IPLbrAcctUnit2, IPLbrAcctUnit3, IPLbrAcctUnit4, IPLbrAcctAccessUnit1, IPLbrAcctAccessUnit2, IPLbrAcctAccessUnit3, IPLbrAcctAccessUnit4, IPLbrAcctDesc, IPFovhdAcct, IPFovhdAcctUnit1, IPFovhdAcctUnit2, IPFovhdAcctUnit3, IPFovhdAcctUnit4, IPFovhdAcctAccessUnit1, IPFovhdAcctAccessUnit2, IPFovhdAcctAccessUnit3, IPFovhdAcctAccessUnit4, IPFovhdAcctDesc, IPVovhdAcct, IPVovhdAcctUnit1, IPVovhdAcctUnit2, IPVovhdAcctUnit3, IPVovhdAcctUnit4, IPVovhdAcctAccessUnit1, IPVovhdAcctAccessUnit2, IPVovhdAcctAccessUnit3, IPVovhdAcctAccessUnit4, IPVovhdAcctDesc, IPOutAcct, IPOutAcctUnit1, IPOutAcctUnit2, IPOutAcctUnit3, IPOutAcctUnit4, IPOutAcctAccessUnit1, IPOutAcctAccessUnit2, IPOutAcctAccessUnit3, IPOutAcctAccessUnit4, IPOutAcctDesc)
            Dim Severity As Integer = result.ReturnCode.Value
            EnableNonNet = result.EnableNonNet
            InvAcct = result.InvAcct
            InvAcctUnit1 = result.InvAcctUnit1
            InvAcctUnit2 = result.InvAcctUnit2
            InvAcctUnit3 = result.InvAcctUnit3
            InvAcctUnit4 = result.InvAcctUnit4
            InvAcctAccessUnit1 = result.InvAcctAccessUnit1
            InvAcctAccessUnit2 = result.InvAcctAccessUnit2
            InvAcctAccessUnit3 = result.InvAcctAccessUnit3
            InvAcctAccessUnit4 = result.InvAcctAccessUnit4
            InvAcctDesc = result.InvAcctDesc
            LbrAcct = result.LbrAcct
            LbrAcctUnit1 = result.LbrAcctUnit1
            LbrAcctUnit2 = result.LbrAcctUnit2
            lbrAcctUnit3 = result.lbrAcctUnit3
            LbrAcctUnit4 = result.LbrAcctUnit4
            LbrAcctAccessUnit1 = result.LbrAcctAccessUnit1
            LbrAcctAccessUnit2 = result.LbrAcctAccessUnit2
            LbrAcctAccessUnit3 = result.LbrAcctAccessUnit3
            LbrAcctAccessUnit4 = result.LbrAcctAccessUnit4
            LbrAcctDesc = result.LbrAcctDesc
            FovhdAcct = result.FovhdAcct
            FovhdAcctUnit1 = result.FovhdAcctUnit1
            FovhdAcctUnit2 = result.FovhdAcctUnit2
            FovhdAcctUnit3 = result.FovhdAcctUnit3
            FovhdAcctUnit4 = result.FovhdAcctUnit4
            FovhdAcctAccessUnit1 = result.FovhdAcctAccessUnit1
            FovhdAcctAccessUnit2 = result.FovhdAcctAccessUnit2
            FovhdAcctAccessUnit3 = result.FovhdAcctAccessUnit3
            FovhdAcctAccessUnit4 = result.FovhdAcctAccessUnit4
            FovhdAcctDesc = result.FovhdAcctDesc
            VovhdAcct = result.VovhdAcct
            VovhdAcctUnit1 = result.VovhdAcctUnit1
            VovhdAcctUnit2 = result.VovhdAcctUnit2
            VovhdAcctUnit3 = result.VovhdAcctUnit3
            VovhdAcctUnit4 = result.VovhdAcctUnit4
            VovhdAcctAccessUnit1 = result.VovhdAcctAccessUnit1
            VovhdAcctAccessUnit2 = result.VovhdAcctAccessUnit2
            VovhdAcctAccessUnit3 = result.VovhdAcctAccessUnit3
            VovhdAcctAccessUnit4 = result.VovhdAcctAccessUnit4
            VovhdAcctDesc = result.VovhdAcctDesc
            OutAcct = result.OutAcct
            OutAcctUnit1 = result.OutAcctUnit1
            OutAcctUnit2 = result.OutAcctUnit2
            OutAcctUnit3 = result.OutAcctUnit3
            OutAcctUnit4 = result.OutAcctUnit4
            OutAcctAccessUnit1 = result.OutAcctAccessUnit1
            OutAcctAccessUnit2 = result.OutAcctAccessUnit2
            OutAcctAccessUnit3 = result.OutAcctAccessUnit3
            OutAcctAccessUnit4 = result.OutAcctAccessUnit4
            OutAcctDesc = result.OutAcctDesc
            Infobar = result.Infobar
            IPInvAcct = result.IPInvAcct
            IPInvAcctUnit1 = result.IPInvAcctUnit1
            IPInvAcctUnit2 = result.IPInvAcctUnit2
            IPInvAcctUnit3 = result.IPInvAcctUnit3
            IPInvAcctUnit4 = result.IPInvAcctUnit4
            IPInvAcctAccessUnit1 = result.IPInvAcctAccessUnit1
            IPInvAcctAccessUnit2 = result.IPInvAcctAccessUnit2
            IPInvAcctAccessUnit3 = result.IPInvAcctAccessUnit3
            IPInvAcctAccessUnit4 = result.IPInvAcctAccessUnit4
            IPInvAcctDesc = result.IPInvAcctDesc
            IPLbrAcct = result.IPLbrAcct
            IPLbrAcctUnit1 = result.IPLbrAcctUnit1
            IPLbrAcctUnit2 = result.IPLbrAcctUnit2
            IPLbrAcctUnit3 = result.IPLbrAcctUnit3
            IPLbrAcctUnit4 = result.IPLbrAcctUnit4
            IPLbrAcctAccessUnit1 = result.IPLbrAcctAccessUnit1
            IPLbrAcctAccessUnit2 = result.IPLbrAcctAccessUnit2
            IPLbrAcctAccessUnit3 = result.IPLbrAcctAccessUnit3
            IPLbrAcctAccessUnit4 = result.IPLbrAcctAccessUnit4
            IPLbrAcctDesc = result.IPLbrAcctDesc
            IPFovhdAcct = result.IPFovhdAcct
            IPFovhdAcctUnit1 = result.IPFovhdAcctUnit1
            IPFovhdAcctUnit2 = result.IPFovhdAcctUnit2
            IPFovhdAcctUnit3 = result.IPFovhdAcctUnit3
            IPFovhdAcctUnit4 = result.IPFovhdAcctUnit4
            IPFovhdAcctAccessUnit1 = result.IPFovhdAcctAccessUnit1
            IPFovhdAcctAccessUnit2 = result.IPFovhdAcctAccessUnit2
            IPFovhdAcctAccessUnit3 = result.IPFovhdAcctAccessUnit3
            IPFovhdAcctAccessUnit4 = result.IPFovhdAcctAccessUnit4
            IPFovhdAcctDesc = result.IPFovhdAcctDesc
            IPVovhdAcct = result.IPVovhdAcct
            IPVovhdAcctUnit1 = result.IPVovhdAcctUnit1
            IPVovhdAcctUnit2 = result.IPVovhdAcctUnit2
            IPVovhdAcctUnit3 = result.IPVovhdAcctUnit3
            IPVovhdAcctUnit4 = result.IPVovhdAcctUnit4
            IPVovhdAcctAccessUnit1 = result.IPVovhdAcctAccessUnit1
            IPVovhdAcctAccessUnit2 = result.IPVovhdAcctAccessUnit2
            IPVovhdAcctAccessUnit3 = result.IPVovhdAcctAccessUnit3
            IPVovhdAcctAccessUnit4 = result.IPVovhdAcctAccessUnit4
            IPVovhdAcctDesc = result.IPVovhdAcctDesc
            IPOutAcct = result.IPOutAcct
            IPOutAcctUnit1 = result.IPOutAcctUnit1
            IPOutAcctUnit2 = result.IPOutAcctUnit2
            IPOutAcctUnit3 = result.IPOutAcctUnit3
            IPOutAcctUnit4 = result.IPOutAcctUnit4
            IPOutAcctAccessUnit1 = result.IPOutAcctAccessUnit1
            IPOutAcctAccessUnit2 = result.IPOutAcctAccessUnit2
            IPOutAcctAccessUnit3 = result.IPOutAcctAccessUnit3
            IPOutAcctAccessUnit4 = result.IPOutAcctAccessUnit4
            IPOutAcctDesc = result.IPOutAcctDesc
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostSaveSetVarsSp(ByVal [SET] As String, ByVal PWhseList As String, ByVal PItemList As String, ByRef Infobar As String,
<[Optional]> ByRef PromptMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrPostSaveSetVarsExt As IistkrPostSaveSetVars = New istkrPostSaveSetVarsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, PromptMsg As String) = iistkrPostSaveSetVarsExt.istkrPostSaveSetVarsSp([SET], PWhseList, PItemList, Infobar, PromptMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PromptMsg = result.PromptMsg
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PreAddUpdValidation(
<[Optional]> ByVal Whse As String,
<[Optional]> ByVal Item As String,
<[Optional], DefaultParameterValue("@%add")> ByVal Action As String, ByVal ShowCost As Byte?,
<[Optional], DefaultParameterValue(0)> ByRef ItmMatlCost As Decimal?,
<[Optional], DefaultParameterValue(0)> ByRef ItmLbrCost As Decimal?,
<[Optional], DefaultParameterValue(0)> ByRef ItmFovhdCost As Decimal?,
<[Optional], DefaultParameterValue(0)> ByRef ItmVovhdCost As Decimal?,
<[Optional], DefaultParameterValue(0)> ByRef ItmOutCost As Decimal?,
<[Optional]> ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef Buttons As String, ByRef NextRank As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrPreAddUpdValExt As IistkrPreAddUpdVal = New istkrPreAddUpdValFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ItmMatlCost As Decimal?, ItmLbrCost As Decimal?, ItmFovhdCost As Decimal?, ItmVovhdCost As Decimal?, ItmOutCost As Decimal?, Infobar As String, Prompt As String, Buttons As String, NextRank As Short?) = iistkrPreAddUpdValExt.istkrPreAddUpdValSp(Whse, Item, Action, ShowCost, ItmMatlCost, ItmLbrCost, ItmFovhdCost, ItmVovhdCost, ItmOutCost, Infobar, Prompt, Buttons, NextRank)
            Dim Severity As Integer = result.ReturnCode.Value
            ItmMatlCost = result.ItmMatlCost
            ItmLbrCost = result.ItmLbrCost
            ItmFovhdCost = result.ItmFovhdCost
            ItmVovhdCost = result.ItmVovhdCost
            ItmOutCost = result.ItmOutCost
            Infobar = result.Infobar
            Prompt = result.Prompt
            Buttons = result.Buttons
            NextRank = result.NextRank
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PreDelete(ByVal PWhse As String, ByVal PItem As String, ByVal PRank As Short?,
<[Optional]> ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef Buttons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrPreDeleteExt As IistkrPreDelete = New istkrPreDeleteFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, Buttons As String) = iistkrPreDeleteExt.istkrPreDeleteSp(PWhse, PItem, PRank, Infobar, Prompt, Buttons)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Prompt = result.Prompt
            Buttons = result.Buttons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RecalculateCosts(ByVal Item As String, ByVal UM As String, ByRef QtyOnHand As Decimal?, ByRef MatlCost As Decimal?, ByRef LbrCost As Decimal?, ByRef FovhdCost As Decimal?, ByRef VovhdCost As Decimal?, ByRef OutCost As Decimal?, ByVal WarnIfSlowMoving As Byte?, ByVal ErrorIfSlowMoving As Byte?, ByVal WarnIfObsolete As Byte?, ByVal ErrorIfObsolete As Byte?, ByRef Infobar As String, ByRef Prompt As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrRecalculateCostsExt As IistkrRecalculateCosts = New istkrRecalculateCostsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, QtyOnHand As Decimal?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, Infobar As String, Prompt As String, PromptButtons As String) = iistkrRecalculateCostsExt.istkrRecalculateCostsSp(Item, UM, QtyOnHand, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, WarnIfSlowMoving, ErrorIfSlowMoving, WarnIfObsolete, ErrorIfObsolete, Infobar, Prompt, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            QtyOnHand = result.QtyOnHand
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetSessionVars(ByVal PUM As String, ByVal PTrnDate As DateTime?, ByVal PTrnReasonCode As String, ByVal PTrnInvAdjAcct As String, ByVal PTrnInvAdjAcctUnit1 As String, ByVal PTrnInvAdjAcctUnit2 As String, ByVal PTrnInvAdjAcctUnit3 As String, ByVal PTrnInvAdjAcctUnit4 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrSetSessionVarsExt As IistkrSetSessionVars = New istkrSetSessionVarsFactory().Create(appDb)
            Dim result As Integer? = iistkrSetSessionVarsExt.istkrSetSessionVarsSp(PUM, PTrnDate, PTrnReasonCode, PTrnInvAdjAcct, PTrnInvAdjAcctUnit1, PTrnInvAdjAcctUnit2, PTrnInvAdjAcctUnit3, PTrnInvAdjAcctUnit4)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValItemlocRank(ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal LocType As String, ByVal NewRank As Short?, ByVal NewCount As Integer?, ByVal Action As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrValItemlocRankExt As IistkrValItemlocRank = New istkrValItemlocRankFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iistkrValItemlocRankExt.istkrValItemlocRankSp(Whse, Item, Loc, LocType, NewRank, NewCount, Action, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValMrb(ByVal PItem As String, ByVal PMrbFlag As Byte?, ByVal PLoc As String, ByVal PWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iistkrValMrbExt As IistkrValMrb = New istkrValMrbFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iistkrValMrbExt.istkrValMrbSp(PItem, PMrbFlag, PLoc, PWhse, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function istkrPostSaveSp(ByVal PWhseList As String, ByVal PItemList As String, ByRef Infobar As String, ByRef PromptMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iistkrPostSaveExt As IistkrPostSave = New istkrPostSaveFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, PromptMsg As String) = iistkrPostSaveExt.istkrPostSaveSp(PWhseList, PItemList, Infobar, PromptMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PromptMsg = result.PromptMsg
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostSave(ByVal PWhseList As String, ByVal PItemList As String, ByRef Infobar As String, ByRef PromptMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iistkrPostSaveExt As IistkrPostSave = New istkrPostSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, PromptMsg As String) = iistkrPostSaveExt.istkrPostSaveSp(PWhseList, PItemList, Infobar, PromptMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PromptMsg = result.PromptMsg
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MvPostSp(ByVal PType As String, ByVal PDate As DateTime?, ByVal PQty As Decimal?, ByVal PItem As String, ByVal FromWhse As String, ByVal FromLoc As String, ByVal FromLot As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal PZeroCost As Byte?, ByVal PTrnNum As String, ByVal PTrnLine As Short?, ByVal PTransNum As Decimal?, ByVal PRsvdNum As Decimal?, ByVal PStat As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PRefRelease As Short?,
<[Optional]> ByVal RefStr As String, ByRef PUnitCost As Decimal?, ByRef PMatlCost As Decimal?, ByRef PLbrCost As Decimal?, ByRef PFovhdCost As Decimal?, ByRef PVovhdCost As Decimal?, ByRef POutCost As Decimal?, ByRef PTotCost As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String,
<[Optional]> ByVal FromImportDocId As String,
<[Optional]> ByVal ToImportDocId As String,
<[Optional]> ByVal ReasonCode As String,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal FromSiteRecordDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMvPostExt As IMvPost = New MvPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PUnitCost As Decimal?, PMatlCost As Decimal?, PLbrCost As Decimal?, PFovhdCost As Decimal?, PVovhdCost As Decimal?, POutCost As Decimal?, PTotCost As Decimal?, Infobar As String) = iMvPostExt.MvPostSp(PType, PDate, PQty, PItem, FromWhse, FromLoc, FromLot, ToWhse, ToLoc, ToLot, PZeroCost, PTrnNum, PTrnLine, PTransNum, PRsvdNum, PStat, PRefNum, PRefLineSuf, PRefRelease, RefStr, PUnitCost, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, Infobar, DocumentNum, FromImportDocId, ToImportDocId, ReasonCode, EmpNum, FromSiteRecordDate)
            Dim Severity As Integer = result.ReturnCode.Value
            PUnitCost = result.PUnitCost
            PMatlCost = result.PMatlCost
            PLbrCost = result.PLbrCost
            PFovhdCost = result.PFovhdCost
            PVovhdCost = result.PVovhdCost
            POutCost = result.POutCost
            PTotCost = result.PTotCost
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IaPostSp(ByVal TrxType As String, ByVal TransDate As DateTime?,
    <[Optional]> ByVal Acct As String,
    <[Optional]> ByVal AcctUnit1 As String,
    <[Optional]> ByVal AcctUnit2 As String,
    <[Optional]> ByVal AcctUnit3 As String,
    <[Optional]> ByVal AcctUnit4 As String, ByVal TransQty As Decimal?, ByVal Whse As String, ByVal Item As String, ByVal Loc As String,
    <[Optional]> ByVal Lot As String,
    <[Optional]> ByVal FromSite As String,
    <[Optional]> ByVal ToSite As String,
    <[Optional]> ByVal ReasonCode As String,
    <[Optional]> ByVal TrnNum As String,
    <[Optional]> ByVal TrnLine As Short?,
    <[Optional]> ByVal TransNum As Decimal?,
    <[Optional]> ByVal RsvdNum As Decimal?,
    <[Optional], DefaultParameterValue("I")> ByVal SerialStat As String,
    <[Optional]> ByVal Workkey As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal Override As Byte?,
    <[Optional]> ByRef MatlCost As Decimal?,
    <[Optional]> ByRef LbrCost As Decimal?,
    <[Optional]> ByRef FovhdCost As Decimal?,
    <[Optional]> ByRef VovhdCost As Decimal?,
    <[Optional]> ByRef OutCost As Decimal?,
    <[Optional]> ByRef TotalCost As Decimal?,
    <[Optional]> ByRef ProfitMarkup As Decimal?, ByRef Infobar As String,
    <[Optional]> ByVal ToWhse As String,
    <[Optional]> ByVal ToLoc As String,
    <[Optional]> ByVal ToLot As String,
    <[Optional]> ByVal TransferTrxType As String,
    <[Optional]> ByVal TmpSerId As Guid?,
    <[Optional]> ByVal UseExistingSerials As Byte?,
    <[Optional]> ByVal SerialPrefix As String,
    <[Optional]> ByVal RemoteSiteLot As String,
    <[Optional]> ByVal DocumentNum As String,
    <[Optional]> ByVal ImportDocId As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal MoveZeroCostItem As Byte?,
    <[Optional]> ByVal EmpNum As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal SkipItemlocDelete As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iIaPostExt As IIaPost = New IaPostFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, TotalCost As Decimal?, ProfitMarkup As Decimal?, Infobar As String) = iIaPostExt.IaPostSp(TrxType, TransDate, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, TransQty, Whse, Item, Loc, Lot, FromSite, ToSite, ReasonCode, TrnNum, TrnLine, TransNum, RsvdNum, SerialStat, Workkey, Override, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, TotalCost, ProfitMarkup, Infobar, ToWhse, ToLoc, ToLot, TransferTrxType, TmpSerId, UseExistingSerials, SerialPrefix, RemoteSiteLot, DocumentNum, ImportDocId, MoveZeroCostItem, EmpNum, SkipItemlocDelete)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            TotalCost = result.TotalCost
            ProfitMarkup = result.ProfitMarkup
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemQtyDetlSp(ByVal Site As String, ByVal Type As String, ByVal WhseType As String, ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal Lot As String, ByVal DeltaQty As Decimal?, ByVal [Return] As Integer?, ByVal Action As String, ByVal TrnNum As String, ByVal TrnLine As Integer?, ByVal TransNum As Decimal?, ByVal RsvdNum As Decimal?, ByVal Stat As String, ByVal Byprod As Integer?, ByVal Workkey As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String,
        <[Optional]> ByVal ImportDocId As String,
        <[Optional], DefaultParameterValue(0)> ByRef CallForm As Integer?) As Integer Implements IExtFTSLItemLocs.ItemQtyDetlSp
        Dim iItemQtyDetlExt As IItemQtyDetl = New ItemQtyDetlFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String, CallForm As Integer?) = iItemQtyDetlExt.ItemQtyDetlSp(Site, Type, WhseType, Whse, Item, Loc, Lot, DeltaQty, [Return], Action, TrnNum, TrnLine, TransNum, RsvdNum, Stat, Byprod, Workkey, PromptMsg, PromptButtons, Infobar, ImportDocId, CallForm)
        Dim Severity As Integer = result.ReturnCode.Value
        PromptMsg = result.PromptMsg
        PromptButtons = result.PromptButtons
        Infobar = result.Infobar
        CallForm = result.CallForm
        Return Severity
    End Function
End Class
