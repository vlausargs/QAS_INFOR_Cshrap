//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrInitialRateFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjLabrInitialRateFactory
	{
		public IProjLabrInitialRate Create(IApplicationDB appDB)
		{
			var _ProjLabrInitialRate = new Production.Projects.ProjLabrInitialRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjLabrInitialRateExt = timerfactory.Create<Production.Projects.IProjLabrInitialRate>(_ProjLabrInitialRate);
			
			return iProjLabrInitialRateExt;
		}
	}
}
