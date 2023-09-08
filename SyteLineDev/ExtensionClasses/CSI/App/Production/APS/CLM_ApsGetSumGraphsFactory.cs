//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSumGraphsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSumGraphsFactory
	{
		public ICLM_ApsGetSumGraphs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSumGraphs = new Production.APS.CLM_ApsGetSumGraphs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSumGraphsExt = timerfactory.Create<Production.APS.ICLM_ApsGetSumGraphs>(_CLM_ApsGetSumGraphs);
			
			return iCLM_ApsGetSumGraphsExt;
		}
	}
}
