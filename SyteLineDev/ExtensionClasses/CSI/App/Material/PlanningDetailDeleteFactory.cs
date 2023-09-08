//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDetailDeleteFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PlanningDetailDeleteFactory
	{
		public IPlanningDetailDelete Create(IApplicationDB appDB)
		{
			var _PlanningDetailDelete = new Material.PlanningDetailDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningDetailDeleteExt = timerfactory.Create<Material.IPlanningDetailDelete>(_PlanningDetailDelete);
			
			return iPlanningDetailDeleteExt;
		}
	}
}
