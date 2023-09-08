//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchaseOrderDocumentLifecycleTreeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchaseOrderDocumentLifecycleTreeFactory
	{
		public ICLM_PurchaseOrderDocumentLifecycleTree Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PurchaseOrderDocumentLifecycleTree = new Logistics.Vendor.CLM_PurchaseOrderDocumentLifecycleTree(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PurchaseOrderDocumentLifecycleTreeExt = timerfactory.Create<Logistics.Vendor.ICLM_PurchaseOrderDocumentLifecycleTree>(_CLM_PurchaseOrderDocumentLifecycleTree);
			
			return iCLM_PurchaseOrderDocumentLifecycleTreeExt;
		}
	}
}
