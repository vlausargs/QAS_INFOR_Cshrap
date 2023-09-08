//PROJECT NAME: CSIProjects
//CLASS NAME: MilestoneButtonEnableFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class MilestoneButtonEnableFactory
	{
		public IMilestoneButtonEnable Create(IApplicationDB appDB)
		{
			var _MilestoneButtonEnable = new Production.Projects.MilestoneButtonEnable(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMilestoneButtonEnableExt = timerfactory.Create<Production.Projects.IMilestoneButtonEnable>(_MilestoneButtonEnable);
			
			return iMilestoneButtonEnableExt;
		}
	}
}
