//PROJECT NAME: Codes
//CLASS NAME: CustomerPortalCreateCustomerShipToFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class CustomerPortalCreateCustomerShipToFactory
	{
		public ICustomerPortalCreateCustomerShipTo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerPortalCreateCustomerShipTo = new Codes.CustomerPortalCreateCustomerShipTo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerPortalCreateCustomerShipToExt = timerfactory.Create<Codes.ICustomerPortalCreateCustomerShipTo>(_CustomerPortalCreateCustomerShipTo);
			
			return iCustomerPortalCreateCustomerShipToExt;
		}
	}
}
