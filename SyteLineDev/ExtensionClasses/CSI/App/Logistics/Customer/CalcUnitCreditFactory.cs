//PROJECT NAME: Logistics
//CLASS NAME: CalcUnitCreditFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CalcUnitCreditFactory
	{
		public ICalcUnitCredit Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcUnitCredit = new Logistics.Customer.CalcUnitCredit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcUnitCreditExt = timerfactory.Create<Logistics.Customer.ICalcUnitCredit>(_CalcUnitCredit);
			
			return iCalcUnitCreditExt;
		}
	}
}
