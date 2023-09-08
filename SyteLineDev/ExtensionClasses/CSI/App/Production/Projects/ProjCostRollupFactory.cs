//PROJECT NAME: Production
//CLASS NAME: ProjCostRollupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjCostRollupFactory
	{
		public IProjCostRollup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjCostRollup = new Production.Projects.ProjCostRollup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjCostRollupExt = timerfactory.Create<Production.Projects.IProjCostRollup>(_ProjCostRollup);
			
			return iProjCostRollupExt;
		}
	}
}
