//PROJECT NAME: CSICustomer
//CLASS NAME: ExpireEarnedRebateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ExpireEarnedRebateFactory
	{
		public IExpireEarnedRebate Create(IApplicationDB appDB)
		{
			var _ExpireEarnedRebate = new Logistics.Customer.ExpireEarnedRebate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExpireEarnedRebateExt = timerfactory.Create<Logistics.Customer.IExpireEarnedRebate>(_ExpireEarnedRebate);
			
			return iExpireEarnedRebateExt;
		}
	}
}
