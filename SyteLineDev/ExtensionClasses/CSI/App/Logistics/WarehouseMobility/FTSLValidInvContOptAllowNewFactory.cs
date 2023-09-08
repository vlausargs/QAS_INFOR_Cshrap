//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidInvContOptAllowNewFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidInvContOptAllowNewFactory
	{
		public IFTSLValidInvContOptAllowNew Create(IApplicationDB appDB)
		{
			var _FTSLValidInvContOptAllowNew = new Logistics.WarehouseMobility.FTSLValidInvContOptAllowNew(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidInvContOptAllowNewExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidInvContOptAllowNew>(_FTSLValidInvContOptAllowNew);
			
			return iFTSLValidInvContOptAllowNewExt;
		}
	}
}
