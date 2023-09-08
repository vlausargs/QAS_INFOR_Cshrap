//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEstimateOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBEstimateOrderFactory
	{
		public ICLM_ESBEstimateOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBEstimateOrder = new BusInterface.CLM_ESBEstimateOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBEstimateOrderExt = timerfactory.Create<BusInterface.ICLM_ESBEstimateOrder>(_CLM_ESBEstimateOrder);
			
			return iCLM_ESBEstimateOrderExt;
		}
	}
}
