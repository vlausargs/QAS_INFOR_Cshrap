//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateComponentFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateComponentFactory
	{
		public IFTSLValidateComponent Create(IApplicationDB appDB)
		{
			var _FTSLValidateComponent = new Logistics.WarehouseMobility.FTSLValidateComponent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateComponentExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateComponent>(_FTSLValidateComponent);
			
			return iFTSLValidateComponentExt;
		}
	}
}
