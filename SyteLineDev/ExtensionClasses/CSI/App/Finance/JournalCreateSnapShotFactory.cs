//PROJECT NAME: Finance
//CLASS NAME: JournalCreateSnapShotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalCreateSnapShotFactory
	{
		public IJournalCreateSnapShot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalCreateSnapShot = new Finance.JournalCreateSnapShot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalCreateSnapShotExt = timerfactory.Create<Finance.IJournalCreateSnapShot>(_JournalCreateSnapShot);
			
			return iJournalCreateSnapShotExt;
		}
	}
}
