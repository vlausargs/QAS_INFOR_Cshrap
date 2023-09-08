//PROJECT NAME: CSIVendor
//CLASS NAME: AptrxVerifyVoucherNoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AptrxVerifyVoucherNoFactory
	{
		public IAptrxVerifyVoucherNo Create(IApplicationDB appDB)
		{
			var _AptrxVerifyVoucherNo = new Logistics.Vendor.AptrxVerifyVoucherNo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxVerifyVoucherNoExt = timerfactory.Create<Logistics.Vendor.IAptrxVerifyVoucherNo>(_AptrxVerifyVoucherNo);
			
			return iAptrxVerifyVoucherNoExt;
		}
	}
}
