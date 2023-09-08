//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrEmpNumValidFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjLabrEmpNumValidFactory
	{
		public IProjLabrEmpNumValid Create(IApplicationDB appDB)
		{
			var _ProjLabrEmpNumValid = new Production.Projects.ProjLabrEmpNumValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjLabrEmpNumValidExt = timerfactory.Create<Production.Projects.IProjLabrEmpNumValid>(_ProjLabrEmpNumValid);
			
			return iProjLabrEmpNumValidExt;
		}
	}
}
