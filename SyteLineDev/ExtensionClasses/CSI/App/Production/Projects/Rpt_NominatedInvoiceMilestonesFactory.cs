//PROJECT NAME: Production
//CLASS NAME: Rpt_NominatedInvoiceMilestonesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class Rpt_NominatedInvoiceMilestonesFactory
	{
		public IRpt_NominatedInvoiceMilestones Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_NominatedInvoiceMilestones = new Production.Projects.Rpt_NominatedInvoiceMilestones(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_NominatedInvoiceMilestonesExt = timerfactory.Create<Production.Projects.IRpt_NominatedInvoiceMilestones>(_Rpt_NominatedInvoiceMilestones);
			
			return iRpt_NominatedInvoiceMilestonesExt;
		}
	}
}
