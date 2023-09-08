//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTDeleteTmpserFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTDeleteTmpserFactory
	{
		public IFTDeleteTmpser Create(IApplicationDB appDB)
		{
			var _FTDeleteTmpser = new Logistics.WarehouseMobility.FTDeleteTmpser(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTDeleteTmpserExt = timerfactory.Create<Logistics.WarehouseMobility.IFTDeleteTmpser>(_FTDeleteTmpser);
			
			return iFTDeleteTmpserExt;
		}
	}
}
