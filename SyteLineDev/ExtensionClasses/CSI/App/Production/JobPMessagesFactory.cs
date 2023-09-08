//PROJECT NAME: Production
//CLASS NAME: JobPMessagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobPMessagesFactory
	{
		public IJobPMessages Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobPMessages = new Production.JobPMessages(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobPMessagesExt = timerfactory.Create<Production.IJobPMessages>(_JobPMessages);
			
			return iJobPMessagesExt;
		}
	}
}
