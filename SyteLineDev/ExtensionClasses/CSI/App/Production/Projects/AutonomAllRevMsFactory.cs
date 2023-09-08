//PROJECT NAME: CSIProjects
//CLASS NAME: AutonomAllRevMsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class AutonomAllRevMsFactory
	{
		public IAutonomAllRevMs Create(IApplicationDB appDB)
		{
			var _AutonomAllRevMs = new Production.Projects.AutonomAllRevMs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutonomAllRevMsExt = timerfactory.Create<Production.Projects.IAutonomAllRevMs>(_AutonomAllRevMs);
			
			return iAutonomAllRevMsExt;
		}
	}
}
