//PROJECT NAME: Logistics
//CLASS NAME: CalcUpdCOFreightChargeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CalcUpdCOFreightChargeFactory
	{
		public ICalcUpdCOFreightCharge Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcUpdCOFreightCharge = new Logistics.Customer.CalcUpdCOFreightCharge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcUpdCOFreightChargeExt = timerfactory.Create<Logistics.Customer.ICalcUpdCOFreightCharge>(_CalcUpdCOFreightCharge);
			
			return iCalcUpdCOFreightChargeExt;
		}
	}
}
