//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryBelowSafetyStockReport.cs

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
    [IDOExtensionClass("SLInventoryBelowSafetyStockReport")]
    public class SLInventoryBelowSafetyStockReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryBelowSafetyStockSp([Optional] string WarehouseStarting,
		                                                 [Optional] string WarehouseENDing,
		                                                 [Optional] string ItemStarting,
		                                                 [Optional] string ItemENDing,
		                                                 [Optional] string ProductCodeStarting,
		                                                 [Optional] string ProductCodeENDing,
		                                                 [Optional] string PlanCodeStarting,
		                                                 [Optional] string PlanCodeENDing,
		                                                 [Optional] string MaterialType,
		                                                 [Optional] string Source,
		                                                 [Optional] string pStocked,
		                                                 [Optional] string ABCCode,
		                                                 [Optional] byte? ExcludeZeroNetRequirements,
		                                                 [Optional] byte? IncludeTransfers,
		                                                 [Optional] byte? DisplayHeader,
		                                                 [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InventoryBelowSafetyStockExt = new Rpt_InventoryBelowSafetyStockFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InventoryBelowSafetyStockExt.Rpt_InventoryBelowSafetyStockSp(WarehouseStarting,
				                                                                               WarehouseENDing,
				                                                                               ItemStarting,
				                                                                               ItemENDing,
				                                                                               ProductCodeStarting,
				                                                                               ProductCodeENDing,
				                                                                               PlanCodeStarting,
				                                                                               PlanCodeENDing,
				                                                                               MaterialType,
				                                                                               Source,
				                                                                               pStocked,
				                                                                               ABCCode,
				                                                                               ExcludeZeroNetRequirements,
				                                                                               IncludeTransfers,
				                                                                               DisplayHeader,
				                                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
