//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_PostProjectLaborTransFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_PostProjectLaborTransFactory
	{
		public ICLM_PostProjectLaborTrans Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PostProjectLaborTrans = new Production.Projects.CLM_PostProjectLaborTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PostProjectLaborTransExt = timerfactory.Create<Production.Projects.ICLM_PostProjectLaborTrans>(_CLM_PostProjectLaborTrans);
			
			return iCLM_PostProjectLaborTransExt;
		}
	}
}
