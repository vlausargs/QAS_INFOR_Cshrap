//PROJECT NAME: CSIProjects
//CLASS NAME: GetPlanningModeFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetPlanningModeFactory
	{
		public IGetPlanningMode Create(IApplicationDB appDB)
		{
			var _GetPlanningMode = new Production.Projects.GetPlanningMode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPlanningModeExt = timerfactory.Create<Production.Projects.IGetPlanningMode>(_GetPlanningMode);
			
			return iGetPlanningModeExt;
		}
	}
}
