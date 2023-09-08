//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceiveShippingPostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBReceiveShippingPostFactory
	{
		public ILoadESBReceiveShippingPost Create(IApplicationDB appDB)
		{
			var _LoadESBReceiveShippingPost = new BusInterface.LoadESBReceiveShippingPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBReceiveShippingPostExt = timerfactory.Create<BusInterface.ILoadESBReceiveShippingPost>(_LoadESBReceiveShippingPost);
			
			return iLoadESBReceiveShippingPostExt;
		}
	}
}
