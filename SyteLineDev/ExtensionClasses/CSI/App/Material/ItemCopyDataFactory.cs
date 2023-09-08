//PROJECT NAME: Material
//CLASS NAME: ItemCopyDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemCopyDataFactory
	{
		public IItemCopyData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemCopyData = new Material.ItemCopyData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCopyDataExt = timerfactory.Create<Material.IItemCopyData>(_ItemCopyData);
			
			return iItemCopyDataExt;
		}
	}
}
