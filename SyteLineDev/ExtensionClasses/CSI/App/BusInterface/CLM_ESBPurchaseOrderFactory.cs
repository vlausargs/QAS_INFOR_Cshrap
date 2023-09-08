//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPurchaseOrderFactory
	{
		public ICLM_ESBPurchaseOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPurchaseOrder = new BusInterface.CLM_ESBPurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPurchaseOrderExt = timerfactory.Create<BusInterface.ICLM_ESBPurchaseOrder>(_CLM_ESBPurchaseOrder);
			
			return iCLM_ESBPurchaseOrderExt;
		}
	}
}
