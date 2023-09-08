//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateJobLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateJobLotFactory
	{
		public IFTSLValidateJobLot Create(IApplicationDB appDB)
		{
			var _FTSLValidateJobLot = new Logistics.WarehouseMobility.FTSLValidateJobLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateJobLotExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateJobLot>(_FTSLValidateJobLot);
			
			return iFTSLValidateJobLotExt;
		}
	}
}
