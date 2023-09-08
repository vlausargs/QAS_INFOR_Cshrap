//PROJECT NAME: CSIProjects
//CLASS NAME: ProjBolFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjBolFactory
	{
		public IProjBol Create(IApplicationDB appDB)
		{
			var _ProjBol = new Production.Projects.ProjBol(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjBolExt = timerfactory.Create<Production.Projects.IProjBol>(_ProjBol);
			
			return iProjBolExt;
		}
	}
}
