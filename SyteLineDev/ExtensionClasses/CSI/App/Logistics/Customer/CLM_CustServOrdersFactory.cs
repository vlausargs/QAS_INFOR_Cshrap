//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustServOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustServOrdersFactory
	{
		public ICLM_CustServOrders Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustServOrders = new Logistics.Customer.CLM_CustServOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustServOrdersExt = timerfactory.Create<Logistics.Customer.ICLM_CustServOrders>(_CLM_CustServOrders);
			
			return iCLM_CustServOrdersExt;
		}
	}
}
