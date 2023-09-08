//PROJECT NAME: Logistics
//CLASS NAME: VendorGetVoucherNoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorGetVoucherNoFactory
	{
		public IVendorGetVoucherNo Create(IApplicationDB appDB)
		{
			var _VendorGetVoucherNo = new Logistics.Vendor.VendorGetVoucherNo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorGetVoucherNoExt = timerfactory.Create<Logistics.Vendor.IVendorGetVoucherNo>(_VendorGetVoucherNo);
			
			return iVendorGetVoucherNoExt;
		}
	}
}
