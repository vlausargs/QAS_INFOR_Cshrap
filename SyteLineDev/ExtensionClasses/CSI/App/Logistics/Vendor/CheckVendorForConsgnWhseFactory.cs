//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendorForConsgnWhseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckVendorForConsgnWhseFactory
	{
		public ICheckVendorForConsgnWhse Create(IApplicationDB appDB)
		{
			var _CheckVendorForConsgnWhse = new Logistics.Vendor.CheckVendorForConsgnWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckVendorForConsgnWhseExt = timerfactory.Create<Logistics.Vendor.ICheckVendorForConsgnWhse>(_CheckVendorForConsgnWhse);
			
			return iCheckVendorForConsgnWhseExt;
		}
	}
}
