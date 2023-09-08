//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostingAnalysisCustomerOrderMarginFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CostingAnalysisCustomerOrderMarginFactory
	{
		public IRpt_CostingAnalysisCustomerOrderMargin Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CostingAnalysisCustomerOrderMargin = new Reporting.Rpt_CostingAnalysisCustomerOrderMargin(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CostingAnalysisCustomerOrderMarginExt = timerfactory.Create<Reporting.IRpt_CostingAnalysisCustomerOrderMargin>(_Rpt_CostingAnalysisCustomerOrderMargin);
			
			return iRpt_CostingAnalysisCustomerOrderMarginExt;
		}
	}
}
