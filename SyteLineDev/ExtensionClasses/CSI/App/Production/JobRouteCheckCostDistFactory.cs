//PROJECT NAME: Production
//CLASS NAME: JobRouteCheckCostDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRouteCheckCostDistFactory
	{
		public IJobRouteCheckCostDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRouteCheckCostDist = new Production.JobRouteCheckCostDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRouteCheckCostDistExt = timerfactory.Create<Production.IJobRouteCheckCostDist>(_JobRouteCheckCostDist);
			
			return iJobRouteCheckCostDistExt;
		}
	}
}
