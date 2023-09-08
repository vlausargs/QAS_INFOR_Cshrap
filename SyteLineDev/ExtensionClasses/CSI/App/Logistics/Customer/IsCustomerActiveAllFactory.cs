//PROJECT NAME: CSICustomer
//CLASS NAME: IsCustomerActiveAllFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCustomerActiveAllFactory
	{
		public IIsCustomerActiveAll Create(IApplicationDB appDB)
		{
			var _IsCustomerActiveAll = new Logistics.Customer.IsCustomerActiveAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCustomerActiveAllExt = timerfactory.Create<Logistics.Customer.IIsCustomerActiveAll>(_IsCustomerActiveAll);
			
			return iIsCustomerActiveAllExt;
		}
	}
}
