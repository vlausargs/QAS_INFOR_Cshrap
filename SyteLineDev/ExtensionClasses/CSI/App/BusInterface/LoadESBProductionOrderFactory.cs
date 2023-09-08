//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBProductionOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBProductionOrderFactory
	{
		public ILoadESBProductionOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBProductionOrder = new BusInterface.LoadESBProductionOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBProductionOrderExt = timerfactory.Create<BusInterface.ILoadESBProductionOrder>(_LoadESBProductionOrder);
			
			return iLoadESBProductionOrderExt;
		}
	}
}
