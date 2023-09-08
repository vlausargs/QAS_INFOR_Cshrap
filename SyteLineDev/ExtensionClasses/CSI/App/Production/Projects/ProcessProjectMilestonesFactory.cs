//PROJECT NAME: CSIProjects
//CLASS NAME: ProcessProjectMilestonesFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProcessProjectMilestonesFactory
	{
		public IProcessProjectMilestones Create(IApplicationDB appDB)
		{
			var _ProcessProjectMilestones = new Production.Projects.ProcessProjectMilestones(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessProjectMilestonesExt = timerfactory.Create<Production.Projects.IProcessProjectMilestones>(_ProcessProjectMilestones);
			
			return iProcessProjectMilestonesExt;
		}
	}
}
