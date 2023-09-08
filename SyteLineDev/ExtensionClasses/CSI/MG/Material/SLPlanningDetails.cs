//PROJECT NAME: MaterialExt
//CLASS NAME: SLPlanningDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLPlanningDetails")]
    public class SLPlanningDetails : ExtensionClassBase, ISLPlanningDetails
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiOutGPlnpoSp(string BeginVendNum,
                                          string EndVendNum,
                                          string BeginItem,
                                          string EndItem,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiOutGPlnpoExt = new EdiOutGPlnpoFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iEdiOutGPlnpoExt.EdiOutGPlnpoSp(BeginVendNum,
                                                                    EndVendNum,
                                                                    BeginItem,
                                                                    EndItem,
                                                                    ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetApsIDFromPLNSp(Guid? PApsPlanRowPtr,
                                             ref string PApsOrderID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetApsIDFromPLNExt = new GetApsIDFromPLNFactory().Create(appDb);

                ApsOrderType oPApsOrderID = PApsOrderID;

                int Severity = iGetApsIDFromPLNExt.GetApsIDFromPLNSp(PApsPlanRowPtr,
                                                                                ref oPApsOrderID);

                PApsOrderID = oPApsOrderID;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetDemandIDFromPLNSp(Guid? PApsPlanRowPtr,
                                                ref string PDemandType,
                                                ref string PDemandRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetDemandIDFromPLNExt = new GetDemandIDFromPLNFactory().Create(appDb);

                RefType oPDemandType = PDemandType;
                OrderRefStrType oPDemandRef = PDemandRef;

                int Severity = iGetDemandIDFromPLNExt.GetDemandIDFromPLNSp(PApsPlanRowPtr,
                                                                          ref oPDemandType,
                                                                          ref oPDemandRef);

                PDemandType = oPDemandType;
                PDemandRef = oPDemandRef;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MrpDPreFirmPlanSp(string PItem,
                                             ref string PRefType,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMrpDPreFirmPlanExt = new MrpDPreFirmPlanFactory().Create(appDb);

                JobTypeType oPRefType = PRefType;
                InfobarType oInfobar = Infobar;

                int Severity = iMrpDPreFirmPlanExt.MrpDPreFirmPlanSp(PItem,
                                                                                ref oPRefType,
                                                                                ref oInfobar);

                PRefType = oPRefType;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MrpInitTransferOrderSp(string Item,
                                                  ref string FromSite,
                                                  ref string FromWhse,
                                                  ref string ToSite,
                                                  ref string ToWhse)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMrpInitTransferOrderExt = new MrpInitTransferOrderFactory().Create(appDb);

                SiteType oFromSite = FromSite;
                WhseType oFromWhse = FromWhse;
                SiteType oToSite = ToSite;
                WhseType oToWhse = ToWhse;

                int Severity = iMrpInitTransferOrderExt.MrpInitTransferOrderSp(Item,
                                                                                     ref oFromSite,
                                                                                     ref oFromWhse,
                                                                                     ref oToSite,
                                                                                     ref oToWhse);

                FromSite = oFromSite;
                FromWhse = oFromWhse;
                ToSite = oToSite;
                ToWhse = oToWhse;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MrpSyncMpwSp(Guid? SessionID,
                                        string PItem,
                                        ref byte? DeleteMpw,
                                        ref string PromptMsg,
                                        ref string PromptButtons,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMrpSyncMpwExt = new MrpSyncMpwFactory().Create(appDb);

                ListYesNoType oDeleteMpw = DeleteMpw;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iMrpSyncMpwExt.MrpSyncMpwSp(SessionID,
                                                                  PItem,
                                                                  ref oDeleteMpw,
                                                                  ref oPromptMsg,
                                                                  ref oPromptButtons,
                                                                  ref oInfobar);

                DeleteMpw = oDeleteMpw;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FirmPlnSp(Guid? SessionId,
		                     string VendNum,
		                     string UserName,
		                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iFirmPlnExt = new FirmPlnFactory().Create(appDb);

				int Severity = iFirmPlnExt.FirmPlnSp(SessionId,
				                                     VendNum,
				                                     UserName,
				                                     ref Infobar);

				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PlanningDetailDeleteSp(Guid? SessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iPlanningDetailDeleteExt = new PlanningDetailDeleteFactory().Create(appDb);

				int Severity = iPlanningDetailDeleteExt.PlanningDetailDeleteSp(SessionID);

				return Severity;
			}
		}







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_MRPSupDemSp([Optional] string FilterString,
		                                 [Optional] string SiteGroup,
		                                 string PItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var iCLM_MRPSupDemExt = new CLM_MRPSupDemFactory().Create(appDb, bunchedLoadCollection);

				var result = iCLM_MRPSupDemExt.CLM_MRPSupDemSp(FilterString,
				                                               SiteGroup,
				                                               PItem);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PlanningDemandNegativeSp(DateTime? CutOffDate,
		                                          string PlanCode,
		                                          string Buyer,
		                                          string PMTCodes,
		                                          [Optional] string FilterString,
		                                          [Optional] string CustNum,
		                                          [Optional, DefaultParameterValue((byte)0)] byte? CSFlag,
		[Optional] string ProjMgr,
		[Optional, DefaultParameterValue((byte)0)] byte? PMFlag,
		[Optional] string SiteGroup,
		[Optional, DefaultParameterValue((byte)0)] byte? SortByDueDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var iPlanningDemandNegativeExt = new PlanningDemandNegativeFactory().Create(appDb, bunchedLoadCollection);

				var result = iPlanningDemandNegativeExt.PlanningDemandNegativeSp(CutOffDate,
				                                                                 PlanCode,
				                                                                 Buyer,
				                                                                 PMTCodes,
				                                                                 FilterString,
				                                                                 CustNum,
				                                                                 CSFlag,
				                                                                 ProjMgr,
				                                                                 PMFlag,
				                                                                 SiteGroup,
				                                                                 SortByDueDate);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PlanningDetailRefreshSp(int? RowCount,
		                                         [Optional] string PCFilter,
		                                         [Optional, DefaultParameterValue(1)] int? PageCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var iPlanningDetailRefreshExt = new PlanningDetailRefreshFactory().Create(appDb, bunchedLoadCollection);

				var result = iPlanningDetailRefreshExt.PlanningDetailRefreshSp(RowCount,
				                                                               PCFilter,
				                                                               PageCount);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIPlanningSchedulesSp([Optional] string ExOptBegVend_Num,
		                                       [Optional] string ExOptEndVend_Num,
		                                       [Optional] int? ExOptBegSched_Num,
		                                       [Optional] int? ExOptEndSched_Num,
		                                       [Optional] DateTime? ExOptBegPost_Date,
		                                       [Optional] DateTime? ExOptEndPost_Date,
		                                       [Optional] string ExOptprPostedEmp,
		                                       [Optional] short? CDateStartingOffset,
		                                       [Optional] short? CDateEndingOffset,
		                                       [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iPurgeEDIPlanningSchedulesExt = new PurgeEDIPlanningSchedulesFactory().Create(appDb);

				var result = iPurgeEDIPlanningSchedulesExt.PurgeEDIPlanningSchedulesSp(ExOptBegVend_Num,
				                                                                       ExOptEndVend_Num,
				                                                                       ExOptBegSched_Num,
				                                                                       ExOptEndSched_Num,
				                                                                       ExOptBegPost_Date,
				                                                                       ExOptEndPost_Date,
				                                                                       ExOptprPostedEmp,
				                                                                       CDateStartingOffset,
				                                                                       CDateEndingOffset,
				                                                                       Infobar);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}








		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_MRPOrderActionSp([Optional] string Item,
		[Optional] DateTime? EndDate,
		[Optional] string Source,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iCLM_MRPOrderActionExt = new CLM_MRPOrderActionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iCLM_MRPOrderActionExt.CLM_MRPOrderActionSp(Item,
				EndDate,
				Source,
				FilterString);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpandKyByTypeSp(string DataType,
		string Key,
		[Optional, DefaultParameterValue(null)] string Site,
		ref string Result)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iExpandKyByTypeExt = new ExpandKyByTypeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iExpandKyByTypeExt.ExpandKyByTypeSp(DataType,
				Key,
				Site,
				Result);

				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MRPOrderActionSp([Optional] string Item,
		[Optional] DateTime? EndDate,
		[Optional] string Source,
		[Optional] string FilterString,
		[Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iHome_MRPOrderActionExt = new Home_MRPOrderActionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iHome_MRPOrderActionExt.Home_MRPOrderActionSp(Item,
				EndDate,
				Source,
				FilterString,
				SiteGroup);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MRPFirmPlanOrdersSp(Guid? SessionID,
		string RefType,
		[Optional] string VendNum,
		[Optional] string PoNum,
		[Optional] string PoChange,
		[Optional] int? BlanketQtyOver,
		[Optional] string ReqNum,
		[Optional] string SfcparmsWoPrefix,
		[Optional] int? CopyBom,
		[Optional] int? CopyIndentedBom,
		[Optional] string SfcparmsPsPrefix,
		[Optional] int? SingleOrder,
		[Optional] string TrnNum,
		[Optional] string FromSite,
		[Optional] string FromWhse,
		[Optional] string ToSite,
		[Optional] string ToWhse,
		[Optional, DefaultParameterValue(0)] int? DeleteMpw,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iMRPFirmPlanOrdersExt = new MRPFirmPlanOrdersFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iMRPFirmPlanOrdersExt.MRPFirmPlanOrdersSp(SessionID,
				RefType,
				VendNum,
				PoNum,
				PoChange,
				BlanketQtyOver,
				ReqNum,
				SfcparmsWoPrefix,
				CopyBom,
				CopyIndentedBom,
				SfcparmsPsPrefix,
				SingleOrder,
				TrnNum,
				FromSite,
				FromWhse,
				ToSite,
				ToWhse,
				DeleteMpw,
				Infobar);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpNetSp([Optional, DefaultParameterValue("R")] string UserMrpPlanningType,
		string FormCaption,
		int? BgTaskID,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? DebugLevel,
		[Optional, DefaultParameterValue(0)] int? ItemElapsedTime)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iMrpNetExt = new MrpNetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iMrpNetExt.MrpNetSp(UserMrpPlanningType,
				FormCaption,
				BgTaskID,
				Infobar,
				DebugLevel,
				ItemElapsedTime);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PlanningDemandDetailSp(DateTime? CutOffDate,
		string PlanCode,
		string Buyer,
		string PMTCodes,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iPlanningDemandDetailExt = new PlanningDemandDetailFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPlanningDemandDetailExt.PlanningDemandDetailSp(CutOffDate,
				PlanCode,
				Buyer,
				PMTCodes,
				FilterString);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PlanningDetailSaveSp(Guid? SessionID,
		string Item,
		DateTime? DueDate,
		decimal? QtyReq,
		decimal? OrigQty,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string OrderType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPlanningDetailSaveExt = new PlanningDetailSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPlanningDetailSaveExt.PlanningDetailSaveSp(SessionID,
				Item,
				DueDate,
				QtyReq,
				OrigQty,
				RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				RefSeq,
				OrderType);

				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PostFirmPlnCleanupSp(string OldRefType,
		string OldRefNum,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		[Optional, DefaultParameterValue(0)] int? DeleteDepDemand,
		[Optional] ref string Infobar,
		[Optional] int? OldRefLineSuf)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPostFirmPlnCleanupExt = new PostFirmPlnCleanupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPostFirmPlnCleanupExt.PostFirmPlnCleanupSp(OldRefType,
				OldRefNum,
				RefType,
				RefNum,
				RefLineSuf,
				DeleteDepDemand,
				Infobar,
				OldRefLineSuf);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
