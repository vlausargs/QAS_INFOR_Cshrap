//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ContractProfitAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_ContractProfitAnalysisFactory
	{
		public ISSSFSRpt_ContractProfitAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_ContractProfitAnalysis = new Reporting.SSSFSRpt_ContractProfitAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_ContractProfitAnalysisExt = timerfactory.Create<Reporting.ISSSFSRpt_ContractProfitAnalysis>(_SSSFSRpt_ContractProfitAnalysis);
			
			return iSSSFSRpt_ContractProfitAnalysisExt;
		}
	}
}
