//PROJECT NAME: Finance
//CLASS NAME: GlPost4Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GlPost4Factory
	{
		public IGlPost4 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GlPost4 = new Finance.GlPost4(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlPost4Ext = timerfactory.Create<Finance.IGlPost4>(_GlPost4);
			
			return iGlPost4Ext;
		}
	}
}
