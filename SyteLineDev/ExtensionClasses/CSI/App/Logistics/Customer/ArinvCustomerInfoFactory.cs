//PROJECT NAME: Logistics
//CLASS NAME: ArinvCustomerInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArinvCustomerInfoFactory
	{
		public IArinvCustomerInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArinvCustomerInfo = new Logistics.Customer.ArinvCustomerInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArinvCustomerInfoExt = timerfactory.Create<Logistics.Customer.IArinvCustomerInfo>(_ArinvCustomerInfo);
			
			return iArinvCustomerInfoExt;
		}
	}
}
