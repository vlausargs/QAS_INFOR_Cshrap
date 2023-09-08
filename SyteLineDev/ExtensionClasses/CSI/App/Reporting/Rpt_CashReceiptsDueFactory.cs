//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CashReceiptsDueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CashReceiptsDueFactory
	{
		public IRpt_CashReceiptsDue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CashReceiptsDue = new Reporting.Rpt_CashReceiptsDue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CashReceiptsDueExt = timerfactory.Create<Reporting.IRpt_CashReceiptsDue>(_Rpt_CashReceiptsDue);
			
			return iRpt_CashReceiptsDueExt;
		}
	}
}
