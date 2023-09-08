//PROJECT NAME: Finance
//CLASS NAME: JournalNoTableLockJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalNoTableLockJobFactory
	{
		public IJournalNoTableLockJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalNoTableLockJob = new Finance.JournalNoTableLockJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalNoTableLockJobExt = timerfactory.Create<Finance.IJournalNoTableLockJob>(_JournalNoTableLockJob);
			
			return iJournalNoTableLockJobExt;
		}
	}
}
