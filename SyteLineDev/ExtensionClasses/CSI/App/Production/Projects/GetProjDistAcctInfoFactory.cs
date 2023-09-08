//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjDistAcctInfoFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjDistAcctInfoFactory
	{
		public IGetProjDistAcctInfo Create(IApplicationDB appDB)
		{
			var _GetProjDistAcctInfo = new Production.Projects.GetProjDistAcctInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjDistAcctInfoExt = timerfactory.Create<Production.Projects.IGetProjDistAcctInfo>(_GetProjDistAcctInfo);
			
			return iGetProjDistAcctInfoExt;
		}
	}
}
