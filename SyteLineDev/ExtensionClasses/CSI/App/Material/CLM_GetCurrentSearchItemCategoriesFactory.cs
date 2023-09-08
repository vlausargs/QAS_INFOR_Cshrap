//PROJECT NAME: Material
//CLASS NAME: CLM_GetCurrentSearchItemCategoriesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_GetCurrentSearchItemCategoriesFactory
	{
		public ICLM_GetCurrentSearchItemCategories Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCurrentSearchItemCategories = new Material.CLM_GetCurrentSearchItemCategories(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCurrentSearchItemCategoriesExt = timerfactory.Create<Material.ICLM_GetCurrentSearchItemCategories>(_CLM_GetCurrentSearchItemCategories);
			
			return iCLM_GetCurrentSearchItemCategoriesExt;
		}
	}
}
