//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInventoryHoldFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInventoryHoldFactory
	{
		public ICLM_ESBInventoryHold Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInventoryHold = new BusInterface.CLM_ESBInventoryHold(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInventoryHoldExt = timerfactory.Create<BusInterface.ICLM_ESBInventoryHold>(_CLM_ESBInventoryHold);
			
			return iCLM_ESBInventoryHoldExt;
		}
	}
}
