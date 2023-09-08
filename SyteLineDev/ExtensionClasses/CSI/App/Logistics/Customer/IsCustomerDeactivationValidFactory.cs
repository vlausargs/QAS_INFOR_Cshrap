//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerDeactivationValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class IsCustomerDeactivationValidFactory
	{
		public IIsCustomerDeactivationValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsCustomerDeactivationValid = new Logistics.Customer.IsCustomerDeactivationValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCustomerDeactivationValidExt = timerfactory.Create<Logistics.Customer.IIsCustomerDeactivationValid>(_IsCustomerDeactivationValid);
			
			return iIsCustomerDeactivationValidExt;
		}
	}
}
