//PROJECT NAME: Logistics
//CLASS NAME: VoucherValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherValidFactory
	{
		public IVoucherValid Create(IApplicationDB appDB)
		{
			var _VoucherValid = new Logistics.Vendor.VoucherValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherValidExt = timerfactory.Create<Logistics.Vendor.IVoucherValid>(_VoucherValid);
			
			return iVoucherValidExt;
		}
	}
}
