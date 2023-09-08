//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceiveShippingLoopFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBReceiveShippingLoopFactory
	{
		public ILoadESBReceiveShippingLoop Create(IApplicationDB appDB)
		{
			var _LoadESBReceiveShippingLoop = new BusInterface.LoadESBReceiveShippingLoop(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBReceiveShippingLoopExt = timerfactory.Create<BusInterface.ILoadESBReceiveShippingLoop>(_LoadESBReceiveShippingLoop);
			
			return iLoadESBReceiveShippingLoopExt;
		}
	}
}
