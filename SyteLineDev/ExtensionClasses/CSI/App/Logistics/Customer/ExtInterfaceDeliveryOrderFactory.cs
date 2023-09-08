//PROJECT NAME: CSICustomer
//CLASS NAME: ExtInterfaceDeliveryOrderFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ExtInterfaceDeliveryOrderFactory
	{
		public IExtInterfaceDeliveryOrder Create(IApplicationDB appDB)
		{
			var _ExtInterfaceDeliveryOrder = new Logistics.Customer.ExtInterfaceDeliveryOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtInterfaceDeliveryOrderExt = timerfactory.Create<Logistics.Customer.IExtInterfaceDeliveryOrder>(_ExtInterfaceDeliveryOrder);
			
			return iExtInterfaceDeliveryOrderExt;
		}
	}
}
