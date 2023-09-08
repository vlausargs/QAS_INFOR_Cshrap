//PROJECT NAME: Production
//CLASS NAME: JobOrdersCopyJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOrdersCopyJobFactory
	{
		public IJobOrdersCopyJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOrdersCopyJob = new Production.JobOrdersCopyJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrdersCopyJobExt = timerfactory.Create<Production.IJobOrdersCopyJob>(_JobOrdersCopyJob);
			
			return iJobOrdersCopyJobExt;
		}
	}
}
