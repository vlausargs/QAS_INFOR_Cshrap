//PROJECT NAME: Codes
//CLASS NAME: ServerInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ServerInfoFactory
	{
		public IServerInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ServerInfo = new Codes.ServerInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iServerInfoExt = timerfactory.Create<Codes.IServerInfo>(_ServerInfo);
			
			return iServerInfoExt;
		}
	}
}
