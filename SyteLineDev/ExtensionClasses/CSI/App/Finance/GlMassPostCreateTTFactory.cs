//PROJECT NAME: Finance
//CLASS NAME: GlMassPostCreateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlMassPostCreateTTFactory
	{
		public IGlMassPostCreateTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlMassPostCreateTT = new Finance.GlMassPostCreateTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlMassPostCreateTTExt = timerfactory.Create<Finance.IGlMassPostCreateTT>(_GlMassPostCreateTT);
			
			return iGlMassPostCreateTTExt;
		}
	}
}
