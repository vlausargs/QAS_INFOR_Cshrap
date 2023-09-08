//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PostedPayrollTransactionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PostedPayrollTransactionsFactory
	{
		public IRpt_PostedPayrollTransactions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PostedPayrollTransactions = new Reporting.Rpt_PostedPayrollTransactions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PostedPayrollTransactionsExt = timerfactory.Create<Reporting.IRpt_PostedPayrollTransactions>(_Rpt_PostedPayrollTransactions);
			
			return iRpt_PostedPayrollTransactionsExt;
		}
	}
}
