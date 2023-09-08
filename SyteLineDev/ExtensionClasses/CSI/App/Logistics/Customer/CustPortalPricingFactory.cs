//PROJECT NAME: Logistics
//CLASS NAME: CustPortalPricingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustPortalPricingFactory
	{
		public ICustPortalPricing Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustPortalPricing = new Logistics.Customer.CustPortalPricing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustPortalPricingExt = timerfactory.Create<Logistics.Customer.ICustPortalPricing>(_CustPortalPricing);
			
			return iCustPortalPricingExt;
		}
	}
}
