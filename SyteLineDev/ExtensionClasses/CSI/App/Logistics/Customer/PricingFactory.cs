//PROJECT NAME: Logistics
//CLASS NAME: PricingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PricingFactory
	{
		public IPricing Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Pricing = new Logistics.Customer.Pricing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPricingExt = timerfactory.Create<Logistics.Customer.IPricing>(_Pricing);
			
			return iPricingExt;
		}
	}
}
