//PROJECT NAME: Logistics
//CLASS NAME: FTSLItemValidateFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLItemValidateFactory
	{
		public IFTSLItemValidate Create(IApplicationDB appDB)
		{
			var _FTSLItemValidate = new Logistics.WarehouseMobility.FTSLItemValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLItemValidateExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLItemValidate>(_FTSLItemValidate);
			
			return iFTSLItemValidateExt;
		}
	}
}
