//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlValidateLocFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjmatlValidateLocFactory
	{
		public IProjmatlValidateLoc Create(IApplicationDB appDB)
		{
			var _ProjmatlValidateLoc = new Production.Projects.ProjmatlValidateLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlValidateLocExt = timerfactory.Create<Production.Projects.IProjmatlValidateLoc>(_ProjmatlValidateLoc);
			
			return iProjmatlValidateLocExt;
		}
	}
}
