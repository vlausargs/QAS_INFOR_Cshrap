//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostingAnalysisInventoryVarianceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CostingAnalysisInventoryVarianceFactory
	{
		public IRpt_CostingAnalysisInventoryVariance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CostingAnalysisInventoryVariance = new Reporting.Rpt_CostingAnalysisInventoryVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CostingAnalysisInventoryVarianceExt = timerfactory.Create<Reporting.IRpt_CostingAnalysisInventoryVariance>(_Rpt_CostingAnalysisInventoryVariance);
			
			return iRpt_CostingAnalysisInventoryVarianceExt;
		}
	}
}
