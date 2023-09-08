//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ScrapAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ScrapAnalysisFactory
	{
		public IRpt_ScrapAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ScrapAnalysis = new Reporting.Rpt_ScrapAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ScrapAnalysisExt = timerfactory.Create<Reporting.IRpt_ScrapAnalysis>(_Rpt_ScrapAnalysis);
			
			return iRpt_ScrapAnalysisExt;
		}
	}
}
