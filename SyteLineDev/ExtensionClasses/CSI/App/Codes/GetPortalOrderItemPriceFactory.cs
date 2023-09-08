//PROJECT NAME: CSICodes
//CLASS NAME: GetPortalOrderItemPriceFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetPortalOrderItemPriceFactory
	{
		public IGetPortalOrderItemPrice Create(IApplicationDB appDB)
		{
			var _GetPortalOrderItemPrice = new Codes.GetPortalOrderItemPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPortalOrderItemPriceExt = timerfactory.Create<Codes.IGetPortalOrderItemPrice>(_GetPortalOrderItemPrice);
			
			return iGetPortalOrderItemPriceExt;
		}
	}
}
