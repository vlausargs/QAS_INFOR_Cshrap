//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCarrierRouteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCarrierRouteFactory
	{
		public ICLM_ESBCarrierRoute Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCarrierRoute = new BusInterface.CLM_ESBCarrierRoute(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCarrierRouteExt = timerfactory.Create<BusInterface.ICLM_ESBCarrierRoute>(_CLM_ESBCarrierRoute);
			
			return iCLM_ESBCarrierRouteExt;
		}
	}
}
