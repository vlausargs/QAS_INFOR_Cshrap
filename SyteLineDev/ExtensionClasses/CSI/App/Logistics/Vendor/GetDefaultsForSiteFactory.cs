//PROJECT NAME: CSIVendor
//CLASS NAME: GetDefaultsForSiteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDefaultsForSiteFactory
	{
		public IGetDefaultsForSite Create(IApplicationDB appDB)
		{
			var _GetDefaultsForSite = new Logistics.Vendor.GetDefaultsForSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDefaultsForSiteExt = timerfactory.Create<Logistics.Vendor.IGetDefaultsForSite>(_GetDefaultsForSite);
			
			return iGetDefaultsForSiteExt;
		}
	}
}
