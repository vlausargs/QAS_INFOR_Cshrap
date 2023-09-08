//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBOpportunityTaskFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBOpportunityTaskFactory
	{
		public ICLM_ESBOpportunityTask Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBOpportunityTask = new BusInterface.CLM_ESBOpportunityTask(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBOpportunityTaskExt = timerfactory.Create<BusInterface.ICLM_ESBOpportunityTask>(_CLM_ESBOpportunityTask);
			
			return iCLM_ESBOpportunityTaskExt;
		}
	}
}
