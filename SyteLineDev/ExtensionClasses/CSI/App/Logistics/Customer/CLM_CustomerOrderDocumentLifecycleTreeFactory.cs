//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerOrderDocumentLifecycleTreeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerOrderDocumentLifecycleTreeFactory
	{
		public ICLM_CustomerOrderDocumentLifecycleTree Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerOrderDocumentLifecycleTree = new Logistics.Customer.CLM_CustomerOrderDocumentLifecycleTree(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerOrderDocumentLifecycleTreeExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerOrderDocumentLifecycleTree>(_CLM_CustomerOrderDocumentLifecycleTree);
			
			return iCLM_CustomerOrderDocumentLifecycleTreeExt;
		}
	}
}
