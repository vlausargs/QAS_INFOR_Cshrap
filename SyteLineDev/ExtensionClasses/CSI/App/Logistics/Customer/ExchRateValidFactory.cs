//PROJECT NAME: Logistics
//CLASS NAME: ExchRateValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ExchRateValidFactory
	{
		public IExchRateValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ExchRateValid = new Logistics.Customer.ExchRateValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExchRateValidExt = timerfactory.Create<Logistics.Customer.IExchRateValid>(_ExchRateValid);
			
			return iExchRateValidExt;
		}
	}
}
