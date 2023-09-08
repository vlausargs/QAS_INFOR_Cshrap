//PROJECT NAME: Finance
//CLASS NAME: GlCmprPDoProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlCmprPDoProcessFactory
	{
		public IGlCmprPDoProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlCmprPDoProcess = new Finance.GlCmprPDoProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlCmprPDoProcessExt = timerfactory.Create<Finance.IGlCmprPDoProcess>(_GlCmprPDoProcess);
			
			return iGlCmprPDoProcessExt;
		}
	}
}
