//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchaseOrderDocumentLifeCycleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchaseOrderDocumentLifeCycleFactory
	{
		public ICLM_PurchaseOrderDocumentLifeCycle Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PurchaseOrderDocumentLifeCycle = new Logistics.Vendor.CLM_PurchaseOrderDocumentLifeCycle(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PurchaseOrderDocumentLifeCycleExt = timerfactory.Create<Logistics.Vendor.ICLM_PurchaseOrderDocumentLifeCycle>(_CLM_PurchaseOrderDocumentLifeCycle);
			
			return iCLM_PurchaseOrderDocumentLifeCycleExt;
		}
	}
}
