//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBProductionOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBProductionOrderFactory
	{
		public ICLM_ESBProductionOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBProductionOrder = new BusInterface.CLM_ESBProductionOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBProductionOrderExt = timerfactory.Create<BusInterface.ICLM_ESBProductionOrder>(_CLM_ESBProductionOrder);
			
			return iCLM_ESBProductionOrderExt;
		}
	}
}
