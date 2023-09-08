//PROJECT NAME: Production
//CLASS NAME: JobRouteDeleteResourceGrpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRouteDeleteResourceGrpFactory
	{
		public IJobRouteDeleteResourceGrp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRouteDeleteResourceGrp = new Production.JobRouteDeleteResourceGrp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRouteDeleteResourceGrpExt = timerfactory.Create<Production.IJobRouteDeleteResourceGrp>(_JobRouteDeleteResourceGrp);
			
			return iJobRouteDeleteResourceGrpExt;
		}
	}
}
