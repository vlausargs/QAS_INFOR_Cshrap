//PROJECT NAME: Production
//CLASS NAME: GetLocalServerServiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class GetLocalServerServiceFactory
	{
		public IGetLocalServerService Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetLocalServerService = new Production.APS.GetLocalServerService(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLocalServerServiceExt = timerfactory.Create<Production.APS.IGetLocalServerService>(_GetLocalServerService);
			
			return iGetLocalServerServiceExt;
		}
	}
}
