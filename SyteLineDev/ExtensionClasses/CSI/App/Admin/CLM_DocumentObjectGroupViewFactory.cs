//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_DocumentObjectGroupViewFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_DocumentObjectGroupViewFactory
	{
		public ICLM_DocumentObjectGroupView Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DocumentObjectGroupView = new Admin.CLM_DocumentObjectGroupView(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DocumentObjectGroupViewExt = timerfactory.Create<Admin.ICLM_DocumentObjectGroupView>(_CLM_DocumentObjectGroupView);
			
			return iCLM_DocumentObjectGroupViewExt;
		}
	}
}
