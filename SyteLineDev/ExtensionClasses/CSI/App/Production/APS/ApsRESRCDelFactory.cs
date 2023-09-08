//PROJECT NAME: Production
//CLASS NAME: ApsRESRCDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsRESRCDelFactory
	{
		public IApsRESRCDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsRESRCDel = new Production.APS.ApsRESRCDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsRESRCDelExt = timerfactory.Create<Production.APS.IApsRESRCDel>(_ApsRESRCDel);
			
			return iApsRESRCDelExt;
		}
	}
}
