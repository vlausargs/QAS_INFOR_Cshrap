//PROJECT NAME: Production
//CLASS NAME: ApsCtpPlanOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsCtpPlanOrderFactory
	{
		public IApsCtpPlanOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsCtpPlanOrder = new Production.APS.ApsCtpPlanOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsCtpPlanOrderExt = timerfactory.Create<Production.APS.IApsCtpPlanOrder>(_ApsCtpPlanOrder);
			
			return iApsCtpPlanOrderExt;
		}
	}
}
