//PROJECT NAME: CSIBusInterface
//CLASS NAME: CustomerShipToPartyMasterLoadFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class CustomerShipToPartyMasterLoadFactory
	{
		public ICustomerShipToPartyMasterLoad Create(IApplicationDB appDB)
		{
			var _CustomerShipToPartyMasterLoad = new BusInterface.CustomerShipToPartyMasterLoad(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerShipToPartyMasterLoadExt = timerfactory.Create<BusInterface.ICustomerShipToPartyMasterLoad>(_CustomerShipToPartyMasterLoad);
			
			return iCustomerShipToPartyMasterLoadExt;
		}
	}
}
