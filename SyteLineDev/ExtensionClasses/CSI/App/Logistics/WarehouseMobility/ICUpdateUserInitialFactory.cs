//PROJECT NAME: Logistics
//CLASS NAME: ICUpdateUserInitialFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class ICUpdateUserInitialFactory
	{
		public IICUpdateUserInitial Create(IApplicationDB appDB)
		{
			var _ICUpdateUserInitial = new Logistics.WarehouseMobility.ICUpdateUserInitial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iICUpdateUserInitialExt = timerfactory.Create<Logistics.WarehouseMobility.IICUpdateUserInitial>(_ICUpdateUserInitial);
			
			return iICUpdateUserInitialExt;
		}
	}
}
