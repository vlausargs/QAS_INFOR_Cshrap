//PROJECT NAME: Material
//CLASS NAME: ItemFlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemFlFactory
	{
		public IItemFl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemFl = new Material.ItemFl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemFlExt = timerfactory.Create<Material.IItemFl>(_ItemFl);
			
			return iItemFlExt;
		}
	}
}
