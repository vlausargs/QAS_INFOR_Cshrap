//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PR02RICurPayrollTxsSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PR02RICurPayrollTxsSummaryFactory
	{
		public IRpt_PR02RICurPayrollTxsSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PR02RICurPayrollTxsSummary = new Reporting.Rpt_PR02RICurPayrollTxsSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PR02RICurPayrollTxsSummaryExt = timerfactory.Create<Reporting.IRpt_PR02RICurPayrollTxsSummary>(_Rpt_PR02RICurPayrollTxsSummary);
			
			return iRpt_PR02RICurPayrollTxsSummaryExt;
		}
	}
}
