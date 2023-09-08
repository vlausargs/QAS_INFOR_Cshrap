//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateLotFactory
	{
		public IFTSLValidateLot Create(IApplicationDB appDB)
		{
			var _FTSLValidateLot = new Logistics.WarehouseMobility.FTSLValidateLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateLotExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateLot>(_FTSLValidateLot);
			
			return iFTSLValidateLotExt;
		}
	}
}
