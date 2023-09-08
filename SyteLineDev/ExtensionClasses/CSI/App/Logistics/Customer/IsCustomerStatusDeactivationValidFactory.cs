//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerStatusDeactivationValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class IsCustomerStatusDeactivationValidFactory
	{
		public IIsCustomerStatusDeactivationValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsCustomerStatusDeactivationValid = new Logistics.Customer.IsCustomerStatusDeactivationValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCustomerStatusDeactivationValidExt = timerfactory.Create<Logistics.Customer.IIsCustomerStatusDeactivationValid>(_IsCustomerStatusDeactivationValid);
			
			return iIsCustomerStatusDeactivationValidExt;
		}
	}
}
