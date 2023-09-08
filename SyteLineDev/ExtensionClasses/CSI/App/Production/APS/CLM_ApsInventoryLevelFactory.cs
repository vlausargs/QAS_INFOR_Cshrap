//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsInventoryLevelFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsInventoryLevelFactory
	{
		public ICLM_ApsInventoryLevel Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsInventoryLevel = new Production.APS.CLM_ApsInventoryLevel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsInventoryLevelExt = timerfactory.Create<Production.APS.ICLM_ApsInventoryLevel>(_CLM_ApsInventoryLevel);
			
			return iCLM_ApsInventoryLevelExt;
		}
	}
}
