//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipLinePLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipLinePLFactory
	{
		public ICLM_ESBShipLinePL Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipLinePL = new BusInterface.CLM_ESBShipLinePL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipLinePLExt = timerfactory.Create<BusInterface.ICLM_ESBShipLinePL>(_CLM_ESBShipLinePL);
			
			return iCLM_ESBShipLinePLExt;
		}
	}
}
