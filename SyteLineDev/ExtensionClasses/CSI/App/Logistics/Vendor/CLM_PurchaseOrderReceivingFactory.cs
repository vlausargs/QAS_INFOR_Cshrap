//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchaseOrderReceivingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchaseOrderReceivingFactory
	{
		public ICLM_PurchaseOrderReceiving Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PurchaseOrderReceiving = new Logistics.Vendor.CLM_PurchaseOrderReceiving(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PurchaseOrderReceivingExt = timerfactory.Create<Logistics.Vendor.ICLM_PurchaseOrderReceiving>(_CLM_PurchaseOrderReceiving);
			
			return iCLM_PurchaseOrderReceivingExt;
		}
	}
}
