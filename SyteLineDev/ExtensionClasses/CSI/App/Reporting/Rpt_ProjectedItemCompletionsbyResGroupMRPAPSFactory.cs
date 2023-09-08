//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsbyResGroupMRPAPSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsbyResGroupMRPAPSFactory
	{
		public IRpt_ProjectedItemCompletionsbyResGroupMRPAPS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedItemCompletionsbyResGroupMRPAPS = new Reporting.Rpt_ProjectedItemCompletionsbyResGroupMRPAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedItemCompletionsbyResGroupMRPAPSExt = timerfactory.Create<Reporting.IRpt_ProjectedItemCompletionsbyResGroupMRPAPS>(_Rpt_ProjectedItemCompletionsbyResGroupMRPAPS);
			
			return iRpt_ProjectedItemCompletionsbyResGroupMRPAPSExt;
		}
	}
}
