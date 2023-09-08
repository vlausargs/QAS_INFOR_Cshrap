//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPaymentPostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARPaymentPostingFactory
	{
		public IRpt_ARPaymentPosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARPaymentPosting = new Reporting.Rpt_ARPaymentPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARPaymentPostingExt = timerfactory.Create<Reporting.IRpt_ARPaymentPosting>(_Rpt_ARPaymentPosting);
			
			return iRpt_ARPaymentPostingExt;
		}
	}
}
