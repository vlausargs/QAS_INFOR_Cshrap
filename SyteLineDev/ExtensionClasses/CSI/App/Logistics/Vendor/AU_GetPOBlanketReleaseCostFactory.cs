//PROJECT NAME: CSIVendor
//CLASS NAME: AU_GetPOBlanketReleaseCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_GetPOBlanketReleaseCostFactory
	{
		public IAU_GetPOBlanketReleaseCost Create(IApplicationDB appDB)
		{
			var _AU_GetPOBlanketReleaseCost = new Logistics.Vendor.AU_GetPOBlanketReleaseCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_GetPOBlanketReleaseCostExt = timerfactory.Create<Logistics.Vendor.IAU_GetPOBlanketReleaseCost>(_AU_GetPOBlanketReleaseCost);
			
			return iAU_GetPOBlanketReleaseCostExt;
		}
	}
}
