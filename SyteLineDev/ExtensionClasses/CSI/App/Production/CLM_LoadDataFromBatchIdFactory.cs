//PROJECT NAME: Production
//CLASS NAME: CLM_LoadDataFromBatchIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_LoadDataFromBatchIdFactory
	{
		public ICLM_LoadDataFromBatchId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadDataFromBatchId = new Production.CLM_LoadDataFromBatchId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadDataFromBatchIdExt = timerfactory.Create<Production.ICLM_LoadDataFromBatchId>(_CLM_LoadDataFromBatchId);
			
			return iCLM_LoadDataFromBatchIdExt;
		}
	}
}
