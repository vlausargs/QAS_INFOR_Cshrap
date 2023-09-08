//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateCloseJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PValidateCloseJobFactory
	{
		public IPojob3PValidateCloseJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3PValidateCloseJob = new Production.Pojob3PValidateCloseJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PValidateCloseJobExt = timerfactory.Create<Production.IPojob3PValidateCloseJob>(_Pojob3PValidateCloseJob);
			
			return iPojob3PValidateCloseJobExt;
		}
	}
}
