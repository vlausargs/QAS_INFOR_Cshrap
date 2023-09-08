//PROJECT NAME: Logistics
//CLASS NAME: VendorVerifyVoucherNoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorVerifyVoucherNoFactory
	{
		public IVendorVerifyVoucherNo Create(IApplicationDB appDB)
		{
			var _VendorVerifyVoucherNo = new Logistics.Vendor.VendorVerifyVoucherNo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorVerifyVoucherNoExt = timerfactory.Create<Logistics.Vendor.IVendorVerifyVoucherNo>(_VendorVerifyVoucherNo);
			
			return iVendorVerifyVoucherNoExt;
		}
	}
}
