//PROJECT NAME: Logistics
//CLASS NAME: ShipmentMergeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipmentMergeFactory
	{
		public IShipmentMerge Create(IApplicationDB appDB)
		{
			var _ShipmentMerge = new Logistics.Customer.ShipmentMerge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipmentMergeExt = timerfactory.Create<Logistics.Customer.IShipmentMerge>(_ShipmentMerge);
			
			return iShipmentMergeExt;
		}
	}
}
