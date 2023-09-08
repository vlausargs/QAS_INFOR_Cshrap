//PROJECT NAME: Logistics
//CLASS NAME: GetFutureSalesPeriodsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetFutureSalesPeriodsFactory
	{
		public IGetFutureSalesPeriods Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetFutureSalesPeriods = new Logistics.Customer.GetFutureSalesPeriods(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFutureSalesPeriodsExt = timerfactory.Create<Logistics.Customer.IGetFutureSalesPeriods>(_GetFutureSalesPeriods);
			
			return iGetFutureSalesPeriodsExt;
		}
	}
}
