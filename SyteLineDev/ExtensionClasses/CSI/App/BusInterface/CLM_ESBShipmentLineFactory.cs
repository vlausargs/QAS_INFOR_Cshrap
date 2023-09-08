//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipmentLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipmentLineFactory
	{
		public ICLM_ESBShipmentLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipmentLine = new BusInterface.CLM_ESBShipmentLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipmentLineExt = timerfactory.Create<BusInterface.ICLM_ESBShipmentLine>(_CLM_ESBShipmentLine);
			
			return iCLM_ESBShipmentLineExt;
		}
	}
}
