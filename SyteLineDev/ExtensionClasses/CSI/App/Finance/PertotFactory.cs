//PROJECT NAME: Finance
//CLASS NAME: PertotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PertotFactory
	{
		public IPertot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pertot = new Finance.Pertot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPertotExt = timerfactory.Create<Finance.IPertot>(_Pertot);
			
			return iPertotExt;
		}
	}
}
