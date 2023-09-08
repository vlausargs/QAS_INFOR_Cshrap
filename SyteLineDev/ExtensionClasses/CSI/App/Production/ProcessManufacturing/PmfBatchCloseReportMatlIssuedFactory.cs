//PROJECT NAME: Production
//CLASS NAME: PmfBatchCloseReportMatlIssuedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfBatchCloseReportMatlIssuedFactory
	{
		public IPmfBatchCloseReportMatlIssued Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfBatchCloseReportMatlIssued = new Production.ProcessManufacturing.PmfBatchCloseReportMatlIssued(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfBatchCloseReportMatlIssuedExt = timerfactory.Create<Production.ProcessManufacturing.IPmfBatchCloseReportMatlIssued>(_PmfBatchCloseReportMatlIssued);
			
			return iPmfBatchCloseReportMatlIssuedExt;
		}
	}
}
