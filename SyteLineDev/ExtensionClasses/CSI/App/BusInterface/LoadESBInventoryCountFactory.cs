//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInventoryCountFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBInventoryCountFactory
	{
		public ILoadESBInventoryCount Create(IApplicationDB appDB)
		{
			var _LoadESBInventoryCount = new BusInterface.LoadESBInventoryCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBInventoryCountExt = timerfactory.Create<BusInterface.ILoadESBInventoryCount>(_LoadESBInventoryCount);
			
			return iLoadESBInventoryCountExt;
		}
	}
}
