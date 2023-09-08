//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ApplicantSourceAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ApplicantSourceAnalysisFactory
	{
		public IRpt_ApplicantSourceAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ApplicantSourceAnalysis = new Reporting.Rpt_ApplicantSourceAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ApplicantSourceAnalysisExt = timerfactory.Create<Reporting.IRpt_ApplicantSourceAnalysis>(_Rpt_ApplicantSourceAnalysis);
			
			return iRpt_ApplicantSourceAnalysisExt;
		}
	}
}
