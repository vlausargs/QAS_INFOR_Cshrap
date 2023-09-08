//PROJECT NAME: Production
//CLASS NAME: ProjPmatlXFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjPmatlXFactory
	{
		public IProjPmatlX Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjPmatlX = new Production.Projects.ProjPmatlX(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjPmatlXExt = timerfactory.Create<Production.Projects.IProjPmatlX>(_ProjPmatlX);
			
			return iProjPmatlXExt;
		}
	}
}
