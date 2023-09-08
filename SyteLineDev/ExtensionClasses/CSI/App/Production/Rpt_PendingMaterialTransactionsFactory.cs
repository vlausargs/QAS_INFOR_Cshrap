//PROJECT NAME: Production
//CLASS NAME: Rpt_PendingMaterialTransactionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class Rpt_PendingMaterialTransactionsFactory
	{
		public IRpt_PendingMaterialTransactions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PendingMaterialTransactions = new Production.Rpt_PendingMaterialTransactions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PendingMaterialTransactionsExt = timerfactory.Create<Production.IRpt_PendingMaterialTransactions>(_Rpt_PendingMaterialTransactions);
			
			return iRpt_PendingMaterialTransactionsExt;
		}
	}
}
