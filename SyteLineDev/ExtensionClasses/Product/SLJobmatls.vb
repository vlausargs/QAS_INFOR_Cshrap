Option Explicit On
Option Strict On


Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports CSI.MG
Imports CSI.Production
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Customer
Imports CSI.Material
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLJobmatls")>
Public Class SLJobmatls
    Inherits CSIExtensionClassBase
    Implements IExtFTSLJobmatls

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)

        MyBase.SetContext(context)

        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection

    End Sub
    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs
        Dim updateRequest As UpdateCollectionRequestData
        Dim updateResponse As UpdateCollectionResponseData

        Dim subColResponse As UpdateCollectionResponseData
        Dim ignorePreUpdate As String = ""
        subColResponse = Nothing

        Me.Context.Commands.Invoke("MGCore.DefineVariables", "GetVariableSp", "IgnorePreUpdate", "", 1, ignorePreUpdate, IDONull.Value)

        'Cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        If (updateArgs.ActionMask And (UpdateAction.Insert Or UpdateAction.Update)) = (UpdateAction.Insert Or UpdateAction.Update) Then

            ' create an AppDB instance for our application database
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                ' create a stored proc command for ApsSyncDeferSp
                Using cmd As IDbCommand = appDB.CreateCommand()
                    ' set Infobar parameter to NULL
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "ApsSyncDeferSp"
                    appDB.AddCommandParameterWithValue(cmd, "Infobar", DBNull.Value)
                    appDB.AddCommandParameterWithValue(cmd, "Context", "SLJobmatls.PreUpdateCollection()")
                    ' execute the command through the framework
                    appDB.ExecuteNonQuery(cmd)
                End Using
            End Using
        End If

        If ignorePreUpdate = "" Or ignorePreUpdate.ToUpper() = "TRUE" Then
            Return
        End If

        If (updateArgs.ActionMask And (UpdateAction.Insert Or UpdateAction.Update)) = (UpdateAction.Insert Or UpdateAction.Update) Then

            'Cast the RequestPayload arg as an UpdateCollectionRequestData
            updateRequest = CType(updateArgs.RequestPayload, UpdateCollectionRequestData)

            'Create and initialize the response from request
            ' This will copy the properties from the request that are also
            'part of the response
            updateResponse = New UpdateCollectionResponseData(updateRequest)

            For Each updateItem As IDOUpdateItem In updateRequest.Items
                For Each subColUpdate As UpdateCollectionRequestData In
                    updateItem.NestedUpdates
                    If String.Compare(subColUpdate.IDOName, "SL.SLSerials", True) = 0 Then
                        subColResponse = Me.Context.Commands.UpdateCollection(subColUpdate)
                        'This will stop the subcollection from saving again after the primary collection update.
                        updateItem.NestedUpdates.Remove(subColUpdate)
                        subColResponse = Nothing
                        Exit For
                    End If
                Next
            Next

            ' create an AppDB instance for our application database
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                ' set the BufferJobmatl session variable for triggers
                appDB.SetSessionVariable("BufferJobmatl", "1")
            End Using
        End If

    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs
        'Cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        If (updateArgs.ActionMask And (UpdateAction.Insert Or UpdateAction.Update)) = (UpdateAction.Insert Or UpdateAction.Update) Then
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = appDB.CreateCommand()
                    ' set the Infobar parameter = NULL
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "JobmatlPostSaveSp"
                    appDB.AddCommandParameterWithValue(cmd, "Infobar", DBNull.Value)
                    ' execute the command through the framework
                    appDB.ExecuteNonQuery(cmd)
                End Using

                ' create a stored proc command for ApsSyncimmediateSp
                Using cmd As IDbCommand = appDB.CreateCommand()
                    ' set the Infobar parameter = NULL
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "ApsSyncImmediateSp"
                    appDB.AddCommandParameterWithValue(cmd, "Infobar", DBNull.Value)
                    appDB.AddCommandParameterWithValue(cmd, "Context", "SLJobmatls.PostUpdateCollection()")
                    ' execute the command through the framework
                    appDB.ExecuteNonQuery(cmd)
                End Using
            End Using
        End If

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsBflushLocVSp(ByVal Item As String, ByVal WC As String, ByVal Whse As String, ByVal Backflush As Byte?, ByVal MatlBflushLoc As String, ByVal LocalParamBflushLoc As String, ByVal BflushLoc As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCurrentMaterialsBflushLocVExt As ICurrentMaterialsBflushLocV = New CurrentMaterialsBflushLocVFactory().Create(appDb)
            Dim Severity As Integer = iCurrentMaterialsBflushLocVExt.CurrentMaterialsBflushLocVSp(Item, WC, Whse, Backflush, MatlBflushLoc, LocalParamBflushLoc, BflushLoc, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsItemVSp(ByVal ItmItem As String, ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal JobType As String, ByRef Item As String, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String, ByRef ItemExists As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByRef IsOpenNonInvForm As Byte?, ByRef PPPaperMassBasis As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCurrentMaterialsItemVExt As ICurrentMaterialsItemV = New CurrentMaterialsItemVFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Item As String, Infobar As String, Prompt As String, PromptButtons As String, ItemExists As Byte?, IsOpenNonInvForm As Byte?, PPPaperMassBasis As String) = iCurrentMaterialsItemVExt.CurrentMaterialsItemVSp(ItmItem, Job, Suffix, OperNum, Sequence, JobType, Item, Infobar, Prompt, PromptButtons, ItemExists, IsOpenNonInvForm, PPPaperMassBasis)
            Dim Severity As Integer = result.ReturnCode.Value
            Item = result.Item
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            ItemExists = result.ItemExists
            IsOpenNonInvForm = result.IsOpenNonInvForm
            PPPaperMassBasis = result.PPPaperMassBasis
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsJobItemDataSp(ByVal Item As String, ByRef ItemPlanFlag As Integer?) As Integer
        Dim iCurrentMaterialsJobItemDataExt As ICurrentMaterialsJobItemData = Me.GetService(Of ICurrentMaterialsJobItemData)()
        Dim result As (ReturnCode As Integer?, R_ItemPlanFlag As Integer?) = iCurrentMaterialsJobItemDataExt.CurrentMaterialsJobItemDataSp(Item, ItemPlanFlag)
        Dim Severity As Integer = result.ReturnCode.Value
        ItemPlanFlag = result.R_ItemPlanFlag
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsOperChgSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByRef MOShared As Integer?, ByRef MOSecondsPerCycle As Decimal?, ByRef MOFormulaMatlWeight As Decimal?, ByRef MOFormulaMatlWeightUnits As String, ByRef InfoBar As String) As Integer
        Dim iCurrentMaterialsOperChgExt As ICurrentMaterialsOperChg = Me.GetService(Of ICurrentMaterialsOperChg)()
        Dim result As (ReturnCode As Integer?, R_MOShared As Integer?, R_MOSecondsPerCycle As Decimal?, R_MOFormulaMatlWeight As Decimal?, R_MOFormulaMatlWeightUnits As String, R_InfoBar As String) = iCurrentMaterialsOperChgExt.CurrentMaterialsOperChgSp(Job, Suffix, OperNum, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, InfoBar)
        Dim Severity As Integer = result.ReturnCode.Value
        MOShared = result.R_MOShared
        MOSecondsPerCycle = result.R_MOSecondsPerCycle
        MOFormulaMatlWeight = result.R_MOFormulaMatlWeight
        MOFormulaMatlWeightUnits = result.R_MOFormulaMatlWeightUnits
        InfoBar = result.R_InfoBar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function BomChgSp(ByVal PProcess As String, ByVal PMfgType As String, ByVal PEffDate As DateTime?, ByVal PFromItem As String, ByVal PToItem As String, ByVal PFromMaterialType As String, ByVal PToMaterialType As String, ByVal PFromQty As Decimal?, ByVal PToQty As Decimal?, ByVal PFromUnits As String, ByVal PToUnits As String, ByVal PFromUM As String, ByVal PToUM As String, ByVal PFromScrapFactor As Decimal?, ByVal PToScrapFactor As Decimal?, ByVal PFromRefType As String, ByVal PToRefType As String,
<[Optional]> ByVal EffectDateOffset As Short?, ByVal PJobmatlRowPointer As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iBomChgExt As IBomChg = New BomChgFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iBomChgExt.BomChgSp(PProcess, PMfgType, PEffDate, PFromItem, PToItem, PFromMaterialType, PToMaterialType, PFromQty, PToQty, PFromUnits, PToUnits, PFromUM, PToUM, PFromScrapFactor, PToScrapFactor, PFromRefType, PToRefType, EffectDateOffset, PJobmatlRowPointer)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckAltGroupExistSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal AltGroup As Short?, ByVal ItemItem As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue("C")> ByVal Type As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCheckAltGroupExistExt As ICheckAltGroupExist = New CheckAltGroupExistFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckAltGroupExistExt.CheckAltGroupExistSp(Job, Suffix, OperNum, Sequence, AltGroup, ItemItem, Infobar, Type)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckAltItemExistSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal AltGroup As Short?, ByVal ItemItem As String, ByVal MatlItem As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue("C")> ByVal Type As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCheckAltItemExistExt As ICheckAltItemExist = New CheckAltItemExistFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckAltItemExistExt.CheckAltItemExistSp(Job, Suffix, OperNum, Sequence, AltGroup, ItemItem, MatlItem, Infobar, Type)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function BomChg(ByVal PProcess As String, ByVal PMfgType As String, ByVal PEffDate As DateTime?, ByVal PFromItem As String, ByVal PToItem As String, ByVal PFromMaterialType As String, ByVal PToMaterialType As String, ByVal PFromQty As Decimal?, ByVal PToQty As Decimal?, ByVal PFromUnits As String, ByVal PToUnits As String, ByVal PFromUM As String, ByVal PToUM As String, ByVal PFromScrapFactor As Decimal?, ByVal PToScrapFactor As Decimal?, ByVal PFromRefType As String, ByVal PToRefType As String,
<[Optional]> ByVal EffectDateOffset As Short?, ByVal PJobmatlRowPointer As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iBomChgExt As IBomChg = New BomChgFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iBomChgExt.BomChgSp(PProcess, PMfgType, PEffDate, PFromItem, PToItem, PFromMaterialType, PToMaterialType, PFromQty, PToQty, PFromUnits, PToUnits, PFromUM, PToUM, PFromScrapFactor, PToScrapFactor, PFromRefType, PToRefType, EffectDateOffset, PJobmatlRowPointer)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckAltItemInAltGrpSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal AltGroup As Short?, ByVal ItemItem As String, ByVal MatlItem As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckAltItemInAltGrpExt As ICheckAltItemInAltGrp = New CheckAltItemInAltGrpFactory().Create(appDb)

            Dim Severity As Integer = iCheckAltItemInAltGrpExt.CheckAltItemInAltGrpSp(Job, Suffix, OperNum, Sequence, AltGroup, ItemItem, MatlItem, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckDelJobMatlSp(ByVal Job As String, ByVal Suffix As Integer?, ByVal OperNum As Integer?, ByVal AltGroup As Integer?, ByVal AltGroupRank As Integer?, ByRef Infobar As String) As Integer
        Dim iCheckDelJobMatlExt As ICheckDelJobMatl = Me.GetService(Of ICheckDelJobMatl)()
        Dim result As (ReturnCode As Integer?, Inforbar As String) = iCheckDelJobMatlExt.CheckDelJobMatlSp(Job, Suffix, OperNum, AltGroup, AltGroupRank, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Inforbar
        Return Severity
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetBatchedJobMatlsSp(ByVal Site As String, ByVal ProdBatchId As Integer?, ByVal JobmatlItem As String, ByVal JobmatlDesc As String, ByVal ExtScrap As Byte?, ByVal CurWhse As String, ByVal ShowBFlushMatls As Byte?, ByVal ContainerNum As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GetBatchedJobMatlsExt As ICLM_GetBatchedJobMatls = New CLM_GetBatchedJobMatlsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_GetBatchedJobMatlsExt.CLM_GetBatchedJobMatlsSp(Site, ProdBatchId, JobmatlItem, JobmatlDesc, ExtScrap, CurWhse, ShowBFlushMatls, ContainerNum, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_JobMaterialKitBuilderSp(
<[Optional]> ByVal StartingItem As String,
<[Optional]> ByVal EndingItem As String,
<[Optional]> ByVal PlannerCode As String,
<[Optional]> ByVal StartingDueDate As DateTime?,
<[Optional]> ByVal EndingDueDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_JobMaterialKitBuilderExt As ICLM_JobMaterialKitBuilder = New CLM_JobMaterialKitBuilderFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_JobMaterialKitBuilderExt.CLM_JobMaterialKitBuilderSp(StartingItem, EndingItem, PlannerCode, StartingDueDate, EndingDueDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function DeleteBOMComponentsSp(ByVal PProcess As String, ByVal PItem As String, ByVal PJType As String, ByVal PEffDate As DateTime?, ByVal PObsDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iDeleteBOMComponentsExt As IDeleteBOMComponents = New DeleteBOMComponentsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iDeleteBOMComponentsExt.DeleteBOMComponentsSp(PProcess, PItem, PJType, PEffDate, PObsDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteBOMSp(ByVal PJobType As String, ByVal PJobmatlJob As String, ByVal PJobmatlSuffix As Short?, ByVal PJobmatlOperNum As Integer?, ByVal PJobmatlSequence As Short?, ByVal PEffDate As DateTime?, ByVal PObsDate As DateTime?, ByVal PJobmatlRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDeleteBOMExt As IDeleteBOM = New DeleteBOMFactory().Create(appDb)

            Dim Severity As Integer = iDeleteBOMExt.DeleteBOMSp(PJobType, PJobmatlJob, PJobmatlSuffix, PJobmatlOperNum, PJobmatlSequence, PEffDate, PObsDate, PJobmatlRowPointer)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcnGetNextGroupSp(ByVal SelEcnNum As Integer?, ByRef NextGroup As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcnGetNextGroupExt As IEcnGetNextGroup = New EcnGetNextGroupFactory().Create(appDb)

            Dim Severity As Integer = iEcnGetNextGroupExt.EcnGetNextGroupSp(SelEcnNum, NextGroup)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcnMassSelectedSp(ByVal SelEcnNum As Integer?, ByVal CurMatl As String, ByVal SubMatl As String, ByVal CurQty As Decimal?, ByVal SubQty As Decimal?, ByVal CurUM As String, ByVal SubUM As String, ByVal JobType As String, ByVal BeginProductCode As String, ByVal EndProductCode As String, ByVal BeginItem As String, ByVal EndItem As String, ByVal EffectiveDate As DateTime?, ByVal LineStatusDefault As String, ByVal GroupDefault As String, ByVal RunMode As Byte?, ByVal PJobmatlRowPointer As Guid?, ByVal PJobRowPointer As Guid?, ByVal PItemRowPointer As Guid?, ByRef EcnLineCount As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iEcnMassSelectedExt As IEcnMassSelected = New EcnMassSelectedFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, EcnLineCount As Integer?, Infobar As String) = iEcnMassSelectedExt.EcnMassSelectedSp(SelEcnNum, CurMatl, SubMatl, CurQty, SubQty, CurUM, SubUM, JobType, BeginProductCode, EndProductCode, BeginItem, EndItem, EffectiveDate, LineStatusDefault, GroupDefault, RunMode, PJobmatlRowPointer, PJobRowPointer, PItemRowPointer, EcnLineCount, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EcnLineCount = result.EcnLineCount
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EcnMassSp(ByVal SelEcnNum As Integer?, ByVal CurMatl As String, ByVal SubMatl As String, ByVal CurQty As Decimal?, ByVal SubQty As Decimal?, ByVal CurUM As String, ByVal SubUM As String, ByVal JobType As String, ByVal BeginProductCode As String, ByVal EndProductCode As String, ByVal BeginItem As String, ByVal EndItem As String, ByVal EffectiveDate As DateTime?, ByVal LineStatusDefault As String, ByVal GroupDefault As String, ByVal RunMode As Byte?, ByVal PJobmatlRowPointer As Guid?, ByVal PJobRowPointer As Guid?, ByVal PItemRowPointer As Guid?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iEcnMassExt As IEcnMass = New EcnMassFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iEcnMassExt.EcnMassSp(SelEcnNum, CurMatl, SubMatl, CurQty, SubQty, CurUM, SubUM, JobType, BeginProductCode, EndProductCode, BeginItem, EndItem, EffectiveDate, LineStatusDefault, GroupDefault, RunMode, PJobmatlRowPointer, PJobRowPointer, PItemRowPointer, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EjoblowSp(ByVal PList As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iEjoblowExt As IEjoblow = New EjoblowFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iEjoblowExt.EjoblowSp(PList)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EngWBCopyJobRefSp(ByVal OldRowpointer As Guid?, ByVal NewRowpointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEngWBCopyJobRefExt As IEngWBCopyJobRef = New EngWBCopyJobRefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iEngWBCopyJobRefExt.EngWBCopyJobRefSp(OldRowpointer, NewRowpointer)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EngWBJobmatlSp(ByVal JobmatlRowPointer As Guid?, ByRef JobmatlSequence As Short?, ByRef JobmatlItem As String, ByRef JobmatlDescription As String, ByRef JobmatlMatlType As String, ByRef JobmatlMatlQtyConv As Decimal?, ByRef JobmatlDerUOMConvFactor As Double?, ByRef JobmatlUnits As String, ByRef JobmatlUM As String, ByRef JobmatlScrapFact As Decimal?, ByRef JobmatlBomSeq As Short?, ByRef JobmatlBackflush As Byte?, ByRef JobmatlBflushLoc As String, ByRef JobmatlRefType As String, ByRef JobmatlRefNum As String, ByRef JobmatlRefLineSuf As Short?, ByRef JobmatlRefRelease As Short?, ByRef JobmatlEffectDate As DateTime?, ByRef JobmatlObsDate As DateTime?, ByRef JobmatlFeature As String, ByRef JobmatlOptCode As String, ByRef JobmatlProbable As Decimal?, ByRef JobmatlIncPrice As Decimal?, ByRef JobmatlCost As Decimal?, ByRef JobmatlMatlCost As Decimal?, ByRef JobmatlLbrCost As Decimal?, ByRef JobmatlFOvhdCost As Decimal?, ByRef JobmatlVOvhdCost As Decimal?, ByRef JobmatlMFOvhdCost As Decimal?, ByRef JobmatlMVOvhdCost As Decimal?, ByRef JobmatlOutCost As Decimal?, ByRef JobmatlCostConv As Decimal?, ByRef JobmatlMatlCostConv As Decimal?, ByRef JobmatlLbrCostConv As Decimal?, ByRef JobmatlFOvhdCostConv As Decimal?, ByRef JobmatlVOvhdCostConv As Decimal?, ByRef JobmatlOutCostConv As Decimal?, ByRef JobmatlAltGroup As Short?, ByRef JobmatlAltGroupRank As Short?,
<[Optional]> ByRef ItemPhantomFlag As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iEngWBJobmatlExt As IEngWBJobmatl = New EngWBJobmatlFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, JobmatlSequence As Short?, JobmatlItem As String, JobmatlDescription As String, JobmatlMatlType As String, JobmatlMatlQtyConv As Decimal?, JobmatlDerUOMConvFactor As Double?, JobmatlUnits As String, JobmatlUM As String, JobmatlScrapFact As Decimal?, JobmatlBomSeq As Short?, JobmatlBackflush As Byte?, JobmatlBflushLoc As String, JobmatlRefType As String, JobmatlRefNum As String, JobmatlRefLineSuf As Short?, JobmatlRefRelease As Short?, JobmatlEffectDate As DateTime?, JobmatlObsDate As DateTime?, JobmatlFeature As String, JobmatlOptCode As String, JobmatlProbable As Decimal?, JobmatlIncPrice As Decimal?, JobmatlCost As Decimal?, JobmatlMatlCost As Decimal?, JobmatlLbrCost As Decimal?, JobmatlFOvhdCost As Decimal?, JobmatlVOvhdCost As Decimal?, JobmatlMFOvhdCost As Decimal?, JobmatlMVOvhdCost As Decimal?, JobmatlOutCost As Decimal?, JobmatlCostConv As Decimal?, JobmatlMatlCostConv As Decimal?, JobmatlLbrCostConv As Decimal?, JobmatlFOvhdCostConv As Decimal?, JobmatlVOvhdCostConv As Decimal?, JobmatlOutCostConv As Decimal?, JobmatlAltGroup As Short?, JobmatlAltGroupRank As Short?, ItemPhantomFlag As Byte?) = iEngWBJobmatlExt.EngWBJobmatlSp(JobmatlRowPointer, JobmatlSequence, JobmatlItem, JobmatlDescription, JobmatlMatlType, JobmatlMatlQtyConv, JobmatlDerUOMConvFactor, JobmatlUnits, JobmatlUM, JobmatlScrapFact, JobmatlBomSeq, JobmatlBackflush, JobmatlBflushLoc, JobmatlRefType, JobmatlRefNum, JobmatlRefLineSuf, JobmatlRefRelease, JobmatlEffectDate, JobmatlObsDate, JobmatlFeature, JobmatlOptCode, JobmatlProbable, JobmatlIncPrice, JobmatlCost, JobmatlMatlCost, JobmatlLbrCost, JobmatlFOvhdCost, JobmatlVOvhdCost, JobmatlMFOvhdCost, JobmatlMVOvhdCost, JobmatlOutCost, JobmatlCostConv, JobmatlMatlCostConv, JobmatlLbrCostConv, JobmatlFOvhdCostConv, JobmatlVOvhdCostConv, JobmatlOutCostConv, JobmatlAltGroup, JobmatlAltGroupRank, ItemPhantomFlag)
            Dim Severity As Integer = result.ReturnCode.Value
            JobmatlSequence = result.JobmatlSequence
            JobmatlItem = result.JobmatlItem
            JobmatlDescription = result.JobmatlDescription
            JobmatlMatlType = result.JobmatlMatlType
            JobmatlMatlQtyConv = result.JobmatlMatlQtyConv
            JobmatlDerUOMConvFactor = result.JobmatlDerUOMConvFactor
            JobmatlUnits = result.JobmatlUnits
            JobmatlUM = result.JobmatlUM
            JobmatlScrapFact = result.JobmatlScrapFact
            JobmatlBomSeq = result.JobmatlBomSeq
            JobmatlBackflush = result.JobmatlBackflush
            JobmatlBflushLoc = result.JobmatlBflushLoc
            JobmatlRefType = result.JobmatlRefType
            JobmatlRefNum = result.JobmatlRefNum
            JobmatlRefLineSuf = result.JobmatlRefLineSuf
            JobmatlRefRelease = result.JobmatlRefRelease
            JobmatlEffectDate = result.JobmatlEffectDate
            JobmatlObsDate = result.JobmatlObsDate
            JobmatlFeature = result.JobmatlFeature
            JobmatlOptCode = result.JobmatlOptCode
            JobmatlProbable = result.JobmatlProbable
            JobmatlIncPrice = result.JobmatlIncPrice
            JobmatlCost = result.JobmatlCost
            JobmatlMatlCost = result.JobmatlMatlCost
            JobmatlLbrCost = result.JobmatlLbrCost
            JobmatlFOvhdCost = result.JobmatlFOvhdCost
            JobmatlVOvhdCost = result.JobmatlVOvhdCost
            JobmatlMFOvhdCost = result.JobmatlMFOvhdCost
            JobmatlMVOvhdCost = result.JobmatlMVOvhdCost
            JobmatlOutCost = result.JobmatlOutCost
            JobmatlCostConv = result.JobmatlCostConv
            JobmatlMatlCostConv = result.JobmatlMatlCostConv
            JobmatlLbrCostConv = result.JobmatlLbrCostConv
            JobmatlFOvhdCostConv = result.JobmatlFOvhdCostConv
            JobmatlVOvhdCostConv = result.JobmatlVOvhdCostConv
            JobmatlOutCostConv = result.JobmatlOutCostConv
            JobmatlAltGroup = result.JobmatlAltGroup
            JobmatlAltGroupRank = result.JobmatlAltGroupRank
            ItemPhantomFlag = result.ItemPhantomFlag
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetJobmatlItemSp(
        <[Optional]> ByVal Item As String,
        <[Optional]> ByVal UM As String,
        <[Optional]> ByVal Job As String,
        <[Optional]> ByVal Suffix As Integer?,
        <[Optional]> ByVal OperNum As Integer?,
        <[Optional]> ByVal Sequence As Integer?,
        <[Optional]> ByVal CurWhse As String,
        <[Optional]> ByVal ExtByScrap As Integer?, ByVal PoNum As String, ByVal PoLine As Integer?, ByVal PoRelease As Integer?, ByRef item_UM As String, ByRef item_Description As String, ByRef ItemExists As Integer?, ByRef UMConvFactor As Decimal?, ByRef JobmatlExists As Integer?, ByRef JobmatlByProduct As Integer?, ByRef item_MatlCost As Decimal?, ByRef item_MatlCostConv As Decimal?, ByRef item_LaborCost As Decimal?, ByRef item_LaborCostConv As Decimal?, ByRef item_FovhdCost As Decimal?, ByRef item_FovhdCostConv As Decimal?, ByRef item_VovhdCost As Decimal?, ByRef item_VovhdCostConv As Decimal?, ByRef item_OutCost As Decimal?, ByRef item_OutCostConv As Decimal?, ByRef item_IssueBy As String, ByRef item_SerialTracked As Integer?, ByRef item_LotTracked As Integer?, ByRef OutLoc As String, ByRef OutLot As String, ByRef ReqQty As Decimal?, ByRef ReqQtyConv As Decimal?, ByRef QtyIssued As Decimal?, ByRef QtyIssuedConv As Decimal?, ByRef PlanCost As Decimal?, ByRef PlanCostConv As Decimal?, ByRef OnHandQty As Decimal?, ByRef OnHandQtyConv As Decimal?, ByRef ACost As Decimal?, ByRef AMatlCost As Decimal?, ByRef ALbrCost As Decimal?, ByRef AFovhdCost As Decimal?, ByRef AVovhdCost As Decimal?, ByRef AOutCost As Decimal?, ByRef CostCode As String, ByRef PoitemNonInvAcct As String, ByRef PoitemNonInvAcctUnit1 As String, ByRef PoitemNonInvAcctUnit2 As String, ByRef PoitemNonInvAcctUnit3 As String, ByRef PoitemNonInvAcctUnit4 As String, ByRef PoitemNonInvAcctAccessUnit1 As String, ByRef PoitemNonInvAcctAccessUnit2 As String, ByRef PoitemNonInvAcctAccessUnit3 As String, ByRef PoitemNonInvAcctAccessUnit4 As String,
        <[Optional]> ByRef Infobar As String,
        <[Optional]> ByRef Prompt As String,
        <[Optional]> ByRef PromptButtons As String,
        <[Optional]> ByVal Site As String, ByRef OutImportDocId As String,
        <[Optional], DefaultParameterValue(0)> ByVal JmtRETURN As Integer?,
        <[Optional], DefaultParameterValue(0)> ByRef WCOutside As Integer?,
        <[Optional]> ByRef JobmatlRecordDate As DateTime?,
        <[Optional], DefaultParameterValue(0)> ByRef TrakcedPieces As Integer?,
        <[Optional]> ByRef ItemDimensionGroup As String,
        <[Optional]> ByRef JobmatlRowPointer As Guid?,
        <[Optional], DefaultParameterValue(0)> ByRef JobmatlBackFlush As Integer?, ByRef jobmatl_ManufacturerID As String, ByRef manufacturer_ManufacturerName As String, ByRef jobmatl_ManufacturerItem As String, ByRef manufacturerItem_ManufacturerItemDesc As String) As Integer Implements IExtFTSLJobmatls.GetJobmatlItemSp
        Dim iGetJobMatlItemExt As IGetJobMatlItem = New GetJobMatlItemFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, item_UM As String, item_Description As String, ItemExists As Integer?, UMConvFactor As Decimal?, JobmatlExists As Integer?, JobmatlByProduct As Integer?, item_MatlCost As Decimal?, item_MatlCostConv As Decimal?, item_LaborCost As Decimal?, item_LaborCostConv As Decimal?, item_FovhdCost As Decimal?, item_FovhdCostConv As Decimal?, item_VovhdCost As Decimal?, item_VovhdCostConv As Decimal?, item_OutCost As Decimal?, item_OutCostConv As Decimal?, item_IssueBy As String, item_SerialTracked As Integer?, item_LotTracked As Integer?, OutLoc As String, OutLot As String, ReqQty As Decimal?, ReqQtyConv As Decimal?, QtyIssued As Decimal?, QtyIssuedConv As Decimal?, PlanCost As Decimal?, PlanCostConv As Decimal?, OnHandQty As Decimal?, OnHandQtyConv As Decimal?, ACost As Decimal?, AMatlCost As Decimal?, ALbrCost As Decimal?, AFovhdCost As Decimal?, AVovhdCost As Decimal?, AOutCost As Decimal?, CostCode As String, PoitemNonInvAcct As String, PoitemNonInvAcctUnit1 As String, PoitemNonInvAcctUnit2 As String, PoitemNonInvAcctUnit3 As String, PoitemNonInvAcctUnit4 As String, PoitemNonInvAcctAccessUnit1 As String, PoitemNonInvAcctAccessUnit2 As String, PoitemNonInvAcctAccessUnit3 As String, PoitemNonInvAcctAccessUnit4 As String, Infobar As String, Prompt As String, PromptButtons As String, OutImportDocId As String, WCOutside As Integer?, JobmatlRecordDate As DateTime?, TrakcedPieces As Integer?, ItemDimensionGroup As String, JobmatlRowPointer As Guid?, JobmatlBackFlush As Integer?, jobmatl_ManufacturerID As String, manufacturer_ManufacturerName As String, jobmatl_ManufacturerItem As String, manufacturerItem_ManufacturerItemDesc As String) = iGetJobMatlItemExt.GetJobmatlItemSp(Item, UM, Job, Suffix, OperNum, Sequence, CurWhse, ExtByScrap, PoNum, PoLine, PoRelease, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, Site, OutImportDocId, JmtRETURN, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc)
        Dim Severity As Integer = result.ReturnCode.Value
        item_UM = result.item_UM
        item_Description = result.item_Description
        ItemExists = result.ItemExists
        UMConvFactor = result.UMConvFactor
        JobmatlExists = result.JobmatlExists
        JobmatlByProduct = result.JobmatlByProduct
        item_MatlCost = result.item_MatlCost
        item_MatlCostConv = result.item_MatlCostConv
        item_LaborCost = result.item_LaborCost
        item_LaborCostConv = result.item_LaborCostConv
        item_FovhdCost = result.item_FovhdCost
        item_FovhdCostConv = result.item_FovhdCostConv
        item_VovhdCost = result.item_VovhdCost
        item_VovhdCostConv = result.item_VovhdCostConv
        item_OutCost = result.item_OutCost
        item_OutCostConv = result.item_OutCostConv
        item_IssueBy = result.item_IssueBy
        item_SerialTracked = result.item_SerialTracked
        item_LotTracked = result.item_LotTracked
        OutLoc = result.OutLoc
        OutLot = result.OutLot
        ReqQty = result.ReqQty
        ReqQtyConv = result.ReqQtyConv
        QtyIssued = result.QtyIssued
        QtyIssuedConv = result.QtyIssuedConv
        PlanCost = result.PlanCost
        PlanCostConv = result.PlanCostConv
        OnHandQty = result.OnHandQty
        OnHandQtyConv = result.OnHandQtyConv
        ACost = result.ACost
        AMatlCost = result.AMatlCost
        ALbrCost = result.ALbrCost
        AFovhdCost = result.AFovhdCost
        AVovhdCost = result.AVovhdCost
        AOutCost = result.AOutCost
        CostCode = result.CostCode
        PoitemNonInvAcct = result.PoitemNonInvAcct
        PoitemNonInvAcctUnit1 = result.PoitemNonInvAcctUnit1
        PoitemNonInvAcctUnit2 = result.PoitemNonInvAcctUnit2
        PoitemNonInvAcctUnit3 = result.PoitemNonInvAcctUnit3
        PoitemNonInvAcctUnit4 = result.PoitemNonInvAcctUnit4
        PoitemNonInvAcctAccessUnit1 = result.PoitemNonInvAcctAccessUnit1
        PoitemNonInvAcctAccessUnit2 = result.PoitemNonInvAcctAccessUnit2
        PoitemNonInvAcctAccessUnit3 = result.PoitemNonInvAcctAccessUnit3
        PoitemNonInvAcctAccessUnit4 = result.PoitemNonInvAcctAccessUnit4
        Infobar = result.Infobar
        Prompt = result.Prompt
        PromptButtons = result.PromptButtons
        OutImportDocId = result.OutImportDocId
        WCOutside = result.WCOutside
        JobmatlRecordDate = result.JobmatlRecordDate
        TrakcedPieces = result.TrakcedPieces
        ItemDimensionGroup = result.ItemDimensionGroup
        JobmatlRowPointer = result.JobmatlRowPointer
        JobmatlBackFlush = result.JobmatlBackFlush
        jobmatl_ManufacturerID = result.jobmatl_ManufacturerID
        manufacturer_ManufacturerName = result.manufacturer_ManufacturerName
        jobmatl_ManufacturerItem = result.jobmatl_ManufacturerItem
        manufacturerItem_ManufacturerItemDesc = result.manufacturerItem_ManufacturerItemDesc
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetMaterialSequence(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Item As String,
<[Optional]> ByVal PoNum As String,
<[Optional]> ByVal PoLine As Short?,
<[Optional]> ByVal PoRelease As Short?, ByRef Sequence As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetMaterialSequenExt As IGetMaterialSequen = New GetMaterialSequenFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Sequence As Short?, Infobar As String) = iGetMaterialSequenExt.GetMaterialSequence(Job, Suffix, OperNum, Item, PoNum, PoLine, PoRelease, Sequence, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Sequence = result.Sequence
            Infobar = result.Infobar
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
    Public Function ItemSelectSp(ByVal Item As String, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iItemSelectExt As IItemSelect = New ItemSelectFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iItemSelectExt.ItemSelectSp(Item, Infobar, Prompt, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobMaterialIssueValidationSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal Item As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iJobMaterialIssueValidationExt As IJobMaterialIssueValidation = New JobMaterialIssueValidationFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobMaterialIssueValidationExt.JobMaterialIssueValidationSp(Job, Suffix, OperNum, Sequence, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobmatlObsChkSp(ByVal PJob As String, ByVal PSuffix As Short?,
<[Optional]> ByVal OperStart As Integer?,
<[Optional]> ByVal OperEnd As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iJobmatlObsChkExt As IJobmatlObsChk = New JobmatlObsChkFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobmatlObsChkExt.JobmatlObsChkSp(PJob, PSuffix, OperStart, OperEnd, Infobar)
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
    Public Function PreUpdateMaterialSequenceSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPreUpdateMaterialSequenceExt As IPreUpdateMaterialSequence = New PreUpdateMaterialSequenceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPreUpdateMaterialSequenceExt.PreUpdateMaterialSequenceSp(Job, Suffix, OperNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessBatchedJobMatlTransSp(ByVal Site As String, ByVal RowPointer As Guid?, ByVal ProdBatchId As Integer?, ByVal JobmatlItem As String, ByVal SerialTracked As Byte?, ByVal ExtScrap As Byte?, ByVal CurWhse As String, ByVal ShowBFlushMatls As Byte?, ByVal ContainerNum As String, ByVal ItemQty As Decimal?, ByVal Loc As String, ByVal Lot As String, ByVal UM As String, ByVal TransDate As DateTime?,
<[Optional]> ByVal RecordDate As DateTime?,
<[Optional]> ByVal EmpNum As String, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iProcessBatchedJobMatlTransExt As IProcessBatchedJobMatlTrans = New ProcessBatchedJobMatlTransFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iProcessBatchedJobMatlTransExt.ProcessBatchedJobMatlTransSp(Site, RowPointer, ProdBatchId, JobmatlItem, SerialTracked, ExtScrap, CurWhse, ShowBFlushMatls, ContainerNum, ItemQty, Loc, Lot, UM, TransDate, RecordDate, EmpNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessBOMImportBuilderSp(ByVal ProcessId As Guid?, ByVal ParentItem As String, ByVal ParentItemDescription As String, ByVal ParentUM As String, ByVal ParentRevision As String, ByVal ParentSource As String, ByVal ParentProductCode As String, ByVal ParentMatlType As String, ByVal PrCategory As String, ByRef PrJob As String, ByRef PrSuffix As Integer?, ByVal PrSchedId As String, ByRef PrItem As String, ByVal PrRelease As DateTime?, ByRef Infobar As String, ByVal PrAlternateID As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProcessBOMImportBuilderExt As IProcessBOMImportBuilder = New ProcessBOMImportBuilderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PrJob As String, PrSuffix As Integer?, PrItem As String, Infobar As String) = iProcessBOMImportBuilderExt.ProcessBOMImportBuilderSp(ProcessId, ParentItem, ParentItemDescription, ParentUM, ParentRevision, ParentSource, ParentProductCode, ParentMatlType, PrCategory, PrJob, PrSuffix, PrSchedId, PrItem, PrRelease, Infobar, PrAlternateID)
            Dim Severity As Integer = result.ReturnCode.Value
            PrJob = result.PrJob
            PrSuffix = result.PrSuffix
            PrItem = result.PrItem
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SaveBomIBCleanUpSp(ByVal ProcessId As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSaveBomIBCleanUpExt As ISaveBomIBCleanUp = New SaveBomIBCleanUpFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSaveBomIBCleanUpExt.SaveBomIBCleanUpSp(ProcessId)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function TransAddPreSp(ByVal PTrnNum As String, ByVal PItem As String, ByVal PFromSite As String, ByVal PFromWhse As String, ByVal PToSite As String, ByVal PToWhse As String, ByVal PJob As String, ByVal PSuffix As Integer?, ByVal POperNum As Integer?, ByVal PSequence As Integer?, ByVal POrderQty As Decimal?, ByRef PRefNum As String, ByRef PRefLineSuf As Integer?, ByVal TrnLoc As String, ByVal FOBSite As String, ByRef ItemLocQuestionAsked As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTransAddPreExt As ITransAddPre = New TransAddPreFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PRefNum As String, PRefLineSuf As Integer?, ItemLocQuestionAsked As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iTransAddPreExt.TransAddPreSp(PTrnNum, PItem, PFromSite, PFromWhse, PToSite, PToWhse, PJob, PSuffix, POperNum, PSequence, POrderQty, PRefNum, PRefLineSuf, TrnLoc, FOBSite, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PRefNum = result.PRefNum
            PRefLineSuf = result.PRefLineSuf
            ItemLocQuestionAsked = result.ItemLocQuestionAsked
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateJobmatlReferenceSp(ByVal PRefType As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PJob As String, ByVal PSuffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateJobmatlReferenceExt As IValidateJobmatlReference = New ValidateJobmatlReferenceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateJobmatlReferenceExt.ValidateJobmatlReferenceSp(PRefType, PRefNum, PRefLineSuf, PJob, PSuffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateJobmatlSeqSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?,
<[Optional]> ByRef UM As String,
<[Optional]> ByRef Item As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateJobmatlSeqExt As IValidateJobmatlSeq = New ValidateJobmatlSeqFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, UM As String, Item As String, Infobar As String) = iValidateJobmatlSeqExt.ValidateJobmatlSeqSp(Job, Suffix, OperNum, Sequence, UM, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            UM = result.UM
            Item = result.Item
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function XrefWarningMessageSp(ByVal NewRefType As String, ByVal NewRefNum As String, ByVal NewRefLineSuf As Integer?, ByVal NewRefRel As Integer?, ByRef WarningMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iXrefWarningMessageExt As IXrefWarningMessage = New XrefWarningMessageFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, WarningMsg As String) = iXrefWarningMessageExt.XrefWarningMessageSp(NewRefType, NewRefNum, NewRefLineSuf, NewRefRel, WarningMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            WarningMsg = result.WarningMsg
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessJobMatlTransSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal DeleteTmpSer As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Backflush As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ByProduct As Byte?,
<[Optional]> ByVal UM As String, ByVal Item As String,
<[Optional]> ByVal Description As String,
<[Optional]> ByVal Wc As String, ByVal Whse As String,
<[Optional]> ByVal Loc As String,
<[Optional]> ByVal Lot As String, ByVal TransDate As DateTime?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal Cost As Decimal?,
<[Optional]> ByVal PlanCost As Decimal?, ByVal Qty As Decimal?,
<[Optional]> ByVal Acct As String,
<[Optional]> ByVal AcctUnit1 As String,
<[Optional]> ByVal AcctUnit2 As String,
<[Optional]> ByVal AcctUnit3 As String,
<[Optional]> ByVal AcctUnit4 As String,
<[Optional]> ByVal RowPointer As Guid?, ByVal JobmatlRefType As String, ByVal JobmatlRefNum As String, ByVal JobmatlRefLineSuf As Short?, ByVal JobmatlRefRelease As Short?, ByRef Infobar As String, ByVal ImportDocId As String,
<[Optional]> ByVal JobLot As String,
<[Optional]> ByVal JobSerial As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal RecordDate As DateTime?,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iProcessJobMatlTransExt As IProcessJobMatlTrans = New ProcessJobMatlTransFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iProcessJobMatlTransExt.ProcessJobMatlTransSp(Job, Suffix, OperNum, Sequence, DeleteTmpSer, Backflush, ByProduct, UM, Item, Description, Wc, Whse, Loc, Lot, TransDate, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Cost, PlanCost, Qty, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, RowPointer, JobmatlRefType, JobmatlRefNum, JobmatlRefLineSuf, JobmatlRefRelease, Infobar, ImportDocId, JobLot, JobSerial, ContainerNum, RecordDate, EmpNum, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckMatlCBPctSp(
    <[Optional]> ByVal Job As String,
    <[Optional]> ByVal Suffix As Integer?,
    <[Optional]> ByVal OperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCheckMatlCBPctExt As ICheckMatlCBPct = New CheckMatlCBPctFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckMatlCBPctExt.CheckMatlCBPctSp(Job, Suffix, OperNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckOperationExistsSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCheckOperationExistsExt As ICheckOperationExists = New CheckOperationExistsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckOperationExistsExt.CheckOperationExistsSp(Job, Suffix, OperNum, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckRevTrackForCurrOperSp(ByVal Item As String, ByRef Job As String, ByRef Suffix As Integer?, ByRef MatlType As String, ByRef EcnTrack As Integer?, ByRef Infobar As String, ByVal JobType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCheckRevTrackForCurrOperExt As ICheckRevTrackForCurrOper = New CheckRevTrackForCurrOperFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Job As String, Suffix As Integer?, MatlType As String, EcnTrack As Integer?, Infobar As String) = iCheckRevTrackForCurrOperExt.CheckRevTrackForCurrOperSp(Item, Job, Suffix, MatlType, EcnTrack, Infobar, JobType)
            Dim Severity As Integer = result.ReturnCode.Value
            Job = result.Job
            Suffix = result.Suffix
            MatlType = result.MatlType
            EcnTrack = result.EcnTrack
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsBomSeqV1Sp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal ItmItem As String, ByRef BomSeq As Integer?, ByVal AltGroup As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCurrentMaterialsBomSeqV1Ext As ICurrentMaterialsBomSeqV1 = New CurrentMaterialsBomSeqV1Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BomSeq As Integer?, Infobar As String) = iCurrentMaterialsBomSeqV1Ext.CurrentMaterialsBomSeqV1Sp(Job, Suffix, OperNum, Sequence, ItmItem, BomSeq, AltGroup, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BomSeq = result.BomSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsDeleteSp(ByVal JobType As String, ByVal ItmItem As String, ByRef Infobar As String) As Integer
        Dim iCurrentMaterialsDeleteExt As ICurrentMaterialsDelete = Me.GetService(Of ICurrentMaterialsDelete)()
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCurrentMaterialsDeleteExt.CurrentMaterialsDeleteSp(JobType, ItmItem, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsItemChgSp(ByVal Item As String, ByVal WC As String, ByVal LocalNegFlag As Integer?, ByVal Job As String, ByVal Suffix As Integer?, ByVal JobmatlRowPointer As Guid?, ByRef BomSeq As Integer?, ByRef DerMatlExist As Integer?, ByRef DerUOMConvFactor As Decimal?, ByRef MatlSerialTracked As Integer?, ByRef MatlLotTracked As Integer?, ByRef Description As String, ByRef MatlType As String, ByRef Units As String, ByRef MatlStat As String, ByRef UM As String, ByRef DerUM As String, ByRef MatlUM As String, ByRef MatlLowLevel As Integer?, ByRef Backflush As Integer?, ByRef BflushLoc As String, ByRef RefType As String, ByRef PhantomFlag As Integer?, ByRef DerBflushLocRequired As Integer?, ByRef Cost As Decimal?, ByRef MatlCost As Decimal?, ByRef LbrCost As Decimal?, ByRef FovhdCost As Decimal?, ByRef VovhdCost As Decimal?, ByRef OutCost As Decimal?, ByRef CostConv As Decimal?, ByRef MatlCostConv As Decimal?, ByRef LbrCostConv As Decimal?, ByRef FovhdCostConv As Decimal?, ByRef VovhdCostConv As Decimal?, ByRef OutCostConv As Decimal?, ByRef Fmatlovhd As Decimal?, ByRef Vmatlovhd As Decimal?, ByRef Kit As Integer?, ByRef PreassignLots As Integer?, ByRef LotPrefix As String, ByRef Infobar As String,
        <[Optional]> ByVal OperNum As Integer?,
        <[Optional]> ByRef MOShared As Integer?,
        <[Optional]> ByRef MOSecondsPerCycle As Decimal?,
        <[Optional]> ByRef MOFormulaMatlWeight As Decimal?,
        <[Optional]> ByRef MOFormulaMatlWeightUnits As String,
        <[Optional]> ByRef Revision As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCurrentMaterialsItemChgExt As ICurrentMaterialsItemChg = New CurrentMaterialsItemChgFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BomSeq As Integer?, DerMatlExist As Integer?, DerUOMConvFactor As Decimal?, MatlSerialTracked As Integer?, MatlLotTracked As Integer?, Description As String, MatlType As String, Units As String, MatlStat As String, UM As String, DerUM As String, MatlUM As String, MatlLowLevel As Integer?, Backflush As Integer?, BflushLoc As String, RefType As String, PhantomFlag As Integer?, DerBflushLocRequired As Integer?, Cost As Decimal?, MatlCost As Decimal?, LbrCost As Decimal?, FovhdCost As Decimal?, VovhdCost As Decimal?, OutCost As Decimal?, CostConv As Decimal?, MatlCostConv As Decimal?, LbrCostConv As Decimal?, FovhdCostConv As Decimal?, VovhdCostConv As Decimal?, OutCostConv As Decimal?, Fmatlovhd As Decimal?, Vmatlovhd As Decimal?, Kit As Integer?, PreassignLots As Integer?, LotPrefix As String, Infobar As String, MOShared As Integer?, MOSecondsPerCycle As Decimal?, MOFormulaMatlWeight As Decimal?, MOFormulaMatlWeightUnits As String, Revision As String) = iCurrentMaterialsItemChgExt.CurrentMaterialsItemChgSp(Item, WC, LocalNegFlag, Job, Suffix, JobmatlRowPointer, BomSeq, DerMatlExist, DerUOMConvFactor, MatlSerialTracked, MatlLotTracked, Description, MatlType, Units, MatlStat, UM, DerUM, MatlUM, MatlLowLevel, Backflush, BflushLoc, RefType, PhantomFlag, DerBflushLocRequired, Cost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, CostConv, MatlCostConv, LbrCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, Fmatlovhd, Vmatlovhd, Kit, PreassignLots, LotPrefix, Infobar, OperNum, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, Revision)
            Dim Severity As Integer = result.ReturnCode.Value
            BomSeq = result.BomSeq
            DerMatlExist = result.DerMatlExist
            DerUOMConvFactor = result.DerUOMConvFactor
            MatlSerialTracked = result.MatlSerialTracked
            MatlLotTracked = result.MatlLotTracked
            Description = result.Description
            MatlType = result.MatlType
            Units = result.Units
            MatlStat = result.MatlStat
            UM = result.UM
            DerUM = result.DerUM
            MatlUM = result.MatlUM
            MatlLowLevel = result.MatlLowLevel
            Backflush = result.Backflush
            BflushLoc = result.BflushLoc
            RefType = result.RefType
            PhantomFlag = result.PhantomFlag
            DerBflushLocRequired = result.DerBflushLocRequired
            Cost = result.Cost
            MatlCost = result.MatlCost
            LbrCost = result.LbrCost
            FovhdCost = result.FovhdCost
            VovhdCost = result.VovhdCost
            OutCost = result.OutCost
            CostConv = result.CostConv
            MatlCostConv = result.MatlCostConv
            LbrCostConv = result.LbrCostConv
            FovhdCostConv = result.FovhdCostConv
            VovhdCostConv = result.VovhdCostConv
            OutCostConv = result.OutCostConv
            Fmatlovhd = result.Fmatlovhd
            Vmatlovhd = result.Vmatlovhd
            Kit = result.Kit
            PreassignLots = result.PreassignLots
            LotPrefix = result.LotPrefix
            Infobar = result.Infobar
            MOShared = result.MOShared
            MOSecondsPerCycle = result.MOSecondsPerCycle
            MOFormulaMatlWeight = result.MOFormulaMatlWeight
            MOFormulaMatlWeightUnits = result.MOFormulaMatlWeightUnits
            Revision = result.Revision
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsUMV1Sp(ByVal UM As String, ByVal Item As String, ByVal ItemUM As String, ByVal Cost As Decimal?, ByVal IncPrice As Decimal?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal DerUM As String, ByRef MatlQtyConv As Decimal?, ByRef VDerUM As String, ByRef VDerUOMConvFactor As Decimal?, ByRef VMatlQty As Decimal?, ByRef VCost As Decimal?, ByRef VIncPrice As Decimal?, ByRef VMatlCost As Decimal?, ByRef VLbrCost As Decimal?, ByRef VFovhdCost As Decimal?, ByRef VVovhdCost As Decimal?, ByRef VOutCost As Decimal?, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCurrentMaterialsUMV1Ext As ICurrentMaterialsUMV1 = New CurrentMaterialsUMV1Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, MatlQtyConv As Decimal?, VDerUM As String, VDerUOMConvFactor As Decimal?, VMatlQty As Decimal?, VCost As Decimal?, VIncPrice As Decimal?, VMatlCost As Decimal?, VLbrCost As Decimal?, VFovhdCost As Decimal?, VVovhdCost As Decimal?, VOutCost As Decimal?, Infobar As String, Prompt As String, PromptButtons As String) = iCurrentMaterialsUMV1Ext.CurrentMaterialsUMV1Sp(UM, Item, ItemUM, Cost, IncPrice, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, DerUM, MatlQtyConv, VDerUM, VDerUOMConvFactor, VMatlQty, VCost, VIncPrice, VMatlCost, VLbrCost, VFovhdCost, VVovhdCost, VOutCost, Infobar, Prompt, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlQtyConv = result.MatlQtyConv
            VDerUM = result.VDerUM
            VDerUOMConvFactor = result.VDerUOMConvFactor
            VMatlQty = result.VMatlQty
            VCost = result.VCost
            VIncPrice = result.VIncPrice
            VMatlCost = result.VMatlCost
            VLbrCost = result.VLbrCost
            VFovhdCost = result.VFovhdCost
            VVovhdCost = result.VVovhdCost
            VOutCost = result.VOutCost
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrentMaterialsUpdInsSp(ByVal Item As String, ByVal JobJob As String, ByVal JobSuffix As Integer?, ByVal JobType As String, ByVal ItmItem As String, ByVal ItmLowLevel As Integer?, ByVal DerMatlExist As Integer?, ByRef MatlLowLevel As Integer?, ByRef Infobar As String, ByVal Inserted As Integer?,
<[Optional]> ByVal OldJobmatlRowPointer As Guid?,
<[Optional]> ByVal NewJobmatlRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCurrentMaterialsUpdInsExt As ICurrentMaterialsUpdIns = New CurrentMaterialsUpdInsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, MatlLowLevel As Integer?, Infobar As String) = iCurrentMaterialsUpdInsExt.CurrentMaterialsUpdInsSp(Item, JobJob, JobSuffix, JobType, ItmItem, ItmLowLevel, DerMatlExist, MatlLowLevel, Infobar, Inserted, OldJobmatlRowPointer, NewJobmatlRowPointer)
            Dim Severity As Integer = result.ReturnCode.Value
            MatlLowLevel = result.MatlLowLevel
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EngWBGetJobVarSp(
<[Optional]> ByRef Job As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEngWBGetJobVarExt As IEngWBGetJobVar = New EngWBGetJobVarFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Job As String) = iEngWBGetJobVarExt.EngWBGetJobVarSp(Job)
            Dim Severity As Integer = result.ReturnCode.Value
            Job = result.Job
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetJobmatlSeqListSp(
        <[Optional]> ByVal Job As String,
        <[Optional]> ByVal Suffix As Integer?,
        <[Optional]> ByVal OperNum As Integer?,
        <[Optional]> ByVal UM As String,
        <[Optional]> ByVal Item As String,
        <[Optional]> ByVal Descr As String,
        <[Optional], DefaultParameterValue(1)> ByVal ExtScrap As Integer?,
        <[Optional]> ByVal MatlCost As Decimal?,
        <[Optional]> ByVal LaborCost As Decimal?,
        <[Optional]> ByVal FovhdCost As Decimal?,
        <[Optional]> ByVal VovhdCost As Decimal?,
        <[Optional]> ByVal OutCost As Decimal?,
        <[Optional]> ByVal CurWhse As String,
        <[Optional]> ByVal Site As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetJobmatlSeqListExt As IGetJobmatlSeqList = New GetJobmatlSeqListFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iGetJobmatlSeqListExt.GetJobmatlSeqListSp(Job, Suffix, OperNum, UM, Item, Descr, ExtScrap, MatlCost, LaborCost, FovhdCost, VovhdCost, OutCost, CurWhse, Site, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetJobMatlsSp(
<[Optional]> ByVal Site As String,
<[Optional]> ByVal JobJob As String,
<[Optional]> ByVal JobSuffix As Short?,
<[Optional]> ByVal JobmatlOperNum As String,
<[Optional]> ByVal JobmatlSequence As String,
<[Optional]> ByVal JobmatlItem As String,
<[Optional]> ByVal JobmatlDesc As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal ExtScrap As Byte?,
<[Optional]> ByVal CurWhse As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ShowBFlushMatls As Byte?,
<[Optional]> ByVal ContainerNum As String, ByRef Infobar As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetJobMatlsExt As IGetJobMatls = New GetJobMatlsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iGetJobMatlsExt.GetJobMatlsSp(Site, JobJob, JobSuffix, JobmatlOperNum, JobmatlSequence, JobmatlItem, JobmatlDesc, ExtScrap, CurWhse, ShowBFlushMatls, ContainerNum, Infobar, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function JoblowSp(ByVal PList As String,
        <[Optional]> ByVal BgTaskID As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJoblowExt As IJoblow = New JoblowFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iJoblowExt.JoblowSp(PList, BgTaskID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobMaterialsPostDeleteSp(ByVal Job As String, ByVal Suffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobMaterialsPostDeleteExt As IJobMaterialsPostDelete = New JobMaterialsPostDeleteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobMaterialsPostDeleteExt.JobMaterialsPostDeleteSp(Job, Suffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobMaterialsPreDeleteSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobMaterialsPreDeleteExt As IJobMaterialsPreDelete = New JobMaterialsPreDeleteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobMaterialsPreDeleteExt.JobMaterialsPreDeleteSp(Job, Suffix, OperNum, Sequence, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobmatlXrefSp(ByRef PAsk As Integer?, ByVal PRefType As String, ByVal PJob As String, ByVal PSuffix As Integer?, ByVal POperNum As Integer?, ByVal PSeq As Integer?, ByVal PItem As String, ByRef PRefNum As String, ByRef PRefLine As Integer?, ByRef PRefRelease As Integer?, ByRef POrderQty As Decimal?, ByRef PPoType As String, ByRef PCommand As String, ByRef PromptMsg As String, ByRef Buttons As String, ByRef Infobar As String, ByVal ExportType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobmatlXrefExt As IJobmatlXref = New JobmatlXrefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PAsk As Integer?, PRefNum As String, PRefLine As Integer?, PRefRelease As Integer?, POrderQty As Decimal?, PPoType As String, PCommand As String, PromptMsg As String, Buttons As String, Infobar As String) = iJobmatlXrefExt.JobmatlXrefSp(PAsk, PRefType, PJob, PSuffix, POperNum, PSeq, PItem, PRefNum, PRefLine, PRefRelease, POrderQty, PPoType, PCommand, PromptMsg, Buttons, Infobar, ExportType)
            Dim Severity As Integer = result.ReturnCode.Value
            PAsk = result.PAsk
            PRefNum = result.PRefNum
            PRefLine = result.PRefLine
            PRefRelease = result.PRefRelease
            POrderQty = result.POrderQty
            PPoType = result.PPoType
            PCommand = result.PCommand
            PromptMsg = result.PromptMsg
            Buttons = result.Buttons
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
    Public Function MatlGetInvparmsSp(ByRef DefWhse As String, ByRef EcnEst As String, ByRef EcnJob As String, ByRef EcnStd As String, ByRef NegFlag As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMatlGetInvparmsExt As IMatlGetInvparms = New MatlGetInvparmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DefWhse As String, EcnEst As String, EcnJob As String, EcnStd As String, NegFlag As Integer?, Infobar As String) = iMatlGetInvparmsExt.MatlGetInvparmsSp(DefWhse, EcnEst, EcnJob, EcnStd, NegFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DefWhse = result.DefWhse
            EcnEst = result.EcnEst
            EcnJob = result.EcnJob
            EcnStd = result.EcnStd
            NegFlag = result.NegFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProdConfFeatureMaterialSp(ByVal ParentItem As String, ByVal Feature As String, ByVal CoNum As String, ByVal CoLine As Integer?,
        <[Optional]> ByVal Site As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProdConfFeatureMaterialExt As IProdConfFeatureMaterial = New ProdConfFeatureMaterialFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProdConfFeatureMaterialExt.ProdConfFeatureMaterialSp(ParentItem, Feature, CoNum, CoLine, Site)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProdConfListSp(ByVal FeatStr As String, ByVal Item As String, ByVal CoNum As String, ByVal CoLine As Integer?, ByVal Level As Integer?,
        <[Optional]> ByVal Site As String,
        <[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProdConfListExt As IProdConfList = New ProdConfListFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProdConfListExt.ProdConfListSp(FeatStr, Item, CoNum, CoLine, Level, Site, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RerankJobmatlSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal AltGroup As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRerankJobmatlExt As IRerankJobmatl = New RerankJobmatlFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRerankJobmatlExt.RerankJobmatlSp(Job, Suffix, OperNum, AltGroup, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SaveBomIBJobmatlSp(ByVal ProcessId As Guid?, ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal Create As Byte?, ByVal BomSeq As Short?, ByVal Item As String, ByVal ItemDescription As String, ByVal Revision As String, ByVal ProductCode As String, ByVal MatlQty As Decimal?, ByVal UM As String, ByVal Units As String, ByVal PMTCode As String, ByVal MatlType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSaveBomIBJobmatlExt As ISaveBomIBJobmatl = New SaveBomIBJobmatlFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSaveBomIBJobmatlExt.SaveBomIBJobmatlSp(ProcessId, Job, Suffix, OperNum, Sequence, Create, BomSeq, Item, ItemDescription, Revision, ProductCode, MatlQty, UM, Units, PMTCode, MatlType)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateMaterialSequenceSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateMaterialSequenceExt As IUpdateMaterialSequence = New UpdateMaterialSequenceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateMaterialSequenceExt.UpdateMaterialSequenceSp(Job, Suffix, OperNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JmatlTpSp(ByVal CallFrom As String, ByVal DeleteTmpSer As Integer?, ByVal Backflush As Integer?, ByVal Workkey As String, ByVal ByProduct As Integer?, ByVal TransClass As String, ByVal JobJob As String, ByVal JobSuffix As Integer?, ByVal JobmatlOperNum As Integer?, ByVal JobmatlSequence As Decimal?, ByVal ChildItem As String, ByVal Wc As String, ByVal EmpNum As String, ByVal Whse As String, ByVal Loc As String, ByVal Lot As String, ByVal TransDate As DateTime?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal Cost As Decimal?, ByVal Qty As Decimal?, ByVal Acct As String, ByVal AcctUnit1 As String, ByVal AcctUnit2 As String, ByVal AcctUnit3 As String, ByVal AcctUnit4 As String,
        <[Optional]> ByVal ImportDocId As String, ByRef Infobar As String,
        <[Optional]> ByVal JobLot As String,
        <[Optional]> ByVal JobSerial As String,
        <[Optional]> ByVal ContainerNum As String,
        <[Optional]> ByVal DocumentNum As String) As Integer
        Dim iJmatlTpExt As IJmatlTp = New JmatlTpFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iJmatlTpExt.JmatlTpSp(CallFrom, DeleteTmpSer, Backflush, Workkey, ByProduct, TransClass, JobJob, JobSuffix, JobmatlOperNum, JobmatlSequence, ChildItem, Wc, EmpNum, Whse, Loc, Lot, TransDate, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Cost, Qty, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, ImportDocId, Infobar, JobLot, JobSerial, ContainerNum, DocumentNum)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ChkMatlSp(ByVal Item As String, ByVal ItmItem As String, ByVal Job As String, ByVal Suffix As Integer?, ByVal OperNum As Integer?, ByVal Sequence As Integer?, ByRef Infobar As String,
        <[Optional]> ByRef Prompt As String,
        <[Optional]> ByRef PromptButtons As String) As Integer
        Dim iChkMatlExt As IChkMatl = New ChkMatlFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iChkMatlExt.ChkMatlSp(Item, ItmItem, Job, Suffix, OperNum, Sequence, Infobar, Prompt, PromptButtons)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Prompt = result.Prompt
        PromptButtons = result.PromptButtons
        Return Severity
    End Function
End Class
