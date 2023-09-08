//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateResourceByGroupFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateResourceByGroupFactory
	{
		public IFTSLValidateResourceByGroup Create(IApplicationDB appDB)
		{
			var _FTSLValidateResourceByGroup = new Logistics.WarehouseMobility.FTSLValidateResourceByGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateResourceByGroupExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateResourceByGroup>(_FTSLValidateResourceByGroup);
			
			return iFTSLValidateResourceByGroupExt;
		}
	}
}
