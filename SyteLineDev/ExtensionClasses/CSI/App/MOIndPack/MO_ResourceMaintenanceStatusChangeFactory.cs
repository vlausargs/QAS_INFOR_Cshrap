//PROJECT NAME: CSIMOIndPack
//CLASS NAME: MO_ResourceMaintenanceStatusChangeFactory.cs

using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_ResourceMaintenanceStatusChangeFactory
	{
		public IMO_ResourceMaintenanceStatusChange Create(IApplicationDB appDB)
		{
			var _MO_ResourceMaintenanceStatusChange = new MOIndPack.MO_ResourceMaintenanceStatusChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceMaintenanceStatusChangeExt = timerfactory.Create<MOIndPack.IMO_ResourceMaintenanceStatusChange>(_MO_ResourceMaintenanceStatusChange);
			
			return iMO_ResourceMaintenanceStatusChangeExt;
		}
	}
}
