//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRPT_expenseReconciliationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRPT_expenseReconciliationFactory
	{
		public ISSSFSRPT_expenseReconciliation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRPT_expenseReconciliation = new Reporting.SSSFSRPT_expenseReconciliation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRPT_expenseReconciliationExt = timerfactory.Create<Reporting.ISSSFSRPT_expenseReconciliation>(_SSSFSRPT_expenseReconciliation);
			
			return iSSSFSRPT_expenseReconciliationExt;
		}
	}
}
