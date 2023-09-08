//PROJECT NAME: ReportExt
//CLASS NAME: SLItemCostingReport.cs

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
    [IDOExtensionClass("SLItemCostingReport")]
    public class SLItemCostingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemCostingSp([Optional] string pMatlType,
		                                   [Optional] string pPMTCode,
		                                   [Optional] string pStocked,
		                                   [Optional] string pAbcCode,
		                                   [Optional] byte? pPrZeroQty,
		                                   [Optional] string pSortBy,
		                                   [Optional] string pItemstarting,
		                                   [Optional] string pItemEnding,
		                                   [Optional] string pProdCodeStarting,
		                                   [Optional] string pProdCodeEnding,
		                                   [Optional] string FromWarehouse,
		                                   [Optional] string ToWarehouse,
		                                   [Optional] byte? DisplayHeader,
		                                   [Optional] byte? CostItemAtWhse,
		                                   [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemCostingExt = new Rpt_ItemCostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemCostingExt.Rpt_ItemCostingSp(pMatlType,
				                                                   pPMTCode,
				                                                   pStocked,
				                                                   pAbcCode,
				                                                   pPrZeroQty,
				                                                   pSortBy,
				                                                   pItemstarting,
				                                                   pItemEnding,
				                                                   pProdCodeStarting,
				                                                   pProdCodeEnding,
				                                                   FromWarehouse,
				                                                   ToWarehouse,
				                                                   DisplayHeader,
				                                                   CostItemAtWhse,
				                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
