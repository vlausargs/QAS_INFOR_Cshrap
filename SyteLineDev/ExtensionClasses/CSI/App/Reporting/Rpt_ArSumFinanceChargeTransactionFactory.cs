//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ArSumFinanceChargeTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ArSumFinanceChargeTransactionFactory
	{
		public IRpt_ArSumFinanceChargeTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ArSumFinanceChargeTransaction = new Reporting.Rpt_ArSumFinanceChargeTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ArSumFinanceChargeTransactionExt = timerfactory.Create<Reporting.IRpt_ArSumFinanceChargeTransaction>(_Rpt_ArSumFinanceChargeTransaction);
			
			return iRpt_ArSumFinanceChargeTransactionExt;
		}
	}
}
