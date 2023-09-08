//PROJECT NAME: Logistics
//CLASS NAME: ValidatePriceItemCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidatePriceItemCustFactory
	{
		public IValidatePriceItemCust Create(IApplicationDB appDB)
		{
			var _ValidatePriceItemCust = new Logistics.Customer.ValidatePriceItemCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePriceItemCustExt = timerfactory.Create<Logistics.Customer.IValidatePriceItemCust>(_ValidatePriceItemCust);
			
			return iValidatePriceItemCustExt;
		}
	}
}
