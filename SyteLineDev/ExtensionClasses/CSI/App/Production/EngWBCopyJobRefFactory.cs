//PROJECT NAME: Production
//CLASS NAME: EngWBCopyJobRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EngWBCopyJobRefFactory
	{
		public IEngWBCopyJobRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EngWBCopyJobRef = new Production.EngWBCopyJobRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBCopyJobRefExt = timerfactory.Create<Production.IEngWBCopyJobRef>(_EngWBCopyJobRef);
			
			return iEngWBCopyJobRefExt;
		}
	}
}
