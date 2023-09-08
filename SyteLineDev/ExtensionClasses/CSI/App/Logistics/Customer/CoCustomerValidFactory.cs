//PROJECT NAME: Logistics
//CLASS NAME: CoCustomerValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoCustomerValidFactory
	{
		public ICoCustomerValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoCustomerValid = new Logistics.Customer.CoCustomerValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoCustomerValidExt = timerfactory.Create<Logistics.Customer.ICoCustomerValid>(_CoCustomerValid);
			
			return iCoCustomerValidExt;
		}
	}
}
