//PROJECT NAME: Production
//CLASS NAME: ProdConfFeatureMaterialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class ProdConfFeatureMaterialFactory
	{
		public IProdConfFeatureMaterial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProdConfFeatureMaterial = new Production.ProdConfFeatureMaterial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProdConfFeatureMaterialExt = timerfactory.Create<Production.IProdConfFeatureMaterial>(_ProdConfFeatureMaterial);
			
			return iProdConfFeatureMaterialExt;
		}
	}
}
