//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyCustomerTop5SalesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_MyCustomerTop5SalesFactory
	{
		public IHomepage_MyCustomerTop5Sales Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_MyCustomerTop5Sales = new Logistics.Customer.Homepage_MyCustomerTop5Sales(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MyCustomerTop5SalesExt = timerfactory.Create<Logistics.Customer.IHomepage_MyCustomerTop5Sales>(_Homepage_MyCustomerTop5Sales);
			
			return iHomepage_MyCustomerTop5SalesExt;
		}
	}
}
