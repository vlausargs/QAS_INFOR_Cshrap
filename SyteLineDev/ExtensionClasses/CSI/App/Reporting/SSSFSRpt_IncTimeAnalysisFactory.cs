//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_IncTimeAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_IncTimeAnalysisFactory
	{
		public ISSSFSRpt_IncTimeAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_IncTimeAnalysis = new Reporting.SSSFSRpt_IncTimeAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_IncTimeAnalysisExt = timerfactory.Create<Reporting.ISSSFSRpt_IncTimeAnalysis>(_SSSFSRpt_IncTimeAnalysis);
			
			return iSSSFSRpt_IncTimeAnalysisExt;
		}
	}
}
