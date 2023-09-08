//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLDocumentListingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLDocumentListingFactory
	{
		public ICLM_FTSLDocumentListing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLDocumentListing = new Logistics.WarehouseMobility.CLM_FTSLDocumentListing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLDocumentListingExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLDocumentListing>(_CLM_FTSLDocumentListing);
			
			return iCLM_FTSLDocumentListingExt;
		}
	}
}
