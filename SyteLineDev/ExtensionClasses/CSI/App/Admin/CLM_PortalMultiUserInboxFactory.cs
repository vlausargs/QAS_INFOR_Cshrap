//PROJECT NAME: Admin
//CLASS NAME: CLM_PortalMultiUserInboxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_PortalMultiUserInboxFactory
	{
		public ICLM_PortalMultiUserInbox Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalMultiUserInbox = new Admin.CLM_PortalMultiUserInbox(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalMultiUserInboxExt = timerfactory.Create<Admin.ICLM_PortalMultiUserInbox>(_CLM_PortalMultiUserInbox);
			
			return iCLM_PortalMultiUserInboxExt;
		}
	}
}
