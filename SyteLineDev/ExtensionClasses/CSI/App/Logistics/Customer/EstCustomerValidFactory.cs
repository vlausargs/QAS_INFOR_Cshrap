//PROJECT NAME: Logistics
//CLASS NAME: EstCustomerValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstCustomerValidFactory
	{
		public IEstCustomerValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstCustomerValid = new Logistics.Customer.EstCustomerValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstCustomerValidExt = timerfactory.Create<Logistics.Customer.IEstCustomerValid>(_EstCustomerValid);
			
			return iEstCustomerValidExt;
		}
	}
}
