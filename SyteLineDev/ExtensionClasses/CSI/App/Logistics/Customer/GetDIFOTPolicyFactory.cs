//PROJECT NAME: Logistics
//CLASS NAME: GetDIFOTPolicyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetDIFOTPolicyFactory
	{
		public IGetDIFOTPolicy Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDIFOTPolicy = new Logistics.Customer.GetDIFOTPolicy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDIFOTPolicyExt = timerfactory.Create<Logistics.Customer.IGetDIFOTPolicy>(_GetDIFOTPolicy);
			
			return iGetDIFOTPolicyExt;
		}
	}
}
