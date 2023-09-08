//PROJECT NAME: CSIAdmin
//CLASS NAME: BI_LoadLinkSiteFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class BI_LoadLinkSiteFactory
	{
		public IBI_LoadLinkSite Create(IApplicationDB appDB)
		{
			var _BI_LoadLinkSite = new Admin.BI_LoadLinkSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBI_LoadLinkSiteExt = timerfactory.Create<Admin.IBI_LoadLinkSite>(_BI_LoadLinkSite);
			
			return iBI_LoadLinkSiteExt;
		}
	}
}
