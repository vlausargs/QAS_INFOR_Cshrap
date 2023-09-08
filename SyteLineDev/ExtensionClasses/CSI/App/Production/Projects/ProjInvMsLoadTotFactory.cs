//PROJECT NAME: Production
//CLASS NAME: ProjInvMsLoadTotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjInvMsLoadTotFactory
	{
		public IProjInvMsLoadTot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjInvMsLoadTot = new Production.Projects.ProjInvMsLoadTot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjInvMsLoadTotExt = timerfactory.Create<Production.Projects.IProjInvMsLoadTot>(_ProjInvMsLoadTot);
			
			return iProjInvMsLoadTotExt;
		}

		public IProjInvMsLoadTot Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var _ProjInvMsLoadTot = new Production.Projects.ProjInvMsLoadTot(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjInvMsLoadTotExt = timerfactory.Create<Production.Projects.IProjInvMsLoadTot>(_ProjInvMsLoadTot);

			return iProjInvMsLoadTotExt;
		}
	}
}
