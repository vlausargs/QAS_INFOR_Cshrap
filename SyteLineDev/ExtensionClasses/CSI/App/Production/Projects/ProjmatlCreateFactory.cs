//PROJECT NAME: Production
//CLASS NAME: ProjmatlCreateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjmatlCreateFactory
	{
		public IProjmatlCreate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjmatlCreate = new Production.Projects.ProjmatlCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlCreateExt = timerfactory.Create<Production.Projects.IProjmatlCreate>(_ProjmatlCreate);
			
			return iProjmatlCreateExt;
		}
	}
}
