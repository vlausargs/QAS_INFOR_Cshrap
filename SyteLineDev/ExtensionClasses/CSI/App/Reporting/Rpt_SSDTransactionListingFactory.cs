//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SSDTransactionListingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SSDTransactionListingFactory
	{
		public IRpt_SSDTransactionListing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SSDTransactionListing = new Reporting.Rpt_SSDTransactionListing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SSDTransactionListingExt = timerfactory.Create<Reporting.IRpt_SSDTransactionListing>(_Rpt_SSDTransactionListing);
			
			return iRpt_SSDTransactionListingExt;
		}
	}
}
