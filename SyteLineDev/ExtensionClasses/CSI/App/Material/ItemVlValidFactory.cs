//PROJECT NAME: Material
//CLASS NAME: ItemVlValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemVlValidFactory
	{
		public IItemVlValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemVlValid = new Material.ItemVlValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemVlValidExt = timerfactory.Create<Material.IItemVlValid>(_ItemVlValid);
			
			return iItemVlValidExt;
		}
	}
}
