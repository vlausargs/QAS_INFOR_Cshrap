//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CoItemsBookingsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CoItemsBookingsFactory
	{
		public ICLM_CoItemsBookings Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CoItemsBookings = new Logistics.Customer.CLM_CoItemsBookings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CoItemsBookingsExt = timerfactory.Create<Logistics.Customer.ICLM_CoItemsBookings>(_CLM_CoItemsBookings);
			
			return iCLM_CoItemsBookingsExt;
		}
	}
}
