//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APVoucherPostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APVoucherPostingFactory
	{
		public IRpt_APVoucherPosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APVoucherPosting = new Reporting.Rpt_APVoucherPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APVoucherPostingExt = timerfactory.Create<Reporting.IRpt_APVoucherPosting>(_Rpt_APVoucherPosting);
			
			return iRpt_APVoucherPostingExt;
		}
	}
}
