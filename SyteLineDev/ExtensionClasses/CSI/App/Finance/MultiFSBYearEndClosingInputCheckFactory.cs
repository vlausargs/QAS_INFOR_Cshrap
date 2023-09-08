//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBYearEndClosingInputCheckFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBYearEndClosingInputCheckFactory
	{
		public IMultiFSBYearEndClosingInputCheck Create(IApplicationDB appDB)
		{
			var _MultiFSBYearEndClosingInputCheck = new Finance.MultiFSBYearEndClosingInputCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBYearEndClosingInputCheckExt = timerfactory.Create<Finance.IMultiFSBYearEndClosingInputCheck>(_MultiFSBYearEndClosingInputCheck);
			
			return iMultiFSBYearEndClosingInputCheckExt;
		}
	}
}
