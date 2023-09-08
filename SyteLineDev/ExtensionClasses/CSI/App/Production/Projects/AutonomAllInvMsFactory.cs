//PROJECT NAME: CSIProjects
//CLASS NAME: AutonomAllInvMsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class AutonomAllInvMsFactory
	{
		public IAutonomAllInvMs Create(IApplicationDB appDB)
		{
			var _AutonomAllInvMs = new Projects.AutonomAllInvMs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutonomAllInvMsExt = timerfactory.Create<Projects.IAutonomAllInvMs>(_AutonomAllInvMs);
			
			return iAutonomAllInvMsExt;
		}
	}
}
