//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtNotifyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteMgmtNotifyFactory
	{
		public ISiteMgmtNotify Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteMgmtNotify = new Codes.SiteMgmtNotify(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteMgmtNotifyExt = timerfactory.Create<Codes.ISiteMgmtNotify>(_SiteMgmtNotify);
			
			return iSiteMgmtNotifyExt;
		}
	}
}
