//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLQCSGetTestdDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLQCSGetTestdDetailsFactory
	{
		public ICLM_FTSLQCSGetTestdDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLQCSGetTestdDetails = new Logistics.WarehouseMobility.CLM_FTSLQCSGetTestdDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLQCSGetTestdDetailsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLQCSGetTestdDetails>(_CLM_FTSLQCSGetTestdDetails);
			
			return iCLM_FTSLQCSGetTestdDetailsExt;
		}
	}
}
