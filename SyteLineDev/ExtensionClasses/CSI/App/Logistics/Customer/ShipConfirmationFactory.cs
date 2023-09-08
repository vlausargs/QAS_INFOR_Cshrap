//PROJECT NAME: Logistics
//CLASS NAME: ShipConfirmationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipConfirmationFactory
	{
		public IShipConfirmation Create(IApplicationDB appDB)
		{
			var _ShipConfirmation = new Logistics.Customer.ShipConfirmation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipConfirmationExt = timerfactory.Create<Logistics.Customer.IShipConfirmation>(_ShipConfirmation);
			
			return iShipConfirmationExt;
		}
	}
}
