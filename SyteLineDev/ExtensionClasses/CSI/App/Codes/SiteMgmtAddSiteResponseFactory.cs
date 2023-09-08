//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtAddSiteResponseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteMgmtAddSiteResponseFactory
	{
		public ISiteMgmtAddSiteResponse Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteMgmtAddSiteResponse = new Codes.SiteMgmtAddSiteResponse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteMgmtAddSiteResponseExt = timerfactory.Create<Codes.ISiteMgmtAddSiteResponse>(_SiteMgmtAddSiteResponse);
			
			return iSiteMgmtAddSiteResponseExt;
		}
	}
}
