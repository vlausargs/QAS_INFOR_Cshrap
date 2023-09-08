//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBJournalEntryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBJournalEntryFactory
	{
		public ICLM_ESBJournalEntry Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBJournalEntry = new BusInterface.CLM_ESBJournalEntry(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBJournalEntryExt = timerfactory.Create<BusInterface.ICLM_ESBJournalEntry>(_CLM_ESBJournalEntry);
			
			return iCLM_ESBJournalEntryExt;
		}
	}
}
