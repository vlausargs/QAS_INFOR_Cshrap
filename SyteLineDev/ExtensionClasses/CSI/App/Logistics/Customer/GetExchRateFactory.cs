//PROJECT NAME: Logistics
//CLASS NAME: GetExchRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetExchRateFactory
	{
		public IGetExchRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetExchRate = new Logistics.Customer.GetExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetExchRateExt = timerfactory.Create<Logistics.Customer.IGetExchRate>(_GetExchRate);
			
			return iGetExchRateExt;
		}
	}
}
