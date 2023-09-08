//PROJECT NAME: Logistics
//CLASS NAME: CustomerRevDayFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustomerRevDayFactory
	{
		public ICustomerRevDay Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerRevDay = new Logistics.Customer.CustomerRevDay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerRevDayExt = timerfactory.Create<Logistics.Customer.ICustomerRevDay>(_CustomerRevDay);
			
			return iCustomerRevDayExt;
		}
	}
}
