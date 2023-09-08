//PROJECT NAME: CSIAdmin
//CLASS NAME: MonitoredResources_SubscribeAlertFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class MonitoredResources_SubscribeAlertFactory
	{
		public IMonitoredResources_SubscribeAlert Create(IApplicationDB appDB)
		{
			var _MonitoredResources_SubscribeAlert = new Admin.MonitoredResources_SubscribeAlert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMonitoredResources_SubscribeAlertExt = timerfactory.Create<Admin.IMonitoredResources_SubscribeAlert>(_MonitoredResources_SubscribeAlert);
			
			return iMonitoredResources_SubscribeAlertExt;
		}
	}
}
