//PROJECT NAME: Admin
//CLASS NAME: CLM_PortalExpiredMessagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_PortalExpiredMessagesFactory
	{
		public ICLM_PortalExpiredMessages Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalExpiredMessages = new Admin.CLM_PortalExpiredMessages(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalExpiredMessagesExt = timerfactory.Create<Admin.ICLM_PortalExpiredMessages>(_CLM_PortalExpiredMessages);
			
			return iCLM_PortalExpiredMessagesExt;
		}
	}
}
