//PROJECT NAME: CSICustomer
//CLASS NAME: CoPriceIncludeTaxFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoPriceIncludeTaxFactory
	{
		public ICoPriceIncludeTax Create(IApplicationDB appDB)
		{
			var _CoPriceIncludeTax = new Logistics.Customer.CoPriceIncludeTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoPriceIncludeTaxExt = timerfactory.Create<Logistics.Customer.ICoPriceIncludeTax>(_CoPriceIncludeTax);
			
			return iCoPriceIncludeTaxExt;
		}
	}
}
