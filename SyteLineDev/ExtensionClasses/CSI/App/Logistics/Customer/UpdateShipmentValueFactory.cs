//PROJECT NAME: Logistics
//CLASS NAME: UpdateShipmentValueFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateShipmentValueFactory
	{
		public IUpdateShipmentValue Create(IApplicationDB appDB)
		{
			var _UpdateShipmentValue = new Logistics.Customer.UpdateShipmentValue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateShipmentValueExt = timerfactory.Create<Logistics.Customer.IUpdateShipmentValue>(_UpdateShipmentValue);
			
			return iUpdateShipmentValueExt;
		}
	}
}
