//PROJECT NAME: Finance
//CLASS NAME: GlPostDeleteTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlPostDeleteTTFactory
	{
		public IGlPostDeleteTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlPostDeleteTT = new Finance.GlPostDeleteTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlPostDeleteTTExt = timerfactory.Create<Finance.IGlPostDeleteTT>(_GlPostDeleteTT);
			
			return iGlPostDeleteTTExt;
		}
	}
}
