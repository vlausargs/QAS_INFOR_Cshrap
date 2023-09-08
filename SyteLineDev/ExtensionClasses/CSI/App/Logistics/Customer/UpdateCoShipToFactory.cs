//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCoShipToFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateCoShipToFactory
	{
		public IUpdateCoShipTo Create(IApplicationDB appDB)
		{
			var _UpdateCoShipTo = new Logistics.Customer.UpdateCoShipTo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateCoShipToExt = timerfactory.Create<Logistics.Customer.IUpdateCoShipTo>(_UpdateCoShipTo);
			
			return iUpdateCoShipToExt;
		}
	}
}
