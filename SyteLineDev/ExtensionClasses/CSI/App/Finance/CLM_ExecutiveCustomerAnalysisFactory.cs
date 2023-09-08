//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveCustomerAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveCustomerAnalysisFactory
	{
		public ICLM_ExecutiveCustomerAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveCustomerAnalysis = new Finance.CLM_ExecutiveCustomerAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveCustomerAnalysisExt = timerfactory.Create<Finance.ICLM_ExecutiveCustomerAnalysis>(_CLM_ExecutiveCustomerAnalysis);
			
			return iCLM_ExecutiveCustomerAnalysisExt;
		}
	}
}
