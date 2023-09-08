//PROJECT NAME: Material
//CLASS NAME: PurgeEDIPlanningSchedulesFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PurgeEDIPlanningSchedulesFactory
	{
		public IPurgeEDIPlanningSchedules Create(IApplicationDB appDB)
		{
			var _PurgeEDIPlanningSchedules = new Material.PurgeEDIPlanningSchedules(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIPlanningSchedulesExt = timerfactory.Create<Material.IPurgeEDIPlanningSchedules>(_PurgeEDIPlanningSchedules);
			
			return iPurgeEDIPlanningSchedulesExt;
		}
	}
}
