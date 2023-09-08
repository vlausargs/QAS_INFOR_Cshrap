//PROJECT NAME: Production
//CLASS NAME: JobCopyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobCopyFactory
	{
		public IJobCopy Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobCopy = new Production.JobCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobCopyExt = timerfactory.Create<Production.IJobCopy>(_JobCopy);
			
			return iJobCopyExt;
		}
	}
}
