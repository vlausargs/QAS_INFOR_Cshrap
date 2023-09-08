//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VendorVoucherDebitMemoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VendorVoucherDebitMemoFactory
	{
		public IRpt_VendorVoucherDebitMemo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VendorVoucherDebitMemo = new Reporting.Rpt_VendorVoucherDebitMemo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VendorVoucherDebitMemoExt = timerfactory.Create<Reporting.IRpt_VendorVoucherDebitMemo>(_Rpt_VendorVoucherDebitMemo);
			
			return iRpt_VendorVoucherDebitMemoExt;
		}
	}
}
