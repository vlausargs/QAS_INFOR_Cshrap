//PROJECT NAME: Adapters
//CLASS NAME: CalcCurrRateExpireDateFactory.cs

using CSI.MG;

namespace CSI.Adapters
{
	public class CalcCurrRateExpireDateFactory
	{
		public ICalcCurrRateExpireDate Create(IApplicationDB appDB)
		{
			var _CalcCurrRateExpireDate = new Adapters.CalcCurrRateExpireDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcCurrRateExpireDateExt = timerfactory.Create<Adapters.ICalcCurrRateExpireDate>(_CalcCurrRateExpireDate);
			
			return iCalcCurrRateExpireDateExt;
		}
	}
}
