//PROJECT NAME: Logistics
//CLASS NAME: CalcARGainLossFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CalcARGainLossFactory
	{
		public ICalcARGainLoss Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcARGainLoss = new Logistics.Customer.CalcARGainLoss(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcARGainLossExt = timerfactory.Create<Logistics.Customer.ICalcARGainLoss>(_CalcARGainLoss);
			
			return iCalcARGainLossExt;
		}
	}
}
