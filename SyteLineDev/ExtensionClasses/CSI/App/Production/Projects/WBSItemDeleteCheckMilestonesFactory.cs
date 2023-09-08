//PROJECT NAME: Production
//CLASS NAME: WBSItemDeleteCheckMilestonesFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSItemDeleteCheckMilestonesFactory
	{
		public IWBSItemDeleteCheckMilestones Create(IApplicationDB appDB)
		{
			var _WBSItemDeleteCheckMilestones = new Production.Projects.WBSItemDeleteCheckMilestones(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWBSItemDeleteCheckMilestonesExt = timerfactory.Create<Production.Projects.IWBSItemDeleteCheckMilestones>(_WBSItemDeleteCheckMilestones);
			
			return iWBSItemDeleteCheckMilestonesExt;
		}
	}
}
