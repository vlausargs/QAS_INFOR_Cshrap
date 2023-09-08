//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBShipToPartyMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBShipToPartyMasterFactory
	{
		public ILoadESBShipToPartyMaster Create(IApplicationDB appDB)
		{
			var _LoadESBShipToPartyMaster = new BusInterface.LoadESBShipToPartyMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBShipToPartyMasterExt = timerfactory.Create<BusInterface.ILoadESBShipToPartyMaster>(_LoadESBShipToPartyMaster);
			
			return iLoadESBShipToPartyMasterExt;
		}
	}
}
