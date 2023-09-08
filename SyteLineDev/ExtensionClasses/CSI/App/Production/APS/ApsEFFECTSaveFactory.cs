//PROJECT NAME: Production
//CLASS NAME: ApsEFFECTSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsEFFECTSaveFactory
	{
		public IApsEFFECTSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsEFFECTSave = new Production.APS.ApsEFFECTSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsEFFECTSaveExt = timerfactory.Create<Production.APS.IApsEFFECTSave>(_ApsEFFECTSave);
			
			return iApsEFFECTSaveExt;
		}
	}
}
