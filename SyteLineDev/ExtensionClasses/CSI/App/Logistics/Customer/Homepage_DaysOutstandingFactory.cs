//PROJECT NAME: Logistics
//CLASS NAME: Homepage_DaysOutstandingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_DaysOutstandingFactory
	{
		public IHomepage_DaysOutstanding Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_DaysOutstanding = new Logistics.Customer.Homepage_DaysOutstanding(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_DaysOutstandingExt = timerfactory.Create<Logistics.Customer.IHomepage_DaysOutstanding>(_Homepage_DaysOutstanding);
			
			return iHomepage_DaysOutstandingExt;
		}
	}
}
