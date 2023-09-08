//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCLM_SearchForRegistrationPostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCLM_SearchForRegistrationPostingFactory
	{
		public ISSSFSCLM_SearchForRegistrationPosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSCLM_SearchForRegistrationPosting = new Logistics.FieldService.SSSFSCLM_SearchForRegistrationPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSCLM_SearchForRegistrationPostingExt = timerfactory.Create<Logistics.FieldService.ISSSFSCLM_SearchForRegistrationPosting>(_SSSFSCLM_SearchForRegistrationPosting);
			
			return iSSSFSCLM_SearchForRegistrationPostingExt;
		}
	}
}
