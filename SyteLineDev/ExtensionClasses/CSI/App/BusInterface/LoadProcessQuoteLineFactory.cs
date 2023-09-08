//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessQuoteLineFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessQuoteLineFactory
	{
		public ILoadProcessQuoteLine Create(IApplicationDB appDB)
		{
			var _LoadProcessQuoteLine = new BusInterface.LoadProcessQuoteLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessQuoteLineExt = timerfactory.Create<BusInterface.ILoadProcessQuoteLine>(_LoadProcessQuoteLine);
			
			return iLoadProcessQuoteLineExt;
		}
	}
}
