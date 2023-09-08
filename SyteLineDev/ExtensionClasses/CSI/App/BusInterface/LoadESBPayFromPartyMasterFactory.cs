//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPayFromPartyMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPayFromPartyMasterFactory
	{
		public ILoadESBPayFromPartyMaster Create(IApplicationDB appDB)
		{
			var _LoadESBPayFromPartyMaster = new BusInterface.LoadESBPayFromPartyMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPayFromPartyMasterExt = timerfactory.Create<BusInterface.ILoadESBPayFromPartyMaster>(_LoadESBPayFromPartyMaster);
			
			return iLoadESBPayFromPartyMasterExt;
		}
	}
}
