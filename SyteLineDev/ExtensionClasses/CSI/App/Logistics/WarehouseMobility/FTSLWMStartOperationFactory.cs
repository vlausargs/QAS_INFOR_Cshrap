//PROJECT NAME: Logistics
//CLASS NAME: FTSLWMStartOperationFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMStartOperationFactory
	{
		public IFTSLWMStartOperation Create(IApplicationDB appDB)
		{
			var _FTSLWMStartOperation = new Logistics.WarehouseMobility.FTSLWMStartOperation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMStartOperationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMStartOperation>(_FTSLWMStartOperation);
			
			return iFTSLWMStartOperationExt;
		}
	}
}
