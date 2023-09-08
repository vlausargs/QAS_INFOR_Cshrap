//PROJECT NAME: Logistics
//CLASS NAME: UnshipShipmentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnshipShipmentFactory
	{
		public IUnshipShipment Create(IApplicationDB appDB)
		{
			var _UnshipShipment = new Logistics.Customer.UnshipShipment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnshipShipmentExt = timerfactory.Create<Logistics.Customer.IUnshipShipment>(_UnshipShipment);
			
			return iUnshipShipmentExt;
		}
	}
}
