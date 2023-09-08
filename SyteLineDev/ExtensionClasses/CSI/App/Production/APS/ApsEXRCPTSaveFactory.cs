//PROJECT NAME: Production
//CLASS NAME: ApsEXRCPTSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsEXRCPTSaveFactory
	{
		public IApsEXRCPTSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsEXRCPTSave = new Production.APS.ApsEXRCPTSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsEXRCPTSaveExt = timerfactory.Create<Production.APS.IApsEXRCPTSave>(_ApsEXRCPTSave);
			
			return iApsEXRCPTSaveExt;
		}
	}
}
