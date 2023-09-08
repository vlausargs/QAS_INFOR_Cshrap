//PROJECT NAME: CSICustomer
//CLASS NAME: OrderInvCrMemoPredisplayFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class OrderInvCrMemoPredisplayFactory
	{
		public IOrderInvCrMemoPredisplay Create(IApplicationDB appDB)
		{
			var _OrderInvCrMemoPredisplay = new Logistics.Customer.OrderInvCrMemoPredisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOrderInvCrMemoPredisplayExt = timerfactory.Create<Logistics.Customer.IOrderInvCrMemoPredisplay>(_OrderInvCrMemoPredisplay);
			
			return iOrderInvCrMemoPredisplayExt;
		}
	}
}
