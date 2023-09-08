//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBInventoryCountLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBInventoryCountLineFactory
	{
		public ILoadESBInventoryCountLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBInventoryCountLine = new BusInterface.LoadESBInventoryCountLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBInventoryCountLineExt = timerfactory.Create<BusInterface.ILoadESBInventoryCountLine>(_LoadESBInventoryCountLine);
			
			return iLoadESBInventoryCountLineExt;
		}
	}
}
