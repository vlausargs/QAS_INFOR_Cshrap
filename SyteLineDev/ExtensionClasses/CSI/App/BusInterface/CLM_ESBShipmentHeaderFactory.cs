//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipmentHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipmentHeaderFactory
	{
		public ICLM_ESBShipmentHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipmentHeader = new BusInterface.CLM_ESBShipmentHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipmentHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBShipmentHeader>(_CLM_ESBShipmentHeader);
			
			return iCLM_ESBShipmentHeaderExt;
		}
	}
}
