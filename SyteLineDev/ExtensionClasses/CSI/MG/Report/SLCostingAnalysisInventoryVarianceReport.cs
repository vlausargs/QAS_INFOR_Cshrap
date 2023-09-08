//PROJECT NAME: ReportExt
//CLASS NAME: SLCostingAnalysisInventoryVarianceReport.cs

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
    [IDOExtensionClass("SLCostingAnalysisInventoryVarianceReport")]
    public class SLCostingAnalysisInventoryVarianceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CostingAnalysisInventoryVarianceSp(string CostingAlt,
		string CostingAltVersus,
		string BOMTypeVersus,
		[Optional] string WhseVersus,
		[Optional] string PMTCode,
		[Optional] string ABCCode,
		[Optional] string CostMethod,
		[Optional] string MatlType,
		[Optional] int? GroupByProdCode,
		[Optional] int? DisplayHeader,
		[Optional] string ProdCodeStarting,
		[Optional] string ProdCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CostingAnalysisInventoryVarianceExt = new Rpt_CostingAnalysisInventoryVarianceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CostingAnalysisInventoryVarianceExt.Rpt_CostingAnalysisInventoryVarianceSp(CostingAlt,
				CostingAltVersus,
				BOMTypeVersus,
				WhseVersus,
				PMTCode,
				ABCCode,
				CostMethod,
				MatlType,
				GroupByProdCode,
				DisplayHeader,
				ProdCodeStarting,
				ProdCodeEnding,
				ItemStarting,
				ItemEnding,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
