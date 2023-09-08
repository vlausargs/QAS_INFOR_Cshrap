//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderInvoicingCreditMemoToBePrintedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderInvoicingCreditMemoToBePrintedFactory
	{
		public IRpt_OrderInvoicingCreditMemoToBePrinted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderInvoicingCreditMemoToBePrinted = new Reporting.Rpt_OrderInvoicingCreditMemoToBePrinted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderInvoicingCreditMemoToBePrintedExt = timerfactory.Create<Reporting.IRpt_OrderInvoicingCreditMemoToBePrinted>(_Rpt_OrderInvoicingCreditMemoToBePrinted);
			
			return iRpt_OrderInvoicingCreditMemoToBePrintedExt;
		}
	}
}
