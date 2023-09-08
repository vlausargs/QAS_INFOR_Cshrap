//PROJECT NAME: Reporting
//CLASS NAME: sssfsrpt_itemRentalHistoryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class sssfsrpt_itemRentalHistoryFactory
	{
		public Isssfsrpt_itemRentalHistory Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _sssfsrpt_itemRentalHistory = new Reporting.sssfsrpt_itemRentalHistory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var isssfsrpt_itemRentalHistoryExt = timerfactory.Create<Reporting.Isssfsrpt_itemRentalHistory>(_sssfsrpt_itemRentalHistory);
			
			return isssfsrpt_itemRentalHistoryExt;
		}
	}
}
