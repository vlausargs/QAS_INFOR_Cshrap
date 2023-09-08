//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricItemShortageFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_MetricItemShortageFactory
	{
		public IHome_MetricItemShortage Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricItemShortage = new Logistics.Customer.Home_MetricItemShortage(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricItemShortageExt = timerfactory.Create<Logistics.Customer.IHome_MetricItemShortage>(_Home_MetricItemShortage);
			
			return iHome_MetricItemShortageExt;
		}
	}
}
