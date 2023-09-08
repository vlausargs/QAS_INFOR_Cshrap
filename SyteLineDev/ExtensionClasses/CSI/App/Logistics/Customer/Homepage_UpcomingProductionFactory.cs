//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_UpcomingProductionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_UpcomingProductionFactory
	{
		public IHomepage_UpcomingProduction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_UpcomingProduction = new Logistics.Customer.Homepage_UpcomingProduction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_UpcomingProductionExt = timerfactory.Create<Logistics.Customer.IHomepage_UpcomingProduction>(_Homepage_UpcomingProduction);
			
			return iHomepage_UpcomingProductionExt;
		}
	}
}
