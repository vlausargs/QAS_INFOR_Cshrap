//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_OpportunityFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Homepage_OpportunityFactory
	{
		public IHomepage_Opportunity Create(IApplicationDB appDB)
		{
			var _Homepage_Opportunity = new Logistics.Customer.Homepage_Opportunity(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OpportunityExt = timerfactory.Create<Logistics.Customer.IHomepage_Opportunity>(_Homepage_Opportunity);
			
			return iHomepage_OpportunityExt;
		}
	}
}
