//PROJECT NAME: Logistics
//CLASS NAME: ShipmentSplittingFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipmentSplittingFactory
	{
		public IShipmentSplitting Create(IApplicationDB appDB)
		{
			var _ShipmentSplitting = new Logistics.Customer.ShipmentSplitting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipmentSplittingExt = timerfactory.Create<Logistics.Customer.IShipmentSplitting>(_ShipmentSplitting);
			
			return iShipmentSplittingExt;
		}
	}
}
