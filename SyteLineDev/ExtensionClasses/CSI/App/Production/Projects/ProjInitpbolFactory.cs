//PROJECT NAME: CSIProjects
//CLASS NAME: ProjInitpbolFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjInitpbolFactory
	{
		public IProjInitpbol Create(IApplicationDB appDB)
		{
			var _ProjInitpbol = new Production.Projects.ProjInitpbol(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjInitpbolExt = timerfactory.Create<Production.Projects.IProjInitpbol>(_ProjInitpbol);
			
			return iProjInitpbolExt;
		}
	}
}
