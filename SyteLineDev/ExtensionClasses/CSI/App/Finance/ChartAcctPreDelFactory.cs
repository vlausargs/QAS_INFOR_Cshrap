//PROJECT NAME: CSIFinance
//CLASS NAME: ChartAcctPreDelFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ChartAcctPreDelFactory
	{
		public IChartAcctPreDel Create(IApplicationDB appDB)
		{
			var _ChartAcctPreDel = new Finance.ChartAcctPreDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChartAcctPreDelExt = timerfactory.Create<Finance.IChartAcctPreDel>(_ChartAcctPreDel);
			
			return iChartAcctPreDelExt;
		}
	}
}
