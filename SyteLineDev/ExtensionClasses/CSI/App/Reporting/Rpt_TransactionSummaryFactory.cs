//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransactionSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransactionSummaryFactory
	{
		public IRpt_TransactionSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransactionSummary = new Reporting.Rpt_TransactionSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransactionSummaryExt = timerfactory.Create<Reporting.IRpt_TransactionSummary>(_Rpt_TransactionSummary);
			
			return iRpt_TransactionSummaryExt;
		}
	}
}
