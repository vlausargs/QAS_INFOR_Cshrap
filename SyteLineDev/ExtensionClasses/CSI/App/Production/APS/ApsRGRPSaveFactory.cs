//PROJECT NAME: Production
//CLASS NAME: ApsRGRPSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsRGRPSaveFactory
	{
		public IApsRGRPSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsRGRPSave = new Production.APS.ApsRGRPSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsRGRPSaveExt = timerfactory.Create<Production.APS.IApsRGRPSave>(_ApsRGRPSave);
			
			return iApsRGRPSaveExt;
		}
	}
}
