//PROJECT NAME: CSIProjects
//CLASS NAME: ProjlabrDeleteFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjlabrDeleteFactory
	{
		public IProjlabrDelete Create(IApplicationDB appDB)
		{
			var _ProjlabrDelete = new Production.Projects.ProjlabrDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjlabrDeleteExt = timerfactory.Create<Production.Projects.IProjlabrDelete>(_ProjlabrDelete);
			
			return iProjlabrDeleteExt;
		}
	}
}
