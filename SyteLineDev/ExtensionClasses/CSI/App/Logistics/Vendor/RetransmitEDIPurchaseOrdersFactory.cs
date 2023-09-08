//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIPurchaseOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class RetransmitEDIPurchaseOrdersFactory
	{
		public IRetransmitEDIPurchaseOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIPurchaseOrders = new Logistics.Vendor.RetransmitEDIPurchaseOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIPurchaseOrdersExt = timerfactory.Create<Logistics.Vendor.IRetransmitEDIPurchaseOrders>(_RetransmitEDIPurchaseOrders);
			
			return iRetransmitEDIPurchaseOrdersExt;
		}
	}
}
