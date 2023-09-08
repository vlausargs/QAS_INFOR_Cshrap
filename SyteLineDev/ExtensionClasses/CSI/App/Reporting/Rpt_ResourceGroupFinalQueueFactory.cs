//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupFinalQueueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupFinalQueueFactory
	{
		public IRpt_ResourceGroupFinalQueue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceGroupFinalQueue = new Reporting.Rpt_ResourceGroupFinalQueue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceGroupFinalQueueExt = timerfactory.Create<Reporting.IRpt_ResourceGroupFinalQueue>(_Rpt_ResourceGroupFinalQueue);
			
			return iRpt_ResourceGroupFinalQueueExt;
		}
	}
}
