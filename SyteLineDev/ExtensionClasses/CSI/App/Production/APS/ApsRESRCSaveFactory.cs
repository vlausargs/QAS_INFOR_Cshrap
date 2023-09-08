//PROJECT NAME: Production
//CLASS NAME: ApsRESRCSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsRESRCSaveFactory
	{
		public IApsRESRCSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsRESRCSave = new Production.APS.ApsRESRCSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsRESRCSaveExt = timerfactory.Create<Production.APS.IApsRESRCSave>(_ApsRESRCSave);
			
			return iApsRESRCSaveExt;
		}
	}
}
