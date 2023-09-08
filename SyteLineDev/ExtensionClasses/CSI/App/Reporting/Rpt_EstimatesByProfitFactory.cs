//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimatesByProfitFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EstimatesByProfitFactory
	{
		public IRpt_EstimatesByProfit Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EstimatesByProfit = new Reporting.Rpt_EstimatesByProfit(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EstimatesByProfitExt = timerfactory.Create<Reporting.IRpt_EstimatesByProfit>(_Rpt_EstimatesByProfit);
			
			return iRpt_EstimatesByProfitExt;
		}
	}
}
