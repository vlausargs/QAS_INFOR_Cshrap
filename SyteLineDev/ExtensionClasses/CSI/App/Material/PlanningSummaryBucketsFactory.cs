//PROJECT NAME: Material
//CLASS NAME: PlanningSummaryBucketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class PlanningSummaryBucketsFactory
	{
		public IPlanningSummaryBuckets Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PlanningSummaryBuckets = new Material.PlanningSummaryBuckets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningSummaryBucketsExt = timerfactory.Create<Material.IPlanningSummaryBuckets>(_PlanningSummaryBuckets);
			
			return iPlanningSummaryBucketsExt;
		}
	}
}
