//PROJECT NAME: Logistics
//CLASS NAME: GetParmDuePeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetParmDuePeriodFactory
	{
		public IGetParmDuePeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetParmDuePeriod = new Logistics.Customer.GetParmDuePeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmDuePeriodExt = timerfactory.Create<Logistics.Customer.IGetParmDuePeriod>(_GetParmDuePeriod);
			
			return iGetParmDuePeriodExt;
		}
	}
}
