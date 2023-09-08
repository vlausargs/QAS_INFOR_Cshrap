//PROJECT NAME: Production
//CLASS NAME: GetAlternDatesFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GetAlternDatesFactory
	{
		public IGetAlternDates Create(IApplicationDB appDB)
		{
			var _GetAlternDates = new Production.APS.GetAlternDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAlternDatesExt = timerfactory.Create<Production.APS.IGetAlternDates>(_GetAlternDates);
			
			return iGetAlternDatesExt;
		}
	}
}
