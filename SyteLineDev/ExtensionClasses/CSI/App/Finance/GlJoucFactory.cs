//PROJECT NAME: Finance
//CLASS NAME: GlJoucFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlJoucFactory
	{
		public IGlJouc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlJouc = new Finance.GlJouc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlJoucExt = timerfactory.Create<Finance.IGlJouc>(_GlJouc);
			
			return iGlJoucExt;
		}
	}
}
