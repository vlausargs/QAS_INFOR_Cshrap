//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARDirectDebitPostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARDirectDebitPostingFactory
	{
		public IRpt_ARDirectDebitPosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARDirectDebitPosting = new Reporting.Rpt_ARDirectDebitPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARDirectDebitPostingExt = timerfactory.Create<Reporting.IRpt_ARDirectDebitPosting>(_Rpt_ARDirectDebitPosting);
			
			return iRpt_ARDirectDebitPostingExt;
		}
	}
}
