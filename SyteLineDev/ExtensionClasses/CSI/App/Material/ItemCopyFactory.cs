//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCopyFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemCopyFactory
	{
		public IItemCopy Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemCopy = new Material.ItemCopy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCopyExt = timerfactory.Create<Material.IItemCopy>(_ItemCopy);
			
			return iItemCopyExt;
		}
	}
}
