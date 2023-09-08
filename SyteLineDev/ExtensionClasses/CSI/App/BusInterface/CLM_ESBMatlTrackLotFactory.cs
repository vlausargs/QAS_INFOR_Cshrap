//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBMatlTrackLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBMatlTrackLotFactory
	{
		public ICLM_ESBMatlTrackLot Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBMatlTrackLot = new BusInterface.CLM_ESBMatlTrackLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBMatlTrackLotExt = timerfactory.Create<BusInterface.ICLM_ESBMatlTrackLot>(_CLM_ESBMatlTrackLot);
			
			return iCLM_ESBMatlTrackLotExt;
		}
	}
}
