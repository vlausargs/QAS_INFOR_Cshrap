//PROJECT NAME: Production
//CLASS NAME: ApsSaveAPSOPTIONSFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsSaveAPSOPTIONSFactory
	{
		public IApsSaveAPSOPTIONS Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsSaveAPSOPTIONS = new Production.APS.ApsSaveAPSOPTIONS(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSaveAPSOPTIONSExt = timerfactory.Create<Production.APS.IApsSaveAPSOPTIONS>(_ApsSaveAPSOPTIONS);
			
			return iApsSaveAPSOPTIONSExt;
		}
	}
}
