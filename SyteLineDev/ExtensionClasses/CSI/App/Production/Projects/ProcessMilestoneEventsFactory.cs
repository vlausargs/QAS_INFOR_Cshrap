//PROJECT NAME: Production
//CLASS NAME: ProcessMilestoneEventsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProcessMilestoneEventsFactory
	{
		public IProcessMilestoneEvents Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessMilestoneEvents = new Production.Projects.ProcessMilestoneEvents(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessMilestoneEventsExt = timerfactory.Create<Production.Projects.IProcessMilestoneEvents>(_ProcessMilestoneEvents);
			
			return iProcessMilestoneEventsExt;
		}
	}
}
