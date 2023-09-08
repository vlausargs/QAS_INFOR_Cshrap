//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveVendorAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveVendorAnalysisFactory
	{
		public ICLM_ExecutiveVendorAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveVendorAnalysis = new Finance.CLM_ExecutiveVendorAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveVendorAnalysisExt = timerfactory.Create<Finance.ICLM_ExecutiveVendorAnalysis>(_CLM_ExecutiveVendorAnalysis);
			
			return iCLM_ExecutiveVendorAnalysisExt;
		}
	}
}
