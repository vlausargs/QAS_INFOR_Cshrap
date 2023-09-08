//PROJECT NAME: CSIProjects
//CLASS NAME: ProfileReprintProjPackSlipFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProfileReprintProjPackSlipFactory
	{
		public IProfileReprintProjPackSlip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _ProfileReprintProjPackSlip = new Production.Projects.ProfileReprintProjPackSlip(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileReprintProjPackSlipExt = timerfactory.Create<Production.Projects.IProfileReprintProjPackSlip>(_ProfileReprintProjPackSlip);
			
			return iProfileReprintProjPackSlipExt;
		}
	}
}
