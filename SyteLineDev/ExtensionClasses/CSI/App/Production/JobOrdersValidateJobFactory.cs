//PROJECT NAME: Production
//CLASS NAME: JobOrdersValidateJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOrdersValidateJobFactory
	{
		public IJobOrdersValidateJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOrdersValidateJob = new Production.JobOrdersValidateJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrdersValidateJobExt = timerfactory.Create<Production.IJobOrdersValidateJob>(_JobOrdersValidateJob);
			
			return iJobOrdersValidateJobExt;
		}
	}
}
