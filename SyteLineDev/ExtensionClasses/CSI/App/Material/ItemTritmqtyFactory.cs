//PROJECT NAME: Material
//CLASS NAME: ItemTritmqtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemTritmqtyFactory
	{
		public IItemTritmqty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemTritmqty = new Material.ItemTritmqty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemTritmqtyExt = timerfactory.Create<Material.IItemTritmqty>(_ItemTritmqty);
			
			return iItemTritmqtyExt;
		}
	}
}
