//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetTimeInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetTimeInfoFactory
	{
		public IFTSLGetTimeInfo Create(IApplicationDB appDB)
		{
			var _FTSLGetTimeInfo = new Logistics.WarehouseMobility.FTSLGetTimeInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetTimeInfoExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetTimeInfo>(_FTSLGetTimeInfo);
			
			return iFTSLGetTimeInfoExt;
		}
	}
}
