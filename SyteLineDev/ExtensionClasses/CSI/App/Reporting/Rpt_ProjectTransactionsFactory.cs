//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectTransactionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectTransactionsFactory
	{
		public IRpt_ProjectTransactions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectTransactions = new Reporting.Rpt_ProjectTransactions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectTransactionsExt = timerfactory.Create<Reporting.IRpt_ProjectTransactions>(_Rpt_ProjectTransactions);
			
			return iRpt_ProjectTransactionsExt;
		}
	}
}
