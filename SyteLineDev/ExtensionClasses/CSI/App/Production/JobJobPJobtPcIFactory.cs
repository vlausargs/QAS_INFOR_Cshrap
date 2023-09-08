//PROJECT NAME: Production
//CLASS NAME: JobJobPJobtPcIFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobJobPJobtPcIFactory
	{
		public IJobJobPJobtPcI Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobJobPJobtPcI = new Production.JobJobPJobtPcI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobJobPJobtPcIExt = timerfactory.Create<Production.IJobJobPJobtPcI>(_JobJobPJobtPcI);
			
			return iJobJobPJobtPcIExt;
		}
	}
}
