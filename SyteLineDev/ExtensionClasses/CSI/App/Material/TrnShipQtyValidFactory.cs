//PROJECT NAME: Material
//CLASS NAME: TrnShipQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrnShipQtyValidFactory
	{
		public ITrnShipQtyValid Create(IApplicationDB appDB)
		{
			var _TrnShipQtyValid = new Material.TrnShipQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnShipQtyValidExt = timerfactory.Create<Material.ITrnShipQtyValid>(_TrnShipQtyValid);
			
			return iTrnShipQtyValidExt;
		}
	}
}
