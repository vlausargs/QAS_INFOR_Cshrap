//PROJECT NAME: CSIAdmin
//CLASS NAME: MonitoredResource_NotifySubscribersFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class MonitoredResource_NotifySubscribersFactory
	{
		public IMonitoredResource_NotifySubscribers Create(IApplicationDB appDB)
		{
			var _MonitoredResource_NotifySubscribers = new Admin.MonitoredResource_NotifySubscribers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMonitoredResource_NotifySubscribersExt = timerfactory.Create<Admin.IMonitoredResource_NotifySubscribers>(_MonitoredResource_NotifySubscribers);
			
			return iMonitoredResource_NotifySubscribersExt;
		}
	}
}
