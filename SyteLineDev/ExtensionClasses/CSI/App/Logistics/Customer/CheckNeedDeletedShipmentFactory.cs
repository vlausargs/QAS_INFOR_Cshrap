//PROJECT NAME: CSICustomer
//CLASS NAME: CheckNeedDeletedShipmentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckNeedDeletedShipmentFactory
	{
		public ICheckNeedDeletedShipment Create(IApplicationDB appDB)
		{
			var _CheckNeedDeletedShipment = new Logistics.Customer.CheckNeedDeletedShipment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckNeedDeletedShipmentExt = timerfactory.Create<Logistics.Customer.ICheckNeedDeletedShipment>(_CheckNeedDeletedShipment);
			
			return iCheckNeedDeletedShipmentExt;
		}
	}
}
