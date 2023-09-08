//PROJECT NAME: Production
//CLASS NAME: PmfBatchCloseReportHeaderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfBatchCloseReportHeaderFactory
	{
		public IPmfBatchCloseReportHeader Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfBatchCloseReportHeader = new Production.ProcessManufacturing.PmfBatchCloseReportHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfBatchCloseReportHeaderExt = timerfactory.Create<Production.ProcessManufacturing.IPmfBatchCloseReportHeader>(_PmfBatchCloseReportHeader);
			
			return iPmfBatchCloseReportHeaderExt;
		}
	}
}
