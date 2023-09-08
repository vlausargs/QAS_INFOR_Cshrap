//PROJECT NAME: CSIFinance
//CLASS NAME: PeriodsGetCurrentFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsGetCurrentFactory
	{
		public IPeriodsGetCurrent Create(IApplicationDB appDB)
		{
			var _PeriodsGetCurrent = new Finance.PeriodsGetCurrent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPeriodsGetCurrentExt = timerfactory.Create<Finance.IPeriodsGetCurrent>(_PeriodsGetCurrent);
			
			return iPeriodsGetCurrentExt;
		}
	}
}
