//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetItemConvQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetItemConvQtyOnHandFactory
	{
		public IFTSLGetItemConvQtyOnHand Create(IApplicationDB appDB)
		{
			var _FTSLGetItemConvQtyOnHand = new Logistics.WarehouseMobility.FTSLGetItemConvQtyOnHand(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetItemConvQtyOnHandExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetItemConvQtyOnHand>(_FTSLGetItemConvQtyOnHand);
			
			return iFTSLGetItemConvQtyOnHandExt;
		}
	}
}
