//PROJECT NAME: CSIProjects
//CLASS NAME: ProfileProjNomInvFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProfileProjNomInvFactory
	{
		public IProfileProjNomInv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileProjNomInv = new Production.Projects.ProfileProjNomInv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileProjNomInvExt = timerfactory.Create<Production.Projects.IProfileProjNomInv>(_ProfileProjNomInv);
			
			return iProfileProjNomInvExt;
		}
	}
}
