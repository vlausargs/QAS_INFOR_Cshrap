//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCustomerPartyMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCustomerPartyMasterFactory
	{
		public ILoadESBCustomerPartyMaster Create(IApplicationDB appDB)
		{
			var _LoadESBCustomerPartyMaster = new BusInterface.LoadESBCustomerPartyMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCustomerPartyMasterExt = timerfactory.Create<BusInterface.ILoadESBCustomerPartyMaster>(_LoadESBCustomerPartyMaster);
			
			return iLoadESBCustomerPartyMasterExt;
		}
	}
}
