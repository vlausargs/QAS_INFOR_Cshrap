//PROJECT NAME: Material
//CLASS NAME: GetItemsPriceForCustItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class GetItemsPriceForCustItemFactory
	{
		public IGetItemsPriceForCustItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetItemsPriceForCustItem = new Material.GetItemsPriceForCustItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemsPriceForCustItemExt = timerfactory.Create<Material.IGetItemsPriceForCustItem>(_GetItemsPriceForCustItem);
			
			return iGetItemsPriceForCustItemExt;
		}
	}
}
