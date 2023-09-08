//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyJobOrdersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_MyJobOrdersFactory
	{
		public IHomepage_MyJobOrders Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_MyJobOrders = new Logistics.Customer.Homepage_MyJobOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MyJobOrdersExt = timerfactory.Create<Logistics.Customer.IHomepage_MyJobOrders>(_Homepage_MyJobOrders);
			
			return iHomepage_MyJobOrdersExt;
		}
	}
}
