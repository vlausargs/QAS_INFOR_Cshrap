//PROJECT NAME: Material
//CLASS NAME: ItemLifoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemLifoFactory
	{
		public IItemLifo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemLifo = new Material.ItemLifo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLifoExt = timerfactory.Create<Material.IItemLifo>(_ItemLifo);
			
			return iItemLifoExt;
		}
	}
}
