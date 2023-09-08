//PROJECT NAME: Material
//CLASS NAME: MasterPlanningBucketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class MasterPlanningBucketsFactory
	{
		public IMasterPlanningBuckets Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MasterPlanningBuckets = new Material.MasterPlanningBuckets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMasterPlanningBucketsExt = timerfactory.Create<Material.IMasterPlanningBuckets>(_MasterPlanningBuckets);
			
			return iMasterPlanningBucketsExt;
		}
	}
}
