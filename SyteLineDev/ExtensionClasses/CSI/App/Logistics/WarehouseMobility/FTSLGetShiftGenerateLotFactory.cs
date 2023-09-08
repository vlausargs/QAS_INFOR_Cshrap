//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetShiftGenerateLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetShiftGenerateLotFactory
	{
		public IFTSLGetShiftGenerateLot Create(IApplicationDB appDB)
		{
			var _FTSLGetShiftGenerateLot = new Logistics.WarehouseMobility.FTSLGetShiftGenerateLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetShiftGenerateLotExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetShiftGenerateLot>(_FTSLGetShiftGenerateLot);
			
			return iFTSLGetShiftGenerateLotExt;
		}
	}
}
