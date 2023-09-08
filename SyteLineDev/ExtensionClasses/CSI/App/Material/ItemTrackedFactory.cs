//PROJECT NAME: Material
//CLASS NAME: ItemTrackedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemTrackedFactory
	{
		public IItemTracked Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemTracked = new Material.ItemTracked(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemTrackedExt = timerfactory.Create<Material.IItemTracked>(_ItemTracked);
			
			return iItemTrackedExt;
		}
	}
}
