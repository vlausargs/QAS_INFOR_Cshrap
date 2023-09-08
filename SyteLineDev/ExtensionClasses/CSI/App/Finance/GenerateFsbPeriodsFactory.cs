//PROJECT NAME: Finance
//CLASS NAME: GenerateFsbPeriodsFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GenerateFsbPeriodsFactory
	{
		public IGenerateFsbPeriods Create(IApplicationDB appDB)
		{
			var _GenerateFsbPeriods = new Finance.GenerateFsbPeriods(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateFsbPeriodsExt = timerfactory.Create<Finance.IGenerateFsbPeriods>(_GenerateFsbPeriods);
			
			return iGenerateFsbPeriodsExt;
		}
	}
}
