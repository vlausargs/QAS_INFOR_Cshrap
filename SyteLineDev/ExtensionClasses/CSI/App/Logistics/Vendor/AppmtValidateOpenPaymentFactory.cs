//PROJECT NAME: Logistics
//CLASS NAME: AppmtValidateOpenPaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtValidateOpenPaymentFactory
	{
		public IAppmtValidateOpenPayment Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtValidateOpenPayment = new Logistics.Vendor.AppmtValidateOpenPayment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtValidateOpenPaymentExt = timerfactory.Create<Logistics.Vendor.IAppmtValidateOpenPayment>(_AppmtValidateOpenPayment);
			
			return iAppmtValidateOpenPaymentExt;
		}
	}
}
