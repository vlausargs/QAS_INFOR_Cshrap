//PROJECT NAME: Production
//CLASS NAME: Cal000BldHldyMcalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Cal000BldHldyMcalFactory
	{
		public ICal000BldHldyMcal Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Cal000BldHldyMcal = new Production.Cal000BldHldyMcal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCal000BldHldyMcalExt = timerfactory.Create<Production.ICal000BldHldyMcal>(_Cal000BldHldyMcal);
			
			return iCal000BldHldyMcalExt;
		}
	}
}
