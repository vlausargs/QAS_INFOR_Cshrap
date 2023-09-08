//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTDeleteSelectedTmpserFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTDeleteSelectedTmpserFactory
	{
		public IFTDeleteSelectedTmpser Create(IApplicationDB appDB)
		{
			var _FTDeleteSelectedTmpser = new Logistics.WarehouseMobility.FTDeleteSelectedTmpser(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTDeleteSelectedTmpserExt = timerfactory.Create<Logistics.WarehouseMobility.IFTDeleteSelectedTmpser>(_FTDeleteSelectedTmpser);
			
			return iFTDeleteSelectedTmpserExt;
		}
	}
}
