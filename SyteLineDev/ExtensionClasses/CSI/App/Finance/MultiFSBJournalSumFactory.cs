//PROJECT NAME: Finance
//CLASS NAME: MultiFSBJournalSumFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class MultiFSBJournalSumFactory
	{
		public IMultiFSBJournalSum Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MultiFSBJournalSum = new Finance.MultiFSBJournalSum(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBJournalSumExt = timerfactory.Create<Finance.IMultiFSBJournalSum>(_MultiFSBJournalSum);
			
			return iMultiFSBJournalSumExt;
		}
	}
}
