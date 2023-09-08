//PROJECT NAME: Production
//CLASS NAME: PmfBatchCloseReportProdOutputFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfBatchCloseReportProdOutputFactory
	{
		public IPmfBatchCloseReportProdOutput Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfBatchCloseReportProdOutput = new Production.ProcessManufacturing.PmfBatchCloseReportProdOutput(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfBatchCloseReportProdOutputExt = timerfactory.Create<Production.ProcessManufacturing.IPmfBatchCloseReportProdOutput>(_PmfBatchCloseReportProdOutput);
			
			return iPmfBatchCloseReportProdOutputExt;
		}
	}
}
