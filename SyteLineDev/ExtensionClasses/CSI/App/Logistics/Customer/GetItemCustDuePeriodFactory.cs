//PROJECT NAME: Logistics
//CLASS NAME: GetItemCustDuePeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetItemCustDuePeriodFactory
	{
		public IGetItemCustDuePeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemCustDuePeriod = new Logistics.Customer.GetItemCustDuePeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemCustDuePeriodExt = timerfactory.Create<Logistics.Customer.IGetItemCustDuePeriod>(_GetItemCustDuePeriod);
			
			return iGetItemCustDuePeriodExt;
		}
	}
}
