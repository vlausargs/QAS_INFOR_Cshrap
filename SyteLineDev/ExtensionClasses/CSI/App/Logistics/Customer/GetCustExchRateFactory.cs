//PROJECT NAME: Logistics
//CLASS NAME: GetCustExchRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCustExchRateFactory
	{
		public IGetCustExchRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCustExchRate = new Logistics.Customer.GetCustExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustExchRateExt = timerfactory.Create<Logistics.Customer.IGetCustExchRate>(_GetCustExchRate);
			
			return iGetCustExchRateExt;
		}
	}
}
