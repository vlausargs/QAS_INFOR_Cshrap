//PROJECT NAME: CSICustomer
//CLASS NAME: OrderCreditHoldFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class OrderCreditHoldFactory
	{
		public IOrderCreditHold Create(IApplicationDB appDB)
		{
			var _OrderCreditHold = new Logistics.Customer.OrderCreditHold(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOrderCreditHoldExt = timerfactory.Create<Logistics.Customer.IOrderCreditHold>(_OrderCreditHold);
			
			return iOrderCreditHoldExt;
		}
	}
}
