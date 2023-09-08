//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileChangeOrderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileChangeOrderFactory
	{
		public IProfileChangeOrder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileChangeOrder = new Logistics.Vendor.ProfileChangeOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileChangeOrderExt = timerfactory.Create<Logistics.Vendor.IProfileChangeOrder>(_ProfileChangeOrder);
			
			return iProfileChangeOrderExt;
		}
	}
}
