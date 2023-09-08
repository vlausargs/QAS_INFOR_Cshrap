//PROJECT NAME: Production
//CLASS NAME: WcmatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class WcmatlFactory
	{
		public IWcmatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Wcmatl = new Production.Wcmatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWcmatlExt = timerfactory.Create<Production.IWcmatl>(_Wcmatl);
			
			return iWcmatlExt;
		}
	}
}
