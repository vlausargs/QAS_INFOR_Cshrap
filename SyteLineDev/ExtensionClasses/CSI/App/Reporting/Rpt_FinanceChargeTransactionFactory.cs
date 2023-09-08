//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FinanceChargeTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FinanceChargeTransactionFactory
	{
		public IRpt_FinanceChargeTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FinanceChargeTransaction = new Reporting.Rpt_FinanceChargeTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FinanceChargeTransactionExt = timerfactory.Create<Reporting.IRpt_FinanceChargeTransaction>(_Rpt_FinanceChargeTransaction);
			
			return iRpt_FinanceChargeTransactionExt;
		}
	}
}
