//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetDefaultWCLocationFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetDefaultWCLocationFactory
	{
		public IFTSLGetDefaultWCLocation Create(IApplicationDB appDB)
		{
			var _FTSLGetDefaultWCLocation = new Logistics.WarehouseMobility.FTSLGetDefaultWCLocation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetDefaultWCLocationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetDefaultWCLocation>(_FTSLGetDefaultWCLocation);
			
			return iFTSLGetDefaultWCLocationExt;
		}
	}
}
