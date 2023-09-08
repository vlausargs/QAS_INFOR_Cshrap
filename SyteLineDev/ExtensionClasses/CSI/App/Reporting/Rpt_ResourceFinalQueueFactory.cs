//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceFinalQueueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceFinalQueueFactory
	{
		public IRpt_ResourceFinalQueue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceFinalQueue = new Reporting.Rpt_ResourceFinalQueue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceFinalQueueExt = timerfactory.Create<Reporting.IRpt_ResourceFinalQueue>(_Rpt_ResourceFinalQueue);
			
			return iRpt_ResourceFinalQueueExt;
		}
	}
}
