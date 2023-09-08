//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerOrderDocumentLifecycleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerOrderDocumentLifecycleFactory
	{
		public ICLM_CustomerOrderDocumentLifecycle Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerOrderDocumentLifecycle = new Logistics.Customer.CLM_CustomerOrderDocumentLifecycle(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerOrderDocumentLifecycleExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerOrderDocumentLifecycle>(_CLM_CustomerOrderDocumentLifecycle);
			
			return iCLM_CustomerOrderDocumentLifecycleExt;
		}
	}
}
