//PROJECT NAME: Admin
//CLASS NAME: BI_SaveBILinkSitesFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class BI_SaveBILinkSitesFactory
	{
		public IBI_SaveBILinkSites Create(IApplicationDB appDB)
		{
			var _BI_SaveBILinkSites = new Admin.BI_SaveBILinkSites(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBI_SaveBILinkSitesExt = timerfactory.Create<Admin.IBI_SaveBILinkSites>(_BI_SaveBILinkSites);
			
			return iBI_SaveBILinkSitesExt;
		}
	}
}
