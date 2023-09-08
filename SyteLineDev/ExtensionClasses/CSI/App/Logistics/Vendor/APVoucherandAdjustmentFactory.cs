//PROJECT NAME: CSIVendor
//CLASS NAME: APVoucherandAdjustmentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APVoucherandAdjustmentFactory
	{
		public IAPVoucherandAdjustment Create(IApplicationDB appDB)
		{
			var _APVoucherandAdjustment = new Logistics.Vendor.APVoucherandAdjustment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPVoucherandAdjustmentExt = timerfactory.Create<Logistics.Vendor.IAPVoucherandAdjustment>(_APVoucherandAdjustment);
			
			return iAPVoucherandAdjustmentExt;
		}
	}
}
