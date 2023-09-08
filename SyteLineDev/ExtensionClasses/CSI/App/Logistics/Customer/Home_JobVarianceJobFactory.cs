//PROJECT NAME: Logistics
//CLASS NAME: Home_JobVarianceJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_JobVarianceJobFactory
	{
		public IHome_JobVarianceJob Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_JobVarianceJob = new Logistics.Customer.Home_JobVarianceJob(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_JobVarianceJobExt = timerfactory.Create<Logistics.Customer.IHome_JobVarianceJob>(_Home_JobVarianceJob);
			
			return iHome_JobVarianceJobExt;
		}
	}
}
