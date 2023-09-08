//PROJECT NAME: Material
//CLASS NAME: RValLotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RValLotFactory
	{
		public IRValLot Create(IApplicationDB appDB)
		{
			var _RValLot = new Material.RValLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRValLotExt = timerfactory.Create<Material.IRValLot>(_RValLot);
			
			return iRValLotExt;
		}
	}
}
