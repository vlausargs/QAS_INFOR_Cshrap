//PROJECT NAME: CSIFinance
//CLASS NAME: FinRptLineCopyUpdateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineCopyUpdateFactory
	{
		public IFinRptLineCopyUpdate Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _FinRptLineCopyUpdate = new Finance.FinRptLineCopyUpdate(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptLineCopyUpdateExt = timerfactory.Create<Finance.IFinRptLineCopyUpdate>(_FinRptLineCopyUpdate);
			
			return iFinRptLineCopyUpdateExt;
		}
	}
}
