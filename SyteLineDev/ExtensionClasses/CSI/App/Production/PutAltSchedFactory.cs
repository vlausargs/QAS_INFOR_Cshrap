//PROJECT NAME: Production
//CLASS NAME: PutAltSchedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PutAltSchedFactory
	{
		public IPutAltSched Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PutAltSched = new Production.PutAltSched(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPutAltSchedExt = timerfactory.Create<Production.IPutAltSched>(_PutAltSched);
			
			return iPutAltSchedExt;
		}
	}
}
