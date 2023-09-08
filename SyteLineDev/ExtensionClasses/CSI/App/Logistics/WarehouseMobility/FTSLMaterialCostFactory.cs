//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLMaterialCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLMaterialCostFactory
	{
		public IFTSLMaterialCost Create(IApplicationDB appDB)
		{
			var _FTSLMaterialCost = new Logistics.WarehouseMobility.FTSLMaterialCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLMaterialCostExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLMaterialCost>(_FTSLMaterialCost);
			
			return iFTSLMaterialCostExt;
		}
	}
}
