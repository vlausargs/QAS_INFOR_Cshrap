//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadVSAJobAndPreSerialsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadVSAJobAndPreSerialsFactory
	{
		public ICLM_FTSLLoadVSAJobAndPreSerials Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadVSAJobAndPreSerials = new Logistics.WarehouseMobility.CLM_FTSLLoadVSAJobAndPreSerials(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadVSAJobAndPreSerialsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadVSAJobAndPreSerials>(_CLM_FTSLLoadVSAJobAndPreSerials);
			
			return iCLM_FTSLLoadVSAJobAndPreSerialsExt;
		}
	}
}
