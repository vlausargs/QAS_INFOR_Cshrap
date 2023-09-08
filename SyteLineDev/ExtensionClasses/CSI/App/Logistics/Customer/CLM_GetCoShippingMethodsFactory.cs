//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCoShippingMethodsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCoShippingMethodsFactory
	{
		public ICLM_GetCoShippingMethods Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCoShippingMethods = new Logistics.Customer.CLM_GetCoShippingMethods(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCoShippingMethodsExt = timerfactory.Create<Logistics.Customer.ICLM_GetCoShippingMethods>(_CLM_GetCoShippingMethods);
			
			return iCLM_GetCoShippingMethodsExt;
		}
	}
}
