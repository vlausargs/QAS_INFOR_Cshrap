//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateJobWrapperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PValidateJobWrapperFactory
	{
		public IPojob3PValidateJobWrapper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3PValidateJobWrapper = new Production.Pojob3PValidateJobWrapper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PValidateJobWrapperExt = timerfactory.Create<Production.IPojob3PValidateJobWrapper>(_Pojob3PValidateJobWrapper);
			
			return iPojob3PValidateJobWrapperExt;
		}
	}
}
