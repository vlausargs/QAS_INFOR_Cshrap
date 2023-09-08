//PROJECT NAME: Material
//CLASS NAME: ProdConfFeatureGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ProdConfFeatureGroupFactory
	{
		public IProdConfFeatureGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProdConfFeatureGroup = new Material.ProdConfFeatureGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProdConfFeatureGroupExt = timerfactory.Create<Material.IProdConfFeatureGroup>(_ProdConfFeatureGroup);
			
			return iProdConfFeatureGroupExt;
		}
	}
}
