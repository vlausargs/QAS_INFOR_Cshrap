//PROJECT NAME: Logistics
//CLASS NAME: PriceCalFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PriceCalFactory
	{
		public IPriceCal Create(IApplicationDB appDB)
		{
			var _PriceCal = new Logistics.Customer.PriceCal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPriceCalExt = timerfactory.Create<Logistics.Customer.IPriceCal>(_PriceCal);
			
			return iPriceCalExt;
		}
	}
}
