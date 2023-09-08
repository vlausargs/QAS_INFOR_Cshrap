//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBYearEndClosingFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBYearEndClosingFactory
	{
		public IMultiFSBYearEndClosing Create(IApplicationDB appDB)
		{
			var _MultiFSBYearEndClosing = new Finance.MultiFSBYearEndClosing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBYearEndClosingExt = timerfactory.Create<Finance.IMultiFSBYearEndClosing>(_MultiFSBYearEndClosing);
			
			return iMultiFSBYearEndClosingExt;
		}
	}
}
