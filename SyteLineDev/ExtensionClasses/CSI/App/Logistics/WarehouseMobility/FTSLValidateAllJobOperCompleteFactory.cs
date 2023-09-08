//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateAllJobOperCompleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateAllJobOperCompleteFactory
	{
		public IFTSLValidateAllJobOperComplete Create(IApplicationDB appDB)
		{
			var _FTSLValidateAllJobOperComplete = new Logistics.WarehouseMobility.FTSLValidateAllJobOperComplete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateAllJobOperCompleteExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateAllJobOperComplete>(_FTSLValidateAllJobOperComplete);
			
			return iFTSLValidateAllJobOperCompleteExt;
		}
	}
}
