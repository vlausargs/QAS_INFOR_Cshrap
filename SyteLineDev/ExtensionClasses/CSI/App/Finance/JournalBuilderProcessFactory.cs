//PROJECT NAME: Finance
//CLASS NAME: JournalBuilderProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalBuilderProcessFactory
	{
		public IJournalBuilderProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalBuilderProcess = new Finance.JournalBuilderProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalBuilderProcessExt = timerfactory.Create<Finance.IJournalBuilderProcess>(_JournalBuilderProcess);
			
			return iJournalBuilderProcessExt;
		}
	}
}
