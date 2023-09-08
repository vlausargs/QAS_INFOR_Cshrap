//PROJECT NAME: Material
//CLASS NAME: ItemInitFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemInitFactory
	{
		public IItemInit Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemInit = new Material.ItemInit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemInitExt = timerfactory.Create<Material.IItemInit>(_ItemInit);
			
			return iItemInitExt;
		}
	}
}
