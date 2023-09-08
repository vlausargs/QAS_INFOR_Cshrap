//PROJECT NAME: Admin
//CLASS NAME: SLServerRestartFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SLServerRestartFactory
	{
		public ISLServerRestart Create(IApplicationDB appDB)
		{
			var _SLServerRestart = new Admin.SLServerRestart(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSLServerRestartExt = timerfactory.Create<Admin.ISLServerRestart>(_SLServerRestart);
			
			return iSLServerRestartExt;
		}
	}
}
