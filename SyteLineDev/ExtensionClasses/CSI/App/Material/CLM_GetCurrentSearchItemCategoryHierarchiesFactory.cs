//PROJECT NAME: Material
//CLASS NAME: CLM_GetCurrentSearchItemCategoryHierarchiesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_GetCurrentSearchItemCategoryHierarchiesFactory
	{
		public ICLM_GetCurrentSearchItemCategoryHierarchies Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCurrentSearchItemCategoryHierarchies = new Material.CLM_GetCurrentSearchItemCategoryHierarchies(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCurrentSearchItemCategoryHierarchiesExt = timerfactory.Create<Material.ICLM_GetCurrentSearchItemCategoryHierarchies>(_CLM_GetCurrentSearchItemCategoryHierarchies);
			
			return iCLM_GetCurrentSearchItemCategoryHierarchiesExt;
		}
	}
}
