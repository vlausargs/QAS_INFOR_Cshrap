//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DemandSummaryWithOperationsSchedulerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DemandSummaryWithOperationsSchedulerFactory
	{
		public IRpt_DemandSummaryWithOperationsScheduler Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DemandSummaryWithOperationsScheduler = new Reporting.Rpt_DemandSummaryWithOperationsScheduler(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DemandSummaryWithOperationsSchedulerExt = timerfactory.Create<Reporting.IRpt_DemandSummaryWithOperationsScheduler>(_Rpt_DemandSummaryWithOperationsScheduler);
			
			return iRpt_DemandSummaryWithOperationsSchedulerExt;
		}
	}
}
