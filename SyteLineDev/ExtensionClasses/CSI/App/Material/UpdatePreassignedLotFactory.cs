//PROJECT NAME: Material
//CLASS NAME: UpdatePreassignedLotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdatePreassignedLotFactory
	{
		public IUpdatePreassignedLot Create(IApplicationDB appDB)
		{
			var _UpdatePreassignedLot = new Material.UpdatePreassignedLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePreassignedLotExt = timerfactory.Create<Material.IUpdatePreassignedLot>(_UpdatePreassignedLot);
			
			return iUpdatePreassignedLotExt;
		}
	}
}
