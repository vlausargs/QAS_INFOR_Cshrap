//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTClearSessionTablesFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTTClearSessionTablesFactory
	{
		public IFTTTClearSessionTables Create(IApplicationDB appDB)
		{
			var _FTTTClearSessionTables = new Logistics.WarehouseMobility.FTTTClearSessionTables(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTTClearSessionTablesExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTTClearSessionTables>(_FTTTClearSessionTables);
			
			return iFTTTClearSessionTablesExt;
		}
	}
}
