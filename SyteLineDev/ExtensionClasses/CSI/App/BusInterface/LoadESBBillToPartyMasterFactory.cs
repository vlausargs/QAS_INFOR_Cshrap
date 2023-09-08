//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillToPartyMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBillToPartyMasterFactory
	{
		public ILoadESBBillToPartyMaster Create(IApplicationDB appDB)
		{
			var _LoadESBBillToPartyMaster = new BusInterface.LoadESBBillToPartyMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBillToPartyMasterExt = timerfactory.Create<BusInterface.ILoadESBBillToPartyMaster>(_LoadESBBillToPartyMaster);
			
			return iLoadESBBillToPartyMasterExt;
		}
	}
}
