//PROJECT NAME: Logistics
//CLASS NAME: ArpmtGetCurrentExchangeRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtGetCurrentExchangeRateFactory
	{
		public IArpmtGetCurrentExchangeRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtGetCurrentExchangeRate = new Logistics.Customer.ArpmtGetCurrentExchangeRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtGetCurrentExchangeRateExt = timerfactory.Create<Logistics.Customer.IArpmtGetCurrentExchangeRate>(_ArpmtGetCurrentExchangeRate);
			
			return iArpmtGetCurrentExchangeRateExt;
		}
	}
}
