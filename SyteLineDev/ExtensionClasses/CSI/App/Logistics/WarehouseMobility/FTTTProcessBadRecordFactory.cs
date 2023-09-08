//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTProcessBadRecordFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTTProcessBadRecordFactory
	{
		public IFTTTProcessBadRecord Create(IApplicationDB appDB)
		{
			var _FTTTProcessBadRecord = new Logistics.WarehouseMobility.FTTTProcessBadRecord(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTTProcessBadRecordExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTTProcessBadRecord>(_FTTTProcessBadRecord);
			
			return iFTTTProcessBadRecordExt;
		}
	}
}
