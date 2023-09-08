//PROJECT NAME: CSIProjects
//CLASS NAME: prjresDupItemWarningFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class prjresDupItemWarningFactory
	{
		public IprjresDupItemWarning Create(IApplicationDB appDB)
		{
			var _prjresDupItemWarning = new Production.Projects.prjresDupItemWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iprjresDupItemWarningExt = timerfactory.Create<Production.Projects.IprjresDupItemWarning>(_prjresDupItemWarning);
			
			return iprjresDupItemWarningExt;
		}
	}
}
