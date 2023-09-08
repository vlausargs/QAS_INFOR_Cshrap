//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCarrierRouteShipmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCarrierRouteShipmentFactory
	{
		public ICLM_ESBCarrierRouteShipment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCarrierRouteShipment = new BusInterface.CLM_ESBCarrierRouteShipment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCarrierRouteShipmentExt = timerfactory.Create<BusInterface.ICLM_ESBCarrierRouteShipment>(_CLM_ESBCarrierRouteShipment);
			
			return iCLM_ESBCarrierRouteShipmentExt;
		}
	}
}
