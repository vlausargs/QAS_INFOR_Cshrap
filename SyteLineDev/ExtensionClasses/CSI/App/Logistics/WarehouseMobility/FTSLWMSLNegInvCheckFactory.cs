//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMSLNegInvCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMSLNegInvCheckFactory
	{
		public IFTSLWMSLNegInvCheck Create(IApplicationDB appDB)
		{
			var _FTSLWMSLNegInvCheck = new Logistics.WarehouseMobility.FTSLWMSLNegInvCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMSLNegInvCheckExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMSLNegInvCheck>(_FTSLWMSLNegInvCheck);
			
			return iFTSLWMSLNegInvCheckExt;
		}
	}
}
