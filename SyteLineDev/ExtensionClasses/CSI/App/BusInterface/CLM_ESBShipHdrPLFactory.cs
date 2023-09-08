//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipHdrPLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipHdrPLFactory
	{
		public ICLM_ESBShipHdrPL Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipHdrPL = new BusInterface.CLM_ESBShipHdrPL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipHdrPLExt = timerfactory.Create<BusInterface.ICLM_ESBShipHdrPL>(_CLM_ESBShipHdrPL);
			
			return iCLM_ESBShipHdrPLExt;
		}
	}
}
