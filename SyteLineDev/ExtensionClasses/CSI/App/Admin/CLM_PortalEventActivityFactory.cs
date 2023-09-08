//PROJECT NAME: Admin
//CLASS NAME: CLM_PortalEventActivityFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_PortalEventActivityFactory
	{
		public ICLM_PortalEventActivity Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalEventActivity = new Admin.CLM_PortalEventActivity(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalEventActivityExt = timerfactory.Create<Admin.ICLM_PortalEventActivity>(_CLM_PortalEventActivity);
			
			return iCLM_PortalEventActivityExt;
		}
	}
}
