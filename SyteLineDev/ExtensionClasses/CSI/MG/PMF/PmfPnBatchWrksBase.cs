//PROJECT NAME: PmfExt
//CLASS NAME: PmfPnBatchWrksBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfPnBatchWrksBase")]
	public class PmfPnBatchWrksBase : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfEntryClear([Optional] Guid? SessionId)
		{
			var iPmfEntryClearExt = new PmfEntryClearFactory().Create(this, true);

			var result = iPmfEntryClearExt.PmfEntryClearSp(SessionId);

			return result ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetNextPn(string Context,
		                        string Prefix,
		                        int? KeyLength,
		                        ref string Key,
		                        [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetNextPnExt = new PmfGetNextPnFactory().Create(appDb);
				
				var result = iPmfGetNextPnExt.PmfGetNextPnSp(Context,
				                                             Prefix,
				                                             KeyLength,
				                                             Key,
				                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnCreateBatchWrk([Optional] ref string InfoBar,
		                               [Optional] string Prefix,
		                               Guid? SessionId,
		                               decimal? Sequence,
		                               Guid? PmfMfgSpecRowPointer,
		                               [Optional] Guid? PmfPnBatchWrkRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnCreateBatchWrkExt = new PmfPnCreateBatchWrkFactory().Create(appDb);
				
				var result = iPmfPnCreateBatchWrkExt.PmfPnCreateBatchWrkSp(InfoBar,
				                                                           Prefix,
				                                                           SessionId,
				                                                           Sequence,
				                                                           PmfMfgSpecRowPointer,
				                                                           PmfPnBatchWrkRowPointer);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnEntryClearTemplates([Optional] ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnEntryClearTemplatesExt = new PmfPnEntryClearTemplatesFactory().Create(appDb);
				
				var result = iPmfPnEntryClearTemplatesExt.PmfPnEntryClearTemplatesSp(InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnEntryCreatePn([Optional] ref string InfoBar,
		                              [Optional] Guid? PnWrkRp,
		                              [Optional] ref Guid? PnRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnEntryCreatePnExt = new PmfPnEntryCreatePnFactory().Create(appDb);
				
				var result = iPmfPnEntryCreatePnExt.PmfPnEntryCreatePnSp(InfoBar,
				                                                         PnWrkRp,
				                                                         PnRp);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				PnRp = result.PnRp;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnEntryinitUi([Optional] ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnEntryInitUiExt = new PmfPnEntryInitUiFactory().Create(appDb);
				
				var result = iPmfPnEntryInitUiExt.PmfPnEntryInitUiSp(InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnEntryValidateUi([Optional] ref string InfoBar,
		                                Guid? PnWrkRp,
		                                [Optional, DefaultParameterValue(1)] int? InitOnly,
		                                [Optional, DefaultParameterValue(0)] ref int? ResetPn,
		                                [Optional, DefaultParameterValue(0)] int? SpecChanged,
		                                [Optional] ref string RecordDate,
		                                [Optional, DefaultParameterValue(0)] ref int? EnforceBatchSizes,
		                                [Optional, DefaultParameterValue(0)] ref int? HasByProduct)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnEntryValidateUiExt = new PmfPnEntryValidateUiFactory().Create(appDb);
				
				var result = iPmfPnEntryValidateUiExt.PmfPnEntryValidateUiSp(InfoBar,
				                                                             PnWrkRp,
				                                                             InitOnly,
				                                                             ResetPn,
				                                                             SpecChanged,
				                                                             RecordDate,
				                                                             EnforceBatchSizes,
				                                                             HasByProduct);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				ResetPn = result.ResetPn;
				RecordDate = result.RecordDate;
				EnforceBatchSizes = result.EnforceBatchSizes;
				HasByProduct = result.HasByProduct;
				return Severity;
			}
		}
	}
}
