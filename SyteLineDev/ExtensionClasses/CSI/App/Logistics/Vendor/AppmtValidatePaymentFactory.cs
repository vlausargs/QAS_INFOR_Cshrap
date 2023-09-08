//PROJECT NAME: Logistics
//CLASS NAME: AppmtValidatePaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtValidatePaymentFactory
	{
		public IAppmtValidatePayment Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtValidatePayment = new Logistics.Vendor.AppmtValidatePayment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtValidatePaymentExt = timerfactory.Create<Logistics.Vendor.IAppmtValidatePayment>(_AppmtValidatePayment);
			
			return iAppmtValidatePaymentExt;
		}
	}
}
