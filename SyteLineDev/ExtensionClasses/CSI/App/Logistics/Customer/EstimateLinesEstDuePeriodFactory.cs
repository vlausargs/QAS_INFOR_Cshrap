//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesEstDuePeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesEstDuePeriodFactory
	{
		public IEstimateLinesEstDuePeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstimateLinesEstDuePeriod = new Logistics.Customer.EstimateLinesEstDuePeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesEstDuePeriodExt = timerfactory.Create<Logistics.Customer.IEstimateLinesEstDuePeriod>(_EstimateLinesEstDuePeriod);
			
			return iEstimateLinesEstDuePeriodExt;
		}
	}
}
