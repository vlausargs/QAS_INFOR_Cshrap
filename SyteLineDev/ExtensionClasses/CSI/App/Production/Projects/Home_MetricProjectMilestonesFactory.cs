//PROJECT NAME: Production
//CLASS NAME: Home_MetricProjectMilestonesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class Home_MetricProjectMilestonesFactory
	{
		public IHome_MetricProjectMilestones Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricProjectMilestones = new Production.Projects.Home_MetricProjectMilestones(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricProjectMilestonesExt = timerfactory.Create<Production.Projects.IHome_MetricProjectMilestones>(_Home_MetricProjectMilestones);
			
			return iHome_MetricProjectMilestonesExt;
		}
	}
}
