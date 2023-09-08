//PROJECT NAME: Production
//CLASS NAME: JobtMatLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtMatLogErrorFactory
	{
		public IJobtMatLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtMatLogError = new Production.JobtMatLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtMatLogErrorExt = timerfactory.Create<Production.IJobtMatLogError>(_JobtMatLogError);
			
			return iJobtMatLogErrorExt;
		}
	}
}
