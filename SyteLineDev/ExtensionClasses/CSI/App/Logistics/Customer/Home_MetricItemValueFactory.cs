//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricItemValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_MetricItemValueFactory
	{
		public IHome_MetricItemValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricItemValue = new Logistics.Customer.Home_MetricItemValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricItemValueExt = timerfactory.Create<Logistics.Customer.IHome_MetricItemValue>(_Home_MetricItemValue);
			
			return iHome_MetricItemValueExt;
		}
	}
}
