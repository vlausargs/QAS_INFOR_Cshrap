//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMSLNegInvLotCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMSLNegInvLotCheckFactory
	{
		public IFTSLWMSLNegInvLotCheck Create(IApplicationDB appDB)
		{
			var _FTSLWMSLNegInvLotCheck = new Logistics.WarehouseMobility.FTSLWMSLNegInvLotCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMSLNegInvLotCheckExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMSLNegInvLotCheck>(_FTSLWMSLNegInvLotCheck);
			
			return iFTSLWMSLNegInvLotCheckExt;
		}
	}
}
