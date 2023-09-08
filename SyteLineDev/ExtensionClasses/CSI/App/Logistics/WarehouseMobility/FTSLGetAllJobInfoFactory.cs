//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetAllJobInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetAllJobInfoFactory
	{
		public IFTSLGetAllJobInfo Create(IApplicationDB appDB)
		{
			var _FTSLGetAllJobInfo = new Logistics.WarehouseMobility.FTSLGetAllJobInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetAllJobInfoExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetAllJobInfo>(_FTSLGetAllJobInfo);
			
			return iFTSLGetAllJobInfoExt;
		}
	}
}
