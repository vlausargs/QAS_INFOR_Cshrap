//PROJECT NAME: CSIProjects
//CLASS NAME: ProfileReprintProjInvFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProfileReprintProjInvFactory
	{
		public IProfileReprintProjInv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileReprintProjInv = new Production.Projects.ProfileReprintProjInv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileReprintProjInvExt = timerfactory.Create<Production.Projects.IProfileReprintProjInv>(_ProfileReprintProjInv);
			
			return iProfileReprintProjInvExt;
		}
	}
}
