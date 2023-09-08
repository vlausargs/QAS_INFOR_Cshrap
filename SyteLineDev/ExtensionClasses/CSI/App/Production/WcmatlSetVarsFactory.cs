//PROJECT NAME: Production
//CLASS NAME: WcmatlSetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class WcmatlSetVarsFactory
	{
		public IWcmatlSetVars Create(IApplicationDB appDB)
		{
			var _WcmatlSetVars = new Production.WcmatlSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWcmatlSetVarsExt = timerfactory.Create<Production.IWcmatlSetVars>(_WcmatlSetVars);
			
			return iWcmatlSetVarsExt;
		}
	}
}
