//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBJournalTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBJournalTransactionFactory
	{
		public IRpt_MultiFSBJournalTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBJournalTransaction = new Reporting.Rpt_MultiFSBJournalTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBJournalTransactionExt = timerfactory.Create<Reporting.IRpt_MultiFSBJournalTransaction>(_Rpt_MultiFSBJournalTransaction);
			
			return iRpt_MultiFSBJournalTransactionExt;
		}
	}
}
