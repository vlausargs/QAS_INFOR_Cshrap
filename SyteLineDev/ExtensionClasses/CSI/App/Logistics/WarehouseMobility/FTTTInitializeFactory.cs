//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTInitializeFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTTInitializeFactory
	{
		public IFTTTInitialize Create(IApplicationDB appDB)
		{
			var _FTTTInitialize = new Logistics.WarehouseMobility.FTTTInitialize(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTTInitializeExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTTInitialize>(_FTTTInitialize);
			
			return iFTTTInitializeExt;
		}
	}
}
