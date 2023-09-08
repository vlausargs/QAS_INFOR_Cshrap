//PROJECT NAME: CSICustomer
//CLASS NAME: PortalValidateRmaRequestFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PortalValidateRmaRequestFactory
	{
		public IPortalValidateRmaRequest Create(IApplicationDB appDB)
		{
			var _PortalValidateRmaRequest = new Logistics.Customer.PortalValidateRmaRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalValidateRmaRequestExt = timerfactory.Create<Logistics.Customer.IPortalValidateRmaRequest>(_PortalValidateRmaRequest);
			
			return iPortalValidateRmaRequestExt;
		}
	}
}
