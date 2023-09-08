//PROJECT NAME: CSIVendor
//CLASS NAME: EvaluateAutoVoucherFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EvaluateAutoVoucherFactory
	{
		public IEvaluateAutoVoucher Create(IApplicationDB appDB)
		{
			var _EvaluateAutoVoucher = new Logistics.Vendor.EvaluateAutoVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEvaluateAutoVoucherExt = timerfactory.Create<Logistics.Vendor.IEvaluateAutoVoucher>(_EvaluateAutoVoucher);
			
			return iEvaluateAutoVoucherExt;
		}
	}
}
