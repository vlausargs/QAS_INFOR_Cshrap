//PROJECT NAME: Production
//CLASS NAME: Rpt_RevenueMilestoneProgressFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class Rpt_RevenueMilestoneProgressFactory
	{
		public IRpt_RevenueMilestoneProgress Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RevenueMilestoneProgress = new Production.Projects.Rpt_RevenueMilestoneProgress(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RevenueMilestoneProgressExt = timerfactory.Create<Production.Projects.IRpt_RevenueMilestoneProgress>(_Rpt_RevenueMilestoneProgress);
			
			return iRpt_RevenueMilestoneProgressExt;
		}
	}
}
