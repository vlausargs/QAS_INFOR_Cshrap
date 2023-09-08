//PROJECT NAME: Production
//CLASS NAME: ApsSyncDeferFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ApsSyncDeferFactory
	{
		public IApsSyncDefer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsSyncDefer = new Production.ApsSyncDefer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSyncDeferExt = timerfactory.Create<Production.IApsSyncDefer>(_ApsSyncDefer);
			
			return iApsSyncDeferExt;
		}
	}
}
