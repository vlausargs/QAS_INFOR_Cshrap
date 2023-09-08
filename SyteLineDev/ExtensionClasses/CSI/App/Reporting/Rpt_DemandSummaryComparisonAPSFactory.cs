//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DemandSummaryComparisonAPSFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DemandSummaryComparisonAPSFactory
	{
		public IRpt_DemandSummaryComparisonAPS Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DemandSummaryComparisonAPS = new Reporting.Rpt_DemandSummaryComparisonAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DemandSummaryComparisonAPSExt = timerfactory.Create<Reporting.IRpt_DemandSummaryComparisonAPS>(_Rpt_DemandSummaryComparisonAPS);
			
			return iRpt_DemandSummaryComparisonAPSExt;
		}
	}
}
