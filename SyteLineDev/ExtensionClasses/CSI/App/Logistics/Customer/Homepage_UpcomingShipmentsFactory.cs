//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_UpcomingShipmentsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_UpcomingShipmentsFactory
	{
		public IHomepage_UpcomingShipments Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_UpcomingShipments = new Logistics.Customer.Homepage_UpcomingShipments(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_UpcomingShipmentsExt = timerfactory.Create<Logistics.Customer.IHomepage_UpcomingShipments>(_Homepage_UpcomingShipments);
			
			return iHomepage_UpcomingShipmentsExt;
		}
	}
}
