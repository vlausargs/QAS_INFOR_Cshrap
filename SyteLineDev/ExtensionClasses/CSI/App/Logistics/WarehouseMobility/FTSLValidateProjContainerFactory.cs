//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateProjContainerFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateProjContainerFactory
	{
		public IFTSLValidateProjContainer Create(IApplicationDB appDB)
		{
			var _FTSLValidateProjContainer = new Logistics.WarehouseMobility.FTSLValidateProjContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateProjContainerExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateProjContainer>(_FTSLValidateProjContainer);
			
			return iFTSLValidateProjContainerExt;
		}
	}
}
