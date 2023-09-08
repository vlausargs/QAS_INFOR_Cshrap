//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetSLTrnOrderPrefixFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetSLTrnOrderPrefixFactory
	{
		public IFTSLGetSLTrnOrderPrefix Create(IApplicationDB appDB)
		{
			var _FTSLGetSLTrnOrderPrefix = new Logistics.WarehouseMobility.FTSLGetSLTrnOrderPrefix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetSLTrnOrderPrefixExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetSLTrnOrderPrefix>(_FTSLGetSLTrnOrderPrefix);
			
			return iFTSLGetSLTrnOrderPrefixExt;
		}
	}
}
