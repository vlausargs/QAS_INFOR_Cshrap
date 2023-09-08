//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderBookingsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderBookingsFactory
	{
		public IRpt_OrderBookings Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderBookings = new Reporting.Rpt_OrderBookings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderBookingsExt = timerfactory.Create<Reporting.IRpt_OrderBookings>(_Rpt_OrderBookings);
			
			return iRpt_OrderBookingsExt;
		}
	}
}
