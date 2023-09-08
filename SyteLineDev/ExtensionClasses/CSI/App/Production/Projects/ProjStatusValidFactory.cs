//PROJECT NAME: CSIProjects
//CLASS NAME: ProjStatusValidFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjStatusValidFactory
	{
		public IProjStatusValid Create(IApplicationDB appDB)
		{
			var _ProjStatusValid = new Production.Projects.ProjStatusValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjStatusValidExt = timerfactory.Create<Production.Projects.IProjStatusValid>(_ProjStatusValid);
			
			return iProjStatusValidExt;
		}
	}
}
