//PROJECT NAME: CSICustomer
//CLASS NAME: GetShipmentInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetShipmentInfoFactory
	{
		public IGetShipmentInfo Create(IApplicationDB appDB)
		{
			var _GetShipmentInfo = new Logistics.Customer.GetShipmentInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetShipmentInfoExt = timerfactory.Create<Logistics.Customer.IGetShipmentInfo>(_GetShipmentInfo);
			
			return iGetShipmentInfoExt;
		}
	}
}
