//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceiveLinePLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceiveLinePLFactory
	{
		public ICLM_ESBReceiveLinePL Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceiveLinePL = new BusInterface.CLM_ESBReceiveLinePL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceiveLinePLExt = timerfactory.Create<BusInterface.ICLM_ESBReceiveLinePL>(_CLM_ESBReceiveLinePL);
			
			return iCLM_ESBReceiveLinePLExt;
		}
	}
}
