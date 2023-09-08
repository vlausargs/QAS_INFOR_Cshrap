//PROJECT NAME: Finance
//CLASS NAME: ImportJournalEntriesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ImportJournalEntriesFactory
	{
		public IImportJournalEntries Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ImportJournalEntries = new Finance.ImportJournalEntries(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iImportJournalEntriesExt = timerfactory.Create<Finance.IImportJournalEntries>(_ImportJournalEntries);
			
			return iImportJournalEntriesExt;
		}
	}
}
