//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtAddSiteCleanupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteMgmtAddSiteCleanupFactory
	{
		public ISiteMgmtAddSiteCleanup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteMgmtAddSiteCleanup = new Codes.SiteMgmtAddSiteCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteMgmtAddSiteCleanupExt = timerfactory.Create<Codes.ISiteMgmtAddSiteCleanup>(_SiteMgmtAddSiteCleanup);
			
			return iSiteMgmtAddSiteCleanupExt;
		}
	}
}
