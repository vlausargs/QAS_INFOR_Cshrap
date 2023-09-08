//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadOnHandFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRecallLoadOnHandFactory
	{
		public IPmfRecallLoadOnHand Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfRecallLoadOnHand = new Production.ProcessManufacturing.PmfRecallLoadOnHand(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRecallLoadOnHandExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRecallLoadOnHand>(_PmfRecallLoadOnHand);
			
			return iPmfRecallLoadOnHandExt;
		}
	}
}
