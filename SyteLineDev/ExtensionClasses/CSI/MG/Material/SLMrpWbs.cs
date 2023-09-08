//PROJECT NAME: MaterialExt
//CLASS NAME: SLMrpWbs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLMrpWbs")]
	public class SLMrpWbs : ExtensionClassBase
	{
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable MatlPlannerWorkbenchGenSp(byte? DelPwbBatch,
                                                   byte? UsePln,
                                                   DateTime? EndDate,
                                                   string Source,
                                                   string PlannerCode,
                                                   string Buyer,
                                                   string Whse,
                                                   string Replenishment,
                                                   string ThingsToProcess,
                                                   string StartingItem,
                                                   string EndingItem,
                                                   string StartingOrder,
                                                   string EndingOrder,
                                                   string StartingProject,
                                                   string EndingProject,
                                                   string StartingTransfer,
                                                   string EndingTransfer,
                                                   string StartingJob,
                                                   string EndingJob,
                                                   short? StartingJobSuf,
                                                   short? EndingJobSuf,
                                                   decimal? UserId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iMatlPlannerWorkbenchGenExt = new MatlPlannerWorkbenchGenFactory().Create(appDb, bunchedLoadCollection);

                var result = iMatlPlannerWorkbenchGenExt.MatlPlannerWorkbenchGenSp(DelPwbBatch,
                                                                                   UsePln,
                                                                                   EndDate,
                                                                                   Source,
                                                                                   PlannerCode,
                                                                                   Buyer,
                                                                                   Whse,
                                                                                   Replenishment,
                                                                                   ThingsToProcess,
                                                                                   StartingItem,
                                                                                   EndingItem,
                                                                                   StartingOrder,
                                                                                   EndingOrder,
                                                                                   StartingProject,
                                                                                   EndingProject,
                                                                                   StartingTransfer,
                                                                                   EndingTransfer,
                                                                                   StartingJob,
                                                                                   EndingJob,
                                                                                   StartingJobSuf,
                                                                                   EndingJobSuf,
                                                                                   UserId);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }














		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGetCostSp(string Item,
		decimal? ReqdQty,
		string VendNum,
		string ToWhse,
		ref int? LeadTime,
		ref decimal? UnitCost,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGetCostExt = new MrpWbGetCostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGetCostExt.MrpWbGetCostSp(Item,
				ReqdQty,
				VendNum,
				ToWhse,
				LeadTime,
				UnitCost,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				LeadTime = result.LeadTime;
				UnitCost = result.UnitCost;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGetDateSp(string RefTab,
		string Item,
		string SupplySite,
		decimal? ReqdQty,
		DateTime? DueDate,
		ref DateTime? ReleaseDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGetDateExt = new MrpWbGetDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGetDateExt.MrpWbGetDateSp(RefTab,
				Item,
				SupplySite,
				ReqdQty,
				DueDate,
				ReleaseDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ReleaseDate = result.ReleaseDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGetPoInfoSp(string PoNum,
		DateTime? DueDate,
		string Item,
		ref string VendNum,
		ref decimal? BlanketUnitCost,
		ref int? IsBlanket,
		ref string Infobar,
		ref string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGetPoInfoExt = new MrpWbGetPoInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGetPoInfoExt.MrpWbGetPoInfoSp(PoNum,
				DueDate,
				Item,
				VendNum,
				BlanketUnitCost,
				IsBlanket,
				Infobar,
				Whse);
				
				int Severity = result.ReturnCode.Value;
				VendNum = result.VendNum;
				BlanketUnitCost = result.BlanketUnitCost;
				IsBlanket = result.IsBlanket;
				Infobar = result.Infobar;
				Whse = result.Whse;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGetPrefixSp(ref string PoparmsPoPrefix,
		ref string PoparmsPoChange,
		ref string PoparmsPrqPrefix,
		ref string InvparmsTrnPrefix,
		ref string SfcparmsWoPrefix,
		ref string SfcparmsPsPrefix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGetPrefixExt = new MrpWbGetPrefixFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGetPrefixExt.MrpWbGetPrefixSp(PoparmsPoPrefix,
				PoparmsPoChange,
				PoparmsPrqPrefix,
				InvparmsTrnPrefix,
				SfcparmsWoPrefix,
				SfcparmsPsPrefix);
				
				int Severity = result.ReturnCode.Value;
				PoparmsPoPrefix = result.PoparmsPoPrefix;
				PoparmsPoChange = result.PoparmsPoChange;
				PoparmsPrqPrefix = result.PoparmsPrqPrefix;
				InvparmsTrnPrefix = result.InvparmsTrnPrefix;
				SfcparmsWoPrefix = result.SfcparmsWoPrefix;
				SfcparmsPsPrefix = result.SfcparmsPsPrefix;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGetTransferInfoSp(string TrnNum,
		string Item,
		ref string FromSite,
		ref string FromWhse,
		ref string ToWhse,
		ref decimal? UnitCost,
		ref int? LeadTime,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGetTransferInfoExt = new MrpWbGetTransferInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGetTransferInfoExt.MrpWbGetTransferInfoSp(TrnNum,
				Item,
				FromSite,
				FromWhse,
				ToWhse,
				UnitCost,
				LeadTime,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				FromSite = result.FromSite;
				FromWhse = result.FromWhse;
				ToWhse = result.ToWhse;
				UnitCost = result.UnitCost;
				LeadTime = result.LeadTime;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbSummarySp(decimal? UserId,
		ref decimal? PoCostWb,
		ref decimal? PrCostWb,
		ref decimal? JobCostWb,
		ref decimal? PsCostWb,
		ref decimal? MpsCostWb,
		ref decimal? ToCostWb,
		ref decimal? TotalCostWb,
		ref decimal? PoCostSelected,
		ref decimal? PrCostSelected,
		ref decimal? JobCostSelected,
		ref decimal? PsCostSelected,
		ref decimal? MpsCostSelected,
		ref decimal? ToCostSelected,
		ref decimal? TotalCostSelected,
		ref int? PoOrders,
		ref int? JobOrders,
		ref int? PsOrders,
		ref int? MpsOrders,
		ref int? ToOrders,
		ref int? PoLines,
		ref int? PrLines,
		ref int? PsLines,
		ref int? MpsLines,
		ref int? ToLines)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbSummaryExt = new MrpWbSummaryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbSummaryExt.MrpWbSummarySp(UserId,
				PoCostWb,
				PrCostWb,
				JobCostWb,
				PsCostWb,
				MpsCostWb,
				ToCostWb,
				TotalCostWb,
				PoCostSelected,
				PrCostSelected,
				JobCostSelected,
				PsCostSelected,
				MpsCostSelected,
				ToCostSelected,
				TotalCostSelected,
				PoOrders,
				JobOrders,
				PsOrders,
				MpsOrders,
				ToOrders,
				PoLines,
				PrLines,
				PsLines,
				MpsLines,
				ToLines);
				
				int Severity = result.ReturnCode.Value;
				PoCostWb = result.PoCostWb;
				PrCostWb = result.PrCostWb;
				JobCostWb = result.JobCostWb;
				PsCostWb = result.PsCostWb;
				MpsCostWb = result.MpsCostWb;
				ToCostWb = result.ToCostWb;
				TotalCostWb = result.TotalCostWb;
				PoCostSelected = result.PoCostSelected;
				PrCostSelected = result.PrCostSelected;
				JobCostSelected = result.JobCostSelected;
				PsCostSelected = result.PsCostSelected;
				MpsCostSelected = result.MpsCostSelected;
				ToCostSelected = result.ToCostSelected;
				TotalCostSelected = result.TotalCostSelected;
				PoOrders = result.PoOrders;
				JobOrders = result.JobOrders;
				PsOrders = result.PsOrders;
				MpsOrders = result.MpsOrders;
				ToOrders = result.ToOrders;
				PoLines = result.PoLines;
				PrLines = result.PrLines;
				PsLines = result.PsLines;
				MpsLines = result.MpsLines;
				ToLines = result.ToLines;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MrpWbGenerateOrderSp(decimal? UserID,
		string RefTab,
		[Optional] string PoparmsPoPrefix,
		[Optional] string PoChange,
		[Optional] int? BlanketQtyOver,
		[Optional] int? PurchReqNotes,
		[Optional] string PoparmsPrqPrefix,
		[Optional] string SfcparmsWoPrefix,
		[Optional] int? CopyCurrentBOM,
		[Optional] int? CopyIndentedBOM,
		[Optional] string SfcparmsPsPrefix,
		[Optional] int? SingleOrder,
		[Optional] string InvparmsTrnPrefix,
		[Optional] Guid? SessionID,
		[Optional] int? CopyToPSItemBOM,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? CreateTransitLoc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMrpWbGenerateOrderExt = new MrpWbGenerateOrderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMrpWbGenerateOrderExt.MrpWbGenerateOrderSp(UserID,
				RefTab,
				PoparmsPoPrefix,
				PoChange,
				BlanketQtyOver,
				PurchReqNotes,
				PoparmsPrqPrefix,
				SfcparmsWoPrefix,
				CopyCurrentBOM,
				CopyIndentedBOM,
				SfcparmsPsPrefix,
				SingleOrder,
				InvparmsTrnPrefix,
				SessionID,
				CopyToPSItemBOM,
				Infobar,
				CreateTransitLoc);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
