//PROJECT NAME: Reporting
//CLASS NAME: Rpt_WantAdCostAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_WantAdCostAnalysisFactory
	{
		public IRpt_WantAdCostAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_WantAdCostAnalysis = new Reporting.Rpt_WantAdCostAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_WantAdCostAnalysisExt = timerfactory.Create<Reporting.IRpt_WantAdCostAnalysis>(_Rpt_WantAdCostAnalysis);
			
			return iRpt_WantAdCostAnalysisExt;
		}
	}
}
