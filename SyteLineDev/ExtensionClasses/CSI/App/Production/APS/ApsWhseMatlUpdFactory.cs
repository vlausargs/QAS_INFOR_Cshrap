//PROJECT NAME: Production
//CLASS NAME: ApsWhseMatlUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseMatlUpdFactory
	{
		public IApsWhseMatlUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseMatlUpd = new Production.APS.ApsWhseMatlUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseMatlUpdExt = timerfactory.Create<Production.APS.IApsWhseMatlUpd>(_ApsWhseMatlUpd);
			
			return iApsWhseMatlUpdExt;
		}
	}
}
