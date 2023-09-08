//PROJECT NAME: Production
//CLASS NAME: ProjGetMsPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjGetMsPeriodFactory
	{
		public IProjGetMsPeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjGetMsPeriod = new Production.Projects.ProjGetMsPeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjGetMsPeriodExt = timerfactory.Create<Production.Projects.IProjGetMsPeriod>(_ProjGetMsPeriod);
			
			return iProjGetMsPeriodExt;
		}

		public IProjGetMsPeriod Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var _ProjGetMsPeriod = new Production.Projects.ProjGetMsPeriod(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjGetMsPeriodExt = timerfactory.Create<Production.Projects.IProjGetMsPeriod>(_ProjGetMsPeriod);

			return iProjGetMsPeriodExt;
		}
	}
}
