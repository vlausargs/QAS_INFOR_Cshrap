//PROJECT NAME: CSIAdmin
//CLASS NAME: GetPortalAdminStatsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class GetPortalAdminStatsFactory
	{
		public IGetPortalAdminStats Create(IApplicationDB appDB)
		{
			var _GetPortalAdminStats = new Admin.GetPortalAdminStats(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPortalAdminStatsExt = timerfactory.Create<Admin.IGetPortalAdminStats>(_GetPortalAdminStats);
			
			return iGetPortalAdminStatsExt;
		}
	}
}
