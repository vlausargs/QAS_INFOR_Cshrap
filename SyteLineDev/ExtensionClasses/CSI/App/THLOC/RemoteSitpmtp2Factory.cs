//PROJECT NAME: THLOC
//CLASS NAME: RemoteSitpmtp2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class RemoteSitpmtp2Factory
	{
		public IRemoteSitpmtp2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RemoteSitpmtp2 = new THLOC.RemoteSitpmtp2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRemoteSitpmtp2Ext = timerfactory.Create<THLOC.IRemoteSitpmtp2>(_RemoteSitpmtp2);
			
			return iRemoteSitpmtp2Ext;
		}
	}
}
