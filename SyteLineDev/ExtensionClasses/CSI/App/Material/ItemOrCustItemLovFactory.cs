//PROJECT NAME: Material
//CLASS NAME: ItemOrCustItemLovFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemOrCustItemLovFactory
	{
		public IItemOrCustItemLov Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemOrCustItemLov = new Material.ItemOrCustItemLov(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemOrCustItemLovExt = timerfactory.Create<Material.IItemOrCustItemLov>(_ItemOrCustItemLov);
			
			return iItemOrCustItemLovExt;
		}
	}
}
