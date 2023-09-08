//PROJECT NAME: Logistics
//CLASS NAME: SetPaymentAppliedAmtsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class SetPaymentAppliedAmtsFactory
	{
		public ISetPaymentAppliedAmts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetPaymentAppliedAmts = new Logistics.Customer.SetPaymentAppliedAmts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetPaymentAppliedAmtsExt = timerfactory.Create<Logistics.Customer.ISetPaymentAppliedAmts>(_SetPaymentAppliedAmts);
			
			return iSetPaymentAppliedAmtsExt;
		}
	}
}
