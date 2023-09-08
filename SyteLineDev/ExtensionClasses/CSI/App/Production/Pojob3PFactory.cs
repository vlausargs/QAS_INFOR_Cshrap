//PROJECT NAME: Production
//CLASS NAME: Pojob3PFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Pojob3PFactory
	{
		public IPojob3P Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pojob3P = new Production.Pojob3P(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPojob3PExt = timerfactory.Create<Production.IPojob3P>(_Pojob3P);
			
			return iPojob3PExt;
		}
	}
}
