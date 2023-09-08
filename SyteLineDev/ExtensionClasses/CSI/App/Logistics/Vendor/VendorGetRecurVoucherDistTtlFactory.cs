//PROJECT NAME: Logistics
//CLASS NAME: VendorGetRecurVoucherDistTtlFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorGetRecurVoucherDistTtlFactory
	{
		public IVendorGetRecurVoucherDistTtl Create(IApplicationDB appDB)
		{
			var _VendorGetRecurVoucherDistTtl = new Logistics.Vendor.VendorGetRecurVoucherDistTtl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorGetRecurVoucherDistTtlExt = timerfactory.Create<Logistics.Vendor.IVendorGetRecurVoucherDistTtl>(_VendorGetRecurVoucherDistTtl);
			
			return iVendorGetRecurVoucherDistTtlExt;
		}
	}
}
