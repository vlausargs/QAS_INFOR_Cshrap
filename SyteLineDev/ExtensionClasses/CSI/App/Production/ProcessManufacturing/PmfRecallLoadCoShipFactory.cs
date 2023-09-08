//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadCoShipFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRecallLoadCoShipFactory
	{
		public IPmfRecallLoadCoShip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfRecallLoadCoShip = new Production.ProcessManufacturing.PmfRecallLoadCoShip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRecallLoadCoShipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRecallLoadCoShip>(_PmfRecallLoadCoShip);
			
			return iPmfRecallLoadCoShipExt;
		}
	}
}
