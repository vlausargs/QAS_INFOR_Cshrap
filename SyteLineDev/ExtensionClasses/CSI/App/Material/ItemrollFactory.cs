//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemrollFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemrollFactory
	{
		public IItemroll Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Itemroll = new Material.Itemroll(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemrollExt = timerfactory.Create<Material.IItemroll>(_Itemroll);
			
			return iItemrollExt;
		}
	}
}
