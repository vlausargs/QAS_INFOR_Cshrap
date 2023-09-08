//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDemandNegativeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class PlanningDemandNegativeFactory
	{
		public IPlanningDemandNegative Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PlanningDemandNegative = new Material.PlanningDemandNegative(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningDemandNegativeExt = timerfactory.Create<Material.IPlanningDemandNegative>(_PlanningDemandNegative);
			
			return iPlanningDemandNegativeExt;
		}
	}
}
