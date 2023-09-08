//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceiveShipHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceiveShipHdrFactory
	{
		public ICLM_ESBReceiveShipHdr Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceiveShipHdr = new BusInterface.CLM_ESBReceiveShipHdr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceiveShipHdrExt = timerfactory.Create<BusInterface.ICLM_ESBReceiveShipHdr>(_CLM_ESBReceiveShipHdr);
			
			return iCLM_ESBReceiveShipHdrExt;
		}
	}
}
