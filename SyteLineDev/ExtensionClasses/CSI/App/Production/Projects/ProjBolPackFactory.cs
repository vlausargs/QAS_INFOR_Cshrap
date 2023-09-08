//PROJECT NAME: CSIProjects
//CLASS NAME: ProjBolPackFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjBolPackFactory
	{
		public IProjBolPack Create(IApplicationDB appDB)
		{
			var _ProjBolPack = new Production.Projects.ProjBolPack(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjBolPackExt = timerfactory.Create<Production.Projects.IProjBolPack>(_ProjBolPack);
			
			return iProjBolPackExt;
		}
	}
}
