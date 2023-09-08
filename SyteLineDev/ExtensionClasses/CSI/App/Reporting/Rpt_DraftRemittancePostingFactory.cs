//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DraftRemittancePostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DraftRemittancePostingFactory
	{
		public IRpt_DraftRemittancePosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DraftRemittancePosting = new Reporting.Rpt_DraftRemittancePosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DraftRemittancePostingExt = timerfactory.Create<Reporting.IRpt_DraftRemittancePosting>(_Rpt_DraftRemittancePosting);
			
			return iRpt_DraftRemittancePostingExt;
		}
	}
}
