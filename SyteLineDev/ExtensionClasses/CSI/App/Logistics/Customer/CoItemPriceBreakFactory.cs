//PROJECT NAME: CSICustomer
//CLASS NAME: CoItemPriceBreakFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoItemPriceBreakFactory
	{
		public ICoItemPriceBreak Create(IApplicationDB appDB)
		{
			var _CoItemPriceBreak = new Logistics.Customer.CoItemPriceBreak(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoItemPriceBreakExt = timerfactory.Create<Logistics.Customer.ICoItemPriceBreak>(_CoItemPriceBreak);
			
			return iCoItemPriceBreakExt;
		}
	}
}
