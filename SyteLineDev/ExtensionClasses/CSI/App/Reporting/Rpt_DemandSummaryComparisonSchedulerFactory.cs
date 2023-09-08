//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DemandSummaryComparisonSchedulerFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DemandSummaryComparisonSchedulerFactory
	{
		public IRpt_DemandSummaryComparisonScheduler Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DemandSummaryComparisonScheduler = new Reporting.Rpt_DemandSummaryComparisonScheduler(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DemandSummaryComparisonSchedulerExt = timerfactory.Create<Reporting.IRpt_DemandSummaryComparisonScheduler>(_Rpt_DemandSummaryComparisonScheduler);
			
			return iRpt_DemandSummaryComparisonSchedulerExt;
		}
	}
}
