//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLICValidateResourceIdFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLICValidateResourceIdFactory
	{
		public IFTSLICValidateResourceId Create(IApplicationDB appDB)
		{
			var _FTSLICValidateResourceId = new Logistics.WarehouseMobility.FTSLICValidateResourceId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLICValidateResourceIdExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLICValidateResourceId>(_FTSLICValidateResourceId);
			
			return iFTSLICValidateResourceIdExt;
		}
	}
}
