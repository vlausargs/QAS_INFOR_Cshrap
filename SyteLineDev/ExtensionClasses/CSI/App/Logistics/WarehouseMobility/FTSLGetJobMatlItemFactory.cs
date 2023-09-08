//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetJobMatlItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetJobMatlItemFactory
	{
		public IFTSLGetJobMatlItem Create(IApplicationDB appDB)
		{
			var _FTSLGetJobMatlItem = new Logistics.WarehouseMobility.FTSLGetJobMatlItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetJobMatlItemExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetJobMatlItem>(_FTSLGetJobMatlItem);
			
			return iFTSLGetJobMatlItemExt;
		}
	}
}
