//PROJECT NAME: CSIProjects
//CLASS NAME: CreateProjInvMsTTFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class CreateProjInvMsTTFactory
	{
		public ICreateProjInvMsTT Create(IApplicationDB appDB)
		{
			var _CreateProjInvMsTT = new Production.Projects.CreateProjInvMsTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateProjInvMsTTExt = timerfactory.Create<Production.Projects.ICreateProjInvMsTT>(_CreateProjInvMsTT);
			
			return iCreateProjInvMsTTExt;
		}
	}
}
