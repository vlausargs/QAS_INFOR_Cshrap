//PROJECT NAME: Finance
//CLASS NAME: TTJournalLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class TTJournalLoadFactory
	{
		public ITTJournalLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TTJournalLoad = new Finance.TTJournalLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalLoadExt = timerfactory.Create<Finance.ITTJournalLoad>(_TTJournalLoad);
			
			return iTTJournalLoadExt;
		}
	}
}
