//PROJECT NAME: CSIVendor
//CLASS NAME: ProfilePurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfilePurchaseOrderFactory
	{
		public IProfilePurchaseOrder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfilePurchaseOrder = new Logistics.Vendor.ProfilePurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfilePurchaseOrderExt = timerfactory.Create<Logistics.Vendor.IProfilePurchaseOrder>(_ProfilePurchaseOrder);
			
			return iProfilePurchaseOrderExt;
		}
	}
}
