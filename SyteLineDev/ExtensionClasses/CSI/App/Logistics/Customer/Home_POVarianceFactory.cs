//PROJECT NAME: Logistics
//CLASS NAME: Home_POVarianceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_POVarianceFactory
	{
		public IHome_POVariance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_POVariance = new Logistics.Customer.Home_POVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_POVarianceExt = timerfactory.Create<Logistics.Customer.IHome_POVariance>(_Home_POVariance);
			
			return iHome_POVarianceExt;
		}
	}
}
