//PROJECT NAME: Finance
//CLASS NAME: GlCmprPDoProcessBkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlCmprPDoProcessBkFactory
	{
		public IGlCmprPDoProcessBk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlCmprPDoProcessBk = new Finance.GlCmprPDoProcessBk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlCmprPDoProcessBkExt = timerfactory.Create<Finance.IGlCmprPDoProcessBk>(_GlCmprPDoProcessBk);
			
			return iGlCmprPDoProcessBkExt;
		}
	}
}
