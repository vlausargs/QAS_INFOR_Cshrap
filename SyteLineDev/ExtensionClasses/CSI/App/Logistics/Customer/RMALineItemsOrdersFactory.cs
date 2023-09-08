//PROJECT NAME: Logistics
//CLASS NAME: RMALineItemsOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class RMALineItemsOrdersFactory
	{
		public IRMALineItemsOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RMALineItemsOrders = new Logistics.Customer.RMALineItemsOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRMALineItemsOrdersExt = timerfactory.Create<Logistics.Customer.IRMALineItemsOrders>(_RMALineItemsOrders);
			
			return iRMALineItemsOrdersExt;
		}
	}
}
