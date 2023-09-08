//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetPartnerIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetPartnerIdFactory
	{
		public ICLM_FTSLGetPartnerId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetPartnerId = new Logistics.WarehouseMobility.CLM_FTSLGetPartnerId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetPartnerIdExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetPartnerId>(_CLM_FTSLGetPartnerId);
			
			return iCLM_FTSLGetPartnerIdExt;
		}
	}
}
