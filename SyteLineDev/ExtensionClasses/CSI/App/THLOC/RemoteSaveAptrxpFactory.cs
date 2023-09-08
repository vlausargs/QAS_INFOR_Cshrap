//PROJECT NAME: THLOC
//CLASS NAME: RemoteSaveAptrxpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class RemoteSaveAptrxpFactory
	{
		public IRemoteSaveAptrxp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RemoteSaveAptrxp = new THLOC.RemoteSaveAptrxp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRemoteSaveAptrxpExt = timerfactory.Create<THLOC.IRemoteSaveAptrxp>(_RemoteSaveAptrxp);
			
			return iRemoteSaveAptrxpExt;
		}
	}
}
