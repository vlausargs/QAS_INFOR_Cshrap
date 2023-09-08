//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIPurchaseOrdersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_RetransmitEDIPurchaseOrdersFactory
	{
		public ICLM_RetransmitEDIPurchaseOrders Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIPurchaseOrders = new Logistics.Vendor.CLM_RetransmitEDIPurchaseOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIPurchaseOrdersExt = timerfactory.Create<Logistics.Vendor.ICLM_RetransmitEDIPurchaseOrders>(_RetransmitEDIPurchaseOrders);
			
			return iRetransmitEDIPurchaseOrdersExt;
		}
	}
}
