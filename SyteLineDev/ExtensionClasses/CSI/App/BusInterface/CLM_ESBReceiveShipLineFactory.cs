//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceiveShipLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceiveShipLineFactory
	{
		public ICLM_ESBReceiveShipLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceiveShipLine = new BusInterface.CLM_ESBReceiveShipLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceiveShipLineExt = timerfactory.Create<BusInterface.ICLM_ESBReceiveShipLine>(_CLM_ESBReceiveShipLine);
			
			return iCLM_ESBReceiveShipLineExt;
		}
	}
}
