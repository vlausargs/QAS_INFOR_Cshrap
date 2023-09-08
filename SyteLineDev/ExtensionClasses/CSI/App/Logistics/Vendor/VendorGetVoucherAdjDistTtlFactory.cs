//PROJECT NAME: Logistics
//CLASS NAME: VendorGetVoucherAdjDistTtlFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorGetVoucherAdjDistTtlFactory
	{
		public IVendorGetVoucherAdjDistTtl Create(IApplicationDB appDB)
		{
			var _VendorGetVoucherAdjDistTtl = new Logistics.Vendor.VendorGetVoucherAdjDistTtl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorGetVoucherAdjDistTtlExt = timerfactory.Create<Logistics.Vendor.IVendorGetVoucherAdjDistTtl>(_VendorGetVoucherAdjDistTtl);
			
			return iVendorGetVoucherAdjDistTtlExt;
		}
	}
}
