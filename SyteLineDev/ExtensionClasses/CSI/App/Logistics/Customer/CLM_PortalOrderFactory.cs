//PROJECT NAME: Logistics
//CLASS NAME: CLM_PortalOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PortalOrderFactory
	{
		public ICLM_PortalOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalOrder = new Logistics.Customer.CLM_PortalOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalOrderExt = timerfactory.Create<Logistics.Customer.ICLM_PortalOrder>(_CLM_PortalOrder);
			
			return iCLM_PortalOrderExt;
		}
	}
}
