//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateIssueLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateIssueLotFactory
	{
		public IFTSLValidateIssueLot Create(IApplicationDB appDB)
		{
			var _FTSLValidateIssueLot = new Logistics.WarehouseMobility.FTSLValidateIssueLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateIssueLotExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateIssueLot>(_FTSLValidateIssueLot);
			
			return iFTSLValidateIssueLotExt;
		}
	}
}
