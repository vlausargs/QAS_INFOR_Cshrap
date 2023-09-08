//PROJECT NAME: CSIVendor
//CLASS NAME: PurchaseOrdResetAccumTotalsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PurchaseOrdResetAccumTotalsFactory
	{
		public IPurchaseOrdResetAccumTotals Create(IApplicationDB appDB)
		{
			var _PurchaseOrdResetAccumTotals = new Logistics.Vendor.PurchaseOrdResetAccumTotals(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurchaseOrdResetAccumTotalsExt = timerfactory.Create<Logistics.Vendor.IPurchaseOrdResetAccumTotals>(_PurchaseOrdResetAccumTotals);
			
			return iPurchaseOrdResetAccumTotalsExt;
		}
	}
}
