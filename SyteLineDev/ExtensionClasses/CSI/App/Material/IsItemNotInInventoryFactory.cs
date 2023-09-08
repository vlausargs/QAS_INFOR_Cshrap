//PROJECT NAME: Material
//CLASS NAME: IsItemNotInInventoryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class IsItemNotInInventoryFactory
	{
		public IIsItemNotInInventory Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsItemNotInInventory = new Material.IsItemNotInInventory(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsItemNotInInventoryExt = timerfactory.Create<Material.IIsItemNotInInventory>(_IsItemNotInInventory);
			
			return iIsItemNotInInventoryExt;
		}
	}
}
