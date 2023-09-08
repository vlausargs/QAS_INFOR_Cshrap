//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerActiveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class IsCustomerActiveFactory
	{
		public IIsCustomerActive Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsCustomerActive = new Logistics.Customer.IsCustomerActive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCustomerActiveExt = timerfactory.Create<Logistics.Customer.IIsCustomerActive>(_IsCustomerActive);
			
			return iIsCustomerActiveExt;
		}
	}
}
