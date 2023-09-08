//PROJECT NAME: Admin
//CLASS NAME: CLM_PortalMetricSubmittedOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_PortalMetricSubmittedOrdersFactory
	{
		public ICLM_PortalMetricSubmittedOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalMetricSubmittedOrders = new Admin.CLM_PortalMetricSubmittedOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalMetricSubmittedOrdersExt = timerfactory.Create<Admin.ICLM_PortalMetricSubmittedOrders>(_CLM_PortalMetricSubmittedOrders);
			
			return iCLM_PortalMetricSubmittedOrdersExt;
		}
	}
}
