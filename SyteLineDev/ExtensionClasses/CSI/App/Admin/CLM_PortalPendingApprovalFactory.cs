//PROJECT NAME: Admin
//CLASS NAME: CLM_PortalPendingApprovalFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_PortalPendingApprovalFactory
	{
		public ICLM_PortalPendingApproval Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalPendingApproval = new Admin.CLM_PortalPendingApproval(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalPendingApprovalExt = timerfactory.Create<Admin.ICLM_PortalPendingApproval>(_CLM_PortalPendingApproval);
			
			return iCLM_PortalPendingApprovalExt;
		}
	}
}
