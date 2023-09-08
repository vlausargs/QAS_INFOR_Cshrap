//PROJECT NAME: CSIVendor
//CLASS NAME: POLineRelWarehouseChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POLineRelWarehouseChangeFactory
	{
		public IPOLineRelWarehouseChange Create(IApplicationDB appDB)
		{
			var _POLineRelWarehouseChange = new Logistics.Vendor.POLineRelWarehouseChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOLineRelWarehouseChangeExt = timerfactory.Create<Logistics.Vendor.IPOLineRelWarehouseChange>(_POLineRelWarehouseChange);
			
			return iPOLineRelWarehouseChangeExt;
		}
	}
}
