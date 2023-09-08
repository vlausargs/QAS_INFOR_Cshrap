//PROJECT NAME: Logistics
//CLASS NAME: CustomerCreditCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustomerCreditCheckFactory
	{
		public ICustomerCreditCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerCreditCheck = new Logistics.Customer.CustomerCreditCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerCreditCheckExt = timerfactory.Create<Logistics.Customer.ICustomerCreditCheck>(_CustomerCreditCheck);
			
			return iCustomerCreditCheckExt;
		}
	}
}
