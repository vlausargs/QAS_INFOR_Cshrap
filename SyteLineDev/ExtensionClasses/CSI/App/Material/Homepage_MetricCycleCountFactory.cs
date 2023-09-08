//PROJECT NAME: CSIMaterial
//CLASS NAME: Homepage_MetricCycleCountFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Homepage_MetricCycleCountFactory
	{
		public IHomepage_MetricCycleCount Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_MetricCycleCount = new Material.Homepage_MetricCycleCount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MetricCycleCountExt = timerfactory.Create<Material.IHomepage_MetricCycleCount>(_Homepage_MetricCycleCount);
			
			return iHomepage_MetricCycleCountExt;
		}
	}
}
