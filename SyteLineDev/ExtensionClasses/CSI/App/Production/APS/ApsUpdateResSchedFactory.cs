//PROJECT NAME: Production
//CLASS NAME: ApsUpdateResSchedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsUpdateResSchedFactory
	{
		public IApsUpdateResSched Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsUpdateResSched = new Production.APS.ApsUpdateResSched(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsUpdateResSchedExt = timerfactory.Create<Production.APS.IApsUpdateResSched>(_ApsUpdateResSched);
			
			return iApsUpdateResSchedExt;
		}
	}
}
