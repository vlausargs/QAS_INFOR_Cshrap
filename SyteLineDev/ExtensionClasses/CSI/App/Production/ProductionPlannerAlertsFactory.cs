//PROJECT NAME: Production
//CLASS NAME: ProductionPlannerAlertsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ProductionPlannerAlertsFactory
	{
		public IProductionPlannerAlerts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProductionPlannerAlerts = new Production.ProductionPlannerAlerts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProductionPlannerAlertsExt = timerfactory.Create<Production.IProductionPlannerAlerts>(_ProductionPlannerAlerts);
			
			return iProductionPlannerAlertsExt;
		}
	}
}
