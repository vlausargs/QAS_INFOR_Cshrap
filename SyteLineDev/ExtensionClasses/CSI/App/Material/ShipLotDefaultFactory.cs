//PROJECT NAME: Material
//CLASS NAME: ShipLotDefaultFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ShipLotDefaultFactory
	{
		public IShipLotDefault Create(IApplicationDB appDB)
		{
			var _ShipLotDefault = new Material.ShipLotDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipLotDefaultExt = timerfactory.Create<Material.IShipLotDefault>(_ShipLotDefault);
			
			return iShipLotDefaultExt;
		}
	}
}
