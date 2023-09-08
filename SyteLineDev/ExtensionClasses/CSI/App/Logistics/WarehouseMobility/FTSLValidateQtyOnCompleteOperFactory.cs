//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateQtyOnCompleteOperFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateQtyOnCompleteOperFactory
	{
		public IFTSLValidateQtyOnCompleteOper Create(IApplicationDB appDB)
		{
			var _FTSLValidateQtyOnCompleteOper = new Logistics.WarehouseMobility.FTSLValidateQtyOnCompleteOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateQtyOnCompleteOperExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateQtyOnCompleteOper>(_FTSLValidateQtyOnCompleteOper);
			
			return iFTSLValidateQtyOnCompleteOperExt;
		}
	}
}
