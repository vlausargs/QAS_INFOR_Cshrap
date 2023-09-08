//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileVoucherAdjFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileVoucherAdjFactory
	{
		public IProfileVoucherAdj Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileVoucherAdj = new Logistics.Vendor.ProfileVoucherAdj(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileVoucherAdjExt = timerfactory.Create<Logistics.Vendor.IProfileVoucherAdj>(_ProfileVoucherAdj);
			
			return iProfileVoucherAdjExt;
		}
	}
}
