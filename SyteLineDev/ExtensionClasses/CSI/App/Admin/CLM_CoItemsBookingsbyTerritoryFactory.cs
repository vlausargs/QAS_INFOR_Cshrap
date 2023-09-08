//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_CoItemsBookingsbyTerritoryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_CoItemsBookingsbyTerritoryFactory
	{
		public ICLM_CoItemsBookingsbyTerritory Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CoItemsBookingsbyTerritory = new Admin.CLM_CoItemsBookingsbyTerritory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CoItemsBookingsbyTerritoryExt = timerfactory.Create<Admin.ICLM_CoItemsBookingsbyTerritory>(_CLM_CoItemsBookingsbyTerritory);
			
			return iCLM_CoItemsBookingsbyTerritoryExt;
		}
	}
}
