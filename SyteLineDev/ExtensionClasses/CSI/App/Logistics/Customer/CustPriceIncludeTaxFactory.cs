//PROJECT NAME: Logistics
//CLASS NAME: CustPriceIncludeTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustPriceIncludeTaxFactory
	{
		public ICustPriceIncludeTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustPriceIncludeTax = new Logistics.Customer.CustPriceIncludeTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustPriceIncludeTaxExt = timerfactory.Create<Logistics.Customer.ICustPriceIncludeTax>(_CustPriceIncludeTax);
			
			return iCustPriceIncludeTaxExt;
		}
	}
}
