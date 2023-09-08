//PROJECT NAME: CSIProjects
//CLASS NAME: NextProjTaskFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class NextProjTaskFactory
	{
		public INextProjTask Create(IApplicationDB appDB)
		{
			var _NextProjTask = new Production.Projects.NextProjTask(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextProjTaskExt = timerfactory.Create<Production.Projects.INextProjTask>(_NextProjTask);
			
			return iNextProjTaskExt;
		}
	}
}
