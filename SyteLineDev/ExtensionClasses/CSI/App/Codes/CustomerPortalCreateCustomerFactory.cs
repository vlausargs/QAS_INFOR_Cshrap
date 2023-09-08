//PROJECT NAME: Codes
//CLASS NAME: CustomerPortalCreateCustomerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class CustomerPortalCreateCustomerFactory
	{
		public ICustomerPortalCreateCustomer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerPortalCreateCustomer = new Codes.CustomerPortalCreateCustomer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerPortalCreateCustomerExt = timerfactory.Create<Codes.ICustomerPortalCreateCustomer>(_CustomerPortalCreateCustomer);
			
			return iCustomerPortalCreateCustomerExt;
		}
	}
}
