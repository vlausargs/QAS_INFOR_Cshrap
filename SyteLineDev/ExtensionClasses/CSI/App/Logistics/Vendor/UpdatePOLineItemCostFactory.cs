//PROJECT NAME: CSIVendor
//CLASS NAME: UpdatePOLineItemCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdatePOLineItemCostFactory
	{
		public IUpdatePOLineItemCost Create(IApplicationDB appDB)
		{
			var _UpdatePOLineItemCost = new Logistics.Vendor.UpdatePOLineItemCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePOLineItemCostExt = timerfactory.Create<Logistics.Vendor.IUpdatePOLineItemCost>(_UpdatePOLineItemCost);
			
			return iUpdatePOLineItemCostExt;
		}
	}
}
