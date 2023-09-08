//PROJECT NAME: CSIFinance
//CLASS NAME: CheckFiscalYearFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class CheckFiscalYearFactory
	{
		public ICheckFiscalYear Create(IApplicationDB appDB)
		{
			var _CheckFiscalYear = new Finance.CheckFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckFiscalYearExt = timerfactory.Create<Finance.ICheckFiscalYear>(_CheckFiscalYear);
			
			return iCheckFiscalYearExt;
		}
	}
}
