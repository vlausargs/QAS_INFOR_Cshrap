//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryPreAdjustmentReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInventoryPreAdjustmentReport")]
    public class SLInventoryPreAdjustmentReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryPreAdjustmentSp([Optional, DefaultParameterValue("B")] string ExOptszVarSelect,
		[Optional, DefaultParameterValue(0)] decimal? ExOptprQtyVar,
		[Optional, DefaultParameterValue(0)] decimal? ExOptSzCostVar,
		[Optional, DefaultParameterValue((byte)0)] byte? ExOptszSortByProdcode,
		[Optional] string ExOptprProductCode,
		[Optional] string ExOptprPlanCode,
		[Optional] string Whse,
		[Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InventoryPreAdjustmentExt = new Rpt_InventoryPreAdjustmentFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InventoryPreAdjustmentExt.Rpt_InventoryPreAdjustmentSp(ExOptszVarSelect,
				                                                                         ExOptprQtyVar,
				                                                                         ExOptSzCostVar,
				                                                                         ExOptszSortByProdcode,
				                                                                         ExOptprProductCode,
				                                                                         ExOptprPlanCode,
				                                                                         Whse,
				                                                                         PDisplayHeader,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
