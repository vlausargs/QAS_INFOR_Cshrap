//PROJECT NAME: CSICustomer
//CLASS NAME: RemoveShipmentSequencePackageIDFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RemoveShipmentSequencePackageIDFactory
	{
		public IRemoveShipmentSequencePackageID Create(IApplicationDB appDB)
		{
			var _RemoveShipmentSequencePackageID = new Logistics.Customer.RemoveShipmentSequencePackageID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRemoveShipmentSequencePackageIDExt = timerfactory.Create<Logistics.Customer.IRemoveShipmentSequencePackageID>(_RemoveShipmentSequencePackageID);
			
			return iRemoveShipmentSequencePackageIDExt;
		}
	}
}
