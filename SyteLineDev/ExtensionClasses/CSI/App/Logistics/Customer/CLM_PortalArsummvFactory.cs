//PROJECT NAME: Logistics
//CLASS NAME: CLM_PortalArsummvFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PortalArsummvFactory
	{
		public ICLM_PortalArsummv Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PortalArsummv = new Logistics.Customer.CLM_PortalArsummv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PortalArsummvExt = timerfactory.Create<Logistics.Customer.ICLM_PortalArsummv>(_CLM_PortalArsummv);
			
			return iCLM_PortalArsummvExt;
		}
	}
}
