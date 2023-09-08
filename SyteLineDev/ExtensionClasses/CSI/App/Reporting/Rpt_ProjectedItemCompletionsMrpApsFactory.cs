//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsMrpApsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsMrpApsFactory
	{
		public IRpt_ProjectedItemCompletionsMrpAps Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedItemCompletionsMrpAps = new Reporting.Rpt_ProjectedItemCompletionsMrpAps(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedItemCompletionsMrpApsExt = timerfactory.Create<Reporting.IRpt_ProjectedItemCompletionsMrpAps>(_Rpt_ProjectedItemCompletionsMrpAps);
			
			return iRpt_ProjectedItemCompletionsMrpApsExt;
		}
	}
}
