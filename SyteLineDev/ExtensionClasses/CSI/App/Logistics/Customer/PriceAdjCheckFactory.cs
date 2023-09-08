//PROJECT NAME: CSICustomer
//CLASS NAME: PriceAdjCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PriceAdjCheckFactory
	{
		public IPriceAdjCheck Create(IApplicationDB appDB)
		{
			var _PriceAdjCheck = new Logistics.Customer.PriceAdjCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPriceAdjCheckExt = timerfactory.Create<Logistics.Customer.IPriceAdjCheck>(_PriceAdjCheck);
			
			return iPriceAdjCheckExt;
		}
	}
}
