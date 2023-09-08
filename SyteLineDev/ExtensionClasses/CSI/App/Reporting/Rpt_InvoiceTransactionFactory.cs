//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceTransactionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceTransactionFactory
	{
		public IRpt_InvoiceTransaction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceTransaction = new Reporting.Rpt_InvoiceTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceTransactionExt = timerfactory.Create<Reporting.IRpt_InvoiceTransaction>(_Rpt_InvoiceTransaction);
			
			return iRpt_InvoiceTransactionExt;
		}
	}
}
