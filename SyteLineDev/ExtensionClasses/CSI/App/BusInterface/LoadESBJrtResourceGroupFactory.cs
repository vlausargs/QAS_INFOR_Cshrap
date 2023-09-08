//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBJrtResourceGroupFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBJrtResourceGroupFactory
	{
		public ILoadESBJrtResourceGroup Create(IApplicationDB appDB)
		{
			var _LoadESBJrtResourceGroup = new BusInterface.LoadESBJrtResourceGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBJrtResourceGroupExt = timerfactory.Create<BusInterface.ILoadESBJrtResourceGroup>(_LoadESBJrtResourceGroup);
			
			return iLoadESBJrtResourceGroupExt;
		}
	}
}
