//PROJECT NAME: Finance
//CLASS NAME: ProcessTmpMassJournalBulkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ProcessTmpMassJournalBulkFactory
	{
		public IProcessTmpMassJournalBulk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessTmpMassJournalBulk = new Finance.ProcessTmpMassJournalBulk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessTmpMassJournalBulkExt = timerfactory.Create<Finance.IProcessTmpMassJournalBulk>(_ProcessTmpMassJournalBulk);
			
			return iProcessTmpMassJournalBulkExt;
		}
	}
}
