//PROJECT NAME: CSIProduct
//CLASS NAME: CalcSubJobDatesFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CalcSubJobDatesFactory
	{
		public ICalcSubJobDates Create(IApplicationDB appDB)
		{
			var _CalcSubJobDates = new Production.CalcSubJobDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcSubJobDatesExt = timerfactory.Create<Production.ICalcSubJobDates>(_CalcSubJobDates);
			
			return iCalcSubJobDatesExt;
		}
	}
}
