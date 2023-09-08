//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLQCSGetTesteachDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLQCSGetTesteachDetailsFactory
	{
		public ICLM_FTSLQCSGetTesteachDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLQCSGetTesteachDetails = new Logistics.WarehouseMobility.CLM_FTSLQCSGetTesteachDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLQCSGetTesteachDetailsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLQCSGetTesteachDetails>(_CLM_FTSLQCSGetTesteachDetails);
			
			return iCLM_FTSLQCSGetTesteachDetailsExt;
		}
	}
}
