//PROJECT NAME: Material
//CLASS NAME: ItemPreDisplayFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemPreDisplayFactory
	{
		public IItemPreDisplay Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemPreDisplay = new Material.ItemPreDisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemPreDisplayExt = timerfactory.Create<Material.IItemPreDisplay>(_ItemPreDisplay);
			
			return iItemPreDisplayExt;
		}
	}
}
