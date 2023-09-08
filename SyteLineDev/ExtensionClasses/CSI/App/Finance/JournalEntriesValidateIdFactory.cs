//PROJECT NAME: Finance
//CLASS NAME: JournalEntriesValidateIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalEntriesValidateIdFactory
	{
		public IJournalEntriesValidateId Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalEntriesValidateId = new Finance.JournalEntriesValidateId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalEntriesValidateIdExt = timerfactory.Create<Finance.IJournalEntriesValidateId>(_JournalEntriesValidateId);
			
			return iJournalEntriesValidateIdExt;
		}
	}
}
