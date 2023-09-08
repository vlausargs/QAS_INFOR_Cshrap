//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAGetOverHeadMachineFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLTAGetOverHeadMachineFactory
	{
		public IFTSLTAGetOverHeadMachine Create(IApplicationDB appDB)
		{
			var _FTSLTAGetOverHeadMachine = new Logistics.WarehouseMobility.FTSLTAGetOverHeadMachine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLTAGetOverHeadMachineExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLTAGetOverHeadMachine>(_FTSLTAGetOverHeadMachine);
			
			return iFTSLTAGetOverHeadMachineExt;
		}
	}
}
