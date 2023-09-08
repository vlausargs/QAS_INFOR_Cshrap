//PROJECT NAME: Production
//CLASS NAME: PmfSpecCostingReportCostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecCostingReportCostingFactory
	{
		public IPmfSpecCostingReportCosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfSpecCostingReportCosting = new Production.ProcessManufacturing.PmfSpecCostingReportCosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecCostingReportCostingExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecCostingReportCosting>(_PmfSpecCostingReportCosting);
			
			return iPmfSpecCostingReportCostingExt;
		}
	}
}
