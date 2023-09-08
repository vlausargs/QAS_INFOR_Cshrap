//PROJECT NAME: CSIProjects
//CLASS NAME: ProjDateChangedFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjDateChangedFactory
	{
		public IProjDateChanged Create(IApplicationDB appDB)
		{
			var _ProjDateChanged = new Production.Projects.ProjDateChanged(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjDateChangedExt = timerfactory.Create<Production.Projects.IProjDateChanged>(_ProjDateChanged);
			
			return iProjDateChangedExt;
		}
	}
}
