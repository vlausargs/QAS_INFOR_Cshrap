//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBGetChartInfoFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBGetChartInfoFactory
	{
		public IMultiFSBGetChartInfo Create(IApplicationDB appDB)
		{
			var _MultiFSBGetChartInfo = new Finance.MultiFSBGetChartInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBGetChartInfoExt = timerfactory.Create<Finance.IMultiFSBGetChartInfo>(_MultiFSBGetChartInfo);
			
			return iMultiFSBGetChartInfoExt;
		}
	}
}
