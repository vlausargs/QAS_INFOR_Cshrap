//PROJECT NAME: Material
//CLASS NAME: ItemVlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemVlFactory
	{
		public IItemVl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemVl = new Material.ItemVl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemVlExt = timerfactory.Create<Material.IItemVl>(_ItemVl);
			
			return iItemVlExt;
		}
	}
}
