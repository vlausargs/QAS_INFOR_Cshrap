//PROJECT NAME: Production
//CLASS NAME: ApsEXRCPTDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsEXRCPTDelFactory
	{
		public IApsEXRCPTDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsEXRCPTDel = new Production.APS.ApsEXRCPTDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsEXRCPTDelExt = timerfactory.Create<Production.APS.IApsEXRCPTDel>(_ApsEXRCPTDel);
			
			return iApsEXRCPTDelExt;
		}
	}
}
