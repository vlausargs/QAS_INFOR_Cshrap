//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLSerialCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLSerialCountFactory
	{
		public IFTSLSerialCount Create(IApplicationDB appDB)
		{
			var _FTSLSerialCount = new Logistics.WarehouseMobility.FTSLSerialCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLSerialCountExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLSerialCount>(_FTSLSerialCount);
			
			return iFTSLSerialCountExt;
		}
	}
}
