//PROJECT NAME: Finance
//CLASS NAME: PostedTrnsAcctSummFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class PostedTrnsAcctSummFactory
	{
		public IPostedTrnsAcctSumm Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PostedTrnsAcctSumm = new Finance.PostedTrnsAcctSumm(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostedTrnsAcctSummExt = timerfactory.Create<Finance.IPostedTrnsAcctSumm>(_PostedTrnsAcctSumm);
			
			return iPostedTrnsAcctSummExt;
		}
	}
}
