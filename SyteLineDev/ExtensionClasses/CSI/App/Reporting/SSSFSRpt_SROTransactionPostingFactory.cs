//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROTransactionPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROTransactionPostingFactory
	{
		public ISSSFSRpt_SROTransactionPosting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROTransactionPosting = new Reporting.SSSFSRpt_SROTransactionPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROTransactionPostingExt = timerfactory.Create<Reporting.ISSSFSRpt_SROTransactionPosting>(_SSSFSRpt_SROTransactionPosting);
			
			return iSSSFSRpt_SROTransactionPostingExt;
		}
	}
}
