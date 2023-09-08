//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_UserStartFormSubFormsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_UserStartFormSubFormsFactory
	{
		public ICLM_UserStartFormSubForms Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_UserStartFormSubForms = new Admin.CLM_UserStartFormSubForms(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_UserStartFormSubFormsExt = timerfactory.Create<Admin.ICLM_UserStartFormSubForms>(_CLM_UserStartFormSubForms);
			
			return iCLM_UserStartFormSubFormsExt;
		}
	}
}
