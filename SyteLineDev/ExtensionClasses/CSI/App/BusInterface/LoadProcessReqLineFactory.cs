//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessReqLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadProcessReqLineFactory
	{
		public ILoadProcessReqLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadProcessReqLine = new BusInterface.LoadProcessReqLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessReqLineExt = timerfactory.Create<BusInterface.ILoadProcessReqLine>(_LoadProcessReqLine);
			
			return iLoadProcessReqLineExt;
		}
	}
}
