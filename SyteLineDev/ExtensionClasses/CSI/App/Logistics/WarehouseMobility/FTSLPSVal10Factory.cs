//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLPSVal10Factory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLPSVal10Factory
	{
		public IFTSLPSVal10 Create(IApplicationDB appDB)
		{
			var _FTSLPSVal10 = new Logistics.WarehouseMobility.FTSLPSVal10(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLPSVal10Ext = timerfactory.Create<Logistics.WarehouseMobility.IFTSLPSVal10>(_FTSLPSVal10);
			
			return iFTSLPSVal10Ext;
		}
	}
}
