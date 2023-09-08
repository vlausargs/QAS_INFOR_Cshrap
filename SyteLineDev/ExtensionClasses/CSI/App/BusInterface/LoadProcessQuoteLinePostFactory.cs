//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessQuoteLinePostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessQuoteLinePostFactory
	{
		public ILoadProcessQuoteLinePost Create(IApplicationDB appDB)
		{
			var _LoadProcessQuoteLinePost = new BusInterface.LoadProcessQuoteLinePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessQuoteLinePostExt = timerfactory.Create<BusInterface.ILoadProcessQuoteLinePost>(_LoadProcessQuoteLinePost);
			
			return iLoadProcessQuoteLinePostExt;
		}
	}
}
