//PROJECT NAME: Logistics
//CLASS NAME: LoadESBCustomerContactFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LoadESBCustomerContactFactory
	{
		public ILoadESBCustomerContact Create(IApplicationDB appDB)
		{
			var _LoadESBCustomerContact = new Logistics.Customer.LoadESBCustomerContact(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCustomerContactExt = timerfactory.Create<Logistics.Customer.ILoadESBCustomerContact>(_LoadESBCustomerContact);
			
			return iLoadESBCustomerContactExt;
		}
	}
}
