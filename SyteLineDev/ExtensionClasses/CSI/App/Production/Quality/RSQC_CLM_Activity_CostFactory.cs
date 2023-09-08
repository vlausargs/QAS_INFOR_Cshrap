//PROJECT NAME: Production
//CLASS NAME: RSQC_CLM_Activity_CostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Quality
{
	public class RSQC_CLM_Activity_CostFactory
	{
		public IRSQC_CLM_Activity_Cost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_CLM_Activity_Cost = new Production.Quality.RSQC_CLM_Activity_Cost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CLM_Activity_CostExt = timerfactory.Create<Production.Quality.IRSQC_CLM_Activity_Cost>(_RSQC_CLM_Activity_Cost);
			
			return iRSQC_CLM_Activity_CostExt;
		}
	}
}
