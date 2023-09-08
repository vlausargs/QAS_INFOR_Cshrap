//PROJECT NAME: CSIMaterial
//CLASS NAME: DisableEnableTaxFreeMatlForMultiSiteFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class DisableEnableTaxFreeMatlForMultiSiteFactory
	{
		public IDisableEnableTaxFreeMatlForMultiSite Create(IApplicationDB appDB)
		{
			var _DisableEnableTaxFreeMatlForMultiSite = new Material.DisableEnableTaxFreeMatlForMultiSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDisableEnableTaxFreeMatlForMultiSiteExt = timerfactory.Create<Material.IDisableEnableTaxFreeMatlForMultiSite>(_DisableEnableTaxFreeMatlForMultiSite);
			
			return iDisableEnableTaxFreeMatlForMultiSiteExt;
		}
	}
}
