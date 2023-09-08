//PROJECT NAME: Logistics
//CLASS NAME: GetCustomerWhseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCustomerWhseFactory
	{
		public IGetCustomerWhse Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCustomerWhse = new Logistics.Customer.GetCustomerWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustomerWhseExt = timerfactory.Create<Logistics.Customer.IGetCustomerWhse>(_GetCustomerWhse);
			
			return iGetCustomerWhseExt;
		}
	}
}
