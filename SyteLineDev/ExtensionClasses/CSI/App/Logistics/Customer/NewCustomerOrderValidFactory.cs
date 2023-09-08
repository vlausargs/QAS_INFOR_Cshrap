//PROJECT NAME: Logistics
//CLASS NAME: NewCustomerOrderValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class NewCustomerOrderValidFactory
	{
		public INewCustomerOrderValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NewCustomerOrderValid = new Logistics.Customer.NewCustomerOrderValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNewCustomerOrderValidExt = timerfactory.Create<Logistics.Customer.INewCustomerOrderValid>(_NewCustomerOrderValid);
			
			return iNewCustomerOrderValidExt;
		}
	}
}
