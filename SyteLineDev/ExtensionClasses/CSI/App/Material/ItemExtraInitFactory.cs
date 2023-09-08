//PROJECT NAME: Material
//CLASS NAME: ItemExtraInitFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemExtraInitFactory
	{
		public IItemExtraInit Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemExtraInit = new Material.ItemExtraInit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemExtraInitExt = timerfactory.Create<Material.IItemExtraInit>(_ItemExtraInit);
			
			return iItemExtraInitExt;
		}
	}
}
