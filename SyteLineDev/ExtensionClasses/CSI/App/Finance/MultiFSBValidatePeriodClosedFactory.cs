//PROJECT NAME: Finance
//CLASS NAME: MultiFSBValidatePeriodClosedFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBValidatePeriodClosedFactory
	{
		public IMultiFSBValidatePeriodClosed Create(IApplicationDB appDB)
		{
			var _MultiFSBValidatePeriodClosed = new Finance.MultiFSBValidatePeriodClosed(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBValidatePeriodClosedExt = timerfactory.Create<Finance.IMultiFSBValidatePeriodClosed>(_MultiFSBValidatePeriodClosed);
			
			return iMultiFSBValidatePeriodClosedExt;
		}
	}
}
