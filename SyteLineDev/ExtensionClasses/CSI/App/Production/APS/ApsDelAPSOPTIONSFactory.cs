//PROJECT NAME: Production
//CLASS NAME: ApsDelAPSOPTIONSFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsDelAPSOPTIONSFactory
	{
		public IApsDelAPSOPTIONS Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsDelAPSOPTIONS = new Production.APS.ApsDelAPSOPTIONS(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsDelAPSOPTIONSExt = timerfactory.Create<Production.APS.IApsDelAPSOPTIONS>(_ApsDelAPSOPTIONS);
			
			return iApsDelAPSOPTIONSExt;
		}
	}
}
