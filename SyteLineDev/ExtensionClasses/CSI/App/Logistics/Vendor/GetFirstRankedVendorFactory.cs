//PROJECT NAME: CSIVendor
//CLASS NAME: GetFirstRankedVendorFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetFirstRankedVendorFactory
	{
		public IGetFirstRankedVendor Create(IApplicationDB appDB)
		{
			var _GetFirstRankedVendor = new Logistics.Vendor.GetFirstRankedVendor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFirstRankedVendorExt = timerfactory.Create<Logistics.Vendor.IGetFirstRankedVendor>(_GetFirstRankedVendor);
			
			return iGetFirstRankedVendorExt;
		}
	}
}
