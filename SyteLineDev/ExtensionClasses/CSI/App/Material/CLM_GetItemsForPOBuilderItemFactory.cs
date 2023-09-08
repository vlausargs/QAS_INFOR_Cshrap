//PROJECT NAME: Material
//CLASS NAME: CLM_GetItemsForPOBuilderItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_GetItemsForPOBuilderItemFactory
	{
		public ICLM_GetItemsForPOBuilderItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetItemsForPOBuilderItem = new Material.CLM_GetItemsForPOBuilderItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetItemsForPOBuilderItemExt = timerfactory.Create<Material.ICLM_GetItemsForPOBuilderItem>(_CLM_GetItemsForPOBuilderItem);
			
			return iCLM_GetItemsForPOBuilderItemExt;
		}
	}
}
