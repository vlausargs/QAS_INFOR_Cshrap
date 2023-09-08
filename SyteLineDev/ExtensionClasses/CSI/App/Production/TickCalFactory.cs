//PROJECT NAME: Production
//CLASS NAME: TickCalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class TickCalFactory
	{
		public ITickCal Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TickCal = new Production.TickCal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTickCalExt = timerfactory.Create<Production.ITickCal>(_TickCal);
			
			return iTickCalExt;
		}
	}
}
