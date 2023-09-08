Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.MG
Imports CSI.Production
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports System.Runtime.InteropServices
Imports CSI.Production.APS
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLJobs")>
Public Class SLJobs
    Inherits CSIExtensionClassBase
    Implements IExtFTSLJobs

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobStatusChangeMassCustomLoad(ByVal PropertyNames As Object, ByRef ResultSet As Object, ByRef Flags As Object,
  ByVal Process As String, ByVal FromJobStatus As String, ByVal FromJobStatusLabel As String,
  ByVal ToJobStatus As String, ByVal ToJobStatusLabel As String, ByVal SelectFinish As Integer,
  ByVal StartingJob As String, ByVal StartingSuffix As Integer, ByVal EndingJob As String,
  ByVal EndingSuffix As Integer, ByVal EarliestJobEndDate As Date, ByVal LatestJobEndDate As Date,
  ByVal EarliestStartDate As Date, ByVal LatestStartDate As Date, ByVal DeleteHistoryJobs As Integer,
  ByVal CopyRouting As Integer, ByVal EStartDateOffset As Integer, ByVal LStartDateOffset As Integer,
  ByVal EEndDateOffset As Integer, ByVal LEndDateOffset As Integer) As Integer

        ' Call the original custom load method

        Me.Invoke("JobStatusChangeMassSp", PropertyNames, ResultSet, Flags,
            Process, FromJobStatus, FromJobStatusLabel,
            ToJobStatus, ToJobStatusLabel, SelectFinish,
            StartingJob, StartingSuffix, EndingJob,
            EndingSuffix, EarliestJobEndDate, LatestJobEndDate,
            EarliestStartDate, LatestStartDate, DeleteHistoryJobs,
            CopyRouting, EStartDateOffset, LStartDateOffset, EEndDateOffset, LEndDateOffset)

        If Process = "P" Then
            JobStatusChangeMassCustomLoad = 16
        Else
            JobStatusChangeMassCustomLoad = 0
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgRemoveConfigurationHoldSp(ByVal SourceRefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal ConfigHold As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCfgRemoveConfigurationHoldExt As ICfgRemoveConfigurationHold = New CfgRemoveConfigurationHoldFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iCfgRemoveConfigurationHoldExt.CfgRemoveConfigurationHoldSp(SourceRefType, RefNum, RefLineSuf, ConfigHold)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CalcSubJobDatesSP(ByRef CalcBOMSubJobDates As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCalcSubJobDatesExt As ICalcSubJobDates = New CalcSubJobDatesFactory().Create(appDb)

            Dim Severity As Integer = iCalcSubJobDatesExt.CalcSubJobDatesSp(CalcBOMSubJobDates)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CojobItemCopyBOMSp(ByVal Job As String, ByVal Suffix As Short?, ByVal Item As String, ByVal AlternateID As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCojobItemCopyBOMExt As ICojobItemCopyBOM = New CojobItemCopyBOMFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCojobItemCopyBOMExt.CojobItemCopyBOMSp(Job, Suffix, Item, AlternateID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomCheckSubJobSp(ByVal Job As String, ByVal Suffix As Short?, ByVal JobType As String, ByRef SubJob As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomCheckSubJobExt As ICopyBomCheckSubJob = New CopyBomCheckSubJobFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomCheckSubJobExt.CopyBomCheckSubJobSp(Job, Suffix, JobType, SubJob)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomLeaveFromReleaseSp(ByRef PsNum As String, ByRef Item As String, ByRef Job As String, ByRef Suffix As Short?, ByRef DueDate As DateTime?, ByRef StartOper As Integer?, ByRef EndOper As Integer?, ByRef ItemRev As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomLeaveFromReleaseExt As ICopyBomLeaveFromRelease = New CopyBomLeaveFromReleaseFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomLeaveFromReleaseExt.CopyBomLeaveFromReleaseSp(PsNum, Item, Job, Suffix, DueDate, StartOper, EndOper, ItemRev, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomLeaveToItemSp(ByVal ToCategory As String, ByVal Item As String, ByVal PsNum As String, ByRef Job As String, ByRef Suffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomLeaveToItemExt As ICopyBomLeaveToItem = New CopyBomLeaveToItemFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomLeaveToItemExt.CopyBomLeaveToItemSp(ToCategory, Item, PsNum, Job, Suffix, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomLeaveToJobSp(ByVal CopyBom As Byte?, ByVal Job As String, ByVal Suffix As Short?, ByRef AfterOper As Integer?, ByRef AfterOperED As Byte?, ByRef OptionType As String, ByRef OptionED As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomLeaveToJobExt As ICopyBomLeaveToJob = New CopyBomLeaveToJobFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomLeaveToJobExt.CopyBomLeaveToJobSp(CopyBom, Job, Suffix, AfterOper, AfterOperED, OptionType, OptionED, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomLeaveToJobSuffixSp(ByVal CopyBom As Byte?, ByVal Job As String, ByVal Suffix As Short?, ByRef AfterOper As Integer?, ByRef AfterOperED As Byte?, ByRef OptionType As String, ByRef OptionED As Byte?, ByRef Infobar As String, ByRef Rework As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomLeaveToJobSuffixExt As ICopyBomLeaveToJobSuffix = New CopyBomLeaveToJobSuffixFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomLeaveToJobSuffixExt.CopyBomLeaveToJobSuffixSp(CopyBom, Job, Suffix, AfterOper, AfterOperED, OptionType, OptionED, Infobar, Rework)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomLeaveToReleaseSp(ByVal Item_F As String, ByVal Type_F As String, ByRef PsNum As String, ByRef Item As String, ByRef Job As String, ByRef Suffix As Short?, ByRef DueDate As DateTime?, ByRef StartOper As Integer?, ByRef EndOper As Integer?, ByRef ItemRev As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomLeaveToReleaseExt As ICopyBomLeaveToRelease = New CopyBomLeaveToReleaseFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomLeaveToReleaseExt.CopyBomLeaveToReleaseSp(Item_F, Type_F, PsNum, Item, Job, Suffix, DueDate, StartOper, EndOper, ItemRev, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomVerifyFromInputsSp(ByVal FromCategory As String, ByVal P_Type As String, ByVal P_Job As String, ByVal P_Suffix As Short?, ByVal P_Ps_Num As String, ByVal P_Item As String, ByVal P_Revision As String, ByVal P_Op_Start As Integer?, ByVal P_Op_End As Integer?, ByRef O_Job As String, ByRef O_Suffix As Short?, ByRef O_Ps_Num As String, ByRef O_Item As String, ByRef O_Revision As String, ByRef O_Op_Start As Integer?, ByRef O_Op_End As Integer?, ByRef O_Error As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomVerifyFromInputsExt As ICopyBomVerifyFromInputs = New CopyBomVerifyFromInputsFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomVerifyFromInputsExt.CopyBomVerifyFromInputsSp(FromCategory, P_Type, P_Job, P_Suffix, P_Ps_Num, P_Item, P_Revision, P_Op_Start, P_Op_End, O_Job, O_Suffix, O_Ps_Num, O_Item, O_Revision, O_Op_Start, O_Op_End, O_Error, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomVerifyToInputsSp(ByVal ToCategory As String, ByVal P_Type As String, ByVal P_Job As String, ByVal P_Suffix As Short?, ByVal P_Ps_Num As String, ByVal P_Item As String, ByVal P_Revision As String, ByVal P_Type_F As String, ByVal P_Item_F As String, ByVal P_Bom As Byte?, ByVal P_Op_Start As Integer?, ByVal P_Op_End As Integer?, ByVal P_Choice As String, ByRef O_Job As String, ByRef O_Suffix As Short?, ByRef O_Item As String, ByRef O_Revision As String, ByRef Infobar As String, ByRef JobRouteExists As Byte?, ByVal P_Suffix_F As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyBomVerifyToInputsExt As ICopyBomVerifyToInputs = New CopyBomVerifyToInputsFactory().Create(appDb)

            Dim Severity As Integer = iCopyBomVerifyToInputsExt.CopyBomVerifyToInputsSp(ToCategory, P_Type, P_Job, P_Suffix, P_Ps_Num, P_Item, P_Revision, P_Type_F, P_Item_F, P_Bom, P_Op_Start, P_Op_End, P_Choice, O_Job, O_Suffix, O_Item, O_Revision, Infobar, JobRouteExists, P_Suffix_F)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyJobOperationSp(ByVal FromCardType As String, ByVal FromJobType As String, ByVal FromJob As String, ByVal FromSuffix As Short?, ByVal FromOperNum As Integer?, ByVal ToCardType As String, ByVal ToJobType As String, ByVal ToJob As String, ByVal ToSuffix As Short?, ByVal ToOperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCopyJobOperationExt As ICopyJobOperation = New CopyJobOperationFactory().Create(appDb)

            Dim Severity As Integer = iCopyJobOperationExt.CopyJobOperationSp(FromCardType, FromJobType, FromJob, FromSuffix, FromOperNum, ToCardType, ToJobType, ToJob, ToSuffix, ToOperNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateJobSp(ByVal JobType As String, ByRef Job As String, ByRef Suffix As Short?, ByVal Item As String, ByVal Description As String, ByVal Revision As String, ByVal QtyReleased As Decimal?, ByVal Status As String, ByVal JobDate As DateTime?, ByVal StartDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCreateJobExt As ICreateJob = New CreateJobFactory().Create(appDb)

            Dim Severity As Integer = iCreateJobExt.CreateJobSp(JobType, Job, Suffix, Item, Description, Revision, QtyReleased, Status, JobDate, StartDate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EstimateJobRollSp(ByVal StartingJob As String, ByVal StartingSuffix As Short?, ByVal EndingJob As String, ByVal EndingSuffix As Short?, ByVal ResetByProductCost As Byte?, ByVal ResetItemCost As Byte?, ByVal ResetPOCost As Byte?, ByVal ResetRecCost As Byte?, ByVal ResetJobCost As Byte?, ByVal ShowList As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iEstimateJobRollExt As IEstimateJobRoll = New EstimateJobRollFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iEstimateJobRollExt.EstimateJobRollSp(StartingJob, StartingSuffix, EndingJob, EndingSuffix, ResetByProductCost, ResetItemCost, ResetPOCost, ResetRecCost, ResetJobCost, ShowList)

            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EstJobItemVSp(ByRef Item As String, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iEstJobItemVExt As IEstJobItemV = New EstJobItemVFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Item As String, Infobar As String, Prompt As String, PromptButtons As String) = iEstJobItemVExt.EstJobItemVSp(Item, Infobar, Prompt, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            Item = result.Item
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExpandValidateRJobSp(ByVal Job As String, ByVal Suffix As Short?, ByVal PostMatlIssues As Byte?, ByRef Item As String, ByRef Infobar As String) As Integer Implements IExtFTSLJobs.ExpandValidateRJobSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iExpandValidateRJobExt As IExpandValidateRJob = New ExpandValidateRJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Item As String, Infobar As String) = iExpandValidateRJobExt.ExpandValidateRJobSp(Job, Suffix, PostMatlIssues, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Item = result.Item
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExpandValidateRplJobSp(ByVal Job As String, ByVal Suffix As Short?, ByVal PostMatlIssues As Byte?, ByRef Item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iExpandValidateRplJobExt As IExpandValidateRplJob = New ExpandValidateRplJobFactory().Create(appDb)

            Dim Severity As Integer = iExpandValidateRplJobExt.ExpandValidateRplJobSp(Job, Suffix, PostMatlIssues, Item, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemSuffixSp(ByVal Job As String, ByRef Item As String, ByRef Suffix As Short?, ByRef QtyRequired As Decimal?, ByRef DateRequired As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetItemSuffixExt As IGetItemSuffix = New GetItemSuffixFactory().Create(appDb)

            Dim Severity As Integer = iGetItemSuffixExt.GetItemSuffixSp(Job, Item, Suffix, QtyRequired, DateRequired)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetLastDateRequiredSp(ByRef LastDateRequired As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetLastDateRequiredExt As IGetLastDateRequired = New GetLastDateRequiredFactory().Create(appDb)

            Dim Severity As Integer = iGetLastDateRequiredExt.GetLastDateRequiredSp(LastDateRequired)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetProdMixSp(ByVal Item As String, ByRef ProdMix As String, ByRef Qty As Short?, ByRef Description As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetProdMixExt As IGetProdMix = New GetProdMixFactory().Create(appDb)

            Dim Severity As Integer = iGetProdMixExt.GetProdMixSp(Item, ProdMix, Qty, Description)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemChgRateSp(ByVal JobType As String, ByVal UpdFixMatlOvhd As Byte?, ByVal UpdVarMatlOvhd As Byte?, ByVal UpdFixedOvhd As Byte?, ByVal UpdVarOvhd As Byte?, ByVal UpdSetupRate As Byte?, ByVal UpdEfficiency As Byte?, ByVal UpdRunRate As Byte?, ByVal UpdFixMachRate As Byte?, ByVal UpdVarMachRate As Byte?, ByVal FromJob As String, ByVal ToJob As String, ByVal FromSuffix As Short?, ByVal ToSuffix As Short?, ByVal FromItem As String, ByVal ToItem As String, ByVal FromProductCode As String, ByVal ToProductCode As String, ByVal FromWc As String, ByVal ToWc As String, ByVal FromDept As String, ByVal ToDept As String, ByVal FromPsNum As String, ByVal ToPsNum As String, ByRef Infobar As String,
<[Optional]> ByVal FromCostingAlt As String,
<[Optional]> ByVal ToCostingAlt As String,
<[Optional]> ByVal FromBOMAlternateID As String,
<[Optional]> ByVal ToBOMAlternateID As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemChgRateExt As IItemChgRate = New ItemChgRateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iItemChgRateExt.ItemChgRateSp(JobType, UpdFixMatlOvhd, UpdVarMatlOvhd, UpdFixedOvhd, UpdVarOvhd, UpdSetupRate, UpdEfficiency, UpdRunRate, UpdFixMachRate, UpdVarMachRate, FromJob, ToJob, FromSuffix, ToSuffix, FromItem, ToItem, FromProductCode, ToProductCode, FromWc, ToWc, FromDept, ToDept, FromPsNum, ToPsNum, Infobar, FromCostingAlt, ToCostingAlt, FromBOMAlternateID, ToBOMAlternateID)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobDelPostSaveSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobDelPostSaveExt As IJobDelPostSave = New JobDelPostSaveFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobDelPostSaveExt.JobDelPostSaveSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity

        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobMergeSp(ByVal FromJob As String, ByVal FromSuffix As Short?, ByVal ToJob As String, ByVal ToSuffix As Short?, ByVal CurWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobMergeExt As IJobMerge = New JobMergeFactory().Create(appDb)

            Dim Severity As Integer = iJobMergeExt.JobMergeSp(FromJob, FromSuffix, ToJob, ToSuffix, CurWhse, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrdersGetEndDateSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PStartTick As Decimal?, ByRef PEndTick As Decimal?, ByVal PStartDate As DateTime?, ByRef PEndDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobOrdersGetEndDateExt As IJobOrdersGetEndDate = New JobOrdersGetEndDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PStartTick As Decimal?, PEndTick As Decimal?, PEndDate As DateTime?, Infobar As String) = iJobOrdersGetEndDateExt.JobOrdersGetEndDateSp(PJob, PSuffix, PStartTick, PEndTick, PStartDate, PEndDate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PStartTick = result.PStartTick
            PEndTick = result.PEndTick
            PEndDate = result.PEndDate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrderStdFormPredisplaySp(ByRef ApsParmValue As String, ByRef CalcBOMSubJobDates As Byte?, ByRef ApsCalcSubJobDates As Short?, ByRef InvParmValue As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobOrderStdFormPredisplayExt As IJobOrderStdFormPredisplay = New JobOrderStdFormPredisplayFactory().Create(appDb)

            Dim Severity As Integer = iJobOrderStdFormPredisplayExt.JobOrderStdFormPredisplaySp(ApsParmValue, CalcBOMSubJobDates, ApsCalcSubJobDates, InvParmValue)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrdersValidateJobSp(ByVal PJob As String, ByVal PSuffix As Short?, ByVal Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobOrdersValidateJobExt As IJobOrdersValidateJob = New JobOrdersValidateJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iJobOrdersValidateJobExt.JobOrdersValidateJobSp(PJob, PSuffix, Infobar)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobReceiptGetQtySp(ByVal Job As String, ByVal Suffix As Short?, ByVal Item As String, ByVal OperNum As Integer?, ByRef QtyMoved As Decimal?, ByRef QtyComplete As Decimal?, ByRef ItemSerialPrefix As String, ByRef Infobar As String) As Integer Implements IExtFTSLJobs.JobReceiptGetQtySp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobReceiptGetQtyExt As IJobReceiptGetQty = New JobReceiptGetQtyFactory().Create(appDb)

            Dim Severity As Integer = iJobReceiptGetQtyExt.JobReceiptGetQtySp(Job, Suffix, Item, OperNum, QtyMoved, QtyComplete, ItemSerialPrefix, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobReceiptPostSetVarsSp(ByVal [SET] As String, ByVal Job As String, ByVal Suffix As Short?, ByVal Item As String, ByVal OperNum As Integer?, ByVal Qty As Decimal?, ByVal Loc As String, ByVal Lot As String, ByVal TransDate As DateTime?, ByVal Override As Byte?, ByRef CanOverride As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String,
<[Optional]> ByVal ImportDocId As String,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal ContainerNum As String) As Integer Implements IExtFTSLJobs.JobReceiptPostSetVarsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iJobReceiptPostSetVarsExt As IJobReceiptPostSetVars = New JobReceiptPostSetVarsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CanOverride As Integer?, Infobar As String) = iJobReceiptPostSetVarsExt.JobReceiptPostSetVarsSp([SET], Job, Suffix, Item, OperNum, Qty, Loc, Lot, TransDate, Override, CanOverride, Infobar, DocumentNum, ImportDocId, EmpNum, ContainerNum)
            Dim Severity As Integer = result.ReturnCode.Value
            CanOverride = result.CanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobReceiptValidateJobSp(ByVal Job As String, ByVal Suffix As Short?, ByRef JobrouteOperNum As Integer?, ByRef QtyMoved As Decimal?, ByRef QtyComplete As Decimal?, ByRef ItemLotTracked As Integer?, ByRef ItemSerialTracked As Integer?, ByRef Infobar As String,
        <[Optional]> ByRef Prompt As String,
        <[Optional]> ByRef PromptButtons As String) As Integer Implements IExtFTSLJobs.JobReceiptValidateJobSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iJobReceiptValidateJobExt As IJobReceiptValidateJob = New JobReceiptValidateJobFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, JobrouteOperNum As Integer?, QtyMoved As Decimal?, QtyComplete As Decimal?, ItemLotTracked As Integer?, ItemSerialTracked As Integer?, Infobar As String, Prompt As String, PromptButtons As String) = iJobReceiptValidateJobExt.JobReceiptValidateJobSp(Job, Suffix, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            JobrouteOperNum = result.JobrouteOperNum
            QtyMoved = result.QtyMoved
            QtyComplete = result.QtyComplete
            ItemLotTracked = result.ItemLotTracked
            ItemSerialTracked = result.ItemSerialTracked
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobrouteExistsSp(ByVal Job As String, ByVal Suffix As Short?, ByRef JobrouteExists As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobrouteExistsExt As IJobrouteExists = New JobrouteExistsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, JobrouteExists As Integer?) = iJobrouteExistsExt.JobrouteExistsSp(Job, Suffix, JobrouteExists)
            Dim Severity As Integer = result.ReturnCode.Value
            JobrouteExists = result.JobrouteExists
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function JobStatusChangeMassSp(ByVal Process As String, ByVal FromJobStatus As String, ByVal FromJobStatusLabel As String, ByVal ToJobStatus As String, ByVal ToJobStatusLabel As String, ByVal SelectFinish As Byte?, ByVal StartingJob As String, ByVal StartingSuffix As Integer?, ByVal EndingJob As String, ByVal EndingSuffix As Integer?, ByVal EarliestJobEndDate As DateTime?, ByVal LatestJobEndDate As DateTime?, ByVal EarliestStartDate As DateTime?, ByVal LatestStartDate As DateTime?, ByVal DeleteHistoryJobs As Byte?, ByVal CopyRouting As Byte?,
<[Optional]> ByVal EStartDateOffset As Short?,
<[Optional]> ByVal LStartDateOffset As Short?,
<[Optional]> ByVal EEndDateOffset As Short?,
<[Optional]> ByVal LEndDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iJobStatusChangeMassExt As IJobStatusChangeMass = New JobStatusChangeMassFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iJobStatusChangeMassExt.JobStatusChangeMassSp(Process, FromJobStatus, FromJobStatusLabel, ToJobStatus, ToJobStatusLabel, SelectFinish, StartingJob, StartingSuffix, EndingJob, EndingSuffix, EarliestJobEndDate, LatestJobEndDate, EarliestStartDate, LatestStartDate, DeleteHistoryJobs, CopyRouting, EStartDateOffset, LStartDateOffset, EEndDateOffset, LEndDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_AddAlternateSp(ByVal JobItem As String,
<[Optional]> ByVal AlternateID As String,
<[Optional]> ByVal AlternateDescription As String, ByRef JobSuffix As Short?, ByRef Infobar As String,
<[Optional]> ByRef OperNum As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMO_AddAlternateExt As IMO_AddAlternate = New MO_AddAlternateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, JobSuffix As Short?, Infobar As String, OperNum As Integer?) = iMO_AddAlternateExt.MO_AddAlternateSp(JobItem, AlternateID, AlternateDescription, JobSuffix, Infobar, OperNum)
            Dim Severity As Integer = result.ReturnCode.Value
            JobSuffix = result.JobSuffix
            Infobar = result.Infobar
            OperNum = result.OperNum
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_NextAlternateSuffixSp(ByVal Item As String, ByRef Suffix As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_NextAlternateSuffixExt As IMO_NextAlternateSuffix = New MO_NextAlternateSuffixFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Suffix As Integer?) = iMO_NextAlternateSuffixExt.MO_NextAlternateSuffixSp(Item, Suffix)
            Dim Severity As Integer = result.ReturnCode.Value
            Suffix = result.Suffix
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_ValAlternateAskSp(ByVal JobItem As String, ByVal AlternateID As String, ByRef AlternateDescription As String, ByRef JobSuffix As Integer?, ByRef PromptAddMsg As String, ByRef PromptAddButtons As String, ByRef Infobar As String,
<[Optional]> ByRef OperNum As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_ValAlternateAskExt As IMO_ValAlternateAsk = New MO_ValAlternateAskFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AlternateDescription As String, JobSuffix As Integer?, PromptAddMsg As String, PromptAddButtons As String, Infobar As String, OperNum As Integer?) = iMO_ValAlternateAskExt.MO_ValAlternateAskSp(JobItem, AlternateID, AlternateDescription, JobSuffix, PromptAddMsg, PromptAddButtons, Infobar, OperNum)
            Dim Severity As Integer = result.ReturnCode.Value
            AlternateDescription = result.AlternateDescription
            JobSuffix = result.JobSuffix
            PromptAddMsg = result.PromptAddMsg
            PromptAddButtons = result.PromptAddButtons
            Infobar = result.Infobar
            OperNum = result.OperNum
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_GetPrintRootJobQtysSp(ByVal Job As String, ByVal Suffix As Short?, ByRef JobQtyReleased As Decimal?, ByRef PPJobMinSheetCount As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_GetPrintRootJobQtysExt As IPP_GetPrintRootJobQtys = New PP_GetPrintRootJobQtysFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, JobQtyReleased As Decimal?, PPJobMinSheetCount As Decimal?, Infobar As String) = iPP_GetPrintRootJobQtysExt.PP_GetPrintRootJobQtysSp(Job, Suffix, JobQtyReleased, PPJobMinSheetCount, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            JobQtyReleased = result.JobQtyReleased
            PPJobMinSheetCount = result.PPJobMinSheetCount
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_SumPrintQuotePriceForRootJobSp(ByVal RootJob As String, ByVal RootSuffix As Short?, ByRef PriceForRootJob As Decimal?, ByRef CoitemExtPrice As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_SumPrintQuotePriceForRootJobExt As IPP_SumPrintQuotePriceForRootJob = New PP_SumPrintQuotePriceForRootJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PriceForRootJob As Decimal?, CoitemExtPrice As Decimal?, Infobar As String) = iPP_SumPrintQuotePriceForRootJobExt.PP_SumPrintQuotePriceForRootJobSp(RootJob, RootSuffix, PriceForRootJob, CoitemExtPrice, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PriceForRootJob = result.PriceForRootJob
            CoitemExtPrice = result.CoitemExtPrice
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProductionPlannerAlertsSp(ByRef PastDueJobs As Integer?, ByRef ProductionDueJobs As Integer?, ByRef NumberOfUserTasks As Integer?, ByRef NumberOfEventMessages As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProductionPlannerAlertsExt As IProductionPlannerAlerts = New ProductionPlannerAlertsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PastDueJobs As Integer?, ProductionDueJobs As Integer?, NumberOfUserTasks As Integer?, NumberOfEventMessages As Integer?) = iProductionPlannerAlertsExt.ProductionPlannerAlertsSp(PastDueJobs, ProductionDueJobs, NumberOfUserTasks, NumberOfEventMessages)
            Dim Severity As Integer = result.ReturnCode.Value
            PastDueJobs = result.PastDueJobs
            ProductionDueJobs = result.ProductionDueJobs
            NumberOfUserTasks = result.NumberOfUserTasks
            NumberOfEventMessages = result.NumberOfEventMessages
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function PsStatSp(ByVal PsFromStat As String, ByVal PsToStat As String, ByVal FromPsNum As String, ByVal ToPsNum As String, ByVal FromItem As String, ByVal ToItem As String, ByVal FromDate As DateTime?, ByVal ToDate As DateTime?, ByVal PProcess As Byte?, ByVal CopyPSItemBOM As Byte?, ByVal CopyPSReleaseBOM As Byte?, ByRef Infobar As String,
<[Optional]> ByVal StartingDateOffset As Short?,
<[Optional]> ByVal EndingDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPsStatExt As IPsStat = New PsStatFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iPsStatExt.PsStatSp(PsFromStat, PsToStat, FromPsNum, ToPsNum, FromItem, ToItem, FromDate, ToDate, PProcess, CopyPSItemBOM, CopyPSReleaseBOM, Infobar, StartingDateOffset, EndingDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RSQC_CheckIPSp(ByVal i_begjob As String, ByVal i_endjob As String, ByVal i_begsuffix As String, ByVal i_endsuffix As String, ByVal EarliestStartDate As DateTime?, ByVal LatestStartDate As DateTime?, ByVal EarliestJobEndDate As DateTime?, ByVal LatestJobEndDate As DateTime?,
<[Optional]> ByVal EStartDateOffset As Short?,
<[Optional]> ByVal LStartDateOffset As Short?,
<[Optional]> ByVal EEndDateOffset As Short?,
<[Optional]> ByVal LEndDateOffset As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRSQC_CheckIPExt As IRSQC_CheckIP = New RSQC_CheckIPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRSQC_CheckIPExt.RSQC_CheckIPSp(i_begjob, i_endjob, i_begsuffix, i_endsuffix, EarliestStartDate, LatestStartDate, EarliestJobEndDate, LatestJobEndDate, EStartDateOffset, LStartDateOffset, EEndDateOffset, LEndDateOffset, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function SchedpSp(ByVal pType As String, ByVal pStatus As String, ByVal pUseCr As String, ByVal pStartingJobNum As String, ByVal pEndingJobNum As String, ByVal pStartingSuffixNum As Short?, ByVal pEndingSuffixNum As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSchedpExt As ISchedp = New SchedpFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iSchedpExt.SchedpSp(pType, pStatus, pUseCr, pStartingJobNum, pEndingJobNum, pStartingSuffixNum, pEndingSuffixNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdatePlannedCostsSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdatePlannedCostsExt As IUpdatePlannedCosts = New UpdatePlannedCostsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdatePlannedCostsExt.UpdatePlannedCostsSp(PJob, PSuffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateJobRevisionSp(ByVal PItem As String, ByRef PRevision As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateJobRevisionExt As IValidateJobRevision = New ValidateJobRevisionFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PRevision As String, Infobar As String) = iValidateJobRevisionExt.ValidateJobRevisionSp(PItem, PRevision, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PRevision = result.PRevision
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobValidateProdMixSp(ByVal PProdMix As String, ByVal PJob As String, ByVal PSuffix As Short?, ByVal PItem As String, ByVal PQtyReleased As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobValidateProdMixExt As IJobValidateProdMix = New JobValidateProdMixFactory().Create(appDb)

            Dim Severity As Integer = iJobValidateProdMixExt.JobValidateProdMixSp(PProdMix, PJob, PSuffix, PItem, PQtyReleased, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCalcSubJobDatesSp(ByRef ApsCalcSubJobDates As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsCalcSubJobDatesExt As IApsCalcSubJobDates = New ApsCalcSubJobDatesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ApsCalcSubJobDates As Integer?) = iApsCalcSubJobDatesExt.ApsCalcSubJobDatesSp(ApsCalcSubJobDates)
            Dim Severity As Integer = result.ReturnCode.Value
            ApsCalcSubJobDates = result.ApsCalcSubJobDates
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_JobCustomersSp(
<[Optional]> ByVal CustNum As String,
<[Optional]> ByVal FilterString As String,
<[Optional]> ByVal SiteGroup As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_JobCustomersExt As ICLM_JobCustomers = New CLM_JobCustomersFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_JobCustomersExt.CLM_JobCustomersSp(CustNum, FilterString, SiteGroup)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_JobsReferencingProjectsSp(
<[Optional]> ByVal ProjMgr As String,
<[Optional]> ByVal CutoffDate As DateTime?,
<[Optional]> ByVal WBSNum As String,
<[Optional]> ByVal FilterString As String,
<[Optional]> ByVal SiteGroup As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_JobsReferencingProjectsExt As ICLM_JobsReferencingProjects = New CLM_JobsReferencingProjectsFactory().Create(appDb, bunchedLoadCollection, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_JobsReferencingProjectsExt.CLM_JobsReferencingProjectsSp(ProjMgr, CutoffDate, WBSNum, FilterString, SiteGroup)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyBomDoProcessSp(ByVal FromJobCategory As String, ByVal FromJob As String, ByVal FromSuffix As Short?, ByVal FromItem As String, ByVal StartOper As Integer?, ByVal EndOper As Integer?, ByVal LMBVar As String, ByVal Revision As String, ByVal ScrapFactor As Byte?, ByVal CopyBom As Byte?, ByVal ToJobCategory As String, ByVal ToItem As String, ByRef ToJob As String, ByRef ToSuffix As Integer?, ByVal EffectDate As DateTime?, ByVal OptionType As String, ByVal AfterOper As Integer?, ByVal CopyToPSReleaseBOM As Byte?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyUetValues As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCopyBomDoProcessExt As ICopyBomDoProcess = New CopyBomDoProcessFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ToJob As String, ToSuffix As Integer?, Infobar As String) = iCopyBomDoProcessExt.CopyBomDoProcessSp(FromJobCategory, FromJob, FromSuffix, FromItem, StartOper, EndOper, LMBVar, Revision, ScrapFactor, CopyBom, ToJobCategory, ToItem, ToJob, ToSuffix, EffectDate, OptionType, AfterOper, CopyToPSReleaseBOM, Infobar, CopyUetValues)
            Dim Severity As Integer = result.ReturnCode.Value
            ToJob = result.ToJob
            ToSuffix = result.ToSuffix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyJobMaterialSp(ByVal FromCardType As String, ByVal FromJobType As String, ByVal FromJob As String, ByVal FromSuffix As Short?, ByVal FromOperNum As Integer?, ByVal FromSequence As Short?, ByVal ToCardType As String, ByVal ToJobType As String, ByVal ToJob As String, ByVal ToSuffix As Short?, ByVal ToOperNum As Integer?, ByVal ToSequence As Short?, ByVal CutFlag As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCopyJobMaterialExt As ICopyJobMaterial = New CopyJobMaterialFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCopyJobMaterialExt.CopyJobMaterialSp(FromCardType, FromJobType, FromJob, FromSuffix, FromOperNum, FromSequence, ToCardType, ToJobType, ToJob, ToSuffix, ToOperNum, ToSequence, CutFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreatePsitemReleasesSp(ByVal InsertFlag As Byte?, ByVal Job As String, ByRef Suffix As Integer?, ByVal EndDate As DateTime?, ByVal Status As String, ByVal OldStatus As String, ByVal QtyReleased As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCreatePsitemReleasesExt As ICreatePsitemReleases = New CreatePsitemReleasesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Suffix As Integer?, Infobar As String) = iCreatePsitemReleasesExt.CreatePsitemReleasesSp(InsertFlag, Job, Suffix, EndDate, Status, OldStatus, QtyReleased, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Suffix = result.Suffix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobCopySp(ByVal FromType As String, ByVal FromJob As String, ByVal FromSuffix As Short?, ByVal FromOperNumStart As Integer?, ByVal FromOperNumEnd As Integer?, ByVal FromOpt As String, ByVal FromRevision As String, ByVal ToType As String, ByVal ToItem As String, ByRef ToJob As String, ByRef ToSuffix As Integer?, ByVal EffectDate As DateTime?, ByVal ToOpt As String, ByVal InsertOperNum As Integer?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal SetQtyAllocJob As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal OverwriteExistingJobroute As Byte?,
<[Optional], DefaultParameterValue(Nothing)> ByVal SessionID As Guid?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal FromMRP As Byte?,
<[Optional]> ByVal PLN_Ref_Type As String,
<[Optional]> ByVal PLN_Ref_Num As String,
<[Optional]> ByVal PLN_ref_suf As Short?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyUetValues As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobCopyExt As IJobCopy = New JobCopyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ToJob As String, ToSuffix As Integer?, Infobar As String) = iJobCopyExt.JobCopySp(FromType, FromJob, FromSuffix, FromOperNumStart, FromOperNumEnd, FromOpt, FromRevision, ToType, ToItem, ToJob, ToSuffix, EffectDate, ToOpt, InsertOperNum, SetQtyAllocJob, OverwriteExistingJobroute, SessionID, Infobar, FromMRP, PLN_Ref_Type, PLN_Ref_Num, PLN_ref_suf, CopyUetValues)
            Dim Severity As Integer = result.ReturnCode.Value
            ToJob = result.ToJob
            ToSuffix = result.ToSuffix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobiRefSp(ByVal PJob As String, ByVal PSuffix As Short?, ByVal PItem As String, ByRef FoundRef As Integer?, ByRef PMessage As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobiRefExt As IJobiRef = New JobiRefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, FoundRef As Integer?, PMessage As String, Infobar As String) = iJobiRefExt.JobiRefSp(PJob, PSuffix, PItem, FoundRef, PMessage, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            FoundRef = result.FoundRef
            PMessage = result.PMessage
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrdersCopyJobSp(ByRef PJob As String, ByRef PSuffix As Integer?, ByVal JobItem As String, ByVal JobRevision As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobOrdersCopyJobExt As IJobOrdersCopyJob = New JobOrdersCopyJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PJob As String, PSuffix As Integer?, Infobar As String) = iJobOrdersCopyJobExt.JobOrdersCopyJobSp(PJob, PSuffix, JobItem, JobRevision, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PJob = result.PJob
            PSuffix = result.PSuffix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrdersPreSaveSp(ByVal PJob As String, ByVal PSuffix As Short?, ByVal PJobType As String, ByVal PItem As String, ByVal PQtyReleased As Decimal?, ByVal PCoProductMix As Byte?, ByVal POrdType As String, ByVal POrdNum As String, ByVal POrdLine As Short?, ByVal POrdRelease As Short?, ByVal OldStat As String, ByVal NewStat As String, ByRef PStartDate As DateTime?, ByRef PEndDate As DateTime?, ByRef PStartTick As Decimal?, ByRef PEndTick As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobOrdersPreSaveExt As IJobOrdersPreSave = New JobOrdersPreSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PStartDate As DateTime?, PEndDate As DateTime?, PStartTick As Decimal?, PEndTick As Decimal?, Infobar As String) = iJobOrdersPreSaveExt.JobOrdersPreSaveSp(PJob, PSuffix, PJobType, PItem, PQtyReleased, PCoProductMix, POrdType, POrdNum, POrdLine, POrdRelease, OldStat, NewStat, PStartDate, PEndDate, PStartTick, PEndTick, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PStartDate = result.PStartDate
            PEndDate = result.PEndDate
            PStartTick = result.PStartTick
            PEndTick = result.PEndTick
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobOrdersValidateItemSp(ByVal PItem As String, ByVal PJob As String, ByVal PSuffix As Short?, ByVal PJobType As String, ByVal PCoProductMix As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobOrdersValidateItemExt As IJobOrdersValidateItem = New JobOrdersValidateItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobOrdersValidateItemExt.JobOrdersValidateItemSp(PItem, PJob, PSuffix, PJobType, PCoProductMix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobReceiptPostSp(ByVal Job As String, ByVal Suffix As Short?, ByVal Item As String, ByVal OperNum As Integer?, ByVal Qty As Decimal?, ByVal Loc As String, ByVal Lot As String, ByVal TransDate As DateTime?, ByVal Override As Byte?, ByRef CanOverride As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String, ByVal ImportDocId As String,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal ContainerNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobReceiptPostExt As IJobReceiptPost = New JobReceiptPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CanOverride As Integer?, Infobar As String) = iJobReceiptPostExt.JobReceiptPostSp(Job, Suffix, Item, OperNum, Qty, Loc, Lot, TransDate, Override, CanOverride, Infobar, DocumentNum, ImportDocId, EmpNum, ContainerNum)
            Dim Severity As Integer = result.ReturnCode.Value
            CanOverride = result.CanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function JobrollSp(ByVal ExBegFinishJob As String, ByVal ExBegSuffix As Short?, ByVal ExEndFinishJob As String, ByVal ExEndSuffix As Short?, ByVal TResetI As Byte?, ByVal TResetP As Byte?, ByVal TResetR As Byte?, ByVal TResetJ As Byte?, ByVal TUpdateA As Byte?, ByVal ExOptprResetByProdCost As Byte?, ByVal ExOptgoListOpts As Byte?,
<[Optional]> ByVal BgTaskID As Integer?,
<[Optional]> ByVal UserID As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobrollExt As IJobroll = New JobrollFactory().Create(appDb, bunchedLoadCollection, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iJobrollExt.JobrollSp(ExBegFinishJob, ExBegSuffix, ExEndFinishJob, ExEndSuffix, TResetI, TResetP, TResetR, TResetJ, TUpdateA, ExOptprResetByProdCost, ExOptgoListOpts, BgTaskID, UserID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LeaveItemSp(ByVal PNewItem As String, ByVal PJob As String, ByVal PSuffix As Integer?, ByVal PType As String, ByRef PDescription As String, ByRef PRevision As String, ByRef PWipAcct As String, ByRef PWipAcctUnit1 As String, ByRef PWipAcctUnit2 As String, ByRef PWipAcctUnit3 As String, ByRef PWipAcctUnit4 As String, ByRef PJcbAcct As String, ByRef PJcbAcctUnit1 As String, ByRef PJcbAcctUnit2 As String, ByRef PJcbAcctUnit3 As String, ByRef PJcbAcctUnit4 As String, ByRef PWipLbrAcct As String, ByRef PWipLbrAcctUnit1 As String, ByRef PWipLbrAcctUnit2 As String, ByRef PWipLbrAcctUnit3 As String, ByRef PWipLbrAcctUnit4 As String, ByRef PWipFovhdAcct As String, ByRef PWipFovhdAcctUnit1 As String, ByRef PWipFovhdAcctUnit2 As String, ByRef PWipFovhdAcctUnit3 As String, ByRef PWipFovhdAcctUnit4 As String, ByRef PWipVovhdAcct As String, ByRef PWipVovhdAcctUnit1 As String, ByRef PWipVovhdAcctUnit2 As String, ByRef PWipVovhdAcctUnit3 As String, ByRef PWipVovhdAcctUnit4 As String, ByRef PWipOutAcct As String, ByRef PWipOutAcctUnit1 As String, ByRef PWipOutAcctUnit2 As String, ByRef PWipOutAcctUnit3 As String, ByRef PWipOutAcctUnit4 As String, ByRef PProdMix As String, ByRef PWipAcctDescription As String, ByRef PWipAccessUnit1 As String, ByRef PWipAccessUnit2 As String, ByRef PWipAccessUnit3 As String, ByRef PWipAccessUnit4 As String, ByRef PJcbAcctDescription As String, ByRef PJcbAccessUnit1 As String, ByRef PJcbAccessUnit2 As String, ByRef PJcbAccessUnit3 As String, ByRef PJcbAccessUnit4 As String, ByRef PWipLbrAcctDescription As String, ByRef PWipLbrAccessUnit1 As String, ByRef PWipLbrAccessUnit2 As String, ByRef PWipLbrAccessUnit3 As String, ByRef PWipLbrAccessUnit4 As String, ByRef PWipFovhdAcctDescription As String, ByRef PWipFovhdAccessUnit1 As String, ByRef PWipFovhdAccessUnit2 As String, ByRef PWipFovhdAccessUnit3 As String, ByRef PWipFovhdAccessUnit4 As String, ByRef PWipVovhdAcctDescription As String, ByRef PWipVovhdAccessUnit1 As String, ByRef PWipVovhdAccessUnit2 As String, ByRef PWipVovhdAccessUnit3 As String, ByRef PWipVovhdAccessUnit4 As String, ByRef PWipOutAcctDescription As String, ByRef PWipOutAccessUnit1 As String, ByRef PWipOutAccessUnit2 As String, ByRef PWipOutAccessUnit3 As String, ByRef PWipOutAccessUnit4 As String, ByRef Infobar As String, ByRef PreassignLots As Integer?, ByRef PreassignSerials As Integer?, ByRef ItemLotTracked As Integer?, ByRef ItemSerialTracked As Integer?, ByRef ItemLotPrefix As String, ByRef ItemSerialPrefix As String, ByRef PWipAcctIsControl As Integer?, ByRef PJcbAcctIsControl As Integer?, ByRef PWipLbrAcctIsControl As Integer?, ByRef PWipFovhdAcctIsControl As Integer?, ByRef PWipVovhdAcctIsControl As Integer?, ByRef PWipOutAcctIsControl As Integer?,
        <[Optional]> ByRef PUM As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iLeaveItemExt As ILeaveItem = New LeaveItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PDescription As String, PRevision As String, PWipAcct As String, PWipAcctUnit1 As String, PWipAcctUnit2 As String, PWipAcctUnit3 As String, PWipAcctUnit4 As String, PJcbAcct As String, PJcbAcctUnit1 As String, PJcbAcctUnit2 As String, PJcbAcctUnit3 As String, PJcbAcctUnit4 As String, PWipLbrAcct As String, PWipLbrAcctUnit1 As String, PWipLbrAcctUnit2 As String, PWipLbrAcctUnit3 As String, PWipLbrAcctUnit4 As String, PWipFovhdAcct As String, PWipFovhdAcctUnit1 As String, PWipFovhdAcctUnit2 As String, PWipFovhdAcctUnit3 As String, PWipFovhdAcctUnit4 As String, PWipVovhdAcct As String, PWipVovhdAcctUnit1 As String, PWipVovhdAcctUnit2 As String, PWipVovhdAcctUnit3 As String, PWipVovhdAcctUnit4 As String, PWipOutAcct As String, PWipOutAcctUnit1 As String, PWipOutAcctUnit2 As String, PWipOutAcctUnit3 As String, PWipOutAcctUnit4 As String, PProdMix As String, PWipAcctDescription As String, PWipAccessUnit1 As String, PWipAccessUnit2 As String, PWipAccessUnit3 As String, PWipAccessUnit4 As String, PJcbAcctDescription As String, PJcbAccessUnit1 As String, PJcbAccessUnit2 As String, PJcbAccessUnit3 As String, PJcbAccessUnit4 As String, PWipLbrAcctDescription As String, PWipLbrAccessUnit1 As String, PWipLbrAccessUnit2 As String, PWipLbrAccessUnit3 As String, PWipLbrAccessUnit4 As String, PWipFovhdAcctDescription As String, PWipFovhdAccessUnit1 As String, PWipFovhdAccessUnit2 As String, PWipFovhdAccessUnit3 As String, PWipFovhdAccessUnit4 As String, PWipVovhdAcctDescription As String, PWipVovhdAccessUnit1 As String, PWipVovhdAccessUnit2 As String, PWipVovhdAccessUnit3 As String, PWipVovhdAccessUnit4 As String, PWipOutAcctDescription As String, PWipOutAccessUnit1 As String, PWipOutAccessUnit2 As String, PWipOutAccessUnit3 As String, PWipOutAccessUnit4 As String, Infobar As String, PreassignLots As Integer?, PreassignSerials As Integer?, ItemLotTracked As Integer?, ItemSerialTracked As Integer?, ItemLotPrefix As String, ItemSerialPrefix As String, PWipAcctIsControl As Integer?, PJcbAcctIsControl As Integer?, PWipLbrAcctIsControl As Integer?, PWipFovhdAcctIsControl As Integer?, PWipVovhdAcctIsControl As Integer?, PWipOutAcctIsControl As Integer?, PUM As String) = iLeaveItemExt.LeaveItemSp(PNewItem, PJob, PSuffix, PType, PDescription, PRevision, PWipAcct, PWipAcctUnit1, PWipAcctUnit2, PWipAcctUnit3, PWipAcctUnit4, PJcbAcct, PJcbAcctUnit1, PJcbAcctUnit2, PJcbAcctUnit3, PJcbAcctUnit4, PWipLbrAcct, PWipLbrAcctUnit1, PWipLbrAcctUnit2, PWipLbrAcctUnit3, PWipLbrAcctUnit4, PWipFovhdAcct, PWipFovhdAcctUnit1, PWipFovhdAcctUnit2, PWipFovhdAcctUnit3, PWipFovhdAcctUnit4, PWipVovhdAcct, PWipVovhdAcctUnit1, PWipVovhdAcctUnit2, PWipVovhdAcctUnit3, PWipVovhdAcctUnit4, PWipOutAcct, PWipOutAcctUnit1, PWipOutAcctUnit2, PWipOutAcctUnit3, PWipOutAcctUnit4, PProdMix, PWipAcctDescription, PWipAccessUnit1, PWipAccessUnit2, PWipAccessUnit3, PWipAccessUnit4, PJcbAcctDescription, PJcbAccessUnit1, PJcbAccessUnit2, PJcbAccessUnit3, PJcbAccessUnit4, PWipLbrAcctDescription, PWipLbrAccessUnit1, PWipLbrAccessUnit2, PWipLbrAccessUnit3, PWipLbrAccessUnit4, PWipFovhdAcctDescription, PWipFovhdAccessUnit1, PWipFovhdAccessUnit2, PWipFovhdAccessUnit3, PWipFovhdAccessUnit4, PWipVovhdAcctDescription, PWipVovhdAccessUnit1, PWipVovhdAccessUnit2, PWipVovhdAccessUnit3, PWipVovhdAccessUnit4, PWipOutAcctDescription, PWipOutAccessUnit1, PWipOutAccessUnit2, PWipOutAccessUnit3, PWipOutAccessUnit4, Infobar, PreassignLots, PreassignSerials, ItemLotTracked, ItemSerialTracked, ItemLotPrefix, ItemSerialPrefix, PWipAcctIsControl, PJcbAcctIsControl, PWipLbrAcctIsControl, PWipFovhdAcctIsControl, PWipVovhdAcctIsControl, PWipOutAcctIsControl, PUM)
            Dim Severity As Integer = result.ReturnCode.Value
            PDescription = result.PDescription
            PRevision = result.PRevision
            PWipAcct = result.PWipAcct
            PWipAcctUnit1 = result.PWipAcctUnit1
            PWipAcctUnit2 = result.PWipAcctUnit2
            PWipAcctUnit3 = result.PWipAcctUnit3
            PWipAcctUnit4 = result.PWipAcctUnit4
            PJcbAcct = result.PJcbAcct
            PJcbAcctUnit1 = result.PJcbAcctUnit1
            PJcbAcctUnit2 = result.PJcbAcctUnit2
            PJcbAcctUnit3 = result.PJcbAcctUnit3
            PJcbAcctUnit4 = result.PJcbAcctUnit4
            PWipLbrAcct = result.PWipLbrAcct
            PWipLbrAcctUnit1 = result.PWipLbrAcctUnit1
            PWipLbrAcctUnit2 = result.PWipLbrAcctUnit2
            PWipLbrAcctUnit3 = result.PWipLbrAcctUnit3
            PWipLbrAcctUnit4 = result.PWipLbrAcctUnit4
            PWipFovhdAcct = result.PWipFovhdAcct
            PWipFovhdAcctUnit1 = result.PWipFovhdAcctUnit1
            PWipFovhdAcctUnit2 = result.PWipFovhdAcctUnit2
            PWipFovhdAcctUnit3 = result.PWipFovhdAcctUnit3
            PWipFovhdAcctUnit4 = result.PWipFovhdAcctUnit4
            PWipVovhdAcct = result.PWipVovhdAcct
            PWipVovhdAcctUnit1 = result.PWipVovhdAcctUnit1
            PWipVovhdAcctUnit2 = result.PWipVovhdAcctUnit2
            PWipVovhdAcctUnit3 = result.PWipVovhdAcctUnit3
            PWipVovhdAcctUnit4 = result.PWipVovhdAcctUnit4
            PWipOutAcct = result.PWipOutAcct
            PWipOutAcctUnit1 = result.PWipOutAcctUnit1
            PWipOutAcctUnit2 = result.PWipOutAcctUnit2
            PWipOutAcctUnit3 = result.PWipOutAcctUnit3
            PWipOutAcctUnit4 = result.PWipOutAcctUnit4
            PProdMix = result.PProdMix
            PWipAcctDescription = result.PWipAcctDescription
            PWipAccessUnit1 = result.PWipAccessUnit1
            PWipAccessUnit2 = result.PWipAccessUnit2
            PWipAccessUnit3 = result.PWipAccessUnit3
            PWipAccessUnit4 = result.PWipAccessUnit4
            PJcbAcctDescription = result.PJcbAcctDescription
            PJcbAccessUnit1 = result.PJcbAccessUnit1
            PJcbAccessUnit2 = result.PJcbAccessUnit2
            PJcbAccessUnit3 = result.PJcbAccessUnit3
            PJcbAccessUnit4 = result.PJcbAccessUnit4
            PWipLbrAcctDescription = result.PWipLbrAcctDescription
            PWipLbrAccessUnit1 = result.PWipLbrAccessUnit1
            PWipLbrAccessUnit2 = result.PWipLbrAccessUnit2
            PWipLbrAccessUnit3 = result.PWipLbrAccessUnit3
            PWipLbrAccessUnit4 = result.PWipLbrAccessUnit4
            PWipFovhdAcctDescription = result.PWipFovhdAcctDescription
            PWipFovhdAccessUnit1 = result.PWipFovhdAccessUnit1
            PWipFovhdAccessUnit2 = result.PWipFovhdAccessUnit2
            PWipFovhdAccessUnit3 = result.PWipFovhdAccessUnit3
            PWipFovhdAccessUnit4 = result.PWipFovhdAccessUnit4
            PWipVovhdAcctDescription = result.PWipVovhdAcctDescription
            PWipVovhdAccessUnit1 = result.PWipVovhdAccessUnit1
            PWipVovhdAccessUnit2 = result.PWipVovhdAccessUnit2
            PWipVovhdAccessUnit3 = result.PWipVovhdAccessUnit3
            PWipVovhdAccessUnit4 = result.PWipVovhdAccessUnit4
            PWipOutAcctDescription = result.PWipOutAcctDescription
            PWipOutAccessUnit1 = result.PWipOutAccessUnit1
            PWipOutAccessUnit2 = result.PWipOutAccessUnit2
            PWipOutAccessUnit3 = result.PWipOutAccessUnit3
            PWipOutAccessUnit4 = result.PWipOutAccessUnit4
            Infobar = result.Infobar
            PreassignLots = result.PreassignLots
            PreassignSerials = result.PreassignSerials
            ItemLotTracked = result.ItemLotTracked
            ItemSerialTracked = result.ItemSerialTracked
            ItemLotPrefix = result.ItemLotPrefix
            ItemSerialPrefix = result.ItemSerialPrefix
            PWipAcctIsControl = result.PWipAcctIsControl
            PJcbAcctIsControl = result.PJcbAcctIsControl
            PWipLbrAcctIsControl = result.PWipLbrAcctIsControl
            PWipFovhdAcctIsControl = result.PWipFovhdAcctIsControl
            PWipVovhdAcctIsControl = result.PWipVovhdAcctIsControl
            PWipOutAcctIsControl = result.PWipOutAcctIsControl
            PUM = result.PUM
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MO_CLM_EstResourceItemSp(
        <[Optional]> ByVal selectedResource As String,
        <[Optional], DefaultParameterValue(0)> ByVal productCycle As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_CLM_EstResourceItemExt As IMO_CLM_EstResourceItem = New MO_CLM_EstResourceItemFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iMO_CLM_EstResourceItemExt.MO_CLM_EstResourceItemSp(selectedResource, productCycle)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function JobrollSpNonTrans(ByVal ExBegFinishJob As String, ByVal ExBegSuffix As Short?, ByVal ExEndFinishJob As String, ByVal ExEndSuffix As Short?, ByVal TResetI As Byte?, ByVal TResetP As Byte?, ByVal TResetR As Byte?, ByVal TResetJ As Byte?, ByVal TUpdateA As Byte?, ByVal ExOptprResetByProdCost As Byte?, ByVal ExOptgoListOpts As Byte?,
<[Optional]> ByVal BgTaskID As Integer?,
<[Optional]> ByVal UserID As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobrollExt As IJobroll = New JobrollFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iJobrollExt.JobrollSp(ExBegFinishJob, ExBegSuffix, ExEndFinishJob, ExEndSuffix, TResetI, TResetP, TResetR, TResetJ, TUpdateA, ExOptprResetByProdCost, ExOptgoListOpts, BgTaskID, UserID)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MO_CLM_ResourceItemSp(
        <[Optional]> ByVal selectedResource As String,
        <[Optional], DefaultParameterValue(0)> ByVal productCycle As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_CLM_ResourceItemExt As IMO_CLM_ResourceItem = New MO_CLM_ResourceItemFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iMO_CLM_ResourceItemExt.MO_CLM_ResourceItemSp(selectedResource, productCycle)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_ValAlternateSp(ByVal JobItem As String, ByVal AlternateID As String, ByRef AlternateDescription As String, ByRef JobSuffix As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMO_ValAlternateExt As IMO_ValAlternate = New MO_ValAlternateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AlternateDescription As String, JobSuffix As Integer?, Infobar As String) = iMO_ValAlternateExt.MO_ValAlternateSp(JobItem, AlternateID, AlternateDescription, JobSuffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AlternateDescription = result.AlternateDescription
            JobSuffix = result.JobSuffix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function NextWoSp(ByVal PContext As String, ByVal PPrefix As String, ByVal PKeyLength As Integer?, ByRef PKey As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iNextWoExt As INextWo = New NextWoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PKey As String, Infobar As String) = iNextWoExt.NextWoSp(PContext, PPrefix, PKeyLength, PKey, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PKey = result.PKey
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PmfPnWrkProdInitUi(
<[Optional]> ByRef InfoBar As String, ByVal PnRp As Guid?, ByVal JobRp As Guid?, ByRef TranDate As DateTime?, ByRef JobDesc As String, ByRef Lot As String, ByRef LotTrack As Integer?, ByRef Loc As String, ByRef Qty As Decimal?, ByRef Um As String, ByRef QtyOrd As Decimal?, ByRef QtyComplete As Decimal?, ByRef QtyScrapped As Decimal?, ByRef QtyRem As Decimal?, ByRef ContainerNum As String, ByRef DocNo As String, ByRef StockUm As String, ByRef UserInstructions As String, ByRef OutputEntryEnabled As Integer?,
<[Optional]> ByRef DefWipItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPmfPnWrkProdInitUiExt As IPmfPnWrkProdInitUi = New PmfPnWrkProdInitUiFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, InfoBar As String, TranDate As DateTime?, JobDesc As String, Lot As String, LotTrack As Integer?, Loc As String, Qty As Decimal?, Um As String, QtyOrd As Decimal?, QtyComplete As Decimal?, QtyScrapped As Decimal?, QtyRem As Decimal?, ContainerNum As String, DocNo As String, StockUm As String, UserInstructions As String, OutputEntryEnabled As Integer?, DefWipItem As String) = iPmfPnWrkProdInitUiExt.PmfPnWrkProdInitUiSp(InfoBar, PnRp, JobRp, TranDate, JobDesc, Lot, LotTrack, Loc, Qty, Um, QtyOrd, QtyComplete, QtyScrapped, QtyRem, ContainerNum, DocNo, StockUm, UserInstructions, OutputEntryEnabled, DefWipItem)
            Dim Severity As Integer = result.ReturnCode.Value
            InfoBar = result.InfoBar
            TranDate = result.TranDate
            JobDesc = result.JobDesc
            Lot = result.Lot
            LotTrack = result.LotTrack
            Loc = result.Loc
            Qty = result.Qty
            Um = result.Um
            QtyOrd = result.QtyOrd
            QtyComplete = result.QtyComplete
            QtyScrapped = result.QtyScrapped
            QtyRem = result.QtyRem
            ContainerNum = result.ContainerNum
            DocNo = result.DocNo
            StockUm = result.StockUm
            UserInstructions = result.UserInstructions
            OutputEntryEnabled = result.OutputEntryEnabled
            DefWipItem = result.DefWipItem
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function PmfPnBatchLoadJobs(
<[Optional]> ByRef InfoBar As String, ByVal PnRp As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iPmfPnLoadJobsExt As IPmfPnLoadJobs = New PmfPnLoadJobsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, InfoBar As String) = iPmfPnLoadJobsExt.PmfPnLoadJobsSp(InfoBar, PnRp)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            InfoBar = result.InfoBar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_PrintingEstWB_CreateSectionMatlSp(ByVal Job As String, ByVal Suffix As Short?, ByVal Item As String, ByVal Quantity As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_PrintingEstWB_CreateSectionMatlExt As IPP_PrintingEstWB_CreateSectionMatl = New PP_PrintingEstWB_CreateSectionMatlFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPP_PrintingEstWB_CreateSectionMatlExt.PP_PrintingEstWB_CreateSectionMatlSp(Job, Suffix, Item, Quantity, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_SaveJobPropertiesSp(ByVal Job As String, ByVal suffix As Short?, ByVal Out As Integer?, ByVal Up As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_SaveJobPropertiesExt As IPP_SaveJobProperties = New PP_SaveJobPropertiesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPP_SaveJobPropertiesExt.PP_SaveJobPropertiesSp(Job, suffix, Out, Up, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PP_SavePrintingJobDataSp(ByVal Job As String, ByVal Suffix As Short?, ByVal MinSheetCount As Decimal?, ByVal PrintQuotePrice As Decimal?, ByVal Up As Integer?, ByVal Out As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPP_SavePrintingJobDataExt As IPP_SavePrintingJobData = New PP_SavePrintingJobDataFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPP_SavePrintingJobDataExt.PP_SavePrintingJobDataSp(Job, Suffix, MinSheetCount, PrintQuotePrice, Up, Out, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PSSingleReleaseJobCopySp(ByVal RJob As String, ByVal RSuffix As Integer?, ByVal Item As String, ByVal Revision As String,
        <[Optional], DefaultParameterValue(0)> ByVal FromMRP As Integer?,
        <[Optional]> ByVal PLN_Ref_Type As String,
        <[Optional]> ByVal PLN_Ref_Num As String,
        <[Optional]> ByVal PLN_Ref_suf As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPSSingleReleaseJobCopyExt As IPSSingleReleaseJobCopy = New PSSingleReleaseJobCopyFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPSSingleReleaseJobCopyExt.PSSingleReleaseJobCopySp(RJob, RSuffix, Item, Revision, FromMRP, PLN_Ref_Type, PLN_Ref_Num, PLN_Ref_suf, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SyncJobSubJobDueDatesSp(ByVal PJob As String, ByVal PSuffix As Short?, ByVal PPerformSync As Byte?, ByVal POverwriteDates As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSyncJobSubJobDueDatesExt As ISyncJobSubJobDueDates = New SyncJobSubJobDueDatesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSyncJobSubJobDueDatesExt.SyncJobSubJobDueDatesSp(PJob, PSuffix, PPerformSync, POverwriteDates, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateJobOrderWhseSp(ByVal PItem As String, ByVal PWhse As String, ByVal PMultiWhse As Byte?, ByVal PDefWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateJobOrderWhseExt As IValidateJobOrderWhse = New ValidateJobOrderWhseFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateJobOrderWhseExt.ValidateJobOrderWhseSp(PItem, PWhse, PMultiWhse, PDefWhse, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateMfgDateSp(ByVal PStartDateIn As DateTime?, ByVal PEndDateIn As DateTime?, ByVal PItem As String, ByVal PQtyReleased As Decimal?, ByRef PStartDateOut As DateTime?, ByRef PEndDateOut As DateTime?, ByRef PStartTick As Decimal?, ByRef PEndTick As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal HrsPerDay As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateMfgDateExt As IValidateMfgDate = New ValidateMfgDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PStartDateOut As DateTime?, PEndDateOut As DateTime?, PStartTick As Decimal?, PEndTick As Decimal?, Infobar As String) = iValidateMfgDateExt.ValidateMfgDateSp(PStartDateIn, PEndDateIn, PItem, PQtyReleased, PStartDateOut, PEndDateOut, PStartTick, PEndTick, Infobar, HrsPerDay)
            Dim Severity As Integer = result.ReturnCode.Value
            PStartDateOut = result.PStartDateOut
            PEndDateOut = result.PEndDateOut
            PStartTick = result.PStartTick
            PEndTick = result.PEndTick
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RSQC_DeleteJobSp(ByVal i_job As String, ByVal i_suffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRSQC_DeleteJobExt As IRSQC_DeleteJob = New RSQC_DeleteJobFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRSQC_DeleteJobExt.RSQC_DeleteJobSp(i_job, i_suffix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckCojobCopyBOMSp(ByVal Job As String, ByVal Suffix As Integer?, ByVal Item As String, ByVal AlternateID As String, ByVal JobRouteExist As Integer?, ByVal OldJobStat As String, ByRef NewJobStat As String, ByRef Infobar As String) As Integer
        Dim iCheckCojobCopyBOMExt As ICheckCojobCopyBOM = New CheckCojobCopyBOMFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, NewJobStat As String, Infobar As String) = iCheckCojobCopyBOMExt.CheckCojobCopyBOMSp(Job, Suffix, Item, AlternateID, JobRouteExist, OldJobStat, NewJobStat, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        NewJobStat = result.NewJobStat
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetIndentedJobStructureSp(ByVal JobType As String, ByVal Job As String, ByVal Suffix As Integer?, ByRef Infobar As String) As DataTable
        Dim iGetIndentedJobStructureExt As IGetIndentedJobStructure = New GetIndentedJobStructureFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCoed As Integer?, Infobar As String) = iGetIndentedJobStructureExt.GetIndentedJobStructureSp(JobType, Job, Suffix, Infobar)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Infobar = result.Infobar
        Return dt
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Home_MetricPSTodaySp() As DataTable
        Dim iHome_MetricPSTodayExt As IHome_MetricPSToday = New Home_MetricPSTodayFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iHome_MetricPSTodayExt.Home_MetricPSTodaySp()
        If result.Data Is Nothing Then
            Return New DataTable()
        Else
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Home_GetTodaysKeyProductionValuesSp(ByRef CompleteQty As Integer?, ByRef PastDueQty As Integer?) As Integer
        Dim iHome_GetTodaysKeyProductionValuesExt As IHome_GetTodaysKeyProductionValues = New Home_GetTodaysKeyProductionValuesFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, CompleteQty As Integer?, PastDueQty As Integer?) = iHome_GetTodaysKeyProductionValuesExt.Home_GetTodaysKeyProductionValuesSp(CompleteQty, PastDueQty)
        Dim Severity As Integer = result.ReturnCode.Value
        CompleteQty = result.CompleteQty
        PastDueQty = result.PastDueQty
        Return Severity
    End Function
End Class
