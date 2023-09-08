//PROJECT NAME: Logistics
//CLASS NAME: CustomerInsUpdRemCallFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerInsUpdRemCallFactory
	{
		public ICustomerInsUpdRemCall Create(IApplicationDB appDB)
		{
			var _CustomerInsUpdRemCall = new Logistics.Customer.CustomerInsUpdRemCall(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerInsUpdRemCallExt = timerfactory.Create<Logistics.Customer.ICustomerInsUpdRemCall>(_CustomerInsUpdRemCall);
			
			return iCustomerInsUpdRemCallExt;
		}
	}
}
