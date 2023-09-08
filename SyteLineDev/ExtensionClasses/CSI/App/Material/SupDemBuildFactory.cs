//PROJECT NAME: Material
//CLASS NAME: SupDemBuildFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class SupDemBuildFactory
	{
		public ISupDemBuild Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SupDemBuild = new Material.SupDemBuild(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSupDemBuildExt = timerfactory.Create<Material.ISupDemBuild>(_SupDemBuild);
			
			return iSupDemBuildExt;
		}
	}
}
