//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPlanningSchedulePostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPlanningSchedulePostFactory
	{
		public ILoadESBPlanningSchedulePost Create(IApplicationDB appDB)
		{
			var _LoadESBPlanningSchedulePost = new BusInterface.LoadESBPlanningSchedulePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPlanningSchedulePostExt = timerfactory.Create<BusInterface.ILoadESBPlanningSchedulePost>(_LoadESBPlanningSchedulePost);
			
			return iLoadESBPlanningSchedulePostExt;
		}
	}
}
