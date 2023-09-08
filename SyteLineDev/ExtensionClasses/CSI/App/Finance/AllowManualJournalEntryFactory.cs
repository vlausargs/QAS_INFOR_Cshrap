//PROJECT NAME: Finance
//CLASS NAME: AllowManualJournalEntryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class AllowManualJournalEntryFactory
	{
		public IAllowManualJournalEntry Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AllowManualJournalEntry = new Finance.AllowManualJournalEntry(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAllowManualJournalEntryExt = timerfactory.Create<Finance.IAllowManualJournalEntry>(_AllowManualJournalEntry);
			
			return iAllowManualJournalEntryExt;
		}
	}
}
