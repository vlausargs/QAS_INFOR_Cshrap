//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBProductionReceiverItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBProductionReceiverItemFactory
	{
		public ICLM_ESBProductionReceiverItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBProductionReceiverItem = new BusInterface.CLM_ESBProductionReceiverItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBProductionReceiverItemExt = timerfactory.Create<BusInterface.ICLM_ESBProductionReceiverItem>(_CLM_ESBProductionReceiverItem);
			
			return iCLM_ESBProductionReceiverItemExt;
		}
	}
}
