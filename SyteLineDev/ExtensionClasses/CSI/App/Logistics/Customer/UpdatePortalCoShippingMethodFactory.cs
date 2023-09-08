//PROJECT NAME: Logistics
//CLASS NAME: UpdatePortalCoShippingMethodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdatePortalCoShippingMethodFactory
	{
		public IUpdatePortalCoShippingMethod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdatePortalCoShippingMethod = new Logistics.Customer.UpdatePortalCoShippingMethod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePortalCoShippingMethodExt = timerfactory.Create<Logistics.Customer.IUpdatePortalCoShippingMethod>(_UpdatePortalCoShippingMethod);
			
			return iUpdatePortalCoShippingMethodExt;
		}
	}
}
