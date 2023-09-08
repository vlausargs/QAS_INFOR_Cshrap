//PROJECT NAME: CSIProjects
//CLASS NAME: ProjInvPostFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjInvPostFactory
	{
		public IProjInvPost Create(IApplicationDB appDB)
		{
			var _ProjInvPost = new Production.Projects.ProjInvPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjInvPostExt = timerfactory.Create<Production.Projects.IProjInvPost>(_ProjInvPost);
			
			return iProjInvPostExt;
		}
	}
}
