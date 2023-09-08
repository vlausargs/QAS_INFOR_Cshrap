//PROJECT NAME: Logistics
//CLASS NAME: MO_CLM_EstimateJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class MO_CLM_EstimateJobFactory
	{
		public IMO_CLM_EstimateJob Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_CLM_EstimateJob = new Logistics.Customer.MO_CLM_EstimateJob(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_CLM_EstimateJobExt = timerfactory.Create<Logistics.Customer.IMO_CLM_EstimateJob>(_MO_CLM_EstimateJob);
			
			return iMO_CLM_EstimateJobExt;
		}
	}
}
