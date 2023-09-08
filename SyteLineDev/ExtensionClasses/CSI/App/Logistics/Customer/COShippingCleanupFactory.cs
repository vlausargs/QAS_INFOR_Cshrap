//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingCleanupFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COShippingCleanupFactory
	{
		public ICOShippingCleanup Create(IApplicationDB appDB)
		{
			var _COShippingCleanup = new Logistics.Customer.COShippingCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOShippingCleanupExt = timerfactory.Create<Logistics.Customer.ICOShippingCleanup>(_COShippingCleanup);
			
			return iCOShippingCleanupExt;
		}
	}
}
