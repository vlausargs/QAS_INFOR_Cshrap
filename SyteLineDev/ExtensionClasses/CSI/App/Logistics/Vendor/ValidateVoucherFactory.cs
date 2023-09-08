//PROJECT NAME: Logistics
//CLASS NAME: ValidateVoucherFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateVoucherFactory
	{
		public IValidateVoucher Create(IApplicationDB appDB)
		{
			var _ValidateVoucher = new Logistics.Vendor.ValidateVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateVoucherExt = timerfactory.Create<Logistics.Vendor.IValidateVoucher>(_ValidateVoucher);
			
			return iValidateVoucherExt;
		}
	}
}
