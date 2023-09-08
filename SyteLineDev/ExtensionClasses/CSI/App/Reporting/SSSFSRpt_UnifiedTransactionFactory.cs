//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_UnifiedTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_UnifiedTransactionFactory
	{
		public ISSSFSRpt_UnifiedTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_UnifiedTransaction = new Reporting.SSSFSRpt_UnifiedTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_UnifiedTransactionExt = timerfactory.Create<Reporting.ISSSFSRpt_UnifiedTransaction>(_SSSFSRpt_UnifiedTransaction);
			
			return iSSSFSRpt_UnifiedTransactionExt;
		}
	}
}
