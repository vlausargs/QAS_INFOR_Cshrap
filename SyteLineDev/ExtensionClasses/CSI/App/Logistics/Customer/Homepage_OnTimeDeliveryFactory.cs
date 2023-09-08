//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_OnTimeDeliveryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_OnTimeDeliveryFactory
	{
		public IHomepage_OnTimeDelivery Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_OnTimeDelivery = new Logistics.Customer.Homepage_OnTimeDelivery(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OnTimeDeliveryExt = timerfactory.Create<Logistics.Customer.IHomepage_OnTimeDelivery>(_Homepage_OnTimeDelivery);
			
			return iHomepage_OnTimeDeliveryExt;
		}
	}
}
