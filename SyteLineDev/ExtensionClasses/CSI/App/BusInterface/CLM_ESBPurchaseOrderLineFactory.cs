//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPurchaseOrderLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPurchaseOrderLineFactory
	{
		public ICLM_ESBPurchaseOrderLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPurchaseOrderLine = new BusInterface.CLM_ESBPurchaseOrderLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPurchaseOrderLineExt = timerfactory.Create<BusInterface.ICLM_ESBPurchaseOrderLine>(_CLM_ESBPurchaseOrderLine);
			
			return iCLM_ESBPurchaseOrderLineExt;
		}
	}
}
