//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBLotFactory
	{
		public ICLM_ESBLot Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBLot = new BusInterface.CLM_ESBLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBLotExt = timerfactory.Create<BusInterface.ICLM_ESBLot>(_CLM_ESBLot);
			
			return iCLM_ESBLotExt;
		}
	}
}
