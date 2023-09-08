//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPeriodsGetCurrentFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBPeriodsGetCurrentFactory
	{
		public IMultiFSBPeriodsGetCurrent Create(IApplicationDB appDB)
		{
			var _MultiFSBPeriodsGetCurrent = new Finance.MultiFSBPeriodsGetCurrent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBPeriodsGetCurrentExt = timerfactory.Create<Finance.IMultiFSBPeriodsGetCurrent>(_MultiFSBPeriodsGetCurrent);
			
			return iMultiFSBPeriodsGetCurrentExt;
		}
	}
}
