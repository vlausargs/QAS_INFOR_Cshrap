//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtProcessActionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteMgmtProcessActionFactory
	{
		public ISiteMgmtProcessAction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteMgmtProcessAction = new Codes.SiteMgmtProcessAction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteMgmtProcessActionExt = timerfactory.Create<Codes.ISiteMgmtProcessAction>(_SiteMgmtProcessAction);
			
			return iSiteMgmtProcessActionExt;
		}
	}
}
