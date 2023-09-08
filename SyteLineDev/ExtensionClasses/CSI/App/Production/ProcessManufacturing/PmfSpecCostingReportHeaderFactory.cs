//PROJECT NAME: Production
//CLASS NAME: PmfSpecCostingReportHeaderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecCostingReportHeaderFactory
	{
		public IPmfSpecCostingReportHeader Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfSpecCostingReportHeader = new Production.ProcessManufacturing.PmfSpecCostingReportHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecCostingReportHeaderExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecCostingReportHeader>(_PmfSpecCostingReportHeader);
			
			return iPmfSpecCostingReportHeaderExt;
		}
	}
}
