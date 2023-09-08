//PROJECT NAME: Material
//CLASS NAME: Home_MetricCycleCountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Home_MetricCycleCountFactory
	{
		public IHome_MetricCycleCount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricCycleCount = new Material.Home_MetricCycleCount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricCycleCountExt = timerfactory.Create<Material.IHome_MetricCycleCount>(_Home_MetricCycleCount);
			
			return iHome_MetricCycleCountExt;
		}
	}
}
