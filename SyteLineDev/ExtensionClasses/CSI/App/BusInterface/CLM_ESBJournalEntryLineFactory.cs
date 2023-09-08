//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBJournalEntryLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBJournalEntryLineFactory
	{
		public ICLM_ESBJournalEntryLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBJournalEntryLine = new BusInterface.CLM_ESBJournalEntryLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBJournalEntryLineExt = timerfactory.Create<BusInterface.ICLM_ESBJournalEntryLine>(_CLM_ESBJournalEntryLine);
			
			return iCLM_ESBJournalEntryLineExt;
		}
	}
}
