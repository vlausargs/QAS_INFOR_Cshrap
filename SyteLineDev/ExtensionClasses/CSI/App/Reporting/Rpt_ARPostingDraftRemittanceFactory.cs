//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPostingDraftRemittanceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARPostingDraftRemittanceFactory
	{
		public IRpt_ARPostingDraftRemittance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARPostingDraftRemittance = new Reporting.Rpt_ARPostingDraftRemittance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARPostingDraftRemittanceExt = timerfactory.Create<Reporting.IRpt_ARPostingDraftRemittance>(_Rpt_ARPostingDraftRemittance);
			
			return iRpt_ARPostingDraftRemittanceExt;
		}
	}
}
