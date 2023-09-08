//PROJECT NAME: Production
//CLASS NAME: Pojob3PPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PPreFactory
	{
		public IPojob3PPre Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3PPre = new Production.Pojob3PPre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PPreExt = timerfactory.Create<Production.IPojob3PPre>(_Pojob3PPre);
			
			return iPojob3PPreExt;
		}
	}
}
