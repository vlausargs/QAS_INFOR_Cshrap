//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTInsertJobFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTTInsertJobFactory
	{
		public IFTTTInsertJob Create(IApplicationDB appDB)
		{
			var _FTTTInsertJob = new Logistics.WarehouseMobility.FTTTInsertJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTTInsertJobExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTTInsertJob>(_FTTTInsertJob);
			
			return iFTTTInsertJobExt;
		}
	}
}
