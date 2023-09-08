//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JournalTransactionFactory
	{
		public IRpt_JournalTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JournalTransaction = new Reporting.Rpt_JournalTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JournalTransactionExt = timerfactory.Create<Reporting.IRpt_JournalTransaction>(_Rpt_JournalTransaction);
			
			return iRpt_JournalTransactionExt;
		}
	}
}
