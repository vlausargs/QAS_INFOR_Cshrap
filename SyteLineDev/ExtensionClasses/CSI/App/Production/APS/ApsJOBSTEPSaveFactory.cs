//PROJECT NAME: Production
//CLASS NAME: ApsJOBSTEPSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsJOBSTEPSaveFactory
	{
		public IApsJOBSTEPSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsJOBSTEPSave = new Production.APS.ApsJOBSTEPSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsJOBSTEPSaveExt = timerfactory.Create<Production.APS.IApsJOBSTEPSave>(_ApsJOBSTEPSave);
			
			return iApsJOBSTEPSaveExt;
		}
	}
}
