//PROJECT NAME: CSIProjects
//CLASS NAME: ProjCopyProjectFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProjCopyProjectFactory
	{
		public IProjCopyProject Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProjCopyProject = new Production.Projects.ProjCopyProject(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjCopyProjectExt = timerfactory.Create<Production.Projects.IProjCopyProject>(_ProjCopyProject);
			
			return iProjCopyProjectExt;
		}
	}
}
