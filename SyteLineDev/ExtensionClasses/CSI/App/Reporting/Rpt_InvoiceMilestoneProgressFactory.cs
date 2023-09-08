//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceMilestoneProgressFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceMilestoneProgressFactory
	{
		public IRpt_InvoiceMilestoneProgress Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceMilestoneProgress = new Reporting.Rpt_InvoiceMilestoneProgress(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceMilestoneProgressExt = timerfactory.Create<Reporting.IRpt_InvoiceMilestoneProgress>(_Rpt_InvoiceMilestoneProgress);
			
			return iRpt_InvoiceMilestoneProgressExt;
		}
	}
}
