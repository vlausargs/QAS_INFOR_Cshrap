//PROJECT NAME: CSICustomer
//CLASS NAME: RmaLineItemRmaLoadFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaLineItemRmaLoadFactory
	{
		public IRmaLineItemRmaLoad Create(IApplicationDB appDB)
		{
			var _RmaLineItemRmaLoad = new Logistics.Customer.RmaLineItemRmaLoad(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaLineItemRmaLoadExt = timerfactory.Create<Logistics.Customer.IRmaLineItemRmaLoad>(_RmaLineItemRmaLoad);
			
			return iRmaLineItemRmaLoadExt;
		}
	}
}
