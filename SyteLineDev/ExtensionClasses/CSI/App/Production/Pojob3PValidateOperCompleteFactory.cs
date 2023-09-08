//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateOperCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PValidateOperCompleteFactory
	{
		public IPojob3PValidateOperComplete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3PValidateOperComplete = new Production.Pojob3PValidateOperComplete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PValidateOperCompleteExt = timerfactory.Create<Production.IPojob3PValidateOperComplete>(_Pojob3PValidateOperComplete);
			
			return iPojob3PValidateOperCompleteExt;
		}
	}
}
