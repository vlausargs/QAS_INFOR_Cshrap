//PROJECT NAME: Production
//CLASS NAME: JobRouteGetPermFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRouteGetPermFactory
	{
		public IJobRouteGetPerm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRouteGetPerm = new Production.JobRouteGetPerm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRouteGetPermExt = timerfactory.Create<Production.IJobRouteGetPerm>(_JobRouteGetPerm);
			
			return iJobRouteGetPermExt;
		}
	}
}
