//PROJECT NAME: Production
//CLASS NAME: ShopCalendarSaveFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ShopCalendarSaveFactory
	{
		public IShopCalendarSave Create(IApplicationDB appDB)
		{
			var _ShopCalendarSave = new Production.ShopCalendarSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShopCalendarSaveExt = timerfactory.Create<Production.IShopCalendarSave>(_ShopCalendarSave);
			
			return iShopCalendarSaveExt;
		}
	}
}
