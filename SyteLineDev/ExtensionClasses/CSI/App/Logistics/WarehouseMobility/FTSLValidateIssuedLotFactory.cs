//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateIssuedLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateIssuedLotFactory
	{
		public IFTSLValidateIssuedLot Create(IApplicationDB appDB)
		{
			var _FTSLValidateIssuedLot = new Logistics.WarehouseMobility.FTSLValidateIssuedLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateIssuedLotExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateIssuedLot>(_FTSLValidateIssuedLot);
			
			return iFTSLValidateIssuedLotExt;
		}
	}
}
