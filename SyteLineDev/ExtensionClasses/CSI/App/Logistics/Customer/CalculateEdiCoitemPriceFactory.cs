//PROJECT NAME: CSICustomer
//CLASS NAME: CalculateEdiCoitemPriceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalculateEdiCoitemPriceFactory
	{
		public ICalculateEdiCoitemPrice Create(IApplicationDB appDB)
		{
			var _CalculateEdiCoitemPrice = new Logistics.Customer.CalculateEdiCoitemPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalculateEdiCoitemPriceExt = timerfactory.Create<Logistics.Customer.ICalculateEdiCoitemPrice>(_CalculateEdiCoitemPrice);
			
			return iCalculateEdiCoitemPriceExt;
		}
	}
}
