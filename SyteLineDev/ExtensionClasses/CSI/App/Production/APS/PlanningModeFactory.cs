//PROJECT NAME: Production
//CLASS NAME: PlanningModeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class PlanningModeFactory
	{
		public IPlanningMode Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PlanningMode = new Production.APS.PlanningMode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningModeExt = timerfactory.Create<Production.APS.IPlanningMode>(_PlanningMode);
			
			return iPlanningModeExt;
		}
	}
}
