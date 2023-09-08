//PROJECT NAME: Material
//CLASS NAME: ShippingLotValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ShippingLotValidFactory
	{
		public IShippingLotValid Create(IApplicationDB appDB)
		{
			var _ShippingLotValid = new Material.ShippingLotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShippingLotValidExt = timerfactory.Create<Material.IShippingLotValid>(_ShippingLotValid);
			
			return iShippingLotValidExt;
		}
	}
}
