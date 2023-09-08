//PROJECT NAME: Logistics
//CLASS NAME: SalesPersonFromUsernameFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SalesPersonFromUsernameFactory
	{
		public ISalesPersonFromUsername Create(IApplicationDB appDB)
		{
			var _SalesPersonFromUsername = new Logistics.Customer.SalesPersonFromUsername(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSalesPersonFromUsernameExt = timerfactory.Create<Logistics.Customer.ISalesPersonFromUsername>(_SalesPersonFromUsername);
			
			return iSalesPersonFromUsernameExt;
		}
	}
}
