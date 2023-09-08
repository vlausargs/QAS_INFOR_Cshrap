//PROJECT NAME: CSIProjects
//CLASS NAME: UpdateProjInfoByCustFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class UpdateProjInfoByCustFactory
	{
		public IUpdateProjInfoByCust Create(IApplicationDB appDB)
		{
			var _UpdateProjInfoByCust = new Production.Projects.UpdateProjInfoByCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateProjInfoByCustExt = timerfactory.Create<Production.Projects.IUpdateProjInfoByCust>(_UpdateProjInfoByCust);
			
			return iUpdateProjInfoByCustExt;
		}
	}
}
