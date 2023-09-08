//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemProductCodeCostDetailSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemProductCodeCostDetailSalesAnalysisFactory
	{
		public IRpt_ItemProductCodeCostDetailSalesAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemProductCodeCostDetailSalesAnalysis = new Reporting.Rpt_ItemProductCodeCostDetailSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemProductCodeCostDetailSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ItemProductCodeCostDetailSalesAnalysis>(_Rpt_ItemProductCodeCostDetailSalesAnalysis);
			
			return iRpt_ItemProductCodeCostDetailSalesAnalysisExt;
		}
	}
}
