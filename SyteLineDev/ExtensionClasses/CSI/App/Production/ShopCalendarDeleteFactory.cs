//PROJECT NAME: Production
//CLASS NAME: ShopCalendarDeleteFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ShopCalendarDeleteFactory
	{
		public IShopCalendarDelete Create(IApplicationDB appDB)
		{
			var _ShopCalendarDelete = new Production.ShopCalendarDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShopCalendarDeleteExt = timerfactory.Create<Production.IShopCalendarDelete>(_ShopCalendarDelete);
			
			return iShopCalendarDeleteExt;
		}
	}
}
