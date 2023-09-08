//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPlanningScheduleLinesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPlanningScheduleLinesFactory
	{
		public ILoadESBPlanningScheduleLines Create(IApplicationDB appDB)
		{
			var _LoadESBPlanningScheduleLines = new BusInterface.LoadESBPlanningScheduleLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPlanningScheduleLinesExt = timerfactory.Create<BusInterface.ILoadESBPlanningScheduleLines>(_LoadESBPlanningScheduleLines);
			
			return iLoadESBPlanningScheduleLinesExt;
		}
	}
}
