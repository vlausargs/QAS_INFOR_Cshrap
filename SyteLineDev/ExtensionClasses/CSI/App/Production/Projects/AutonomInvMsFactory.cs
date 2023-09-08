//PROJECT NAME: Production
//CLASS NAME: AutonomInvMsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class AutonomInvMsFactory
	{
		public IAutonomInvMs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AutonomInvMs = new Production.Projects.AutonomInvMs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutonomInvMsExt = timerfactory.Create<Production.Projects.IAutonomInvMs>(_AutonomInvMs);
			
			return iAutonomInvMsExt;
		}
	}
}
