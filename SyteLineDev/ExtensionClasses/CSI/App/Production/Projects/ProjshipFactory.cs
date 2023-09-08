//PROJECT NAME: Production
//CLASS NAME: ProjshipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjshipFactory
	{
		public IProjship Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Projship = new Production.Projects.Projship(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjshipExt = timerfactory.Create<Production.Projects.IProjship>(_Projship);
			
			return iProjshipExt;
		}
	}
}
