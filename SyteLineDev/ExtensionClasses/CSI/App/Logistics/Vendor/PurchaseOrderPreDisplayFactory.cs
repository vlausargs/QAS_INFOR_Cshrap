//PROJECT NAME: CSIVendor
//CLASS NAME: PurchaseOrderPreDisplayFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PurchaseOrderPreDisplayFactory
	{
		public IPurchaseOrderPreDisplay Create(IApplicationDB appDB)
		{
			var _PurchaseOrderPreDisplay = new Logistics.Vendor.PurchaseOrderPreDisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurchaseOrderPreDisplayExt = timerfactory.Create<Logistics.Vendor.IPurchaseOrderPreDisplay>(_PurchaseOrderPreDisplay);
			
			return iPurchaseOrderPreDisplayExt;
		}
	}
}
