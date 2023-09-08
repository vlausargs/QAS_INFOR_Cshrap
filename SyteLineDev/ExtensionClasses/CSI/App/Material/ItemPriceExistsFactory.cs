//PROJECT NAME: Material
//CLASS NAME: ItemPriceExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemPriceExistsFactory
	{
		public IItemPriceExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemPriceExists = new Material.ItemPriceExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemPriceExistsExt = timerfactory.Create<Material.IItemPriceExists>(_ItemPriceExists);
			
			return iItemPriceExistsExt;
		}
	}
}
