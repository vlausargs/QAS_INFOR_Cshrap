//PROJECT NAME: CSIProjects
//CLASS NAME: ProjlabrPostFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjlabrPostFactory
	{
		public IProjlabrPost Create(IApplicationDB appDB)
		{
			var _ProjlabrPost = new Production.Projects.ProjlabrPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjlabrPostExt = timerfactory.Create<Production.Projects.IProjlabrPost>(_ProjlabrPost);
			
			return iProjlabrPostExt;
		}
	}
}
