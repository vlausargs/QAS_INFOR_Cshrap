//PROJECT NAME: CSICustomer
//CLASS NAME: MO_ValidateResourceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MO_ValidateResourceFactory
	{
		public IMO_ValidateResource Create(IApplicationDB appDB)
		{
			var _MO_ValidateResource = new Logistics.Customer.MO_ValidateResource(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ValidateResourceExt = timerfactory.Create<Logistics.Customer.IMO_ValidateResource>(_MO_ValidateResource);
			
			return iMO_ValidateResourceExt;
		}
	}
}
