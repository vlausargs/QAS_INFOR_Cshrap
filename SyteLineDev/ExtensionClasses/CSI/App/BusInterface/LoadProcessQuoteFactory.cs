//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessQuoteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadProcessQuoteFactory
	{
		public ILoadProcessQuote Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadProcessQuote = new BusInterface.LoadProcessQuote(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessQuoteExt = timerfactory.Create<BusInterface.ILoadProcessQuote>(_LoadProcessQuote);
			
			return iLoadProcessQuoteExt;
		}
	}
}
