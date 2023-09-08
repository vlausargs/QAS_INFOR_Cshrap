//PROJECT NAME: Logistics
//CLASS NAME: ArpmtValidatePaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtValidatePaymentFactory
	{
		public IArpmtValidatePayment Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtValidatePayment = new Logistics.Customer.ArpmtValidatePayment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtValidatePaymentExt = timerfactory.Create<Logistics.Customer.IArpmtValidatePayment>(_ArpmtValidatePayment);
			
			return iArpmtValidatePaymentExt;
		}
	}
}
