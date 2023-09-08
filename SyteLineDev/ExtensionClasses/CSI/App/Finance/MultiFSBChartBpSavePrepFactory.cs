//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBChartBpSavePrepFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBChartBpSavePrepFactory
	{
		public IMultiFSBChartBpSavePrep Create(IApplicationDB appDB)
		{
			var _MultiFSBChartBpSavePrep = new Finance.MultiFSBChartBpSavePrep(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBChartBpSavePrepExt = timerfactory.Create<Finance.IMultiFSBChartBpSavePrep>(_MultiFSBChartBpSavePrep);
			
			return iMultiFSBChartBpSavePrepExt;
		}
	}
}
