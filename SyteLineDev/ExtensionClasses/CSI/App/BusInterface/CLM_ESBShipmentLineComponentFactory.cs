//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipmentLineComponentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipmentLineComponentFactory
	{
		public ICLM_ESBShipmentLineComponent Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipmentLineComponent = new BusInterface.CLM_ESBShipmentLineComponent(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipmentLineComponentExt = timerfactory.Create<BusInterface.ICLM_ESBShipmentLineComponent>(_CLM_ESBShipmentLineComponent);
			
			return iCLM_ESBShipmentLineComponentExt;
		}
	}
}
