//PROJECT NAME: CSIProduct
//CLASS NAME: ItemChgRateFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ItemChgRateFactory
	{
		public IItemChgRate Create(IApplicationDB appDB)
		{
			var _ItemChgRate = new Production.ItemChgRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemChgRateExt = timerfactory.Create<Production.IItemChgRate>(_ItemChgRate);
			
			return iItemChgRateExt;
		}
	}
}
