//PROJECT NAME: Material
//CLASS NAME: ItemPortalPriceFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemPortalPriceFactory
	{
		public IItemPortalPrice Create(IApplicationDB appDB)
		{
			var _ItemPortalPrice = new Material.ItemPortalPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemPortalPriceExt = timerfactory.Create<Material.IItemPortalPrice>(_ItemPortalPrice);
			
			return iItemPortalPriceExt;
		}
	}
}
