//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetPortalCoShippingMethodsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetPortalCoShippingMethodsFactory
	{
		public ICLM_GetPortalCoShippingMethods Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetPortalCoShippingMethods = new Logistics.Customer.CLM_GetPortalCoShippingMethods(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetPortalCoShippingMethodsExt = timerfactory.Create<Logistics.Customer.ICLM_GetPortalCoShippingMethods>(_CLM_GetPortalCoShippingMethods);
			
			return iCLM_GetPortalCoShippingMethodsExt;
		}
	}
}
