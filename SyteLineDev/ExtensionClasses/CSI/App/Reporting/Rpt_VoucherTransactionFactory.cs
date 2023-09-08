//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoucherTransactionFactory
	{
		public IRpt_VoucherTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoucherTransaction = new Reporting.Rpt_VoucherTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoucherTransactionExt = timerfactory.Create<Reporting.IRpt_VoucherTransaction>(_Rpt_VoucherTransaction);
			
			return iRpt_VoucherTransactionExt;
		}
	}
}
