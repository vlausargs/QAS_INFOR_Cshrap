//PROJECT NAME: Production
//CLASS NAME: PmfPnLoadStatsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnLoadStatsFactory
	{
		public IPmfPnLoadStats Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfPnLoadStats = new Production.ProcessManufacturing.PmfPnLoadStats(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnLoadStatsExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnLoadStats>(_PmfPnLoadStats);
			
			return iPmfPnLoadStatsExt;
		}
	}
}
