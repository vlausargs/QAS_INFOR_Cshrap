//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingConvertCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceivingConvertCostFactory
	{
		public IPOReceivingConvertCost Create(IApplicationDB appDB)
		{
			var _POReceivingConvertCost = new Logistics.Vendor.POReceivingConvertCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivingConvertCostExt = timerfactory.Create<Logistics.Vendor.IPOReceivingConvertCost>(_POReceivingConvertCost);
			
			return iPOReceivingConvertCostExt;
		}
	}
}
