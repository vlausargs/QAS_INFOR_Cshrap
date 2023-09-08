//PROJECT NAME: Production
//CLASS NAME: PmfBatchCloseReportAcctSummaryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfBatchCloseReportAcctSummaryFactory
	{
		public IPmfBatchCloseReportAcctSummary Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfBatchCloseReportAcctSummary = new Production.ProcessManufacturing.PmfBatchCloseReportAcctSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfBatchCloseReportAcctSummaryExt = timerfactory.Create<Production.ProcessManufacturing.IPmfBatchCloseReportAcctSummary>(_PmfBatchCloseReportAcctSummary);
			
			return iPmfBatchCloseReportAcctSummaryExt;
		}
	}
}
