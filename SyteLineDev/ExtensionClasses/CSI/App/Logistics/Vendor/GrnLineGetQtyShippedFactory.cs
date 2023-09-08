//PROJECT NAME: CSIVendor
//CLASS NAME: GrnLineGetQtyShippedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GrnLineGetQtyShippedFactory
	{
		public IGrnLineGetQtyShipped Create(IApplicationDB appDB)
		{
			var _GrnLineGetQtyShipped = new Logistics.Vendor.GrnLineGetQtyShipped(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGrnLineGetQtyShippedExt = timerfactory.Create<Logistics.Vendor.IGrnLineGetQtyShipped>(_GrnLineGetQtyShipped);
			
			return iGrnLineGetQtyShippedExt;
		}
	}
}
