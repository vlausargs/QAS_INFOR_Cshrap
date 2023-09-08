//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVouchersPocWarnFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersPocWarnFactory
	{
		public IGenerateLCVouchersPocWarn Create(IApplicationDB appDB)
		{
			var _GenerateLCVouchersPocWarn = new Logistics.Vendor.GenerateLCVouchersPocWarn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateLCVouchersPocWarnExt = timerfactory.Create<Logistics.Vendor.IGenerateLCVouchersPocWarn>(_GenerateLCVouchersPocWarn);
			
			return iGenerateLCVouchersPocWarnExt;
		}
	}
}
