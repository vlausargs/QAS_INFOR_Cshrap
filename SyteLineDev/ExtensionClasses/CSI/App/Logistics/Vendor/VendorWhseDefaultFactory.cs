//PROJECT NAME: CSIVendor
//CLASS NAME: VendorWhseDefaultFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorWhseDefaultFactory
	{
		public IVendorWhseDefault Create(IApplicationDB appDB)
		{
			var _VendorWhseDefault = new Logistics.Vendor.VendorWhseDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorWhseDefaultExt = timerfactory.Create<Logistics.Vendor.IVendorWhseDefault>(_VendorWhseDefault);
			
			return iVendorWhseDefaultExt;
		}
	}
}
