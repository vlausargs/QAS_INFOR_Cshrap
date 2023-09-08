//PROJECT NAME: CSIVendor
//CLASS NAME: GetDefaultBankCodeForAPPaymentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDefaultBankCodeForAPPaymentFactory
	{
		public IGetDefaultBankCodeForAPPayment Create(IApplicationDB appDB)
		{
			var _GetDefaultBankCodeForAPPayment = new Logistics.Vendor.GetDefaultBankCodeForAPPayment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDefaultBankCodeForAPPaymentExt = timerfactory.Create<Logistics.Vendor.IGetDefaultBankCodeForAPPayment>(_GetDefaultBankCodeForAPPayment);
			
			return iGetDefaultBankCodeForAPPaymentExt;
		}
	}
}
