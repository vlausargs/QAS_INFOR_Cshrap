//PROJECT NAME: CSIProjects
//CLASS NAME: prjresPermissionsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class prjresPermissionsFactory
	{
		public IprjresPermissions Create(IApplicationDB appDB)
		{
			var _prjresPermissions = new Production.Projects.prjresPermissions(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iprjresPermissionsExt = timerfactory.Create<Production.Projects.IprjresPermissions>(_prjresPermissions);
			
			return iprjresPermissionsExt;
		}
	}
}
