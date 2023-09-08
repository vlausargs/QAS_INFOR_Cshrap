//PROJECT NAME: CSICustomer
//CLASS NAME: DelShipmentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DelShipmentFactory
	{
		public IDelShipment Create(IApplicationDB appDB)
		{
			var _DelShipment = new Logistics.Customer.DelShipment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelShipmentExt = timerfactory.Create<Logistics.Customer.IDelShipment>(_DelShipment);
			
			return iDelShipmentExt;
		}
	}
}
