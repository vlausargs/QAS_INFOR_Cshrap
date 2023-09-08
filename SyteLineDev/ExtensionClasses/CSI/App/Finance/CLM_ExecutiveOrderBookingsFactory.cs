//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ExecutiveOrderBookingsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveOrderBookingsFactory
	{
		public ICLM_ExecutiveOrderBookings Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveOrderBookings = new Finance.CLM_ExecutiveOrderBookings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveOrderBookingsExt = timerfactory.Create<Finance.ICLM_ExecutiveOrderBookings>(_CLM_ExecutiveOrderBookings);
			
			return iCLM_ExecutiveOrderBookingsExt;
		}
	}
}
