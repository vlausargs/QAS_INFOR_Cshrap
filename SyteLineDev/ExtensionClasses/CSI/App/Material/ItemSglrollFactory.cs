//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemSglrollFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemSglrollFactory
	{
		public IItemSglroll Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemSglroll = new Material.ItemSglroll(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemSglrollExt = timerfactory.Create<Material.IItemSglroll>(_ItemSglroll);
			
			return iItemSglrollExt;
		}
	}
}
