//PROJECT NAME: Logistics
//CLASS NAME: Homepage_OrdersFulfilledFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_OrdersFulfilledFactory
	{
		public IHomepage_OrdersFulfilled Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_OrdersFulfilled = new Logistics.Customer.Homepage_OrdersFulfilled(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OrdersFulfilledExt = timerfactory.Create<Logistics.Customer.IHomepage_OrdersFulfilled>(_Homepage_OrdersFulfilled);
			
			return iHomepage_OrdersFulfilledExt;
		}
	}
}
