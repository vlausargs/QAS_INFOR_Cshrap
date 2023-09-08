//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARInvoiceCreditDebitMemoFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARInvoiceCreditDebitMemoFactory
	{
		public IRpt_ARInvoiceCreditDebitMemo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARInvoiceCreditDebitMemo = new Reporting.Rpt_ARInvoiceCreditDebitMemo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARInvoiceCreditDebitMemoExt = timerfactory.Create<Reporting.IRpt_ARInvoiceCreditDebitMemo>(_Rpt_ARInvoiceCreditDebitMemo);
			
			return iRpt_ARInvoiceCreditDebitMemoExt;
		}
	}
}
