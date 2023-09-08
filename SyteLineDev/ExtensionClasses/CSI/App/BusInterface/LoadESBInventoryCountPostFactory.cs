//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBInventoryCountPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBInventoryCountPostFactory
	{
		public ILoadESBInventoryCountPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBInventoryCountPost = new BusInterface.LoadESBInventoryCountPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBInventoryCountPostExt = timerfactory.Create<BusInterface.ILoadESBInventoryCountPost>(_LoadESBInventoryCountPost);
			
			return iLoadESBInventoryCountPostExt;
		}
	}
}
