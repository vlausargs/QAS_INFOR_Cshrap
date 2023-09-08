//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APPostingDraftRemittanceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APPostingDraftRemittanceFactory
	{
		public IRpt_APPostingDraftRemittance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APPostingDraftRemittance = new Reporting.Rpt_APPostingDraftRemittance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APPostingDraftRemittanceExt = timerfactory.Create<Reporting.IRpt_APPostingDraftRemittance>(_Rpt_APPostingDraftRemittance);
			
			return iRpt_APPostingDraftRemittanceExt;
		}
	}
}
