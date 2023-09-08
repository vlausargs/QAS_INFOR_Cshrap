//PROJECT NAME: Logistics
//CLASS NAME: PurgeTmpCoShipFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeTmpCoShipFactory
	{
		public IPurgeTmpCoShip Create(IApplicationDB appDB)
		{
			var _PurgeTmpCoShip = new Logistics.Customer.PurgeTmpCoShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeTmpCoShipExt = timerfactory.Create<Logistics.Customer.IPurgeTmpCoShip>(_PurgeTmpCoShip);
			
			return iPurgeTmpCoShipExt;
		}
	}
}
