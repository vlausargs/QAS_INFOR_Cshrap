//PROJECT NAME: MaterialExt
//CLASS NAME: ItemAvailSetVars.cs

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
    [IDOExtensionClass("SLItemwhseAlls")]
    public class SLItemwhseAlls : CSIExtensionClassBase
    {



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemAvailSetVarsSp([Optional] string SET,
		                              [Optional] string SiteRef,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemAvailSetVarsExt = new ItemAvailSetVarsFactory().Create(appDb);
				
				var result = iItemAvailSetVarsExt.ItemAvailSetVarsSp(SET,
				                                                     SiteRef,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}









		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInvSiteGrpSp(decimal? Userid,
		ref string InvSiteGrp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetInvSiteGrpExt = new GetInvSiteGrpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetInvSiteGrpExt.GetInvSiteGrpSp(Userid,
				InvSiteGrp);
				
				int Severity = result.ReturnCode.Value;
				InvSiteGrp = result.InvSiteGrp;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InventoryBelowSafetyStockSp([Optional, DefaultParameterValue("")] string PMTCodes,
		[Optional] string PlanCode,
		[Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_InventoryBelowSafetyStockExt = new CLM_InventoryBelowSafetyStockFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_InventoryBelowSafetyStockExt.CLM_InventoryBelowSafetyStockSp(PMTCodes,
				PlanCode,
				FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TranferLineSummarySp(string Whse,
			string PMTCodes,
			[Optional] string FilterString,
			[Optional] string PSiteGroup)
		{
			var iCLM_TranferLineSummaryExt = new CLM_TranferLineSummaryFactory().Create(this, true);

			var result = iCLM_TranferLineSummaryExt.CLM_TranferLineSummarySp(Whse,
				PMTCodes,
				FilterString,
				PSiteGroup);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
