//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMGetActiveTransactionByEmployeeFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMGetActiveTransactionByEmployeeFactory
	{
		public IFTSLWMGetActiveTransactionByEmployee Create(IApplicationDB appDB)
		{
			var _FTSLWMGetActiveTransactionByEmployee = new Logistics.WarehouseMobility.FTSLWMGetActiveTransactionByEmployee(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMGetActiveTransactionByEmployeeExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMGetActiveTransactionByEmployee>(_FTSLWMGetActiveTransactionByEmployee);
			
			return iFTSLWMGetActiveTransactionByEmployeeExt;
		}
	}
}
