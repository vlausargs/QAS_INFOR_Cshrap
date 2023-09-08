//PROJECT NAME: Finance
//CLASS NAME: MultiFSBGetCurPeriodBeginEndDateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBGetCurPeriodBeginEndDateFactory
	{
		public IMultiFSBGetCurPeriodBeginEndDate Create(IApplicationDB appDB)
		{
			var _MultiFSBGetCurPeriodBeginEndDate = new Finance.MultiFSBGetCurPeriodBeginEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBGetCurPeriodBeginEndDateExt = timerfactory.Create<Finance.IMultiFSBGetCurPeriodBeginEndDate>(_MultiFSBGetCurPeriodBeginEndDate);
			
			return iMultiFSBGetCurPeriodBeginEndDateExt;
		}
	}
}
