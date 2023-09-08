//PROJECT NAME: CSICustomer
//CLASS NAME: GetSiteParmsForCustomerAllsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetSiteParmsForCustomerAllsFactory
	{
		public IGetSiteParmsForCustomerAlls Create(IApplicationDB appDB)
		{
			var _GetSiteParmsForCustomerAlls = new Logistics.Customer.GetSiteParmsForCustomerAlls(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteParmsForCustomerAllsExt = timerfactory.Create<Logistics.Customer.IGetSiteParmsForCustomerAlls>(_GetSiteParmsForCustomerAlls);
			
			return iGetSiteParmsForCustomerAllsExt;
		}
	}
}
