//PROJECT NAME: Admin
//CLASS NAME: ApplicationDebugLogFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class ApplicationDebugLogFactory
	{
		public IApplicationDebugLog Create(IApplicationDB appDB)
		{
			var _ApplicationDebugLog = new Admin.ApplicationDebugLog(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApplicationDebugLogExt = timerfactory.Create<Admin.IApplicationDebugLog>(_ApplicationDebugLog);
			
			return iApplicationDebugLogExt;
		}
	}
}
