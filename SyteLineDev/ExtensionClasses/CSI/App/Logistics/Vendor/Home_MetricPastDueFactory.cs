//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricPastDueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class Home_MetricPastDueFactory
	{
		public IHome_MetricPastDue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricPastDue = new Logistics.Vendor.Home_MetricPastDue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricPastDueExt = timerfactory.Create<Logistics.Vendor.IHome_MetricPastDue>(_Home_MetricPastDue);
			
			return iHome_MetricPastDueExt;
		}
	}
}
