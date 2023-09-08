//PROJECT NAME: Material
//CLASS NAME: ItemQtyDetlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemQtyDetlFactory
	{
		public IItemQtyDetl Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ItemQtyDetl = new Material.ItemQtyDetl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemQtyDetlExt = timerfactory.Create<Material.IItemQtyDetl>(_ItemQtyDetl);
			
			return iItemQtyDetlExt;
		}
	}
}
