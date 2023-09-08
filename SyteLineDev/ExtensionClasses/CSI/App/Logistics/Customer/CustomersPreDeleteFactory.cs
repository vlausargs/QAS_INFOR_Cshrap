//PROJECT NAME: CSICustomer
//CLASS NAME: CustomersPreDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomersPreDeleteFactory
	{
		public ICustomersPreDelete Create(IApplicationDB appDB)
		{
			var _CustomersPreDelete = new Logistics.Customer.CustomersPreDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomersPreDeleteExt = timerfactory.Create<Logistics.Customer.ICustomersPreDelete>(_CustomersPreDelete);
			
			return iCustomersPreDeleteExt;
		}
	}
}
