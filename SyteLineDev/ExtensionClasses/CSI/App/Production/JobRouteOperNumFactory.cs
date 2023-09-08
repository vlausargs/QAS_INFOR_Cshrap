//PROJECT NAME: Production
//CLASS NAME: JobRouteOperNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRouteOperNumFactory
	{
		public IJobRouteOperNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRouteOperNum = new Production.JobRouteOperNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRouteOperNumExt = timerfactory.Create<Production.IJobRouteOperNum>(_JobRouteOperNum);
			
			return iJobRouteOperNumExt;
		}
	}
}
