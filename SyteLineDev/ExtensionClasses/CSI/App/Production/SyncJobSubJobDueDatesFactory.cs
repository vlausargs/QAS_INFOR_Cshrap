//PROJECT NAME: Production
//CLASS NAME: SyncJobSubJobDueDatesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SyncJobSubJobDueDatesFactory
	{
		public ISyncJobSubJobDueDates Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SyncJobSubJobDueDates = new Production.SyncJobSubJobDueDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSyncJobSubJobDueDatesExt = timerfactory.Create<Production.ISyncJobSubJobDueDates>(_SyncJobSubJobDueDates);
			
			return iSyncJobSubJobDueDatesExt;
		}
	}
}
