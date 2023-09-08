//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DemandSummaryWithOperationsAPSFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DemandSummaryWithOperationsAPSFactory
	{
		public IRpt_DemandSummaryWithOperationsAPS Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DemandSummaryWithOperationsAPS = new Reporting.Rpt_DemandSummaryWithOperationsAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DemandSummaryWithOperationsAPSExt = timerfactory.Create<Reporting.IRpt_DemandSummaryWithOperationsAPS>(_Rpt_DemandSummaryWithOperationsAPS);
			
			return iRpt_DemandSummaryWithOperationsAPSExt;
		}
	}
}
