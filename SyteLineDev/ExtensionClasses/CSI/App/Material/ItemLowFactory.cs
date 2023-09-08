//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLowFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemLowFactory
	{
		public IItemLow Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemLow = new Material.ItemLow(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLowExt = timerfactory.Create<Material.IItemLow>(_ItemLow);
			
			return iItemLowExt;
		}
	}
}
