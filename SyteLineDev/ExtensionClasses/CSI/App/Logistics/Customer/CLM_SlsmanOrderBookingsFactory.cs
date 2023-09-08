//PROJECT NAME: Logistics
//CLASS NAME: CLM_SlsmanOrderBookingsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SlsmanOrderBookingsFactory
	{
		public ICLM_SlsmanOrderBookings Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SlsmanOrderBookings = new Logistics.Customer.CLM_SlsmanOrderBookings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SlsmanOrderBookingsExt = timerfactory.Create<Logistics.Customer.ICLM_SlsmanOrderBookings>(_CLM_SlsmanOrderBookings);
			
			return iCLM_SlsmanOrderBookingsExt;
		}
	}
}
