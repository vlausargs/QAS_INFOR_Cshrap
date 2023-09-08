//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVoucherCompStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVoucherCompStatusFactory
	{
		public IGenerateLCVoucherCompStatus Create(IApplicationDB appDB)
		{
			var _GenerateLCVoucherCompStatus = new Logistics.Vendor.GenerateLCVoucherCompStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateLCVoucherCompStatusExt = timerfactory.Create<Logistics.Vendor.IGenerateLCVoucherCompStatus>(_GenerateLCVoucherCompStatus);
			
			return iGenerateLCVoucherCompStatusExt;
		}
	}
}
