//PROJECT NAME: Production
//CLASS NAME: MO_ValAlternateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class MO_ValAlternateFactory
	{
		public IMO_ValAlternate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_ValAlternate = new Production.MO_ValAlternate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ValAlternateExt = timerfactory.Create<Production.IMO_ValAlternate>(_MO_ValAlternate);
			
			return iMO_ValAlternateExt;
		}
	}
}
