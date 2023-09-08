//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMStopOperationFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMStopOperationFactory
	{
		public IFTSLWMStopOperation Create(IApplicationDB appDB)
		{
			var _FTSLWMStopOperation = new Logistics.WarehouseMobility.FTSLWMStopOperation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMStopOperationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMStopOperation>(_FTSLWMStopOperation);
			
			return iFTSLWMStopOperationExt;
		}
	}
}
