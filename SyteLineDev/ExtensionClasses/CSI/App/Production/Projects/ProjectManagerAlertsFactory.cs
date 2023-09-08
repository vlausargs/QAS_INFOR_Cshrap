//PROJECT NAME: CSIProjects
//CLASS NAME: ProjectManagerAlertsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjectManagerAlertsFactory
	{
		public IProjectManagerAlerts Create(IApplicationDB appDB)
		{
			var _ProjectManagerAlerts = new Production.Projects.ProjectManagerAlerts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjectManagerAlertsExt = timerfactory.Create<Production.Projects.IProjectManagerAlerts>(_ProjectManagerAlerts);
			
			return iProjectManagerAlertsExt;
		}
	}
}
