//PROJECT NAME: Material
//CLASS NAME: Item_ItemRevFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Item_ItemRevFactory
	{
		public IItem_ItemRev Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Item_ItemRev = new Material.Item_ItemRev(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItem_ItemRevExt = timerfactory.Create<Material.IItem_ItemRev>(_Item_ItemRev);
			
			return iItem_ItemRevExt;
		}
	}
}
