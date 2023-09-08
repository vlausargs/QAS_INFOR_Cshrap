//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLLabelCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLLabelCountFactory
	{
		public IFTSLLabelCount Create(IApplicationDB appDB)
		{
			var _FTSLLabelCount = new Logistics.WarehouseMobility.FTSLLabelCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLLabelCountExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLLabelCount>(_FTSLLabelCount);
			
			return iFTSLLabelCountExt;
		}
	}
}
