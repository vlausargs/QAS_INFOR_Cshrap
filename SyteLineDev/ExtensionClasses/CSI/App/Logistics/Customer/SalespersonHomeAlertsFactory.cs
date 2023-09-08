//PROJECT NAME: Logistics
//CLASS NAME: SalespersonHomeAlertsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SalespersonHomeAlertsFactory
	{
		public ISalespersonHomeAlerts Create(IApplicationDB appDB)
		{
			var _SalespersonHomeAlerts = new Logistics.Customer.SalespersonHomeAlerts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSalespersonHomeAlertsExt = timerfactory.Create<Logistics.Customer.ISalespersonHomeAlerts>(_SalespersonHomeAlerts);
			
			return iSalespersonHomeAlertsExt;
		}
	}
}
