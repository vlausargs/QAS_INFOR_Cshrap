//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAValidateResourceIdFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLTAValidateResourceIdFactory
	{
		public IFTSLTAValidateResourceId Create(IApplicationDB appDB)
		{
			var _FTSLTAValidateResourceId = new Logistics.WarehouseMobility.FTSLTAValidateResourceId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLTAValidateResourceIdExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLTAValidateResourceId>(_FTSLTAValidateResourceId);
			
			return iFTSLTAValidateResourceIdExt;
		}
	}
}
