//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerDeactivationValidAllFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCustomerDeactivationValidAllFactory
	{
		public IIsCustomerDeactivationValidAll Create(IApplicationDB appDB)
		{
			var _IsCustomerDeactivationValidAll = new Logistics.Customer.IsCustomerDeactivationValidAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCustomerDeactivationValidAllExt = timerfactory.Create<Logistics.Customer.IIsCustomerDeactivationValidAll>(_IsCustomerDeactivationValidAll);
			
			return iIsCustomerDeactivationValidAllExt;
		}
	}
}
