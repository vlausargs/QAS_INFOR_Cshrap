//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLLotValidateFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLLotValidateFactory
	{
		public IFTSLLotValidate Create(IApplicationDB appDB)
		{
			var _FTSLLotValidate = new Logistics.WarehouseMobility.FTSLLotValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLLotValidateExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLLotValidate>(_FTSLLotValidate);
			
			return iFTSLLotValidateExt;
		}
	}
}
