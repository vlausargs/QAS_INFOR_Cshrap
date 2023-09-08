//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_BookingsByTimeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_BookingsByTimeFactory
	{
		public IHomepage_BookingsByTime Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_BookingsByTime = new Logistics.Customer.Homepage_BookingsByTime(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_BookingsByTimeExt = timerfactory.Create<Logistics.Customer.IHomepage_BookingsByTime>(_Homepage_BookingsByTime);
			
			return iHomepage_BookingsByTimeExt;
		}
	}
}
