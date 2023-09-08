//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production;
using OfficeIntegration = CSI.ExternalContracts.OfficeIntegration.Project;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjMatls")]
	public class SLProjMatls : CSIExtensionClassBase, OfficeIntegration.ISLProjMatls, IExtFTSLProjMatls
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetECVatValuesSp(string ProjNum,
		                            ref string TransNat,
		                            ref string TransNat2,
		                            ref string Delterm,
		                            ref string ProcessInd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetECVatValuesExt = new GetECVatValuesFactory().Create(appDb);
				
				int Severity = iGetECVatValuesExt.GetECVatValuesSp(ProjNum,
				                                                   ref TransNat,
				                                                   ref TransNat2,
				                                                   ref Delterm,
				                                                   ref ProcessInd);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPlanningModeSp(ref string PlanMode,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetPlanningModeExt = new GetPlanningModeFactory().Create(appDb);
				
				int Severity = iGetPlanningModeExt.GetPlanningModeSp(ref PlanMode,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetProjTaskInfoSp(string ProjNum,
			int? TaskNum,
			ref DateTime? StartDate,
			ref DateTime? EndDate)
        {
            var iGetProjTaskInfoExt = new GetProjTaskInfoFactory().Create(this, true);

            var result = iGetProjTaskInfoExt.GetProjTaskInfoSp(ProjNum,
				TaskNum,
				StartDate,
				EndDate);

            StartDate = result.StartDate;
            EndDate = result.EndDate;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PmatlUMValidSp(string PItem,
		                          decimal? PMatlQty,
		                          ref string PUM,
		                          ref double? UomConvFactor,
		                          ref decimal? TQty,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmatlUMValidExt = new PmatlUMValidFactory().Create(appDb);
				
				int Severity = iPmatlUMValidExt.PmatlUMValidSp(PItem,
				                                               PMatlQty,
				                                               ref PUM,
				                                               ref UomConvFactor,
				                                               ref TQty,
				                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int prjresPermissionsSp(ref byte? CanAdd,
		                               ref byte? CanUpdate,
		                               ref byte? CanDelete)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iprjresPermissionsExt = new prjresPermissionsFactory().Create(appDb);
				
				int Severity = iprjresPermissionsExt.prjresPermissionsSp(ref CanAdd,
				                                                         ref CanUpdate,
				                                                         ref CanDelete);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int prjresUMSp(string PItem,
		                      string POldItem,
		                      string PUM,
		                      string POldUM,
		                      string PProjNum,
		                      int? PTaskNum,
		                      int? PSeq,
		                      byte? PAddMode,
		                      decimal? PMatlQty,
		                      ref decimal? PCost,
		                      ref decimal? PMatlCost,
		                      ref decimal? PLbrCost,
		                      ref decimal? PFovhdCost,
		                      ref decimal? PVovhdCost,
		                      ref decimal? POutCost,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iprjresUMExt = new prjresUMFactory().Create(appDb);
				
				int Severity = iprjresUMExt.prjresUMSp(PItem,
				                                       POldItem,
				                                       PUM,
				                                       POldUM,
				                                       PProjNum,
				                                       PTaskNum,
				                                       PSeq,
				                                       PAddMode,
				                                       PMatlQty,
				                                       ref PCost,
				                                       ref PMatlCost,
				                                       ref PLbrCost,
				                                       ref PFovhdCost,
				                                       ref PVovhdCost,
				                                       ref POutCost,
				                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlJobRefValidationSp(string PRefNum,
		                                      short? PSuffix,
		                                      string PRefType,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjmatlJobRefValidationExt = new ProjmatlJobRefValidationFactory().Create(appDb);
				
				int Severity = iProjmatlJobRefValidationExt.ProjmatlJobRefValidationSp(PRefNum,
				                                                                       PSuffix,
				                                                                       PRefType,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlValidateItemSp(string Item,
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			string Whse,
			ref string TItem,
			ref int? TSeqNum,
			ref string TItemDesc,
			ref int? TSerTracked,
			ref int? TLotTracked,
			ref string TNonInvAcct,
			ref decimal? TNonInvCost,
			ref string TCostCode,
			ref string TLoc,
			ref string TLot,
			ref decimal? TRequired,
			ref decimal? TIssued,
			ref decimal? TOnHand,
			ref string TUM,
			ref decimal? UomConvFactor,
			ref decimal? TRequiredConv,
			ref decimal? TIssuedConv,
			ref decimal? TOnHandConv,
			ref decimal? TQty,
			ref decimal? TQtyConv,
			ref int? ItemAvailable,
			ref string PromptMsg1,
			ref string PromptButtons1,
			ref string PromptMsg2,
			ref string PromptButtons2,
			ref string Infobar,
			ref string TImportDocId,
			ref int? TTaxFreeMatl,
			ref int? TTrackPieces,
			ref string TDimensionGroup,
			ref decimal? TQtyShipped,
			ref int? IsControl,
			ref int? ItemTrackECN,
			ref string Revision)
		{
			var iProjmatlValidateItemExt = new ProjmatlValidateItemFactory().Create(this, true);
			
			var result = iProjmatlValidateItemExt.ProjmatlValidateItemSp(Item,
				ProjNum,
				TaskNum,
				SeqNum,
				Whse,
				TItem,
				TSeqNum,
				TItemDesc,
				TSerTracked,
				TLotTracked,
				TNonInvAcct,
				TNonInvCost,
				TCostCode,
				TLoc,
				TLot,
				TRequired,
				TIssued,
				TOnHand,
				TUM,
				UomConvFactor,
				TRequiredConv,
				TIssuedConv,
				TOnHandConv,
				TQty,
				TQtyConv,
				ItemAvailable,
				PromptMsg1,
				PromptButtons1,
				PromptMsg2,
				PromptButtons2,
				Infobar,
				TImportDocId,
				TTaxFreeMatl,
				TTrackPieces,
				TDimensionGroup,
				TQtyShipped,
				IsControl,
				ItemTrackECN,
				Revision);
			
			TItem = result.TItem;
			TSeqNum = result.TSeqNum;
			TItemDesc = result.TItemDesc;
			TSerTracked = result.TSerTracked;
			TLotTracked = result.TLotTracked;
			TNonInvAcct = result.TNonInvAcct;
			TNonInvCost = result.TNonInvCost;
			TCostCode = result.TCostCode;
			TLoc = result.TLoc;
			TLot = result.TLot;
			TRequired = result.TRequired;
			TIssued = result.TIssued;
			TOnHand = result.TOnHand;
			TUM = result.TUM;
			UomConvFactor = result.UomConvFactor;
			TRequiredConv = result.TRequiredConv;
			TIssuedConv = result.TIssuedConv;
			TOnHandConv = result.TOnHandConv;
			TQty = result.TQty;
			TQtyConv = result.TQtyConv;
			ItemAvailable = result.ItemAvailable;
			PromptMsg1 = result.PromptMsg1;
			PromptButtons1 = result.PromptButtons1;
			PromptMsg2 = result.PromptMsg2;
			PromptButtons2 = result.PromptButtons2;
			Infobar = result.Infobar;
			TImportDocId = result.TImportDocId;
			TTaxFreeMatl = result.TTaxFreeMatl;
			TTrackPieces = result.TTrackPieces;
			TDimensionGroup = result.TDimensionGroup;
			TQtyShipped = result.TQtyShipped;
			IsControl = result.IsControl;
			ItemTrackECN = result.ItemTrackECN;
			Revision = result.Revision;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlValidateLocSp(string Item,
		                                 string ProjNum,
		                                 int? TaskNum,
		                                 int? SeqNum,
		                                 string Whse,
		                                 string TLoc,
		                                 double? UomConvFactor,
		                                 ref string TLot,
		                                 ref decimal? TOnHand,
		                                 ref decimal? TOnHandConv,
		                                 ref decimal? TQty,
		                                 ref decimal? TQtyConv,
		                                 ref string Infobar,
		                                 ref string TImportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjmatlValidateLocExt = new ProjmatlValidateLocFactory().Create(appDb);
				
				int Severity = iProjmatlValidateLocExt.ProjmatlValidateLocSp(Item,
				                                                             ProjNum,
				                                                             TaskNum,
				                                                             SeqNum,
				                                                             Whse,
				                                                             TLoc,
				                                                             UomConvFactor,
				                                                             ref TLot,
				                                                             ref TOnHand,
				                                                             ref TOnHandConv,
				                                                             ref TQty,
				                                                             ref TQtyConv,
				                                                             ref Infobar,
				                                                             ref TImportDocId);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PrjResourcesKitBuilderSp([Optional] string StartingItem,
		                                              [Optional] string EndingItem,
		                                              [Optional] string PlannerCode,
		                                              [Optional] DateTime? StartingDate,
		                                              [Optional] DateTime? EndingDate,
		                                              [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PrjResourcesKitBuilderExt = new CLM_PrjResourcesKitBuilderFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PrjResourcesKitBuilderExt.CLM_PrjResourcesKitBuilderSp(StartingItem,
				                                                                         EndingItem,
				                                                                         PlannerCode,
				                                                                         StartingDate,
				                                                                         EndingDate,
				                                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmatlValidateMatlQtySp(decimal? NewMatlQty,
		                                  string PWhse,
		                                  string PItem,
		                                  string PLoc,
		                                  string PLot,
		                                  double? UomConvFactor,
		                                  decimal? QtyIssuedConv,
		                                  decimal? QtyRequiredConv,
		                                  byte? CreateMatl,
		                                  ref decimal? TQty,
		                                  ref string PromptButtons,
		                                  ref string PromptMsg,
		                                  ref string Infobar,
		                                  string PImportDocId,
		                                  [Optional] string ProjNum,
		                                  [Optional] int? TaskNum,
		                                  [Optional] int? ProjmatSeq,
		                                  [Optional] ref decimal? ConsignQtyRequired,
		                                  [Optional] ref string ConsignVdrWhse,
		                                  [Optional] ref string ConsignVdrLoc,
		                                  [Optional] ref string ConsignedPromptButtons,
		                                  [Optional] ref string ConsignedPromptMsg,
		                                  [Optional] ref string ContianedPromptButtons,
		                                  [Optional] ref string ContianedPromptMsg,
		                                  [Optional] ref string CallFormStr)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmatlValidateMatlQtyExt = new PmatlValidateMatlQtyFactory().Create(appDb);
				
				var result = iPmatlValidateMatlQtyExt.PmatlValidateMatlQtySp(NewMatlQty,
				                                                             PWhse,
				                                                             PItem,
				                                                             PLoc,
				                                                             PLot,
				                                                             UomConvFactor,
				                                                             QtyIssuedConv,
				                                                             QtyRequiredConv,
				                                                             CreateMatl,
				                                                             TQty,
				                                                             PromptButtons,
				                                                             PromptMsg,
				                                                             Infobar,
				                                                             PImportDocId,
				                                                             ProjNum,
				                                                             TaskNum,
				                                                             ProjmatSeq,
				                                                             ConsignQtyRequired,
				                                                             ConsignVdrWhse,
				                                                             ConsignVdrLoc,
				                                                             ConsignedPromptButtons,
				                                                             ConsignedPromptMsg,
				                                                             ContianedPromptButtons,
				                                                             ContianedPromptMsg,
				                                                             CallFormStr);
				
				int Severity = result.ReturnCode.Value;
				TQty = result.TQty;
				PromptButtons = result.PromptButtons;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				ConsignQtyRequired = result.ConsignQtyRequired;
				ConsignVdrWhse = result.ConsignVdrWhse;
				ConsignVdrLoc = result.ConsignVdrLoc;
				ConsignedPromptButtons = result.ConsignedPromptButtons;
				ConsignedPromptMsg = result.ConsignedPromptMsg;
				ContianedPromptButtons = result.ContianedPromptButtons;
				ContianedPromptMsg = result.ContianedPromptMsg;
				CallFormStr = result.CallFormStr;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int prjresDupItemWarningSp(string PProjNum,
		                                  int? PTaskNum,
		                                  int? PSeq,
		                                  string PItem,
		                                  ref string Infobar,
		                                  [Optional] ref string Prompt,
		                                  [Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iprjresDupItemWarningExt = new prjresDupItemWarningFactory().Create(appDb);
				
				var result = iprjresDupItemWarningExt.prjresDupItemWarningSp(PProjNum,
				                                                             PTaskNum,
				                                                             PSeq,
				                                                             PItem,
				                                                             Infobar,
				                                                             Prompt,
				                                                             PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int prjresValidateItemSp(ref string PItem,
		                                string POldItem,
		                                string PProj,
		                                byte? PAddMode,
		                                ref decimal? PCost,
		                                ref byte? PBackflush,
		                                ref string PRefType,
		                                ref string PMatlType,
		                                ref string PUnits,
		                                ref decimal? PMatlCost,
		                                ref decimal? PLbrCost,
		                                ref decimal? PFovhdCost,
		                                ref decimal? PVovhdCost,
		                                ref decimal? POutCost,
		                                ref decimal? PFmatlovhd,
		                                ref decimal? PVmatlovhd,
		                                ref string PUM,
		                                ref byte? PItemAvail,
		                                ref string PItemDesc,
		                                ref byte? PItemSerialTracked,
		                                ref string PCostCode,
		                                ref string Infobar,
		                                [Optional] ref string Prompt,
		                                [Optional] ref string PromptButtons,
		                                [Optional, DefaultParameterValue((byte)0)] ref byte? SupplQtyReq,
		[Optional, DefaultParameterValue(1)] ref double? SupplQtyConvFactor,
		[Optional] ref string Origin,
		[Optional] ref string CommCode,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitWeight,
		ref byte? Kit)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iprjresValidateItemExt = new prjresValidateItemFactory().Create(appDb);
				
				var result = iprjresValidateItemExt.prjresValidateItemSp(PItem,
				                                                         POldItem,
				                                                         PProj,
				                                                         PAddMode,
				                                                         PCost,
				                                                         PBackflush,
				                                                         PRefType,
				                                                         PMatlType,
				                                                         PUnits,
				                                                         PMatlCost,
				                                                         PLbrCost,
				                                                         PFovhdCost,
				                                                         PVovhdCost,
				                                                         POutCost,
				                                                         PFmatlovhd,
				                                                         PVmatlovhd,
				                                                         PUM,
				                                                         PItemAvail,
				                                                         PItemDesc,
				                                                         PItemSerialTracked,
				                                                         PCostCode,
				                                                         Infobar,
				                                                         Prompt,
				                                                         PromptButtons,
				                                                         SupplQtyReq,
				                                                         SupplQtyConvFactor,
				                                                         Origin,
				                                                         CommCode,
				                                                         UnitWeight,
				                                                         Kit);
				
				int Severity = result.ReturnCode.Value;
				PItem = result.PItem;
				PCost = result.PCost;
				PBackflush = result.PBackflush;
				PRefType = result.PRefType;
				PMatlType = result.PMatlType;
				PUnits = result.PUnits;
				PMatlCost = result.PMatlCost;
				PLbrCost = result.PLbrCost;
				PFovhdCost = result.PFovhdCost;
				PVovhdCost = result.PVovhdCost;
				POutCost = result.POutCost;
				PFmatlovhd = result.PFmatlovhd;
				PVmatlovhd = result.PVmatlovhd;
				PUM = result.PUM;
				PItemAvail = result.PItemAvail;
				PItemDesc = result.PItemDesc;
				PItemSerialTracked = result.PItemSerialTracked;
				PCostCode = result.PCostCode;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				SupplQtyReq = result.SupplQtyReq;
				SupplQtyConvFactor = result.SupplQtyConvFactor;
				Origin = result.Origin;
				CommCode = result.CommCode;
				UnitWeight = result.UnitWeight;
				Kit = result.Kit;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlTransactionByContainerSp(string ContainerNum,
		                                            [Optional] string PProjNum,
		                                            [Optional] int? PTaskNum,
		                                            string CurWhse,
		                                            DateTime? PTransDate,
		                                            ref string PromptMsg,
		                                            ref string PromptButtons,
		                                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjmatlTransactionByContainerExt = new ProjmatlTransactionByContainerFactory().Create(appDb);
				
				var result = iProjmatlTransactionByContainerExt.ProjmatlTransactionByContainerSp(ContainerNum,
				                                                                                 PProjNum,
				                                                                                 PTaskNum,
				                                                                                 CurWhse,
				                                                                                 PTransDate,
				                                                                                 PromptMsg,
				                                                                                 PromptButtons,
				                                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreatePckItemSp(int? PackNum,
		string ProjNum,
		int? TaskNum,
		int? Seq,
		string Item,
		string UM,
		decimal? PackQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreatePckItemExt = new CreatePckItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreatePckItemExt.CreatePckItemSp(PackNum,
				ProjNum,
				TaskNum,
				Seq,
				Item,
				UM,
				PackQty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSysParPermPlanModeSp(ref string ApsParmApsmode,
		ref int? CanAdd,
		ref int? CanUpdate,
		ref int? CanDelete,
		ref string PlanMode,
		ref string Parm_DefWhse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetSysParPermPlanModeExt = new GetSysParPermPlanModeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetSysParPermPlanModeExt.GetSysParPermPlanModeSp(ApsParmApsmode,
				CanAdd,
				CanUpdate,
				CanDelete,
				PlanMode,
				Parm_DefWhse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ApsParmApsmode = result.ApsParmApsmode;
				CanAdd = result.CanAdd;
				CanUpdate = result.CanUpdate;
				CanDelete = result.CanDelete;
				PlanMode = result.PlanMode;
				Parm_DefWhse = result.Parm_DefWhse;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyInvChkSp(string Whse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyInvChkExt = new PhyInvChkFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyInvChkExt.PhyInvChkSp(Whse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int prjresMatlQtyConvSp(decimal? NewMatlQty,
		string PItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iprjresMatlQtyConvExt = new prjresMatlQtyConvFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iprjresMatlQtyConvExt.prjresMatlQtyConvSp(NewMatlQty,
				PItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjectResourceTrxPostSp(string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		decimal? PQty,
		string CurWhse,
		string PCostCode,
		string PLoc1,
		string PLot1,
		DateTime? PTransDate,
		string PTranType,
		string PNonInvAcct,
		string PNonInvAcctUnit1,
		string PNonInvAcctUnit2,
		string PNonInvAcctUnit3,
		string PNonInvAcctUnit4,
		decimal? PNonInvCost,
		string PPoNum,
		int? PPoLine,
		int? PPoRel,
		string PRefType,
		[Optional, DefaultParameterValue("")] string CallArg,
		[Optional] string ControlPrefix,
		[Optional] string ControlSite,
		[Optional] int? ControlYear,
		[Optional] int? ControlPeriod,
		[Optional] decimal? ControlNumber,
		ref string Infobar,
		string PImportDocId1,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjectResourceTrxPostExt = new ProjectResourceTrxPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjectResourceTrxPostExt.ProjectResourceTrxPostSp(PProjNum,
				PTaskNum,
				PSeqNum,
				PItem,
				PQty,
				CurWhse,
				PCostCode,
				PLoc1,
				PLot1,
				PTransDate,
				PTranType,
				PNonInvAcct,
				PNonInvAcctUnit1,
				PNonInvAcctUnit2,
				PNonInvAcctUnit3,
				PNonInvAcctUnit4,
				PNonInvCost,
				PPoNum,
				PPoLine,
				PPoRel,
				PRefType,
				CallArg,
				ControlPrefix,
				ControlSite,
				ControlYear,
				ControlPeriod,
				ControlNumber,
				Infobar,
				PImportDocId1,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlCreateSp(string TProjNum,
		int? TTaskNum,
		string TCostCode,
		string TItem,
		string TItemDesc,
		decimal? TQty,
		decimal? TQtyConv,
		string TUM,
		string TWhse,
		decimal? TNonInvCost,
		ref int? TSeqNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjmatlCreateExt = new ProjmatlCreateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjmatlCreateExt.ProjmatlCreateSp(TProjNum,
				TTaskNum,
				TCostCode,
				TItem,
				TItemDesc,
				TQty,
				TQtyConv,
				TUM,
				TWhse,
				TNonInvCost,
				TSeqNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TSeqNum = result.TSeqNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlTransactionSp(string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		string PItemDesc,
		decimal? PQty,
		decimal? PQtyConv,
		string PUM,
		string CurWhse,
		string PCostCode,
		string PLoc1,
		string PLot1,
		DateTime? PTransDate,
		string PTranType,
		string PNonInvAcct,
		string PNonInvAcctUnit1,
		string PNonInvAcctUnit2,
		string PNonInvAcctUnit3,
		string PNonInvAcctUnit4,
		decimal? PNonInvCost,
		int? CreateMatl,
		ref int? TSeqNum,
		ref string Infobar,
		string PImportDocId1,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjmatlTransactionExt = new ProjmatlTransactionFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjmatlTransactionExt.ProjmatlTransactionSp(PProjNum,
				PTaskNum,
				PSeqNum,
				PItem,
				PItemDesc,
				PQty,
				PQtyConv,
				PUM,
				CurWhse,
				PCostCode,
				PLoc1,
				PLot1,
				PTransDate,
				PTranType,
				PNonInvAcct,
				PNonInvAcctUnit1,
				PNonInvAcctUnit2,
				PNonInvAcctUnit3,
				PNonInvAcctUnit4,
				PNonInvCost,
				CreateMatl,
				TSeqNum,
				Infobar,
				PImportDocId1,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				TSeqNum = result.TSeqNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjPackSlipQtyValidSp(decimal? QtyRequired,
		decimal? QtyToPack,
		string TPckCall,
		ref string Warning,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjPackSlipQtyValidExt = new ProjPackSlipQtyValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjPackSlipQtyValidExt.ProjPackSlipQtyValidSp(QtyRequired,
				QtyToPack,
				TPckCall,
				Warning,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Warning = result.Warning;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ContainerItemsForCompareToProjRes(string ProjNum,
		int? ProjTaskNum,
		string ContainerNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ContainerItemsForCompareToProjResExt = new CLM_ContainerItemsForCompareToProjResFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ContainerItemsForCompareToProjResExt.CLM_ContainerItemsForCompareToProjResSp(ProjNum,
				ProjTaskNum,
				ContainerNum,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetProjMatSp(string ProjNum,
		int? TaskNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetProjMatExt = new GetProjMatFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetProjMatExt.GetProjMatSp(ProjNum,
				TaskNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PackingSlipLoadSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPackingSlipLoadExt = new PackingSlipLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPackingSlipLoadExt.PackingSlipLoadSp(TPckCall,
				ProjNum,
				CustNum,
				FromTaskNum,
				ToTaskNum,
				FromSeq,
				ToSeq,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PrjTshpBuildSp(string TProjNum,
		int? TTaskNum,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPrjTshpBuildExt = new PrjTshpBuildFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPrjTshpBuildExt.PrjTshpBuildSp(TProjNum,
				TTaskNum,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjmatlTransactionSetVarsSp(string SET,
		string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		string PItemDesc,
		decimal? PQty,
		decimal? PQtyConv,
		string PUM,
		string CurWhse,
		string PCostCode,
		string PLoc1,
		string PLot1,
		DateTime? PTransDate,
		string PTranType,
		string PNonInvAcct,
		string PNonInvAcctUnit1,
		string PNonInvAcctUnit2,
		string PNonInvAcctUnit3,
		string PNonInvAcctUnit4,
		decimal? PNonInvCost,
		int? CreateMatl,
		ref int? TSeqNum,
		ref string Infobar,
		string PImportDocId1,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjmatlTransactionSetVarsExt = new ProjmatlTransactionSetVarsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjmatlTransactionSetVarsExt.ProjmatlTransactionSetVarsSp(SET,
				PProjNum,
				PTaskNum,
				PSeqNum,
				PItem,
				PItemDesc,
				PQty,
				PQtyConv,
				PUM,
				CurWhse,
				PCostCode,
				PLoc1,
				PLot1,
				PTransDate,
				PTranType,
				PNonInvAcct,
				PNonInvAcctUnit1,
				PNonInvAcctUnit2,
				PNonInvAcctUnit3,
				PNonInvAcctUnit4,
				PNonInvCost,
				CreateMatl,
				TSeqNum,
				Infobar,
				PImportDocId1,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				TSeqNum = result.TSeqNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjPmatlXSp(int? PAsk,
		string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PRefType,
		ref string PRefNum,
		ref int? PRefLineSuf,
		ref int? PRefRelease,
		ref string PAction,
		ref string PToLaunch,
		ref int? PoChangeOrd,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string PromptMsg1,
		ref string PromptButtons1,
		ref string PromptMsg2,
		ref string PromptButtons2,
		ref string PromptMsg3,
		ref string PromptButtons3,
		ref string PromptMsg4,
		ref string PromptButtons4,
		ref string PromptMsg5,
		ref string PromptButtons5,
		string ExportType,
		ref string PFromSite,
		ref string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		ref string PCurRefNum,
		ref string PCurRefLineSuf,
		string TrnLoc,
		string FOBSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjPmatlXExt = new ProjPmatlXFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjPmatlXExt.ProjPmatlXSp(PAsk,
				PProjNum,
				PTaskNum,
				PSeq,
				PRefType,
				PRefNum,
				PRefLineSuf,
				PRefRelease,
				PAction,
				PToLaunch,
				PoChangeOrd,
				Infobar,
				PromptMsg,
				PromptButtons,
				PromptMsg1,
				PromptButtons1,
				PromptMsg2,
				PromptButtons2,
				PromptMsg3,
				PromptButtons3,
				PromptMsg4,
				PromptButtons4,
				PromptMsg5,
				PromptButtons5,
				ExportType,
				PFromSite,
				PFromWhse,
				PToSite,
				PToWhse,
				PQtyOrdered,
				PDueDate,
				PCurRefNum,
				PCurRefLineSuf,
				TrnLoc,
				FOBSite);
				
				int Severity = result.ReturnCode.Value;
				PRefNum = result.PRefNum;
				PRefLineSuf = result.PRefLineSuf;
				PRefRelease = result.PRefRelease;
				PAction = result.PAction;
				PToLaunch = result.PToLaunch;
				PoChangeOrd = result.PoChangeOrd;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons2 = result.PromptButtons2;
				PromptMsg3 = result.PromptMsg3;
				PromptButtons3 = result.PromptButtons3;
				PromptMsg4 = result.PromptMsg4;
				PromptButtons4 = result.PromptButtons4;
				PromptMsg5 = result.PromptMsg5;
				PromptButtons5 = result.PromptButtons5;
				PFromSite = result.PFromSite;
				PFromWhse = result.PFromWhse;
				PCurRefNum = result.PCurRefNum;
				PCurRefLineSuf = result.PCurRefLineSuf;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjSetEffDateSp(string ProjNum,
		int? ProjTaskNum,
		DateTime? NewEffDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjSetEffDateExt = new ProjSetEffDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjSetEffDateExt.ProjSetEffDateSp(ProjNum,
				ProjTaskNum,
				NewEffDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjshipSp(string PProjNum,
		int? PTaskNum,
		int? PSeq,
		decimal? PQtyToShip,
		DateTime? PShipDate,
		string PEcCode,
		int? PConsNum,
		ref string Infobar,
		string PExportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjshipExt = new ProjshipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjshipExt.ProjshipSp(PProjNum,
				PTaskNum,
				PSeq,
				PQtyToShip,
				PShipDate,
				PEcCode,
				PConsNum,
				Infobar,
				PExportDocId);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int XrefWarningMessageSp(string NewRefType,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRel,
		ref string WarningMsg)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iXrefWarningMessageExt = new XrefWarningMessageFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iXrefWarningMessageExt.XrefWarningMessageSp(NewRefType,
				NewRefNum,
				NewRefLineSuf,
				NewRefRel,
				WarningMsg);
				
				int Severity = result.ReturnCode.Value;
				WarningMsg = result.WarningMsg;
				return Severity;
			}
		}
    }
}
