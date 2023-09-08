//PROJECT NAME: Logistics
//CLASS NAME: VendLcrRebalanceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendLcrRebalanceFactory
	{
		public IVendLcrRebalance Create(IApplicationDB appDB)
		{
			var _VendLcrRebalance = new Logistics.Vendor.VendLcrRebalance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendLcrRebalanceExt = timerfactory.Create<Logistics.Vendor.IVendLcrRebalance>(_VendLcrRebalance);
			
			return iVendLcrRebalanceExt;
		}
	}
}
