//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetLaborBackFlushStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetLaborBackFlushStatusFactory
	{
		public IFTSLGetLaborBackFlushStatus Create(IApplicationDB appDB)
		{
			var _FTSLGetLaborBackFlushStatus = new Logistics.WarehouseMobility.FTSLGetLaborBackFlushStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetLaborBackFlushStatusExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetLaborBackFlushStatus>(_FTSLGetLaborBackFlushStatus);
			
			return iFTSLGetLaborBackFlushStatusExt;
		}
	}
}
