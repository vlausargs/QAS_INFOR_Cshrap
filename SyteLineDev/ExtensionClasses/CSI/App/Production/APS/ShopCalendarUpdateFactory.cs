//PROJECT NAME: Production
//CLASS NAME: ShopCalendarUpdateFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ShopCalendarUpdateFactory
	{
		public IShopCalendarUpdate Create(IApplicationDB appDB)
		{
			var _ShopCalendarUpdate = new Production.APS.ShopCalendarUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShopCalendarUpdateExt = timerfactory.Create<Production.APS.IShopCalendarUpdate>(_ShopCalendarUpdate);
			
			return iShopCalendarUpdateExt;
		}
	}
}
