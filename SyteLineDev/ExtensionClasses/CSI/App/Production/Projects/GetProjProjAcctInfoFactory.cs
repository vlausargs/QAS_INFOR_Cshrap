//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjProjAcctInfoFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjProjAcctInfoFactory
	{
		public IGetProjProjAcctInfo Create(IApplicationDB appDB)
		{
			var _GetProjProjAcctInfo = new Production.Projects.GetProjProjAcctInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjProjAcctInfoExt = timerfactory.Create<Production.Projects.IGetProjProjAcctInfo>(_GetProjProjAcctInfo);
			
			return iGetProjProjAcctInfoExt;
		}
	}
}
