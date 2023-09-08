//PROJECT NAME: Material
//CLASS NAME: ItemwhseValidAllFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemwhseValidAllFactory
	{
		public IItemwhseValidAll Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemwhseValidAll = new Material.ItemwhseValidAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemwhseValidAllExt = timerfactory.Create<Material.IItemwhseValidAll>(_ItemwhseValidAll);
			
			return iItemwhseValidAllExt;
		}
	}
}
