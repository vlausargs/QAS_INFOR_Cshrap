//PROJECT NAME: Logistics
//CLASS NAME: ArinvInvNumValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArinvInvNumValidateFactory
	{
		public IArinvInvNumValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArinvInvNumValidate = new Logistics.Customer.ArinvInvNumValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArinvInvNumValidateExt = timerfactory.Create<Logistics.Customer.IArinvInvNumValidate>(_ArinvInvNumValidate);
			
			return iArinvInvNumValidateExt;
		}
	}
}
