//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsolidatedJobCostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ConsolidatedJobCostFactory
	{
		public IRpt_ConsolidatedJobCost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ConsolidatedJobCost = new Reporting.Rpt_ConsolidatedJobCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ConsolidatedJobCostExt = timerfactory.Create<Reporting.IRpt_ConsolidatedJobCost>(_Rpt_ConsolidatedJobCost);
			
			return iRpt_ConsolidatedJobCostExt;
		}
	}
}
