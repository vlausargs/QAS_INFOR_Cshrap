//PROJECT NAME: Logistics
//CLASS NAME: CLM_ServiceOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class CLM_ServiceOrdersFactory
	{
		public ICLM_ServiceOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ServiceOrders = new Logistics.FieldService.Requests.CLM_ServiceOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ServiceOrdersExt = timerfactory.Create<Logistics.FieldService.Requests.ICLM_ServiceOrders>(_CLM_ServiceOrders);
			
			return iCLM_ServiceOrdersExt;
		}
	}
}
