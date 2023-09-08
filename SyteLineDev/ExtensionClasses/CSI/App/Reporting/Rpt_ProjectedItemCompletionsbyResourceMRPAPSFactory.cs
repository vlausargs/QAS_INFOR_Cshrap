//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsbyResourceMRPAPSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsbyResourceMRPAPSFactory
	{
		public IRpt_ProjectedItemCompletionsbyResourceMRPAPS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedItemCompletionsbyResourceMRPAPS = new Reporting.Rpt_ProjectedItemCompletionsbyResourceMRPAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedItemCompletionsbyResourceMRPAPSExt = timerfactory.Create<Reporting.IRpt_ProjectedItemCompletionsbyResourceMRPAPS>(_Rpt_ProjectedItemCompletionsbyResourceMRPAPS);
			
			return iRpt_ProjectedItemCompletionsbyResourceMRPAPSExt;
		}
	}
}
