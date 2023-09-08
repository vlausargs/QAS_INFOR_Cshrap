//PROJECT NAME: Production
//CLASS NAME: AutonomRevMsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class AutonomRevMsFactory
	{
		public IAutonomRevMs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AutonomRevMs = new Production.Projects.AutonomRevMs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutonomRevMsExt = timerfactory.Create<Production.Projects.IAutonomRevMs>(_AutonomRevMs);
			
			return iAutonomRevMsExt;
		}
	}
}
