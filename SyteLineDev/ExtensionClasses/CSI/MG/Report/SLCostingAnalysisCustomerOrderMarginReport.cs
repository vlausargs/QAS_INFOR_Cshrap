//PROJECT NAME: ReportExt
//CLASS NAME: SLCostingAnalysisCustomerOrderMarginReport.cs

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
    [IDOExtensionClass("SLCostingAnalysisCustomerOrderMarginReport")]
    public class SLCostingAnalysisCustomerOrderMarginReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CostingAnalysisCustomerOrderMarginSp([Optional] string CostingAlt,
		[Optional, DefaultParameterValue(0)] int? GroupByCustomer,
		[Optional, DefaultParameterValue(0)] int? GroupByCO,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] string EstimateOrderStarting,
		[Optional] string EstimateOrderEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] string OrderType,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CostingAnalysisCustomerOrderMarginExt = new Rpt_CostingAnalysisCustomerOrderMarginFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CostingAnalysisCustomerOrderMarginExt.Rpt_CostingAnalysisCustomerOrderMarginSp(CostingAlt,
				GroupByCustomer,
				GroupByCO,
				CustomerStarting,
				CustomerEnding,
				OrderStarting,
				OrderEnding,
				EstimateOrderStarting,
				EstimateOrderEnding,
				ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				DisplayHeader,
				OrderType,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
