//PROJECT NAME: CSIVendor
//CLASS NAME: POHeaderWarehouseChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POHeaderWarehouseChangeFactory
	{
		public IPOHeaderWarehouseChange Create(IApplicationDB appDB)
		{
			var _POHeaderWarehouseChange = new Logistics.Vendor.POHeaderWarehouseChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOHeaderWarehouseChangeExt = timerfactory.Create<Logistics.Vendor.IPOHeaderWarehouseChange>(_POHeaderWarehouseChange);
			
			return iPOHeaderWarehouseChangeExt;
		}
	}
}
