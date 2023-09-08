//PROJECT NAME: Material
//CLASS NAME: ItemLcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemLcFactory
	{
		public IItemLc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemLc = new Material.ItemLc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLcExt = timerfactory.Create<Material.IItemLc>(_ItemLc);
			
			return iItemLcExt;
		}
	}
}
