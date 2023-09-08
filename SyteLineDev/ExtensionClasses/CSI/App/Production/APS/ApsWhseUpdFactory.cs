//PROJECT NAME: Production
//CLASS NAME: ApsWhseUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseUpdFactory
	{
		public IApsWhseUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseUpd = new Production.APS.ApsWhseUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseUpdExt = timerfactory.Create<Production.APS.IApsWhseUpd>(_ApsWhseUpd);
			
			return iApsWhseUpdExt;
		}
	}
}
