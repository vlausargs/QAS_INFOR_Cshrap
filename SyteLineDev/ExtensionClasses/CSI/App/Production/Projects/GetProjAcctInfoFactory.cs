//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjAcctInfoFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjAcctInfoFactory
	{
		public IGetProjAcctInfo Create(IApplicationDB appDB)
		{
			var _GetProjAcctInfo = new Production.Projects.GetProjAcctInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjAcctInfoExt = timerfactory.Create<Production.Projects.IGetProjAcctInfo>(_GetProjAcctInfo);
			
			return iGetProjAcctInfoExt;
		}
	}
}
