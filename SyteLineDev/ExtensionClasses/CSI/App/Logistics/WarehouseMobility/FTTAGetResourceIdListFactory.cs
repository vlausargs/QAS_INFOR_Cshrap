//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTAGetResourceIdListFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTAGetResourceIdListFactory
	{
		public IFTTAGetResourceIdList Create(IApplicationDB appDB)
		{
			var _FTTAGetResourceIdList = new Logistics.WarehouseMobility.FTTAGetResourceIdList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTAGetResourceIdListExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTAGetResourceIdList>(_FTTAGetResourceIdList);
			
			return iFTTAGetResourceIdListExt;
		}
	}
}
