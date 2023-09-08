//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInventoryHoldLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInventoryHoldLotFactory
	{
		public ICLM_ESBInventoryHoldLot Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInventoryHoldLot = new BusInterface.CLM_ESBInventoryHoldLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInventoryHoldLotExt = timerfactory.Create<BusInterface.ICLM_ESBInventoryHoldLot>(_CLM_ESBInventoryHoldLot);
			
			return iCLM_ESBInventoryHoldLotExt;
		}
	}
}
