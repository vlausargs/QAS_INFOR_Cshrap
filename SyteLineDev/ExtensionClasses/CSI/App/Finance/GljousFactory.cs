//PROJECT NAME: Finance
//CLASS NAME: GljousFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GljousFactory
	{
		public IGljous Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Gljous = new Finance.Gljous(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGljousExt = timerfactory.Create<Finance.IGljous>(_Gljous);
			
			return iGljousExt;
		}
	}
}
