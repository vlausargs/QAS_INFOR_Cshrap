//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceiveHdrPLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceiveHdrPLFactory
	{
		public ICLM_ESBReceiveHdrPL Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceiveHdrPL = new BusInterface.CLM_ESBReceiveHdrPL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceiveHdrPLExt = timerfactory.Create<BusInterface.ICLM_ESBReceiveHdrPL>(_CLM_ESBReceiveHdrPL);
			
			return iCLM_ESBReceiveHdrPLExt;
		}
	}
}
