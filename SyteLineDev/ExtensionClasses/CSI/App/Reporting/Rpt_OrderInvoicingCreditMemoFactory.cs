//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderInvoicingCreditMemoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderInvoicingCreditMemoFactory
	{
		public IRpt_OrderInvoicingCreditMemo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderInvoicingCreditMemo = new Reporting.Rpt_OrderInvoicingCreditMemo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderInvoicingCreditMemoExt = timerfactory.Create<Reporting.IRpt_OrderInvoicingCreditMemo>(_Rpt_OrderInvoicingCreditMemo);
			
			return iRpt_OrderInvoicingCreditMemoExt;
		}
	}
}
