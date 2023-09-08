//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlTransactionByContainerFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjmatlTransactionByContainerFactory
	{
		public IProjmatlTransactionByContainer Create(IApplicationDB appDB)
		{
			var _ProjmatlTransactionByContainer = new Production.Projects.ProjmatlTransactionByContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlTransactionByContainerExt = timerfactory.Create<Production.Projects.IProjmatlTransactionByContainer>(_ProjmatlTransactionByContainer);
			
			return iProjmatlTransactionByContainerExt;
		}
	}
}
