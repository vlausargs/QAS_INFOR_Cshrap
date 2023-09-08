//PROJECT NAME: Logistics
//CLASS NAME: ShipmentPackageUnMergeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipmentPackageUnMergeFactory
	{
		public IShipmentPackageUnMerge Create(IApplicationDB appDB)
		{
			var _ShipmentPackageUnMerge = new Logistics.Customer.ShipmentPackageUnMerge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipmentPackageUnMergeExt = timerfactory.Create<Logistics.Customer.IShipmentPackageUnMerge>(_ShipmentPackageUnMerge);
			
			return iShipmentPackageUnMergeExt;
		}
	}
}
