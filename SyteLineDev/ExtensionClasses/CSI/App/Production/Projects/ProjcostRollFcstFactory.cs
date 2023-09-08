//PROJECT NAME: CSIProjects
//CLASS NAME: ProjcostRollFcstFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjcostRollFcstFactory
	{
		public IProjcostRollFcst Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _ProjcostRollFcst = new Production.Projects.ProjcostRollFcst(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjcostRollFcstExt = timerfactory.Create<Production.Projects.IProjcostRollFcst>(_ProjcostRollFcst);
			
			return iProjcostRollFcstExt;
		}
	}
}
