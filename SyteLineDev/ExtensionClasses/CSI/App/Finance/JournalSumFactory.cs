//PROJECT NAME: Finance
//CLASS NAME: JournalSumFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class JournalSumFactory
	{
		public IJournalSum Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _JournalSum = new Finance.JournalSum(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalSumExt = timerfactory.Create<Finance.IJournalSum>(_JournalSum);
			
			return iJournalSumExt;
		}
	}
}
