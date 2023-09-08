//PROJECT NAME: Finance
//CLASS NAME: MultiFSBCheckFiscalYearFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBCheckFiscalYearFactory
	{
		public IMultiFSBCheckFiscalYear Create(IApplicationDB appDB)
		{
			var _MultiFSBCheckFiscalYear = new Finance.MultiFSBCheckFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBCheckFiscalYearExt = timerfactory.Create<Finance.IMultiFSBCheckFiscalYear>(_MultiFSBCheckFiscalYear);
			
			return iMultiFSBCheckFiscalYearExt;
		}
	}
}
