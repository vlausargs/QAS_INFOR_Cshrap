//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBItemMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBItemMasterFactory
	{
		public ILoadESBItemMaster Create(IApplicationDB appDB)
		{
			var _LoadESBItemMaster = new BusInterface.LoadESBItemMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBItemMasterExt = timerfactory.Create<BusInterface.ILoadESBItemMaster>(_LoadESBItemMaster);
			
			return iLoadESBItemMasterExt;
		}
	}
}
