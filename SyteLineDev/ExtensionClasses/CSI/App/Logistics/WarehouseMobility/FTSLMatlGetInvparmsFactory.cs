//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLMatlGetInvparmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLMatlGetInvparmsFactory
	{
		public IFTSLMatlGetInvparms Create(IApplicationDB appDB)
		{
			var _FTSLMatlGetInvparms = new Logistics.WarehouseMobility.FTSLMatlGetInvparms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLMatlGetInvparmsExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLMatlGetInvparms>(_FTSLMatlGetInvparms);
			
			return iFTSLMatlGetInvparmsExt;
		}
	}
}
