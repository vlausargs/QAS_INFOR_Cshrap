//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetDisposalTransactionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetDisposalTransactionFactory
	{
		public IRpt_FixedAssetDisposalTransaction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetDisposalTransaction = new Reporting.Rpt_FixedAssetDisposalTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetDisposalTransactionExt = timerfactory.Create<Reporting.IRpt_FixedAssetDisposalTransaction>(_Rpt_FixedAssetDisposalTransaction);
			
			return iRpt_FixedAssetDisposalTransactionExt;
		}
	}
}
