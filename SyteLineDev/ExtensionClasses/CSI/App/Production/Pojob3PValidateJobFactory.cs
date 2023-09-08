//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PValidateJobFactory
	{
		public IPojob3PValidateJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3PValidateJob = new Production.Pojob3PValidateJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PValidateJobExt = timerfactory.Create<Production.IPojob3PValidateJob>(_Pojob3PValidateJob);
			
			return iPojob3PValidateJobExt;
		}
	}
}
