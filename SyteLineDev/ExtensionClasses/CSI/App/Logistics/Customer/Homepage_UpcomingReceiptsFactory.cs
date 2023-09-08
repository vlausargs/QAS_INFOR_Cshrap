//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_UpcomingReceiptsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_UpcomingReceiptsFactory
	{
		public IHomepage_UpcomingReceipts Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_UpcomingReceipts = new Logistics.Customer.Homepage_UpcomingReceipts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_UpcomingReceiptsExt = timerfactory.Create<Logistics.Customer.IHomepage_UpcomingReceipts>(_Homepage_UpcomingReceipts);
			
			return iHomepage_UpcomingReceiptsExt;
		}
	}
}
