//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDetailRefreshFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class PlanningDetailRefreshFactory
	{
		public IPlanningDetailRefresh Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PlanningDetailRefresh = new Material.PlanningDetailRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningDetailRefreshExt = timerfactory.Create<Material.IPlanningDetailRefresh>(_PlanningDetailRefresh);
			
			return iPlanningDetailRefreshExt;
		}
	}
}
