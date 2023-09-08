//PROJECT NAME: Production
//CLASS NAME: MO_ValAlternateAskFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class MO_ValAlternateAskFactory
	{
		public IMO_ValAlternateAsk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_ValAlternateAsk = new Production.MO_ValAlternateAsk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ValAlternateAskExt = timerfactory.Create<Production.IMO_ValAlternateAsk>(_MO_ValAlternateAsk);
			
			return iMO_ValAlternateAskExt;
		}
	}
}
