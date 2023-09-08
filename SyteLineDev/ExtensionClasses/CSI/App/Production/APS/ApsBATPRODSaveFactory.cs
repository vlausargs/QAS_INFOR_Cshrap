//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsBATPRODSaveFactory
	{
		public IApsBATPRODSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsBATPRODSave = new Production.APS.ApsBATPRODSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATPRODSaveExt = timerfactory.Create<Production.APS.IApsBATPRODSave>(_ApsBATPRODSave);
			
			return iApsBATPRODSaveExt;
		}
	}
}
